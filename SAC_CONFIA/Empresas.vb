Imports System.Data.OleDb
Imports System.Threading.Tasks
Imports MySql.Data.MySqlClient

Public Class Empresas
    Dim conectado As Boolean
    Dim conCaja As Boolean
    Private Sub MonoFlat_ThemeContainer1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Empresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Dim acceso As Boolean
        For Each row As DataRow In dataPermisos.Rows
            acceso = row("SacAcceso")
        Next
        If acceso Then
            Try
                '
                iniciarconexion()
                Dim sql As String
                Dim comando As OleDb.OleDbCommand
                Dim milector As OleDb.OleDbDataReader

                comando = New OleDb.OleDbCommand

                comando.Connection = conexion
                sql = "select rs,ip,bd,nombre from empresas"
                comando.CommandText = sql
                milector = comando.ExecuteReader
                While milector.Read
                    Dim botonempresa As New Bunifu.Framework.UI.BunifuFlatButton

                    botonempresa.Normalcolor = Color.FromArgb(48, 55, 76)
                    botonempresa.Iconimage = My.Resources.empresa_azul
                    botonempresa.Size = New Size(390, 48)
                    botonempresa.Name = milector("bd")
                    botonempresa.Text = milector("nombre")
                    botonempresa.Tag = milector("ip")
                    AddHandler botonempresa.Click, AddressOf clickevenntAsync
                    FlowLayoutPanel1.Controls.Add(botonempresa)
                End While
                milector.Close()


                'Timer1.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("El usuario no tiene acceso al sistema")
            Me.Close()
        End If

    End Sub
    Private Async Sub clickevenntAsync(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '  Dim iniFile As New IniFile()
            'iniFile.Load("C:\Modulo\SetConfig.ini")
            ' Dim section As IniSection = iniFile.Sections.Add("Sucursal")
            ' section.Keys.Add("BdSucursal", sender.name)

            bdconsultas = sender.name
            ' Save and encrypt the file.
            ' iniFile.Save("C:\Modulo\SetConfig.ini")
            ipconsultas = sender.tag

            ' iniFile.Sections.Clear()
            '  MessageBox.Show("Listo")
            'iniciarconexionempresa()
            Cargando.Show()
            Cargando.MonoFlat_Label1.Text = "Intentando Conexión"
            FlowLayoutPanel1.Enabled = False
            Await Task.Factory.StartNew(Sub()


                                            If IntentaConexion() = True Then

                                                Dim comando As OleDb.OleDbCommand
                                                Dim consulta As String
                                                Dim reader As OleDb.OleDbDataReader
                                                comando = New OleDb.OleDbCommand
                                                consulta = "select id,rs,RFC,Calle,Nex,Col,Ciudad,Estado,CP,nombre FROM empresas where BD = '" & bdconsultas & "' and ip = '" & ipconsultas & "'"
                                                comando.Connection = conexion
                                                comando.CommandText = consulta
                                                reader = comando.ExecuteReader
                                                While reader.Read
                                                    NombreEmpresa = reader("rs")
                                                    RFCEmpresa = reader("RFC")
                                                    CalleEmpresa = reader("Calle")
                                                    NumeroEmpresa = reader("Nex")
                                                    ColEmpresa = reader("Col")
                                                    CiudadEmpresa = reader("Ciudad")
                                                    EstadoEmpresa = reader("Estado")
                                                    CPEmpresa = reader("CP")
                                                    nombreAmostrar = reader("Nombre")
                                                    idEmpresa = reader("id")
                                                End While
                                                Docs()
                                                Try
                                                    Dim conexionLogin As MySqlConnection
                                                    conexionLogin = New MySqlConnection()
                                                    conexionLogin.ConnectionString = "server=www.prestamosconfia.com;user id=ajas;pwd=123456;port=3306;database=USRS"
                                                    conexionLogin.Open()

                                                    Dim comandoEmpresaLogin As MySqlCommand
                                                    Dim consultaEmpresaLogin As String
                                                    consultaEmpresaLogin = "update Sesiones set Empresa = '" & nombreAmostrar & "' where id = '" & idSesion & "'"
                                                    comandoEmpresaLogin = New MySqlCommand
                                                    comandoEmpresaLogin.Connection = conexionLogin
                                                    comandoEmpresaLogin.CommandText = consultaEmpresaLogin
                                                    comandoEmpresaLogin.ExecuteNonQuery()
                                                Catch ex As Exception
                                                    IO.File.AppendAllText("C:\ConfiaAdmin\SAC\Log.txt", String.Format("{0}{1}", Environment.NewLine, ex.ToString()))
                                                End Try

                                                conCaja = CargarCaja()

                                                conectado = True
                                            Else
                                                MessageBox.Show("Pruebe de nuevo o verifique su configuración")
                                                FlowLayoutPanel1.Enabled = True
                                                conectado = False
                                                Cargando.Close()
                                            End If

                                        End Sub)


            If conectado Then
                If conCaja Then
                    Cargando.Close()
                    frm_adm.Show()
                    Me.Close()
                Else
                    MessageBox.Show("El número de caja " & noCaja & " configurado no figura dentro de las cajas de esta empresa")
                    Cargando.Close()
                    FlowLayoutPanel1.Enabled = True
                End If

            Else
                Cargando.Close()
            End If

            ' Me.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Function IntentaConexion() As Boolean

        Try
            Dim IntentoConexion As OleDbConnection
            Dim cnConexion As String
            cnConexion = "Provider=sqloledb;" &
                        "Data Source=  " & ipconsultas & "\confia;" &
                         "Initial Catalog=" & bdconsultas & ";" &
                         "User Id=sa;Password=BSi5t3Ma$CFAD;"
            IntentoConexion = New OleDbConnection(cnConexion)
            IntentoConexion.Open()
            Return True
        Catch ex As System.Data.OleDb.OleDbException
            MessageBox.Show("No se puede conectar con el servidor")
            Return False
        End Try


    End Function

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub
End Class