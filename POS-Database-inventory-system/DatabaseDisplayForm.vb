Imports System.Data.SQLite

Public Class DatabaseDisplayForm
    Private connString As String
    Private mainForm As Form1

    Public Sub New(connection As String, parentForm As Form1)
        InitializeComponent()
        connString = connection
        mainForm = parentForm
    End Sub

    Private Sub DatabaseDisplayForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrders()
        Me.BackColor = Color.FromArgb(255, 245, 235) ' Soft beige background
        Me.ForeColor = Color.FromArgb(85, 64, 49) ' Dark brown text color

        ' Buttons (Mocha color)
        btnExit.BackColor = Color.FromArgb(139, 101, 61) ' Mocha color for exit button
        btnExit.ForeColor = Color.White

        ' Data Grid styling
        DataGridView1.BackgroundColor = Color.FromArgb(255, 245, 235) ' Light beige grid background
        DataGridView1.ForeColor = Color.FromArgb(85, 64, 49) ' Dark brown text for grid
        DataGridView1.GridColor = Color.FromArgb(139, 101, 61) ' Mocha borders for grid

        ' Optional: Customize header style if needed
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(139, 101, 61) ' Mocha color for headers
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White ' White text for headers
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold) ' Bold header text

    End Sub

    Private Sub LoadOrders()
        Try
            Using connection As New SQLiteConnection(connString)
                connection.Open()
                Dim query As String = "SELECT * FROM OrderDetails"
                Using cmd As New SQLiteCommand(query, connection)
                    Dim dt As New DataTable()
                    dt.Load(cmd.ExecuteReader())
                    DataGridView1.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message)
        End Try
    End Sub

    Private Sub btnResetTable_Click(sender As Object, e As EventArgs) Handles btnResetTable.Click
        Dim result = MessageBox.Show("Are you sure you want to reset the entire table?", "Confirm Reset", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Using conn As New SQLiteConnection(connString)
                conn.Open()
                Dim command As New SQLiteCommand("DELETE FROM OrderDetails", conn)
                command.ExecuteNonQuery()
            End Using
            LoadOrders()
        End If
    End Sub

    Private Sub btnDeleteEntry_Click(sender As Object, e As EventArgs) Handles btnDeleteEntry.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim orderId As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("OrderID").Value)
            Using conn As New SQLiteConnection(connString)
                conn.Open()
                Dim command As New SQLiteCommand("DELETE FROM OrderDetails WHERE OrderID = @OrderID", conn)
                command.Parameters.AddWithValue("@OrderID", orderId)
                command.ExecuteNonQuery()
            End Using
            LoadOrders()
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        mainForm.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
