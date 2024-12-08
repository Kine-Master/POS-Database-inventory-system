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
        Label1 = New Label()
        txtQuantity = New TextBox()
        txtTotalAmount = New TextBox()
        btnAddToCart = New Button()
        dgvCart = New DataGridView()
        btnCheckOut = New Button()
        btnViewOrders = New Button()
        btnInventory = New Button()
        Label2 = New Label()
        Label3 = New Label()
        btnDeleteToCart = New Button()
        ItemName = New DataGridViewTextBoxColumn()
        Quantity = New DataGridViewTextBoxColumn()
        Price = New DataGridViewTextBoxColumn()
        TotalAmount = New DataGridViewTextBoxColumn()
        CType(dgvCart, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 15)
        Label1.TabIndex = 0
        Label1.Text = "SEASPOT CAFE"
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Location = New Point(671, 60)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(100, 23)
        txtQuantity.TabIndex = 2
        ' 
        ' txtTotalAmount
        ' 
        txtTotalAmount.Location = New Point(671, 104)
        txtTotalAmount.Name = "txtTotalAmount"
        txtTotalAmount.Size = New Size(100, 23)
        txtTotalAmount.TabIndex = 3
        ' 
        ' btnAddToCart
        ' 
        btnAddToCart.Location = New Point(671, 133)
        btnAddToCart.Name = "btnAddToCart"
        btnAddToCart.Size = New Size(75, 23)
        btnAddToCart.TabIndex = 4
        btnAddToCart.Text = "ADD"
        btnAddToCart.UseVisualStyleBackColor = True
        ' 
        ' dgvCart
        ' 
        dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCart.Columns.AddRange(New DataGridViewColumn() {ItemName, Quantity, Price, TotalAmount})
        dgvCart.Location = New Point(225, 39)
        dgvCart.Name = "dgvCart"
        dgvCart.Size = New Size(440, 231)
        dgvCart.TabIndex = 5
        ' 
        ' btnCheckOut
        ' 
        btnCheckOut.Location = New Point(670, 247)
        btnCheckOut.Name = "btnCheckOut"
        btnCheckOut.Size = New Size(101, 23)
        btnCheckOut.TabIndex = 6
        btnCheckOut.Text = "CHECHKOUT"
        btnCheckOut.UseVisualStyleBackColor = True
        ' 
        ' btnViewOrders
        ' 
        btnViewOrders.Location = New Point(225, 276)
        btnViewOrders.Name = "btnViewOrders"
        btnViewOrders.Size = New Size(117, 23)
        btnViewOrders.TabIndex = 7
        btnViewOrders.Text = "Order History"
        btnViewOrders.UseVisualStyleBackColor = True
        ' 
        ' btnInventory
        ' 
        btnInventory.Location = New Point(225, 305)
        btnInventory.Name = "btnInventory"
        btnInventory.Size = New Size(117, 23)
        btnInventory.TabIndex = 8
        btnInventory.Text = "Inventory"
        btnInventory.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(671, 42)
        Label2.Name = "Label2"
        Label2.Size = New Size(56, 15)
        Label2.TabIndex = 9
        Label2.Text = "Quantity:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(671, 86)
        Label3.Name = "Label3"
        Label3.Size = New Size(54, 15)
        Label3.TabIndex = 10
        Label3.Text = "Amount:"
        ' 
        ' btnDeleteToCart
        ' 
        btnDeleteToCart.Location = New Point(671, 162)
        btnDeleteToCart.Name = "btnDeleteToCart"
        btnDeleteToCart.Size = New Size(75, 23)
        btnDeleteToCart.TabIndex = 11
        btnDeleteToCart.Text = "DELETE"
        btnDeleteToCart.UseVisualStyleBackColor = True
        ' 
        ' ItemName
        ' 
        ItemName.HeaderText = "Item Name"
        ItemName.Name = "ItemName"
        ' 
        ' Quantity
        ' 
        Quantity.HeaderText = "Quantity"
        Quantity.Name = "Quantity"
        ' 
        ' Price
        ' 
        Price.HeaderText = "Price"
        Price.Name = "Price"
        ' 
        ' TotalAmount
        ' 
        TotalAmount.HeaderText = "Total Amount"
        TotalAmount.Name = "TotalAmount"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnDeleteToCart)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(btnInventory)
        Controls.Add(btnViewOrders)
        Controls.Add(btnCheckOut)
        Controls.Add(dgvCart)
        Controls.Add(btnAddToCart)
        Controls.Add(txtTotalAmount)
        Controls.Add(txtQuantity)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Form1"
        CType(dgvCart, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents dgvCart As DataGridView
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents btnViewOrders As Button
    Friend WithEvents btnInventory As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnDeleteToCart As Button
    Friend WithEvents ItemName As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents Price As DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As DataGridViewTextBoxColumn

End Class
