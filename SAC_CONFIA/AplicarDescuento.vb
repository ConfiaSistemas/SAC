﻿Public Class AplicarDescuento
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        Ticket_impresion.txtDescuento.Text = txtTotal.Text
        Me.Close()
    End Sub
End Class