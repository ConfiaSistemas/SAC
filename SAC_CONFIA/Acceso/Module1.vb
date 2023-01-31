Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Windows

Module Module1
    Public strusuarios As String
    Public cn As String
    Public cnempresa As String
    Public ipser As String
    Public bdser As String
    Public ipconsultas As String
    Public bdconsultas As String
    Public nmusr As String
    Public grpusr As String
    Public nm_completeusr As String
    Public addrusr As String
    Public tlfusr As String
    Public imgstrusr As String
    Public bitmapBytes As Byte()
    Public idusr As String
    Public streamimgusr As System.IO.MemoryStream
    Public bitmapimgusr As Bitmap
    Public conexion As OleDbConnection
    Public conexionempresa As SqlConnection
    Public m_PanStartPoint As New Point
    Public bloquear As Boolean = False
    Public NombreEmpresa As String
    Public RFCEmpresa As String
    Public CalleEmpresa As String
    Public NumeroEmpresa As String
    Public ColEmpresa As String
    Public CiudadEmpresa As String
    Public EstadoEmpresa As String
    Public CPEmpresa As String
    Public nombreAmostrar As String
    Public idEmpresa As String
    Public noCaja As String
    Public Impresora As String
    Public dataDocs As DataSet
    Public adapterDocs As SqlDataAdapter
    Public FondoCaja As Double
    Public LimiteCaja As Double
    Public cobrado As Double
    Public usuarioActivo As Boolean
    Public vistapreviaTicket As Boolean = False
    Public cantTickets As Double
    Public cantRetiros As Double
    Public Retirado As Double
    Public totalCaja As Double
    Public CanCobrar As Boolean
    Public idGrp As Integer
    Public adapterPermisos As OleDb.OleDbDataAdapter
    Public dataPermisos As DataTable
    Public TipoEquipo As String
    Public Actualizar As Boolean
    Public idSesion As String
    Private WithEvents TestWorker As System.ComponentModel.BackgroundWorker
    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (
ByVal process As IntPtr,
ByVal minimumWorkingSetSize As Integer,
ByVal maximumWorkingSetSize As Integer) As Integer
    Private Declare Function CreateEllipticRgn Lib "gdi32" (ByVal X1 As Long, ByVal Y1 As Long, ByVal X2 As Long, ByVal Y2 As Long) As Long
    Private Declare Function SetWindowRgn Lib "user32" (ByVal hWnd As Long, ByVal hRgn As Long, ByVal bRedraw As Boolean) As Long
    Public Sub iniciarconexion()
        cn = "Provider=sqloledb;" &
                     "Data Source=  " & ipser & "\confia;" &
                     "Initial Catalog=" & bdser & ";" &
                     "User Id=sa;Password=BSi5t3Ma$CFAD;"
        conexion = New OleDbConnection(cn)
            conexion.Open()
    End Sub
    Public Sub iniciarconexionempresa()
        cnempresa = "Data Source=  " & ipconsultas & "\confia;" &
                     "Initial Catalog=" & bdconsultas & ";" &
                     "User Id=sa;Password=BSi5t3Ma$CFAD;MultipleActiveResultSets=true"
        conexionempresa = New SqlConnection(cnempresa)
        conexionempresa.Open()
    End Sub

    Public Sub cargarperfil()
        Dim strconf As String = ("select x1.nm,x2.nm as grp,x1.nm_complete,x1.addr,x1.tlf,x1.imgstr,x1.activo,x1.grp as idgrp from usr x1 inner join grp x2 on x1.grp = x2.id where x1.idusr = '" & idusr & "'")
        Dim connexio = New OleDbConnection(cn)
        Dim ejec2 = New OleDbCommand(strconf)
        ejec2.Connection = connexio
        connexio.Open()
        Dim myreaderconf As OleDbDataReader = ejec2.ExecuteReader()
        While myreaderconf.Read()
            nmusr = Convert.ToString(myreaderconf("nm"))
            grpusr = Convert.ToString(myreaderconf("grp"))
            nm_completeusr = Convert.ToString(myreaderconf("nm_complete"))
            addrusr = Convert.ToString(myreaderconf("addr"))
            tlfusr = Convert.ToString(myreaderconf("tlf"))
            imgstrusr = Convert.ToString(myreaderconf("imgstr"))
            usuarioActivo = myreaderconf("activo")
            idGrp = myreaderconf("idgrp")
        End While
        If imgstrusr <> "" Then
            bitmapBytes = Convert.FromBase64String(imgstrusr)
            streamimgusr = New MemoryStream(bitmapBytes, 0, bitmapBytes.Length)
            streamimgusr.Write(bitmapBytes, 0, bitmapBytes.Length)
            bitmapimgusr = New Bitmap(streamimgusr)
        End If

        Dim consultaPermisos As String
        consultaPermisos = "Select * from permisosGrupo where idgrupo = '" & idGrp & "'"
        adapterPermisos = New OleDbDataAdapter(consultaPermisos, connexio)
        dataPermisos = New DataTable
        adapterPermisos.Fill(dataPermisos)

        connexio.Close()

    End Sub


    Public Sub RunWorkerAsync()
        TestWorker.RunWorkerAsync()
    End Sub
    Public Sub TestWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles TestWorker.DoWork
        'MessageBox.Show("haciendolo")
        'cargarusuarios()
    End Sub

    Public Sub mousedownevent(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        'Capture the initial point 
        m_PanStartPoint = New Point(e.X, e.Y)

    End Sub
    Public Sub mouseupevent(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        'Capture the initial point 
        bloquear = False


    End Sub
    Public Sub MouseMoveevent(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        'Verify Left Button is pressed while the mouse is moving
        If e.Button = Forms.MouseButtons.Left Then
            bloquear = True
            'Here we get the change in coordinates.
            Dim DeltaX As Integer = (m_PanStartPoint.X - e.X)
            Dim DeltaY As Integer = (m_PanStartPoint.Y - e.Y)

            'Then we set the new autoscroll position.
            'ALWAYS pass positive integers to the panels autoScrollPosition method
            'usuarios.FlowLayoutPanel1.AutoScrollPosition =
            ' New Drawing.Point((DeltaX - usuarios.FlowLayoutPanel1.AutoScrollPosition.X),
            ' (DeltaY - usuarios.FlowLayoutPanel1.AutoScrollPosition.Y))

        End If

    End Sub
    Public Sub clickevent(ByVal sender As Object, ByVal e As EventArgs)

        ' Dim label = DirectCast(sender, Label)
        If bloquear = False Then
            ' Editar_Usuario.idusuario = sender.name

            ' Editar_Usuario.Show()
        End If



    End Sub

    Private Sub TestWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles TestWorker.RunWorkerCompleted
        MessageBox.Show("listo")

    End Sub
    Public Sub Docs()
        iniciarconexionempresa()
        Dim consultaDocs As String
        consultaDocs = "select * from tipodoc"
        adapterDocs = New SqlDataAdapter(consultaDocs, conexionempresa)
        dataDocs = New DataSet
        adapterDocs.Fill(dataDocs)
    End Sub


    Public Function CargarCaja() As Boolean

        Try
            iniciarconexionempresa()
            Dim comandoCaja As SqlCommand
            Dim consultaCaja As String
            Dim readerCaja As SqlDataReader

            consultaCaja = "Select fondo,limite from cajasSucursal where Nocaja = '" & noCaja & "'"
            comandoCaja = New SqlCommand
            comandoCaja.Connection = conexionempresa
            comandoCaja.CommandText = consultaCaja
            readerCaja = comandoCaja.ExecuteReader
            If readerCaja.HasRows Then
                While readerCaja.Read
                    FondoCaja = readerCaja("fondo")
                    LimiteCaja = readerCaja("limite")
                End While
                Return True
            Else
                FondoCaja = 0
                LimiteCaja = 0
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function GetNombreDoc(id As Integer) As String
        Dim nombreDoc As String
        For Each row As DataRow In dataDocs.Tables(0).Rows
            If row("id").ToString = id Then
                nombreDoc = row("Nombre").ToString
                Exit For
            End If

        Next
        Return nombreDoc
    End Function
    Public Function ObtenerTipoDoc(nombredoc As String) As Integer
        Dim tipoDoc As Integer
        For Each row As DataRow In dataDocs.Tables(0).Rows
            If row("Nombre").ToString = nombredoc Then
                tipoDoc = Val(row("id").ToString)
                Exit For
            End If

        Next
        Return tipoDoc
    End Function
    Public Sub FlushMemory()
        Try
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function PuedeCobrar() As Boolean
        iniciarconexionempresa()
        Dim comandoCobrar As SqlCommand
        Dim consultaCobrar As String
        Dim fechainsercionhasta As String
        Dim readerCobrado As SqlDataReader
        fechainsercionhasta = Now.Date

        Dim fechasqlhasta As Date
        fechasqlhasta = fechainsercionhasta
        fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
        consultaCobrar = "select sum(total) as cobrado,count(ticket.id) as cantTickets from ticket inner join tipodoc on ticket.tipodoc = tipodoc.id where fecha >= '" & fechainsercionhasta & "' and fecha <= '" & fechainsercionhasta & "' and tipodoc.afectaCaja = 1 and caja = '" & noCaja & "' and ticket.estado = 'A'"
        comandoCobrar = New SqlCommand
        comandoCobrar.Connection = conexionempresa
        comandoCobrar.CommandText = consultaCobrar
        readerCobrado = comandoCobrar.ExecuteReader
        If readerCobrado.HasRows Then
            While readerCobrado.Read
                If IsDBNull(readerCobrado("Cobrado")) Then
                    cobrado = 0
                Else
                    cobrado = readerCobrado("cobrado")
                End If
                If IsDBNull(readerCobrado("cantTickets")) Then
                    cantTickets = 0
                Else
                    cantTickets = readerCobrado("cantTickets")
                End If

            End While
        Else
            cobrado = 0
            cantTickets = 0
        End If
        ' If IsDBNull(comandoCobrar.ExecuteScalar) Then
        'cobrado = 0
        'Else
        'cobrado = comandoCobrar.ExecuteScalar

        'End If


        Dim comandoRetirado As SqlCommand
        Dim consultaRetirado As String
        Dim readerRetirado As SqlDataReader
        consultaRetirado = "select sum(Monto) as Retiros, count(id) as cantRetiros from Retiros where  fecha >= '" & fechainsercionhasta & "' and fecha <= '" & fechainsercionhasta & "' and caja = '" & noCaja & "' "
        comandoRetirado = New SqlCommand
        comandoRetirado.Connection = conexionempresa
        comandoRetirado.CommandText = consultaRetirado
        readerRetirado = comandoRetirado.ExecuteReader
        If readerRetirado.HasRows Then
            While readerRetirado.Read
                If IsDBNull(readerRetirado("Retiros")) Then
                    Retirado = 0
                Else

                    Retirado = readerRetirado("Retiros")
                End If
                If IsDBNull(readerRetirado("cantRetiros")) Then
                    cantRetiros = 0
                Else
                    cantRetiros = readerRetirado("cantRetiros")
                End If

            End While
        Else
            Retirado = 0
            cantRetiros = 0
        End If
        'If IsDBNull(comandoRetirado.ExecuteScalar) Then
        'Retirado = 0
        'Else
        'Retirado = comandoRetirado.ExecuteScalar
        'End If

        totalCaja = cobrado - Retirado

        If totalCaja >= LimiteCaja Then

            Return False
        Else
            Return True
        End If

    End Function

    Public Function AfectaCaja(nombredoc As String) As Boolean
        Dim afectacion As Boolean
        For Each row As DataRow In dataDocs.Tables(0).Rows
            If row("Nombre").ToString = nombredoc Then
                afectacion = Val(row("AfectaCaja").ToString)
                Exit For
            End If

        Next
        Return afectacion
    End Function

    Public Function reimprimirTicket(noTicket As Integer) As Boolean
        '   Try
        Dim NumeroLetra As New NumLetra
        Dim comandorecibo As SqlCommand
        Dim consultarecibo As String
        Dim readerrecibo As SqlDataReader
        Dim fechastring As String
        Dim fecha As Date
        Dim horastring As String
        Dim idrecibo As Integer
        Dim total As Double
        Dim idcredito As Double
        Dim recibido As Double
        Dim cambio As Double
        Dim intereses As Double
        Dim pagonormal As Double
        Dim nombreCredito As String
        Dim pcmil As Double
        Dim monto As Double
        Dim cp As Integer
        Dim concepto As String
        Dim subtotal As Double
        Dim descuento As Double
        Dim a As DetallePago
        Dim pagoindividual As Double
        Dim array As ArrayList = New ArrayList
        Dim tipodoc As Integer
        Dim tipodocstring As String
        Dim cpConvenio As Integer
        Dim montoConvenio As Double
        Dim NumeroCaja As Integer
        Dim nombreCajero As String
        iniciarconexionempresa()

        Dim comandoTipoDoc As SqlCommand
        Dim consultaTipoDoc As String
        Dim tipoDocRecibo As Integer

        comandoTipoDoc = New SqlCommand
        consultaTipoDoc = "Select tipodoc from ticket where id = '" & noTicket & "'"
        comandoTipoDoc.Connection = conexionempresa
        comandoTipoDoc.CommandText = consultaTipoDoc
        tipoDocRecibo = comandoTipoDoc.ExecuteScalar

        ' Select Case tipoDocRecibo
        'Case 1
        'consultarecibo = "select recibos.IdRecibo,recibos.Id_Credito,recibos.total,recibos.Recibido,recibos.Cambio,recibos.fecha,recibos.hora,recibos.PagoNormal,recibos.Intereses,ce.nombre,ce.PCMil,ce.monto,Productos.CP,recibos.tipodoc as Tipo, recibos.concepto, tipodoc.nombre as NombreDoc,recibos.Caja  from recibos inner join CreditosExt CE on recibos.Id_Credito = ce.id_credito inner join productos on ce.id_producto = Productos.ID inner join tipodoc on recibos.tipodoc = tipodoc.id where IdRecibo = '" & noTicket & "'"

        ' Case 4
        ' consultarecibo = "select recibos.IdRecibo,recibos.Id_Credito,recibos.total,recibos.Recibido,recibos.Cambio,recibos.fecha,recibos.hora,recibos.PagoNormal,recibos.Intereses,ce.nombre,ce.PCMil,ce.monto,Productos.CP,recibos.tipodoc as Tipo, recibos.concepto, tipodoc.nombre as NombreDoc,convenios.CanPagos, convenios.TotalDeuda,recibos.Caja  from recibos inner join convenios on recibos.Id_Credito = Convenios.id inner join creditosext ce on Convenios.id_credito = ce.id_credito inner join productos on ce.id_producto = Productos.ID inner join tipodoc on recibos.tipodoc = tipodoc.id where IdRecibo = '" & noTicket & "'"
        ' Case Else
        ' consultarecibo = "select recibos.IdRecibo,recibos.Id_Credito,recibos.total,recibos.Recibido,recibos.Cambio,recibos.fecha,recibos.hora,recibos.PagoNormal,recibos.Intereses,ce.nombre,ce.PCMil,ce.monto,Productos.CP,recibos.tipodoc as Tipo, recibos.concepto, tipodoc.nombre as NombreDoc,recibos.Caja  from recibos inner join CreditosExt CE on recibos.Id_Credito = ce.id_credito inner join productos on ce.id_producto = Productos.ID inner join tipodoc on recibos.tipodoc = tipodoc.id where IdRecibo = '" & noTicket & "'"

        'End Select


        Select Case GetNombreDoc(tipoDocRecibo)
            Case "Pago"
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,ce.Interes,ce.monto,TiposDeCredito.Plazo,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario,ce.pagoindividual  from Ticket inner join Credito CE on Ticket.IdCredito = ce.id inner join TiposDeCredito on ce.Tipo = TiposDeCredito.ID inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"

            Case "Convenio"

                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario  from Ticket inner join conveniossac CS on Ticket.IdCredito = CS.id  inner join tipodoc on Ticket.tipodoc = tipodoc.id INNER join credito ce on cs.idcredito = ce.id where Ticket.id = '" & noTicket & "'"

            Case "Apertura"
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,ce.Interes,ce.monto,TiposDeCredito.Plazo,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario,ce.pagoindividual  from Ticket inner join Credito CE on Ticket.IdCredito = ce.id inner join TiposDeCredito on ce.Tipo = TiposDeCredito.ID inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"

            Case "Enganche Motocicleta"
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,ce.Interes,ce.monto,TiposDeCredito.Plazo,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario,ce.pagoindividual  from Ticket inner join Credito CE on Ticket.IdCredito = ce.id inner join TiposDeCredito on ce.Tipo = TiposDeCredito.ID inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"

            Case "Extra"
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario  from Ticket  inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"

            Case "Legal"
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,ce.MontoConvenio,ce.plazo,ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario  from Ticket inner join Legales CE on Ticket.IdCredito = ce.id inner join TiposDeCredito on ce.Tipo = TiposDeCredito.ID inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"
            Case "Refrendo", "Comisión por avalúo", "Desempeño"
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,ce.Interesdiario,ce.montoprestado,ce.Plazorefrendo,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario,ce.montorefrendo  from Ticket inner join empeños CE on Ticket.IdCredito = ce.id  inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"

            Case "Reestructura"
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario  from Ticket inner join ReestructurasSAC RS on Ticket.IdCredito = RS.id  inner join tipodoc on Ticket.tipodoc = tipodoc.id INNER join credito ce on RS.idcredito = ce.id where Ticket.id = '" & noTicket & "'"
            Case "Promesa de pago"
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,ce.Interes,ce.monto,TiposDeCredito.Plazo,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario,ce.pagoindividual  from Ticket inner join Credito CE on Ticket.IdCredito = ce.id inner join TiposDeCredito on ce.Tipo = TiposDeCredito.ID inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"

            Case Else
                consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,ce.Interes,ce.monto,TiposDeCredito.Plazo,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario,ce.pagoindividual  from Ticket inner join Credito CE on Ticket.IdCredito = ce.id inner join TiposDeCredito on ce.Tipo = TiposDeCredito.ID inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"

        End Select

        ' consultarecibo = "select Ticket.Id,Ticket.IdCredito,Ticket.total,Ticket.Recibido,Ticket.Cambio,Ticket.SubTotal,Ticket.Descuento,Ticket.fecha,Ticket.hora,Ticket.PagoNormal,Ticket.Intereses,ce.nombre,ce.Interes,ce.monto,TiposDeCredito.Plazo,Ticket.tipodoc as Tipo, Ticket.concepto, tipodoc.nombre as NombreDoc,Ticket.Caja,Ticket.NombreUsuario,ce.pagoindividual  from Ticket inner join Credito CE on Ticket.IdCredito = ce.id inner join TiposDeCredito on ce.Tipo = TiposDeCredito.ID inner join tipodoc on Ticket.tipodoc = tipodoc.id where Ticket.id = '" & noTicket & "'"
        '  consultarecibo = "select recibos.IdRecibo,recibos.Id_Credito,recibos.total,recibos.Recibido,recibos.Cambio,recibos.fecha,recibos.hora,recibos.PagoNormal,recibos.Intereses,ce.nombre,ce.PCMil,ce.monto,Productos.CP,recibos.tipodoc as Tipo, recibos.concepto, tipodoc.nombre as NombreDoc  from recibos inner join CreditosExt CE on recibos.Id_Credito = ce.id_credito inner join productos on ce.id_producto = Productos.ID inner join tipodoc on recibos.tipodoc = tipodoc.id where IdRecibo = '" & noTicket & "'"
        comandorecibo = New SqlCommand
        comandorecibo.Connection = conexionempresa
        comandorecibo.CommandText = consultarecibo
        readerrecibo = comandorecibo.ExecuteReader
        Select Case GetNombreDoc(tipoDocRecibo)
            Case "Pago"
                While readerrecibo.Read
                    idrecibo = readerrecibo("id")
                    idcredito = readerrecibo("idcredito")
                    total = readerrecibo("total")
                    recibido = readerrecibo("recibido")
                    cambio = readerrecibo("cambio")
                    fechastring = readerrecibo("fecha")
                    horastring = readerrecibo("hora").ToString
                    pagonormal = readerrecibo("pagonormal")
                    intereses = readerrecibo("intereses")
                    nombreCredito = readerrecibo("nombre")
                    pcmil = readerrecibo("interes")
                    monto = readerrecibo("monto")
                    cp = readerrecibo("plazo")
                    tipodoc = readerrecibo("Tipo")
                    concepto = readerrecibo("concepto")
                    tipodocstring = readerrecibo("NombreDoc")
                    NumeroCaja = readerrecibo("Caja")
                    subtotal = readerrecibo("subtotal")
                    descuento = readerrecibo("descuento")
                    nombreCajero = readerrecibo("NombreUsuario")
                    pagoindividual = readerrecibo("pagoindividual")
                End While
            Case "Convenio"
                While readerrecibo.Read

                    idrecibo = readerrecibo("id")
                    idcredito = readerrecibo("idcredito")
                    total = readerrecibo("total")
                    recibido = readerrecibo("recibido")
                    cambio = readerrecibo("cambio")
                    fechastring = readerrecibo("fecha")
                    horastring = readerrecibo("hora").ToString
                    pagonormal = readerrecibo("pagonormal")
                    intereses = readerrecibo("intereses")
                    nombreCredito = readerrecibo("nombre")
                    ' pcmil = readerrecibo("pcmil")
                    'monto = readerrecibo("monto")
                    ' cp = readerrecibo("cp")
                    tipodoc = readerrecibo("Tipo")
                    concepto = readerrecibo("concepto")
                    tipodocstring = readerrecibo("NombreDoc")
                    ' cpConvenio = readerrecibo("CanPagos")
                    'montoConvenio = readerrecibo("totaldeuda")
                    nombreCajero = readerrecibo("NombreUsuario")
                    NumeroCaja = readerrecibo("Caja")
                End While
            Case "Reestructura"
                While readerrecibo.Read

                    idrecibo = readerrecibo("id")
                    idcredito = readerrecibo("idcredito")
                    total = readerrecibo("total")
                    recibido = readerrecibo("recibido")
                    cambio = readerrecibo("cambio")
                    fechastring = readerrecibo("fecha")
                    horastring = readerrecibo("hora").ToString
                    pagonormal = readerrecibo("pagonormal")
                    intereses = readerrecibo("intereses")
                    nombreCredito = readerrecibo("nombre")
                    ' pcmil = readerrecibo("pcmil")
                    'monto = readerrecibo("monto")
                    ' cp = readerrecibo("cp")
                    tipodoc = readerrecibo("Tipo")
                    concepto = readerrecibo("concepto")
                    tipodocstring = readerrecibo("NombreDoc")
                    ' cpConvenio = readerrecibo("CanPagos")
                    'montoConvenio = readerrecibo("totaldeuda")
                    nombreCajero = readerrecibo("NombreUsuario")
                    NumeroCaja = readerrecibo("Caja")
                End While
            Case "Extra"
                While readerrecibo.Read
                    idrecibo = readerrecibo("id")
                    'idcredito = readerrecibo("idcredito")
                    total = readerrecibo("total")
                    recibido = readerrecibo("recibido")
                    cambio = readerrecibo("cambio")
                    fechastring = readerrecibo("fecha")
                    horastring = readerrecibo("hora").ToString
                    pagonormal = readerrecibo("pagonormal")
                    intereses = readerrecibo("intereses")
                    'nombreCredito = readerrecibo("nombre")
                    ' pcmil = readerrecibo("interes")
                    'monto = readerrecibo("monto")
                    'cp = readerrecibo("plazo")
                    tipodoc = readerrecibo("Tipo")
                    concepto = readerrecibo("concepto")
                    tipodocstring = readerrecibo("NombreDoc")
                    NumeroCaja = readerrecibo("Caja")
                    subtotal = readerrecibo("subtotal")
                    descuento = readerrecibo("descuento")
                    nombreCajero = readerrecibo("NombreUsuario")
                End While
            Case "Legal"
                While readerrecibo.Read
                    idrecibo = readerrecibo("id")
                    idcredito = readerrecibo("idcredito")
                    total = readerrecibo("total")
                    recibido = readerrecibo("recibido")
                    cambio = readerrecibo("cambio")
                    fechastring = readerrecibo("fecha")
                    horastring = readerrecibo("hora").ToString
                    pagonormal = readerrecibo("pagonormal")
                    intereses = readerrecibo("intereses")
                    nombreCredito = readerrecibo("nombre")
                    ' pcmil = readerrecibo("interes")
                    monto = readerrecibo("montoConvenio")
                    cp = readerrecibo("plazo")
                    tipodoc = readerrecibo("Tipo")
                    concepto = readerrecibo("concepto")
                    tipodocstring = readerrecibo("NombreDoc")
                    NumeroCaja = readerrecibo("Caja")
                    subtotal = readerrecibo("subtotal")
                    descuento = readerrecibo("descuento")
                    nombreCajero = readerrecibo("NombreUsuario")
                End While
            Case "Refrendo", "Comisión por avalúo", "Desempeño"
                While readerrecibo.Read
                    idrecibo = readerrecibo("id")
                    idcredito = readerrecibo("idcredito")
                    total = readerrecibo("total")
                    recibido = readerrecibo("recibido")
                    cambio = readerrecibo("cambio")
                    fechastring = readerrecibo("fecha")
                    horastring = readerrecibo("hora").ToString
                    pagonormal = readerrecibo("pagonormal")
                    intereses = readerrecibo("intereses")
                    nombreCredito = readerrecibo("nombre")
                    pcmil = readerrecibo("interesdiario")
                    monto = readerrecibo("montoPrestado")
                    cp = readerrecibo("plazoRefrendo")
                    tipodoc = readerrecibo("Tipo")
                    concepto = readerrecibo("concepto")
                    tipodocstring = readerrecibo("NombreDoc")
                    NumeroCaja = readerrecibo("Caja")
                    subtotal = readerrecibo("subtotal")
                    descuento = readerrecibo("descuento")
                    nombreCajero = readerrecibo("NombreUsuario")
                End While
            Case "Promesa de pago"
                While readerrecibo.Read
                    idrecibo = readerrecibo("id")
                    idcredito = readerrecibo("idcredito")
                    total = readerrecibo("total")
                    recibido = readerrecibo("recibido")
                    cambio = readerrecibo("cambio")
                    fechastring = readerrecibo("fecha")
                    horastring = readerrecibo("hora").ToString
                    pagonormal = readerrecibo("pagonormal")
                    intereses = readerrecibo("intereses")
                    nombreCredito = readerrecibo("nombre")
                    pcmil = readerrecibo("interes")
                    monto = readerrecibo("monto")
                    cp = readerrecibo("plazo")
                    tipodoc = readerrecibo("Tipo")
                    concepto = readerrecibo("concepto")
                    tipodocstring = readerrecibo("NombreDoc")
                    NumeroCaja = readerrecibo("Caja")
                    subtotal = readerrecibo("subtotal")
                    descuento = readerrecibo("descuento")
                    nombreCajero = readerrecibo("NombreUsuario")
                    pagoindividual = readerrecibo("pagoindividual")
                End While
            Case Else
                While readerrecibo.Read
                    idrecibo = readerrecibo("id")
                    idcredito = readerrecibo("idcredito")
                    total = readerrecibo("total")
                    recibido = readerrecibo("recibido")
                    cambio = readerrecibo("cambio")
                    fechastring = readerrecibo("fecha")
                    horastring = readerrecibo("hora").ToString
                    pagonormal = readerrecibo("pagonormal")
                    intereses = readerrecibo("intereses")
                    nombreCredito = readerrecibo("nombre")
                    pcmil = readerrecibo("interes")
                    monto = readerrecibo("monto")
                    cp = readerrecibo("plazo")
                    tipodoc = readerrecibo("Tipo")
                    concepto = readerrecibo("concepto")
                    tipodocstring = readerrecibo("NombreDoc")
                    NumeroCaja = readerrecibo("Caja")
                    subtotal = readerrecibo("subtotal")
                    descuento = readerrecibo("descuento")
                    nombreCajero = readerrecibo("NombreUsuario")
                End While


        End Select

        fecha = Convert.ToDateTime(fechastring)
        Dim fechadepago As String
        fechadepago = Format(fecha, "dd/MM/yyyy")
        Dim comandoAbono As SqlCommand
        Dim consultaAbono As String
        Dim readerAbono As SqlDataReader
        Select Case tipodocstring
            Case "Pago"
                consultaAbono = "select TicketDetalle.idpago,TicketDetalle.fecha,TicketDetalle.monto,TicketDetalle.intereses,TicketDetalle.PagoNormal,TicketDetalle.concepto,CalendarioNormal.Npago from TicketDetalle inner join CalendarioNormal on TicketDetalle.idpago = CalendarioNormal.idpago where idTicket = '" & noTicket & "'"

                'consultaAbono = "select abonosext.idpago,abonosext.fecha,abonosext.monto,abonosext.intereses,abonosext.PagoNormal,abonosext.concepto,PagosExt.Npago from AbonosExt inner join PagosExt on AbonosExt.idpago = PagosExt.idpago where IdRecibo = '" & noTicket & "'"
                comandoAbono = New SqlCommand
                comandoAbono.Connection = conexionempresa
                comandoAbono.CommandText = consultaAbono
                readerAbono = comandoAbono.ExecuteReader
                If readerAbono.HasRows Then
                    While readerAbono.Read
                        a = New DetallePago(readerAbono("idpago"), readerAbono("Npago"), readerAbono("monto"), readerAbono("intereses"), 0, 0, readerAbono("pagonormal"), readerAbono("concepto"), recibido, 0)
                        array.Add(a)
                    End While
                Else

                End If
            Case "Convenio"
                consultaAbono = "select TicketDetalle.idpago,TicketDetalle.fecha,TicketDetalle.monto,TicketDetalle.intereses,TicketDetalle.PagoNormal,TicketDetalle.concepto,calendarioconveniossac.Npago from TicketDetalle inner join calendarioconveniossac on TicketDetalle.idpago = calendarioconveniossac.idpago where idTicket = '" & noTicket & "'"
                comandoAbono = New SqlCommand
                comandoAbono.Connection = conexionempresa
                comandoAbono.CommandText = consultaAbono
                readerAbono = comandoAbono.ExecuteReader
                If readerAbono.HasRows Then
                    While readerAbono.Read
                        a = New DetallePago(readerAbono("idpago"), readerAbono("Npago"), readerAbono("monto"), readerAbono("intereses"), 0, 0, readerAbono("pagonormal"), readerAbono("concepto"), recibido, 0)
                        array.Add(a)
                    End While
                Else

                End If
                'consultaAbono = "select abonosext.idpago,abonosext.fecha,abonosext.monto,abonosext.intereses,abonosext.PagoNormal,abonosext.concepto,calendarioconvenios.Npago from AbonosExt inner join calendarioconvenios on AbonosExt.idpago = calendarioconvenios.idpago where IdRecibo = '" & noTicket & "'"
            Case "Legal"
                consultaAbono = "select TicketDetalle.idpago,TicketDetalle.fecha,TicketDetalle.monto,TicketDetalle.intereses,TicketDetalle.PagoNormal,TicketDetalle.concepto,Calendariolegales.Npago from TicketDetalle inner join Calendariolegales on TicketDetalle.idpago = Calendariolegales.idpago where idTicket = '" & noTicket & "'"
                comandoAbono = New SqlCommand
                comandoAbono.Connection = conexionempresa
                comandoAbono.CommandText = consultaAbono
                readerAbono = comandoAbono.ExecuteReader
                If readerAbono.HasRows Then
                    While readerAbono.Read
                        a = New DetallePago(readerAbono("idpago"), readerAbono("Npago"), readerAbono("monto"), readerAbono("intereses"), 0, 0, readerAbono("pagonormal"), readerAbono("concepto"), recibido, 0)
                        array.Add(a)
                    End While
                Else

                End If
            Case "Reestructura"
                consultaAbono = "select TicketDetalle.idpago,TicketDetalle.fecha,TicketDetalle.monto,TicketDetalle.intereses,TicketDetalle.PagoNormal,TicketDetalle.concepto,CRS.Npago from TicketDetalle inner join CalendarioReestructurasSAC CRS on TicketDetalle.idpago = CRS.idpago where idTicket = '" & noTicket & "'"
                comandoAbono = New SqlCommand
                comandoAbono.Connection = conexionempresa
                comandoAbono.CommandText = consultaAbono
                readerAbono = comandoAbono.ExecuteReader
                If readerAbono.HasRows Then
                    While readerAbono.Read
                        a = New DetallePago(readerAbono("idpago"), readerAbono("Npago"), readerAbono("monto"), readerAbono("intereses"), 0, 0, readerAbono("pagonormal"), readerAbono("concepto"), recibido, 0)
                        array.Add(a)
                    End While
                Else

                End If
            Case "Promesa de pago"
                consultaAbono = "select TicketDetalle.idpago,TicketDetalle.fecha,TicketDetalle.monto,TicketDetalle.intereses,TicketDetalle.PagoNormal,TicketDetalle.concepto,'1' as npago from TicketDetalle inner join promesadepago on TicketDetalle.idpago = promesadepago.id where idTicket = '" & noTicket & "'"

                'consultaAbono = "select abonosext.idpago,abonosext.fecha,abonosext.monto,abonosext.intereses,abonosext.PagoNormal,abonosext.concepto,PagosExt.Npago from AbonosExt inner join PagosExt on AbonosExt.idpago = PagosExt.idpago where IdRecibo = '" & noTicket & "'"
                comandoAbono = New SqlCommand
                comandoAbono.Connection = conexionempresa
                comandoAbono.CommandText = consultaAbono
                readerAbono = comandoAbono.ExecuteReader
                If readerAbono.HasRows Then
                    While readerAbono.Read
                        a = New DetallePago(readerAbono("idpago"), readerAbono("Npago"), readerAbono("monto"), readerAbono("intereses"), 0, 0, readerAbono("pagonormal"), readerAbono("concepto"), recibido, 0)
                        array.Add(a)
                    End While
                Else

                End If
        End Select
        '   consultaAbono = "select abonosext.idpago,abonosext.fecha,abonosext.monto,abonosext.intereses,abonosext.PagoNormal,abonosext.concepto,PagosExt.Npago from AbonosExt inner join PagosExt on AbonosExt.idpago = PagosExt.idpago where IdRecibo = '" & noTicket & "'"



        Dim pagosemana As Double
        pagosemana = (monto / 1000) * pcmil


        Dim P As New PrinterClass(Impresora, System.Windows.Forms.Application.StartupPath, vistapreviaTicket)
        Select Case tipodoc
            Case 1
                With P


                    .AlignCenter()
                    .RTL = False
                    .AlignCenter()
                    .Gotox(1050)
                    .PrintLogo()
                    .GotoSixth(1)
                    .NormalFont()
                    .WriteLine(NombreEmpresa)
                    .WriteLine("")
                    .WriteLine(RFCEmpresa)
                    .FontSize = 8
                    .WriteLine("")
                    .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Colonia" & " " & ColEmpresa)

                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                    .WriteLine("")

                    .DrawLine()
                    .GotoSixth(1)
                    .FontSize = 7.3
                    .Bold = True
                    .WriteChars("TICKET:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idrecibo)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("CAJA:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(NumeroCaja)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("ATENDIDO POR:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(nombreCajero)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("CRÉDITO NO.:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idcredito)
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .FontSize = 6.3
                    .WriteChars("MONTO DEL CRÉDITO:")
                    .FontSize = 7.3
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars((monto).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("CLIENTE:")
                    .GotoSixth(3)
                    .Bold = False
                    .FontSize = 6.5
                    .WriteChars(nombreCredito)
                    .FontSize = 7.3
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("PLAZO(semanas):")
                    .GotoSixth(3)
                    .Bold = False
                    .WriteChars(cp)
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("PAGO SEMANAL:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(pagoindividual)
                    .WriteLine("")



                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("FECHA Y HORA DE PAGO: ")
                    .Bold = False

                    .WriteChars("  " & fechadepago & " - " & horastring)

                    .WriteLine("")
                    .DrawLine()

                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("DESCRIPCIÓN")
                    .GotoSixth(5)
                    .WriteChars("MONTO")

                    .WriteLine("")

                    .DrawLine()

                    .FontSize = 8
                    Dim subtotal16 As Double = 0
                    Dim totalpago As Double = 0
                    For Each s As DetallePago In array
                        .GotoSixth(1)
                        If s.getAbonado = 0 Then
                            .WriteChars("Capital de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                            .GotoSixth(5)
                            .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Interés de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                            .GotoSixth(5)
                            .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            'subtotal16 = subtotal16 + s.GenInteres(pcmil)
                        Else
                            .WriteChars("Capital de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                            .GotoSixth(5)
                            .WriteChars((s.getAbonado - s.GenInteres(pcmil)).ToString("$ ##,##00.00"))

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Interés de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                            .GotoSixth(5)
                            .WriteChars((s.GenInteres(pcmil)).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            subtotal16 = subtotal16 + s.GenInteres(pcmil)
                        End If

                        If s.getInteres <> 0 Then
                            .GotoSixth(1)
                            .WriteChars("Multa de pago No. " & s.getNoPago)

                            .GotoSixth(5)
                            .WriteChars((s.getInteres).ToString("$ ##,##00.00"))
                            subtotal16 = subtotal16 + s.getInteres
                            .WriteLine("")
                        End If
                        totalpago = totalpago + s.getAbonado + s.getInteres
                    Next
                    .DrawLine()

                    .GotoSixth(1)
                    .WriteChars("Subtotal Tasa 16%")

                    .GotoSixth(5)
                    .WriteChars((subtotal16 / 1.16).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("I.V.A")


                    .GotoSixth(5)
                    .WriteChars(((subtotal16 / 1.16) * 0.16).ToString("$ ##,##00.00"))
                    .WriteLine("")

                    .DrawLine()

                    .GotoSixth(1)
                    .WriteChars("SubTotal")
                    .GotoSixth(5)
                    .WriteChars((subtotal).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)

                    .WriteChars("Descuento")
                    .GotoSixth(5)
                    .WriteChars((descuento).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)

                    .WriteChars("Total")
                    .GotoSixth(5)
                    .WriteChars((total).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Recibido")
                    .GotoSixth(5)

                    .WriteChars((recibido).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Cambio")
                    .GotoSixth(5)

                    .WriteChars((cambio).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .DrawLine()
                    .FontSize = 7
                    .GotoSixth(1)

                    Dim StringNumeroLetra As String
                    StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                    Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                    Dim i As Integer = 0
                    Dim nuevostring As String = ""
                    Dim siguientestring As String = ""
                    For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                        i += StringNumeroLetraPartido(Palabras).Length + 1
                        .AlignCenter()
                        If i < 56 Then
                            nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                        Else
                            siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                        End If
                    Next
                    .WriteLine(nuevostring)
                    If siguientestring <> "" Then
                        .WriteLine(siguientestring)
                    End If
                    .WriteLine("")
                    .GotoSixth(1)

                    .GotoSixth(1)
                    .Bold = False
                    .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                    .CutPaper()
                    .EndDoc()


                End With



               ' Return True
                ' Catch ex As Exception
                'MessageBox.Show(ex.Message)
                'Return False
                ' End Try
            Case 2
                With P

                    .AlignCenter()
                    .RTL = False
                    .AlignCenter()
                    .Gotox(1050)
                    .PrintLogo()
                    .GotoSixth(1)
                    .NormalFont()
                    .WriteLine(NombreEmpresa)
                    .WriteLine("")
                    .WriteLine(RFCEmpresa)
                    .FontSize = 8
                    .WriteLine("")
                    .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Colonia" & " " & ColEmpresa)

                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                    .WriteLine("")

                    .DrawLine()
                    .GotoSixth(1)
                    .FontSize = 7.3
                    .Bold = True
                    .WriteChars("TICKET:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idrecibo)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("CAJA:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(NumeroCaja)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("ATENDIDO POR:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(nombreCajero)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("CRÉDITO NO.:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idcredito)
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .FontSize = 6.3
                    .WriteChars("MONTO DEL CRÉDITO:")
                    .FontSize = 7.3
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars((monto).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("CLIENTE:")
                    .GotoSixth(3)
                    .Bold = False
                    .FontSize = 6.5
                    .WriteChars(nombreCredito)
                    .FontSize = 7.3
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("PLAZO(semanas):")
                    .GotoSixth(3)
                    .Bold = False
                    .WriteChars(cp)
                    .WriteLine("")



                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("FECHA Y HORA DE PAGO: ")
                    .Bold = False
                    .WriteChars("  " & fechadepago & " - " & horastring)

                    .WriteLine("")
                    .DrawLine()

                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("DESCRIPCIÓN")
                    .GotoSixth(5)
                    .WriteChars("MONTO")

                    .WriteLine("")

                    .DrawLine()



                    .GotoSixth(1)
                    .WriteChars("Comisión por Apertura")

                    .GotoSixth(5)
                    .WriteChars((total / 1.16).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("I.V.A")


                    .GotoSixth(5)
                    .WriteChars(((total / 1.16) * 0.16).ToString("$ ##,##00.00"))
                    .WriteLine("")

                    .DrawLine()

                    .GotoSixth(1)
                    .WriteChars("Total Pagado")
                    .GotoSixth(5)
                    .WriteChars((total).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Recibido")
                    .GotoSixth(5)

                    .WriteChars((recibido).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Cambio")
                    .GotoSixth(5)

                    .WriteChars((cambio).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .DrawLine()
                    .GotoSixth(1)
                    Dim StringNumeroLetra As String
                    StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                    Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                    Dim i As Integer = 0
                    Dim nuevostring As String = ""
                    Dim siguientestring As String = ""
                    For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                        i += StringNumeroLetraPartido(Palabras).Length + 1
                        .AlignCenter()
                        If i < 56 Then
                            nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                        Else
                            siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                        End If
                    Next
                    .WriteLine(nuevostring)
                    If siguientestring <> "" Then
                        .WriteLine(siguientestring)
                    End If
                    .WriteLine("")
                    .GotoSixth(1)

                    .GotoSixth(1)
                    .Bold = False
                    .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                    .CutPaper()
                    .EndDoc()

                End With

            Case 3
                With P

                    .AlignCenter()
                    .RTL = False
                    .AlignCenter()
                    .Gotox(1050)
                    .PrintLogo()
                    .GotoSixth(1)
                    .NormalFont()
                    .WriteLine(NombreEmpresa)
                    .WriteLine("")
                    .WriteLine(RFCEmpresa)
                    .FontSize = 8
                    .WriteLine("")
                    .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Colonia" & " " & ColEmpresa)

                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                    .WriteLine("")

                    .DrawLine()
                    .GotoSixth(1)
                    .FontSize = 7.3
                    .Bold = True
                    .WriteChars("TICKET:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idrecibo)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("CAJA:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(NumeroCaja)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("ATENDIDO POR:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(nombreCajero)
                    .WriteLine("")





                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("FECHA Y HORA DE PAGO:  ")
                    .Bold = False
                    .WriteChars("  " & fechadepago & " - " & horastring)

                    .WriteLine("")
                    .DrawLine()

                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("DESCRIPCIÓN")
                    .GotoSixth(5)
                    .WriteChars("MONTO")

                    .WriteLine("")

                    .DrawLine()


                    .GotoSixth(1)


                    .WriteChars(concepto)
                    .GotoSixth(5)
                    .WriteChars((total).ToString("$ ##,##00.00"))

                    .WriteLine("")

                    .DrawLine()


                    .GotoSixth(1)
                    .WriteChars("SubTotal")
                    .GotoSixth(5)
                    .WriteChars((subtotal).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)

                    .WriteChars("Descuento")
                    .GotoSixth(5)
                    .WriteChars((descuento).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)

                    .WriteChars("Total")
                    .GotoSixth(5)
                    .WriteChars((total).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Recibido")
                    .GotoSixth(5)
                    .WriteChars((recibido).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Cambio")
                    .GotoSixth(5)
                    ' Dim cambio As Double
                    ' If txtCambio.Text = "" Then
                    ' cambio = 0
                    ' Else
                    'cambio = Convert.ToDouble(txtCambio.Text)
                    ' End If
                    .WriteChars((cambio).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .DrawLine()
                    .GotoSixth(1)

                    Dim StringNumeroLetra As String
                    StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                    Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                    Dim i As Integer = 0
                    Dim nuevostring As String = ""
                    Dim siguientestring As String = ""
                    For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                        i += StringNumeroLetraPartido(Palabras).Length + 1
                        .AlignCenter()
                        If i < 56 Then
                            nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                        Else
                            siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                        End If
                    Next
                    .WriteLine(nuevostring)
                    If siguientestring <> "" Then
                        .WriteLine(siguientestring)
                    End If

                    .WriteLine("")


                    .GotoSixth(1)
                    .Bold = False
                    .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                    .CutPaper()
                    .EndDoc()

                End With

            Case 5
                With P

                    .AlignCenter()
                    .RTL = False
                    .AlignCenter()
                    .Gotox(1050)
                    .PrintLogo()
                    .GotoSixth(1)
                    .NormalFont()
                    .WriteLine(NombreEmpresa)
                    .WriteLine("")
                    .WriteLine(RFCEmpresa)
                    .FontSize = 8
                    .WriteLine("")
                    .WriteChars("Calle  " & CalleEmpresa & "  " & NumeroEmpresa)


                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Colonia" & " " & ColEmpresa)

                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                    .WriteLine("")

                    .DrawLine()
                    .GotoSixth(1)
                    .FontSize = 7.3
                    .Bold = True
                    .WriteChars("TICKET:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idrecibo)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("CAJA:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(noCaja)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("ATENDIDO POR:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(nm_completeusr)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .FontSize = 6.8
                    .WriteChars("CRÉDITO LEGAL NO.:")
                    .FontSize = 7.3
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idcredito)
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("DEUDA TOTAL:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars((monto).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("CLIENTE:")
                    .GotoSixth(3)
                    .Bold = False
                    .FontSize = 6.5
                    .WriteChars(nombreCredito)
                    .FontSize = 7.3
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("PLAZO(semanas):")
                    .GotoSixth(3)
                    .Bold = False
                    .WriteChars(cp)
                    .WriteLine("")

                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("FECHA Y HORA DE PAGO: ")
                    .Bold = False
                    .WriteChars("  " & fechadepago & " - " & horastring)

                    .WriteLine("")
                    .DrawLine()

                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("DESCRIPCIÓN")
                    .GotoSixth(5)
                    .WriteChars("MONTO")

                    .WriteLine("")

                    .DrawLine()



                    .GotoSixth(1)
                    .WriteChars(concepto)

                    .GotoSixth(5)
                    .WriteChars((total).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)

                    .DrawLine()
                    .GotoSixth(1)

                    Dim StringNumeroLetra As String
                    StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                    Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                    Dim i As Integer = 0
                    Dim nuevostring As String = ""
                    Dim siguientestring As String = ""
                    For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                        i += StringNumeroLetraPartido(Palabras).Length + 1
                        .AlignCenter()
                        If i < 56 Then
                            nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                        Else
                            siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                        End If
                    Next
                    .WriteLine(nuevostring)
                    If siguientestring <> "" Then
                        .WriteLine(siguientestring)
                    End If

                    .WriteLine("")
                    .GotoSixth(1)

                    .GotoSixth(1)
                    .Bold = False
                    .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                    .CutPaper()
                    .EndDoc()

                End With
            Case 4
                With P


                    .AlignCenter()
                    .RTL = False
                    .AlignCenter()
                    .Gotox(1050)
                    .PrintLogo()
                    .GotoSixth(1)
                    .NormalFont()
                    .WriteLine(NombreEmpresa)
                    .WriteLine("")
                    .WriteLine(RFCEmpresa)
                    .FontSize = 8
                    .WriteLine("")
                    .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Colonia" & " " & ColEmpresa)

                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                    .WriteLine("")

                    .DrawLine()
                    .GotoSixth(1)
                    .FontSize = 7.3
                    .Bold = True
                    .WriteChars("TICKET:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idrecibo)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("CAJA:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(NumeroCaja)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("ATENDIDO POR:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(nombreCajero)
                    .WriteLine("")
                    .Bold = True
                    .GotoSixth(1)
                    .WriteChars("CONVENIO NO.:")
                    .Bold = False
                    .GotoSixth(3)
                    .WriteChars(idcredito)
                    .WriteLine("")

                    .GotoSixth(1)
                    .Bold = True
                    .WriteChars("CLIENTE:")
                    .GotoSixth(3)
                    .Bold = False
                    .FontSize = 6.5
                    .WriteChars(nombreCredito)
                    .FontSize = 7.3
                    .WriteLine("")
                    .GotoSixth(1)
                    .Bold = True

                    .WriteLine("")



                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("FECHA Y HORA DE PAGO: ")
                    .Bold = False
                    .WriteChars("  " & fechadepago & " - " & horastring)

                    .WriteLine("")
                    .DrawLine()

                    .GotoSixth(1)
                    .Bold = True

                    .WriteChars("DESCRIPCIÓN")
                    .GotoSixth(5)
                    .WriteChars("MONTO")

                    .WriteLine("")

                    .DrawLine()


                    Dim subtotal16 As Double = 0
                    Dim totalpago As Double = 0
                    For Each s As DetallePago In array
                        .GotoSixth(1)
                        If s.getAbonado = 0 Then
                            .WriteChars("Capital de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                            .GotoSixth(5)
                            .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Interés de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                            .GotoSixth(5)
                            .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            'subtotal16 = subtotal16 + s.GenInteres(pcmil)
                        Else
                            .WriteChars("Capital de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                            .GotoSixth(5)
                            .WriteChars((s.getAbonado - s.GenInteres(pcmil)).ToString("$ ##,##00.00"))

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Interés de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                            .GotoSixth(5)
                            .WriteChars((s.GenInteres(pcmil)).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            subtotal16 = subtotal16 + s.GenInteres(pcmil)
                        End If

                        If s.getInteres <> 0 Then
                            .GotoSixth(1)
                            .WriteChars("Multa de pago No. " & s.getNoPago)

                            .GotoSixth(5)
                            .WriteChars((s.getInteres).ToString("$ ##,##00.00"))
                            subtotal16 = subtotal16 + s.getInteres
                            .WriteLine("")
                        End If
                        totalpago = totalpago + s.getAbonado + s.getInteres
                    Next
                    .DrawLine()

                    .GotoSixth(1)
                    .WriteChars("Subtotal Tasa 16%")

                    .GotoSixth(5)
                    .WriteChars((subtotal16 / 1.16).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("I.V.A")


                    .GotoSixth(5)
                    .WriteChars(((subtotal16 / 1.16) * 0.16).ToString("$ ##,##00.00"))
                    .WriteLine("")

                    .DrawLine()

                    .GotoSixth(1)
                    .WriteChars("SubTotal")
                    .GotoSixth(5)
                    .WriteChars((subtotal).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)

                    .WriteChars("Descuento")
                    .GotoSixth(5)
                    .WriteChars((descuento).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)

                    .WriteChars("Total")
                    .GotoSixth(5)
                    .WriteChars((total).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Recibido")
                    .GotoSixth(5)

                    .WriteChars((recibido).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .WriteChars("Cambio")
                    .GotoSixth(5)

                    .WriteChars((cambio).ToString("$ ##,##00.00"))
                    .WriteLine("")
                    .GotoSixth(1)
                    .DrawLine()
                    .GotoSixth(1)

                    Dim StringNumeroLetra As String
                    StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                    Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                    Dim i As Integer = 0
                    Dim nuevostring As String = ""
                    Dim siguientestring As String = ""
                    For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                        i += StringNumeroLetraPartido(Palabras).Length + 1
                        .AlignCenter()
                        If i < 56 Then
                            nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                        Else
                            siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                        End If
                    Next
                    .WriteLine(nuevostring)
                    If siguientestring <> "" Then
                        .WriteLine(siguientestring)
                    End If

                    .WriteLine("")
                    .GotoSixth(1)

                    .GotoSixth(1)
                    .Bold = False
                    .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                    .CutPaper()
                    .EndDoc()


                End With



            Case Else
                Select Case tipodocstring
                    Case "Reestructura"
                        With P


                            .AlignCenter()
                            .RTL = False
                            .AlignCenter()
                            .Gotox(1050)
                            .PrintLogo()
                            .GotoSixth(1)
                            .NormalFont()
                            .WriteLine(NombreEmpresa)
                            .WriteLine("")
                            .WriteLine(RFCEmpresa)
                            .FontSize = 8
                            .WriteLine("")
                            .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Colonia" & " " & ColEmpresa)

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                            .WriteLine("")

                            .DrawLine()
                            .GotoSixth(1)
                            .FontSize = 7.3
                            .Bold = True
                            .WriteChars("TICKET:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idrecibo)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CAJA:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(NumeroCaja)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("ATENDIDO POR:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(nombreCajero)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .FontSize = 6
                            .WriteChars("FOLIO REESTRUCTURA:")
                            .FontSize = 7.3
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idcredito)
                            .WriteLine("")

                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("CLIENTE:")
                            .GotoSixth(3)
                            .Bold = False
                            .FontSize = 6.5
                            .WriteChars(nombreCredito)
                            .FontSize = 7.3
                            .WriteLine("")

                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("FECHA Y HORA DE PAGO: ")
                            .Bold = False
                            .WriteChars("  " & fechadepago & " - " & horastring)

                            .WriteLine("")
                            .DrawLine()

                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("DESCRIPCIÓN")
                            .GotoSixth(5)
                            .WriteChars("MONTO")

                            .WriteLine("")

                            .DrawLine()


                            Dim subtotal16 As Double = 0
                            Dim totalpago As Double = 0
                            For Each s As DetallePago In array
                                .GotoSixth(1)
                                If s.getAbonado = 0 Then
                                    .WriteChars("Capital de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))

                                    .WriteLine("")
                                    .GotoSixth(1)
                                    .WriteChars("Interés de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))
                                    .WriteLine("")
                                    'subtotal16 = subtotal16 + s.GenInteres(pcmil)
                                Else
                                    .WriteChars("Capital de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado - s.GenInteres(pcmil)).ToString("$ ##,##00.00"))

                                    .WriteLine("")
                                    .GotoSixth(1)
                                    .WriteChars("Interés de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                                    .GotoSixth(5)
                                    .WriteChars((s.GenInteres(pcmil)).ToString("$ ##,##00.00"))
                                    .WriteLine("")
                                    subtotal16 = subtotal16 + s.GenInteres(pcmil)
                                End If

                                If s.getInteres <> 0 Then
                                    .GotoSixth(1)
                                    .WriteChars("Multa de pago No. " & s.getNoPago)

                                    .GotoSixth(5)
                                    .WriteChars((s.getInteres).ToString("$ ##,##00.00"))
                                    subtotal16 = subtotal16 + s.getInteres
                                    .WriteLine("")
                                End If
                                totalpago = totalpago + s.getAbonado + s.getInteres
                            Next
                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("Subtotal Tasa 16%")

                            .GotoSixth(5)
                            .WriteChars((subtotal16 / 1.16).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("I.V.A")


                            .GotoSixth(5)
                            .WriteChars(((subtotal16 / 1.16) * 0.16).ToString("$ ##,##00.00"))
                            .WriteLine("")

                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("SubTotal")
                            .GotoSixth(5)
                            .WriteChars((subtotal).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Descuento")
                            .GotoSixth(5)
                            .WriteChars((descuento).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Total")
                            .GotoSixth(5)
                            .WriteChars((total).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Recibido")
                            .GotoSixth(5)

                            .WriteChars((recibido).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Cambio")
                            .GotoSixth(5)

                            .WriteChars((cambio).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .DrawLine()
                            .GotoSixth(1)

                            Dim StringNumeroLetra As String
                            StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                            Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                            Dim i As Integer = 0
                            Dim nuevostring As String = ""
                            Dim siguientestring As String = ""
                            For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                i += StringNumeroLetraPartido(Palabras).Length + 1
                                .AlignCenter()
                                If i < 56 Then
                                    nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                Else
                                    siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                End If
                            Next
                            .WriteLine(nuevostring)
                            If siguientestring <> "" Then
                                .WriteLine(siguientestring)
                            End If

                            .WriteLine("")
                            .GotoSixth(1)

                            .GotoSixth(1)
                            .Bold = False
                            .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                            .CutPaper()
                            .EndDoc()


                        End With
                    Case "Liquidación Insoluto"
                        With P

                            .AlignCenter()
                            .RTL = False
                            .AlignCenter()
                            .Gotox(1050)
                            .PrintLogo()
                            .GotoSixth(1)
                            .NormalFont()
                            .WriteLine(NombreEmpresa)
                            .WriteLine("")
                            .WriteLine(RFCEmpresa)
                            .FontSize = 8
                            .WriteLine("")
                            .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Colonia" & " " & ColEmpresa)

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                            .WriteLine("")

                            .DrawLine()
                            .GotoSixth(1)
                            .FontSize = 7.3
                            .Bold = True
                            .WriteChars("TICKET:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idrecibo)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CAJA:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(NumeroCaja)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("ATENDIDO POR:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(nombreCajero)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CRÉDITO NO.:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idcredito)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .FontSize = 6.3
                            .WriteChars("MONTO DEL CRÉDITO:")
                            .FontSize = 7.3
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars((monto).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("CLIENTE:")
                            .GotoSixth(3)
                            .Bold = False
                            .FontSize = 6.5
                            .WriteChars(nombreCredito)
                            .FontSize = 7.3
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PLAZO(semanas):")
                            .GotoSixth(3)
                            .Bold = False
                            .WriteChars(cp)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PAGO SEMANAL:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(pagosemana)
                            .WriteLine("")



                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("FECHA Y HORA DE PAGO: ")
                            .Bold = False
                            .WriteChars("  " & fechadepago & " - " & horastring)

                            .WriteLine("")
                            .DrawLine()

                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("DESCRIPCIÓN")
                            .GotoSixth(5)
                            .WriteChars("MONTO")

                            .WriteLine("")

                            .DrawLine()


                            Dim subtotal16 As Double = 0
                            Dim totalpago As Double = 0
                            .GotoSixth(1)

                            .WriteChars("Capital de Liquidación")
                            .GotoSixth(5)
                            .WriteChars((pagonormal).ToString("$ ##,##00.00"))

                            .WriteLine("")
                            .GotoSixth(1)


                            If intereses <> 0 Then
                                .GotoSixth(1)
                                .WriteChars("Multas")

                                .GotoSixth(5)
                                .WriteChars((intereses).ToString("$ ##,##00.00"))
                                subtotal16 = intereses
                                .WriteLine("")
                            End If


                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("Subtotal Tasa 16%")

                            .GotoSixth(5)
                            .WriteChars((subtotal16 / 1.16).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("I.V.A")


                            .GotoSixth(5)
                            .WriteChars(((subtotal16 / 1.16) * 0.16).ToString("$ ##,##00.00"))
                            .WriteLine("")

                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("SubTotal")
                            .GotoSixth(5)
                            .WriteChars((subtotal).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Descuento")
                            .GotoSixth(5)
                            .WriteChars((descuento).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Total")
                            .GotoSixth(5)
                            .WriteChars((total).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Recibido")
                            .GotoSixth(5)

                            .WriteChars((recibido).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Cambio")
                            .GotoSixth(5)

                            .WriteChars((cambio).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .DrawLine()
                            .GotoSixth(1)

                            Dim StringNumeroLetra As String
                            StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                            Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                            Dim i As Integer = 0
                            Dim nuevostring As String = ""
                            Dim siguientestring As String = ""
                            For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                i += StringNumeroLetraPartido(Palabras).Length + 1
                                .AlignCenter()
                                If i < 56 Then
                                    nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                Else
                                    siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                End If
                            Next
                            .WriteLine(nuevostring)
                            If siguientestring <> "" Then
                                .WriteLine(siguientestring)
                            End If

                            .WriteLine("")
                            .GotoSixth(1)

                            .Bold = True
                            .WriteLine("CUENTA LIQUIDADA")

                            .GotoSixth(1)
                            .Bold = False
                            .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                            .CutPaper()
                            .EndDoc()

                        End With
                    Case "Liquidación Normal"
                        With P

                            .AlignCenter()
                            .RTL = False
                            .AlignCenter()
                            .Gotox(1050)
                            .PrintLogo()
                            .GotoSixth(1)
                            .NormalFont()
                            .WriteLine(NombreEmpresa)
                            .WriteLine("")
                            .WriteLine(RFCEmpresa)
                            .FontSize = 8
                            .WriteLine("")
                            .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Colonia" & " " & ColEmpresa)

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                            .WriteLine("")

                            .DrawLine()
                            .GotoSixth(1)
                            .FontSize = 7.3
                            .Bold = True
                            .WriteChars("TICKET:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idrecibo)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CAJA:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(NumeroCaja)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CRÉDITO NO.:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idcredito)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .FontSize = 6.3
                            .WriteChars("MONTO DEL CRÉDITO:")
                            .FontSize = 7.3
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars((monto).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("CLIENTE:")
                            .GotoSixth(3)
                            .Bold = False
                            .FontSize = 6.5
                            .WriteChars(nombreCredito)
                            .FontSize = 7.3
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PLAZO(semanas):")
                            .GotoSixth(3)
                            .Bold = False
                            .WriteChars(cp)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PAGO SEMANAL:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(pagosemana)
                            .WriteLine("")



                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("FECHA Y HORA DE PAGO: ")
                            .Bold = False
                            .WriteChars("  " & fechadepago & " - " & horastring)

                            .WriteLine("")
                            .DrawLine()

                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("DESCRIPCIÓN")
                            .GotoSixth(5)
                            .WriteChars("MONTO")

                            .WriteLine("")

                            .DrawLine()


                            Dim subtotal16 As Double = 0
                            Dim totalpago As Double = 0
                            For Each s As DetallePago In array
                                .GotoSixth(1)
                                If s.getAbonado = 0 Then
                                    .WriteChars("Capital de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))

                                    .WriteLine("")
                                    .GotoSixth(1)
                                    .WriteChars("Interés de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))
                                    .WriteLine("")
                                    'subtotal16 = subtotal16 + s.GenInteres(pcmil)
                                Else
                                    .WriteChars("Capital de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado - s.GenInteres(pcmil)).ToString("$ ##,##00.00"))

                                    .WriteLine("")
                                    .GotoSixth(1)
                                    .WriteChars("Interés de " & s.getConcepto & " de Pago No. " & s.getNoPago)
                                    .GotoSixth(5)
                                    .WriteChars((s.GenInteres(pcmil)).ToString("$ ##,##00.00"))
                                    .WriteLine("")
                                    subtotal16 = subtotal16 + s.GenInteres(pcmil)
                                End If

                                If s.getInteres <> 0 Then
                                    .GotoSixth(1)
                                    .WriteChars("Multa de pago No. " & s.getNoPago)

                                    .GotoSixth(5)
                                    .WriteChars((s.getInteres).ToString("$ ##,##00.00"))
                                    subtotal16 = subtotal16 + s.getInteres
                                    .WriteLine("")
                                End If
                                totalpago = totalpago + s.getAbonado + s.getInteres
                            Next
                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("Subtotal Tasa 16%")

                            .GotoSixth(5)
                            .WriteChars((subtotal16 / 1.16).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("I.V.A")


                            .GotoSixth(5)
                            .WriteChars(((subtotal16 / 1.16) * 0.16).ToString("$ ##,##00.00"))
                            .WriteLine("")

                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("Total Pagado")
                            .GotoSixth(5)
                            .WriteChars((totalpago).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Recibido")
                            .GotoSixth(5)
                            .WriteChars((recibido).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Cambio")
                            .GotoSixth(5)
                            '   Dim cambio As Double
                            'If txtCambio.Text = "" Then
                            'cambio = 0
                            'Else
                            'cambio = Convert.ToDouble(txtCambio.Text)
                            'End If
                            .WriteChars((cambio).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .DrawLine()
                            .GotoSixth(1)

                            Dim StringNumeroLetra As String
                            StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                            Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                            Dim i As Integer = 0
                            Dim nuevostring As String = ""
                            Dim siguientestring As String = ""
                            For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                i += StringNumeroLetraPartido(Palabras).Length + 1
                                .AlignCenter()
                                If i < 56 Then
                                    nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                Else
                                    siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                End If
                            Next
                            .WriteLine(nuevostring)
                            If siguientestring <> "" Then
                                .WriteLine(siguientestring)
                            End If

                            .WriteLine("")
                            .GotoSixth(1)
                            ' If atraso = 0 Then
                            .Bold = True
                            .WriteLine("CUENTA LIQUIDADA")
                            .WriteLine("")
                            ' Else
                            '.Bold = True
                            '.WriteLine("CUENTA EN ATRASO PUEDE PONERSE AL CORRIENTE CON:")

                            '.WriteLine("")
                            '  .WriteLine((atraso).ToString("$ ##,##00.00"))
                            ' .WriteLine("")
                            ' End If
                            .GotoSixth(1)
                            .Bold = False
                            .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                            .CutPaper()
                            .EndDoc()

                        End With
                    Case "Renovación Insoluto"
                        With P

                            .AlignCenter()
                            .RTL = False
                            .AlignCenter()
                            .Gotox(1050)
                            .PrintLogo()
                            .GotoSixth(1)
                            .NormalFont()
                            .WriteLine(NombreEmpresa)
                            .WriteLine("")
                            .WriteLine(RFCEmpresa)
                            .FontSize = 8
                            .WriteLine("")
                            .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Colonia" & " " & ColEmpresa)

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                            .WriteLine("")

                            .DrawLine()
                            .GotoSixth(1)
                            .FontSize = 7.3
                            .Bold = True
                            .WriteChars("TICKET:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idrecibo)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CAJA:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(NumeroCaja)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("ATENDIDO POR:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(nombreCajero)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CRÉDITO NO.:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idcredito)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .FontSize = 6.3
                            .WriteChars("MONTO DEL CRÉDITO:")
                            .FontSize = 7.3
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars((monto).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("CLIENTE:")
                            .GotoSixth(3)
                            .Bold = False
                            .FontSize = 6.5
                            .WriteChars(nombreCredito)
                            .FontSize = 7.3
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PLAZO(semanas):")
                            .GotoSixth(3)
                            .Bold = False
                            .WriteChars(cp)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PAGO SEMANAL:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(pagosemana)
                            .WriteLine("")



                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("FECHA Y HORA DE PAGO: ")
                            .Bold = False
                            .WriteChars("  " & fechadepago & " - " & horastring)

                            .WriteLine("")
                            .DrawLine()

                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("DESCRIPCIÓN")
                            .GotoSixth(5)
                            .WriteChars("MONTO")

                            .WriteLine("")

                            .DrawLine()


                            Dim subtotal16 As Double = 0
                            Dim totalpago As Double = 0
                            .GotoSixth(1)

                            .WriteChars("Capital de Liquidación")
                            .GotoSixth(5)
                            .WriteChars((pagonormal).ToString("$ ##,##00.00"))

                            .WriteLine("")
                            .GotoSixth(1)


                            If intereses <> 0 Then
                                .GotoSixth(1)
                                .WriteChars("Multas")

                                .GotoSixth(5)
                                .WriteChars((intereses).ToString("$ ##,##00.00"))
                                subtotal16 = intereses
                                .WriteLine("")
                            End If


                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("Subtotal Tasa 16%")

                            .GotoSixth(5)
                            .WriteChars((subtotal16 / 1.16).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("I.V.A")


                            .GotoSixth(5)
                            .WriteChars(((subtotal16 / 1.16) * 0.16).ToString("$ ##,##00.00"))
                            .WriteLine("")

                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("SubTotal")
                            .GotoSixth(5)
                            .WriteChars((subtotal).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Descuento")
                            .GotoSixth(5)
                            .WriteChars((descuento).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Total")
                            .GotoSixth(5)
                            .WriteChars((total).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Recibido")
                            .GotoSixth(5)

                            .WriteChars((recibido).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Cambio")
                            .GotoSixth(5)

                            .WriteChars((cambio).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .DrawLine()
                            .GotoSixth(1)

                            Dim StringNumeroLetra As String
                            StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                            Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                            Dim i As Integer = 0
                            Dim nuevostring As String = ""
                            Dim siguientestring As String = ""
                            For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                i += StringNumeroLetraPartido(Palabras).Length + 1
                                .AlignCenter()
                                If i < 56 Then
                                    nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                Else
                                    siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                End If
                            Next
                            .WriteLine(nuevostring)
                            If siguientestring <> "" Then
                                .WriteLine(siguientestring)
                            End If

                            .WriteLine("")
                            .GotoSixth(1)

                            .Bold = True
                            .WriteLine("CUENTA LIQUIDADA")

                            .GotoSixth(1)
                            .Bold = False
                            .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                            .CutPaper()
                            .EndDoc()

                        End With
                    Case "Refrendo", "Comisión por avalúo", "Desempeño"
                        With P
                            .AlignCenter()
                            .RTL = False
                            .AlignCenter()
                            .Gotox(1085)
                            .PrintLogo()
                            .GotoSixth(1)
                            .NormalFont()
                            .WriteLine(NombreEmpresa)
                            .WriteLine("")
                            .WriteLine(RFCEmpresa)
                            .FontSize = 8
                            .WriteLine("")
                            .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Colonia" & " " & ColEmpresa)

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                            .WriteLine("")

                            .DrawLine()
                            .GotoSixth(1)
                            .FontSize = 7.3
                            .Bold = True
                            .WriteChars("TICKET:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idrecibo)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CAJA:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(NumeroCaja)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("ATENDIDO POR:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(nombreCajero)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("EMPEÑO NO.:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idcredito)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .FontSize = 6.3
                            .WriteChars("MONTO DEL EMPEÑO:")
                            .Bold = False
                            .FontSize = 7.3
                            .GotoSixth(3)
                            .WriteChars((monto).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("CLIENTE:")
                            .GotoSixth(3)
                            .Bold = False
                            .FontSize = 6.5
                            .WriteChars(nombreCredito)
                            .FontSize = 7.3
                            .WriteLine("")
                            .GotoSixth(1)


                            .Bold = True
                            .WriteChars("FECHA Y HORA DE PAGO:  ")
                            .Bold = False
                            .WriteChars("  " & fechadepago & " - " & horastring)

                            .WriteLine("")
                            .DrawLine()

                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("DESCRIPCIÓN")
                            .GotoSixth(5)
                            .WriteChars("MONTO")

                            .WriteLine("")

                            .DrawLine()


                            Dim subtotal16 As Double = 0
                            Dim totalpago As Double = 0
                            If GetNombreDoc(tipodoc) = "Comisión por avalúo" Then
                                .GotoSixth(1)

                                .WriteChars("Comisión por avalúo ")
                                .GotoSixth(5)
                                .WriteChars((intereses).ToString("$ ##,##00.00"))


                                .WriteLine("")
                            Else
                                If intereses <> 0 Then
                                    .GotoSixth(1)

                                    .WriteChars("Pago de refrendo no. " & concepto)
                                    .GotoSixth(5)
                                    .WriteChars((intereses).ToString("$ ##,##00.00"))


                                    .WriteLine("")
                                End If

                                'subtotal16 = subtotal16 + s.GenInteres(pcmil)


                                If pagonormal <> 0 Then
                                    .GotoSixth(1)
                                    .WriteChars("Abono a capital")

                                    .GotoSixth(5)
                                    .WriteChars((pagonormal).ToString("$ ##,##00.00"))

                                    .WriteLine("")
                                End If


                            End If

                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("Subtotal Tasa 16%")

                            .GotoSixth(5)
                            .WriteChars((intereses / 1.16).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("I.V.A")


                            .GotoSixth(5)
                            .WriteChars(((intereses / 1.16) * 0.16).ToString("$ ##,##00.00"))
                            .WriteLine("")

                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("SubTotal")
                            .GotoSixth(5)
                            .WriteChars((subtotal).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Descuento")
                            .GotoSixth(5)
                            .WriteChars((descuento).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Total")
                            .GotoSixth(5)
                            .WriteChars((total).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Recibido")
                            .GotoSixth(5)

                            .WriteChars((recibido).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Cambio")
                            .GotoSixth(5)

                            .WriteChars((cambio).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .DrawLine()
                            .GotoSixth(1)
                            Dim StringNumeroLetra As String
                            StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                            Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                            Dim i As Integer = 0
                            Dim nuevostring As String = ""
                            Dim siguientestring As String = ""
                            For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                i += StringNumeroLetraPartido(Palabras).Length + 1
                                .AlignCenter()
                                If i < 56 Then
                                    nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                Else
                                    siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                End If
                            Next
                            .WriteLine(nuevostring)
                            If siguientestring <> "" Then
                                .WriteLine(siguientestring)
                            End If
                            .WriteLine("")
                            If GetNombreDoc(tipodoc) = "Desempeño" Then
                                .Bold = True
                                .GotoSixth(1)
                                .WriteLine("CUENTA LIQUIDADA")

                            End If

                            .GotoSixth(1)
                            .Bold = False
                            .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                            .CutPaper()
                            .EndDoc()

                        End With
                    Case "Promesa de pago"
                        With P


                            .AlignCenter()
                            .RTL = False
                            .AlignCenter()
                            .Gotox(1050)
                            .PrintLogo()
                            .GotoSixth(1)
                            .NormalFont()
                            .WriteLine(NombreEmpresa)
                            .WriteLine("")
                            .WriteLine(RFCEmpresa)
                            .FontSize = 8
                            .WriteLine("")
                            .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Colonia" & " " & ColEmpresa)

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                            .WriteLine("")

                            .DrawLine()
                            .GotoSixth(1)
                            .FontSize = 7.3
                            .Bold = True
                            .WriteChars("TICKET:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idrecibo)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CAJA:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(NumeroCaja)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("ATENDIDO POR:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(nombreCajero)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CRÉDITO NO.:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idcredito)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .FontSize = 6.3
                            .WriteChars("MONTO DEL CRÉDITO:")
                            .FontSize = 7.3
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars((monto).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("CLIENTE:")
                            .GotoSixth(3)
                            .Bold = False
                            .FontSize = 6.5
                            .WriteChars(nombreCredito)
                            .FontSize = 7.3
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PLAZO(semanas):")
                            .GotoSixth(3)
                            .Bold = False
                            .WriteChars(cp)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PAGO SEMANAL:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(pagoindividual)
                            .WriteLine("")



                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("FECHA Y HORA DE PAGO: ")
                            .Bold = False

                            .WriteChars("  " & fechadepago & " - " & horastring)

                            .WriteLine("")
                            .DrawLine()

                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("DESCRIPCIÓN")
                            .GotoSixth(5)
                            .WriteChars("MONTO")

                            .WriteLine("")

                            .DrawLine()

                            .FontSize = 8
                            Dim subtotal16 As Double = 0
                            Dim totalpago As Double = 0
                            For Each s As DetallePago In array
                                .GotoSixth(1)
                                If s.getAbonado = 0 Then
                                    .WriteChars("Capital de " & s.getConcepto & " de promesa")
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))

                                    .WriteLine("")
                                    .GotoSixth(1)
                                    .WriteChars("Interés de " & s.getConcepto & " de promesa")
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))
                                    .WriteLine("")
                                    'subtotal16 = subtotal16 + s.GenInteres(pcmil)
                                Else
                                    .WriteChars("Capital de " & s.getConcepto & " de promesa")
                                    .GotoSixth(5)
                                    .WriteChars((s.getAbonado - s.GenInteres(pcmil)).ToString("$ ##,##00.00"))

                                    .WriteLine("")
                                    .GotoSixth(1)
                                    .WriteChars("Interés de " & s.getConcepto & " de promesa")
                                    .GotoSixth(5)
                                    .WriteChars((s.GenInteres(pcmil)).ToString("$ ##,##00.00"))
                                    .WriteLine("")
                                    subtotal16 = subtotal16 + s.GenInteres(pcmil)
                                End If

                                If s.getInteres <> 0 Then
                                    .GotoSixth(1)
                                    .WriteChars("Multa de promesa")

                                    .GotoSixth(5)
                                    .WriteChars((s.getInteres).ToString("$ ##,##00.00"))
                                    subtotal16 = subtotal16 + s.getInteres
                                    .WriteLine("")
                                End If
                                totalpago = totalpago + s.getAbonado + s.getInteres
                            Next
                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("Subtotal Tasa 16%")

                            .GotoSixth(5)
                            .WriteChars((subtotal16 / 1.16).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("I.V.A")


                            .GotoSixth(5)
                            .WriteChars(((subtotal16 / 1.16) * 0.16).ToString("$ ##,##00.00"))
                            .WriteLine("")

                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("SubTotal")
                            .GotoSixth(5)
                            .WriteChars((subtotal).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Descuento")
                            .GotoSixth(5)
                            .WriteChars((descuento).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)

                            .WriteChars("Total")
                            .GotoSixth(5)
                            .WriteChars((total).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Recibido")
                            .GotoSixth(5)

                            .WriteChars((recibido).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Cambio")
                            .GotoSixth(5)

                            .WriteChars((cambio).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .DrawLine()
                            .FontSize = 7
                            .GotoSixth(1)

                            Dim StringNumeroLetra As String
                            StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                            Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                            Dim i As Integer = 0
                            Dim nuevostring As String = ""
                            Dim siguientestring As String = ""
                            For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                i += StringNumeroLetraPartido(Palabras).Length + 1
                                .AlignCenter()
                                If i < 56 Then
                                    nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                Else
                                    siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                End If
                            Next
                            .WriteLine(nuevostring)
                            If siguientestring <> "" Then
                                .WriteLine(siguientestring)
                            End If
                            .WriteLine("")
                            .GotoSixth(1)

                            .GotoSixth(1)
                            .Bold = False
                            .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                            .CutPaper()
                            .EndDoc()


                        End With
                    Case "Enganche Motocicleta"
                        With P

                            .AlignCenter()
                            .RTL = False
                            .AlignCenter()
                            .Gotox(1050)
                            .PrintLogo()
                            .GotoSixth(1)
                            .NormalFont()
                            .WriteLine(NombreEmpresa)
                            .WriteLine("")
                            .WriteLine(RFCEmpresa)
                            .FontSize = 8
                            .WriteLine("")
                            .WriteChars("Calle  " & CalleEmpresa & "  No. " & NumeroEmpresa)


                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Colonia" & " " & ColEmpresa)

                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("C.P." & " " & CPEmpresa & " " & CiudadEmpresa & " " & EstadoEmpresa)


                            .WriteLine("")

                            .DrawLine()
                            .GotoSixth(1)
                            .FontSize = 7.3
                            .Bold = True
                            .WriteChars("TICKET:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idrecibo)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CAJA:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(NumeroCaja)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("ATENDIDO POR:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(nombreCajero)
                            .WriteLine("")
                            .Bold = True
                            .GotoSixth(1)
                            .WriteChars("CRÉDITO NO.:")
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars(idcredito)
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .FontSize = 6.3
                            .WriteChars("MONTO DEL CRÉDITO:")
                            .FontSize = 7.3
                            .Bold = False
                            .GotoSixth(3)
                            .WriteChars((monto).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("CLIENTE:")
                            .GotoSixth(3)
                            .Bold = False
                            .FontSize = 6.5
                            .WriteChars(nombreCredito)
                            .FontSize = 7.3
                            .WriteLine("")
                            .GotoSixth(1)
                            .Bold = True
                            .WriteChars("PLAZO(semanas):")
                            .GotoSixth(3)
                            .Bold = False
                            .WriteChars(cp)
                            .WriteLine("")



                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("FECHA Y HORA DE PAGO: ")
                            .Bold = False
                            .WriteChars("  " & fechadepago & " - " & horastring)

                            .WriteLine("")
                            .DrawLine()

                            .GotoSixth(1)
                            .Bold = True

                            .WriteChars("DESCRIPCIÓN")
                            .GotoSixth(5)
                            .WriteChars("MONTO")

                            .WriteLine("")

                            .DrawLine()



                            .GotoSixth(1)
                            .WriteChars("Enganche")

                            .GotoSixth(5)
                            .WriteChars((total / 1.16).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("I.V.A")


                            .GotoSixth(5)
                            .WriteChars(((total / 1.16) * 0.16).ToString("$ ##,##00.00"))
                            .WriteLine("")

                            .DrawLine()

                            .GotoSixth(1)
                            .WriteChars("Total Pagado")
                            .GotoSixth(5)
                            .WriteChars((total).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Recibido")
                            .GotoSixth(5)

                            .WriteChars((recibido).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .WriteChars("Cambio")
                            .GotoSixth(5)

                            .WriteChars((cambio).ToString("$ ##,##00.00"))
                            .WriteLine("")
                            .GotoSixth(1)
                            .DrawLine()
                            .GotoSixth(1)
                            Dim StringNumeroLetra As String
                            StringNumeroLetra = (NumeroLetra.Convertir(total.ToString, True))
                            Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                            Dim i As Integer = 0
                            Dim nuevostring As String = ""
                            Dim siguientestring As String = ""
                            For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                i += StringNumeroLetraPartido(Palabras).Length + 1
                                .AlignCenter()
                                If i < 56 Then
                                    nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                Else
                                    siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                End If
                            Next
                            .WriteLine(nuevostring)
                            If siguientestring <> "" Then
                                .WriteLine(siguientestring)
                            End If
                            .WriteLine("")
                            .GotoSixth(1)

                            .GotoSixth(1)
                            .Bold = False
                            .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                            .CutPaper()
                            .EndDoc()

                        End With

                End Select
        End Select
        Return True

    End Function
End Module
