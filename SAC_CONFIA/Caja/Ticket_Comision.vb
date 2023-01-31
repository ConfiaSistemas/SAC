Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Ticket_Comision
    Public total As Double
    Public idRecibo As Integer
    Dim recibido As Double
    Public nombre_credito As String
    Public cp As Double
    Public idCreditoRecibo As Integer
    Public montocredito As Integer
    Dim horadepago As String
    Dim fechadePago As String
    Private Sub Ticket_Comision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTotal.Text = total
        txtRecibido.Text = total
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub txtRecibido_OnValueChanged(sender As Object, e As EventArgs) Handles txtRecibido.OnValueChanged
        If txtRecibido.Text = "" Then
            recibido = 0
        Else

            recibido = Convert.ToDouble(txtRecibido.Text)

        End If


        If recibido < total Then
            txtCambio.Text = 0

        Else
            txtCambio.Text = recibido - Convert.ToDouble(txtTotal.Text)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim NumeroLetra As New NumLetra
        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
        Dim comandoRecibo As SqlCommand

        Dim consultarecibo As String
        iniciarconexionempresa()
        Dim fechainsercionhasta As String
        fechainsercionhasta = Now.Date

        Dim fechasqlhasta As Date
        fechasqlhasta = fechainsercionhasta
        fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
        consultarecibo = "Insert into Ticket values('" & total & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','2','','" & nmusr & "','" & noCaja & "',0,'A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
        comandoRecibo = New SqlCommand
        comandoRecibo.Connection = conexionempresa
        comandoRecibo.CommandText = consultarecibo
        'comandoRecibo.ExecuteNonQuery()
        idRecibo = comandoRecibo.ExecuteScalar
        fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
        horadepago = tiempo

        ' Dim consultaIdRecibo As String
        'consultaIdRecibo = "Select top 1 idRecibo from recibos order by idRecibo desc "
        'comandoIdRecibo = New OleDb.OleDbCommand
        'comandoIdRecibo.Connection = conexionempresa
        'comandoIdRecibo.CommandText = consultaIdRecibo
        'idRecibo = comandoIdRecibo.ExecuteScalar



        'MessageBox.Show("Listo")

        Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
        For copy As Integer = 1 To 2
            With P

                .AlignCenter()
                .RTL = False
                .AlignCenter()
                .GotoSixth(3)
                .PrintLogo()
                .GotoSixth(1)
                .NormalFont()
                .WriteLine(NombreEmpresa)
                .WriteLine("")
                .WriteLine(RFCEmpresa)
                .FontSize = 8
                .WriteLine("")
                .WriteChars("Calle  " & CalleEmpresa & "  " & NumeroEmpresa)


                .WriteLine("")
                .GotoSixth(1)
                .WriteChars("Colonia" & " " & ColEmpresa)

                .WriteLine("")
                .GotoSixth(1)
                .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                .WriteLine("")

                .DrawLine()
                .GotoSixth(1)
                .FontSize = 6
                .Bold = True
                .WriteChars("TICKET:")
                .Bold = False
                .GotoSixth(3)
                .WriteChars(idRecibo)
                .WriteLine("")
                .Bold = True
                .GotoSixth(1)
                .WriteChars("CAJA:")
                .Bold = False
                .GotoSixth(3)
                .WriteChars(noCaja)
                .WriteLine("")
                .Bold = True
                .GotoSixth(1)
                .WriteChars("ATENDIDO POR:")
                .Bold = False
                .GotoSixth(3)
                .WriteChars(nm_completeusr)
                .WriteLine("")
                .Bold = True
                .GotoSixth(1)
                .WriteChars("CRÉDITO NO.:")
                .Bold = False
                .GotoSixth(3)
                .WriteChars(idCreditoRecibo)
                .WriteLine("")
                .GotoSixth(1)
                .Bold = True
                .WriteChars("MONTO DEL CRÉDITO:")
                .Bold = False
                .GotoSixth(3)
                .WriteChars((montocredito).ToString("$ ##,##00.00"))
                .WriteLine("")
                .GotoSixth(1)
                .Bold = True
                .WriteChars("CLIENTE:")
                .GotoSixth(3)
                .Bold = False
                .WriteChars(nombre_credito)
                .WriteLine("")
                .GotoSixth(1)
                .Bold = True
                .WriteChars("PLAZO(semanas):")
                .GotoSixth(3)
                .Bold = False
                .WriteChars(cp)
                .WriteLine("")



                .GotoSixth(1)
                .Bold = True

                .WriteChars("FECHA Y HORA DE PAGO:")
                .Bold = False
                .GotoSixth(3)
                .WriteChars("  " & fechadePago & " - " & horadepago)

                .WriteLine("")
                .DrawLine()

                .GotoSixth(1)
                .Bold = True

                .WriteChars("DESCRIPCIÓN")
                .GotoSixth(5)
                .WriteChars("MONTO")

                .WriteLine("")

                .DrawLine()



                .GotoSixth(1)
                .WriteChars("Comisión por Apertura")

                .GotoSixth(5)
                .WriteChars((total / 1.16).ToString("$ ##,##00.00"))
                .WriteLine("")
                .GotoSixth(1)
                .WriteChars("I.V.A")


                .GotoSixth(5)
                .WriteChars(((total / 1.16) * 0.16).ToString("$ ##,##00.00"))
                .WriteLine("")

                .DrawLine()

                .GotoSixth(1)
                .WriteChars("Total Pagado")
                .GotoSixth(5)
                .WriteChars((total).ToString("$ ##,##00.00"))
                .WriteLine("")
                .GotoSixth(1)
                .WriteChars("Recibido")
                .GotoSixth(5)
                Dim recibido As Double
                recibido = Convert.ToDouble(txtRecibido.Text)
                .WriteChars((recibido).ToString("$ ##,##00.00"))
                .WriteLine("")
                .GotoSixth(1)
                .WriteChars("Cambio")
                .GotoSixth(5)
                Dim cambio As Double
                If txtCambio.Text = "" Then
                    cambio = 0
                Else
                    cambio = Convert.ToDouble(txtCambio.Text)
                End If
                .WriteChars((cambio).ToString("$ ##,##00.00"))
                .WriteLine("")
                .GotoSixth(1)
                .DrawLine()
                .GotoSixth(1)
                .WriteLine(NumeroLetra.Convertir(total.ToString, True))
                .WriteLine("")
                .GotoSixth(1)

                .GotoSixth(1)
                .Bold = False
                .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                .CutPaper()
                .EndDoc()

            End With

        Next

        ' Me.Close()

    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        If recibido < total Then
            MessageBox.Show("No se puede recibir un monto menor al total a pagar")
        Else
            Cargando.Show()
            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Cargando.Close()
        Me.Invoke(Sub()
                      Creditos_Autorizados.cargarSolicitudes()

                  End Sub)
        Me.Close()
    End Sub
End Class