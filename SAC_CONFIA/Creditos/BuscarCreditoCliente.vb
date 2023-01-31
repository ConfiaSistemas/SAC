Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class BuscarCreditoCliente

    Public tipoCredito As String
    Public dataCredito As DataTable

    Private Sub BuscarCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtimpuestos.ScrollBars = ScrollBars.None

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        dtimpuestos.DataSource = dataCredito

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        dtimpuestos.ScrollBars = ScrollBars.Both

    End Sub

    Private Sub txtusuario_OnValueChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub dtimpuestos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellDoubleClick
        inicio.txtid.Text = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(0).Value
        inicio.estadoCredito = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(5).Value
        Me.Invoke(Sub()
                      inicio.dtimpuestos.Rows.Clear()
                      inicio.dtimpuestos.ScrollBars = ScrollBars.None
                      inicio.txtid.Enabled = False
                      Cargando.Show()
                      Cargando.MonoFlat_Label1.Text = "Buscando datos"
                      inicio.BackgroundWorker1.RunWorkerAsync()
                  End Sub)
        Me.Close()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub dtimpuestos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellContentClick

    End Sub
End Class