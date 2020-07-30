Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class CobroEmpeño
    Dim ClienteOcredito As String
    Dim idCredito, nombreCredito, estadoCredito As String
    Dim montoCredito, interesCredito, pagoIndividualCredito, interesPendiente, porcentajerefrendo, PendienteEmpeño, abonadoEmpeño As Double
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
    Dim fechaPrimerPago, FechaEntrega, FechaUltimoPago, fechaDefault As Date

    Private Sub inicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FlushMemory()

        DoubleBuffered = True

        'If frm_adm.BunifuImageButton1.Width + frm_adm.panelusuarios.Width + frm_adm.Panelconfiguracion.Width + frm_adm.Panel3.Width + frm_adm.Panel4.Width + frm_adm.notificaciones.Width + frm_adm.imgperfil.Width + 30 > frm_adm.Panel1.Width Then
        fechaDefault = #01/01/1900#


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

    Private Sub txtid_OnValueChanged(sender As Object, e As EventArgs) Handles txtid.OnValueChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BuscarEmpeño.tipoCredito = tipoCredito
        BuscarEmpeño.Show()
    End Sub




    Private Sub BunifuMaterialTextbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtid.KeyDown
        If e.KeyCode = Keys.F2 Then
            BuscarEmpeño.tipoCredito = tipoCredito
            BuscarEmpeño.Show()

        End If
        If e.KeyCode = Keys.Enter Then
            'dtimpuestos.Rows.Clear()
            'dtimpuestos.ScrollBars = ScrollBars.None
            txtid.Enabled = False
            Cargando.Show()
            Cargando.MonoFlat_Label1.Text = "Buscando datos"
            BackgroundWorker1.RunWorkerAsync()

        End If
        If e.KeyCode = Keys.F5 Then
            If CanCobrar Then
                If total = 0 Then
                    MessageBox.Show("El empeño ha pagado todos sus intereses hasta el día de hoy")
                Else
                    If FechaUltimoPago = fechaDefault Then
                        Ticket_impresion.tipoDoc = ObtenerTipoDoc("Comisión por avalúo")
                        Ticket_impresion.idCreditoRecibo = idCredito
                        Ticket_impresion.interesEmpeño = FormatNumber(total, 2)
                        Ticket_impresion.capitalEmpeño = 0
                        Ticket_impresion.montocredito = montoCredito
                        Ticket_impresion.pendienteEmpeño = PendienteEmpeño

                        Ticket_impresion.nombre_credito = nombreCredito
                        Ticket_impresion.total = FormatNumber(total, 2)
                        Ticket_impresion.Show()
                        Ticket_impresion.TopMost = True
                    Else
                        Ticket_impresion.tipoDoc = ObtenerTipoDoc("Refrendo")
                        Ticket_impresion.idCreditoRecibo = idCredito
                        Ticket_impresion.interesEmpeño = FormatNumber(total * 1.16, 2)
                        Ticket_impresion.capitalEmpeño = 0
                        Ticket_impresion.montocredito = montoCredito
                        Ticket_impresion.pendienteEmpeño = PendienteEmpeño
                        Ticket_impresion.abonadoEmpeño = abonadoEmpeño
                        Ticket_impresion.nombre_credito = nombreCredito
                        Ticket_impresion.total = FormatNumber(total * 1.16, 2)
                        Ticket_impresion.Show()
                        Ticket_impresion.TopMost = True
                    End If

                End If

            Else
                MessageBox.Show("Has alcanzado el límite de dinero en caja, realiza un retiro para poder seguir cobrando")

            End If

        End If

        If e.KeyCode = Keys.F8 Then
            CobroExtra.Show()

        End If
    End Sub

    Private Sub txtRefrendo_Click(sender As Object, e As EventArgs) Handles txtRefrendo.Click
        If CanCobrar Then
            If total = 0 Then
                MessageBox.Show("El empeño ha pagado todos sus intereses hasta el día de hoy")
            Else
                If FechaUltimoPago = fechaDefault Then
                    Ticket_impresion.tipoDoc = ObtenerTipoDoc("Comisión por avalúo")
                    Ticket_impresion.idCreditoRecibo = idCredito
                    Ticket_impresion.interesEmpeño = FormatNumber(total, 2)
                    Ticket_impresion.capitalEmpeño = 0
                    Ticket_impresion.montocredito = montoCredito
                    Ticket_impresion.pendienteEmpeño = PendienteEmpeño

                    Ticket_impresion.nombre_credito = nombreCredito
                    Ticket_impresion.total = FormatNumber(total, 2)
                    Ticket_impresion.Show()
                    Ticket_impresion.TopMost = True
                Else
                    Ticket_impresion.tipoDoc = ObtenerTipoDoc("Refrendo")
                    Ticket_impresion.idCreditoRecibo = idCredito
                    Ticket_impresion.interesEmpeño = FormatNumber(total * 1.16, 2)
                    Ticket_impresion.capitalEmpeño = 0
                    Ticket_impresion.montocredito = montoCredito
                    Ticket_impresion.pendienteEmpeño = PendienteEmpeño
                    Ticket_impresion.abonadoEmpeño = abonadoEmpeño
                    Ticket_impresion.nombre_credito = nombreCredito
                    Ticket_impresion.total = FormatNumber(total * 1.16, 2)
                    Ticket_impresion.Show()
                    Ticket_impresion.TopMost = True
                End If

            End If

        Else
            MessageBox.Show("Has alcanzado el límite de dinero en caja, realiza un retiro para poder seguir cobrando")

        End If


    End Sub

    Private Sub txtOtraCantidad_Click(sender As Object, e As EventArgs) Handles txtOtraCantidad.Click
        OtraCantidadEmpeño.idempeño = idCredito
        OtraCantidadEmpeño.abonado = abonadoEmpeño
        OtraCantidadEmpeño.pendiente = PendienteEmpeño
        OtraCantidadEmpeño.interesEmpeño = FormatNumber(total * 1.16, 2)
        OtraCantidadEmpeño.montoEmpeño = montoCredito
        OtraCantidadEmpeño.nombreCredito = nombreCredito

        OtraCantidadEmpeño.ShowDialog()

    End Sub

    Private Sub txtDesempeño_Click(sender As Object, e As EventArgs) Handles txtDesempeño.Click
        If CanCobrar Then

            If FechaUltimoPago = fechaDefault Then
                    MessageBox.Show("No se puede desempeñar, no se ha cobrado la comisión por avalúo")
                Else
                    Ticket_impresion.tipoDoc = ObtenerTipoDoc("Desempeño")
                    Ticket_impresion.idCreditoRecibo = idCredito
                    Ticket_impresion.interesEmpeño = FormatNumber(total * 1.16, 2)
                    Ticket_impresion.capitalEmpeño = PendienteEmpeño
                    Ticket_impresion.montocredito = montoCredito
                    Ticket_impresion.pendienteEmpeño = PendienteEmpeño - PendienteEmpeño
                    Ticket_impresion.abonadoEmpeño = abonadoEmpeño + PendienteEmpeño
                    Ticket_impresion.nombre_credito = nombreCredito
                Ticket_impresion.total = FormatNumber((total * 1.16) + PendienteEmpeño, 2)
                Ticket_impresion.Show()
                    Ticket_impresion.TopMost = True
                End If


        Else
            MessageBox.Show("Has alcanzado el límite de dinero en caja, realiza un retiro para poder seguir cobrando")

        End If
    End Sub









    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'dtimpuestos.Rows.Clear()

        iniciarconexionempresa()
        Dim comandoDatos As SqlCommand
        Dim consultaDatos As String
        Dim readerDatos As SqlDataReader
        'If tipoCredito = "Normal" Then
        consultaDatos = "Select id,nombre,montoPrestado,plazoRefrendo,porcentajeRefrendo,interesdiario,MontoRefrendo,Abonado,Pendiente,FechaPrimerPago,FechaUltimoPago,FechaEntrega,estado from empeños where id = '" & txtid.Text & "'"

        'Else
        'consultaDatos = "Select id,nombre,totaldeuda,plazo,estado from legales where id = '" & txtid.Text & "'"

        'End If
        comandoDatos = New SqlCommand
        comandoDatos.Connection = conexionempresa
        comandoDatos.CommandText = consultaDatos
        readerDatos = comandoDatos.ExecuteReader
        If readerDatos.HasRows Then
            While readerDatos.Read
                idCredito = readerDatos("id")
                nombreCredito = readerDatos("nombre")

                plazo = readerDatos("plazoRefrendo")

                abonadoEmpeño = readerDatos("Abonado")

                estadoCredito = readerDatos("Estado")
                interesCredito = readerDatos("interesdiario")
                pagoIndividualCredito = readerDatos("MontoRefrendo")
                fechaPrimerPago = readerDatos("fechaprimerpago")
                FechaUltimoPago = readerDatos("fechaultimopago")
                FechaEntrega = readerDatos("fechaentrega")
                porcentajerefrendo = readerDatos("porcentajerefrendo") / 7

                PendienteEmpeño = readerDatos("pendiente")
                If IsDBNull(readerDatos("montoPrestado")) Then
                    montoCredito = 0
                Else
                    montoCredito = readerDatos("montoPrestado")
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
                    If FechaUltimoPago = fechaDefault Then
                        total = pagoIndividualCredito
                    Else
                        interesPendiente = (porcentajerefrendo / 100) * PendienteEmpeño
                        total = interesPendiente * DateDiff(DateInterval.Day, FechaUltimoPago, Now.Date)
                    End If
                Case Else
                    MessageBox.Show("El crédito no se encuentra activo por lo tanto no puedes cobrarle")
            End Select
        Else

        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If existe Then
            BunifuTransition1.HideSync(txtPrestado)
            BunifuTransition2.HideSync(txtDesempeño)
            BunifuTransition3.HideSync(txtUltimoPago)
            BunifuTransition4.HideSync(txtInteresDiario)
            BunifuTransition5.HideSync(txtRefrendo)
            BunifuTransition6.HideSync(txtOtraCantidad)
            If FechaUltimoPago = fechaDefault Then
                txtPrestado.Text = FormatCurrency(montoCredito, 2)
                txtDesempeño.Text = FormatCurrency((total) + PendienteEmpeño, 2)
                txtUltimoPago.Text = FechaUltimoPago
                txtInteresDiario.Text = FormatCurrency(interesPendiente, 2)
                txtRefrendo.Text = FormatCurrency(total, 2)
            Else
                txtPrestado.Text = FormatCurrency(montoCredito, 2)
                txtDesempeño.Text = FormatCurrency((total * 1.16) + PendienteEmpeño, 2)
                txtUltimoPago.Text = FechaUltimoPago
                txtInteresDiario.Text = FormatCurrency(interesPendiente * 1.16, 2)
                txtRefrendo.Text = FormatCurrency(total * 1.16, 2)

            End If


            BunifuTransition1.ShowSync(txtPrestado)
            BunifuTransition2.ShowSync(txtDesempeño)
            BunifuTransition3.ShowSync(txtUltimoPago)
            BunifuTransition4.ShowSync(txtInteresDiario)
            BunifuTransition5.ShowSync(txtRefrendo)
            BunifuTransition6.ShowSync(txtOtraCantidad)
        Else
            BunifuTransition1.HideSync(txtPrestado)
            BunifuTransition2.HideSync(txtDesempeño)
            BunifuTransition3.HideSync(txtUltimoPago)
            BunifuTransition4.HideSync(txtInteresDiario)
            BunifuTransition5.HideSync(txtRefrendo)
            BunifuTransition6.HideSync(txtOtraCantidad)

        End If
        'dtimpuestos.ScrollBars = ScrollBars.Both
        '        total = 0

        '   For Each row As DataGridViewRow In 'dtimpuestos.Rows
        'If row.Cells(0).Value = 1 Then
        'total = total + row.Cells(7).Value
        'End If


        '  Next

        ' lblpago.Text = FormatCurrency(total, 2)
        lblnombre.Text = nombreCredito
        txtid.Enabled = True
        txtid.Select()
        CanCobrar = PuedeCobrar()

        Cargando.Close()
        FlushMemory()
        widthLiquidacion = 0
        'If estadoCredito = "A" Then
        'TimerLiquidación.Enabled = True
        'End If
    End Sub

    Public Sub SubCobrar()
        If CanCobrar Then



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

    Private Sub BunifuMetroTextbox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuMetroTextbox2_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            MessageBox.Show("Holaaaa")
        End If
    End Sub

    Private Sub BunifuMetroTextbox2_GotFocus(sender As Object, e As EventArgs)
        MessageBox.Show("Haols")
    End Sub
End Class