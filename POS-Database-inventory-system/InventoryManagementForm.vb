Imports System.Data.SQLite

Public Class InventoryManagementForm
    Private connString As String
    Private mainForm As Form1

    Public Sub New(connection As String, parentForm As Form1)
        InitializeComponent()
        connString = connection
        mainForm = parentForm
    End Sub

    Private Sub InventoryManagementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInventory()

        Me.BackColor = Color.FromArgb(245, 235, 220) ' Soft warm beige background
        Me.ForeColor = Color.FromArgb(85, 64, 49) ' Dark brown text color

        ' Buttons
        btnAddItem.BackColor = Color.FromArgb(139, 101, 61)
        btnAddItem.ForeColor = Color.White

        btnEditItem.BackColor = Color.FromArgb(139, 101, 61)
        btnEditItem.ForeColor = Color.White

        btnExit.BackColor = Color.FromArgb(139, 101, 61)
        btnExit.ForeColor = Color.White

        ' Grid styling
        DataGridView1.BackgroundColor = Color.FromArgb(255, 245, 235) ' Light beige grid background
        DataGridView1.ForeColor = Color.FromArgb(85, 64, 49) ' Dark brown text for grid
        DataGridView1.GridColor = Color.FromArgb(139, 101, 61) ' Mocha borders for grid

    End Sub

    Private Sub LoadInventory()
        Try
            Using conn As New SQLiteConnection(connString)
                conn.Open()
                Dim query As String = "SELECT * FROM Inventory"
                Dim cmd As New SQLiteCommand(query, conn)
                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())
                DataGridView1.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading inventory: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        ' Validate the input fields for empty or invalid data
        If String.IsNullOrWhiteSpace(txtItemName.Text) Then
            MessageBox.Show("Please enter an item name.")
            Return
        End If

        Dim quantity As Integer
        If Not Integer.TryParse(txtQuantity.Text, quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please enter a valid quantity.")
            Return
        End If

        Dim price As Double
        If Not Double.TryParse(txtPrice.Text, price) OrElse price <= 0 Then
            MessageBox.Show("Please enter a valid price.")
            Return
        End If

        ' Proceed with adding the item to the inventory
        Using conn As New SQLiteConnection(connString)
            conn.Open()
            Dim query = "INSERT INTO Inventory (ItemName, Quantity, Price) VALUES (@ItemName, @Quantity, @Price)"
            Dim cmd As New SQLiteCommand(query, conn)
            cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text)
            cmd.Parameters.AddWithValue("@Quantity", quantity)
            cmd.Parameters.AddWithValue("@Price", price)
            cmd.ExecuteNonQuery()
        End Using
        LoadInventory()
    End Sub

    Private Sub btnEditItem_Click(sender As Object, e As EventArgs) Handles btnEditItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Validate the input fields for empty or invalid data
            If String.IsNullOrWhiteSpace(txtItemName.Text) Then
                MessageBox.Show("Please enter an item name.")
                Return
            End If

            Dim quantity As Integer
            If Not Integer.TryParse(txtQuantity.Text, quantity) OrElse quantity <= 0 Then
                MessageBox.Show("Please enter a valid quantity.")
                Return
            End If

            Dim price As Double
            If Not Double.TryParse(txtPrice.Text, price) OrElse price <= 0 Then
                MessageBox.Show("Please enter a valid price.")
                Return
            End If

            ' Proceed with updating the item in the inventory
            Using conn As New SQLiteConnection(connString)
                conn.Open()
                Dim query = "UPDATE Inventory SET ItemName = @ItemName, Quantity = @Quantity, Price = @Price WHERE ItemID = @ItemID"
                Dim cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@ItemID", DataGridView1.SelectedRows(0).Cells("ItemID").Value)
                cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text)
                cmd.Parameters.AddWithValue("@Quantity", quantity)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.ExecuteNonQuery()
            End Using
            LoadInventory()
        Else
            MessageBox.Show("Please select an item to edit.")
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        mainForm.Show()
        Me.Hide()
    End Sub
End Class
