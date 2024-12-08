Imports System.Data.SQLite

Public Class Form1
    Private connString As String = $"Data Source={System.IO.Path.Combine(Application.StartupPath, "posDatabase.db")};Version=3;"

    ' Declare the ComboBox here
    Private cmbItems As New ComboBox()

    ' Declare the DataGridView columns and other properties (Assuming dgvCart exists in the form)
    ' You should have columns like ItemName, Quantity, Price, and TotalAmount in dgvCart.

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(235, 224, 204) ' Light beige background color
        Me.ForeColor = Color.FromArgb(85, 64, 49) ' Dark brown text color

        ' Set button background and text color
        btnCheckOut.BackColor = Color.FromArgb(139, 101, 61) ' Mocha color
        btnCheckOut.ForeColor = Color.White

        btnViewOrders.BackColor = Color.FromArgb(139, 101, 61)
        btnViewOrders.ForeColor = Color.White

        btnInventory.BackColor = Color.FromArgb(139, 101, 61)
        btnInventory.ForeColor = Color.White

        btnAddToCart.BackColor = Color.FromArgb(139, 101, 61)
        btnAddToCart.ForeColor = Color.White

        btnDeleteToCart.BackColor = Color.FromArgb(139, 101, 61)
        btnDeleteToCart.ForeColor = Color.White


        CreateDatabase() ' Create the database on startup

        InitializeComboBox() ' Initialize the ComboBox properties
        LoadItemsIntoComboBox() ' Populate the ComboBox with items from the inventory
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        LoadItemsIntoComboBox() ' Refresh ComboBox items every time Form1 is activated
    End Sub

    ' Create the Database and Tables
    Private Sub CreateDatabase()
        If Not IO.File.Exists("posDatabase.db") Then
            SQLiteConnection.CreateFile("posDatabase.db")
            Using conn As New SQLiteConnection(connString)
                conn.Open()

                ' Create OrderDetails Table
                Dim createOrdersQuery As String = "
                CREATE TABLE IF NOT EXISTS OrderDetails (
                    OrderID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ItemName TEXT,
                    Quantity INTEGER,
                    Price REAL,
                    TotalAmount REAL,
                    OrderDate TEXT
                );"

                ' Create Inventory Table
                Dim createInventoryQuery As String = "
                CREATE TABLE IF NOT EXISTS Inventory (
                    ItemID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ItemName TEXT,
                    Quantity INTEGER,
                    Price REAL
                );"

                Using cmd As New SQLiteCommand(createOrdersQuery, conn)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New SQLiteCommand(createInventoryQuery, conn)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Database and tables created successfully!")
            End Using
        End If
    End Sub

    ' Initialize ComboBox properties
    Private Sub InitializeComboBox()
        ' Set properties of the ComboBox
        cmbItems.Name = "cmbItems"
        cmbItems.Size = New Size(200, 25)
        cmbItems.Location = New Point(10, 50) ' Adjust the location on the form
        cmbItems.DropDownStyle = ComboBoxStyle.DropDownList ' Optional: to restrict editing
        Me.Controls.Add(cmbItems) ' Add ComboBox to the form
    End Sub

    ' Load items into ComboBox from the Inventory table
    Private Sub LoadItemsIntoComboBox()
        ' Ensure the ComboBox is not null before interacting with it
        If cmbItems IsNot Nothing Then
            cmbItems.Items.Clear()

            Using conn As New SQLiteConnection(connString)
                conn.Open()
                Dim query As String = "SELECT ItemName FROM Inventory"
                Using cmd As New SQLiteCommand(query, conn)
                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cmbItems.Items.Add(reader("ItemName").ToString())
                        End While
                    End Using
                End Using
            End Using
        Else
            MessageBox.Show("ComboBox is not initialized.")
        End If
    End Sub

    ' Handle quantity input and calculate the total amount
    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        CalculateTotalAmount()
    End Sub

    ' Calculate Total Amount based on selected item price and quantity
    Private Sub CalculateTotalAmount()
        If cmbItems.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            txtTotalAmount.Text = "0" ' Reset total if no item selected or quantity is empty
            Return
        End If

        Dim selectedItem As String = cmbItems.SelectedItem.ToString()
        Dim itemPrice As Double = GetItemPriceFromInventory(selectedItem)
        Dim quantity As Integer

        If Integer.TryParse(txtQuantity.Text, quantity) Then
            Dim totalAmount As Double = itemPrice * quantity
            txtTotalAmount.Text = totalAmount.ToString("F2") ' Display total amount with 2 decimal places
        Else
            txtTotalAmount.Text = "0" ' If quantity is not a valid number
        End If
    End Sub



    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        ' Ensure item is selected in the ComboBox
        If cmbItems.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            MessageBox.Show("Please select an item and enter a quantity.")
            Return
        End If

        Dim selectedItem As String = cmbItems.SelectedItem.ToString()
        Dim quantity As Integer = Convert.ToInt32(txtQuantity.Text)

        ' Get the available inventory quantity for the selected item
        Dim inventoryQuantity As Integer = GetInventoryQuantity(selectedItem)

        ' Check if the inventory has enough stock or if it's out of stock
        If inventoryQuantity <= 0 Then
            MessageBox.Show($"{selectedItem} is out of stock! Please restock before adding to the cart.")
            Return
        End If

        ' Check if the user is trying to add more than available quantity
        If quantity > inventoryQuantity Then
            MessageBox.Show($"You can only add up to {inventoryQuantity} units of {selectedItem}.")
            Return
        End If

        Dim itemPrice As Double = GetItemPriceFromInventory(selectedItem)
        Dim totalAmount As Double = itemPrice * quantity

        ' Add item to the DataGridView (Cart)
        dgvCart.Rows.Add(selectedItem, quantity, itemPrice, totalAmount)

        ' Optionally, reset ComboBox and Quantity input after adding to cart
        cmbItems.SelectedIndex = -1
        txtQuantity.Clear()
        txtTotalAmount.Clear()
    End Sub

    ' This function gets the available quantity of the selected item in the inventory
    Private Function GetInventoryQuantity(itemName As String) As Integer
        Dim quantity As Integer = 0
        Try
            Using conn As New SQLiteConnection(connString)
                conn.Open()
                Dim query As String = "SELECT Quantity FROM Inventory WHERE ItemName = @ItemName"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ItemName", itemName)
                    quantity = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking inventory quantity: " & ex.Message)
        End Try
        Return quantity
    End Function


    ' Delete from Cart
    Private Sub btnDeleteToCart_Click(sender As Object, e As EventArgs) Handles btnDeleteToCart.Click
        ' Check if a row is selected in the DataGridView
        If dgvCart.SelectedRows.Count > 0 Then
            ' Delete the selected row
            dgvCart.Rows.RemoveAt(dgvCart.SelectedRows(0).Index)
        Else
            MessageBox.Show("Please select an item to delete from the cart.")
        End If
    End Sub

    ' Retrieve the price of an item from the inventory
    Private Function GetItemPriceFromInventory(itemName As String) As Double
        Dim price As Double = 0

        Using conn As New SQLiteConnection(connString)
            conn.Open()
            Dim query As String = "SELECT Price FROM Inventory WHERE ItemName = @ItemName"
            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@ItemName", itemName)
                price = Convert.ToDouble(cmd.ExecuteScalar()) ' Assuming only one price is returned for the item
            End Using
        End Using

        Return price
    End Function

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        Try
            ' Ensure that the DataGridView has at least one row
            If dgvCart.Rows.Count = 0 Then
                MessageBox.Show("No items in the cart to checkout.")
                Return
            End If

            ' Loop through all rows in the DataGridView and insert each row into the database
            For Each row As DataGridViewRow In dgvCart.Rows
                ' Ensure the row is not empty (check if it contains item data)
                If row.Cells("ItemName").Value IsNot Nothing AndAlso row.Cells("Quantity").Value IsNot Nothing AndAlso row.Cells("Price").Value IsNot Nothing AndAlso row.Cells("TotalAmount").Value IsNot Nothing Then
                    Dim itemName As String = row.Cells("ItemName").Value.ToString()
                    Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)
                    Dim price As Double = Convert.ToDouble(row.Cells("Price").Value)
                    Dim totalAmount As Double = Convert.ToDouble(row.Cells("TotalAmount").Value)

                    ' Proceed with adding the order to the database
                    Using conn As New SQLiteConnection(connString)
                        conn.Open()

                        ' Insert each item from the DataGridView into the OrderDetails table
                        Dim query As String = "INSERT INTO OrderDetails (ItemName, Quantity, Price, TotalAmount, OrderDate) 
                                           VALUES (@ItemName, @Quantity, @Price, @TotalAmount, @OrderDate)"
                        Using cmd As New SQLiteCommand(query, conn)
                            cmd.Parameters.AddWithValue("@ItemName", itemName)
                            cmd.Parameters.AddWithValue("@Quantity", quantity)
                            cmd.Parameters.AddWithValue("@Price", price)
                            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount)
                            cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    Using conn As New SQLiteConnection(connString)
                        conn.Open()
                        Dim updateQuery As String = "UPDATE Inventory SET Quantity = Quantity - @Quantity WHERE ItemName = @ItemName"
                        Using cmd As New SQLiteCommand(updateQuery, conn)
                            cmd.Parameters.AddWithValue("@Quantity", quantity)
                            cmd.Parameters.AddWithValue("@ItemName", itemName)
                            cmd.ExecuteNonQuery()

                        End Using
                    End Using
                End If
            Next

            MessageBox.Show("Order(s) Added Successfully!")

            ' Optionally, clear the cart (dgvCart) after checkout
            dgvCart.Rows.Clear()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


    ' Navigate to Orders View
    Private Sub btnViewOrders_Click(sender As Object, e As EventArgs) Handles btnViewOrders.Click
        Dim dbDisplay As New DatabaseDisplayForm(connString, Me)
        dbDisplay.Show()
        Me.Hide()
    End Sub

    ' Navigate to Inventory Management
    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        Dim inventoryForm As New InventoryManagementForm(connString, Me)
        inventoryForm.Show()
        Me.Hide()
    End Sub



End Class
