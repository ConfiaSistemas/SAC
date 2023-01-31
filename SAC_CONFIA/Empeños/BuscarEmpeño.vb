Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class BuscarEmpeño

    Public tipoCredito As String
    Private Sub BuscarCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtimpuestos.ScrollBars = ScrollBars.None
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        iniciarconexionempresa()
        Dim comandoCreditos As SqlCommand
        Dim consultaCreditos As String
        Dim readerCreditos As SqlDataReader
        'If tipoCredito = "Normal" Then
        consultaCreditos = "Select id,format(fechaEntrega,'dd/MM/yyyy') as fechaEntrega,nombre,montoprestado,Plazorefrendo from Empeños order by nombre asc"
        ' Else
        'consultaCreditos = "Select id,format(FechaConvenio,'dd/MM/yyyy') as fechaEntrega,nombre,TotalDeuda,Plazo from legales order by nombre asc"
        'End If

        comandoCreditos = New SqlCommand
        comandoCreditos.Connection = conexionempresa
        comandoCreditos.CommandText = consultaCreditos
        readerCreditos = comandoCreditos.ExecuteReader
        While readerCreditos.Read
            'If tipoCredito = "Normal" Then
            dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("fechaEntrega"), readerCreditos("Nombre"), readerCreditos("MontoPrestado"), readerCreditos("Plazorefrendo"))

            ' Else
            ' dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("fechaEntrega"), readerCreditos("Nombre"), readerCreditos("TotalDeuda"), readerCreditos("Plazo"))
            'End If
        End While
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        dtimpuestos.ScrollBars = ScrollBars.Both
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
            'If tipoCredito = "Normal" Then
            consultaCreditos = "Select id,format(fechaEntrega,'dd/MM/yyyy') as fechaEntrega,nombre,montoPrestado,Plazo from Empeños where nombre like '%" & txtNombre.Text & "%' order by nombre asc"
            ' Else
            ' consultaCreditos = "Select id,format(FechaConvenio,'dd/MM/yyyy') as fechaEntrega,nombre,totaldeuda,Plazo from legales where nombre like '%" & txtNombre.Text & "%' order by nombre asc"
            'End If
            'consultaCreditos = "Select id,format(fechaEntrega,'dd/MM/yyyy') as fechaEntrega,nombre,monto,Plazo from credito where nombre like '%" & txtNombre.Text & "%'"
            comandoCreditos = New SqlCommand
            comandoCreditos.Connection = conexionempresa
            comandoCreditos.CommandText = consultaCreditos
            readerCreditos = comandoCreditos.ExecuteReader
            While readerCreditos.Read
                ' If tipoCredito = "Normal" Then
                dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("fechaEntrega"), readerCreditos("Nombre"), readerCreditos("MontoPrestado"), readerCreditos("Plazo"))
                'Else

                ' dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("fechaEntrega"), readerCreditos("Nombre"), readerCreditos("totaldeuda"), readerCreditos("Plazo"))
                ' End If

            End While
        End If
    End Sub

    Private Sub dtimpuestos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellContentClick

    End Sub

    Private Sub dtimpuestos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellContentDoubleClick
        CobroEmpeño.txtid.Text = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(0).Value
        Me.Close()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub
End Class