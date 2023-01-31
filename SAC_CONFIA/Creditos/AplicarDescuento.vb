Public Class AplicarDescuento
    Public frmDescuento As New Ticket_impresion
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        frmDescuento.txtDescuento.Text = txtTotal.Text
        Me.Close()
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub AplicarDescuento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class