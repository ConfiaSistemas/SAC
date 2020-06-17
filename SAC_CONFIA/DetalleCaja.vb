Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class DetalleCaja

    Dim total As Double
    Dim retiros As Double
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        lblNoCaja.Text = noCaja
        lblFondoCaja.Text = FormatCurrency(FondoCaja, 2)
        CanCobrar = PuedeCobrar()
        lblCantRetiros.Text = cantRetiros
        lblCantTickets.Text = cantTickets
        lblTotalCobrado.Text = FormatCurrency(cobrado, 2)
        lblTotalRetiros.Text = FormatCurrency(Retirado, 2)
        lblTotalCaja.Text = FormatCurrency((FondoCaja + cobrado) - Retirado, 2)
    End Sub

    Private Sub DetalleCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargando.Show()
        Cargando.MonoFlat_Label1.Text = "Consultando"
        Cargando.TopMost = True
        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Cargando.Close()
    End Sub



    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        RealizarRetrio.ShowDialog()
        Cargando.Show()
        Cargando.MonoFlat_Label1.Text = "Consultando"
        Cargando.TopMost = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub
End Class