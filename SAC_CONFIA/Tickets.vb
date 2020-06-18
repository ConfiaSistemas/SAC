Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Tickets
    Dim dataCajas As DataTable
    Dim adapterCajas As SqlDataAdapter

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        dtdatos.Rows.Clear()

        iniciarconexionempresa()
        Dim comando As SqlCommand

        Dim reader As SqlDataReader
        Dim consulta As String
        Dim fechainserciondesde As String
        fechainserciondesde = dateDesde.Value.ToShortDateString

        Dim fechasqldesde As Date
        fechasqldesde = fechainserciondesde
        fechainserciondesde = Format(fechasqldesde, "yyyy-MM-dd")


        Dim fechainsercionhasta As String
        fechainsercionhasta = dateHasta.Value.ToShortDateString

        Dim fechasqlhasta As Date
        fechasqlhasta = fechainsercionhasta
        fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")

        Dim cajaConsultar As String
        Select Case ComboFiltro.Text
            Case "Todas"
                consulta = "select Ticket.id,Ticket.Recibido,Ticket.IdCredito,Ticket.Fecha,Ticket.hora,Ticket.total,tipodoc.Nombre as tipo,Ticket.concepto,Ticket.caja,ticket.estado from Ticket  inner join TipoDoc on Ticket.tipodoc = TipoDoc.id where Ticket.fecha >= convert(date,'" & fechainserciondesde & "',102) and Ticket.fecha <= convert(date,'" & fechainsercionhasta & "',102)  order by Ticket.fecha,Ticket.hora asc "
            Case Else
                cajaConsultar = ComboFiltro.Text
                consulta = "select Ticket.id,Ticket.Recibido,Ticket.IdCredito,Ticket.Fecha,Ticket.hora,Ticket.total,tipodoc.Nombre as tipo,Ticket.concepto,Ticket.caja,ticket.estado from Ticket  inner join TipoDoc on Ticket.tipodoc = TipoDoc.id where Ticket.fecha >= convert(date,'" & fechainserciondesde & "',102) and Ticket.fecha <= convert(date,'" & fechainsercionhasta & "',102) and ticket.caja = '" & cajaConsultar & "'  order by Ticket.fecha,Ticket.hora asc "

        End Select


        comando = New SqlCommand
        comando.Connection = conexionempresa
        comando.CommandTimeout = 120
        comando.CommandText = consulta
        reader = comando.ExecuteReader
        Dim recibido As Double = 0
        Dim totalPago As Double = 0
        While reader.Read
            Dim nombrecredito As String

            Select Case reader("tipo")
                Case "Convenio"
                    Dim comandonombre As SqlCommand
                    comandonombre = New SqlCommand

                    Dim consultaNombre As String
                    consultaNombre = "select credito.nombre from conveniossac inner join credito on credito.id = conveniossac.idcredito where conveniossac.id = '" & reader("idcredito") & "'"
                    comandonombre.Connection = conexionempresa
                    comandonombre.CommandText = consultaNombre
                    nombrecredito = comandonombre.ExecuteScalar
                Case "Legal"
                    Dim comandonombre As SqlCommand
                    comandonombre = New SqlCommand

                    Dim consultaNombre As String
                    consultaNombre = "select nombre from legales  where id = '" & reader("idcredito") & "'"
                    comandonombre.Connection = conexionempresa
                    comandonombre.CommandText = consultaNombre
                    nombrecredito = comandonombre.ExecuteScalar
                Case Else
                    Dim comandonombre As SqlCommand
                    comandonombre = New SqlCommand

                    Dim consultaNombre As String
                    consultaNombre = "select nombre from credito  where id = '" & reader("idcredito") & "'"
                    comandonombre.Connection = conexionempresa
                    comandonombre.CommandText = consultaNombre
                    nombrecredito = comandonombre.ExecuteScalar
            End Select

            recibido = reader("recibido")
            totalPago = reader("total")
            If recibido > totalPago Then
                Select Case reader("tipo")
                    Case "Convenio"
                        dtdatos.Rows.Add(reader("id"), reader("idcredito"), nombrecredito, reader("Total"), reader("Fecha"), reader("hora"), reader("tipo"), reader("Caja"), reader("estado"))
                    Case "Legal"

                        dtdatos.Rows.Add(reader("id"), reader("idcredito"), nombrecredito, reader("Total"), reader("Fecha"), reader("hora"), reader("tipo"), reader("Caja"), reader("estado"))
                    Case "Extra"
                        dtdatos.Rows.Add(reader("id"), reader("idcredito"), reader("concepto"), reader("Total"), reader("Fecha"), reader("hora"), reader("tipo"), reader("Caja"), reader("estado"))
                    Case Else
                        dtdatos.Rows.Add(reader("id"), reader("idcredito"), nombrecredito, reader("Total"), reader("Fecha"), reader("hora"), reader("tipo"), reader("Caja"), reader("estado"))
                End Select



            Else
                Select Case reader("tipo")

                    Case "Convenio"
                        dtdatos.Rows.Add(reader("id"), reader("idcredito"), nombrecredito, reader("recibido"), Convert.ToDateTime(reader("Fecha")).ToString("yyyy-MM-dd"), reader("hora"), reader("tipo"), reader("Caja"), reader("estado"))
                    Case "Legal"

                        dtdatos.Rows.Add(reader("id"), reader("idcredito"), nombrecredito, reader("recibido"), Convert.ToDateTime(reader("Fecha")).ToString("yyyy-MM-dd"), reader("hora"), reader("tipo"), reader("Caja"), reader("estado"))
                    Case "Extra"
                        dtdatos.Rows.Add(reader("id"), reader("idcredito"), reader("concepto"), reader("recibido"), Convert.ToDateTime(reader("Fecha")).ToString("yyyy-MM-dd"), reader("hora"), reader("tipo"), reader("Caja"), reader("estado"))
                    Case Else
                        dtdatos.Rows.Add(reader("id"), reader("idcredito"), nombrecredito, reader("recibido"), Convert.ToDateTime(reader("Fecha")).ToString("yyyy-MM-dd"), reader("hora"), reader("tipo"), reader("Caja"), reader("estado"))
                End Select


            End If



        End While

        Dim total As Double
        total = 0
        Dim afecta As Boolean
        For Each row As DataGridViewRow In dtdatos.Rows
            afecta = AfectaCaja(row.Cells(6).Value)
            If afecta And row.Cells(8).Value = "A" Then
                total = total + row.Cells(3).Value
            Else

            End If


        Next
        lbltotal.Text = FormatCurrency(total)
    End Sub

    Private Sub MonoFlat_HeaderLabel3_Click(sender As Object, e As EventArgs) Handles lbltotal.Click

    End Sub

    Private Sub BackgroundCajas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundCajas.DoWork
        iniciarconexionempresa()
        Dim consultaCajas As String
        consultaCajas = "Select Nocaja from cajasSucursal"
        adapterCajas = New SqlDataAdapter(consultaCajas, conexionempresa)
        dataCajas = New DataTable
        adapterCajas.Fill(dataCajas)

    End Sub

    Private Sub BackgroundCajas_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundCajas.RunWorkerCompleted
        ComboFiltro.Items.Clear()
        ComboFiltro.Items.Add("Todas")
        For Each row As DataRow In dataCajas.Rows
            ComboFiltro.Items.Add(row("Nocaja").ToString)
        Next
        ComboFiltro.SelectedIndex = 0
        Cargando.Close()
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        dtdatos.Rows.Clear()
        dtdatos.ScrollBars = ScrollBars.None
        Cargando.Show()
        Cargando.MonoFlat_Label1.Text = "Consultando"
        Cargando.TopMost = True
        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        dtdatos.ScrollBars = ScrollBars.Both
        Cargando.Close()

        Cargando.TopMost = False
        Dim _contextmenu As New ContextMenuStrip
        _contextmenu.Items.Add("Reimprimir")

        AddHandler _contextmenu.ItemClicked, AddressOf contextmenu_click
        For Each rw As DataGridViewRow In dtdatos.Rows
            For Each c As DataGridViewCell In rw.Cells
                c.ContextMenuStrip = _contextmenu
            Next
        Next
    End Sub

    Private Sub contextmenu_click(ByVal sender As System.Object,
                                  ByVal e As ToolStripItemClickedEventArgs)
        Dim clickCell As DataGridViewRow = dtdatos.CurrentRow
        Select Case e.ClickedItem.Text
            Case "Reimprimir"
                reimprimirTicket(clickCell.Cells(0).Value)

        End Select
    End Sub

    Private Sub Tickets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateDesde.Value = Now
        dateHasta.Value = Now
        Cargando.Show()
        Cargando.MonoFlat_Label1.Text = "Consultando cajas"
        Cargando.TopMost = True
        BackgroundCajas.RunWorkerAsync()

    End Sub

    Private Sub dtdatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtdatos.CellContentClick

    End Sub

    Private Sub dtdatos_MouseDown(sender As Object, e As MouseEventArgs) Handles dtdatos.MouseDown

    End Sub

    Private Sub dtdatos_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtdatos.CellMouseDown
        If e.RowIndex <> -1 And e.ColumnIndex <> -1 Then
            If e.Button = MouseButtons.Right Then
                Dim clickCell As DataGridViewCell = sender.Rows(e.RowIndex).Cells(e.ColumnIndex)
                clickCell.Selected = True
            End If
        End If
    End Sub

    Private Sub MonoFlat_CheckBox1_CheckedChanged(sender As Object) Handles MonoFlat_CheckBox1.CheckedChanged
        If MonoFlat_CheckBox1.Checked Then
            vistapreviaTicket = True
        Else

            vistapreviaTicket = False

        End If

    End Sub

    Private Sub dateDesde_onValueChanged(sender As Object, e As EventArgs) Handles dateDesde.onValueChanged

    End Sub
End Class