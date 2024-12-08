<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryManagementForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        DataGridView1 = New DataGridView()
        txtItemName = New TextBox()
        txtQuantity = New TextBox()
        txtPrice = New TextBox()
        btnAddItem = New Button()
        btnEditItem = New Button()
        btnExit = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(12, 12)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(424, 358)
        DataGridView1.TabIndex = 0
        ' 
        ' txtItemName
        ' 
        txtItemName.Location = New Point(442, 12)
        txtItemName.Name = "txtItemName"
        txtItemName.Size = New Size(100, 23)
        txtItemName.TabIndex = 1
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Location = New Point(442, 41)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(100, 23)
        txtQuantity.TabIndex = 2
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(442, 70)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(100, 23)
        txtPrice.TabIndex = 3
        ' 
        ' btnAddItem
        ' 
        btnAddItem.Location = New Point(442, 99)
        btnAddItem.Name = "btnAddItem"
        btnAddItem.Size = New Size(75, 23)
        btnAddItem.TabIndex = 4
        btnAddItem.Text = "ADD"
        btnAddItem.UseVisualStyleBackColor = True
        ' 
        ' btnEditItem
        ' 
        btnEditItem.Location = New Point(442, 160)
        btnEditItem.Name = "btnEditItem"
        btnEditItem.Size = New Size(75, 23)
        btnEditItem.TabIndex = 5
        btnEditItem.Text = "EDIT"
        btnEditItem.UseVisualStyleBackColor = True
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(442, 347)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(75, 23)
        btnExit.TabIndex = 6
        btnExit.Text = "EXIT"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' InventoryManagementForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(567, 450)
        Controls.Add(btnExit)
        Controls.Add(btnEditItem)
        Controls.Add(btnAddItem)
        Controls.Add(txtPrice)
        Controls.Add(txtQuantity)
        Controls.Add(txtItemName)
        Controls.Add(DataGridView1)
        Name = "InventoryManagementForm"
        Text = "InventoryManagementForm"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtItemName As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents btnAddItem As Button
    Friend WithEvents btnEditItem As Button
    Friend WithEvents btnExit As Button
End Class
