Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class inicio
    Dim ClienteOcredito As String
    Dim idCredito, nombreCredito, estadoCredito As String
    Dim montoCredito, interesCredito, pagoIndividualCredito As Double
    Dim plazo As Integer
    Dim existe As Boolean
    Dim total As Double
    Dim cobrar As Boolean = True
    Dim convenioCredito As Integer
    Public tipoDoc As Integer
    Dim cpConvenio As Integer
    Dim MontoConvenio As Integer
    Public idAnterior As Integer = 0
    Public totalLiquidacion As Double
    Public multasLiquidacion As Double
    Public MontoliquidacionSmultas As Double
    Public Insoluto As Boolean
    Public idConsultado As Integer
    Dim tipoCredito As String
    Dim widthLiquidacion As Integer = 0
    Private Sub inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PanelLiquidacion.Width = 0
        FlushMemory()
        DoubleBuffered = True
        'If frm_adm.BunifuImageButton1.Width + frm_adm.panelusuarios.Width + frm_adm.Panelconfiguracion.Width + frm_adm.Panel3.Width + frm_adm.Panel4.Width + frm_adm.notificaciones.Width + frm_adm.imgperfil.Width + 30 > frm_adm.Panel1.Width Then


        CheckForIllegalCrossThreadCalls = False


        ' Me.Panelsecundario.Visible = True




        ' Else



        ' Me.Panelsecundario.Visible = False





        'End If
        If frm_adm.mostrarpanelsecundario = False Then
            '  Panelsecundario.Visible = False
        Else
            ' Panelsecundario.Visible = True

        End If
        ' Me.Panelsecundario.Left = frm_adm.panelusuarios.Width + frm_adm.Panelconfiguracion.Width + frm_adm.BunifuImageButton1.Width - frm_adm.panelmenus.Width + 10
        'Panelsecundario.Top = 0

    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs)
        'grupos.Show()

    End Sub
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BuscarCredito.tipoCredito = tipoCredito
        BuscarCredito.Show()
    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(sender As Object, e As EventArgs) Handles txtid.OnValueChanged

    End Sub

    Private Sub dtimpuestos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellContentClick
        Totalizar()
    End Sub

    Private Sub BunifuMaterialTextbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtid.KeyDown
        If e.KeyCode = Keys.F2 Then
            BuscarCredito.tipoCredito = tipoCredito
            BuscarCredito.Show()

        End If
        If e.KeyCode = Keys.Enter Then
            dtimpuestos.Rows.Clear()
            dtimpuestos.ScrollBars = ScrollBars.None
            txtid.Enabled = False
            Cargando.Show()
            Cargando.MonoFlat_Label1.Text = "Buscando datos"
            BackgroundWorker1.RunWorkerAsync()

        End If
        If e.KeyCode = Keys.F5 Then
            If CanCobrar Then
                SubCobrar()
            Else
                MessageBox.Show("Haz alcanzado tu límite de cobro, realiza un retiro para poder seguir cobrando")
            End If

        End If

        If e.KeyCode = Keys.F8 Then
            CobroExtra.Show()

        End If
    End Sub

    Private Sub SwitchTipo_CheckedChanged(sender As Object, e As EventArgs) Handles SwitchTipo.CheckedChanged
        If SwitchTipo.Checked Then
            lblTipoCredito.Text = "Normal"
            tipoCredito = "Normal"
        Else
            lblTipoCredito.Text = "Legal"
            tipoCredito = "Legal"
        End If
    End Sub

    Private Sub TimerLiquidación_Tick(sender As Object, e As EventArgs) Handles TimerLiquidación.Tick
        If widthLiquidacion <= 141 Then
            PanelLiquidacion.Width = widthLiquidacion
            widthLiquidacion += 20
        Else
            TimerLiquidación.Stop()
            TimerLiquidación.Enabled = False
        End If

    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        Liquidaciones.idcredito = idCredito
        Liquidaciones.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        dtimpuestos.Rows.Clear()
        PanelLiquidacion.Width = 0
        iniciarconexionempresa()
        Dim comandoDatos As SqlCommand
        Dim consultaDatos As String
        Dim readerDatos As SqlDataReader
        If tipoCredito = "Normal" Then
            consultaDatos = "if exists(select 1 from credito inner join Solicitud on Credito.IdSolicitud=Solicitud.id
			inner join Legales on Legales.idSolicitud=Solicitud.id where Credito.id='" & txtid.Text & "')
            select Legales.id,Legales.Nombre,MontoConvenio as Monto, Legales.Plazo, ('0')as pagoindividual, credito.Estado,  ('0')as Interes from credito inner join Solicitud on Credito.IdSolicitud=Solicitud.id
			inner join Legales on Legales.idSolicitud=Solicitud.id where Credito.id='" & txtid.Text & "'
            else
            Select id,nombre,monto,plazo,interes,pagoindividual,estado from credito where id = '" & txtid.Text & "'"

        Else
            consultaDatos = "Select id,nombre,totaldeuda,plazo,estado from legales where id = '" & txtid.Text & "'"

        End If
        comandoDatos = New SqlCommand
        comandoDatos.Connection = conexionempresa
        comandoDatos.CommandText = consultaDatos
        readerDatos = comandoDatos.ExecuteReader
        If readerDatos.HasRows Then
            While readerDatos.Read
                idCredito = readerDatos("id")
                nombreCredito = readerDatos("nombre")

                plazo = readerDatos("plazo")


                If tipoCredito = "Normal" Then
                    estadoCredito = readerDatos("Estado")
                    interesCredito = readerDatos("interes")
                    pagoIndividualCredito = readerDatos("Pagoindividual")
                    If IsDBNull(readerDatos("monto")) Then
                        montoCredito = 0
                    Else
                        montoCredito = readerDatos("monto")
                    End If

                Else
                    estadoCredito = "L"
                    interesCredito = 0
                    pagoIndividualCredito = 0
                    montoCredito = readerDatos("totalDeuda")
                End If

            End While
            existe = True
        Else
            nombreCredito = "No existe"
            estadoCredito = ""
            existe = False
        End If
        readerDatos.Close()


        If existe Then

            Dim comandoPagos As SqlCommand
            Dim consultaPagos As String
            Dim readerPagos As SqlDataReader
            Select Case estadoCredito
                Case "A"
                    consultaPagos = "select idpago,FechaPago,monto,interes,Pendiente,Abonado,Npago,Estado,Convenio from calendarioNormal where id_credito = '" & idCredito & "' and estado = 'V'"
                    comandoPagos = New SqlCommand
                    comandoPagos.Connection = conexionempresa
                    comandoPagos.CommandText = consultaPagos
                    readerPagos = comandoPagos.ExecuteReader
                    If readerPagos.HasRows Then
                        While readerPagos.Read
                            dtimpuestos.Rows.Add(1, readerPagos("idpago"), readerPagos("npago"), readerPagos("fechaPago"), readerPagos("Monto"), readerPagos("interes"), readerPagos("abonado"), readerPagos("pendiente"), readerPagos("estado"), readerPagos("convenio"))

                        End While
                    End If
                    readerPagos.Close()
                    Dim comandoPagosProximos As SqlCommand
                    Dim consultaPagosProximos As String
                    Dim readerPagosProximos As SqlDataReader
                    consultaPagosProximos = "select top 2 idpago,FechaPago,monto,interes,Pendiente,Abonado,Npago,Estado,Convenio from calendarioNormal where   estado = 'P' and id_credito  = '" & idCredito & "' order by fechapago asc"
                    comandoPagosProximos = New SqlCommand
                    comandoPagosProximos.Connection = conexionempresa
                    comandoPagosProximos.CommandText = consultaPagosProximos
                    readerPagosProximos = comandoPagosProximos.ExecuteReader
                    If readerPagosProximos.HasRows Then
                        While readerPagosProximos.Read
                            dtimpuestos.Rows.Add(0, readerPagosProximos("idpago"), readerPagosProximos("npago"), readerPagosProximos("fechaPago"), readerPagosProximos("Monto"), readerPagosProximos("interes"), readerPagosProximos("abonado"), readerPagosProximos("pendiente"), readerPagosProximos("estado"), readerPagosProximos("convenio"))

                        End While
                    End If
                    tipoDoc = 1
                Case "C"
                    consultaPagos = "select calendarioconveniosSac.idpago,calendarioconveniosSac.FechaPago,calendarioconveniosSac.monto,calendarioconveniosSac.interes,calendarioconveniosSac.Pendiente,calendarioconveniosSac.Abonado,calendarioconveniosSac.Npago,calendarioconveniosSac.Estado,calendarioconveniosSac.Convenio,calendarioconveniossac.idconvenio from calendarioConveniosSac inner join conveniosSac on calendarioconveniosSac.idconvenio = conveniossac.id inner join credito on conveniossac.idcredito = credito.id where conveniossac.idcredito = '" & idCredito & "' and calendarioconveniossac.estado = 'V'"
                    comandoPagos = New SqlCommand
                    comandoPagos.Connection = conexionempresa
                    comandoPagos.CommandText = consultaPagos
                    readerPagos = comandoPagos.ExecuteReader
                    If readerPagos.HasRows Then
                        While readerPagos.Read
                            dtimpuestos.Rows.Add(1, readerPagos("idpago"), readerPagos("npago"), readerPagos("fechaPago"), readerPagos("Monto"), readerPagos("interes"), readerPagos("abonado"), readerPagos("pendiente"), readerPagos("estado"), readerPagos("convenio"))
                            convenioCredito = readerPagos("idconvenio")
                        End While
                    End If
                    readerPagos.Close()
                    Dim comandoPagosProximos As SqlCommand
                    Dim consultaPagosProximos As String
                    Dim readerPagosProximos As SqlDataReader
                    consultaPagosProximos = "select top 2 calendarioconveniosSac.idpago,calendarioconveniosSac.FechaPago,calendarioconveniosSac.monto,calendarioconveniosSac.interes,calendarioconveniosSac.Pendiente,calendarioconveniosSac.Abonado,calendarioconveniosSac.Npago,calendarioconveniosSac.Estado,calendarioconveniosSac.Convenio,calendarioconveniossac.idconvenio from calendarioConveniosSac inner join conveniosSac on calendarioconveniosSac.idconvenio = conveniossac.id inner join credito on conveniossac.idcredito = credito.id where   calendarioconveniossac.estado = 'P' and conveniossac.idcredito  = '" & idCredito & "' order by calendarioconveniossac.fechapago asc"
                    comandoPagosProximos = New SqlCommand
                    comandoPagosProximos.Connection = conexionempresa
                    comandoPagosProximos.CommandText = consultaPagosProximos
                    readerPagosProximos = comandoPagosProximos.ExecuteReader
                    If readerPagosProximos.HasRows Then
                        While readerPagosProximos.Read
                            dtimpuestos.Rows.Add(0, readerPagosProximos("idpago"), readerPagosProximos("npago"), readerPagosProximos("fechaPago"), readerPagosProximos("Monto"), readerPagosProximos("interes"), readerPagosProximos("abonado"), readerPagosProximos("pendiente"), readerPagosProximos("estado"), readerPagosProximos("convenio"))
                            convenioCredito = readerPagosProximos("idconvenio")
                        End While
                    End If
                    tipoDoc = ObtenerTipoDoc("Convenio")
                Case "L"
                    Dim ComandoLegal As SqlCommand
                    Dim ConsultaLegal As String
                    Dim ReaderLegal As SqlDataReader
                    ConsultaLegal = "Select id, montoconvenio, plazo, from legales"
                    consultaPagos = "select idpago,FechaPago,monto,interes,Pendiente,Abonado,Npago,Estado from calendariolegales where idcredito = '" & idCredito & "' and estado = 'V'"
                    comandoPagos = New SqlCommand
                    comandoPagos.Connection = conexionempresa
                    comandoPagos.CommandText = consultaPagos
                    readerPagos = comandoPagos.ExecuteReader
                    If readerPagos.HasRows Then
                        While readerPagos.Read
                            dtimpuestos.Rows.Add(1, readerPagos("idpago"), readerPagos("npago"), readerPagos("fechaPago"), readerPagos("Monto"), readerPagos("interes"), readerPagos("abonado"), readerPagos("pendiente"), readerPagos("estado"), 0)

                        End While
                    End If
                    readerPagos.Close()
                    Dim comandoPagosProximos As SqlCommand
                    Dim consultaPagosProximos As String
                    Dim readerPagosProximos As SqlDataReader
                    consultaPagosProximos = "select top 2 idpago,FechaPago,monto,interes,Pendiente,Abonado,Npago,Estado from calendariolegales where   estado = 'P' and idcredito  = '" & idCredito & "' order by fechapago asc"
                    comandoPagosProximos = New SqlCommand
                    comandoPagosProximos.Connection = conexionempresa
                    comandoPagosProximos.CommandText = consultaPagosProximos
                    readerPagosProximos = comandoPagosProximos.ExecuteReader
                    If readerPagosProximos.HasRows Then
                        While readerPagosProximos.Read
                            dtimpuestos.Rows.Add(0, readerPagosProximos("idpago"), readerPagosProximos("npago"), readerPagosProximos("fechaPago"), readerPagosProximos("Monto"), readerPagosProximos("interes"), readerPagosProximos("abonado"), readerPagosProximos("pendiente"), readerPagosProximos("estado"), 0)

                        End While
                    End If

                    tipoDoc = ObtenerTipoDoc("Legal")
                Case Else
                    MessageBox.Show("El crédito no se encuentra activo por lo tanto no puedes cobrarle")
            End Select
        Else

        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        dtimpuestos.ScrollBars = ScrollBars.Both
        total = 0

        For Each row As DataGridViewRow In dtimpuestos.Rows
            If row.Cells(0).Value = 1 Then
                total = total + row.Cells(7).Value
            End If


        Next
        lblpago.Text = FormatCurrency(total, 2)
        lblnombre.Text = nombreCredito
        txtid.Enabled = True
        txtid.Select()
        CanCobrar = PuedeCobrar()

        Cargando.Close()
        FlushMemory()
        widthLiquidacion = 0
        If estadoCredito = "A" Then
            TimerLiquidación.Enabled = True
        End If
    End Sub
    Public Sub Totalizar()
        Dim total2 As Double = 0
        For Each row As DataGridViewRow In dtimpuestos.Rows
            Dim c As Boolean
            c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))

            If c Then
                total2 = total2 + row.Cells(7).Value
            Else

            End If
        Next


        total = total2

        lblpago.Text = FormatCurrency(total, 2)
    End Sub
    Public Sub SubCobrar()
        If CanCobrar Then


            Dim nombredoc As String
            nombredoc = GetNombreDoc(tipoDoc)
            If nombredoc = "Liquidación Insoluto" Or nombredoc = "Renovación Insoluto" Then
                Ticket_impresion.total = totalLiquidacion
                Ticket_impresion.MultasLiquidacion = multasLiquidacion
                Ticket_impresion.MontoLiquidacionSmultas = MontoliquidacionSmultas
            Else

                Ticket_impresion.total = lblpago.Text

            End If
            Ticket_impresion.idCreditoRecibo = idCredito

            Ticket_impresion.montocredito = montoCredito
            Ticket_impresion.pcmil = interesCredito
            Ticket_impresion.cp = plazo
            Ticket_impresion.tipoDoc = tipoDoc
            Ticket_impresion.convenio = convenioCredito
            Ticket_impresion.cpConvenio = cpConvenio
            Ticket_impresion.montoConvenio = MontoConvenio
            Ticket_impresion.nombre_credito = nombreCredito
            Ticket_impresion.insoluto = Insoluto
            Ticket_impresion.Show()
            Ticket_impresion.TopMost = True
        Else
            MessageBox.Show("Has alcanzado el límite de dinero en caja, realiza un retiro para poder seguir cobrando")
        End If



    End Sub
End Class