Public Class OtraCantidadEmpeño
    Public idempeño As Integer
    Public abonado, pendiente, montoEmpeño, interesEmpeño As Double
    Public nombreCredito As String

    Dim capitalEmpeño As Double

    Private Sub txtcantidad_OnValueChanged(sender As Object, e As EventArgs) Handles txtcantidad.OnValueChanged

    End Sub

    Private Sub txtOtraCantidad_Click(sender As Object, e As EventArgs) Handles txtOtraCantidad.Click
        If txtcantidad.Text < interesEmpeño Then
            MessageBox.Show("No puedes ingresar una cantidad menor al mínimo a pagar")
        Else
            capitalEmpeño = txtcantidad.Text - interesEmpeño
            If pendiente - capitalEmpeño = 0 Then
                Ticket_impresion.tipoDoc = ObtenerTipoDoc("Desempeño")
            Else
                Ticket_impresion.tipoDoc = ObtenerTipoDoc("Refrendo")
            End If

            Ticket_impresion.idCreditoRecibo = idempeño
            Ticket_impresion.interesEmpeño = FormatNumber(interesEmpeño, 2)
            Ticket_impresion.capitalEmpeño = capitalEmpeño
            Ticket_impresion.montocredito = montoEmpeño
            Ticket_impresion.pendienteEmpeño = pendiente - capitalEmpeño
            Ticket_impresion.abonadoEmpeño = abonado + capitalEmpeño

            Ticket_impresion.nombre_credito = nombreCredito
            Ticket_impresion.total = FormatNumber(txtcantidad.Text, 2)
            Ticket_impresion.Show()
            Ticket_impresion.TopMost = True
            Me.Close()

        End If

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub OtraCantidadEmpeño_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblminimo.Text = FormatCurrency(interesEmpeño, 2)

    End Sub
End Class