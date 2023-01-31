Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Windows
Imports MySql.Data.MySqlClient
Public Class frm_adm
    Dim ventana As New Form
    Public abierto As Boolean = False
    Dim widthmenu As Integer = 0
    Dim widthmenubool As Boolean = False
    Dim widthmenuperfilbool As Boolean = False
    Dim sizeventanas As System.Drawing.Size
    Dim op As Double = 0
    Dim tipoPago As String
    Public cerrarSesion As Boolean
    Public cerrarEmpresa As Boolean
    Public cerrandoSesion As Boolean
    Public cerrandoEmpresa As Boolean
    Public mostrarpanelsecundario As Boolean = False
    Public autorizadoTicketExtra As Boolean
    Dim hayActualizacion As Boolean
    Dim array As ArrayList = New ArrayList

    Friend conexionsql As MySql.Data.MySqlClient.MySqlConnection
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Interval = 150


        Timer1.Start()
        Me.Opacity = op
        If op < 1 Then
            op = op + 0.1
            Me.Opacity = op

            'MessageBox.Show(Str(op))
        Else
            op = 0
            Timer1.Stop()
            Timer1.Enabled = False


        End If
    End Sub

    Private Sub frm_adm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If imgstrusr = "" Then
            imgperfil.Image = SAC_CONFIA.My.Resources.Resources.usuario
        Else
            imgperfil.Image = bitmapimgusr
        End If
    End Sub

    Private Sub frm_adm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        perfilalt.Close()

    End Sub

    Private Sub frm_adm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Timer2.Stop()

            perfilalt.Close()
            abierto = False
            If Actualizar Then
            Else

                If cerrarSesion Then
                    If cerrarEmpresa Then
                        If MessageBox.Show("¿Está seguro que desea cerrar la empresa?", "SATI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Forms.DialogResult.Yes Then
                            perfilalt.TopMost = False

                            'Application.ExitThread()
                            Empresas.Show()
                            cerrarSesion = False
                            cerrandoSesion = True
                            ' Dim i As Integer = 0
                            'i = Application.OpenForms.Count
                            ' For a As Integer = 0 To i
                            'Dim frm As Form
                            'frm = New Form
                            'frm = Application.OpenForms.Item(a)
                            'If frm.Name <> "login" And frm.Name <> Me.Name Then
                            'frm.Close()
                            'End If
                            'Next

                            Dim num_controles As Integer = System.Windows.Forms.Application.OpenForms.Count - 1
                            For n As Integer = num_controles To 0 Step -1
                                Dim ctrl As Form = System.Windows.Forms.Application.OpenForms.Item(n)
                                If ctrl.Name <> "Empresas" And ctrl.Name <> Me.Name Then
                                    ctrl.Close()
                                End If

                                'ctrl.Dispose()
                            Next

                            Me.Close()

                        Else
                            cerrarSesion = False

                            e.Cancel = True

                        End If
                    Else
                        If MessageBox.Show("¿Está seguro que desea cerrar sesión?", "SATI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Forms.DialogResult.Yes Then
                            perfilalt.TopMost = False
                            Dim conexionSesion As MySqlConnection
                            conexionSesion = New MySqlConnection()
                            conexionSesion.ConnectionString = "server=www.prestamosconfia.com;user id=ajas;pwd=123456;port=3306;database=USRS"
                            conexionSesion.Open()
                            Dim comandoActSesion As MySqlCommand
                            Dim consultaActSesion As String
                            consultaActSesion = "update Sesiones set Activo = 0 where id = '" & idSesion & "'"
                            comandoActSesion = New MySqlCommand
                            comandoActSesion.Connection = conexionSesion
                            comandoActSesion.CommandText = consultaActSesion
                            comandoActSesion.ExecuteNonQuery()
                            conexionSesion.Close()
                            'Application.ExitThread()
                            login.Show()
                            cerrarSesion = False
                            cerrandoSesion = True
                            ' Dim i As Integer = 0
                            'i = Application.OpenForms.Count
                            ' For a As Integer = 0 To i
                            'Dim frm As Form
                            'frm = New Form
                            'frm = Application.OpenForms.Item(a)
                            'If frm.Name <> "login" And frm.Name <> Me.Name Then
                            'frm.Close()
                            'End If
                            'Next

                            Dim num_controles As Integer = System.Windows.Forms.Application.OpenForms.Count - 1
                            For n As Integer = num_controles To 0 Step -1
                                Dim ctrl As Form = System.Windows.Forms.Application.OpenForms.Item(n)
                                If ctrl.Name <> "login" And ctrl.Name <> Me.Name Then
                                    ctrl.Close()
                                End If

                                'ctrl.Dispose()
                            Next

                            Me.Close()

                        Else
                            cerrarSesion = False

                            e.Cancel = True

                        End If
                    End If

                Else
                    If cerrandoSesion Then
                        'MessageBox.Show("hola")
                    Else
                        'MessageBox.Show("hola")
                        If MessageBox.Show("¿Está seguro que desea salir?", "SATI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Forms.DialogResult.Yes Then
                            perfilalt.TopMost = False
                            Dim conexionSesion As MySqlConnection
                            conexionSesion = New MySqlConnection()
                            conexionSesion.ConnectionString = "server=www.prestamosconfia.com;user id=ajas;pwd=123456;port=3306;database=USRS"
                            conexionSesion.Open()
                            Dim comandoActSesion As MySqlCommand
                            Dim consultaActSesion As String
                            consultaActSesion = "update Sesiones set Activo = 0 where id = '" & idSesion & "'"
                            comandoActSesion = New MySqlCommand
                            comandoActSesion.Connection = conexionSesion
                            comandoActSesion.CommandText = consultaActSesion
                            comandoActSesion.ExecuteNonQuery()
                            conexionSesion.Close()
                            System.Windows.Forms.Application.ExitThread()



                        Else
                            e.Cancel = True

                        End If
                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frm_adm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Control + Keys.L Then
            login.bloqueado = True
            login.ShowDialog()
        End If
        If e.KeyCode = Keys.F8 Then
            Me.TopMost = False
            Autorizacion.TopMost = True
            Autorizacion.tipoAutorizacion = "SacCobrarExtra"
            Autorizacion.ShowDialog()

            Autorizacion.BringToFront()


            If autorizadoTicketExtra Then
                CobroExtra.ShowDialog()
            Else
                MessageBox.Show("No fue autorizado")
            End If

        End If
        If e.KeyCode = Keys.F4 Then
            BuscarCredito.tipoCredito = inicio.tipoCredito
            BuscarCredito.Show()
        End If

        If e.KeyCode = Keys.F9 Then
            For Each frmForm As Form In My.Application.OpenForms


                If frmForm.Name = ventana.Name Then
                    frmForm.Close()
                    Exit For
                End If
            Next

            ventana.Name = CobroEmpeño.Name
            CobroEmpeño.MdiParent = Me
            CobroEmpeño.Height = Me.Height - Panel1.Height - 43
            CobroEmpeño.Width = Me.Width - panelmenus.Width - 20


            CobroEmpeño.Top = 0
            CobroEmpeño.Left = 0
            CobroEmpeño.Show()
            CobroEmpeño.Top = 0
            CobroEmpeño.Left = 0
            ' inicio.Height = Me.Height - Panel1.Height + 1
            'inicio.Width = Me.Width - panelmenus.Width + 1

            CobroEmpeño.Show()

            If CobroEmpeño.Top > 0 Then
                CobroEmpeño.Top = 0

            End If
        End If

        If e.KeyCode = Keys.F2 And ventana.Name = "inicio" Then
            If inicio.SwitchTipo.Checked Then
                BuscarCliente.Show()

            Else
                BuscarCredito.tipoCredito = inicio.tipoCredito
                BuscarCredito.Show()
            End If
        End If

        If e.KeyCode = Keys.F5 And ventana.Name = "inicio" Then

            Dim seleccionado As Integer = 0
                For Each row As DataGridViewRow In inicio.dtimpuestos.Rows
                    Dim c As Boolean
                    c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))

                    If c Then
                        seleccionado = seleccionado + 1
                    Else

                    End If
                Next
                If seleccionado > 0 Then
                    If CanCobrar Then
                        Me.Invoke(Sub()
                                      inicio.SubCobrar()
                                  End Sub)

                    Else
                        MessageBox.Show("Haz alcanzado tu límite de cobro, realiza un retiro para poder seguir cobrando")
                    End If
                Else
                    MessageBox.Show("No has seleccionado ningún pago")

                End If




        End If

        If e.KeyData = Keys.Control + Keys.R Then

            Run.ShowDialog()
        End If

    End Sub

    Private Sub frm_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TimerActualizacion.Interval = 60000
        TimerActualizacion.Enabled = True
        TimerActualizacion.Start()
        TimerNotificaciones.Interval = 10000
        TimerNotificaciones.Enabled = True
        TimerNotificaciones.Start()
        TimerActSesion.Interval = 60000
        TimerActSesion.Enabled = True
        TimerActSesion.Start()
        CanCobrar = PuedeCobrar()

        DoubleBuffered = True

        Me.Text = "SAC" & " - " & nombreAmostrar
        sizeventanas = New System.Drawing.Size(Me.Width - panelmenus.Width - 20, Me.Height - Panel1.Height - 43)
        If imgstrusr = "" Then
            imgperfil.Image = SAC_CONFIA.My.Resources.Resources.usuario
        Else
            imgperfil.Image = bitmapimgusr
        End If

        notificaciones.Text = "Tiene n notificaciones"

        Timer1.Enabled = True
        Timer2.Enabled = True


        Me.Opacity = 0
        inicio.MdiParent = Me

        inicio.Height = Me.Height - Panel1.Height - 10
        'inicio.Width = Me.Width - panelmenus.Width + 1000
        inicio.FormBorderStyle = Forms.FormBorderStyle.None
        inicio.AutoScroll = False

        inicio.Location = New System.Drawing.Point(panelmenus.Width, Panel1.Height)
        'inv.Height = Me.Height - Panel1.Height
        'inv.Width = Me.Width - panelmenus.Width
        'panelmenus.Width = 0


        'inv.AutoScroll = False
        inicio.Show()
        ventana.Name = inicio.Name
        acomodar()
        ' inicio.Panelsecundario.BackColor = Color.FromArgb(0, 100, 100, 100)
        'inicio.Panelsecundario.Left = panelusuarios.Width + Panelconfiguracion.Width + BunifuImageButton1.Width + 10
        'inicio.Panelsecundario.Top = 0
        ' If BunifuImageButton1.Width + panelusuarios.Width + Panelconfiguracion.Width + Panel3.Width + Panel4.Width + notificaciones.Width + imgperfil.Width + 30 > Panel1.Width Then




        'imgmostrarpanel.Visible = True




        '  Else



        'imgmostrarpanel.Visible = False





        ' End If
        inicio.Size = sizeventanas
        inicio.Update()
        ' imgmostrarpanel.Left = panelusuarios.Width + Panelconfiguracion.Width + BunifuImageButton1.Width + 12 + Panel4.Width
        '  imgmostrarpanel.Top = panelusuarios.Top
    End Sub

    Private Sub frm_adm_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        perfilalt.SetDesktopLocation(Me.Location.X + Me.Width - perfilalt.Width, Me.Location.Y + Panel1.Height + 20)
    End Sub

    Private Sub frm_adm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        perfilalt.TopMost = False
    End Sub





    Private Sub frm_adm_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        'inicio.Height = Me.Height - Panel1.Height
        ' inicio.Width = Me.Width - panelmenus.Width
        'inv.Height = Me.Height - Panel1.Height - 43
        'inv.Width = Me.Width - panelmenus.Width - 20
        ' ventana.Height = Me.Height - Panel1.Height - 43
        ' ventana.Width = Me.Width - panelmenus.Width - 20
        acomodar()
        imgperfil.Left = Panel1.Width - imgperfil.Width - 10
        notificaciones.Left = Panel1.Width - imgperfil.Width - 10 - notificaciones.Width
        perfilalt.SetDesktopLocation(Me.Location.X + Me.Width - perfilalt.Width, Me.Location.Y + Panel1.Height + 20)
        ' If BunifuImageButton1.Width + panelusuarios.Width + Panelconfiguracion.Width + Panel3.Width + Panel4.Width + notificaciones.Width + imgperfil.Width + 30 > Panel1.Width Then



        ' Panel4.Visible = False
        'inicio.Panelsecundario.Visible = True
        'imgmostrarpanel.Visible = True




        ' Else


        'Panel4.Visible = True
        'inicio.Panelsecundario.Visible = False
        ' mostrarpanelsecundario = False
        ' imgmostrarpanel.Visible = False
        ' imgmostrarpanel.Image = SAC_CONFIA.My.Resources.Resources.mostrar1
        ' imgmostrarpanel.BackColor = Color.FromArgb(51, 0, 204)


        '  End If

    End Sub

    Private Sub BunifuFlatButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuFlatButton2.Click
        For Each frmForm As Form In My.Application.OpenForms


            If frmForm.Name = ventana.Name Then
                frmForm.Hide()
                Exit For
            End If
        Next
        ventana.Name = Creditos_Autorizados.Name
        Creditos_Autorizados.MdiParent = Me
        Creditos_Autorizados.Height = Me.Height - Panel1.Height - 43
        Creditos_Autorizados.Width = Me.Width - panelmenus.Width - 20


        Creditos_Autorizados.Top = 0
        Creditos_Autorizados.Left = 0
        Creditos_Autorizados.Show()
        Creditos_Autorizados.Top = 0
        Creditos_Autorizados.Left = 0
        ' inicio.Height = Me.Height - Panel1.Height + 1
        'inicio.Width = Me.Width - panelmenus.Width + 1

        Creditos_Autorizados.Show()

        If Creditos_Autorizados.Top > 0 Then
            Creditos_Autorizados.Top = 0

        End If
        tipoPago = "Comision"


        ' ventana.Name = inv.Name

        'inv.MdiParent = Me
        'inv.Height = Me.Height - Panel1.Height
        'inv.Width = Me.Width - panelmenus.Width


        'inv.Top = 0
        'inv.Left = 0
        'inv.Show()
        'inv.Top = 0
        'inv.Left = 0
        'inv.Height = Me.Height - Panel1.Height - 43
        'inv.Width = Me.Width - panelmenus.Width - 20
        'inv.Size = sizeventanas
        'inv.Show()

        '        If inv.Top > 0 Then
        '       inv.Top = 0
        '
        'End If
        'inv.Update()




    End Sub

    Private Sub BunifuFlatButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuFlatButton1.Click
        For Each frmForm As Form In My.Application.OpenForms


            If frmForm.Name = ventana.Name Then
                frmForm.Hide()
                Exit For
            End If
        Next
        ventana.Name = inicio.Name
        inicio.MdiParent = Me
        inicio.Height = Me.Height - Panel1.Height - 43
        inicio.Width = Me.Width - panelmenus.Width - 20


        inicio.Top = 0
        inicio.Left = 0
        inicio.Show()
        inicio.Top = 0
        inicio.Left = 0
        ' inicio.Height = Me.Height - Panel1.Height + 1
        'inicio.Width = Me.Width - panelmenus.Width + 1

        inicio.Show()

        If inicio.Top > 0 Then
            inicio.Top = 0

        End If
        tipoPago = "Pago"

    End Sub

    Private Sub BunifuImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If panelmenus.Width = 258 Then
        'antes era width 51

        'panelmenus.Width = 0
        'acomodar()
        'Else
        'panelmenus.Width = 258
        'acomodar()

        'End If
        If widthmenubool = False Then
            'BunifuImageButton1.BackColor = Color.FromArgb(0, 0, 153)
            Timerwidthmas.Enabled = True
            Timerwidthmenos.Enabled = False
        Else
            '  BunifuImageButton1.BackColor = Color.FromArgb(51, 0, 204)
            Timerwidthmenos.Enabled = True
            Timerwidthmas.Enabled = False


        End If
    End Sub
    Public Sub acomodar()
        DoubleBuffered = True

        For Each vent As Form In My.Application.OpenForms

            If vent.Name = ventana.Name Then
                'MessageBox.Show("hola")
                ' vent.Height = Me.Height - Panel1.Height
                'vent.Width = Me.Width - panelmenus.Width
                vent.Height = Me.Height - Panel1.Height - 43
                vent.Width = Me.Width - panelmenus.Width - 20
                ' inicio.Height = Me.Height - Panel1.Height - 43
                'inicio.Width = Me.Width - panelmenus.Width - 20
            End If

        Next


    End Sub



    Private Sub imgperfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgperfil.Click

        perfilalt.SetDesktopLocation(Me.Location.X + Me.Width - perfilalt.Width, Me.Location.Y + Panel1.Height + 20)
        If abierto = False Then
            perfilalt.Show()
            Timer2.Start()

            perfilalt.SetDesktopLocation(Me.Location.X + Me.Width - perfilalt.Width, Me.Location.Y + Panel1.Height + 20)
            abierto = True

        Else
            perfilalt.TopMost = False
            Timer2.Stop()

            perfilalt.Close()
            abierto = False


        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Interval = 1
        Timer2.Start()
        If Me IsNot ActiveForm Then
            perfilalt.TopMost = False


        Else
            perfilalt.TopMost = True

        End If
    End Sub


    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerwidthmenos.Tick
        ' If panelmenus.Width = 258 Then
        'antes era width 51

        'panelmenus.Width = 0
        'acomodar()
        'End If

        'If panelmenus.Width < 258 Then
        'panelmenus.Width = 258
        'acomodar()

        'End If

        Timerwidthmenos.Interval = 1
        sizeventanas = New System.Drawing.Size(Me.Width - panelmenus.Width - 20, Me.Height - Panel1.Height - 43)
        panelmenus.Enabled = False
        panelmenus.Width = widthmenu
        If panelmenus.Width > 0 Then
            widthmenu = widthmenu - 10
            'inicio.Panelsecundario.Left = panelusuarios.Width + Panelconfiguracion.Width - BunifuImageButton1.Width + 10

        Else
            widthmenubool = False
            Timerwidthmenos.Stop()
            Timerwidthmenos.Enabled = False
            panelmenus.Enabled = True
            ' inicio.Panelsecundario.Left = panelusuarios.Width + Panelconfiguracion.Width + BunifuImageButton1.Width + panelmenus.Width + 10
            acomodar()
        End If

    End Sub

    Private Sub Timerwidthmas_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timerwidthmas.Tick
        Timerwidthmas.Interval = 1
        sizeventanas = New System.Drawing.Size(Me.Width - panelmenus.Width - 20, Me.Height - Panel1.Height - 43)
        panelmenus.Enabled = False

        panelmenus.Width = widthmenu
        If panelmenus.Width < 258 Then
            widthmenu = widthmenu + 10
            'inicio.Panelsecundario.Left = panelusuarios.Width + Panelconfiguracion.Width + BunifuImageButton1.Width - panelmenus.Width + 10

            acomodar()
        Else
            widthmenubool = True
            Timerwidthmas.Stop()
            Timerwidthmas.Enabled = False
            ' inicio.Panelsecundario.Left = panelusuarios.Width + Panelconfiguracion.Width + BunifuImageButton1.Width - panelmenus.Width + 10
            acomodar()
            panelmenus.Enabled = True
        End If
    End Sub


    Private Sub imgmostrarpanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If mostrarpanelsecundario = False Then

            'inicio.Panelsecundario.Visible = True
            'imgmostrarpanel.Image = SAC_CONFIA.My.Resources.Resources.ocultar1
            ' imgmostrarpanel.BackColor = Color.FromArgb(46, 139, 87)

            mostrarpanelsecundario = True
        Else
            'inicio.Panelsecundario.Visible = False
            'imgmostrarpanel.Image = SAC_CONFIA.My.Resources.Resources.mostrar1
            ' imgmostrarpanel.BackColor = Color.FromArgb(51, 0, 204)
            mostrarpanelsecundario = False

        End If
    End Sub



    Private Sub btnusuarios_Click(sender As Object, e As EventArgs) Handles btnusuarios.Click
        'usuarios.Show()
        DetalleCaja.Show()
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs)
        inicio.Width = 20
        'grupos.Show()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        inicio.Close()
        ' inv.Close()
        'Solicitudes.Close()
        ventana.Name = Reportes.Name

        Reportes.MdiParent = Me
        Reportes.Height = Me.Height - Panel1.Height
        Reportes.Width = Me.Width - panelmenus.Width


        Reportes.Top = 0
        Reportes.Left = 0
        Reportes.Show()
        Reportes.Top = 0
        Reportes.Left = 0
        Reportes.Height = Me.Height - Panel1.Height - 43
        Reportes.Width = Me.Width - panelmenus.Width - 20
        'inv.Size = sizeventanas
        Reportes.Show()

        If Reportes.Top > 0 Then
            Reportes.Top = 0

        End If
        Reportes.Update()

    End Sub

    Private Sub frm_adm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        acomodar()
    End Sub

    Private Sub btnconfiguracion_Click(sender As Object, e As EventArgs) Handles btnconfiguracion.Click
        Configuraciones.Show()
    End Sub

    Private Sub TimerPermisos_Tick(sender As Object, e As EventArgs) Handles TimerPermisos.Tick
        cargarperfil()
        TimerPermisos.Stop()
        TimerPermisos.Enabled = False
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Me.TopMost = False
        Autorizacion.TopMost = True
        Autorizacion.tipoAutorizacion = "SacCobrarExtra"
        Autorizacion.ShowDialog()

        Autorizacion.BringToFront()


        If autorizadoTicketExtra Then
            CobroExtra.ShowDialog()
        Else
            MessageBox.Show("No fue autorizado")
        End If

    End Sub

    Private Sub notificaciones_Click(sender As Object, e As EventArgs) Handles notificaciones.Click

    End Sub

    Private Sub BunifuFlatButton7_Click_1(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        For Each frmForm As Form In My.Application.OpenForms


            If frmForm.Name = ventana.Name Then
                frmForm.Close()
                Exit For
            End If
        Next

        ventana.Name = CobroEmpeño.Name
        CobroEmpeño.MdiParent = Me
        CobroEmpeño.Height = Me.Height - Panel1.Height - 43
        CobroEmpeño.Width = Me.Width - panelmenus.Width - 20


        CobroEmpeño.Top = 0
        CobroEmpeño.Left = 0
        CobroEmpeño.Show()
        CobroEmpeño.Top = 0
        CobroEmpeño.Left = 0
        ' inicio.Height = Me.Height - Panel1.Height + 1
        'inicio.Width = Me.Width - panelmenus.Width + 1

        CobroEmpeño.Show()

        If CobroEmpeño.Top > 0 Then
            CobroEmpeño.Top = 0

        End If
    End Sub

    Private Sub TimerActualizacion_Tick(sender As Object, e As EventArgs) Handles TimerActualizacion.Tick
        If BackgroundActualizacion.IsBusy Then
        Else

            BackgroundActualizacion.RunWorkerAsync()

        End If
    End Sub

    Private Sub BackgroundActualizacion_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundActualizacion.DoWork
        Try
            conexionsql = New MySqlConnection()
            conexionsql.ConnectionString = "server=www.prestamosconfia.com;user id=SACVersiones;pwd=123456;port=3306;database=Versiones"
            conexionsql.Open()

            Dim mysqlcomando As MySqlCommand
            Dim consulta As String

            consulta = "select Nversion from Versiones where Sistema = 'SAC'"
            mysqlcomando = New MySqlCommand
            mysqlcomando.Connection = conexionsql
            mysqlcomando.CommandText = consulta
            Dim versionAct As String
            versionAct = mysqlcomando.ExecuteScalar


            conexionsql.Close()

            If System.Windows.Forms.Application.ProductVersion <> versionAct Then
                hayActualizacion = True


            End If
        Catch ex As Exception
            hayActualizacion = False

        End Try
    End Sub

    Private Sub BackgroundActualizacion_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundActualizacion.RunWorkerCompleted
        If hayActualizacion Then
            btn_Actualizar.Visible = True

        End If

    End Sub

    Private Sub btn_Actualizar_Click(sender As Object, e As EventArgs) Handles btn_Actualizar.Click
        If MessageBox.Show("¿Desea aplicar la actualización?", "SAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Forms.DialogResult.Yes Then
            Actualizar = True

            Dim Proceso As Process = New Process
            Dim ruta As String = "C:\ConfiaAdmin\Updater\Updater.exe"
            Proceso.StartInfo.FileName = ruta
            Proceso.StartInfo.Arguments = "/S SAC /T " & TipoEquipo
            Proceso.Start()
            System.Windows.Forms.Application.Exit()
        Else
            Actualizar = False

        End If
    End Sub

    Private Sub BackgroundNotificaciones_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundNotificaciones.DoWork
        Try



            Dim conexionNotificaciones As MySqlConnection
            conexionNotificaciones = New MySqlConnection()
            conexionNotificaciones.ConnectionString = "server=www.prestamosconfia.com;user id=SACNotificacion;pwd=123456;port=3306;database=USRS"
            conexionNotificaciones.Open()

            Dim mysqlcomando As MySqlCommand
            Dim consulta As String
            Dim readerNotificacion As MySqlDataReader

            consulta = "select * from Notificaciones where Usuario = '" & nmusr & "' and Aplicado = 0 and idSesion='" & idSesion & "'"
            mysqlcomando = New MySqlCommand
            mysqlcomando.Connection = conexionNotificaciones
            mysqlcomando.CommandText = consulta
            readerNotificacion = mysqlcomando.ExecuteReader

            While readerNotificacion.Read
                Dim Nnotificacion As New Notificaciones
                Nnotificacion.id = readerNotificacion("id")
                Nnotificacion.Tipo = readerNotificacion("tipo")
                Nnotificacion.Usuario = readerNotificacion("Usuario")
                Nnotificacion.UsuarioDestino = readerNotificacion("usuariodestino")
                Nnotificacion.Notificacion = readerNotificacion("notificacion")
                Nnotificacion.Mensaje = readerNotificacion("Mensaje")
                Array.Add(Nnotificacion)
            End While
            readerNotificacion.Close()
            ' conexionNotificaciones.Close()
            Me.Invoke(Sub()
                          notificaciones.Text = "Tienes " & array.Count & " notificaciones"
                          notificaciones.Refresh()

                      End Sub)
            For a As Integer = Array.Count - 1 To 0 Step -1
                If Array(a).Tipo = "Logout" Then
                    Dim comandoActNotificacion As MySqlCommand
                    Dim consultaActNotificacion As String
                    comandoActNotificacion = New MySqlCommand
                    consultaActNotificacion = "update Notificaciones set Aplicado = 1 where id = '" & Array(a).id & "'"
                    comandoActNotificacion.Connection = conexionNotificaciones
                    comandoActNotificacion.CommandText = consultaActNotificacion
                    comandoActNotificacion.ExecuteNonQuery()
                    If array(a).Mensaje <> "" Then
                        Me.Invoke(Sub()
                                      Dim nAlertas As New Alertas
                                      nAlertas.cadena = array(a).Mensaje
                                      nAlertas.ShowDialog()
                                      nAlertas.TopMost = True
                                  End Sub)




                    End If
                    Actualizar = True

                    Dim num_controles As Integer = System.Windows.Forms.Application.OpenForms.Count - 1
                    For n As Integer = num_controles To 0 Step -1
                        Dim ctrl As Form = System.Windows.Forms.Application.OpenForms.Item(n)
                        If ctrl.Name <> "login" And ctrl.Name <> Me.Name Then
                            ctrl.Close()
                        End If

                        'ctrl.Dispose()
                    Next
                    Me.Invoke(Sub()
                                  login.Show()
                              End Sub)


                    Me.Close()
                End If
                If Array(a).Tipo = "Message" Then


                    Me.Invoke(Sub()
                                  Dim nAlertas As New Alertas
                                  nAlertas.cadena = array(a).Mensaje
                                  nAlertas.ShowDialog()
                                  nAlertas.TopMost = True
                              End Sub)

                    Dim comandoActNotificacion As MySqlCommand
                    Dim consultaActNotificacion As String
                    comandoActNotificacion = New MySqlCommand
                    consultaActNotificacion = "update Notificaciones set Aplicado = 1 where id = '" & Array(a).id & "'"
                    comandoActNotificacion.Connection = conexionNotificaciones
                    comandoActNotificacion.CommandText = consultaActNotificacion
                    comandoActNotificacion.ExecuteNonQuery()
                    Array.RemoveAt(a)
                End If
                If Array(a).Tipo = "CargarPermisos" Then
                    If array(a).Mensaje <> "" Then

                        Me.Invoke(Sub()
                                      Dim nAlertas As New Alertas
                                      nAlertas.cadena = array(a).Mensaje
                                      nAlertas.ShowDialog()
                                      nAlertas.TopMost = True
                                  End Sub)
                    End If
                    cargarperfil()
                    Dim comandoActNotificacion As MySqlCommand
                    Dim consultaActNotificacion As String
                    comandoActNotificacion = New MySqlCommand
                    consultaActNotificacion = "update Notificaciones set Aplicado = 1 where id = '" & Array(a).id & "'"
                    comandoActNotificacion.Connection = conexionNotificaciones
                    comandoActNotificacion.CommandText = consultaActNotificacion
                    comandoActNotificacion.ExecuteNonQuery()
                    Array.RemoveAt(a)
                End If
                If Array(a).Tipo = "Update" Then
                    If array(a).Mensaje <> "" Then

                        Me.Invoke(Sub()
                                      Dim nAlertas As New Alertas
                                      nAlertas.cadena = array(a).Mensaje
                                      nAlertas.ShowDialog()
                                      nAlertas.TopMost = True
                                  End Sub)
                    End If

                    Dim comandoActNotificacion As MySqlCommand
                    Dim consultaActNotificacion As String
                    comandoActNotificacion = New MySqlCommand
                    consultaActNotificacion = "update Notificaciones set Aplicado = 1 where id = '" & Array(a).id & "'"
                    comandoActNotificacion.Connection = conexionNotificaciones
                    comandoActNotificacion.CommandText = consultaActNotificacion
                    comandoActNotificacion.ExecuteNonQuery()
                    Actualizar = True

                    Dim ruta As String = "C:\ConfiaAdmin\Updater\Updater.exe"
                    Dim Proceso As Process = New Process
                    Proceso.StartInfo.FileName = ruta
                    Proceso.StartInfo.Arguments = "/S SAC /T " & TipoEquipo
                    Proceso.Start()

                    System.Windows.Forms.Application.Exit()
                End If
            Next
            conexionNotificaciones.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TimerNotificaciones_Tick(sender As Object, e As EventArgs) Handles TimerNotificaciones.Tick
        If BackgroundNotificaciones.IsBusy = True Then
        Else
            BackgroundNotificaciones.RunWorkerAsync()

        End If
    End Sub

    Private Sub BackgroundActSesion_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundActSesion.DoWork
        Try
            Dim conexionSesion As MySqlConnection
            conexionSesion = New MySqlConnection()
            conexionSesion.ConnectionString = "server=www.prestamosconfia.com;user id=SACSesiones;pwd=123456;port=3306;database=USRS"
            conexionSesion.Open()

            Dim mysqlcomando As MySqlCommand
            Dim consulta As String
            Dim sesionActiva As Boolean

            consulta = "select Activo from Sesiones where Usuario = '" & nmusr & "' and id='" & idSesion & "'"
            mysqlcomando = New MySqlCommand
            mysqlcomando.Connection = conexionSesion
            mysqlcomando.CommandText = consulta
            sesionActiva = mysqlcomando.ExecuteScalar

            If sesionActiva Then
                Dim comandoActSesion As MySqlCommand
                Dim consultaActSesion As String
                consultaActSesion = "update Sesiones set UltimoAcceso = '" & Date.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' where id = '" & idSesion & "'"
                comandoActSesion = New MySqlCommand
                comandoActSesion.Connection = conexionSesion
                comandoActSesion.CommandText = consultaActSesion
                comandoActSesion.ExecuteNonQuery()
                conexionSesion.Close()
            Else
                conexionSesion.Close()

                'quitar comentario
                Me.Invoke(Sub()
                              Dim nAlertas As New Alertas
                              nAlertas.cadena = "Han pasado más de 5 minutos sin conexión, la sesión se cerrará"
                              nAlertas.ShowDialog()
                              nAlertas.TopMost = True
                          End Sub)



                Actualizar = True
                login.Show()

                Dim num_controles As Integer = System.Windows.Forms.Application.OpenForms.Count - 1
                For n As Integer = num_controles To 0 Step -1
                    Dim ctrl As Form = System.Windows.Forms.Application.OpenForms.Item(n)
                    If ctrl.Name <> "login" And ctrl.Name <> Me.Name Then
                        ctrl.Close()
                    End If

                    'ctrl.Dispose()
                Next
                Me.Invoke(Sub()
                              login.Show()
                          End Sub)

                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TimerActSesion_Tick(sender As Object, e As EventArgs) Handles TimerActSesion.Tick
        If BackgroundActSesion.IsBusy = True Then
        Else
            BackgroundActSesion.RunWorkerAsync()
        End If
    End Sub
End Class