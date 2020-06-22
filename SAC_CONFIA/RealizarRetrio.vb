Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class RealizarRetrio
    Private Sub RealizarRetrio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combofiltro.SelectedIndex = 0
    End Sub

    Private Sub Combofiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combofiltro.SelectedIndexChanged
        Select Case Combofiltro.Text
            Case "Otro"
                lblconcepto.Visible = True
                txtConcepto.Visible = True

            Case Else
                lblconcepto.Visible = False
                txtConcepto.Visible = False
        End Select
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub BackgroundRetiro_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundRetiro.DoWork
        iniciarconexionempresa()
        Dim comandoNoRetiro As SqlCommand

        Dim consultaNoRetiro As String
        Dim NoRetiro As Integer
        Dim fechainsercionhasta As String
        Dim monto As Double
        Dim fechaRetiro As String
        Dim concepto As String
        monto = txtmonto.Text
        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
        fechainsercionhasta = Now.Date

        Dim fechasqlhasta As Date
        fechasqlhasta = fechainsercionhasta
        fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
        consultaNoRetiro = "Select top 1 NoRetiro from Retiros where fecha >= '" & fechainsercionhasta & "' and fecha <= '" & fechainsercionhasta & "' and caja = '" & noCaja & "' order by NoRetiro desc"
        comandoNoRetiro = New SqlCommand
        comandoNoRetiro.Connection = conexionempresa
        comandoNoRetiro.CommandText = consultaNoRetiro
        If IsDBNull(comandoNoRetiro.ExecuteScalar) Then
            NoRetiro = 1
        Else
            NoRetiro = comandoNoRetiro.ExecuteScalar + 1

        End If
        fechaRetiro = Format(fechasqlhasta, "dd/MM/yyyy")
        Dim idRetiro As Integer = 0
        Dim comandoRetiros As SqlCommand
        Dim consultaRetiros As String
        Select Case Combofiltro.Text
            Case "Otro"
                concepto = txtConcepto.Text
                consultaRetiros = "Insert into Retiros values('" & txtmonto.Text & "','" & NoRetiro & "','" & fechainsercionhasta & "','" & tiempo & "','" & noCaja & "','" & txtConcepto.Text & "','" & nmusr & "','','NA','','') select SCOPE_IDENTITY()"
            Case Else
                concepto = Combofiltro.Text
                consultaRetiros = "Insert into Retiros values('" & txtmonto.Text & "','" & NoRetiro & "','" & fechainsercionhasta & "','" & tiempo & "','" & noCaja & "','" & Combofiltro.Text & "','" & nmusr & "','','','','') select SCOPE_IDENTITY()"

        End Select
        comandoRetiros = New SqlCommand
        comandoRetiros.Connection = conexionempresa
        comandoRetiros.CommandText = consultaRetiros
        'comandoRetiros.ExecuteNonQuery()
        idRetiro = comandoRetiros.ExecuteScalar
        ' Dim comandoIdRetiro As OleDb.OleDbCommand
        'Dim consultaIdRetiro As String
        ' consultaIdRetiro = "Select top 1 id from RetirosCaja order by id desc "

        ' comandoIdRetiro = New OleDb.OleDbCommand
        'comandoIdRetiro.Connection = conexionempresa
        'comandoIdRetiro.CommandText = consultaIdRetiro
        'idRetiro = comandoIdRetiro.ExecuteScalar
        'MessageBox.Show(idRetiro)
        'MessageBox.Show("Listo")
        Dim P As New PrinterClass(Impresora, Application.StartupPath, False)

        With P

            .AlignCenter()
            .RTL = False
            .AlignCenter()
            .Gotox(1050)
            .PrintLogo()
            .GotoSixth(1)
            .NormalFont()
            .FontSize = 8
            .WriteLine("Retiro")
            .WriteLine("")

            .DrawLine()
            .GotoSixth(1)
            .FontSize = 7.3
            .Bold = True
            .WriteChars("ID:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(idRetiro)
            .WriteLine("")
            .Bold = True
            .GotoSixth(1)
            .WriteChars("NO. DE RETIRO:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(NoRetiro)
            .WriteLine("")
            .GotoSixth(1)
            .Bold = True
            .WriteChars("Caja")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(noCaja)
            .WriteLine("")
            .GotoSixth(1)
            .Bold = True
            .WriteChars("CONCEPTO:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(concepto)
            .WriteLine("")
            .GotoSixth(1)
            .Bold = True
            .WriteChars("MONTO:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars((monto).ToString("$ ##,##00.00"))
            .WriteLine("")


            .GotoSixth(1)
            .Bold = True

            .WriteChars("FECHA Y HORA:")
            .Bold = False
            .GotoSixth(3)
            .WriteChars(fechaRetiro & " - " & tiempo)

            .WriteLine("")

            .CutPaper()
            .EndDoc()

        End With


        Me.Close()

    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        Cargando.Show()
        Cargando.MonoFlat_Label1.Text = "Generando retiro"
        Cargando.TopMost = True
        BackgroundRetiro.RunWorkerAsync()
    End Sub

    Private Sub BackgroundRetiro_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundRetiro.RunWorkerCompleted
        Cargando.Close()
        Me.Close()

    End Sub
End Class