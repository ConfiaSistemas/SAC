
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports Encryption.RSA
Imports System.Text
Imports MadMilkman.Ini
Imports System.IO
Imports System.Threading.Tasks
Imports System.ComponentModel

Public Class login
    Public bloqueado As Boolean
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Integer) As Long

    Public Async Sub MonoFlat_Button1_ClickAsync(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonoFlat_Button1.Click
        If bloqueado Then
            passwordBloqueadoAsync()
        Else
            passwordInicioAsync()
        End If

    End Sub
    Public Async Sub passwordInicioAsync()
        Dim options As New IniOptions() With {.EncryptionPassword = "EntUs01pos"}
        Dim iniFile As New IniFile(options)
        iniFile.Load("C:\ConfiaAdmin\SAC\SetConfig.ini")
        ipser = iniFile.Sections(0).Keys(0).Value
        bdser = iniFile.Sections(0).Keys(1).Value
        Try
            noCaja = iniFile.Sections(0).Keys("Caja").Value
        Catch ex As System.NullReferenceException
            noCaja = 0
        End Try

        Impresora = iniFile.Sections(0).Keys("Impresora").Value
        iniciarconexion()
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
            If idusr = "" Then
                MessageBox.Show("No existe el usuario")
                txtusr.Focus()
                txtusr.Select()
            Else

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
                    If bloqueado Then
                        bloqueado = False
                        Cargando.Close()
                        Me.Close()
                    Else
                        Cargando.Show()
                        Cargando.MonoFlat_Label1.Text = "Cargando"
                        Await Task.Factory.StartNew(Sub()
                                                        cargarperfil()

                                                        'frm_adm.Show()


                                                    End Sub)
                        Empresas.Show()
                        connexio.Close()
                        Cargando.Close()
                        Me.Close()
                    End If


                Else
                    MessageBox.Show("Contraseña incorrecta")
                    txtcontra.Focus()
                    txtcontra.Select()




                End If
            End If


        Catch exc As System.Exception
            MsgBox(exc.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Public Async Sub passwordBloqueadoAsync()
        iniciarconexion()

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
            If Not nmusr.Equals(txtusr.Text, StringComparison.InvariantCultureIgnoreCase) Then

                MessageBox.Show("El sistema fue bloqueado por otro usuario")
                txtusr.Focus()
                txtusr.Select()
            Else

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

                    bloqueado = False
                    Cargando.Close()
                    Me.Close()


                Else
                    MessageBox.Show("Contraseña incorrecta")
                    txtcontra.Focus()
                    txtcontra.Select()




                End If
            End If


        Catch exc As System.Exception
            MsgBox(exc.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub


    Private Sub txtcontra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyValue = Keys.Enter Then
            MessageBox.Show("hola")
        End If

    End Sub




    Private Sub txtcontra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub









    Private Sub login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Timer1.Enabled = True
        AddHandler txtusr.KeyPress, AddressOf keypressed


    End Sub


    Private Sub MonoFlat_TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub


    Private Sub keypressed(ByVal o As [Object], ByVal e As KeyPressEventArgs)
        ' The keypressed method uses the KeyChar property to check 
        ' whether the ENTER key is pressed. 

        ' If the ENTER key is pressed, the Handled property is set to true, 
        ' to indicate the event is handled.


    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frm_adm.Show()

    End Sub

    Private Sub MonoFlat_Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtcontra_Move(sender As Object, e As EventArgs)

    End Sub

    Private Sub MonoFlat_ThemeContainer1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub login_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If bloqueado Then
            e.Cancel = True
        End If
    End Sub

    Private Sub txtcontra_TextChanged_1(sender As Object, e As EventArgs) Handles txtcontra.TextChanged

    End Sub

    Private Sub txtcontra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontra.KeyPress

    End Sub

    Private Sub txtusr_TextChanged(sender As Object, e As EventArgs) Handles txtusr.TextChanged

    End Sub

    Private Sub txtusr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtusr.KeyDown
        If e.KeyCode = Keys.F2 Then
            MessageBox.Show("Hola")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub login_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'SendKeys.Send("{TAB}")
    End Sub
End Class