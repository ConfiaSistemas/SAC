Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class ComisionEnganche
    Public idcredito As String
    Public nombreCredito As String
    Public cp As String
    Public montoCredito As Double
    Public Total As Double
    Public Enganche As Double
    Public comisionCobrada As Boolean = False
    Public EngancheCobrado As Boolean = False
    Public interesCredito As Double
    Dim nCargando As Cargando
    Private Sub btnNormal_Click(sender As Object, e As EventArgs) Handles btnComision.Click
        Ticket_Comision.idCreditoRecibo = idcredito
        Ticket_Comision.nombre_credito = nombreCredito
        Ticket_Comision.cp = cp
        Ticket_Comision.montocredito = montoCredito
        Ticket_Comision.total = Total
        Ticket_Comision.ShowDialog()

    End Sub

    Private Sub BackgroundCobrados_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundCobrados.DoWork
        iniciarconexionempresa()
        Dim comandoCobrados As SqlCommand
        Dim consultaCobrados As String
        Dim readerCobrados As SqlDataReader
        consultaCobrados = "select isnull((select count(id) from ticket where idCredito =" & idcredito & " and TipoDoc = '2'),0) as Cobrado,isnull((select count(id) from ticket where idCredito = " & idcredito & " and TipoDoc = (select id from tipodoc where nombre='Enganche Motocicleta')),0) as EngancheCobrado,isnull((select interes from credito where id='" & idcredito & "'),0) as interesCredito"
        comandoCobrados = New SqlCommand
        comandoCobrados.Connection = conexionempresa
        comandoCobrados.CommandText = consultaCobrados
        readerCobrados = comandoCobrados.ExecuteReader
        If readerCobrados.HasRows Then
            While readerCobrados.Read
                comisionCobrada = readerCobrados("cobrado")
                EngancheCobrado = readerCobrados("EngancheCobrado")
                interesCredito = readerCobrados("interescredito")
            End While
        End If

    End Sub

    Private Sub BackgroundCobrados_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundCobrados.RunWorkerCompleted
        If comisionCobrada Then
            btnComision.Enabled = False
        Else
            btnComision.Enabled = True
        End If

        If EngancheCobrado Then
            btnEnganche.Enabled = False
        Else
            btnEnganche.Enabled = True
        End If
        nCargando.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub btnEnganche_Click(sender As Object, e As EventArgs) Handles btnEnganche.Click
        If CanCobrar Then

            Dim frmTicket As New Ticket_impresion
            frmTicket.idCreditoRecibo = idcredito
            Dim tipodoc As Integer = ObtenerTipoDoc("Enganche Motocicleta")
            Dim nombredoc As String
            nombredoc = GetNombreDoc(tipoDoc)


            frmTicket.total = Enganche



            frmTicket.montocredito = montoCredito
            frmTicket.pcmil = interesCredito
            frmTicket.cp = cp
            frmTicket.tipoDoc = tipodoc
            ' frmTicket.convenio = convenioCredito
            ' frmTicket.cpConvenio = cpConvenio
            'frmTicket.montoConvenio = MontoConvenio
            frmTicket.nombre_credito = nombreCredito
            ' frmTicket.insoluto = Insoluto

            frmTicket.Show()
            frmTicket.TopMost = True
        Else
            MessageBox.Show("Has alcanzado el límite de dinero en caja, realiza un retiro para poder seguir cobrando")
        End If
    End Sub

    Private Sub ComisionEnganche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nCargando = New Cargando
        nCargando.Show()
        nCargando.MonoFlat_Label1.Text = "Cargando datos"
        BackgroundCobrados.RunWorkerAsync()
    End Sub
End Class