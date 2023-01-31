Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Text
Imports System.Threading.Tasks

Public Class Autorizacion
    Dim adapterUsuariosCautorizacion As OleDb.OleDbDataAdapter
    Dim dataUsuariosCautorizacion As DataTable
    Dim autorizado As Boolean
    Public tipoAutorizacion As String
    Dim passwordCorrect As Boolean
    Public frmAuto As New Ticket_impresion
    Dim ventana As Form
    Private Sub Autorizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MonoFlat_Button1_ClickAsync(sender As Object, e As EventArgs) Handles MonoFlat_Button1.Click

        FlowEspere.Visible = True
        txtusr.Enabled = False
        txtcontra.Enabled = False
        MonoFlat_Button1.Enabled = False
        MonoFlat_Button2.Enabled = False
        BackgroundWorker1.RunWorkerAsync()


    End Sub

    Private Async Function AutorizarAsync() As Task(Of Boolean)
        iniciarconexion()
        Dim consultaUsuariosCautorizacion As String
        Dim connexion = New OleDbConnection(cn)
        consultaUsuariosCautorizacion = "select Usr.Idusr,Usr.nm from Usr inner join grp on Usr.grp = grp.id inner join PermisosGrupo on PermisosGrupo.idGrupo = grp.id where PermisosGrupo." & tipoAutorizacion & " = 1"
        adapterUsuariosCautorizacion = New OleDbDataAdapter(consultaUsuariosCautorizacion, connexion)
        dataUsuariosCautorizacion = New DataTable
        adapterUsuariosCautorizacion.Fill(dataUsuariosCautorizacion)
        For Each row As DataRow In dataUsuariosCautorizacion.Rows
            If row("nm").ToString = txtusr.Text Then
                Try

                    Dim pass, passdecrypt As String
                    Dim s As String = ("SELECT idusr FROM usr  where nm = '" & txtusr.Text & "'")

                    Dim connexio = New OleDbConnection(cn)
                    Dim myCommand = New OleDbCommand(s)

                    myCommand.Connection = connexio

                    connexio.Open()
                    Dim myReader As OleDbDataReader = myCommand.ExecuteReader()

                    While myReader.Read()
                        idusr = myReader("idusr")

                    End While


                    Dim strcontra As String = ("select pass from usr where idusr = '" & idusr & "'")
                    Dim ejec = New OleDbCommand(strcontra)
                    ejec.Connection = connexio
                    Cargando.Show()
                    Cargando.MonoFlat_Label1.Text = "Cargando"
                    Await Task.Factory.StartNew(Sub()
                                                    Dim myreader2 As OleDbDataReader = ejec.ExecuteReader()
                                                    While myreader2.Read()
                                                        pass = myreader2("pass")
                                                        Dim byteconverter As New UnicodeEncoding()
                                                        Dim CadByte As Byte() = System.Convert.FromBase64String(pass)

                                                        Dim DecryptedMessage As Encryption.RSAResult = Encryption.RSA.Decrypt(CadByte, "<RSAKeyValue><Modulus>1D3WnN4qZq3DGHf7i3WjEixX0Nzka28RIR9lOrT7Eg2QmJTACm/E6388wMdGgH3yTwKPp/T5zm61yvZn44oHMka8EKlACGKkADsxN/ci0RLKJ0ZGYDVPtB+KSzI+GbmX2eO00R+FlYvXTpMzGXy3e4QpeCJbIbrDGFpt3rmXy28=</Modulus><Exponent>AQAB</Exponent><P>98YU9Nkhu3qQ4Y168ZbMX+kCFUEPK9mRDEc2yZiyfABU9UlrKU4Ja1qy47WJrQNSALA9nnARZgbiY/3JkslISQ==</P><Q>20nBaoUN5QK9cuH6yX0QqAzhhB88rsI/HFzb8xrbEkceNfsTbYOVt+7biqzQQAvsyEILU+0l529eSe6S52yl9w==</Q><DP>wk3CLWkBfQZXC6ppmX9KcoRFr+k/PoH1r41BN8LZZUjVVy3mLZQW6utLkirQ9q695fBPwincWwhXDVb+dnAGkQ==</DP><DQ>Ks/0hhJiCxME37gE2W+kX9rb8IqUs13TKntqqcTVfnUKDent+hSVl2p3zFQ++DIb0WEriwAixVN16iM85RfOMw==</DQ><InverseQ>coc9FIy42//YO02qCCKfORevLIU8GIeTSYFqD9kMwhHSy1a6QMDpKaYWrYvv8FcMHglqWzdTqbSgBSrsfcnibw==</InverseQ><D>JvPie4/awFWLxOXgaMwCTceNpmukEIOl5SpZ7dhhbALJUveZ91BkF8SWZdss+VAkNJQHwY+YeWagPsvSbVRb1WylY11D8gBQEb6EOR3EsM17/5+v6nRrJ5+cySfpcahRbUjUdJFaVhMCUQ1wsnevLNY/Xo20UF4XCE5Exp7TW0E=</D></RSAKeyValue>")
                                                        passdecrypt = DecryptedMessage.AsString
                                                    End While
                                                End Sub)



                    If StrComp(passdecrypt, txtcontra.Text, 0) = 0 Then


                        Cargando.Close()
                        Return True
                        'Me.Close()


                    Else
                        MessageBox.Show("Contraseña incorrecta")
                        txtcontra.Focus()
                        txtcontra.Select()
                        Cargando.Close()
                        passwordCorrect = True
                        Return False

                    End If



                Catch exc As System.Exception
                    Return False
                    MsgBox(exc.Message, MsgBoxStyle.Exclamation)
                End Try
                Exit For

            Else
                Return False
                MsgBox("El usuario no tiene autorización", MsgBoxStyle.Exclamation)
            End If
            'Exit For
        Next

    End Function

    Private Sub MonoFlat_Button2_Click(sender As Object, e As EventArgs) Handles MonoFlat_Button2.Click
        Select Case tipoAutorizacion

            Case "SacAcceso"
            Case "SacConsultaCredito"
            Case "SacCobrarCredito"
            Case "SacCobrarComision"
            Case "SacAplicarDescuento"
                frmAuto.autorizado = False

                Me.Close()
            Case "SacCancelarTicket"
            Case "SacDetalleCaja"
            Case "SacConsultarTicket"
            Case "SacModReportes"
            Case "SacCobrarExtra"
                frm_adm.autorizadoTicketExtra = False
                inicio.autorizado = False
                Me.Close()


        End Select
    End Sub

    Private Sub Autorizacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Select Case tipoAutorizacion

            Case "SacAcceso"
            Case "SacConsultaCredito"
            Case "SacCobrarCredito"
            Case "SacCobrarComision"
            Case "SacAplicarDescuento"
                If autorizado Then
                    frmAuto.autorizado = True
                    autorizado = False
                    txtusr.Text = ""
                    txtcontra.Text = ""
                Else
                    frmAuto.autorizado = False
                    autorizado = False
                    txtusr.Text = ""
                    txtcontra.Text = ""
                End If
            Case "SacCancelarTicket"
            Case "SacDetalleCaja"
            Case "SacConsultarTicket"
            Case "SacModReportes"
            Case "SacCobrarExtra"
                If autorizado Then
                    inicio.autorizado = True
                    frm_adm.autorizadoTicketExtra = True
                    autorizado = False
                    txtusr.Text = ""
                    txtcontra.Text = ""
                Else
                    inicio.autorizado = False
                    frm_adm.autorizadoTicketExtra = False
                    autorizado = False
                    txtusr.Text = ""
                    txtcontra.Text = ""
                End If

        End Select
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        iniciarconexion()
        Dim consultaUsuariosCautorizacion As String
        Dim connexion = New OleDbConnection(cn)
        consultaUsuariosCautorizacion = "select Usr.Idusr,Usr.nm from Usr inner join grp on Usr.grp = grp.id inner join PermisosGrupo on PermisosGrupo.idGrupo = grp.id where PermisosGrupo." & tipoAutorizacion & " = 1"
        adapterUsuariosCautorizacion = New OleDbDataAdapter(consultaUsuariosCautorizacion, connexion)
        dataUsuariosCautorizacion = New DataTable
        adapterUsuariosCautorizacion.Fill(dataUsuariosCautorizacion)
        For Each row As DataRow In dataUsuariosCautorizacion.Rows
            If row("nm").ToString.Equals(txtusr.Text, StringComparison.InvariantCultureIgnoreCase) Then

                Try

                    Dim pass, passdecrypt As String
                    Dim s As String = ("SELECT idusr FROM usr  where nm = '" & txtusr.Text & "'")

                    Dim connexio = New OleDbConnection(cn)
                    Dim myCommand = New OleDbCommand(s)

                    myCommand.Connection = connexio

                    connexio.Open()
                    Dim myReader As OleDbDataReader = myCommand.ExecuteReader()

                    While myReader.Read()
                        idusr = myReader("idusr")

                    End While


                    Dim strcontra As String = ("select pass from usr where idusr = '" & idusr & "'")
                    Dim ejec = New OleDbCommand(strcontra)
                    ejec.Connection = connexio


                    Dim myreader2 As OleDbDataReader = ejec.ExecuteReader()
                    While myreader2.Read()
                        pass = myreader2("pass")
                        Dim byteconverter As New UnicodeEncoding()
                        Dim CadByte As Byte() = System.Convert.FromBase64String(pass)

                        Dim DecryptedMessage As Encryption.RSAResult = Encryption.RSA.Decrypt(CadByte, "<RSAKeyValue><Modulus>1D3WnN4qZq3DGHf7i3WjEixX0Nzka28RIR9lOrT7Eg2QmJTACm/E6388wMdGgH3yTwKPp/T5zm61yvZn44oHMka8EKlACGKkADsxN/ci0RLKJ0ZGYDVPtB+KSzI+GbmX2eO00R+FlYvXTpMzGXy3e4QpeCJbIbrDGFpt3rmXy28=</Modulus><Exponent>AQAB</Exponent><P>98YU9Nkhu3qQ4Y168ZbMX+kCFUEPK9mRDEc2yZiyfABU9UlrKU4Ja1qy47WJrQNSALA9nnARZgbiY/3JkslISQ==</P><Q>20nBaoUN5QK9cuH6yX0QqAzhhB88rsI/HFzb8xrbEkceNfsTbYOVt+7biqzQQAvsyEILU+0l529eSe6S52yl9w==</Q><DP>wk3CLWkBfQZXC6ppmX9KcoRFr+k/PoH1r41BN8LZZUjVVy3mLZQW6utLkirQ9q695fBPwincWwhXDVb+dnAGkQ==</DP><DQ>Ks/0hhJiCxME37gE2W+kX9rb8IqUs13TKntqqcTVfnUKDent+hSVl2p3zFQ++DIb0WEriwAixVN16iM85RfOMw==</DQ><InverseQ>coc9FIy42//YO02qCCKfORevLIU8GIeTSYFqD9kMwhHSy1a6QMDpKaYWrYvv8FcMHglqWzdTqbSgBSrsfcnibw==</InverseQ><D>JvPie4/awFWLxOXgaMwCTceNpmukEIOl5SpZ7dhhbALJUveZ91BkF8SWZdss+VAkNJQHwY+YeWagPsvSbVRb1WylY11D8gBQEb6EOR3EsM17/5+v6nRrJ5+cySfpcahRbUjUdJFaVhMCUQ1wsnevLNY/Xo20UF4XCE5Exp7TW0E=</D></RSAKeyValue>")
                        passdecrypt = DecryptedMessage.AsString
                    End While




                    If StrComp(passdecrypt, txtcontra.Text, 0) = 0 Then



                        autorizado = True
                        'Me.Close()


                    Else
                        MessageBox.Show("Contraseña incorrecta")
                        txtcontra.Focus()
                        txtcontra.Select()
                        FlowEspere.Visible = False
                        passwordCorrect = True
                        autorizado = False

                    End If



                Catch exc As System.Exception
                    autorizado = False
                    MsgBox(exc.Message, MsgBoxStyle.Exclamation, "SATI")

                End Try
                Exit For

            Else

                autorizado = False

                'MsgBox("El usuario no tiene autorización", MsgBoxStyle.Exclamation, "SATI")
                ' Exit For

            End If
            'Exit For
        Next


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        FlowEspere.Visible = False
        txtusr.Enabled = True
        txtcontra.Enabled = True
        MonoFlat_Button1.Enabled = True
        MonoFlat_Button2.Enabled = True
        If autorizado Then
            Select Case tipoAutorizacion

                Case "SacAcceso"
                Case "SacConsultaCredito"
                Case "SacCobrarCredito"
                Case "SacCobrarComision"
                Case "SacAplicarDescuento"
                    frmAuto.autorizado = True
                    Me.Close()
                Case "SacCancelarTicket"
                Case "SacDetalleCaja"
                Case "SacConsultarTicket"
                Case "SacModReportes"
                Case "SacCobrarExtra"
                    inicio.autorizado = True
                    frm_adm.autorizadoTicketExtra = True
                    Me.Close()
            End Select
        Else
            If passwordCorrect Then
                passwordCorrect = False

            Else
                passwordCorrect = False
                MsgBox("El usuario no tiene autorización", MsgBoxStyle.Exclamation, "SATI")
            End If

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub
End Class