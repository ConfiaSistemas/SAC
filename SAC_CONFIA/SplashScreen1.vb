Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Windows
Imports MadMilkman.Ini
Imports MySql.Data.MySqlClient
Public NotInheritable Class SplashScreen1
    Dim hayActualizaciones As Boolean
    Friend conexionsql As MySqlConnection
    'TODO: Este formulario se puede establecer fácilmente como pantalla de presentación para la aplicación desde la pestaña "Aplicación"
    '  del Diseñador de proyectos ("Propiedades" bajo el menú "Proyecto").


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configure el texto del cuadro de diálogo en tiempo de ejecución según la información del ensamblado de la aplicación.  

        'TODO: Personalice la información del ensamblado de la aplicación en el panel "Aplicación" del cuadro de diálogo 
        '  propiedades del proyecto (bajo el menú "Proyecto").

        'Título de la aplicación


        'Dé formato a la información de versión usando el texto establecido en el control de versiones en tiempo de diseño como
        '  cadena de formato.  Esto le permite una localización efectiva si lo desea.
        '  Se pudo incluir la información de compilación y revisión usando el siguiente código y cambiando el 
        '  texto en tiempo de diseño del control de versiones a "Versión {0}.{1:00}.{2}.{3}" o algo parecido.  Consulte
        '  String.Format() en la Ayuda para obtener más información.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        'Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Información de Copyright
        'Copyright.Text = My.Application.Info.Copyright
        CheckForIllegalCrossThreadCalls = False

        Label1.Text = "Buscando Actualizaciones"
        Backgroundmysql.RunWorkerAsync()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ' BunifuTransition1.Hide(Me)
        login.Show()
        Me.Close()

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim options As New IniOptions() With {.EncryptionPassword = "EntUs01pos"}
        Dim iniFile As New IniFile(options)
        iniFile.Load("C:\ConfiaAdmin\SAC\SetConfig.ini")
        Dim bdAct As String
        Dim serverAct As String
        Dim cnAct As String
        Dim conexionAct As OleDbConnection
        serverAct = iniFile.Sections(0).Keys(0).Value
        bdAct = iniFile.Sections(0).Keys(1).Value
        Try
            TipoEquipo = iniFile.Sections(0).Keys("Tipo").Value
        Catch ex As System.ArgumentOutOfRangeException
            TipoEquipo = ""
            'MessageBox.Show("No se encontró el valor leyenda configurado, se recomienda revisar la configuración")
        Catch ex As NullReferenceException
            TipoEquipo = ""
            'MessageBox.Show("No se encontró el valor leyenda configurado, se recomienda revisar la configuración")
        End Try

        'TipoEquipo = iniFile.Sections(0).Keys("Tipo").Value

        cnAct = "Provider=sqloledb;" &
                     "Data Source=  " & serverAct & "\confia;" &
                     "Initial Catalog=" & bdAct & ";" &
                     "User Id=sa;Password=BSi5t3Ma$CFAD;"
        conexionAct = New OleDbConnection(cnAct)
        conexionAct.Open()

        Dim comandoVersion As OleDbCommand
        Dim consultaVersion As String
        Dim versionAct As String
        consultaVersion = "select nversion from versiones where sistema = 'SAC'"
        comandoVersion = New OleDbCommand
        comandoVersion.Connection = conexionAct
        comandoVersion.CommandText = consultaVersion
        versionAct = comandoVersion.ExecuteScalar


        conexionAct.Close()

        If Application.ProductVersion <> versionAct Then
            hayActualizaciones = True


        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If hayActualizaciones Then
            If MessageBox.Show("Hay una actualización disponible ¿Desea actualizar ahora?", "SAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Forms.DialogResult.Yes Then
                Dim Proceso As Process = New Process
                Dim ruta As String = "C:\ConfiaAdmin\Updater\Updater.exe"
                Proceso.StartInfo.FileName = ruta
                Proceso.StartInfo.Arguments = "/S SAC /T " & TipoEquipo
                Proceso.Start()
                Application.Exit()
            Else
                Timer1.Interval = 500
                Timer1.Enabled = True
            End If


        Else
            Timer1.Interval = 500
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Backgroundmysql_DoWork(sender As Object, e As DoWorkEventArgs) Handles Backgroundmysql.DoWork
        Dim options As New IniOptions() With {.EncryptionPassword = "EntUs01pos"}
        Dim iniFile As New IniFile(options)
        iniFile.Load("C:\ConfiaAdmin\SAC\SetConfig.ini")
        Dim bdAct As String
        Dim serverAct As String

        serverAct = iniFile.Sections(0).Keys(0).Value
        bdAct = iniFile.Sections(0).Keys(1).Value
        Try
            TipoEquipo = iniFile.Sections(0).Keys("Tipo").Value
        Catch ex As System.ArgumentOutOfRangeException
            TipoEquipo = ""
            'MessageBox.Show("No se encontró el valor leyenda configurado, se recomienda revisar la configuración")
        Catch ex As NullReferenceException
            TipoEquipo = ""
            'MessageBox.Show("No se encontró el valor leyenda configurado, se recomienda revisar la configuración")
        End Try

        conexionsql = New MySqlConnection()
        conexionsql.ConnectionString = "server=www.prestamosconfia.com;user id=ajas;pwd=123456;port=3306;database=Versiones"
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

        If Application.ProductVersion <> versionAct Then
            hayActualizaciones = True


        End If
    End Sub

    Private Sub Backgroundmysql_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Backgroundmysql.RunWorkerCompleted
        If hayActualizaciones Then
            If MessageBox.Show("Hay una actualización disponible ¿Desea actualizar ahora?", "SAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Forms.DialogResult.Yes Then
                Dim Proceso As Process = New Process
                Dim ruta As String = "C:\ConfiaAdmin\Updater\Updater.exe"
                Proceso.StartInfo.FileName = ruta
                Proceso.StartInfo.Arguments = "/S SAC /T " & TipoEquipo
                Proceso.Start()
                Application.Exit()
            Else
                Timer1.Interval = 500
                Timer1.Enabled = True
            End If


        Else
            Timer1.Interval = 500
            Timer1.Enabled = True
        End If
    End Sub
End Class
