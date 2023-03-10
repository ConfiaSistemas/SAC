Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class BuscarCredito
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
        If tipoCredito = "Normal" Then
            consultaCreditos = "Select id,format(fechaEntrega,'dd/MM/yyyy') as fechaEntrega,nombre,monto,Plazo,Estado from credito where estado not in('T','E') order by nombre, id"
        Else
            consultaCreditos = "Select id,format(FechaConvenio,'dd/MM/yyyy') as fechaEntrega,nombre,TotalDeuda,Plazo,Estado from legales where estado not in('T','E') order by nombre, id"
        End If

        comandoCreditos = New SqlCommand
        comandoCreditos.Connection = conexionempresa
        comandoCreditos.CommandText = consultaCreditos
        readerCreditos = comandoCreditos.ExecuteReader
        While readerCreditos.Read
            If tipoCredito = "Normal" Then
                dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("fechaEntrega"), readerCreditos("Nombre"), readerCreditos("Monto"), readerCreditos("Plazo"), readerCreditos("Estado"))

            Else
                dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("fechaEntrega"), readerCreditos("Nombre"), readerCreditos("TotalDeuda"), readerCreditos("Plazo"), readerCreditos("Estado"))
            End If
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
            If tipoCredito = "Normal" Then
                consultaCreditos = "Select id,format(fechaEntrega,'dd/MM/yyyy') as fechaEntrega,nombre,monto,Plazo,Estado from credito where nombre like '%" & txtNombre.Text & "%' and estado not in('T','E') order by nombre, id"
            Else
                consultaCreditos = "Select id,format(FechaConvenio,'dd/MM/yyyy') as fechaEntrega,nombre,totaldeuda,Plazo,Estado from legales where nombre like '%" & txtNombre.Text & "%' and estado not in('T','E') order by nombre, id"
            End If
            'consultaCreditos = "Select id,format(fechaEntrega,'dd/MM/yyyy') as fechaEntrega,nombre,monto,Plazo from credito where nombre like '%" & txtNombre.Text & "%'"
            comandoCreditos = New SqlCommand
            comandoCreditos.Connection = conexionempresa
            comandoCreditos.CommandText = consultaCreditos
            readerCreditos = comandoCreditos.ExecuteReader
            While readerCreditos.Read
                If tipoCredito = "Normal" Then
                    dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("fechaEntrega"), readerCreditos("Nombre"), readerCreditos("Monto"), readerCreditos("Plazo"), readerCreditos("Estado"))
                Else

                    dtimpuestos.Rows.Add(readerCreditos("id"), readerCreditos("fechaEntrega"), readerCreditos("Nombre"), readerCreditos("totaldeuda"), readerCreditos("Plazo"), readerCreditos("Estado"))
                End If

            End While
        End If
    End Sub

    Private Sub dtimpuestos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtimpuestos.CellDoubleClick
        inicio.txtid.Text = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(0).Value
        inicio.txtidCliente.Text = dtimpuestos.Rows(dtimpuestos.CurrentRow.Index).Cells(0).Value
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