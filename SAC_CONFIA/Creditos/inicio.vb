Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class inicio
    Dim ClienteOcredito As String
    Dim idCredito, nombreCredito As String
    Public estadoCredito As String
    Dim montoCredito, interesCredito, pagoIndividualCredito As Double
    Dim plazo As Integer
    Dim existe As Boolean
    Dim total As Double
    Dim cobrar As Boolean = True
    Dim convenioCredito As Integer
    Dim idPromesa As Integer
    Public focustxtid As Boolean = False
    Public tipoDoc As Integer
    Dim cpConvenio As Integer
    Dim MontoConvenio As Integer
    Public idAnterior As Integer = 0
    Public totalLiquidacion As Double
    Public multasLiquidacion As Double
    Public MontoliquidacionSmultas As Double
    Public Insoluto As Boolean
    Public idConsultado As Integer
    Public tipoCredito As String
    Dim widthLiquidacion As Integer = 0
    Public autorizado As Boolean
    Dim dataCreditoCliente As DataTable
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SwitchTipo.Checked Then
            BuscarCliente.Show()

        Else
            BuscarCredito.tipoCredito = tipoCredito
            BuscarCredito.Show()
        End If

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

            ' Dim seleccionado As Integer = 0
            '  For Each row As DataGridViewRow In dtimpuestos.Rows
            ' Dim c As Boolean
            'c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))

            'If c Then
            'seleccionado = seleccionado + 1
            '    Else

            'End If
            'Next
            'If seleccionado > 0 Then
            'If CanCobrar Then

            'SubCobrar()
            'Else
            'MessageBox.Show("Haz alcanzado tu límite de cobro, realiza un retiro para poder seguir cobrando")
            'End If
            'Else
            'MessageBox.Show("No has seleccionado ningún pago")
            'End If


        End If

        'If e.KeyCode = Keys.F8 Then
        '    Me.TopMost = False
        '    Autorizacion.TopMost = True
        '    Autorizacion.tipoAutorizacion = "SacCobrarExtra"
        '    Autorizacion.ShowDialog()

        '    Autorizacion.BringToFront()


        '    If autorizado Then
        '        CobroExtra.ShowDialog()
        '    Else
        '        MessageBox.Show("No fue autorizado")
        '    End If

        'End If
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

    Private Sub txtid_OnValueChanged(sender As Object, e As EventArgs) Handles txtid.OnValueChanged

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            dtimpuestos.Rows.Clear()
            PanelLiquidacion.Width = 0
            iniciarconexionempresa()
            Dim comandoDatos As SqlCommand
            Dim consultaDatos As String
            Dim readerDatos As SqlDataReader
            If tipoCredito = "Normal" Then
                If estadoCredito = "L" Then
                    consultaDatos = " select credlegal.*,ISNULL((select id from PromesaDePago where idCredito = credlegal.id and estado = 'A' and tipocredito = 'L'),0) as idPromesa from
                            (Select id,nombre,totaldeuda,plazo,estado from legales where id = '" & txtid.Text & "')credlegal"
                Else
                    consultaDatos = "if exists(select 1 from credito inner join Solicitud on Credito.IdSolicitud=Solicitud.id
			inner join Legales on Legales.idSolicitud=Solicitud.id where Credito.id='" & txtid.Text & "')
            select Legales.id,Legales.Nombre,MontoConvenio as Monto, Legales.Plazo, ('0')as pagoindividual, credito.Estado,  ('0')as Interes from credito inner join Solicitud on Credito.IdSolicitud=Solicitud.id
			inner join Legales on Legales.idSolicitud=Solicitud.id where Credito.id='" & txtid.Text & "'
            else
            select cred.*,ISNULL((select id from PromesaDePago where idCredito = cred.id and estado = 'A'),0) as idPromesa from
			(Select id,nombre,monto,plazo,interes,pagoindividual,estado from credito where id = '" & txtid.Text & "')cred"

                End If

            Else
                consultaDatos = " select credlegal.*,ISNULL((select id from PromesaDePago where idCredito = credlegal.id and estado = 'A' and tipocredito = 'L'),0) as idPromesa from
                            (Select id,nombre,totaldeuda,plazo,estado from legales where id = '" & txtid.Text & "')credlegal"

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
                        If estadoCredito = "L" Then
                            estadoCredito = "L"
                            interesCredito = 0
                            pagoIndividualCredito = 0
                            idPromesa = readerDatos("idPromesa")
                            montoCredito = readerDatos("totalDeuda")
                        Else
                            estadoCredito = readerDatos("Estado")
                            interesCredito = readerDatos("interes")
                            pagoIndividualCredito = readerDatos("Pagoindividual")
                            If IsDBNull(readerDatos("monto")) Then
                                montoCredito = 0
                            Else
                                montoCredito = readerDatos("monto")
                            End If
                            idPromesa = readerDatos("idPromesa")
                        End If

                    Else
                        estadoCredito = "L"
                        interesCredito = 0
                        pagoIndividualCredito = 0
                        idPromesa = readerDatos("idPromesa")
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
                If idPromesa <> 0 Then
                    consultaPagos = "select id as idpago,fechalimite as fechapago,Capital as monto,Moratorios as interes,Pendiente,Abonado,'1' as npago,Estado,'0' as convenio from promesadepago where idcredito = '" & idCredito & "' and estado = 'A' and tipocredito = '" & estadoCredito & "'"
                    comandoPagos = New SqlCommand
                    comandoPagos.Connection = conexionempresa
                    comandoPagos.CommandText = consultaPagos
                    readerPagos = comandoPagos.ExecuteReader
                    If readerPagos.HasRows Then
                        While readerPagos.Read
                            dtimpuestos.Rows.Add(1, readerPagos("idpago"), readerPagos("npago"), readerPagos("fechaPago"), readerPagos("Monto"), readerPagos("interes"), readerPagos("abonado"), readerPagos("pendiente"), readerPagos("estado"), readerPagos("convenio"))

                        End While
                    End If
                    Select Case estadoCredito
                        Case "A", "I"
                            tipoDoc = ObtenerTipoDoc("Promesa de pago")
                        Case "C"
                            tipoDoc = ObtenerTipoDoc("Promesa de pago convenio")
                        Case "R"
                            tipoDoc = ObtenerTipoDoc("Promesa de pago reestructura")

                        Case "L"
                            tipoDoc = ObtenerTipoDoc("Promesa de pago legal")
                    End Select

                    readerPagos.Close()
                Else
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
                        Case "I", "V"
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
                        Case "R"
                            consultaPagos = "select CalendarioReestructurasSAC.idpago,CalendarioReestructurasSAC.FechaPago,CalendarioReestructurasSAC.monto,CalendarioReestructurasSAC.interes,CalendarioReestructurasSAC.Pendiente,CalendarioReestructurasSAC.Abonado,CalendarioReestructurasSAC.Npago,CalendarioReestructurasSAC.Estado,CalendarioReestructurasSAC.Convenio,CalendarioReestructurasSAC.idconvenio from CalendarioReestructurasSAC inner join ReestructurasSAC on CalendarioReestructurasSAC.idconvenio = ReestructurasSAC.id inner join credito on ReestructurasSAC.idcredito = credito.id where ReestructurasSac.idcredito = '" & idCredito & "' and CalendarioReestructurasSAC.estado = 'V'"
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
                            consultaPagosProximos = "select top 2 CalendarioReestructurasSAC.idpago,CalendarioReestructurasSAC.FechaPago,CalendarioReestructurasSAC.monto,CalendarioReestructurasSAC.interes,CalendarioReestructurasSAC.Pendiente,CalendarioReestructurasSAC.Abonado,CalendarioReestructurasSAC.Npago,CalendarioReestructurasSAC.Estado,CalendarioReestructurasSAC.Convenio,CalendarioReestructurasSAC.idconvenio from CalendarioReestructurasSAC inner join ReestructurasSAC on CalendarioReestructurasSAC.idconvenio = ReestructurasSAC.id inner join credito on ReestructurasSAC.idcredito = credito.id where CalendarioReestructurasSAC.estado = 'P' and ReestructurasSAC.idcredito  = '" & idCredito & "' order by CalendarioReestructurasSAC.fechapago asc"
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
                            tipoDoc = ObtenerTipoDoc("Reestructura")
                        Case "Z"
                            consultaPagos = "select CalendarioConveniosTerminalesSac.idpago,CalendarioConveniosTerminalesSac.FechaPago,CalendarioConveniosTerminalesSac.monto,CalendarioConveniosTerminalesSac.interes,CalendarioConveniosTerminalesSac.Pendiente,CalendarioConveniosTerminalesSac.Abonado,CalendarioConveniosTerminalesSac.Npago,CalendarioConveniosTerminalesSac.Estado,CalendarioConveniosTerminalesSac.Convenio,CalendarioConveniosTerminalesSac.idconvenio from CalendarioConveniosTerminalesSac inner join ConveniosTerminalesSac on CalendarioConveniosTerminalesSac.idconvenio = ConveniosTerminalesSac.id inner join credito on ConveniosTerminalesSac.idcredito = credito.id where ConveniosTerminalesSac.idcredito = '" & idCredito & "' and CalendarioConveniosTerminalesSac.estado = 'V'"
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
                            consultaPagosProximos = "select top 2 CalendarioConveniosTerminalesSac.idpago,CalendarioConveniosTerminalesSac.FechaPago,CalendarioConveniosTerminalesSac.monto,CalendarioConveniosTerminalesSac.interes,CalendarioConveniosTerminalesSac.Pendiente,CalendarioConveniosTerminalesSac.Abonado,CalendarioConveniosTerminalesSac.Npago,CalendarioConveniosTerminalesSac.Estado,CalendarioConveniosTerminalesSac.Convenio,CalendarioConveniosTerminalesSac.idconvenio from CalendarioConveniosTerminalesSac inner join ConveniosTerminalesSac on CalendarioConveniosTerminalesSac.idconvenio = ConveniosTerminalesSac.id inner join credito on ConveniosTerminalesSac.idcredito = credito.id where CalendarioConveniosTerminalesSac.estado = 'P' and ConveniosTerminalesSac.idcredito  = '" & idCredito & "' order by CalendarioConveniosTerminalesSac.fechapago asc"
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
                            tipoDoc = ObtenerTipoDoc("Terminal")
                        Case Else
                            MessageBox.Show("El crédito no se encuentra activo por lo tanto no puedes cobrarle")
                    End Select
                End If

            Else

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        dtimpuestos.ScrollBars = ScrollBars.Both
        total = 0

        For Each row As DataGridViewRow In dtimpuestos.Rows
            If row.Cells(0).Value = 1 Then
                total = total + row.Cells(7).Value
            End If
        Next

        Select Case estadoCredito
            Case "A"
                lblEstado.Text = "Activo Normal"
            Case "C"
                lblEstado.Text = "Convenio"
            Case "L"
                lblEstado.Text = "Legal"
            Case "I"
                lblEstado.Text = "Incumplimiento (Convenio Cancelado)"
            Case "V"
                lblEstado.Text = "Vencido (Reestructura Vencida)"
            Case "R"
                lblEstado.Text = "Reestructura"
            Case "T"
                lblEstado.Text = "Liquidado"
            Case "Z"
                lblEstado.Text = "Convenio Terminal"
            Case Else
                lblEstado.Text = "."
                lblpago.Text = "."
        End Select
        lblpago.Text = FormatCurrency(total, 2)
        lblnombre.Text = nombreCredito
        txtid.Enabled = True
        txtid.Select()
        CanCobrar = PuedeCobrar()

        Cargando.Close()
        FlushMemory()
        widthLiquidacion = 0
        If estadoCredito = "A" Or estadoCredito = "I" Or estadoCredito = "C" Or estadoCredito = "V" Or estadoCredito = "R" Then
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

            Dim frmTicket As New Ticket_impresion
            frmTicket.idCreditoRecibo = idCredito
            Dim nombredoc As String
            nombredoc = GetNombreDoc(tipoDoc)
            If nombredoc = "Liquidación Insoluto" Or nombredoc = "Renovación Insoluto" Then
                frmTicket.total = totalLiquidacion
                frmTicket.MultasLiquidacion = multasLiquidacion
                frmTicket.MontoLiquidacionSmultas = MontoliquidacionSmultas
            Else

                frmTicket.total = lblpago.Text

            End If


            frmTicket.montocredito = montoCredito
            frmTicket.pcmil = interesCredito
            frmTicket.cp = plazo
            frmTicket.tipoDoc = tipoDoc
            frmTicket.convenio = convenioCredito
            frmTicket.cpConvenio = cpConvenio
            frmTicket.montoConvenio = MontoConvenio
            frmTicket.nombre_credito = nombreCredito
            frmTicket.insoluto = Insoluto

            frmTicket.Show()
            frmTicket.TopMost = True
        Else
            MessageBox.Show("Has alcanzado el límite de dinero en caja, realiza un retiro para poder seguir cobrando")
        End If
    End Sub

    Private Sub txtidCliente_OnValueChanged(sender As Object, e As EventArgs) Handles txtidCliente.OnValueChanged

    End Sub

    Private Sub txtid_PaddingChanged(sender As Object, e As EventArgs) Handles txtid.PaddingChanged

    End Sub

    Private Sub BackgroundCreditoCliente_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundCreditoCliente.DoWork
        iniciarconexionempresa()
        Dim consultaIdCliente As String
        Dim comandoIdCliente As SqlCommand
        Dim readerCliente As SqlDataReader

        Dim idCliente As String
        Dim nombreCli As String

        consultaIdCliente = "select id,concat(Nombre,' ',apellidopaterno,' ',apellidomaterno) as nombre from clientes where idstr = '" & txtidCliente.Text & "'"
        comandoIdCliente = New SqlCommand
        comandoIdCliente.Connection = conexionempresa
        comandoIdCliente.CommandText = consultaIdCliente
        readerCliente = comandoIdCliente.ExecuteReader
        If readerCliente.HasRows Then
            While readerCliente.Read
                idCliente = readerCliente("id")
                nombreCli = readerCliente("nombre")
                existe = True
                lblnombre.Text = nombreCli
            End While
        Else
            existe = False
            lblnombre.Text = "No existe"
        End If



        Dim adapterCreditoCliente As SqlDataAdapter
        Dim consultaCreditoCliente As String
        consultaCreditoCliente = "if exists(select 1 from Legales where idCliente = '" & idCliente & "')
            select Legales.id,Legales.Nombre,MontoConvenio as Monto, Legales.Plazo, ('0')as pagoindividual, credito.Estado,  ('0')as Interes from credito inner join Solicitud on Credito.IdSolicitud=Solicitud.id
			inner join Legales on Legales.idSolicitud=Solicitud.id where Legales.IdCliente='" & idCliente & "' 
            else
            select  cred.*,ISNULL((select id from PromesaDePago where idCredito = cred.id and estado = 'A'),0) as idPromesa from
			(Select id,nombre,monto,plazo,interes,pagoindividual,estado,FechaEntrega from credito where idcliente = '" & idCliente & "' )cred where (Estado = 'A' OR Estado = 'R' or Estado  = 'C' or Estado = 'I' or Estado='V' or Estado='Z') order by FechaEntrega desc"
        adapterCreditoCliente = New SqlDataAdapter(consultaCreditoCliente, conexionempresa)
        dataCreditoCliente = New DataTable
        adapterCreditoCliente.Fill(dataCreditoCliente)

    End Sub

    Private Sub inicio_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub txtid_GotFocus(sender As Object, e As EventArgs) Handles txtid.GotFocus


    End Sub

    Private Sub BackgroundLiquidacionNormal_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundLiquidacionNormal.DoWork

    End Sub

    Private Sub txtid_LostFocus(sender As Object, e As EventArgs) Handles txtid.LostFocus
        focustxtid = False

    End Sub

    Private Sub txtidCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtidCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not SwitchTipo.Checked Then
                txtid.Text = txtidCliente.Text
                dtimpuestos.Rows.Clear()
                dtimpuestos.ScrollBars = ScrollBars.None
                txtid.Enabled = False
                Cargando.Show()
                Cargando.MonoFlat_Label1.Text = "Buscando datos"
                BackgroundWorker1.RunWorkerAsync()
            Else
                dtimpuestos.Rows.Clear()
                dtimpuestos.ScrollBars = ScrollBars.None

                Cargando.Show()
                Cargando.MonoFlat_Label1.Text = "Buscando datos"
                BackgroundCreditoCliente.RunWorkerAsync()
            End If


        End If
    End Sub

    Private Sub BackgroundCreditoCliente_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundCreditoCliente.RunWorkerCompleted
        Cargando.Close()
        If existe Then
            If dataCreditoCliente.Rows.Count = 0 Then
                lblEstado.Text = "No tiene créditos activos"
            ElseIf dataCreditoCliente.Rows.Count = 1 Then
                For Each row As DataRow In dataCreditoCliente.Rows
                    txtid.Text = row("id")
                    estadoCredito = row("estado")
                    Exit For
                Next
                dtimpuestos.Rows.Clear()
                dtimpuestos.ScrollBars = ScrollBars.None
                txtid.Enabled = False
                Cargando.Show()
                Cargando.MonoFlat_Label1.Text = "Buscando datos"
                BackgroundWorker1.RunWorkerAsync()
            Else
                BuscarCreditoCliente.dataCredito = New DataTable
                BuscarCreditoCliente.dataCredito = dataCreditoCliente
                BuscarCreditoCliente.Show()
            End If
        Else
            nombreCredito = "No existe"
            estadoCredito = ""
            existe = False
        End If



    End Sub
End Class