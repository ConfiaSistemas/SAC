Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class editarperfil
    Dim ex, ey As Integer
    Dim nombre As String
    Dim Arrastre As Boolean
    Private Sub editarperfil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If imgstrusr = "" Then
            BunifuImageButton1.Image = Nothing
        Else
            BunifuImageButton1.Image = bitmapimgusr
            labelimagen.Visible = False

        End If
        If nm_completeusr <> "" Then
            txtnombre.Text = nm_completeusr
        End If

        If addrusr <> "" Then
            txtdireccion.Text = addrusr
        End If

        If tlfusr <> "" Then
            txttelefono.Text = tlfusr
        End If

        BunifuImageButton1.AllowDrop = True
        Dim mensajesayuda As New ToolTip
        mensajesayuda.AutoPopDelay = 5000
        mensajesayuda.InitialDelay = 500
        mensajesayuda.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        mensajesayuda.ShowAlways = True
        mensajesayuda.SetToolTip(Me.BunifuImageButton1, "Arrastra una imagen o da clic para agregar una imagen")
    End Sub
    Private Sub editarperfil_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        ex = e.X

        ey = e.Y

        Arrastre = True

    End Sub

    Private Sub editarperfil_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

        Arrastre = False

    End Sub

    Private Sub editarperfil_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        'Si el formulario no tiene borde (FormBorderStyle = none) la siguiente linea funciona bien

        If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex, Me.MousePosition.Y - Me.Location.Y - ey))

        'pero si quieres dejar los bordes y la barra de titulo entonces es necesario descomentar la siguiente linea y comentar la anterior, osea ponerle el apostrofe

        'If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex - 8, Me.MousePosition.Y - Me.Location.Y - ey - 60))

    End Sub



    Private Sub BunifuImageButton1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BunifuImageButton1.DragDrop
        Try
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then

                Dim strRutaArchivoImagen As String

                Dim i As Integer

                'Asignamos la primera posición del array de ruta de archivos a la variable de tipo string

                'declarada anteriormente ya que en este caso sólo mostraremos una imagen en el control.

                strRutaArchivoImagen = e.Data.GetData(DataFormats.FileDrop)(0)

                'La cargamos al control

                BunifuImageButton1.Load(strRutaArchivoImagen)
            End If
            labelimagen.Visible = False
        Catch ex As ArgumentException
            MsgBox("Archivo no válido", MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub BunifuImageButton1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles BunifuImageButton1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            'Los archivos son externos a nuestra aplicación por lo que de indicaremos All ya que dará lo mismo.

            e.Effect = DragDropEffects.All

        End If

    End Sub


    Private Sub BunifuImageButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuImageButton1.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Imágenes (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.jpeg;*.png"
        openFileDialog1.FilterIndex = 1

        openFileDialog1.ShowDialog()
        If openFileDialog1.FileName <> "" Then
            nombre = openFileDialog1.FileName
            BunifuImageButton1.Image = Image.FromFile(nombre)
            labelimagen.Visible = False

        Else
            MessageBox.Show("No se seleccionó ningún archivo")

        End If
    End Sub

    Private Sub BunifuThinButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuThinButton21.Click
        Dim streamimg As System.IO.MemoryStream
        Dim bitmapbytes As Byte()
        Dim bytestring As String

        streamimg = New MemoryStream
        Dim s As String

        Dim connexio = New OleDbConnection(cn)
        Dim myCommand As OleDbCommand
        Dim myReader As OleDbDataReader

        If txtnombre.Text = "" Then
            MsgBox("La caja de nombre no puede estar vacía", MsgBoxStyle.Exclamation)
            txtnombre.Focus()

        Else
            If txtdireccion.Text = "" Then
                MsgBox("La caja de dirección no puede estar vacía", MsgBoxStyle.Exclamation)
                txtdireccion.Focus()
            Else
                If txttelefono.Text = "" Then
                    MsgBox("La caja de teléfono no puede estar vacía", MsgBoxStyle.Exclamation)
                    txttelefono.Focus()
                Else


                    connexio.Open()
                    If BunifuImageButton1.Image IsNot Nothing Then
                        BunifuImageButton1.Image.Save(streamimg, System.Drawing.Imaging.ImageFormat.Bmp)
                        bitmapbytes = streamimg.ToArray
                        bytestring = Convert.ToBase64String(bitmapbytes)

                        ' s = "update usr set nm_complete = '" & txtnombre.Text & "', addr = '" & txtdireccion.Text & "', tlf = '" & Convert.ToInt64(txttelefono.Text) & "', imgstr = '" & bytestring & "' where idusr = '" & idusr & "'"
                        myCommand = New OleDbCommand(String.Format("update usr set nm_complete = '" & txtnombre.Text & "', addr = '" & txtdireccion.Text & "', tlf = '" & txttelefono.Text & "' , imgstr = '" & bytestring & "' where idusr = '" & idusr & "'"))
                    Else
                        myCommand = New OleDbCommand(String.Format("update usr set nm_complete = '" & txtnombre.Text & "', addr = '" & txtdireccion.Text & "', tlf = '" & Convert.ToDouble(txttelefono.Text) & "', imgstr = '' where idusr = '" & idusr & "'"))
                        s = "update usr set nm_complete = '" & txtnombre.Text & "', addr = '" & txtdireccion.Text & "', tlf = '" & txttelefono.Text & "' where idusr = '" & idusr & "'"
                    End If
                    Try
                        myCommand.Connection = connexio
                        myCommand.ExecuteNonQuery()
                        connexio.Close()
                        cargarperfil()
                        MsgBox("Hecho", MsgBoxStyle.Information)
                        Me.Close()

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                    End Try

                End If
            End If
        End If
    End Sub

    Private Sub txttelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono.KeyPress
        Dim errorprovider1 As New ErrorProvider


        If Char.IsDigit(e.KeyChar) Then

            e.Handled = False

        ElseIf Char.IsControl(e.KeyChar) Then

            e.Handled = False

        Else

            e.Handled = True

        End If
    End Sub

    
    Private Sub LinkLabeldelimage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabeldelimage.LinkClicked
        BunifuImageButton1.Image = Nothing
        labelimagen.Visible = True

    End Sub

    Private Sub BunifuThinButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BunifuThinButton22.Click
        webcam.Show()

    End Sub
End Class