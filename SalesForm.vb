Imports System.Data.OleDb

Public Class SalesForm

    Private salesTable As New DataTable()
    ' Get the path to the database relative to the project folder
    Dim projectPath As String = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, "..\..\.."))
    Dim dbPath As String = System.IO.Path.Combine(projectPath, "DB\POS.accdb")

    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" & dbPath & ";"


    Private currentSaleID As Integer

    Private Sub dvgsales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dvgsales.CellDoubleClick
        If e.RowIndex >= 0 Then
            currentSaleID = Convert.ToInt32(dvgsales.Rows(e.RowIndex).Cells("SaleID").Value)
            LoadSaleItemsForSale(currentSaleID) ' Load sale items into dvgsaleitems
        End If
    End Sub

    Dim SalesHistoryDays As Integer = 15 'set how many days ago you want it to show of sales
    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSalesData()
        UnHighlight()
        Me.Text = "Sales History of Past " & SalesHistoryDays & " Days"
    End Sub



    Private Sub LoadSalesData()
        Dim query As String =
                "SELECT 
                    Sales.SaleID,
                    Sales.SaleDate AS [Date],
                    Sales.PaymentMethod AS [Payment],
                    Sales.Amount AS [Final Amount],
                    Sales.SaleDiscountAmount AS [Discount From Products Sale],
                    Sales.ExtraDiscountAmount AS [Extra Discount Applied],
                    Customer.CustomerName AS [Customer Name],
                    Customer.CustomerPhone AS [Customer Phone],
                    Customer.CustomerEmail as [Customer Email]
                 FROM Sales
                 INNER JOIN Customer ON Sales.CustomerID = Customer.CustomerID
                 WHERE Sales.SaleDate >= DateAdd('d', -" & SalesHistoryDays & ", Date())
                 ORDER BY Sales.SaleDate DESC"



        Using conn As New OleDbConnection(connectionString)
            Dim adapter As New OleDbDataAdapter(query, conn)
            adapter.Fill(salesTable)



            dvgsales.DataSource = salesTable



            dvgsales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            dvgsales.Columns("Discount From Products Sale").DefaultCellStyle.Format = "C2"
            dvgsales.Columns("Extra Discount Applied").DefaultCellStyle.Format = "C2"
            dvgsales.Columns("Final Amount").DefaultCellStyle.Format = "C2"

            FormatSaleDates()
        End Using

        ' hide the internal SaleID
        dvgsales.Columns("SaleID").Visible = False
        dvgsales.Columns("Final Amount").DefaultCellStyle.BackColor = Color.LightGreen

    End Sub

    Private Sub FormatSaleDates()
        dvgsales.Columns("Date").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dvgsales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        For Each row As DataGridViewRow In dvgsales.Rows
            If Not row.IsNewRow Then
                Dim dt As DateTime
                If DateTime.TryParse(row.Cells("Date").Value?.ToString(), dt) Then
                    row.Cells("Date").Value = dt.ToString("yyyy-MM-dd") & vbCrLf & dt.ToString("hh:mm tt")
                End If
            End If
        Next
    End Sub



    Private Sub dvgSales_Sorted(sender As Object, e As EventArgs) Handles dvgsales.Sorted
        UnHighlight()
    End Sub

    Private Sub UnHighlight()
        Me.BeginInvoke(Sub()
                           dvgsales.ClearSelection()
                           dvgsales.CurrentCell = Nothing
                       End Sub)
    End Sub

    Private Sub tbCustomer_TextChanged(sender As Object, e As EventArgs) Handles tbcustomer.TextChanged
        ApplySalesFilter()
    End Sub

    Private Sub ApplySalesFilter()
        Dim customerText As String = tbcustomer.Text.Replace("'", "''")
        Dim filters As New List(Of String)

        If Not String.IsNullOrEmpty(customerText) Then
            filters.Add($"[Customer Name] LIKE '%{customerText}%' OR [Customer Phone] LIKE '%{customerText}%' OR [Customer Email] LIKE '%{customerText}%'")
        End If

        Dim finalFilter As String = String.Join(" AND ", filters)
        Dim view As DataView = salesTable.DefaultView
        view.RowFilter = finalFilter
        dvgsales.DataSource = view
    End Sub




    Private Sub LoadSaleItemsForSale(saleId As Integer)
        Dim saleItemsTable As New DataTable()

        Dim query As String =
            "SELECT 
            P.ItemName AS [Product Name],
            SI.Quantity,
            SI.UnitPrice AS [Unit Price],
            SI.HSTAmount AS [HST],
            IIF(SI.WasOnSale, 'Yes', 'No') AS [Was On Sale]
         FROM SaleItem SI
         INNER JOIN Products P ON SI.ProductID = P.ProductID
         WHERE SI.SaleID = ?"

        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("?", saleId)

                Using adapter As New OleDbDataAdapter(cmd)
                    adapter.Fill(saleItemsTable)
                End Using
            End Using
        End Using

        dvgsaleitems.DataSource = saleItemsTable

        ' Format currency columns
        dvgsaleitems.Columns("Unit Price").DefaultCellStyle.Format = "C2"
        dvgsaleitems.Columns("HST").DefaultCellStyle.Format = "C2"
        dvgsaleitems.Columns("Product Name").ReadOnly = True
        dvgsaleitems.Columns("Quantity").ReadOnly = True
        dvgsaleitems.Columns("Unit Price").ReadOnly = True
        dvgsaleitems.Columns("HST").ReadOnly = True
        dvgsaleitems.Columns("Was On Sale").ReadOnly = True

        If Not dvgsaleitems.Columns.Contains("Return Quantity") Then
            Dim returnQtyCol As New DataGridViewTextBoxColumn()
            returnQtyCol.Name = "Return Quantity"
            returnQtyCol.HeaderText = "Return Quantity"
            returnQtyCol.ValueType = GetType(Integer)
            returnQtyCol.DefaultCellStyle.NullValue = "0"
            returnQtyCol.ReadOnly = False
            dvgsaleitems.Columns.Add(returnQtyCol)
        End If


        dvgsaleitems.ClearSelection()

    End Sub

    Private Sub dvgsaleitems_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dvgsaleitems.CellValueChanged
        If e.RowIndex >= 0 AndAlso dvgsaleitems.Columns(e.ColumnIndex).Name = "Return Quantity" Then
            UpdateRefundAmountLabel()
        End If
    End Sub

    Private Sub dvgsaleitems_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dvgsaleitems.EditingControlShowing
        Dim tb As TextBox = TryCast(e.Control, TextBox)
        If tb IsNot Nothing Then
            RemoveHandler tb.KeyUp, AddressOf RefundAmount_KeyUp
            AddHandler tb.KeyUp, AddressOf RefundAmount_KeyUp
        End If
    End Sub

    Private Sub RefundAmount_KeyUp(sender As Object, e As KeyEventArgs)
        UpdateRefundAmountLabel()
    End Sub

    Private Sub UpdateRefundAmountLabel()
        Dim totalRefund As Decimal = 0D

        For Each row As DataGridViewRow In dvgsaleitems.Rows
            If row.IsNewRow Then Continue For

            Dim returnQty As Integer
            Integer.TryParse(row.Cells("Return Quantity").Value?.ToString(), returnQty)

            If returnQty > 0 Then
                Dim unitPrice As Decimal = Convert.ToDecimal(row.Cells("Unit Price").Value)
                Dim hst As Decimal = Convert.ToDecimal(row.Cells("HST").Value)
                totalRefund += (unitPrice + hst) * returnQty
            End If
        Next

        lblRefundAmount.Text = $"{totalRefund:C}"
    End Sub



    Private Sub btnProcessReturn_Click(sender As Object, e As EventArgs) Handles btnProcessReturn.Click
        If cmbRefundMethod.SelectedIndex = -1 Then
            MessageBox.Show("Please select a refund method.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim refundMethod As String = cmbRefundMethod.SelectedItem.ToString()
        Dim returnItems As New List(Of (ProductID As Integer, Quantity As Integer, UnitPrice As Decimal))
        Dim totalRefund As Decimal = 0D

        ' Collect returnable items
        For Each row As DataGridViewRow In dvgsaleitems.Rows
            If row.IsNewRow Then Continue For

            Dim returnQty As Integer
            If Not Integer.TryParse(row.Cells("Return Quantity").Value?.ToString(), returnQty) OrElse returnQty <= 0 Then Continue For

            Dim productName As String = row.Cells("Product Name").Value.ToString()
            Dim unitPrice As Decimal = Convert.ToDecimal(row.Cells("Unit Price").Value)
            Dim hst As Decimal = Convert.ToDecimal(row.Cells("HST").Value)
            Dim originalQty As Integer = Convert.ToInt32(row.Cells("Quantity").Value)

            ' Lookup ProductID based on ProductName
            Dim productId As Integer = GetProductIDByName(productName)
            If productId = -1 Then
                MessageBox.Show($"Product '{productName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Validate
            If returnQty > originalQty Then
                MessageBox.Show($"Return quantity for '{productName}' exceeds quantity sold.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            totalRefund += (unitPrice + hst) * returnQty
            returnItems.Add((productId, returnQty, unitPrice))
        Next

        If returnItems.Count = 0 Then
            MessageBox.Show("No return items selected.", "Nothing to Return", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Begin transaction
        Using conn As New OleDbConnection(connectionString)
            conn.Open()
            Dim trans As OleDbTransaction = conn.BeginTransaction()

            Try
                ' Insert into Returns table
                Dim insertReturnCmd As New OleDbCommand("INSERT INTO Returns (SaleID, ReturnDate, RefundAmount, RefundMethod, Notes) VALUES (?, ?, ?, ?, ?)", conn, trans)
                insertReturnCmd.Parameters.Add("?", OleDbType.Integer).Value = currentSaleID
                insertReturnCmd.Parameters.Add("?", OleDbType.Date).Value = Date.Now
                insertReturnCmd.Parameters.Add("?", OleDbType.Currency).Value = totalRefund
                insertReturnCmd.Parameters.Add("?", OleDbType.VarChar).Value = refundMethod
                insertReturnCmd.Parameters.Add("?", OleDbType.VarChar).Value = "" ' Notes

                insertReturnCmd.ExecuteNonQuery()

                ' Get ReturnID of inserted return
                Dim returnId As Integer
                Dim getIdCmd As New OleDbCommand("SELECT @@IDENTITY", conn, trans)
                returnId = Convert.ToInt32(getIdCmd.ExecuteScalar())

                ' Insert into ReturnItem and update stock
                For Each item In returnItems
                    ' Insert ReturnItem
                    Dim insertItemCmd As New OleDbCommand("INSERT INTO ReturnItem (ReturnID, ProductID, Quantity, UnitPrice) VALUES (?, ?, ?, ?)", conn, trans)
                    insertItemCmd.Parameters.AddWithValue("?", returnId)
                    insertItemCmd.Parameters.AddWithValue("?", item.ProductID)
                    insertItemCmd.Parameters.AddWithValue("?", item.Quantity)
                    insertItemCmd.Parameters.AddWithValue("?", item.UnitPrice)
                    insertItemCmd.ExecuteNonQuery()

                    ' Update stock
                    Dim updateStockCmd As New OleDbCommand("UPDATE Products SET Stock = Stock + ? WHERE ProductID = ?", conn, trans)
                    updateStockCmd.Parameters.AddWithValue("?", item.Quantity)
                    updateStockCmd.Parameters.AddWithValue("?", item.ProductID)
                    updateStockCmd.ExecuteNonQuery()
                Next

                trans.Commit()
                MessageBox.Show("Return processed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                lblRefundAmount.Text = "Refund Amount: $0.00"
                cmbRefundMethod.SelectedIndex = 0

                ' Optionally refresh sale data or clear Return Quantity columns
            Catch ex As Exception
                trans.Rollback()
                MessageBox.Show("An error occurred: " & ex.Message & vbCrLf & vbCrLf & ex.StackTrace,
                    "Error Details", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub


    Private Function GetProductIDByName(productName As String) As Integer
        Using conn As New OleDbConnection(connectionString)
            conn.Open()
            Dim cmd As New OleDbCommand("SELECT ProductID FROM Products WHERE ItemName = ?", conn)
            cmd.Parameters.AddWithValue("?", productName.Trim())

            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                Return Convert.ToInt32(result)
            Else
                Return -1
            End If
        End Using
    End Function

End Class
