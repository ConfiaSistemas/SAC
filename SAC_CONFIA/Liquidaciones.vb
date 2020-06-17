Public Class Liquidaciones
    Dim tipoDoc As Integer
    Dim Renovacion As Boolean = False
    Public idcredito As String
    Public Nom

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub Liquidaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Liquidaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            Renovacion = True
            lblRenovacion.Text = "Presiona F10 para quitar la marca de renovación"
            lblnota.Visible = True
        End If

        If e.KeyCode = Keys.F10 Then
            Renovacion = False
            lblRenovacion.Text = "Presiona F4 para marcar como renovación"
            lblnota.Visible = False
        End If
    End Sub

    Private Sub btnInsoluto_Click(sender As Object, e As EventArgs) Handles btnInsoluto.Click

    End Sub

    Private Sub btnInsoluto_MouseUp(sender As Object, e As MouseEventArgs) Handles btnInsoluto.MouseUp
        If Renovacion = False Then
            tipoDoc = ObtenerTipoDoc("Liquidación Insoluto")
            LiquidacionInsoluto.tipoDoc = tipoDoc
            LiquidacionInsoluto.idCredito = idcredito
            LiquidacionInsoluto.Show()
        Else
            tipoDoc = ObtenerTipoDoc("Renovación Insoluto")
            LiquidacionInsoluto.tipoDoc = tipoDoc
            LiquidacionInsoluto.idCredito = idcredito
            LiquidacionInsoluto.Show()
        End If
    End Sub
End Class