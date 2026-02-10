<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dvgproducts = New System.Windows.Forms.DataGridView()
        Me.dvgcart = New System.Windows.Forms.DataGridView()
        Me.ProductID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblsubtotalamount = New System.Windows.Forms.Label()
        Me.tbcustname = New System.Windows.Forms.TextBox()
        Me.tbcustphone = New System.Windows.Forms.TextBox()
        Me.btncheckout = New System.Windows.Forms.Button()
        Me.btnremoveitem = New System.Windows.Forms.Button()
        Me.panelcust = New System.Windows.Forms.Panel()
        Me.tbcustemail = New System.Windows.Forms.TextBox()
        Me.lblcustemail = New System.Windows.Forms.Label()
        Me.lblcustphone = New System.Windows.Forms.Label()
        Me.lblcustname = New System.Windows.Forms.Label()
        Me.btnclearall = New System.Windows.Forms.Button()
        Me.btnsales = New System.Windows.Forms.Button()
        Me.tbproductname = New System.Windows.Forms.TextBox()
        Me.cbcategory = New System.Windows.Forms.ComboBox()
        Me.btnrefreshproducts = New System.Windows.Forms.Button()
        Me.lbldiscountamount = New System.Windows.Forms.Label()
        Me.tbextradiscount = New System.Windows.Forms.TextBox()
        Me.lblproductfilter = New System.Windows.Forms.Label()
        Me.lblcategoryfilter = New System.Windows.Forms.Label()
        Me.lblextradiscount = New System.Windows.Forms.Label()
        Me.cbpaymentmethod = New System.Windows.Forms.ComboBox()
        Me.paneltotal = New System.Windows.Forms.Panel()
        Me.lblnewsubtotalamount = New System.Windows.Forms.Label()
        Me.lblnewsubtotal = New System.Windows.Forms.Label()
        Me.lbldiscount = New System.Windows.Forms.Label()
        Me.lblextradiscountamount = New System.Windows.Forms.Label()
        Me.lbltotalamount = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.lbltaxamount = New System.Windows.Forms.Label()
        Me.lbltax = New System.Windows.Forms.Label()
        Me.panelchange = New System.Windows.Forms.Panel()
        Me.tbcashtendered = New System.Windows.Forms.TextBox()
        Me.lblcashgiven = New System.Windows.Forms.Label()
        Me.lblchange = New System.Windows.Forms.Label()
        Me.lblchangeamount = New System.Windows.Forms.Label()
        Me.lblpaymentmethod = New System.Windows.Forms.Label()
        Me.panelpayment = New System.Windows.Forms.Panel()
        CType(Me.dvgproducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dvgcart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelcust.SuspendLayout()
        Me.paneltotal.SuspendLayout()
        Me.panelchange.SuspendLayout()
        Me.panelpayment.SuspendLayout()
        Me.SuspendLayout()
        '
        'dvgproducts
        '
        Me.dvgproducts.AllowUserToAddRows = False
        Me.dvgproducts.AllowUserToDeleteRows = False
        Me.dvgproducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dvgproducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dvgproducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dvgproducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dvgproducts.DefaultCellStyle = DataGridViewCellStyle2
        Me.dvgproducts.Location = New System.Drawing.Point(12, 89)
        Me.dvgproducts.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dvgproducts.Name = "dvgproducts"
        Me.dvgproducts.ReadOnly = True
        Me.dvgproducts.RowHeadersVisible = False
        Me.dvgproducts.RowHeadersWidth = 51
        Me.dvgproducts.Size = New System.Drawing.Size(497, 555)
        Me.dvgproducts.TabIndex = 0
        '
        'dvgcart
        '
        Me.dvgcart.AllowUserToAddRows = False
        Me.dvgcart.AllowUserToDeleteRows = False
        Me.dvgcart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dvgcart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dvgcart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dvgcart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvgcart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductID, Me.PRODUCT, Me.PRICE, Me.discount})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dvgcart.DefaultCellStyle = DataGridViewCellStyle5
        Me.dvgcart.Location = New System.Drawing.Point(541, 126)
        Me.dvgcart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dvgcart.Name = "dvgcart"
        Me.dvgcart.ReadOnly = True
        Me.dvgcart.RowHeadersVisible = False
        Me.dvgcart.RowHeadersWidth = 51
        Me.dvgcart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dvgcart.Size = New System.Drawing.Size(478, 256)
        Me.dvgcart.TabIndex = 1
        '
        'ProductID
        '
        Me.ProductID.HeaderText = "ProductID"
        Me.ProductID.MinimumWidth = 6
        Me.ProductID.Name = "ProductID"
        Me.ProductID.ReadOnly = True
        Me.ProductID.Visible = False
        '
        'PRODUCT
        '
        Me.PRODUCT.HeaderText = "PRODUCT"
        Me.PRODUCT.MinimumWidth = 6
        Me.PRODUCT.Name = "PRODUCT"
        Me.PRODUCT.ReadOnly = True
        '
        'PRICE
        '
        DataGridViewCellStyle4.Format = "C2"
        Me.PRICE.DefaultCellStyle = DataGridViewCellStyle4
        Me.PRICE.HeaderText = "PRICE"
        Me.PRICE.MinimumWidth = 6
        Me.PRICE.Name = "PRICE"
        Me.PRICE.ReadOnly = True
        '
        'discount
        '
        Me.discount.HeaderText = "DISCOUNT FROM SALE"
        Me.discount.MinimumWidth = 6
        Me.discount.Name = "discount"
        Me.discount.ReadOnly = True
        '
        'lblsubtotalamount
        '
        Me.lblsubtotalamount.AutoSize = True
        Me.lblsubtotalamount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblsubtotalamount.Location = New System.Drawing.Point(715, 395)
        Me.lblsubtotalamount.Name = "lblsubtotalamount"
        Me.lblsubtotalamount.Size = New System.Drawing.Size(61, 25)
        Me.lblsubtotalamount.TabIndex = 2
        Me.lblsubtotalamount.Text = "$0.00"
        '
        'tbcustname
        '
        Me.tbcustname.HideSelection = False
        Me.tbcustname.Location = New System.Drawing.Point(3, 26)
        Me.tbcustname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbcustname.Name = "tbcustname"
        Me.tbcustname.Size = New System.Drawing.Size(125, 22)
        Me.tbcustname.TabIndex = 6
        '
        'tbcustphone
        '
        Me.tbcustphone.Location = New System.Drawing.Point(3, 76)
        Me.tbcustphone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbcustphone.Name = "tbcustphone"
        Me.tbcustphone.Size = New System.Drawing.Size(125, 22)
        Me.tbcustphone.TabIndex = 7
        '
        'btncheckout
        '
        Me.btncheckout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncheckout.BackColor = System.Drawing.Color.PaleGreen
        Me.btncheckout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncheckout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncheckout.Location = New System.Drawing.Point(979, 638)
        Me.btncheckout.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btncheckout.Name = "btncheckout"
        Me.btncheckout.Size = New System.Drawing.Size(136, 88)
        Me.btncheckout.TabIndex = 8
        Me.btncheckout.Text = "CHECKOUT"
        Me.btncheckout.UseVisualStyleBackColor = False
        '
        'btnremoveitem
        '
        Me.btnremoveitem.BackColor = System.Drawing.Color.MistyRose
        Me.btnremoveitem.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnremoveitem.ForeColor = System.Drawing.Color.Black
        Me.btnremoveitem.Location = New System.Drawing.Point(1026, 204)
        Me.btnremoveitem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnremoveitem.Name = "btnremoveitem"
        Me.btnremoveitem.Size = New System.Drawing.Size(93, 85)
        Me.btnremoveitem.TabIndex = 9
        Me.btnremoveitem.Text = "Remove Selected Item(s)"
        Me.btnremoveitem.UseVisualStyleBackColor = False
        '
        'panelcust
        '
        Me.panelcust.Controls.Add(Me.tbcustemail)
        Me.panelcust.Controls.Add(Me.lblcustemail)
        Me.panelcust.Controls.Add(Me.lblcustphone)
        Me.panelcust.Controls.Add(Me.lblcustname)
        Me.panelcust.Controls.Add(Me.tbcustname)
        Me.panelcust.Controls.Add(Me.tbcustphone)
        Me.panelcust.Location = New System.Drawing.Point(979, 422)
        Me.panelcust.Name = "panelcust"
        Me.panelcust.Size = New System.Drawing.Size(149, 191)
        Me.panelcust.TabIndex = 11
        '
        'tbcustemail
        '
        Me.tbcustemail.Location = New System.Drawing.Point(3, 143)
        Me.tbcustemail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbcustemail.Name = "tbcustemail"
        Me.tbcustemail.Size = New System.Drawing.Size(125, 22)
        Me.tbcustemail.TabIndex = 23
        '
        'lblcustemail
        '
        Me.lblcustemail.AutoSize = True
        Me.lblcustemail.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lblcustemail.Location = New System.Drawing.Point(4, 111)
        Me.lblcustemail.Name = "lblcustemail"
        Me.lblcustemail.Size = New System.Drawing.Size(119, 16)
        Me.lblcustemail.TabIndex = 22
        Me.lblcustemail.Text = "Customer Email:"
        '
        'lblcustphone
        '
        Me.lblcustphone.AutoSize = True
        Me.lblcustphone.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lblcustphone.Location = New System.Drawing.Point(0, 58)
        Me.lblcustphone.Name = "lblcustphone"
        Me.lblcustphone.Size = New System.Drawing.Size(132, 16)
        Me.lblcustphone.TabIndex = 8
        Me.lblcustphone.Text = "Customer Phone #"
        '
        'lblcustname
        '
        Me.lblcustname.AutoSize = True
        Me.lblcustname.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lblcustname.Location = New System.Drawing.Point(4, 8)
        Me.lblcustname.Name = "lblcustname"
        Me.lblcustname.Size = New System.Drawing.Size(117, 16)
        Me.lblcustname.TabIndex = 7
        Me.lblcustname.Text = "Customer Name"
        '
        'btnclearall
        '
        Me.btnclearall.BackColor = System.Drawing.Color.Salmon
        Me.btnclearall.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.btnclearall.Location = New System.Drawing.Point(1044, 9)
        Me.btnclearall.Name = "btnclearall"
        Me.btnclearall.Size = New System.Drawing.Size(75, 23)
        Me.btnclearall.TabIndex = 14
        Me.btnclearall.Text = "Clear All"
        Me.btnclearall.UseVisualStyleBackColor = False
        '
        'btnsales
        '
        Me.btnsales.BackColor = System.Drawing.Color.AliceBlue
        Me.btnsales.Location = New System.Drawing.Point(679, 12)
        Me.btnsales.Name = "btnsales"
        Me.btnsales.Size = New System.Drawing.Size(149, 86)
        Me.btnsales.TabIndex = 15
        Me.btnsales.Text = "See Past Sales / Make Returns"
        Me.btnsales.UseVisualStyleBackColor = False
        '
        'tbproductname
        '
        Me.tbproductname.Location = New System.Drawing.Point(34, 36)
        Me.tbproductname.Name = "tbproductname"
        Me.tbproductname.Size = New System.Drawing.Size(146, 22)
        Me.tbproductname.TabIndex = 16
        '
        'cbcategory
        '
        Me.cbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcategory.FormattingEnabled = True
        Me.cbcategory.Items.AddRange(New Object() {"All Categories", "Accessory", "Case", "Headphones", "Laptop", "Phone"})
        Me.cbcategory.Location = New System.Drawing.Point(217, 36)
        Me.cbcategory.Name = "cbcategory"
        Me.cbcategory.Size = New System.Drawing.Size(121, 24)
        Me.cbcategory.TabIndex = 17
        '
        'btnrefreshproducts
        '
        Me.btnrefreshproducts.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.btnrefreshproducts.Location = New System.Drawing.Point(13, 679)
        Me.btnrefreshproducts.Name = "btnrefreshproducts"
        Me.btnrefreshproducts.Size = New System.Drawing.Size(111, 47)
        Me.btnrefreshproducts.TabIndex = 18
        Me.btnrefreshproducts.Text = "Refresh Products"
        Me.btnrefreshproducts.UseVisualStyleBackColor = False
        '
        'lbldiscountamount
        '
        Me.lbldiscountamount.AutoSize = True
        Me.lbldiscountamount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lbldiscountamount.Location = New System.Drawing.Point(867, 395)
        Me.lbldiscountamount.Name = "lbldiscountamount"
        Me.lbldiscountamount.Size = New System.Drawing.Size(61, 25)
        Me.lbldiscountamount.TabIndex = 20
        Me.lbldiscountamount.Text = "$0.00"
        '
        'tbextradiscount
        '
        Me.tbextradiscount.Location = New System.Drawing.Point(808, 456)
        Me.tbextradiscount.Name = "tbextradiscount"
        Me.tbextradiscount.Size = New System.Drawing.Size(100, 22)
        Me.tbextradiscount.TabIndex = 21
        '
        'lblproductfilter
        '
        Me.lblproductfilter.AutoSize = True
        Me.lblproductfilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold)
        Me.lblproductfilter.Location = New System.Drawing.Point(31, 17)
        Me.lblproductfilter.Name = "lblproductfilter"
        Me.lblproductfilter.Size = New System.Drawing.Size(145, 15)
        Me.lblproductfilter.TabIndex = 22
        Me.lblproductfilter.Text = "FILTER BY PRODUCT"
        '
        'lblcategoryfilter
        '
        Me.lblcategoryfilter.AutoSize = True
        Me.lblcategoryfilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold)
        Me.lblcategoryfilter.Location = New System.Drawing.Point(214, 17)
        Me.lblcategoryfilter.Name = "lblcategoryfilter"
        Me.lblcategoryfilter.Size = New System.Drawing.Size(141, 13)
        Me.lblcategoryfilter.TabIndex = 23
        Me.lblcategoryfilter.Text = "FILTER BY CATEGORY"
        '
        'lblextradiscount
        '
        Me.lblextradiscount.AutoSize = True
        Me.lblextradiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblextradiscount.Location = New System.Drawing.Point(805, 436)
        Me.lblextradiscount.Name = "lblextradiscount"
        Me.lblextradiscount.Size = New System.Drawing.Size(113, 17)
        Me.lblextradiscount.TabIndex = 24
        Me.lblextradiscount.Text = "Extra Discount"
        '
        'cbpaymentmethod
        '
        Me.cbpaymentmethod.CausesValidation = False
        Me.cbpaymentmethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbpaymentmethod.Items.AddRange(New Object() {"Cash", "Debit", "Credit"})
        Me.cbpaymentmethod.Location = New System.Drawing.Point(85, 43)
        Me.cbpaymentmethod.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbpaymentmethod.Name = "cbpaymentmethod"
        Me.cbpaymentmethod.Size = New System.Drawing.Size(146, 24)
        Me.cbpaymentmethod.TabIndex = 3
        '
        'paneltotal
        '
        Me.paneltotal.Controls.Add(Me.lblnewsubtotalamount)
        Me.paneltotal.Controls.Add(Me.lblnewsubtotal)
        Me.paneltotal.Controls.Add(Me.lbldiscount)
        Me.paneltotal.Controls.Add(Me.lblextradiscountamount)
        Me.paneltotal.Controls.Add(Me.lbltotalamount)
        Me.paneltotal.Controls.Add(Me.lbltotal)
        Me.paneltotal.Controls.Add(Me.lbltaxamount)
        Me.paneltotal.Controls.Add(Me.lbltax)
        Me.paneltotal.Location = New System.Drawing.Point(237, 7)
        Me.paneltotal.Name = "paneltotal"
        Me.paneltotal.Size = New System.Drawing.Size(215, 195)
        Me.paneltotal.TabIndex = 13
        '
        'lblnewsubtotalamount
        '
        Me.lblnewsubtotalamount.AutoSize = True
        Me.lblnewsubtotalamount.Location = New System.Drawing.Point(117, 77)
        Me.lblnewsubtotalamount.Name = "lblnewsubtotalamount"
        Me.lblnewsubtotalamount.Size = New System.Drawing.Size(38, 16)
        Me.lblnewsubtotalamount.TabIndex = 25
        Me.lblnewsubtotalamount.Text = "$0.00"
        '
        'lblnewsubtotal
        '
        Me.lblnewsubtotal.AutoSize = True
        Me.lblnewsubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnewsubtotal.Location = New System.Drawing.Point(17, 77)
        Me.lblnewsubtotal.Name = "lblnewsubtotal"
        Me.lblnewsubtotal.Size = New System.Drawing.Size(91, 16)
        Me.lblnewsubtotal.TabIndex = 24
        Me.lblnewsubtotal.Text = "SUBTOTAL:"
        '
        'lbldiscount
        '
        Me.lbldiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldiscount.Location = New System.Drawing.Point(11, 28)
        Me.lbldiscount.Name = "lbldiscount"
        Me.lbldiscount.Size = New System.Drawing.Size(97, 38)
        Me.lbldiscount.TabIndex = 23
        Me.lbldiscount.Text = "EXTRA DISCOUNT:"
        Me.lbldiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblextradiscountamount
        '
        Me.lblextradiscountamount.AutoSize = True
        Me.lblextradiscountamount.Location = New System.Drawing.Point(117, 44)
        Me.lblextradiscountamount.Name = "lblextradiscountamount"
        Me.lblextradiscountamount.Size = New System.Drawing.Size(38, 16)
        Me.lblextradiscountamount.TabIndex = 22
        Me.lblextradiscountamount.Text = "$0.00"
        '
        'lbltotalamount
        '
        Me.lbltotalamount.AutoSize = True
        Me.lbltotalamount.Location = New System.Drawing.Point(117, 147)
        Me.lbltotalamount.Name = "lbltotalamount"
        Me.lbltotalamount.Size = New System.Drawing.Size(38, 16)
        Me.lbltotalamount.TabIndex = 8
        Me.lbltotalamount.Text = "$0.00"
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lbltotal.Location = New System.Drawing.Point(48, 147)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(60, 16)
        Me.lbltotal.TabIndex = 7
        Me.lbltotal.Text = "TOTAL:"
        '
        'lbltaxamount
        '
        Me.lbltaxamount.AutoSize = True
        Me.lbltaxamount.Location = New System.Drawing.Point(117, 118)
        Me.lbltaxamount.Name = "lbltaxamount"
        Me.lbltaxamount.Size = New System.Drawing.Size(38, 16)
        Me.lbltaxamount.TabIndex = 6
        Me.lbltaxamount.Text = "$0.00"
        '
        'lbltax
        '
        Me.lbltax.AutoSize = True
        Me.lbltax.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltax.Location = New System.Drawing.Point(66, 118)
        Me.lbltax.Name = "lbltax"
        Me.lbltax.Size = New System.Drawing.Size(42, 16)
        Me.lbltax.TabIndex = 5
        Me.lbltax.Text = "HST:"
        '
        'panelchange
        '
        Me.panelchange.Controls.Add(Me.tbcashtendered)
        Me.panelchange.Controls.Add(Me.lblcashgiven)
        Me.panelchange.Controls.Add(Me.lblchange)
        Me.panelchange.Controls.Add(Me.lblchangeamount)
        Me.panelchange.Location = New System.Drawing.Point(121, 84)
        Me.panelchange.Name = "panelchange"
        Me.panelchange.Size = New System.Drawing.Size(110, 101)
        Me.panelchange.TabIndex = 15
        '
        'tbcashtendered
        '
        Me.tbcashtendered.Location = New System.Drawing.Point(3, 23)
        Me.tbcashtendered.Name = "tbcashtendered"
        Me.tbcashtendered.Size = New System.Drawing.Size(100, 22)
        Me.tbcashtendered.TabIndex = 16
        Me.tbcashtendered.Visible = False
        '
        'lblcashgiven
        '
        Me.lblcashgiven.AutoSize = True
        Me.lblcashgiven.Location = New System.Drawing.Point(3, 4)
        Me.lblcashgiven.Name = "lblcashgiven"
        Me.lblcashgiven.Size = New System.Drawing.Size(104, 16)
        Me.lblcashgiven.TabIndex = 15
        Me.lblcashgiven.Text = "Cash Tendered:"
        Me.lblcashgiven.Visible = False
        '
        'lblchange
        '
        Me.lblchange.AutoSize = True
        Me.lblchange.Location = New System.Drawing.Point(3, 50)
        Me.lblchange.Name = "lblchange"
        Me.lblchange.Size = New System.Drawing.Size(67, 16)
        Me.lblchange.TabIndex = 14
        Me.lblchange.Text = "CHANGE:"
        Me.lblchange.Visible = False
        '
        'lblchangeamount
        '
        Me.lblchangeamount.AutoSize = True
        Me.lblchangeamount.Location = New System.Drawing.Point(3, 69)
        Me.lblchangeamount.Name = "lblchangeamount"
        Me.lblchangeamount.Size = New System.Drawing.Size(14, 16)
        Me.lblchangeamount.TabIndex = 5
        Me.lblchangeamount.Text = "0"
        Me.lblchangeamount.Visible = False
        '
        'lblpaymentmethod
        '
        Me.lblpaymentmethod.AutoSize = True
        Me.lblpaymentmethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.lblpaymentmethod.Location = New System.Drawing.Point(82, 17)
        Me.lblpaymentmethod.Name = "lblpaymentmethod"
        Me.lblpaymentmethod.Size = New System.Drawing.Size(126, 16)
        Me.lblpaymentmethod.TabIndex = 16
        Me.lblpaymentmethod.Text = "Payment Method:"
        '
        'panelpayment
        '
        Me.panelpayment.Controls.Add(Me.lblpaymentmethod)
        Me.panelpayment.Controls.Add(Me.panelchange)
        Me.panelpayment.Controls.Add(Me.paneltotal)
        Me.panelpayment.Controls.Add(Me.cbpaymentmethod)
        Me.panelpayment.Location = New System.Drawing.Point(515, 484)
        Me.panelpayment.Name = "panelpayment"
        Me.panelpayment.Size = New System.Drawing.Size(455, 242)
        Me.panelpayment.TabIndex = 12
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.ClientSize = New System.Drawing.Size(1128, 733)
        Me.Controls.Add(Me.lblextradiscount)
        Me.Controls.Add(Me.lblcategoryfilter)
        Me.Controls.Add(Me.lblproductfilter)
        Me.Controls.Add(Me.tbextradiscount)
        Me.Controls.Add(Me.lbldiscountamount)
        Me.Controls.Add(Me.btnrefreshproducts)
        Me.Controls.Add(Me.cbcategory)
        Me.Controls.Add(Me.lblsubtotalamount)
        Me.Controls.Add(Me.tbproductname)
        Me.Controls.Add(Me.btnsales)
        Me.Controls.Add(Me.btnclearall)
        Me.Controls.Add(Me.panelpayment)
        Me.Controls.Add(Me.panelcust)
        Me.Controls.Add(Me.btnremoveitem)
        Me.Controls.Add(Me.btncheckout)
        Me.Controls.Add(Me.dvgcart)
        Me.Controls.Add(Me.dvgproducts)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form1"
        Me.Text = "Point of Sales System"
        CType(Me.dvgproducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dvgcart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelcust.ResumeLayout(False)
        Me.panelcust.PerformLayout()
        Me.paneltotal.ResumeLayout(False)
        Me.paneltotal.PerformLayout()
        Me.panelchange.ResumeLayout(False)
        Me.panelchange.PerformLayout()
        Me.panelpayment.ResumeLayout(False)
        Me.panelpayment.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dvgproducts As DataGridView
    Friend WithEvents dvgcart As DataGridView
    Friend WithEvents lblsubtotalamount As Label
    Friend WithEvents tbcustname As TextBox
    Friend WithEvents tbcustphone As TextBox
    Friend WithEvents btncheckout As Button
    Friend WithEvents btnremoveitem As Button
    Friend WithEvents panelcust As Panel
    Friend WithEvents lblcustphone As Label
    Friend WithEvents lblcustname As Label
    Friend WithEvents btnclearall As Button
    Friend WithEvents btnsales As Button
    Friend WithEvents tbproductname As TextBox
    Friend WithEvents cbcategory As ComboBox
    Friend WithEvents btnrefreshproducts As Button
    Friend WithEvents lbldiscountamount As Label
    Friend WithEvents tbextradiscount As TextBox
    Friend WithEvents ProductID As DataGridViewTextBoxColumn
    Friend WithEvents PRODUCT As DataGridViewTextBoxColumn
    Friend WithEvents PRICE As DataGridViewTextBoxColumn
    Friend WithEvents discount As DataGridViewTextBoxColumn
    Friend WithEvents tbcustemail As TextBox
    Friend WithEvents lblcustemail As Label
    Friend WithEvents lblproductfilter As Label
    Friend WithEvents lblcategoryfilter As Label
    Friend WithEvents lblextradiscount As Label
    Friend WithEvents cbpaymentmethod As ComboBox
    Friend WithEvents paneltotal As Panel
    Friend WithEvents lblnewsubtotalamount As Label
    Friend WithEvents lblnewsubtotal As Label
    Friend WithEvents lbldiscount As Label
    Friend WithEvents lblextradiscountamount As Label
    Friend WithEvents lbltotalamount As Label
    Friend WithEvents lbltotal As Label
    Friend WithEvents lbltaxamount As Label
    Friend WithEvents lbltax As Label
    Friend WithEvents panelchange As Panel
    Friend WithEvents tbcashtendered As TextBox
    Friend WithEvents lblcashgiven As Label
    Friend WithEvents lblchange As Label
    Friend WithEvents lblchangeamount As Label
    Friend WithEvents lblpaymentmethod As Label
    Friend WithEvents panelpayment As Panel
End Class
