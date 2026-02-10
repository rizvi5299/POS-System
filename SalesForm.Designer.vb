<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dvgsales = New System.Windows.Forms.DataGridView()
        Me.tbcustomer = New System.Windows.Forms.TextBox()
        Me.dvgsaleitems = New System.Windows.Forms.DataGridView()
        Me.lblRefundAmount = New System.Windows.Forms.Label()
        Me.cmbRefundMethod = New System.Windows.Forms.ComboBox()
        Me.btnProcessReturn = New System.Windows.Forms.Button()
        Me.lblrefund = New System.Windows.Forms.Label()
        CType(Me.dvgsales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvgsaleitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dvgsales
        '
        Me.dvgsales.AllowUserToAddRows = False
        Me.dvgsales.AllowUserToDeleteRows = False
        Me.dvgsales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dvgsales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dvgsales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dvgsales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvgsales.Location = New System.Drawing.Point(1, 40)
        Me.dvgsales.Name = "dvgsales"
        Me.dvgsales.ReadOnly = True
        Me.dvgsales.RowHeadersVisible = False
        Me.dvgsales.RowHeadersWidth = 51
        Me.dvgsales.RowTemplate.Height = 24
        Me.dvgsales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dvgsales.Size = New System.Drawing.Size(941, 366)
        Me.dvgsales.TabIndex = 0
        '
        'tbcustomer
        '
        Me.tbcustomer.Location = New System.Drawing.Point(12, 12)
        Me.tbcustomer.Name = "tbcustomer"
        Me.tbcustomer.Size = New System.Drawing.Size(100, 22)
        Me.tbcustomer.TabIndex = 1
        '
        'dvgsaleitems
        '
        Me.dvgsaleitems.AllowUserToAddRows = False
        Me.dvgsaleitems.AllowUserToDeleteRows = False
        Me.dvgsaleitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dvgsaleitems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dvgsaleitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dvgsaleitems.DefaultCellStyle = DataGridViewCellStyle2
        Me.dvgsaleitems.Location = New System.Drawing.Point(1, 426)
        Me.dvgsaleitems.Name = "dvgsaleitems"
        Me.dvgsaleitems.RowHeadersVisible = False
        Me.dvgsaleitems.RowHeadersWidth = 51
        Me.dvgsaleitems.RowTemplate.Height = 24
        Me.dvgsaleitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dvgsaleitems.Size = New System.Drawing.Size(439, 362)
        Me.dvgsaleitems.TabIndex = 2
        '
        'lblRefundAmount
        '
        Me.lblRefundAmount.AutoSize = True
        Me.lblRefundAmount.Location = New System.Drawing.Point(614, 456)
        Me.lblRefundAmount.Name = "lblRefundAmount"
        Me.lblRefundAmount.Size = New System.Drawing.Size(38, 16)
        Me.lblRefundAmount.TabIndex = 3
        Me.lblRefundAmount.Text = "$0.00"
        '
        'cmbRefundMethod
        '
        Me.cmbRefundMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRefundMethod.FormattingEnabled = True
        Me.cmbRefundMethod.Items.AddRange(New Object() {"Cash", "Credit Card", "Debit Card", "Store Credit"})
        Me.cmbRefundMethod.Location = New System.Drawing.Point(507, 535)
        Me.cmbRefundMethod.Name = "cmbRefundMethod"
        Me.cmbRefundMethod.Size = New System.Drawing.Size(121, 24)
        Me.cmbRefundMethod.TabIndex = 4
        '
        'btnProcessReturn
        '
        Me.btnProcessReturn.Location = New System.Drawing.Point(507, 623)
        Me.btnProcessReturn.Name = "btnProcessReturn"
        Me.btnProcessReturn.Size = New System.Drawing.Size(103, 74)
        Me.btnProcessReturn.TabIndex = 5
        Me.btnProcessReturn.Text = "Process Return"
        Me.btnProcessReturn.UseVisualStyleBackColor = True
        '
        'lblrefund
        '
        Me.lblrefund.AutoSize = True
        Me.lblrefund.Location = New System.Drawing.Point(507, 456)
        Me.lblrefund.Name = "lblrefund"
        Me.lblrefund.Size = New System.Drawing.Size(101, 16)
        Me.lblrefund.TabIndex = 6
        Me.lblrefund.Text = "Refund Amount:"
        '
        'SalesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 790)
        Me.Controls.Add(Me.lblrefund)
        Me.Controls.Add(Me.btnProcessReturn)
        Me.Controls.Add(Me.cmbRefundMethod)
        Me.Controls.Add(Me.lblRefundAmount)
        Me.Controls.Add(Me.dvgsaleitems)
        Me.Controls.Add(Me.tbcustomer)
        Me.Controls.Add(Me.dvgsales)
        Me.Name = "SalesForm"
        Me.Text = "Sales History"
        CType(Me.dvgsales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvgsaleitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dvgsales As DataGridView
    Friend WithEvents tbcustomer As TextBox
    Friend WithEvents dvgsaleitems As DataGridView
    Friend WithEvents lblRefundAmount As Label
    Friend WithEvents cmbRefundMethod As ComboBox
    Friend WithEvents btnProcessReturn As Button
    Friend WithEvents lblrefund As Label
End Class
