
Imports System.Data.OleDb
Imports System.Net.Http.Headers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1

    Dim productstable As New DataTable()
    ' Get the path to the database relative to the project folder
    Dim projectPath As String = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, "..\..\.."))
    Dim dbPath As String = System.IO.Path.Combine(projectPath, "DB\POS.accdb")

    Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" & dbPath & ";"




    '==== Form Load ====
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
        AddHandler dvgproducts.CellDoubleClick, AddressOf dvgproducts_CellDoubleClick
    End Sub

    '==== Product Grid ====
    Private Sub LoadProducts()
        Dim query As String = "
            SELECT 
                ProductID AS ID,
                ItemName AS PRODUCT,
                Price AS OriginalPrice,
                Price AS PRICE,
                SalePrice,
                IsOnSale,
                Category AS CATEGORY,
                Stock AS STOCK
            FROM Products"


        Using connection As New OleDbConnection(connectionString)
            Dim adapter As New OleDbDataAdapter(query, connection)

            productstable.Clear()
            adapter.Fill(productstable)
            dvgproducts.DataSource = productstable
            dvgproducts.Columns("Price").DefaultCellStyle.Format = "C2"
            dvgproducts.Columns("ID").Visible = False
            dvgproducts.Columns("IsOnSale").Visible = False
            dvgproducts.Columns("SalePrice").Visible = False
            dvgproducts.Columns("OriginalPrice").Visible = False
            ProcessProductRows()

        End Using
    End Sub


    Private Sub dvgproducts_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dvgproducts.DataBindingComplete
        Me.BeginInvoke(Sub()
                           dvgproducts.ClearSelection()
                           dvgproducts.CurrentCell = Nothing
                       End Sub)
    End Sub

    Private Sub dvgproducts_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim selectedRow As DataGridViewRow = dvgproducts.Rows(e.RowIndex)

        Dim productID As String = selectedRow.Cells("ID").Value.ToString()
        Dim productName As String = selectedRow.Cells("PRODUCT").Value.ToString()
        Dim originalPrice As Decimal = Convert.ToDecimal(selectedRow.Cells("OriginalPrice").Value)
        Dim isOnSale As Boolean = Convert.ToBoolean(selectedRow.Cells("IsOnSale").Value)
        Dim salePrice As Decimal = If(Not IsDBNull(selectedRow.Cells("SalePrice").Value), Convert.ToDecimal(selectedRow.Cells("SalePrice").Value), originalPrice)

        Dim finalPrice As Decimal = If(isOnSale, salePrice, originalPrice)
        Dim discount As Decimal = If(isOnSale, originalPrice - salePrice, 0D)


        dvgcart.Rows.Add(productID, productName, finalPrice, discount)

        UpdateTotal()
        CalculateChange()
        dvgcart.ClearSelection()
    End Sub




    '==== Cart Logic ====
    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnremoveitem.Click
        If dvgcart.SelectedRows.Count > 0 Then
            Dim rowsToRemove As New List(Of DataGridViewRow)
            For Each row As DataGridViewRow In dvgcart.SelectedRows
                If Not row.IsNewRow Then rowsToRemove.Add(row)
            Next
            For Each row As DataGridViewRow In rowsToRemove
                dvgcart.Rows.Remove(row)
            Next
        End If
        UpdateTotal()
        CalculateChange()
    End Sub

    Private Sub UpdateTotal()
        Dim subtotal As Decimal = 0D
        Dim totalDiscount As Decimal = 0D

        For Each row As DataGridViewRow In dvgcart.Rows
            If Not row.IsNewRow Then
                ' Get price
                Dim priceValue As Object = row.Cells("PRICE").Value
                Dim price As Decimal
                If Decimal.TryParse(priceValue.ToString(), price) Then
                    subtotal += price
                End If

                ' Get discount
                Dim discountValue As Object = row.Cells("Discount").Value
                Dim discount As Decimal
                If Decimal.TryParse(discountValue.ToString(), discount) Then
                    totalDiscount += discount
                End If
            End If
        Next

        lblsubtotalamount.Text = subtotal.ToString("C2")
        lbldiscountamount.Text = totalDiscount.ToString("C2")

        ' Extra discount from textbox
        Dim extraDiscount As Decimal = 0D
        If Decimal.TryParse(tbextradiscount.Text, extraDiscount) AndAlso extraDiscount >= 0 Then
            lblextradiscountamount.Text = extraDiscount.ToString("C2")
        Else
            extraDiscount = 0D
            lblextradiscountamount.Text = "$0.00"
        End If

        ' New subtotal after manual discount
        Dim newSubtotal As Decimal = Math.Max(0, subtotal - extraDiscount)
        lblnewsubtotalamount.Text = newSubtotal.ToString("C2")

        ' Tax and Total
        Dim tax As Decimal = newSubtotal * 0.13D
        Dim total As Decimal = newSubtotal + tax
        lbltaxamount.Text = tax.ToString("C2")
        lbltotalamount.Text = total.ToString("C2")
    End Sub





    '==== Payment Method UI ====
    Private Sub cbpaymentmethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbpaymentmethod.SelectedIndexChanged
        Dim isCash = cbpaymentmethod.SelectedItem?.ToString() = "Cash"
        lblchange.Visible = isCash
        lblchangeamount.Visible = isCash
        lblcashgiven.Visible = isCash
        tbcashtendered.Visible = isCash
    End Sub

    Private Sub tbcashtendered_TextChanged(sender As Object, e As EventArgs) Handles tbcashtendered.TextChanged
        CalculateChange()
    End Sub

    Private Sub CalculateChange()
        Dim tendered As Decimal, total As Decimal
        If Decimal.TryParse(tbcashtendered.Text, tendered) AndAlso Decimal.TryParse(lbltotalamount.Text.Replace("$", "").Trim(), total) Then
            Dim change As Decimal = tendered - total
            lblchangeamount.Text = If(change >= 0, change.ToString("C2"), "Insufficient")
        Else
            lblchangeamount.Text = ""
        End If
    End Sub

    '==== Checkout Flow ====
    Private Sub btncheckout_Click(sender As Object, e As EventArgs) Handles btncheckout.Click
        If Not ValidateCheckoutInputs() Then Exit Sub

        Dim totalAmount As Decimal = GetTotalAmount()
        Dim paymentMethod As String = cbpaymentmethod.SelectedItem.ToString()
        Dim customerName As String = tbcustname.Text.Trim()
        Dim customerPhone As String = tbcustphone.Text.Trim()
        Dim customerEmail As String = tbcustemail.Text.Trim()
        Dim saleDate As DateTime = DateTime.Now
        Dim productCounts = GetCartProductCounts()

        ' New discount values
        Dim saleDiscountAmount As Decimal = Convert.ToDecimal(lbldiscountamount.Text.Replace("$", "").Trim())
        Dim extraDiscountAmount As Decimal = Convert.ToDecimal(lblextradiscountamount.Text.Replace("$", "").Trim())

        Using conn As New OleDbConnection(connectionString)
            conn.Open()

            Using transaction As OleDbTransaction = conn.BeginTransaction()
                Try
                    If Not CheckStockAvailability(conn, transaction, productCounts) Then
                        transaction.Rollback()
                        Exit Sub
                    End If

                    If MessageBox.Show("Confirm checkout for total $" & totalAmount.ToString("F2") & "?", "Confirm Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        transaction.Rollback()
                        Exit Sub
                    End If

                    Dim customerId As Integer = InsertOrGetCustomerID(conn, transaction, customerName, customerPhone, customerEmail)
                    Dim saleId = InsertSale(conn, transaction, saleDate, totalAmount, paymentMethod, customerId, saleDiscountAmount, extraDiscountAmount)
                    InsertSaleItems(conn, transaction, saleId, productCounts)
                    UpdateProductStock(conn, transaction, productCounts)

                    transaction.Commit()

                    MessageBox.Show("Sale recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearAll()
                    LoadProducts()
                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Error during checkout: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub




    Private Function ValidateCheckoutInputs() As Boolean
        If dvgcart.Rows.Count = 0 Then
            MessageBox.Show("Cart is empty.")
            Return False
        End If
        If cbpaymentmethod.SelectedIndex = -1 Then
            MessageBox.Show("Please select a payment method.")
            Return False
        End If
        Return True
    End Function

    Private Function GetTotalAmount() As Decimal
        Dim totalText As String = lbltotalamount.Text.Replace("C", "").Replace("$", "").Replace("CAD", "").Trim()
        Dim total As Decimal
        Decimal.TryParse(totalText, total)
        Return total
    End Function

    Private Function GetCartProductCounts() As Dictionary(Of Integer, (Integer, Decimal, Boolean))
        Dim productCounts As New Dictionary(Of Integer, (Integer, Decimal, Boolean))

        For Each row As DataGridViewRow In dvgcart.Rows
            If row.IsNewRow Then Continue For

            Dim productId = Convert.ToInt32(row.Cells("PRODUCTID").Value)
            Dim rawPrice = row.Cells("PRICE").Value?.ToString()
            Dim cleanPrice = System.Text.RegularExpressions.Regex.Replace(rawPrice, "[^\d.]", "")
            Dim price = Convert.ToDecimal(cleanPrice)

            ' Check if item was on sale using the "DISCOUNT FROM SALE" column
            Dim discountValue As Decimal = 0
            Decimal.TryParse(row.Cells("discount")?.Value?.ToString(), discountValue)
            Dim wasOnSale As Boolean = discountValue > 0

            If productCounts.ContainsKey(productId) Then
                Dim existing = productCounts(productId)
                productCounts(productId) = (existing.Item1 + 1, price, existing.Item3 Or wasOnSale)
            Else
                productCounts(productId) = (1, price, wasOnSale)
            End If
        Next

        Return productCounts
    End Function



    Private Function CheckStockAvailability(conn As OleDbConnection, transaction As OleDbTransaction, productCounts As Dictionary(Of Integer, (Quantity As Integer, Price As Decimal, WasOnSale As Boolean))) As Boolean
        For Each kvp In productCounts
            Using cmd As New OleDbCommand("SELECT ItemName, Stock FROM Products WHERE ProductID = ?", conn, transaction)
                cmd.Parameters.AddWithValue("?", kvp.Key)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim stock = Convert.ToInt32(reader("Stock"))
                        If stock < kvp.Value.Item1 Then
                            MessageBox.Show("Not enough stock for '" & reader("ItemName").ToString() & "'. Available: " & stock & ", Needed: " & kvp.Value.Item1)
                            Return False
                        End If
                    Else
                        MessageBox.Show("Product ID " & kvp.Key & " not found.")
                        Return False
                    End If
                End Using
            End Using
        Next
        Return True
    End Function

    Private Function InsertSale(conn As OleDbConnection, transaction As OleDbTransaction, saleDate As DateTime, totalAmount As Decimal, paymentMethod As String, customerId As Integer, saleDiscountAmount As Decimal, extraDiscountAmount As Decimal) As Integer
        Using cmd As New OleDbCommand("INSERT INTO Sales (SaleDate, Amount, PaymentMethod, CustomerID, SaleDiscountAmount, ExtraDiscountAmount) VALUES (?, ?, ?, ?, ?, ?)", conn, transaction)
            cmd.Parameters.Add("?", OleDbType.Date).Value = saleDate
            cmd.Parameters.Add("?", OleDbType.Currency).Value = totalAmount
            cmd.Parameters.Add("?", OleDbType.VarChar).Value = paymentMethod
            cmd.Parameters.Add("?", OleDbType.Integer).Value = customerId
            cmd.Parameters.Add("?", OleDbType.Currency).Value = saleDiscountAmount
            cmd.Parameters.Add("?", OleDbType.Currency).Value = extraDiscountAmount
            cmd.ExecuteNonQuery()
        End Using
        Using cmd As New OleDbCommand("SELECT @@IDENTITY", conn, transaction)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function



    Private Sub InsertSaleItems(conn As OleDbConnection, transaction As OleDbTransaction, saleId As Integer, productCounts As Dictionary(Of Integer, (Quantity As Integer, Price As Decimal, WasOnSale As Boolean)))
        Const taxRate As Decimal = 0.13D

        For Each kvp In productCounts
            Dim productId = kvp.Key
            Dim quantity = kvp.Value.Quantity
            Dim price = kvp.Value.Price
            Dim wasOnSale = kvp.Value.WasOnSale

            Dim amountBeforeTax = price ' this is per unit
            Dim hstAmount = Math.Round(quantity * amountBeforeTax * taxRate, 2)

            Using cmd As New OleDbCommand("INSERT INTO SaleItem (SaleID, ProductID, Quantity, UnitPrice, HSTAmount, WasOnSale) VALUES (?, ?, ?, ?, ?, ?)", conn, transaction)
                cmd.Parameters.AddWithValue("?", saleId)
                cmd.Parameters.AddWithValue("?", productId)
                cmd.Parameters.AddWithValue("?", quantity)
                cmd.Parameters.AddWithValue("?", amountBeforeTax)
                cmd.Parameters.AddWithValue("?", hstAmount)
                cmd.Parameters.AddWithValue("?", wasOnSale)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub





    Private Function InsertOrGetCustomerID(conn As OleDbConnection, transaction As OleDbTransaction, name As String, phone As String, email As String) As Integer
        ' Try to find an existing customer by email (or phone fallback)
        Using cmd As New OleDbCommand("SELECT CustomerID FROM Customer WHERE CustomerEmail = ?", conn, transaction)
            cmd.Parameters.AddWithValue("?", email)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then Return Convert.ToInt32(result)
        End Using

        ' If not found, insert new
        Using cmd As New OleDbCommand("INSERT INTO Customer (CustomerName, CustomerPhone, CustomerEmail) VALUES (?, ?, ?)", conn, transaction)
            cmd.Parameters.AddWithValue("?", If(String.IsNullOrWhiteSpace(name), DBNull.Value, name))
            cmd.Parameters.AddWithValue("?", If(String.IsNullOrWhiteSpace(phone), DBNull.Value, phone))
            cmd.Parameters.AddWithValue("?", If(String.IsNullOrWhiteSpace(email), DBNull.Value, email))
            cmd.ExecuteNonQuery()
        End Using

        ' Return the new ID
        Using cmd As New OleDbCommand("SELECT @@IDENTITY", conn, transaction)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function


    Private Sub UpdateProductStock(conn As OleDbConnection, transaction As OleDbTransaction, productCounts As Dictionary(Of Integer, (Quantity As Integer, Price As Decimal, WasOnSale As Boolean)))
        For Each kvp In productCounts
            Using cmd As New OleDbCommand("UPDATE Products SET Stock = Stock - ? WHERE ProductID = ?", conn, transaction)
                cmd.Parameters.AddWithValue("?", kvp.Value.Quantity)
                cmd.Parameters.AddWithValue("?", kvp.Key)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub


    '==== Misc ====
    Private Sub btnclearall_Click(sender As Object, e As EventArgs) Handles btnclearall.Click
        ClearAll()
    End Sub

    Private Sub ClearAll()
        dvgcart.Rows.Clear()
        cbpaymentmethod.SelectedIndex = -1
        tbcustname.Clear()
        tbcustphone.Clear()
        UpdateTotal()
        tbcashtendered.ResetText()
        tbextradiscount.ResetText()
        tbcustemail.ResetText()
        tbproductname.ResetText()
        cbcategory.SelectedIndex = -1
    End Sub

    Private Sub btnsales_Click(sender As Object, e As EventArgs) Handles btnsales.Click
        Dim salesForm As New SalesForm()
        salesForm.ShowDialog()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles tbproductname.TextChanged
        ApplyProductFilters()
    End Sub


    Private Sub cbCategoryFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbcategory.SelectedIndexChanged
        ApplyProductFilters()
    End Sub

    Private Sub ApplyProductFilters()
        Dim nameFilter As String = tbproductname.Text.Replace("'", "''")
        Dim categoryFilter As String = cbcategory.SelectedItem?.ToString()

        Dim filters As New List(Of String)

        If Not String.IsNullOrEmpty(nameFilter) Then
            filters.Add($"PRODUCT LIKE '%{nameFilter}%'")
        End If

        If Not String.IsNullOrEmpty(categoryFilter) AndAlso categoryFilter <> "All Categories" Then
            filters.Add($"Category = '{categoryFilter}'")
        End If

        Dim finalFilter As String = String.Join(" AND ", filters)

        Dim view As DataView = productstable.DefaultView
        view.RowFilter = finalFilter

        dvgproducts.DataSource = view
        ProcessProductRows()

    End Sub


    Private Sub ProcessProductRows()
        For Each row As DataGridViewRow In dvgproducts.Rows
            If row.IsNewRow Then Continue For

            Dim isOnSale As Boolean = False
            Dim originalPrice As Decimal = 0
            Dim salePrice As Decimal = 0

            If Not IsDBNull(row.Cells("IsOnSale").Value) Then
                isOnSale = Convert.ToBoolean(row.Cells("IsOnSale").Value)
            End If
            If Not IsDBNull(row.Cells("OriginalPrice").Value) Then
                originalPrice = Convert.ToDecimal(row.Cells("OriginalPrice").Value)
            End If
            If Not IsDBNull(row.Cells("SalePrice").Value) Then
                salePrice = Convert.ToDecimal(row.Cells("SalePrice").Value)
            End If

            If isOnSale Then
                row.Cells("Price").Value = salePrice
                row.DefaultCellStyle.BackColor = Color.LightGreen
            Else
                row.Cells("Price").Value = originalPrice
            End If
        Next
    End Sub

    Private Sub dvgproducts_Sorted(sender As Object, e As EventArgs) Handles dvgproducts.Sorted
        ProcessProductRows()
    End Sub

    Private Sub btnrefreshproducts_Click(sender As Object, e As EventArgs) Handles btnrefreshproducts.Click
        LoadProducts()
        dvgcart.Rows.Clear()
        tbproductname.ResetText()
        cbcategory.SelectedIndex = -1
        UpdateTotal()
    End Sub

    Private Sub tbextradiscount_TextChanged(sender As Object, e As EventArgs) Handles tbextradiscount.TextChanged
        UpdateTotal()
    End Sub


End Class
