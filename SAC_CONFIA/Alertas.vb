Imports Microsoft.WindowsAPICodePack.Taskbar
Public Class Alertas
    Public cadena As String
    Dim contador As Integer = 0
    'Creamos una variable que define la cantidad de caracteres por linea
    Dim longitud_maxima As Integer = 30
    'La nueva cadena a imprimir en el textbox multiline
    Dim nueva_cadena As String = String.Empty
    Private windowTaskbar As TaskbarManager = TaskbarManager.Instance
    Private Sub Alertas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.BackColor = Me.BackColor
        For Each x As Char In cadena.ToCharArray
            'Incrementamos el contador
            contador += 1
            'si el contador es igual a la longitus maxima asignada
            If contador = longitud_maxima Then
                'Adjunto el caracter y le doy un salto de linea
                nueva_cadena = nueva_cadena & x & vbCrLf
                'Inicializo el contador a 0
                contador = 0
                'Sino...
            Else
                'Sigo adjuntando los caracteres a la nueva cadena
                nueva_cadena = nueva_cadena & x
            End If
        Next
        'Una vez finalizado el recorrido adjunto la nueva
        'cadena al textbox multiline
        If cadena.Length > TextBox1.Height Then
            TextBox1.ScrollBars = ScrollBars.Vertical
        Else
            TextBox1.ScrollBars = ScrollBars.None

        End If
        windowTaskbar.SetProgressState(TaskbarProgressBarState.[Error])
        windowTaskbar.SetProgressValue(10, 10)

        TextBox1.Text = cadena

        lblMensaje.Text = nueva_cadena

    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        windowTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
        Me.Close()

    End Sub

    Private Sub lblMensaje_Click(sender As Object, e As EventArgs) Handles lblMensaje.Click

    End Sub
End Class