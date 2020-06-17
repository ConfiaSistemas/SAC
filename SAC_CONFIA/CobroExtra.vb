Public Class CobroExtra
    Dim tipoDoc As Integer

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        tipoDoc = ObtenerTipoDoc("Extra")
        ' MessageBox.Show(ObtenerTipoDoc("Extra"))
        Ticket_impresion.Concepto = txtConcepto.Text
        Ticket_impresion.total = txtMonto.Text
        Ticket_impresion.tipoDoc = tipoDoc
        Ticket_impresion.Show()
        Me.Close()

    End Sub

    Private Sub txtMonto_OnValueChanged(sender As Object, e As EventArgs) Handles txtMonto.OnValueChanged

    End Sub

    Private Sub txtMonto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMonto.KeyDown
        If e.KeyCode = Keys.F5 Then
            tipoDoc = ObtenerTipoDoc("Extra")
            Ticket_impresion.Concepto = txtConcepto.Text
            Ticket_impresion.total = txtMonto.Text
            Ticket_impresion.tipoDoc = tipoDoc
            Ticket_impresion.Show()
            Me.Close()

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