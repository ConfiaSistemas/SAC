Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class BuscarCliente
    Public tipoCredito As String
    Private Sub BuscarCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtimpuestos.ScrollBars = ScrollBars.None
        txtNombre.Enabled = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        iniciarconexionempresa()
        Dim comandoCreditos As SqlCommand
        Dim consultaCreditos As String
        Dim readerCreditos As SqlDataReader

        consultaCreditos = "select * from (Select id,concat(nombre,' ',apellidopaterno, ' ',apellidomaterno) as Nombre,idstr from clientes)cli order by nombre asc"


        comandoCreditos = New SqlCommand
        comandoCreditos.Connection = conexionempresa
        comandoCreditos.CommandText = consultaCreditos
        readerCreditos = comandoCreditos.ExecuteReader
        While readerCreditos.Read

            dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("nombre"), readerCreditos("idstr"))


        End While
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        dtimpuestos.ScrollBars = ScrollBars.Both
        txtNombre.Enabled = True
        txtNombre.Focus()
    End Sub

    Private Sub txtusuario_OnValueChanged(sender As Object, e As EventArgs) Handles txtNombre.OnValueChanged

    End Sub

    Private Sub txtusuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtimpuestos.Rows.Clear()
            iniciarconexionempresa()
            Dim comandoCreditos As SqlCommand
            Dim consultaCreditos As String
            Dim readerCreditos As SqlDataReader

            consultaCreditos = "select * from (Select id,concat(nombre,' ',apellidopaterno, ' ',apellidomaterno) as Nombre,idstr from clientes)cli where nombre like '%" & txtNombre.Text & "%' order by nombre asc"

            'consultaCreditos = "Select id,format(fechaEntrega,'dd/MM/yyyy') as fechaEntrega,nombre,monto,Plazo from credito where nombre like '%" & txtNombre.Text & "%'"
            comandoCreditos = New SqlCommand
            comandoCreditos.Connection = conexionempresa
            comandoCreditos.CommandText = consultaCreditos
            readerCreditos = comandoCreditos.ExecuteReader
            While readerCreditos.Read

                dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("nombre"), readerCreditos("idstr"))


            End While
        End If
    End Sub

    Private Sub dtimpuestos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellDoubleClick
        '   inicio.txtid.Text = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(0).Value
        inicio.txtidCliente.Text = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(2).Value
        Me.Invoke(Sub()
                      inicio.dtimpuestos.Rows.Clear()
                      inicio.dtimpuestos.ScrollBars = ScrollBars.None
                      inicio.txtid.Enabled = False
                      Cargando.Show()
                      Cargando.MonoFlat_Label1.Text = "Buscando datos"
                      inicio.BackgroundCreditoCliente.RunWorkerAsync()
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