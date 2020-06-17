Imports System.Data.SqlClient

Public Class Creditos_Autorizados
    Private Sub Creditos_Autorizados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarSolicitudes()
    End Sub

    Public Sub cargarSolicitudes()
        dtimpuestos.Rows.Clear()
        Try
            Dim strimpuestos As String
            iniciarconexionempresa()

            strimpuestos = "select * from
(select SinEntregar.*,isnull((select count(id) from ticket where idCredito = SinEntregar.id and TipoDoc = '2'),0) as Cobrado from
(select id,Fecha,Nombre,Monto,Plazo from credito where Estado = 'E') SinEntregar) ComisionCobrada where Cobrado = 0"

            Dim ejec = New SqlCommand(strimpuestos)
            ejec.Connection = conexionempresa
            Dim id, nombre, valor, factor, tipo As String

            Dim myreaderimpuestos As SqlDataReader = ejec.ExecuteReader()
            While myreaderimpuestos.Read
                id = myreaderimpuestos("id")
                nombre = myreaderimpuestos("nombre")

                dtimpuestos.Rows.Add(id, myreaderimpuestos("fecha"), nombre, FormatCurrency(myreaderimpuestos("Monto"), 2), myreaderimpuestos("Plazo"), myreaderimpuestos("Cobrado"))
            End While
            myreaderimpuestos.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CobrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobrarToolStripMenuItem.Click
        Ticket_Comision.idCreditoRecibo = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(0).Value
        Ticket_Comision.nombre_credito = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(2).Value
        Ticket_Comision.cp = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(4).Value
        Ticket_Comision.montocredito = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(3).Value
        Ticket_Comision.total = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(3).Value * 0.04
        Ticket_Comision.ShowDialog()

    End Sub

    Private Sub dtimpuestos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellContentClick

    End Sub

    Private Sub dtimpuestos_SelectionChanged(sender As Object, e As EventArgs) Handles dtimpuestos.SelectionChanged
        If dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(5).Value = "0" Then
            dtimpuestos.ContextMenuStrip = ContextMenuStrip1
        Else
            dtimpuestos.ContextMenuStrip = Nothing
        End If
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        cargarSolicitudes()

    End Sub
End Class