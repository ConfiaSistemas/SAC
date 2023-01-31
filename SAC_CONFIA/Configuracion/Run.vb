Imports System.Text.RegularExpressions
Imports MadMilkman.Ini

Public Class Run
    Dim comando As String
    Dim comandoArray As String()

    ' Dim i As Integer
    Private Sub txtcmd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcmd.KeyDown
        If e.KeyCode = Keys.Enter Then

            comando = txtcmd.Text
            Dim x As Integer
            Dim cantItems As Integer = 0
            x = 0
            'comando = comando.Replace(" "c, String.Empty)
            Dim regex As Regex = New Regex("[\s*]|([=])")
            comandoArray = regex.Split(comando)
            For i As Integer = 0 To comandoArray.Count - 1
                If comandoArray(i) <> "" Then
                    cantItems += 1

                End If
            Next


            ' comandoArray = Regex.Split(comando, "\s+")
            Dim tempArray(cantItems) As String
            For i As Integer = 0 To comandoArray.Count - 1
                If comandoArray(i) <> "" Then
                    tempArray(x) = comandoArray(i)
                    x = x + 1

                End If
            Next

            For i As Integer = 0 To tempArray.Count - 1
                'MessageBox.Show(tempArray(i))
                If tempArray(i).Equals("SET", StringComparison.InvariantCultureIgnoreCase) Then
                    If tempArray(i + 1) <> "" Then

                        If tempArray(i + 1).Equals("TYPE", StringComparison.InvariantCultureIgnoreCase) Then
                            If tempArray(i + 2) = "=" Then
                                TipoEquipo = tempArray(i + 3)
                                Dim options As IniOptions = New IniOptions() With {.EncryptionPassword = "EntUs01pos"}
                                Dim file As IniFile = New IniFile(options)


                                Dim section As IniSection = file.Sections.Add("Conexión")
                                section.Keys.Add("Ip", ipser)
                                section.Keys.Add("Base", bdser)
                                section.Keys.Add("Caja", noCaja)
                                section.Keys.Add("Impresora", Impresora)
                                section.Keys.Add("Tipo", TipoEquipo)

                                ' Save and encrypt the file.
                                file.Save("C:\ConfiaAdmin\SAC\SetConfig.ini")

                                file.Sections.Clear()
                                'ipser = txtIp.Text
                                'bdser = txtBD.Text
                                'ImpresoraPredeterminada = ComboImpresora.Text
                                MessageBox.Show("Se ha marcado este equipo como " & TipoEquipo)
                                Me.Close()
                                Exit For
                            Else
                                MessageBox.Show("No se reconoce el caracter " & tempArray(i + 2))
                                Exit For
                            End If
                        Else
                            MessageBox.Show("No se reconoce el comando " & tempArray(i + 1))
                            Exit For
                        End If
                    Else
                        MessageBox.Show("SET necesita más argumentos")
                    End If





                ElseIf tempArray(i).Equals("GET", StringComparison.InvariantCultureIgnoreCase) Then

                    If tempArray(i + 1) <> "" Then
                        If tempArray(i + 1).Equals("type", StringComparison.InvariantCultureIgnoreCase) Then
                            MessageBox.Show("Éste equipo es: " & TipoEquipo)
                            Exit For

                        Else
                            MessageBox.Show("No se reconoce el comando " & tempArray(i + 1))
                            Exit For
                        End If

                    Else
                        MessageBox.Show("Get necesita más argumentos")
                        Exit For
                    End If
                ElseIf tempArray(i).Equals("DisableSession", StringComparison.InvariantCultureIgnoreCase) Then
                    frm_adm.TimerActSesion.Stop()

                    frm_adm.TimerActSesion.Enabled = False
                    MessageBox.Show("Sesión deshabilitada")
                    Exit For

                ElseIf tempArray(i).Equals("EnableSession", StringComparison.InvariantCultureIgnoreCase) Then
                    frm_adm.TimerActSesion.Enabled = True
                    frm_adm.TimerActSesion.Start()
                    MessageBox.Show("Sesión habilitada")
                    Exit For


                Else

                    MessageBox.Show("No se reconoce el comando " & tempArray(i))
                    Exit For
                End If


            Next


            'If txtcmd.Text.Equals("Migrate", StringComparison.InvariantCultureIgnoreCase) Then
            '    Migrar.Show()
            '    Me.Close()

            'End If
            'If txtcmd.Text.Equals("PruebaDatosSolicitud", StringComparison.InvariantCultureIgnoreCase) Then
            '    DatosSolicitud.Show()
            '    Me.Close()

            'End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub txtcmd_OnValueChanged(sender As Object, e As EventArgs) Handles txtcmd.OnValueChanged

    End Sub
End Class