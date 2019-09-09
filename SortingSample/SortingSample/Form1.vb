Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim str As String = ConfigurationManager.ConnectionStrings("CrudConnection").ConnectionString
        Dim con As New SqlConnection(str)
        con.Open()

        Dim cmd As New SqlCommand()

        cmd.Connection = con
        cmd.CommandText = "SELECT *FROM SortingSample"

        Dim dt1 As DataTable = New DataTable()
        Dim adap1 As SqlDataAdapter = New SqlDataAdapter(cmd)

        adap1.Fill(dt1)

        cmd.CommandText = "SELECT *FROM SortingSample2"

        Dim dt2 As DataTable = New DataTable()
        Dim adap2 As SqlDataAdapter = New SqlDataAdapter(cmd)

        adap2.Fill(dt2)

        dt2.Merge(dt1)
        dt2.AcceptChanges()


    End Sub
End Class
