Imports AForge.Video.DirectShow

Public Class webcam
    Private dispositivos As FilterInfoCollection
    Private fuentedevideo As VideoCaptureDevice
    Dim ex, ey As Integer
    Dim nombre As String
    Dim Arrastre As Boolean

    Private Sub webcam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dispositivos = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        For Each x As FilterInfo In dispositivos
            ComboBox1.Items.Add(x.Name)
        Next
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Btn_iniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_iniciar.Click
        fuentedevideo = New VideoCaptureDevice(dispositivos(ComboBox1.SelectedIndex).MonikerString)
        VideoSourcePlayer1.VideoSource = fuentedevideo
        VideoSourcePlayer1.Start()

    End Sub

    Private Sub btn_detener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_detener.Click
        VideoSourcePlayer1.SignalToStop()
    End Sub

    Private Sub btn_capturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_capturar.Click
        editarperfil.BunifuImageButton1.Image = VideoSourcePlayer1.GetCurrentVideoFrame
        editarperfil.labelimagen.Visible = False
    End Sub

    Private Sub webcam_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        ex = e.X

        ey = e.Y

        Arrastre = True
    End Sub

    Private Sub webcam_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'Si el formulario no tiene borde (FormBorderStyle = none) la siguiente linea funciona bien

        If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex, Me.MousePosition.Y - Me.Location.Y - ey))

        'pero si quieres dejar los bordes y la barra de titulo entonces es necesario descomentar la siguiente linea y comentar la anterior, osea ponerle el apostrofe

        'If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex - 8, Me.MousePosition.Y - Me.Location.Y - ey - 60))
    End Sub

    Private Sub webcam_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Arrastre = False
    End Sub
End Class