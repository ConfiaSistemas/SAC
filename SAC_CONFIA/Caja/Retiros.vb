Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Retiros

    Dim dataCajas As DataTable
    Dim adapterCajas As SqlDataAdapter
    Dim adapterRetiros As SqlDataAdapter
    Dim dataRetiros As DataTable
    Dim vistaPreviaRetiro As Boolean
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        iniciarconexionempresa()

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
                consulta = "select id,Fecha,Hora,NoRetiro,Concepto,Format(Monto,'C','es-mx') as Monto,Caja,UsuarioRetiro from retiros where fecha >= '" & fechainserciondesde & "' and fecha <= '" & fechainsercionhasta & "'"
            Case Else
                cajaConsultar = ComboFiltro.Text
                consulta = "select id,Fecha,Hora,NoRetiro,Concepto,Format(Monto,'C','es-mx') as Monto,Caja,UsuarioRetiro from retiros where caja= '" & cajaConsultar & "' and (fecha >= '" & fechainserciondesde & "' and fecha <= '" & fechainsercionhasta & "')"

        End Select


        adapterRetiros = New SqlDataAdapter(consulta, conexionempresa)
        dataRetiros = New DataTable
        adapterRetiros.Fill(dataRetiros)



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
        ' dtdatos.Rows.Clear()
        dtdatos.ScrollBars = ScrollBars.None
        Cargando.Show()
        Cargando.MonoFlat_Label1.Text = "Consultando"
        Cargando.TopMost = True
        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        dtdatos.DataSource = dataRetiros

        dtdatos.ScrollBars = ScrollBars.Both

        Dim total As Double
        total = 0

        For Each row As DataGridViewRow In dtdatos.Rows


            total = total + row.Cells(5).Value



        Next
        lbltotal.Text = FormatCurrency(total)
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
                ReimprimirRetiro(clickCell.Cells(0).Value, clickCell.Cells(3).Value, clickCell.Cells(6).Value, clickCell.Cells(4).Value, clickCell.Cells(5).Value, clickCell.Cells(1).Value, clickCell.Cells(2).Value.ToString)

        End Select
    End Sub

    Private Sub ReimprimirRetiro(idRetiro As String, NoRetiro As String, NoCaja As String, Concepto As String, Monto As Double, FechaRetiro As Date, Tiempo As String)
        Dim P As New PrinterClass(Impresora, Application.StartupPath, vistaPreviaRetiro)

        With P

            .AlignCenter()
            .RTL = False
            .AlignCenter()
            .Gotox(1050)
            .PrintLogo()
            .GotoSixth(1)
            .NormalFont()
            .FontSize = 8
            .WriteLine("Retiro")
            .WriteLine("")

            .DrawLine()
            .GotoSixth(1)
            .FontSize = 7.3
            .Bold = True
            .WriteChars("ID:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(idRetiro)
            .WriteLine("")
            .Bold = True
            .GotoSixth(1)
            .WriteChars("NO. DE RETIRO:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(NoRetiro)
            .WriteLine("")
            .GotoSixth(1)
            .Bold = True
            .WriteChars("Caja")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(NoCaja)
            .WriteLine("")
            .GotoSixth(1)
            .Bold = True
            .WriteChars("CONCEPTO:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(Concepto)
            .WriteLine("")
            .GotoSixth(1)
            .Bold = True
            .WriteChars("MONTO:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars((Monto).ToString("$ ##,##00.00"))
            .WriteLine("")


            .GotoSixth(1)
            .Bold = True

            .WriteChars("FECHA Y HORA:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(FechaRetiro.ToString("yyyy-MM-dd") & " - " & Tiempo)

            .WriteLine("")

            .CutPaper()
            .EndDoc()

        End With

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
            vistaPreviaRetiro = True
        Else

            vistaPreviaRetiro = False

        End If


    End Sub

    Private Sub dateDesde_onValueChanged(sender As Object, e As EventArgs) Handles dateDesde.onValueChanged

    End Sub
End Class