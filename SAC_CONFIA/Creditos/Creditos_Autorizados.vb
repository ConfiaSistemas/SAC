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
(select SinEntregar.*,isnull((select count(id) from ticket where idCredito = SinEntregar.id and and estado='A' and TipoDoc = '2'),0) as Cobrado,isnull((select count(id) from ticket where idCredito = SinEntregar.id and TipoDoc = (select id from tipodoc where nombre='Enganche Motocicleta')),0) as EngancheCobrado,(case when exists(select * from Motocicletas where idCredito = SinEntregar.id) then (select (Valor*(SinEntregar.enganche/100)) as engancheMoto from Motocicletas where idCredito=SinEntregar.id) else 0 end) as EngancheMoto from
(select credito.id,credito.Fecha,credito.Nombre,credito.Monto,credito.Plazo,tiposdecredito.moto,tiposdecredito.Comision,tiposdecredito.Enganche,tiposdecredito.Nombre as NombreTipo from credito inner join tiposdecredito on credito.tipo = tiposdecredito.id where Estado = 'E') SinEntregar) ComisionCobrada where (moto=1 and Cobrado=0 and EngancheCobrado=0 ) or (moto=1 and Cobrado=1 and EngancheCobrado=0 ) or (moto=1 and Cobrado=0 and EngancheCobrado=1 ) or (moto=0 and Cobrado=0 and EngancheCobrado=0 )"

            Dim ejec = New SqlCommand(strimpuestos)
            ejec.Connection = conexionempresa
            Dim id, nombre, valor, factor, tipo As String

            Dim myreaderimpuestos As SqlDataReader = ejec.ExecuteReader()
            While myreaderimpuestos.Read
                id = myreaderimpuestos("id")
                nombre = myreaderimpuestos("nombre")
                If myreaderimpuestos("moto") Then
                    dtimpuestos.Rows.Add(id, myreaderimpuestos("fecha"), nombre, FormatCurrency(myreaderimpuestos("Monto"), 2), myreaderimpuestos("moto"), myreaderimpuestos("Comision"), myreaderimpuestos("Enganche"), myreaderimpuestos("NombreTipo"), myreaderimpuestos("Plazo"), myreaderimpuestos("EngancheCobrado"), myreaderimpuestos("Cobrado"), myreaderimpuestos("EngancheMoto"))
                Else
                    dtimpuestos.Rows.Add(id, myreaderimpuestos("fecha"), nombre, FormatCurrency(myreaderimpuestos("Monto"), 2), myreaderimpuestos("moto"), myreaderimpuestos("Comision"), "No Aplica", myreaderimpuestos("NombreTipo"), myreaderimpuestos("Plazo"), "No Aplica", myreaderimpuestos("Cobrado"), myreaderimpuestos("EngancheMoto"))

                End If
            End While
            myreaderimpuestos.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CobrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobrarToolStripMenuItem.Click
        If dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(4).Value = "1" Then
            ComisionEnganche.idcredito = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(0).Value
            ComisionEnganche.nombreCredito = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(2).Value
            ComisionEnganche.cp = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(8).Value
            ComisionEnganche.montoCredito = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(3).Value
            ComisionEnganche.Total = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(3).Value * (dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(5).Value / 100)
            ComisionEnganche.Enganche = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(11).Value
            ComisionEnganche.Show()
        Else
            Ticket_Comision.idCreditoRecibo = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(0).Value
            Ticket_Comision.nombre_credito = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(2).Value
            Ticket_Comision.cp = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(8).Value
            Ticket_Comision.montocredito = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(3).Value
            Ticket_Comision.total = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(3).Value * (dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(5).Value / 100)
            Ticket_Comision.ShowDialog()
        End If


    End Sub

    Private Sub dtimpuestos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellContentClick

    End Sub

    Private Sub dtimpuestos_SelectionChanged(sender As Object, e As EventArgs) Handles dtimpuestos.SelectionChanged
        If dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(4).Value = "1" Then
            If dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(9).Value = "0" And dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(10).Value = "0" Then
                dtimpuestos.ContextMenuStrip = ContextMenuStrip1
            ElseIf dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(9).Value = "1" And dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(10).Value = "0" Then
                dtimpuestos.ContextMenuStrip = ContextMenuStrip1
            ElseIf dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(9).Value = "0" And dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(10).Value = "1" Then
                dtimpuestos.ContextMenuStrip = ContextMenuStrip1
            Else


                dtimpuestos.ContextMenuStrip = Nothing
            End If
        Else
            If dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(10).Value = "0" Then
                dtimpuestos.ContextMenuStrip = ContextMenuStrip1
            Else
                dtimpuestos.ContextMenuStrip = Nothing
            End If
        End If


    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        cargarSolicitudes()

    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class