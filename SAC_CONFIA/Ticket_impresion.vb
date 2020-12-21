Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class Ticket_impresion

    Public total As Double
    Dim totalApagar As Double
    Public idRecibo As Integer
    Dim recibido As Double
    Public nombre_credito As String
    Public cp As Double
    Public idCreditoRecibo As Integer
    Public montocredito As Integer
    Public pcmil As Double
    Dim saldo As Double
    Dim a As DetallePago
    Public array As ArrayList = New ArrayList
    Dim horadepago As String
    Dim fechadePago As String
    Public tipoDoc As Integer
    Public convenio As Integer
    Public cpConvenio As Integer
    Public montoConvenio As Integer
    Public MultasLiquidacion As Double
    Public MontoLiquidacionSmultas As Double
    Public insoluto As Boolean
    Dim descuentoAticket As Double = 0
    Dim descuentoApago As Double = 0
    Public autorizado As Boolean
    Public Concepto As String
    Dim abono As Boolean = False
    Public interesEmpeño As Double
    Public capitalEmpeño As Double
    Public pendienteEmpeño As Double
    Public abonadoEmpeño As Double

    Private Sub Ticket_Comision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTotal.Text = total
        txtTotalApagar.Text = total
        totalApagar = total
        txtRecibido.Text = total
        txtRecibido.Select()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub txtRecibido_OnValueChanged(sender As Object, e As EventArgs) Handles txtRecibido.OnValueChanged
        If txtRecibido.Text = "" Then
            recibido = 0
        Else

            recibido = Convert.ToDouble(txtRecibido.Text)

        End If


        If recibido < totalApagar Then
            txtCambio.Text = 0

        Else
            txtCambio.Text = recibido - Convert.ToDouble(txtTotalApagar.Text)
        End If
    End Sub

    Private Async Sub ImprimeTicketPagoNormalAsync()
        Await Task.Factory.StartNew(Sub()
                                        Dim NumeroLetra As New NumLetra
                                        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
                                        If recibido < totalApagar Then
                                            Cargando.TopMost = False
                                            Cargando.SendToBack()
                                            Me.TopMost = False
                                            Dim result As DialogResult = MessageBox.Show("El pago recibido es menor al total a pagar, ¿Desea agregarlo como abono?",
                                                          "Title",
                                                          MessageBoxButtons.YesNo)


                                            If (result = DialogResult.Yes) Then
                                                abono = True
                                                ' Cargando.ShowDialog()
                                                'Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.Show()
                                                Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.TopMost = True
                                                Dim comandoRecibo As SqlCommand
                                                Dim consultarecibo As String
                                                iniciarconexionempresa()
                                                Dim fechainsercionhasta As String
                                                fechainsercionhasta = Now.Date

                                                Dim fechasqlhasta As Date
                                                fechasqlhasta = fechainsercionhasta
                                                fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                                consultarecibo = "Insert into ticket values('" & recibido & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','1','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & recibido & "') SELECT SCOPE_IDENTITY()"
                                                comandoRecibo = New SqlCommand
                                                comandoRecibo.Connection = conexionempresa
                                                comandoRecibo.CommandText = consultarecibo
                                                idRecibo = comandoRecibo.ExecuteScalar
                                                fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                                horadepago = tiempo

                                                saldo = recibido
                                                Dim interesrecibo As Double = 0
                                                Dim pagonormalrecibo As Double = 0
                                                Me.Invoke(Sub()
                                                              For Each row As DataGridViewRow In inicio.dtimpuestos.Rows

                                                                  Dim c As Boolean
                                                                  c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                                  If c Then

                                                                      If saldo >= row.Cells(7).Value Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          Dim readerinteresesacumulado As SqlDataReader
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) as interes from ticketDetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or TipoDoc=(select id from TipoDoc where Nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          'readerinteresesacumulado = comandointeres.ExecuteReader

                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              Select Case row.Cells(5).Value
                                                                                  Case Is > row.Cells(6).Value
                                                                                      interesesAcumulado = row.Cells(6).Value
                                                                                  Case Else
                                                                                      interesesAcumulado = row.Cells(5).Value
                                                                              End Select
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          'MessageBox.Show(interesesAcumulado)
                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim pagonormal As Double
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          interesrecibo = interesrecibo + interesabono

                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String



                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc=(select id from TipoDoc where Nombre = 'Cancelación de Convenio')) and estado = 'A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar

                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                              totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                          End If
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          consultaAbonado = "Update calendarionormal set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fechaultimopago = '" & fechainsercionhasta & "', convenio = '" & row.Cells(9).Value & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = saldo - row.Cells(7).Value



                                                                      ElseIf saldo < row.Cells(7).Value And saldo > 0 Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc=(select id from TipoDoc where nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              Select Case row.Cells(5).Value
                                                                                  Case Is > row.Cells(6).Value
                                                                                      interesesAcumulado = row.Cells(6).Value
                                                                                  Case Else
                                                                                      interesesAcumulado = row.Cells(5).Value
                                                                              End Select
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim interesAbonar As Double
                                                                          Dim saldoAbono As Double
                                                                          Dim pagonormal As Double
                                                                          Dim pagonormalAbonar As Double
                                                                          saldoAbono = saldo
                                                                          interesAbonar = interesabono - saldo
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          ' If saldo > pagonormal Then
                                                                          'pagonormalAbonar = pagonormal
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'Else
                                                                          'pagonormalAbonar = saldo
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'End If

                                                                          If saldo > interesabono Then
                                                                              interesAbonar = interesabono
                                                                              saldoAbono = saldoAbono - interesAbonar
                                                                          Else
                                                                              interesAbonar = saldo
                                                                              saldoAbono = saldoAbono - interesAbonar

                                                                          End If

                                                                          'interesAbonar = saldoAbono
                                                                          ' MessageBox.Show(interesesAcumulado)

                                                                          pagonormal = saldoAbono

                                                                          interesrecibo = interesrecibo + interesAbonar
                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','" & idRecibo & "','" & interesAbonar & "','" & pagonormal & "','Abono','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String
                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc=(select id from TipoDoc where Nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar
                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, saldo, interesAbonar, totalAbonado, pagonormal, pagonormal, "Abono", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          Dim restante As Double
                                                                          restante = row.Cells(7).Value - saldo
                                                                          consultaAbonado = "Update calendarioNormal set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fechaultimopago = '" & fechainsercionhasta & "', convenio = '" & row.Cells(9).Value & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = 0

                                                                      Else
                                                                          Exit For
                                                                      End If
                                                                  End If
                                                              Next
                                                          End Sub)

                                                Dim ComandoActRecibo As SqlCommand
                                                Dim consultaActRecibo As String
                                                ComandoActRecibo = New SqlCommand

                                                consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                                ComandoActRecibo.Connection = conexionempresa
                                                ComandoActRecibo.CommandText = consultaActRecibo
                                                ComandoActRecibo.ExecuteNonQuery()
                                                ' MessageBox.Show("listo")
                                                '  Principal.BackgroundWorker1.RunWorkerAsync()
                                                '  Me.Close()

                                            Else
                                                abono = False
                                                Exit Sub
                                            End If
                                        Else
                                            abono = False
                                            Cargando.Show()
                                            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                            Cargando.TopMost = True
                                            Dim comandoRecibo As SqlCommand
                                            Dim consultarecibo As String
                                            iniciarconexionempresa()
                                            Dim fechainsercionhasta As String
                                            fechainsercionhasta = Now.Date

                                            Dim fechasqlhasta As Date
                                            fechasqlhasta = fechainsercionhasta
                                            fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                            consultarecibo = "Insert into ticket values('" & totalApagar & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','1','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
                                            comandoRecibo = New SqlCommand
                                            comandoRecibo.Connection = conexionempresa
                                            comandoRecibo.CommandText = consultarecibo
                                            'comandoRecibo.ExecuteNonQuery()
                                            idRecibo = comandoRecibo.ExecuteScalar
                                            fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                            horadepago = tiempo


                                            Dim pagados As String


                                            saldo = total
                                            Dim interesrecibo As Double = 0
                                            Dim pagonormalrecibo As Double = 0
                                            Me.Invoke(Sub()
                                                          For Each row As DataGridViewRow In inicio.dtimpuestos.Rows
                                                              Dim c As Boolean
                                                              c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                              If c Then

                                                                  If saldo >= row.Cells(7).Value Then
                                                                      Dim comandointeres As SqlCommand
                                                                      Dim consultaintereses As String
                                                                      Dim interesesAcumulado As Double
                                                                      Dim readerinteresesacumulado As SqlDataReader
                                                                      comandointeres = New SqlCommand
                                                                      consultaintereses = "select sum(intereses) as interes from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc =(select id from TipoDoc where Nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                      comandointeres.Connection = conexionempresa
                                                                      comandointeres.CommandText = consultaintereses
                                                                      'readerinteresesacumulado = comandointeres.ExecuteReader
                                                                      If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                          Select Case row.Cells(5).Value
                                                                              Case Is > row.Cells(6).Value
                                                                                  interesesAcumulado = row.Cells(6).Value
                                                                              Case Else
                                                                                  interesesAcumulado = row.Cells(5).Value
                                                                          End Select
                                                                      Else
                                                                          interesesAcumulado = comandointeres.ExecuteScalar
                                                                      End If

                                                                      Dim interesabono As Double
                                                                      interesabono = row.Cells(5).Value - interesesAcumulado
                                                                      Dim pagonormal As Double
                                                                      pagonormal = row.Cells(7).Value - interesabono

                                                                      interesrecibo = interesrecibo + interesabono

                                                                      pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                      Dim consultaAbono As String
                                                                      consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                      Dim comandoInsertAbono As SqlCommand
                                                                      comandoInsertAbono = New SqlCommand
                                                                      comandoInsertAbono.Connection = conexionempresa
                                                                      comandoInsertAbono.CommandText = consultaAbono
                                                                      comandoInsertAbono.ExecuteNonQuery()





                                                                      Dim comandoAbono As SqlCommand
                                                                      comandoAbono = New SqlCommand
                                                                      Dim consultaAbonar As String
                                                                      consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc = (select id from TipoDoc where Nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                      Dim totalAbonado As String
                                                                      comandoAbono.Connection = conexionempresa
                                                                      comandoAbono.CommandText = consultaAbonar
                                                                      totalAbonado = comandoAbono.ExecuteScalar


                                                                      a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                      array.Add(a)
                                                                      If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                          totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                      End If
                                                                      Dim comandoAbonado As SqlCommand
                                                                      comandoAbonado = New SqlCommand
                                                                      Dim consultaAbonado As String
                                                                      consultaAbonado = "Update calendarionormal set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fechaultimopago = '" & fechainsercionhasta & "', convenio = '" & row.Cells(9).Value & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                      comandoAbonado.Connection = conexionempresa
                                                                      comandoAbonado.CommandText = consultaAbonado
                                                                      comandoAbonado.ExecuteNonQuery()

                                                                      saldo = saldo - row.Cells(7).Value
                                                                  Else
                                                                      Exit For
                                                                  End If

                                                                  ' If saldo < row.Cells(8).Value And saldo > 0 Then
                                                                  'Dim consultaAbono As String
                                                                  'consultaAbono = "Insert into abonosext(idpago,fecha,monto,comprobante,idRecibo) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','','" & idRecibo & "')"
                                                                  'Dim comandoInsertAbono As OleDb.OleDbCommand
                                                                  'comandoInsertAbono = New OleDb.OleDbCommand
                                                                  'comandoInsertAbono.Connection = conexionempresa
                                                                  'comandoInsertAbono.CommandText = consultaAbono
                                                                  'comandoInsertAbono.ExecuteNonQuery()
                                                                  'Dim comandoAbono As OleDb.OleDbCommand
                                                                  'comandoAbono = New OleDb.OleDbCommand
                                                                  '  Dim consultaAbonar As String
                                                                  'consultaAbonar = "select sum(monto) as total from abonosext where idpago = '" & row.Cells(1).Value & "'"
                                                                  'Dim totalAbonado As String
                                                                  'comandoAbono.Connection = conexionempresa
                                                                  'comandoAbono.CommandText = consultaAbonar
                                                                  'totalAbonado = comandoAbono.ExecuteScalar
                                                                  'a = New DetallePago(row.Cells(1).Value, row.Cells(5).Value, saldo, row.Cells(6).Value, totalAbonado, row.Cells(8).Value, saldo, "Abono")
                                                                  'array.Add(a)
                                                                  '  Dim comandoAbonado As OleDb.OleDbCommand
                                                                  'comandoAbonado = New OleDb.OleDbCommand
                                                                  'Dim consultaAbonado As String
                                                                  'Dim restante As Double
                                                                  'restante = row.Cells(8).Value - saldo
                                                                  'consultaAbonado = "Update pagosext set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fecha = '" & fechainsercionhasta & "', convenio = '" & row.Cells(10).Value & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                  'comandoAbonado.Connection = conexionempresa
                                                                  'comandoAbonado.CommandText = consultaAbonado
                                                                  'comandoAbonado.ExecuteNonQuery()

                                                                  ' saldo = saldo - row.Cells(8).Value
                                                                  'End If
                                                              End If
                                                          Next
                                                      End Sub)

                                            Dim ComandoActRecibo As SqlCommand
                                            Dim consultaActRecibo As String
                                            ComandoActRecibo = New SqlCommand

                                            consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                            ComandoActRecibo.Connection = conexionempresa
                                            ComandoActRecibo.CommandText = consultaActRecibo
                                            ComandoActRecibo.ExecuteNonQuery()
                                            ' MessageBox.Show("listo")
                                            'Principal.BackgroundWorker1.RunWorkerAsync()
                                            '  Me.Close()

                                        End If
                                        'conexionempresa.Close()
                                        'iniciarconexionempresa()
                                        Dim comandoAtraso As SqlCommand
                                        Dim consultaAtraso As String
                                        Dim atraso As Double
                                        consultaAtraso = "select sum(pendiente) from calendarionormal where id_Credito = '" & idCreditoRecibo & "' and estado = 'V'"
                                        comandoAtraso = New SqlCommand
                                        comandoAtraso.Connection = conexionempresa
                                        comandoAtraso.CommandText = consultaAtraso
                                        Try
                                            If IsDBNull(comandoAtraso.ExecuteScalar) Then
                                                atraso = 0
                                            Else
                                                atraso = comandoAtraso.ExecuteScalar
                                            End If
                                        Catch ex As InvalidOperationException
                                            iniciarconexionempresa()

                                            If IsDBNull(comandoAtraso.ExecuteScalar) Then
                                                atraso = 0
                                            Else
                                                atraso = comandoAtraso.ExecuteScalar
                                            End If
                                        End Try


                                        Dim pagosemana As Double
                                        pagosemana = (montocredito / 1000) * pcmil


                                        Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
                                        For copy As Integer = 1 To 2
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
                                                .WriteChars(idRecibo)
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
                                                .WriteChars("CRÉDITO NO.:")
                                                .Bold = False
                                                .GotoSixth(3)
                                                .WriteChars(idCreditoRecibo)
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .FontSize = 6.3
                                                .WriteChars("MONTO DEL CRÉDITO:")
                                                .Bold = False
                                                .FontSize = 7.3
                                                .GotoSixth(3)
                                                .WriteChars((montocredito).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .WriteChars("CLIENTE:")
                                                .GotoSixth(3)
                                                .Bold = False
                                                .FontSize = 6.5
                                                .WriteChars(nombre_credito)
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .FontSize = 7.3
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
                                                '.FontSize = 
                                                .WriteChars("FECHA Y HORA DE PAGO:  ")
                                                .Bold = False

                                                .WriteChars("  " & fechadePago & " - " & horadepago)

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
                                                .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)

                                                .WriteChars("Descuento")
                                                .GotoSixth(5)
                                                .WriteChars((descuentoAticket).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)

                                                .WriteChars("Total")
                                                .GotoSixth(5)
                                                If abono Then
                                                    .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                Else
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))

                                                End If

                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Recibido")
                                                .GotoSixth(5)
                                                Dim recibido As Double
                                                recibido = Convert.ToDouble(txtRecibido.Text)
                                                .WriteChars((recibido).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Cambio")
                                                .GotoSixth(5)
                                                Dim cambio As Double
                                                If txtCambio.Text = "" Then
                                                    cambio = 0
                                                Else
                                                    cambio = Convert.ToDouble(txtCambio.Text)
                                                End If
                                                .WriteChars((cambio).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .DrawLine()
                                                .GotoSixth(1)
                                                Dim StringNumeroLetra As String
                                                If abono Then
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalpago.ToString, True))
                                                Else
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalApagar.ToString, True))
                                                End If

                                                Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                                                Dim i As Integer = 0
                                                Dim nuevostring As String = ""
                                                Dim siguientestring As String = ""
                                                For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                                    i += StringNumeroLetraPartido(Palabras).Length + 1
                                                    .AlignCenter()
                                                    If i < 56 Then
                                                        nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                                        '.WriteChars(StringNumeroLetraPartido(Palabras))
                                                        ' .WriteChars(" ")
                                                        '.Gotox(i * 70)
                                                    Else
                                                        siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                                        '.WriteLine("")
                                                        '.GotoSixth(1)
                                                        '.WriteChars(StringNumeroLetraPartido(Palabras))
                                                    End If
                                                Next
                                                .WriteLine(nuevostring)
                                                If siguientestring <> "" Then
                                                    .WriteLine(siguientestring)
                                                End If

                                                If atraso = 0 Then
                                                    .Bold = True
                                                    .WriteLine("")
                                                    .WriteLine("CUENTA AL CORRIENTE")
                                                    .WriteLine("")
                                                Else
                                                    .Bold = True
                                                    .WriteLine("")
                                                    .WriteLine("CUENTA EN ATRASO, PUEDE PONERSE AL CORRIENTE CON:")

                                                    '.WriteLine("")
                                                    .WriteLine((atraso).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                End If
                                                .GotoSixth(1)
                                                .Bold = False
                                                .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                                                .CutPaper()
                                                .EndDoc()

                                            End With

                                        Next
                                        Me.Invoke(Sub()
                                                      ' Principal.idAnterior = idCreditoRecibo
                                                      inicio.BackgroundWorker1.RunWorkerAsync()
                                                  End Sub)
                                        ' PanelConsultando.Visible = False
                                        'FlatButton1.Enabled = True
                                        Cargando.Close()
                                        Me.Close()
                                    End Sub)

    End Sub
    Private Async Sub ImprimeTicketPagoPromesaAsync()
        Await Task.Factory.StartNew(Sub()
                                        Dim NumeroLetra As New NumLetra
                                        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
                                        If recibido < totalApagar Then
                                            Cargando.TopMost = False
                                            Cargando.SendToBack()
                                            Me.TopMost = False
                                            Dim result As DialogResult = MessageBox.Show("El pago recibido es menor al total a pagar, ¿Desea agregarlo como abono?",
                                                          "Title",
                                                          MessageBoxButtons.YesNo)


                                            If (result = DialogResult.Yes) Then
                                                abono = True
                                                ' Cargando.ShowDialog()
                                                'Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.Show()
                                                Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.TopMost = True
                                                Dim comandoRecibo As SqlCommand
                                                Dim consultarecibo As String
                                                iniciarconexionempresa()
                                                Dim fechainsercionhasta As String
                                                fechainsercionhasta = Now.Date

                                                Dim fechasqlhasta As Date
                                                fechasqlhasta = fechainsercionhasta
                                                fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                                consultarecibo = "Insert into ticket values('" & recibido & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & recibido & "') SELECT SCOPE_IDENTITY()"
                                                comandoRecibo = New SqlCommand
                                                comandoRecibo.Connection = conexionempresa
                                                comandoRecibo.CommandText = consultarecibo
                                                idRecibo = comandoRecibo.ExecuteScalar
                                                fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                                horadepago = tiempo

                                                saldo = recibido
                                                Dim interesrecibo As Double = 0
                                                Dim pagonormalrecibo As Double = 0
                                                Me.Invoke(Sub()
                                                              For Each row As DataGridViewRow In inicio.dtimpuestos.Rows

                                                                  Dim c As Boolean
                                                                  c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                                  If c Then

                                                                      If saldo >= row.Cells(7).Value Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          Dim readerinteresesacumulado As SqlDataReader
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) as interes from ticketDetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or TipoDoc=(select id from TipoDoc where Nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          'readerinteresesacumulado = comandointeres.ExecuteReader

                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              Select Case row.Cells(5).Value
                                                                                  Case Is > row.Cells(6).Value
                                                                                      interesesAcumulado = row.Cells(6).Value
                                                                                  Case Else
                                                                                      interesesAcumulado = row.Cells(5).Value
                                                                              End Select
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          'MessageBox.Show(interesesAcumulado)
                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim pagonormal As Double
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          interesrecibo = interesrecibo + interesabono

                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String



                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc=(select id from TipoDoc where Nombre = 'Cancelación de Convenio')) and estado = 'A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar

                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                              totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                          End If
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          consultaAbonado = "Update promesadepago set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fechaultimopago = '" & fechainsercionhasta & "' where id = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = saldo - row.Cells(7).Value



                                                                      ElseIf saldo < row.Cells(7).Value And saldo > 0 Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc=(select id from TipoDoc where nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              Select Case row.Cells(5).Value
                                                                                  Case Is > row.Cells(6).Value
                                                                                      interesesAcumulado = row.Cells(6).Value
                                                                                  Case Else
                                                                                      interesesAcumulado = row.Cells(5).Value
                                                                              End Select
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim interesAbonar As Double
                                                                          Dim saldoAbono As Double
                                                                          Dim pagonormal As Double
                                                                          Dim pagonormalAbonar As Double
                                                                          saldoAbono = saldo
                                                                          interesAbonar = interesabono - saldo
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          ' If saldo > pagonormal Then
                                                                          'pagonormalAbonar = pagonormal
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'Else
                                                                          'pagonormalAbonar = saldo
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'End If

                                                                          If saldo > interesabono Then
                                                                              interesAbonar = interesabono
                                                                              saldoAbono = saldoAbono - interesAbonar
                                                                          Else
                                                                              interesAbonar = saldo
                                                                              saldoAbono = saldoAbono - interesAbonar

                                                                          End If

                                                                          'interesAbonar = saldoAbono
                                                                          ' MessageBox.Show(interesesAcumulado)

                                                                          pagonormal = saldoAbono

                                                                          interesrecibo = interesrecibo + interesAbonar
                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','" & idRecibo & "','" & interesAbonar & "','" & pagonormal & "','Abono','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String
                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc=(select id from TipoDoc where Nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar
                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, saldo, interesAbonar, totalAbonado, pagonormal, pagonormal, "Abono", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          Dim restante As Double
                                                                          restante = row.Cells(7).Value - saldo
                                                                          consultaAbonado = "Update promesadepago set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fechaultimopago = '" & fechainsercionhasta & "' where id = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = 0

                                                                      Else
                                                                          Exit For
                                                                      End If
                                                                  End If
                                                              Next
                                                          End Sub)

                                                Dim ComandoActRecibo As SqlCommand
                                                Dim consultaActRecibo As String
                                                ComandoActRecibo = New SqlCommand

                                                consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                                ComandoActRecibo.Connection = conexionempresa
                                                ComandoActRecibo.CommandText = consultaActRecibo
                                                ComandoActRecibo.ExecuteNonQuery()
                                                ' MessageBox.Show("listo")
                                                '  Principal.BackgroundWorker1.RunWorkerAsync()
                                                '  Me.Close()

                                            Else
                                                abono = False
                                                Exit Sub
                                            End If
                                        Else
                                            abono = False
                                            Cargando.Show()
                                            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                            Cargando.TopMost = True
                                            Dim comandoRecibo As SqlCommand
                                            Dim consultarecibo As String
                                            iniciarconexionempresa()
                                            Dim fechainsercionhasta As String
                                            fechainsercionhasta = Now.Date

                                            Dim fechasqlhasta As Date
                                            fechasqlhasta = fechainsercionhasta
                                            fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                            consultarecibo = "Insert into ticket values('" & totalApagar & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
                                            comandoRecibo = New SqlCommand
                                            comandoRecibo.Connection = conexionempresa
                                            comandoRecibo.CommandText = consultarecibo
                                            'comandoRecibo.ExecuteNonQuery()
                                            idRecibo = comandoRecibo.ExecuteScalar
                                            fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                            horadepago = tiempo


                                            Dim pagados As String


                                            saldo = total
                                            Dim interesrecibo As Double = 0
                                            Dim pagonormalrecibo As Double = 0
                                            Me.Invoke(Sub()
                                                          For Each row As DataGridViewRow In inicio.dtimpuestos.Rows
                                                              Dim c As Boolean
                                                              c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                              If c Then

                                                                  If saldo >= row.Cells(7).Value Then
                                                                      Dim comandointeres As SqlCommand
                                                                      Dim consultaintereses As String
                                                                      Dim interesesAcumulado As Double
                                                                      Dim readerinteresesacumulado As SqlDataReader
                                                                      comandointeres = New SqlCommand
                                                                      consultaintereses = "select sum(intereses) as interes from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc =(select id from TipoDoc where Nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                      comandointeres.Connection = conexionempresa
                                                                      comandointeres.CommandText = consultaintereses
                                                                      'readerinteresesacumulado = comandointeres.ExecuteReader
                                                                      If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                          Select Case row.Cells(5).Value
                                                                              Case Is > row.Cells(6).Value
                                                                                  interesesAcumulado = row.Cells(6).Value
                                                                              Case Else
                                                                                  interesesAcumulado = row.Cells(5).Value
                                                                          End Select
                                                                      Else
                                                                          interesesAcumulado = comandointeres.ExecuteScalar
                                                                      End If

                                                                      Dim interesabono As Double
                                                                      interesabono = row.Cells(5).Value - interesesAcumulado
                                                                      Dim pagonormal As Double
                                                                      pagonormal = row.Cells(7).Value - interesabono

                                                                      interesrecibo = interesrecibo + interesabono

                                                                      pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                      Dim consultaAbono As String
                                                                      consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                      Dim comandoInsertAbono As SqlCommand
                                                                      comandoInsertAbono = New SqlCommand
                                                                      comandoInsertAbono.Connection = conexionempresa
                                                                      comandoInsertAbono.CommandText = consultaAbono
                                                                      comandoInsertAbono.ExecuteNonQuery()





                                                                      Dim comandoAbono As SqlCommand
                                                                      comandoAbono = New SqlCommand
                                                                      Dim consultaAbonar As String
                                                                      consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and (tipodoc = '" & tipoDoc & "' or tipodoc = (select id from TipoDoc where Nombre='Cancelación de Convenio')) and estado = 'A'"
                                                                      Dim totalAbonado As String
                                                                      comandoAbono.Connection = conexionempresa
                                                                      comandoAbono.CommandText = consultaAbonar
                                                                      totalAbonado = comandoAbono.ExecuteScalar


                                                                      a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                      array.Add(a)
                                                                      If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                          totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                      End If
                                                                      Dim comandoAbonado As SqlCommand
                                                                      comandoAbonado = New SqlCommand
                                                                      Dim consultaAbonado As String
                                                                      consultaAbonado = "Update promesadepago set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fechaultimopago = '" & fechainsercionhasta & "' where id = '" & row.Cells(1).Value & "'"
                                                                      comandoAbonado.Connection = conexionempresa
                                                                      comandoAbonado.CommandText = consultaAbonado
                                                                      comandoAbonado.ExecuteNonQuery()

                                                                      saldo = saldo - row.Cells(7).Value
                                                                  Else
                                                                      Exit For
                                                                  End If

                                                                  ' If saldo < row.Cells(8).Value And saldo > 0 Then
                                                                  'Dim consultaAbono As String
                                                                  'consultaAbono = "Insert into abonosext(idpago,fecha,monto,comprobante,idRecibo) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','','" & idRecibo & "')"
                                                                  'Dim comandoInsertAbono As OleDb.OleDbCommand
                                                                  'comandoInsertAbono = New OleDb.OleDbCommand
                                                                  'comandoInsertAbono.Connection = conexionempresa
                                                                  'comandoInsertAbono.CommandText = consultaAbono
                                                                  'comandoInsertAbono.ExecuteNonQuery()
                                                                  'Dim comandoAbono As OleDb.OleDbCommand
                                                                  'comandoAbono = New OleDb.OleDbCommand
                                                                  '  Dim consultaAbonar As String
                                                                  'consultaAbonar = "select sum(monto) as total from abonosext where idpago = '" & row.Cells(1).Value & "'"
                                                                  'Dim totalAbonado As String
                                                                  'comandoAbono.Connection = conexionempresa
                                                                  'comandoAbono.CommandText = consultaAbonar
                                                                  'totalAbonado = comandoAbono.ExecuteScalar
                                                                  'a = New DetallePago(row.Cells(1).Value, row.Cells(5).Value, saldo, row.Cells(6).Value, totalAbonado, row.Cells(8).Value, saldo, "Abono")
                                                                  'array.Add(a)
                                                                  '  Dim comandoAbonado As OleDb.OleDbCommand
                                                                  'comandoAbonado = New OleDb.OleDbCommand
                                                                  'Dim consultaAbonado As String
                                                                  'Dim restante As Double
                                                                  'restante = row.Cells(8).Value - saldo
                                                                  'consultaAbonado = "Update pagosext set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fecha = '" & fechainsercionhasta & "', convenio = '" & row.Cells(10).Value & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                  'comandoAbonado.Connection = conexionempresa
                                                                  'comandoAbonado.CommandText = consultaAbonado
                                                                  'comandoAbonado.ExecuteNonQuery()

                                                                  ' saldo = saldo - row.Cells(8).Value
                                                                  'End If
                                                              End If
                                                          Next
                                                      End Sub)

                                            Dim ComandoActRecibo As SqlCommand
                                            Dim consultaActRecibo As String
                                            ComandoActRecibo = New SqlCommand

                                            consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                            ComandoActRecibo.Connection = conexionempresa
                                            ComandoActRecibo.CommandText = consultaActRecibo
                                            ComandoActRecibo.ExecuteNonQuery()
                                            ' MessageBox.Show("listo")
                                            'Principal.BackgroundWorker1.RunWorkerAsync()
                                            '  Me.Close()

                                        End If
                                        'conexionempresa.Close()
                                        'iniciarconexionempresa()



                                        Dim pagosemana As Double
                                        pagosemana = (montocredito / 1000) * pcmil


                                        Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
                                        For copy As Integer = 1 To 2
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
                                                .WriteChars(idRecibo)
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
                                                .WriteChars("CRÉDITO NO.:")
                                                .Bold = False
                                                .GotoSixth(3)
                                                .WriteChars(idCreditoRecibo)
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .FontSize = 6.3
                                                .WriteChars("MONTO DEL CRÉDITO:")
                                                .Bold = False
                                                .FontSize = 7.3
                                                .GotoSixth(3)
                                                .WriteChars((montocredito).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .WriteChars("CLIENTE:")
                                                .GotoSixth(3)
                                                .Bold = False
                                                .FontSize = 6.5
                                                .WriteChars(nombre_credito)
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .FontSize = 7.3
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
                                                '.FontSize = 
                                                .WriteChars("FECHA Y HORA DE PAGO:  ")
                                                .Bold = False

                                                .WriteChars("  " & fechadePago & " - " & horadepago)

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
                                                        .WriteChars("Capital de " & s.getConcepto & " de promesa ")
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
                                                .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)

                                                .WriteChars("Descuento")
                                                .GotoSixth(5)
                                                .WriteChars((descuentoAticket).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)

                                                .WriteChars("Total")
                                                .GotoSixth(5)
                                                If abono Then
                                                    .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                Else
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))

                                                End If

                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Recibido")
                                                .GotoSixth(5)
                                                Dim recibido As Double
                                                recibido = Convert.ToDouble(txtRecibido.Text)
                                                .WriteChars((recibido).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Cambio")
                                                .GotoSixth(5)
                                                Dim cambio As Double
                                                If txtCambio.Text = "" Then
                                                    cambio = 0
                                                Else
                                                    cambio = Convert.ToDouble(txtCambio.Text)
                                                End If
                                                .WriteChars((cambio).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .DrawLine()
                                                .GotoSixth(1)
                                                Dim StringNumeroLetra As String
                                                If abono Then
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalpago.ToString, True))
                                                Else
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalApagar.ToString, True))
                                                End If

                                                Dim StringNumeroLetraPartido() As String = Split(StringNumeroLetra)
                                                Dim i As Integer = 0
                                                Dim nuevostring As String = ""
                                                Dim siguientestring As String = ""
                                                For Palabras As Integer = 0 To StringNumeroLetraPartido.Length - 1
                                                    i += StringNumeroLetraPartido(Palabras).Length + 1
                                                    .AlignCenter()
                                                    If i < 56 Then
                                                        nuevostring = nuevostring & StringNumeroLetraPartido(Palabras) & " "
                                                        '.WriteChars(StringNumeroLetraPartido(Palabras))
                                                        ' .WriteChars(" ")
                                                        '.Gotox(i * 70)
                                                    Else
                                                        siguientestring = siguientestring & StringNumeroLetraPartido(Palabras) & " "
                                                        '.WriteLine("")
                                                        '.GotoSixth(1)
                                                        '.WriteChars(StringNumeroLetraPartido(Palabras))
                                                    End If
                                                Next
                                                .WriteLine(nuevostring)
                                                If siguientestring <> "" Then
                                                    .WriteLine(siguientestring)
                                                End If


                                                .GotoSixth(1)
                                                .Bold = False
                                                .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                                                .CutPaper()
                                                .EndDoc()

                                            End With

                                        Next
                                        Me.Invoke(Sub()
                                                      ' Principal.idAnterior = idCreditoRecibo
                                                      inicio.BackgroundWorker1.RunWorkerAsync()
                                                  End Sub)
                                        ' PanelConsultando.Visible = False
                                        'FlatButton1.Enabled = True
                                        Cargando.Close()
                                        Me.Close()
                                    End Sub)

    End Sub
    Private Async Sub ImprimeTicketPagoLegalAsync()
        Await Task.Factory.StartNew(Sub()
                                        Dim NumeroLetra As New NumLetra
                                        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
                                        If recibido < totalApagar Then
                                            Cargando.TopMost = False
                                            Cargando.SendToBack()
                                            Me.TopMost = False
                                            Dim result As DialogResult = MessageBox.Show("El pago recibido es menor al total a pagar, ¿Desea agregarlo como abono?",
                                                          "Title",
                                                          MessageBoxButtons.YesNo)

                                            If (result = DialogResult.Yes) Then
                                                abono = True
                                                ' Cargando.ShowDialog()
                                                'Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.Show()
                                                Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.TopMost = True
                                                Dim comandoRecibo As SqlCommand
                                                Dim consultarecibo As String
                                                iniciarconexionempresa()
                                                Dim fechainsercionhasta As String
                                                fechainsercionhasta = Now.Date

                                                Dim fechasqlhasta As Date
                                                fechasqlhasta = fechainsercionhasta
                                                fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                                consultarecibo = "Insert into ticket values('" & recibido & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & recibido & "') SELECT SCOPE_IDENTITY()"
                                                comandoRecibo = New SqlCommand
                                                comandoRecibo.Connection = conexionempresa
                                                comandoRecibo.CommandText = consultarecibo
                                                idRecibo = comandoRecibo.ExecuteScalar
                                                'comandoRecibo.ExecuteNonQuery()
                                                fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                                horadepago = tiempo
                                                ' Dim comandoIdRecibo As OleDb.OleDbCommand
                                                'Dim consultaIdRecibo As String
                                                '  consultaIdRecibo = "Select top 1 idRecibo from recibos order by idRecibo desc "
                                                ' comandoIdRecibo = New OleDb.OleDbCommand
                                                ' comandoIdRecibo.Connection = conexionempresa
                                                'comandoIdRecibo.CommandText = consultaIdRecibo
                                                'idRecibo = comandoIdRecibo.ExecuteScalar

                                                saldo = recibido
                                                Dim interesrecibo As Double = 0
                                                Dim pagonormalrecibo As Double = 0
                                                Me.Invoke(Sub()
                                                              For Each row As DataGridViewRow In inicio.dtimpuestos.Rows

                                                                  Dim c As Boolean
                                                                  c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                                  If c Then

                                                                      If saldo >= row.Cells(7).Value Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          Dim readerinteresesacumulado As SqlDataReader
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) as interes from ticketDetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado= 'A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          'readerinteresesacumulado = comandointeres.ExecuteReader
                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              interesesAcumulado = 0
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          'MessageBox.Show(interesesAcumulado)
                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim pagonormal As Double
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          interesrecibo = interesrecibo + interesabono

                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String



                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar

                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                              totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                          End If
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          consultaAbonado = "Update CalendarioLegales set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fechaultimopago = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = saldo - row.Cells(7).Value



                                                                      ElseIf saldo < row.Cells(7).Value And saldo > 0 Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              interesesAcumulado = 0
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim interesAbonar As Double
                                                                          Dim saldoAbono As Double
                                                                          Dim pagonormal As Double
                                                                          Dim pagonormalAbonar As Double
                                                                          saldoAbono = saldo
                                                                          interesAbonar = interesabono - saldo
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          ' If saldo > pagonormal Then
                                                                          'pagonormalAbonar = pagonormal
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'Else
                                                                          'pagonormalAbonar = saldo
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'End If

                                                                          If saldo > interesabono Then
                                                                              interesAbonar = interesabono
                                                                              saldoAbono = saldoAbono - interesAbonar
                                                                          Else
                                                                              interesAbonar = saldo
                                                                              saldoAbono = saldoAbono - interesAbonar

                                                                          End If

                                                                          'interesAbonar = saldoAbono
                                                                          ' MessageBox.Show(interesesAcumulado)

                                                                          pagonormal = saldoAbono

                                                                          interesrecibo = interesrecibo + interesAbonar
                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','" & idRecibo & "','" & interesAbonar & "','" & pagonormal & "','Abono','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String
                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar
                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, saldo, interesAbonar, totalAbonado, pagonormal, pagonormal, "Abono", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          Dim restante As Double
                                                                          restante = row.Cells(7).Value - saldo
                                                                          consultaAbonado = "Update calendarioLegales set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fechaultimopago = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = 0

                                                                      Else
                                                                          Exit For
                                                                      End If
                                                                  End If
                                                              Next
                                                          End Sub)

                                                Dim ComandoActRecibo As SqlCommand
                                                Dim consultaActRecibo As String
                                                ComandoActRecibo = New SqlCommand

                                                consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                                ComandoActRecibo.Connection = conexionempresa
                                                ComandoActRecibo.CommandText = consultaActRecibo
                                                ComandoActRecibo.ExecuteNonQuery()
                                                ' MessageBox.Show("listo")
                                                '  Principal.BackgroundWorker1.RunWorkerAsync()
                                                '  Me.Close()

                                            Else
                                                abono = False
                                                Exit Sub
                                            End If
                                        Else
                                            abono = False
                                            Cargando.Show()
                                            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                            Cargando.TopMost = True
                                            Dim comandoRecibo As SqlCommand
                                            Dim consultarecibo As String
                                            iniciarconexionempresa()
                                            Dim fechainsercionhasta As String
                                            fechainsercionhasta = Now.Date

                                            Dim fechasqlhasta As Date
                                            fechasqlhasta = fechainsercionhasta
                                            fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                            consultarecibo = "Insert into ticket values('" & totalApagar & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
                                            comandoRecibo = New SqlCommand
                                            comandoRecibo.Connection = conexionempresa
                                            comandoRecibo.CommandText = consultarecibo
                                            'comandoRecibo.ExecuteNonQuery()
                                            idRecibo = comandoRecibo.ExecuteScalar
                                            fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                            horadepago = tiempo

                                            ' Dim comandoIdRecibo As OleDb.OleDbCommand
                                            'Dim consultaIdRecibo As String
                                            ' consultaIdRecibo = "Select top 1 idRecibo from recibos order by idRecibo desc "
                                            ' comandoIdRecibo = New OleDb.OleDbCommand
                                            ' comandoIdRecibo.Connection = conexionempresa
                                            ' comandoIdRecibo.CommandText = consultaIdRecibo
                                            'idRecibo = comandoIdRecibo.ExecuteScalar


                                            Dim pagados As String


                                            saldo = total
                                            Dim interesrecibo As Double = 0
                                            Dim pagonormalrecibo As Double = 0
                                            Me.Invoke(Sub()
                                                          For Each row As DataGridViewRow In inicio.dtimpuestos.Rows
                                                              Dim c As Boolean
                                                              c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                              If c Then

                                                                  If saldo >= row.Cells(7).Value Then
                                                                      Dim comandointeres As SqlCommand
                                                                      Dim consultaintereses As String
                                                                      Dim interesesAcumulado As Double
                                                                      Dim readerinteresesacumulado As SqlDataReader
                                                                      comandointeres = New SqlCommand
                                                                      consultaintereses = "select sum(intereses) as interes from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                      comandointeres.Connection = conexionempresa
                                                                      comandointeres.CommandText = consultaintereses
                                                                      'readerinteresesacumulado = comandointeres.ExecuteReader
                                                                      If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                          interesesAcumulado = 0
                                                                      Else
                                                                          interesesAcumulado = comandointeres.ExecuteScalar
                                                                      End If

                                                                      'MessageBox.Show(interesesAcumulado)
                                                                      Dim interesabono As Double
                                                                      interesabono = row.Cells(5).Value - interesesAcumulado
                                                                      Dim pagonormal As Double
                                                                      pagonormal = row.Cells(7).Value - interesabono

                                                                      interesrecibo = interesrecibo + interesabono

                                                                      pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                      Dim consultaAbono As String
                                                                      consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                      Dim comandoInsertAbono As SqlCommand
                                                                      comandoInsertAbono = New SqlCommand
                                                                      comandoInsertAbono.Connection = conexionempresa
                                                                      comandoInsertAbono.CommandText = consultaAbono
                                                                      comandoInsertAbono.ExecuteNonQuery()





                                                                      Dim comandoAbono As SqlCommand
                                                                      comandoAbono = New SqlCommand
                                                                      Dim consultaAbonar As String
                                                                      consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                      Dim totalAbonado As String
                                                                      comandoAbono.Connection = conexionempresa
                                                                      comandoAbono.CommandText = consultaAbonar
                                                                      totalAbonado = comandoAbono.ExecuteScalar


                                                                      a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                      array.Add(a)
                                                                      If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                          totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                      End If
                                                                      Dim comandoAbonado As SqlCommand
                                                                      comandoAbonado = New SqlCommand
                                                                      Dim consultaAbonado As String
                                                                      consultaAbonado = "Update calendarioLegales set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fechaultimopago = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                      comandoAbonado.Connection = conexionempresa
                                                                      comandoAbonado.CommandText = consultaAbonado
                                                                      comandoAbonado.ExecuteNonQuery()

                                                                      saldo = saldo - row.Cells(7).Value
                                                                  Else
                                                                      Exit For
                                                                  End If

                                                                  ' If saldo < row.Cells(8).Value And saldo > 0 Then
                                                                  'Dim consultaAbono As String
                                                                  'consultaAbono = "Insert into abonosext(idpago,fecha,monto,comprobante,idRecibo) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','','" & idRecibo & "')"
                                                                  'Dim comandoInsertAbono As OleDb.OleDbCommand
                                                                  'comandoInsertAbono = New OleDb.OleDbCommand
                                                                  'comandoInsertAbono.Connection = conexionempresa
                                                                  'comandoInsertAbono.CommandText = consultaAbono
                                                                  'comandoInsertAbono.ExecuteNonQuery()
                                                                  'Dim comandoAbono As OleDb.OleDbCommand
                                                                  'comandoAbono = New OleDb.OleDbCommand
                                                                  '  Dim consultaAbonar As String
                                                                  'consultaAbonar = "select sum(monto) as total from abonosext where idpago = '" & row.Cells(1).Value & "'"
                                                                  'Dim totalAbonado As String
                                                                  'comandoAbono.Connection = conexionempresa
                                                                  'comandoAbono.CommandText = consultaAbonar
                                                                  'totalAbonado = comandoAbono.ExecuteScalar
                                                                  'a = New DetallePago(row.Cells(1).Value, row.Cells(5).Value, saldo, row.Cells(6).Value, totalAbonado, row.Cells(8).Value, saldo, "Abono")
                                                                  'array.Add(a)
                                                                  '  Dim comandoAbonado As OleDb.OleDbCommand
                                                                  'comandoAbonado = New OleDb.OleDbCommand
                                                                  'Dim consultaAbonado As String
                                                                  'Dim restante As Double
                                                                  'restante = row.Cells(8).Value - saldo
                                                                  'consultaAbonado = "Update pagosext set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fecha = '" & fechainsercionhasta & "', convenio = '" & row.Cells(10).Value & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                  'comandoAbonado.Connection = conexionempresa
                                                                  'comandoAbonado.CommandText = consultaAbonado
                                                                  'comandoAbonado.ExecuteNonQuery()

                                                                  ' saldo = saldo - row.Cells(8).Value
                                                                  'End If
                                                              End If
                                                          Next
                                                      End Sub)

                                            Dim ComandoActRecibo As SqlCommand
                                            Dim consultaActRecibo As String
                                            ComandoActRecibo = New SqlCommand

                                            consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                            ComandoActRecibo.Connection = conexionempresa
                                            ComandoActRecibo.CommandText = consultaActRecibo
                                            ComandoActRecibo.ExecuteNonQuery()
                                            ' MessageBox.Show("listo")
                                            'Principal.BackgroundWorker1.RunWorkerAsync()
                                            '  Me.Close()

                                        End If
                                        conexionempresa.Close()
                                        iniciarconexionempresa()
                                        Dim comandoAtraso As SqlCommand
                                        Dim consultaAtraso As String
                                        Dim atraso As Double
                                        consultaAtraso = "select sum(pendiente) from calendariolegales where idCredito = '" & idCreditoRecibo & "' and estado = 'V'"
                                        comandoAtraso = New SqlCommand
                                        comandoAtraso.Connection = conexionempresa
                                        comandoAtraso.CommandText = consultaAtraso
                                        Try
                                            If IsDBNull(comandoAtraso.ExecuteScalar) Then
                                                atraso = 0
                                            Else
                                                atraso = comandoAtraso.ExecuteScalar
                                            End If
                                        Catch ex As InvalidOperationException
                                            iniciarconexionempresa()

                                            If IsDBNull(comandoAtraso.ExecuteScalar) Then
                                                atraso = 0
                                            Else
                                                atraso = comandoAtraso.ExecuteScalar
                                            End If
                                        End Try


                                        Dim pagosemana As Double
                                        pagosemana = (montocredito / 1000) * pcmil


                                        Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
                                        For copy As Integer = 1 To 2
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
                                                .WriteChars(idRecibo)
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
                                                .WriteChars("CRÉDITO LEGAL NO.:")
                                                .Bold = False
                                                .GotoSixth(3)
                                                .WriteChars(idCreditoRecibo)
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .WriteChars("DEUDA TOTAL:")
                                                .Bold = False
                                                .GotoSixth(3)
                                                .WriteChars((montocredito).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .WriteChars("CLIENTE:")
                                                .GotoSixth(3)
                                                .Bold = False
                                                .FontSize = 6.5
                                                .WriteChars(nombre_credito)
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

                                                .WriteChars("FECHA Y HORA DE PAGO:  ")
                                                .Bold = False
                                                .WriteChars("  " & fechadePago & " - " & horadepago)

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
                                                .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)

                                                .WriteChars("Descuento")
                                                .GotoSixth(5)
                                                .WriteChars((descuentoAticket).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)

                                                .WriteChars("Total")
                                                .GotoSixth(5)
                                                If abono Then
                                                    .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                Else
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))

                                                End If
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Recibido")
                                                .GotoSixth(5)
                                                Dim recibido As Double
                                                recibido = Convert.ToDouble(txtRecibido.Text)
                                                .WriteChars((recibido).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Cambio")
                                                .GotoSixth(5)
                                                Dim cambio As Double
                                                If txtCambio.Text = "" Then
                                                    cambio = 0
                                                Else
                                                    cambio = Convert.ToDouble(txtCambio.Text)
                                                End If
                                                .WriteChars((cambio).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .DrawLine()
                                                .GotoSixth(1)

                                                Dim StringNumeroLetra As String
                                                If abono Then
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalpago.ToString, True))
                                                Else
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalApagar.ToString, True))
                                                End If

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
                                                If atraso = 0 Then
                                                    .Bold = True
                                                    .WriteLine("")
                                                    .WriteLine("CUENTA AL CORRIENTE")
                                                    .WriteLine("")
                                                Else
                                                    .Bold = True
                                                    .WriteLine("")
                                                    .WriteLine("CUENTA EN ATRASO, PUEDE PONERSE AL CORRIENTE CON:")

                                                    '.WriteLine("")
                                                    .WriteLine((atraso).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                End If
                                                .GotoSixth(1)
                                                .Bold = False
                                                .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                                                .CutPaper()
                                                .EndDoc()

                                            End With

                                        Next
                                        Me.Invoke(Sub()
                                                      ' Principal.idAnterior = idCreditoRecibo
                                                      inicio.BackgroundWorker1.RunWorkerAsync()
                                                  End Sub)
                                        ' PanelConsultando.Visible = False
                                        'FlatButton1.Enabled = True
                                        Cargando.Close()
                                        Me.Close()
                                    End Sub)

    End Sub
    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        btn_actualizar.Enabled = False
        'MessageBox.Show(tipoDoc)
        If GetNombreDoc(tipoDoc) = "Legal" Then
            ImprimeTicketPagoLegalAsync()
        ElseIf GetNombreDoc(tipoDoc) = "Convenio" Then
            ImprimeTicketPagoConvenioAsync()
        ElseIf GetNombreDoc(tipoDoc) = "Reestructura" Then
            ImprimeTicketPagoReestructuraAsync()
        ElseIf GetNombreDoc(tipoDoc) = "Extra" Then

            ImprimeTicketPagoExtraAsync()
        ElseIf GetNombreDoc(tipoDoc) = "Liquidación Insoluto" Then
            ImprimeTicketLiquidacionInsolutoAsync()


        ElseIf GetNombreDoc(tipoDoc) = "Renovación Insoluto" Then
            ImprimeTicketLiquidacionInsolutoAsync()
        ElseIf GetNombreDoc(tipoDoc) = "Refrendo" Then
            ImprimeTicketEmpeño()
        ElseIf GetNombreDoc(tipoDoc) = "Comisión por avalúo" Then
            ImprimeTicketEmpeño()
        ElseIf GetNombreDoc(tipoDoc) = "Desempeño" Then
            ImprimeTicketEmpeño()
        ElseIf GetNombreDoc(tipoDoc) = "Promesa de pago" Then
            ImprimeTicketPagoPromesaAsync()

        Else







            ImprimeTicketPagoNormalAsync()
        End If

    End Sub

    Private Sub txtDescuento_OnValueChanged(sender As Object, e As EventArgs) Handles txtDescuento.OnValueChanged
        If txtDescuento.Text = "" Then
            descuentoAticket = 0
        Else
            descuentoAticket = Val(txtDescuento.Text)
        End If
        totalApagar = Val(txtTotal.Text) - descuentoAticket
        txtTotalApagar.Text = totalApagar
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub txtTotalApagar_OnValueChanged(sender As Object, e As EventArgs) Handles txtTotalApagar.OnValueChanged
        If txtRecibido.Text = "" Then
            recibido = 0
        Else

            recibido = Convert.ToDouble(txtRecibido.Text)

        End If


        If recibido < totalApagar Then
            txtCambio.Text = 0

        Else
            txtCambio.Text = recibido - Convert.ToDouble(txtTotalApagar.Text)
        End If
    End Sub

    Private Sub txtTotal_OnValueChanged(sender As Object, e As EventArgs) Handles txtTotal.OnValueChanged

    End Sub

    Private Sub txtRecibido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRecibido.KeyDown
        If e.KeyCode = Keys.F8 Then
            Me.TopMost = False
            Autorizacion.TopMost = True
            Autorizacion.tipoAutorizacion = "SacAplicarDescuento"
            Autorizacion.ShowDialog()

            Autorizacion.BringToFront()


            If autorizado Then
                AplicarDescuento.ShowDialog()
            Else
                MessageBox.Show("No fue autorizado")
            End If
        End If
    End Sub

    Private Async Sub ImprimeTicketPagoConvenioAsync()
        Await Task.Factory.StartNew(Sub()
                                        Dim NumeroLetra As New NumLetra
                                        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
                                        If recibido < totalApagar Then
                                            Cargando.TopMost = False
                                            Cargando.SendToBack()
                                            Me.TopMost = False
                                            Dim result As DialogResult = MessageBox.Show("El pago recibido es menor al total a pagar, ¿Desea agregarlo como abono?",
                                                          "Title",
                                                          MessageBoxButtons.YesNo)

                                            If (result = DialogResult.Yes) Then
                                                abono = True
                                                ' Cargando.ShowDialog()
                                                'Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.Show()
                                                Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.TopMost = True
                                                Dim comandoRecibo As SqlCommand
                                                Dim consultarecibo As String
                                                iniciarconexionempresa()
                                                Dim fechainsercionhasta As String
                                                fechainsercionhasta = Now.Date

                                                Dim fechasqlhasta As Date
                                                fechasqlhasta = fechainsercionhasta
                                                fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                                consultarecibo = "Insert into ticket values('" & recibido & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & convenio & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & recibido & "') SELECT SCOPE_IDENTITY()"
                                                comandoRecibo = New SqlCommand
                                                comandoRecibo.Connection = conexionempresa
                                                comandoRecibo.CommandText = consultarecibo
                                                idRecibo = comandoRecibo.ExecuteScalar
                                                'comandoRecibo.ExecuteNonQuery()
                                                fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                                horadepago = tiempo
                                                ' Dim comandoIdRecibo As OleDb.OleDbCommand
                                                'Dim consultaIdRecibo As String
                                                '  consultaIdRecibo = "Select top 1 idRecibo from recibos order by idRecibo desc "
                                                ' comandoIdRecibo = New OleDb.OleDbCommand
                                                ' comandoIdRecibo.Connection = conexionempresa
                                                'comandoIdRecibo.CommandText = consultaIdRecibo
                                                'idRecibo = comandoIdRecibo.ExecuteScalar

                                                saldo = recibido
                                                Dim interesrecibo As Double = 0
                                                Dim pagonormalrecibo As Double = 0
                                                Me.Invoke(Sub()
                                                              For Each row As DataGridViewRow In inicio.dtimpuestos.Rows

                                                                  Dim c As Boolean
                                                                  c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                                  If c Then

                                                                      If saldo >= row.Cells(7).Value Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          Dim readerinteresesacumulado As SqlDataReader
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) as interes from ticketDetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado ='A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          'readerinteresesacumulado = comandointeres.ExecuteReader
                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              interesesAcumulado = 0
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          'MessageBox.Show(interesesAcumulado)
                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim pagonormal As Double
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          interesrecibo = interesrecibo + interesabono

                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String



                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado ='A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar

                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                              totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                          End If
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          consultaAbonado = "Update calendarioConveniosSac set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fecha = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = saldo - row.Cells(7).Value



                                                                      ElseIf saldo < row.Cells(7).Value And saldo > 0 Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              interesesAcumulado = 0
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim interesAbonar As Double
                                                                          Dim saldoAbono As Double
                                                                          Dim pagonormal As Double
                                                                          Dim pagonormalAbonar As Double
                                                                          saldoAbono = saldo
                                                                          interesAbonar = interesabono - saldo
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          ' If saldo > pagonormal Then
                                                                          'pagonormalAbonar = pagonormal
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'Else
                                                                          'pagonormalAbonar = saldo
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'End If

                                                                          If saldo > interesabono Then
                                                                              interesAbonar = interesabono
                                                                              saldoAbono = saldoAbono - interesAbonar
                                                                          Else
                                                                              interesAbonar = saldo
                                                                              saldoAbono = saldoAbono - interesAbonar

                                                                          End If

                                                                          'interesAbonar = saldoAbono
                                                                          ' MessageBox.Show(interesesAcumulado)

                                                                          pagonormal = saldoAbono

                                                                          interesrecibo = interesrecibo + interesAbonar
                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','" & idRecibo & "','" & interesAbonar & "','" & pagonormal & "','Abono','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String
                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar
                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, saldo, interesAbonar, totalAbonado, pagonormal, pagonormal, "Abono", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          Dim restante As Double
                                                                          restante = row.Cells(7).Value - saldo
                                                                          consultaAbonado = "Update calendarioConveniosSac set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fecha = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = 0

                                                                      Else
                                                                          Exit For
                                                                      End If
                                                                  End If
                                                              Next
                                                          End Sub)

                                                Dim ComandoActRecibo As SqlCommand
                                                Dim consultaActRecibo As String
                                                ComandoActRecibo = New SqlCommand

                                                consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                                ComandoActRecibo.Connection = conexionempresa
                                                ComandoActRecibo.CommandText = consultaActRecibo
                                                ComandoActRecibo.ExecuteNonQuery()
                                                ' MessageBox.Show("listo")
                                                '  Principal.BackgroundWorker1.RunWorkerAsync()
                                                '  Me.Close()

                                            Else
                                                abono = False
                                                Exit Sub
                                            End If
                                        Else
                                            abono = False
                                            Cargando.Show()
                                            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                            Cargando.TopMost = True
                                            Dim comandoRecibo As SqlCommand
                                            Dim consultarecibo As String
                                            iniciarconexionempresa()
                                            Dim fechainsercionhasta As String
                                            fechainsercionhasta = Now.Date

                                            Dim fechasqlhasta As Date
                                            fechasqlhasta = fechainsercionhasta
                                            fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                            consultarecibo = "Insert into ticket values('" & totalApagar & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & convenio & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
                                            comandoRecibo = New SqlCommand
                                            comandoRecibo.Connection = conexionempresa
                                            comandoRecibo.CommandText = consultarecibo
                                            'comandoRecibo.ExecuteNonQuery()
                                            idRecibo = comandoRecibo.ExecuteScalar
                                            fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                            horadepago = tiempo

                                            ' Dim comandoIdRecibo As OleDb.OleDbCommand
                                            'Dim consultaIdRecibo As String
                                            ' consultaIdRecibo = "Select top 1 idRecibo from recibos order by idRecibo desc "
                                            ' comandoIdRecibo = New OleDb.OleDbCommand
                                            ' comandoIdRecibo.Connection = conexionempresa
                                            ' comandoIdRecibo.CommandText = consultaIdRecibo
                                            'idRecibo = comandoIdRecibo.ExecuteScalar


                                            Dim pagados As String


                                            saldo = total
                                            Dim interesrecibo As Double = 0
                                            Dim pagonormalrecibo As Double = 0
                                            Me.Invoke(Sub()
                                                          For Each row As DataGridViewRow In inicio.dtimpuestos.Rows
                                                              Dim c As Boolean
                                                              c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                              If c Then

                                                                  If saldo >= row.Cells(7).Value Then
                                                                      Dim comandointeres As SqlCommand
                                                                      Dim consultaintereses As String
                                                                      Dim interesesAcumulado As Double
                                                                      Dim readerinteresesacumulado As SqlDataReader
                                                                      comandointeres = New SqlCommand
                                                                      consultaintereses = "select sum(intereses) as interes from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado ='A'"
                                                                      comandointeres.Connection = conexionempresa
                                                                      comandointeres.CommandText = consultaintereses
                                                                      'readerinteresesacumulado = comandointeres.ExecuteReader
                                                                      If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                          interesesAcumulado = 0
                                                                      Else
                                                                          interesesAcumulado = comandointeres.ExecuteScalar
                                                                      End If

                                                                      'MessageBox.Show(interesesAcumulado)
                                                                      Dim interesabono As Double
                                                                      interesabono = row.Cells(5).Value - interesesAcumulado
                                                                      Dim pagonormal As Double
                                                                      pagonormal = row.Cells(7).Value - interesabono

                                                                      interesrecibo = interesrecibo + interesabono

                                                                      pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                      Dim consultaAbono As String
                                                                      consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                      Dim comandoInsertAbono As SqlCommand
                                                                      comandoInsertAbono = New SqlCommand
                                                                      comandoInsertAbono.Connection = conexionempresa
                                                                      comandoInsertAbono.CommandText = consultaAbono
                                                                      comandoInsertAbono.ExecuteNonQuery()





                                                                      Dim comandoAbono As SqlCommand
                                                                      comandoAbono = New SqlCommand
                                                                      Dim consultaAbonar As String
                                                                      consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                      Dim totalAbonado As String
                                                                      comandoAbono.Connection = conexionempresa
                                                                      comandoAbono.CommandText = consultaAbonar
                                                                      totalAbonado = comandoAbono.ExecuteScalar


                                                                      a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                      array.Add(a)
                                                                      If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                          totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                      End If
                                                                      Dim comandoAbonado As SqlCommand
                                                                      comandoAbonado = New SqlCommand
                                                                      Dim consultaAbonado As String
                                                                      consultaAbonado = "Update calendarioConveniosSac set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fecha = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                      comandoAbonado.Connection = conexionempresa
                                                                      comandoAbonado.CommandText = consultaAbonado
                                                                      comandoAbonado.ExecuteNonQuery()

                                                                      saldo = saldo - row.Cells(7).Value
                                                                  Else
                                                                      Exit For
                                                                  End If

                                                                  ' If saldo < row.Cells(8).Value And saldo > 0 Then
                                                                  'Dim consultaAbono As String
                                                                  'consultaAbono = "Insert into abonosext(idpago,fecha,monto,comprobante,idRecibo) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','','" & idRecibo & "')"
                                                                  'Dim comandoInsertAbono As OleDb.OleDbCommand
                                                                  'comandoInsertAbono = New OleDb.OleDbCommand
                                                                  'comandoInsertAbono.Connection = conexionempresa
                                                                  'comandoInsertAbono.CommandText = consultaAbono
                                                                  'comandoInsertAbono.ExecuteNonQuery()
                                                                  'Dim comandoAbono As OleDb.OleDbCommand
                                                                  'comandoAbono = New OleDb.OleDbCommand
                                                                  '  Dim consultaAbonar As String
                                                                  'consultaAbonar = "select sum(monto) as total from abonosext where idpago = '" & row.Cells(1).Value & "'"
                                                                  'Dim totalAbonado As String
                                                                  'comandoAbono.Connection = conexionempresa
                                                                  'comandoAbono.CommandText = consultaAbonar
                                                                  'totalAbonado = comandoAbono.ExecuteScalar
                                                                  'a = New DetallePago(row.Cells(1).Value, row.Cells(5).Value, saldo, row.Cells(6).Value, totalAbonado, row.Cells(8).Value, saldo, "Abono")
                                                                  'array.Add(a)
                                                                  '  Dim comandoAbonado As OleDb.OleDbCommand
                                                                  'comandoAbonado = New OleDb.OleDbCommand
                                                                  'Dim consultaAbonado As String
                                                                  'Dim restante As Double
                                                                  'restante = row.Cells(8).Value - saldo
                                                                  'consultaAbonado = "Update pagosext set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fecha = '" & fechainsercionhasta & "', convenio = '" & row.Cells(10).Value & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                  'comandoAbonado.Connection = conexionempresa
                                                                  'comandoAbonado.CommandText = consultaAbonado
                                                                  'comandoAbonado.ExecuteNonQuery()

                                                                  ' saldo = saldo - row.Cells(8).Value
                                                                  'End If
                                                              End If
                                                          Next
                                                      End Sub)

                                            Dim ComandoActRecibo As SqlCommand
                                            Dim consultaActRecibo As String
                                            ComandoActRecibo = New SqlCommand

                                            consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                            ComandoActRecibo.Connection = conexionempresa
                                            ComandoActRecibo.CommandText = consultaActRecibo
                                            ComandoActRecibo.ExecuteNonQuery()
                                            ' MessageBox.Show("listo")
                                            'Principal.BackgroundWorker1.RunWorkerAsync()
                                            '  Me.Close()

                                        End If
                                        conexionempresa.Close()
                                        iniciarconexionempresa()
                                        Dim comandoAtraso As SqlCommand
                                        Dim consultaAtraso As String
                                        Dim atraso As Double
                                        consultaAtraso = "select sum(pendiente) from calendarioconveniosSac where idConvenio = '" & convenio & "' and estado = 'V'"
                                        comandoAtraso = New SqlCommand
                                        comandoAtraso.Connection = conexionempresa
                                        comandoAtraso.CommandText = consultaAtraso
                                        Try
                                            If IsDBNull(comandoAtraso.ExecuteScalar) Then
                                                atraso = 0
                                            Else
                                                atraso = comandoAtraso.ExecuteScalar
                                            End If
                                        Catch ex As InvalidOperationException
                                            iniciarconexionempresa()

                                            If IsDBNull(comandoAtraso.ExecuteScalar) Then
                                                atraso = 0
                                            Else
                                                atraso = comandoAtraso.ExecuteScalar
                                            End If
                                        End Try


                                        Dim pagosemana As Double
                                        pagosemana = (montocredito / 1000) * pcmil


                                        Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
                                        For copy As Integer = 1 To 2
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
                                                .FontSize = 6
                                                .Bold = True
                                                .FontSize = 7.3
                                                .WriteChars("TICKET:")
                                                .Bold = False
                                                .GotoSixth(3)
                                                .WriteChars(idRecibo)
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
                                                .WriteChars("CONVENIO NO.:")
                                                .Bold = False
                                                .GotoSixth(3)
                                                .WriteChars(convenio)
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True

                                                .WriteChars("CLIENTE:")
                                                .GotoSixth(3)
                                                .Bold = False
                                                .FontSize = 6.5
                                                .WriteChars(nombre_credito)
                                                .FontSize = 7.3
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .WriteChars("FECHA Y HORA DE PAGO:  ")
                                                .Bold = False
                                                .WriteChars("  " & fechadePago & " - " & horadepago)

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
                                                .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)

                                                .WriteChars("Descuento")
                                                .GotoSixth(5)
                                                .WriteChars((descuentoAticket).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Total")
                                                .GotoSixth(5)
                                                If abono Then
                                                    .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                Else
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))

                                                End If
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Recibido")
                                                .GotoSixth(5)
                                                Dim recibido As Double
                                                recibido = Convert.ToDouble(txtRecibido.Text)
                                                .WriteChars((recibido).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Cambio")
                                                .GotoSixth(5)
                                                Dim cambio As Double
                                                If txtCambio.Text = "" Then
                                                    cambio = 0
                                                Else
                                                    cambio = Convert.ToDouble(txtCambio.Text)
                                                End If
                                                .WriteChars((cambio).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .DrawLine()
                                                .GotoSixth(1)

                                                Dim StringNumeroLetra As String
                                                If abono Then
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalpago.ToString, True))
                                                Else
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalApagar.ToString, True))
                                                End If

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
                                                If atraso = 0 Then
                                                    .Bold = True
                                                    .WriteLine("")
                                                    .WriteLine("CUENTA AL CORRIENTE")
                                                    .WriteLine("")
                                                Else
                                                    .Bold = True
                                                    .WriteLine("")
                                                    .WriteLine("CUENTA EN ATRASO, PUEDE PONERSE AL CORRIENTE CON:")

                                                    '.WriteLine("")
                                                    .WriteLine((atraso).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                End If
                                                .GotoSixth(1)
                                                .Bold = False
                                                .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                                                .CutPaper()
                                                .EndDoc()

                                            End With

                                        Next
                                        Me.Invoke(Sub()
                                                      ' Principal.idAnterior = idCreditoRecibo
                                                      inicio.BackgroundWorker1.RunWorkerAsync()
                                                  End Sub)
                                        ' PanelConsultando.Visible = False
                                        'FlatButton1.Enabled = True
                                        Cargando.Close()
                                        Me.Close()
                                    End Sub)

    End Sub

    Private Async Sub ImprimeTicketPagoReestructuraAsync()
        Await Task.Factory.StartNew(Sub()
                                        Dim NumeroLetra As New NumLetra
                                        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
                                        If recibido < totalApagar Then
                                            Cargando.TopMost = False
                                            Cargando.SendToBack()
                                            Me.TopMost = False
                                            Dim result As DialogResult = MessageBox.Show("El pago recibido es menor al total a pagar, ¿Desea agregarlo como abono?",
                                                          "Title",
                                                          MessageBoxButtons.YesNo)

                                            If (result = DialogResult.Yes) Then
                                                abono = True
                                                ' Cargando.ShowDialog()
                                                'Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.Show()
                                                Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                                Cargando.TopMost = True
                                                Dim comandoRecibo As SqlCommand
                                                Dim consultarecibo As String
                                                iniciarconexionempresa()
                                                Dim fechainsercionhasta As String
                                                fechainsercionhasta = Now.Date

                                                Dim fechasqlhasta As Date
                                                fechasqlhasta = fechainsercionhasta
                                                fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                                consultarecibo = "Insert into ticket values('" & recibido & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & convenio & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & recibido & "') SELECT SCOPE_IDENTITY()"
                                                comandoRecibo = New SqlCommand
                                                comandoRecibo.Connection = conexionempresa
                                                comandoRecibo.CommandText = consultarecibo
                                                idRecibo = comandoRecibo.ExecuteScalar
                                                fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                                horadepago = tiempo

                                                saldo = recibido
                                                Dim interesrecibo As Double = 0
                                                Dim pagonormalrecibo As Double = 0
                                                Me.Invoke(Sub()
                                                              For Each row As DataGridViewRow In inicio.dtimpuestos.Rows

                                                                  Dim c As Boolean
                                                                  c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                                  If c Then

                                                                      If saldo >= row.Cells(7).Value Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          Dim readerinteresesacumulado As SqlDataReader
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) as interes from ticketDetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado ='A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          'readerinteresesacumulado = comandointeres.ExecuteReader
                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              interesesAcumulado = 0
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          'MessageBox.Show(interesesAcumulado)
                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim pagonormal As Double
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          interesrecibo = interesrecibo + interesabono

                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String



                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado ='A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar

                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                              totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                          End If
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          consultaAbonado = "Update CalendarioReestructurasSac set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fecha = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = saldo - row.Cells(7).Value



                                                                      ElseIf saldo < row.Cells(7).Value And saldo > 0 Then
                                                                          Dim comandointeres As SqlCommand
                                                                          Dim consultaintereses As String
                                                                          Dim interesesAcumulado As Double
                                                                          comandointeres = New SqlCommand
                                                                          consultaintereses = "select sum(intereses) from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                          comandointeres.Connection = conexionempresa
                                                                          comandointeres.CommandText = consultaintereses
                                                                          If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                              interesesAcumulado = 0
                                                                          Else
                                                                              interesesAcumulado = comandointeres.ExecuteScalar
                                                                          End If

                                                                          Dim interesabono As Double
                                                                          interesabono = row.Cells(5).Value - interesesAcumulado
                                                                          Dim interesAbonar As Double
                                                                          Dim saldoAbono As Double
                                                                          Dim pagonormal As Double
                                                                          Dim pagonormalAbonar As Double
                                                                          saldoAbono = saldo
                                                                          interesAbonar = interesabono - saldo
                                                                          pagonormal = row.Cells(7).Value - interesabono

                                                                          ' If saldo > pagonormal Then
                                                                          'pagonormalAbonar = pagonormal
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'Else
                                                                          'pagonormalAbonar = saldo
                                                                          'saldoAbono = saldoAbono - pagonormalAbonar
                                                                          'End If

                                                                          If saldo > interesabono Then
                                                                              interesAbonar = interesabono
                                                                              saldoAbono = saldoAbono - interesAbonar
                                                                          Else
                                                                              interesAbonar = saldo
                                                                              saldoAbono = saldoAbono - interesAbonar

                                                                          End If

                                                                          'interesAbonar = saldoAbono
                                                                          ' MessageBox.Show(interesesAcumulado)

                                                                          pagonormal = saldoAbono

                                                                          interesrecibo = interesrecibo + interesAbonar
                                                                          pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                          Dim consultaAbono As String
                                                                          consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','" & idRecibo & "','" & interesAbonar & "','" & pagonormal & "','Abono','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                          Dim comandoInsertAbono As SqlCommand
                                                                          comandoInsertAbono = New SqlCommand
                                                                          comandoInsertAbono.Connection = conexionempresa
                                                                          comandoInsertAbono.CommandText = consultaAbono
                                                                          comandoInsertAbono.ExecuteNonQuery()
                                                                          Dim comandoAbono As SqlCommand
                                                                          comandoAbono = New SqlCommand
                                                                          Dim consultaAbonar As String
                                                                          consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                          Dim totalAbonado As String
                                                                          comandoAbono.Connection = conexionempresa
                                                                          comandoAbono.CommandText = consultaAbonar
                                                                          totalAbonado = comandoAbono.ExecuteScalar
                                                                          a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, saldo, interesAbonar, totalAbonado, pagonormal, pagonormal, "Abono", txtRecibido.Text, descuentoApago)
                                                                          array.Add(a)
                                                                          Dim comandoAbonado As SqlCommand
                                                                          comandoAbonado = New SqlCommand
                                                                          Dim consultaAbonado As String
                                                                          Dim restante As Double
                                                                          restante = row.Cells(7).Value - saldo
                                                                          consultaAbonado = "Update CalendarioReestructurasSac set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fecha = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                          comandoAbonado.Connection = conexionempresa
                                                                          comandoAbonado.CommandText = consultaAbonado
                                                                          comandoAbonado.ExecuteNonQuery()

                                                                          saldo = 0

                                                                      Else
                                                                          Exit For
                                                                      End If
                                                                  End If
                                                              Next
                                                          End Sub)

                                                Dim ComandoActRecibo As SqlCommand
                                                Dim consultaActRecibo As String
                                                ComandoActRecibo = New SqlCommand

                                                consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                                ComandoActRecibo.Connection = conexionempresa
                                                ComandoActRecibo.CommandText = consultaActRecibo
                                                ComandoActRecibo.ExecuteNonQuery()
                                                ' MessageBox.Show("listo")
                                                '  Principal.BackgroundWorker1.RunWorkerAsync()
                                                '  Me.Close()

                                            Else
                                                abono = False
                                                Exit Sub
                                            End If
                                        Else
                                            abono = False
                                            Cargando.Show()
                                            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                            Cargando.TopMost = True
                                            Dim comandoRecibo As SqlCommand
                                            Dim consultarecibo As String
                                            iniciarconexionempresa()
                                            Dim fechainsercionhasta As String
                                            fechainsercionhasta = Now.Date

                                            Dim fechasqlhasta As Date
                                            fechasqlhasta = fechainsercionhasta
                                            fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                            consultarecibo = "Insert into ticket values('" & totalApagar & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & convenio & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
                                            comandoRecibo = New SqlCommand
                                            comandoRecibo.Connection = conexionempresa
                                            comandoRecibo.CommandText = consultarecibo
                                            idRecibo = comandoRecibo.ExecuteScalar
                                            fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                            horadepago = tiempo

                                            Dim pagados As String


                                            saldo = total
                                            Dim interesrecibo As Double = 0
                                            Dim pagonormalrecibo As Double = 0
                                            Me.Invoke(Sub()
                                                          For Each row As DataGridViewRow In inicio.dtimpuestos.Rows
                                                              Dim c As Boolean
                                                              c = Convert.ToBoolean(row.Cells(0).GetEditedFormattedValue(row.Index, 1))
                                                              If c Then

                                                                  If saldo >= row.Cells(7).Value Then
                                                                      Dim comandointeres As SqlCommand
                                                                      Dim consultaintereses As String
                                                                      Dim interesesAcumulado As Double
                                                                      Dim readerinteresesacumulado As SqlDataReader
                                                                      comandointeres = New SqlCommand
                                                                      consultaintereses = "select sum(intereses) as interes from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado ='A'"
                                                                      comandointeres.Connection = conexionempresa
                                                                      comandointeres.CommandText = consultaintereses
                                                                      'readerinteresesacumulado = comandointeres.ExecuteReader
                                                                      If IsDBNull(comandointeres.ExecuteScalar) Then
                                                                          interesesAcumulado = 0
                                                                      Else
                                                                          interesesAcumulado = comandointeres.ExecuteScalar
                                                                      End If

                                                                      'MessageBox.Show(interesesAcumulado)
                                                                      Dim interesabono As Double
                                                                      interesabono = row.Cells(5).Value - interesesAcumulado
                                                                      Dim pagonormal As Double
                                                                      pagonormal = row.Cells(7).Value - interesabono

                                                                      interesrecibo = interesrecibo + interesabono

                                                                      pagonormalrecibo = pagonormalrecibo + pagonormal
                                                                      Dim consultaAbono As String
                                                                      consultaAbono = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & row.Cells(7).Value & "','" & idRecibo & "','" & interesabono & "','" & pagonormal & "','Total','" & tipoDoc & "','A','" & descuentoApago & "')"
                                                                      Dim comandoInsertAbono As SqlCommand
                                                                      comandoInsertAbono = New SqlCommand
                                                                      comandoInsertAbono.Connection = conexionempresa
                                                                      comandoInsertAbono.CommandText = consultaAbono
                                                                      comandoInsertAbono.ExecuteNonQuery()





                                                                      Dim comandoAbono As SqlCommand
                                                                      comandoAbono = New SqlCommand
                                                                      Dim consultaAbonar As String
                                                                      consultaAbonar = "select sum(monto) as total from ticketdetalle where idpago = '" & row.Cells(1).Value & "' and tipodoc = '" & tipoDoc & "' and estado = 'A'"
                                                                      Dim totalAbonado As String
                                                                      comandoAbono.Connection = conexionempresa
                                                                      comandoAbono.CommandText = consultaAbonar
                                                                      totalAbonado = comandoAbono.ExecuteScalar


                                                                      a = New DetallePago(row.Cells(1).Value, row.Cells(2).Value, row.Cells(4).Value, interesabono, totalAbonado, row.Cells(7).Value, pagonormal, "Total", txtRecibido.Text, descuentoApago)
                                                                      array.Add(a)
                                                                      If totalAbonado < (Convert.ToDouble(row.Cells(4).Value) + Convert.ToDouble(row.Cells(5).Value)) Then
                                                                          totalAbonado = totalAbonado + (Convert.ToDouble(row.Cells(6).Value))
                                                                      End If
                                                                      Dim comandoAbonado As SqlCommand
                                                                      comandoAbonado = New SqlCommand
                                                                      Dim consultaAbonado As String
                                                                      consultaAbonado = "Update CalendarioReestructurasSac set abonado = '" & totalAbonado & "', pendiente = '0', estado = 'L',fecha = '" & fechainsercionhasta & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                      comandoAbonado.Connection = conexionempresa
                                                                      comandoAbonado.CommandText = consultaAbonado
                                                                      comandoAbonado.ExecuteNonQuery()

                                                                      saldo = saldo - row.Cells(7).Value
                                                                  Else
                                                                      Exit For
                                                                  End If

                                                                  ' If saldo < row.Cells(8).Value And saldo > 0 Then
                                                                  'Dim consultaAbono As String
                                                                  'consultaAbono = "Insert into abonosext(idpago,fecha,monto,comprobante,idRecibo) values('" & row.Cells(1).Value & "',convert(date,'" & fechainsercionhasta & "',102),'" & saldo & "','','" & idRecibo & "')"
                                                                  'Dim comandoInsertAbono As OleDb.OleDbCommand
                                                                  'comandoInsertAbono = New OleDb.OleDbCommand
                                                                  'comandoInsertAbono.Connection = conexionempresa
                                                                  'comandoInsertAbono.CommandText = consultaAbono
                                                                  'comandoInsertAbono.ExecuteNonQuery()
                                                                  'Dim comandoAbono As OleDb.OleDbCommand
                                                                  'comandoAbono = New OleDb.OleDbCommand
                                                                  '  Dim consultaAbonar As String
                                                                  'consultaAbonar = "select sum(monto) as total from abonosext where idpago = '" & row.Cells(1).Value & "'"
                                                                  'Dim totalAbonado As String
                                                                  'comandoAbono.Connection = conexionempresa
                                                                  'comandoAbono.CommandText = consultaAbonar
                                                                  'totalAbonado = comandoAbono.ExecuteScalar
                                                                  'a = New DetallePago(row.Cells(1).Value, row.Cells(5).Value, saldo, row.Cells(6).Value, totalAbonado, row.Cells(8).Value, saldo, "Abono")
                                                                  'array.Add(a)
                                                                  '  Dim comandoAbonado As OleDb.OleDbCommand
                                                                  'comandoAbonado = New OleDb.OleDbCommand
                                                                  'Dim consultaAbonado As String
                                                                  'Dim restante As Double
                                                                  'restante = row.Cells(8).Value - saldo
                                                                  'consultaAbonado = "Update pagosext set abonado = '" & totalAbonado & "', pendiente = '" & restante & "', fecha = '" & fechainsercionhasta & "', convenio = '" & row.Cells(10).Value & "' where idpago = '" & row.Cells(1).Value & "'"
                                                                  'comandoAbonado.Connection = conexionempresa
                                                                  'comandoAbonado.CommandText = consultaAbonado
                                                                  'comandoAbonado.ExecuteNonQuery()

                                                                  ' saldo = saldo - row.Cells(8).Value
                                                                  'End If
                                                              End If
                                                          Next
                                                      End Sub)

                                            Dim ComandoActRecibo As SqlCommand
                                            Dim consultaActRecibo As String
                                            ComandoActRecibo = New SqlCommand

                                            consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                            ComandoActRecibo.Connection = conexionempresa
                                            ComandoActRecibo.CommandText = consultaActRecibo
                                            ComandoActRecibo.ExecuteNonQuery()
                                            ' MessageBox.Show("listo")
                                            'Principal.BackgroundWorker1.RunWorkerAsync()
                                            '  Me.Close()

                                        End If
                                        conexionempresa.Close()
                                        iniciarconexionempresa()
                                        Dim comandoAtraso As SqlCommand
                                        Dim consultaAtraso As String
                                        Dim atraso As Double
                                        consultaAtraso = "select sum(pendiente) from CalendarioReestructurasSac where idConvenio = '" & convenio & "' and estado = 'V'"
                                        comandoAtraso = New SqlCommand
                                        comandoAtraso.Connection = conexionempresa
                                        comandoAtraso.CommandText = consultaAtraso
                                        Try
                                            If IsDBNull(comandoAtraso.ExecuteScalar) Then
                                                atraso = 0
                                            Else
                                                atraso = comandoAtraso.ExecuteScalar
                                            End If
                                        Catch ex As InvalidOperationException
                                            iniciarconexionempresa()

                                            If IsDBNull(comandoAtraso.ExecuteScalar) Then
                                                atraso = 0
                                            Else
                                                atraso = comandoAtraso.ExecuteScalar
                                            End If
                                        End Try


                                        Dim pagosemana As Double
                                        pagosemana = (montocredito / 1000) * pcmil


                                        Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
                                        For copy As Integer = 1 To 2
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
                                                .FontSize = 6
                                                .Bold = True
                                                .FontSize = 7.3
                                                .WriteChars("TICKET:")
                                                .Bold = False
                                                .GotoSixth(3)
                                                .WriteChars(idRecibo)
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
                                                .FontSize = 6
                                                .WriteChars("FOLIO REESTRUCTURA:")
                                                .Bold = False
                                                .FontSize = 7.3
                                                .GotoSixth(3)
                                                .WriteChars(convenio)
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True

                                                .WriteChars("CLIENTE:")
                                                .GotoSixth(3)
                                                .Bold = False
                                                .FontSize = 6.5
                                                .WriteChars(nombre_credito)
                                                .FontSize = 7.3
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .Bold = True
                                                .WriteChars("FECHA Y HORA DE PAGO:  ")
                                                .Bold = False
                                                .WriteChars("  " & fechadePago & " - " & horadepago)

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
                                                .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)

                                                .WriteChars("Descuento")
                                                .GotoSixth(5)
                                                .WriteChars((descuentoAticket).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Total")
                                                .GotoSixth(5)
                                                If abono Then
                                                    .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                Else
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))

                                                End If
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Recibido")
                                                .GotoSixth(5)
                                                Dim recibido As Double
                                                recibido = Convert.ToDouble(txtRecibido.Text)
                                                .WriteChars((recibido).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .WriteChars("Cambio")
                                                .GotoSixth(5)
                                                Dim cambio As Double
                                                If txtCambio.Text = "" Then
                                                    cambio = 0
                                                Else
                                                    cambio = Convert.ToDouble(txtCambio.Text)
                                                End If
                                                .WriteChars((cambio).ToString("$ ##,##00.00"))
                                                .WriteLine("")
                                                .GotoSixth(1)
                                                .DrawLine()
                                                .GotoSixth(1)

                                                Dim StringNumeroLetra As String
                                                If abono Then
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalpago.ToString, True))
                                                Else
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalApagar.ToString, True))
                                                End If

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
                                                If atraso = 0 Then
                                                    .Bold = True
                                                    .WriteLine("")
                                                    .WriteLine("CUENTA AL CORRIENTE")
                                                    .WriteLine("")
                                                Else
                                                    .Bold = True
                                                    .WriteLine("")
                                                    .WriteLine("CUENTA EN ATRASO, PUEDE PONERSE AL CORRIENTE CON:")

                                                    '.WriteLine("")
                                                    .WriteLine((atraso).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                End If
                                                .GotoSixth(1)
                                                .Bold = False
                                                .WriteLine("RÉGIMEN GENERAL DE LEY PERSONAS MORALES")
                                                .CutPaper()
                                                .EndDoc()

                                            End With

                                        Next
                                        Me.Invoke(Sub()
                                                      ' Principal.idAnterior = idCreditoRecibo
                                                      inicio.BackgroundWorker1.RunWorkerAsync()
                                                  End Sub)
                                        ' PanelConsultando.Visible = False
                                        'FlatButton1.Enabled = True
                                        Cargando.Close()
                                        Me.Close()
                                    End Sub)

    End Sub

    Private Async Sub ImprimeTicketPagoExtraAsync()
        Await Task.Factory.StartNew(Sub()
                                        Dim NumeroLetra As New NumLetra
                                        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
                                        If recibido < totalApagar Then
                                            Cargando.TopMost = False
                                            Cargando.SendToBack()
                                            Me.TopMost = False
                                            Dim result As DialogResult = MessageBox.Show("El pago recibido es menor al total a pagar, en un cobro extraordinario no se puede recibir un monto menor al indicado",
                                                          "Title",
                                                          MessageBoxButtons.OK)
                                            btn_actualizar.Enabled = True

                                        Else
                                            Cargando.Show()
                                            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                            Cargando.TopMost = True
                                            Dim comandoRecibo As SqlCommand
                                            Dim consultarecibo As String
                                            iniciarconexionempresa()
                                            Dim fechainsercionhasta As String
                                            fechainsercionhasta = Now.Date

                                            Dim fechasqlhasta As Date
                                            fechasqlhasta = fechainsercionhasta
                                            fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                            consultarecibo = "Insert into ticket values('" & totalApagar & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','" & tipoDoc & "','" & Concepto & "','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
                                            comandoRecibo = New SqlCommand
                                            comandoRecibo.Connection = conexionempresa
                                            comandoRecibo.CommandText = consultarecibo
                                            'comandoRecibo.ExecuteNonQuery()
                                            idRecibo = comandoRecibo.ExecuteScalar
                                            fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                            horadepago = tiempo

                                            ' Dim comandoIdRecibo As OleDb.OleDbCommand
                                            'Dim consultaIdRecibo As String
                                            ' consultaIdRecibo = "Select top 1 idRecibo from recibos order by idRecibo desc "
                                            ' comandoIdRecibo = New OleDb.OleDbCommand
                                            ' comandoIdRecibo.Connection = conexionempresa
                                            ' comandoIdRecibo.CommandText = consultaIdRecibo
                                            'idRecibo = comandoIdRecibo.ExecuteScalar


                                            Dim pagados As String






                                            ' MessageBox.Show("listo")
                                            'Principal.BackgroundWorker1.RunWorkerAsync()
                                            '  Me.Close()


                                            Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
                                            For copy As Integer = 1 To 2
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
                                                    .WriteChars(idRecibo)
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





                                                    .GotoSixth(1)
                                                    .Bold = True

                                                    .WriteChars("FECHA Y HORA DE PAGO:  ")
                                                    .Bold = False
                                                    .WriteChars("  " & fechadePago & " - " & horadepago)

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


                                                    .WriteChars(Concepto)
                                                    .GotoSixth(5)
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))

                                                    .WriteLine("")

                                                    .DrawLine()


                                                    .GotoSixth(1)
                                                    .WriteChars("SubTotal")
                                                    .GotoSixth(5)
                                                    .WriteChars((total).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)

                                                    .WriteChars("Descuento")
                                                    .GotoSixth(5)
                                                    .WriteChars((descuentoAticket).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)

                                                    .WriteChars("Total")
                                                    .GotoSixth(5)
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .WriteChars("Recibido")
                                                    .GotoSixth(5)
                                                    Dim recibido As Double
                                                    recibido = Convert.ToDouble(txtRecibido.Text)
                                                    .WriteChars((recibido).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .WriteChars("Cambio")
                                                    .GotoSixth(5)
                                                    Dim cambio As Double
                                                    If txtCambio.Text = "" Then
                                                        cambio = 0
                                                    Else
                                                        cambio = Convert.ToDouble(txtCambio.Text)
                                                    End If
                                                    .WriteChars((cambio).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .DrawLine()
                                                    .GotoSixth(1)

                                                    Dim StringNumeroLetra As String
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalApagar.ToString, True))
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

                                            Next
                                            Me.Invoke(Sub()
                                                          ' Principal.idAnterior = idCreditoRecibo
                                                          inicio.BackgroundWorker1.RunWorkerAsync()
                                                      End Sub)
                                            ' PanelConsultando.Visible = False
                                            'FlatButton1.Enabled = True
                                            Cargando.Close()
                                            Me.Close()
                                        End If

                                    End Sub)

    End Sub
    Private Async Sub ImprimeTicketLiquidacionInsolutoAsync()
        Await Task.Factory.StartNew(Sub()
                                        Dim NumeroLetra As New NumLetra
                                        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
                                        If recibido < totalApagar Then
                                            Cargando.TopMost = False
                                            Cargando.SendToBack()
                                            Me.TopMost = False
                                            Dim result As DialogResult = MessageBox.Show("El pago recibido es menor al total a pagar, en una liquidación por saldo insoluto no se puede recibir una cantidad menor a la calculada",
                                                          "Title",
                                                          MessageBoxButtons.OK)


                                        Else
                                            Cargando.Show()
                                            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                            Cargando.TopMost = True
                                            Dim comandoRecibo As SqlCommand
                                            Dim consultarecibo As String
                                            iniciarconexionempresa()
                                            Dim fechainsercionhasta As String
                                            fechainsercionhasta = Now.Date

                                            Dim fechasqlhasta As Date
                                            fechasqlhasta = fechainsercionhasta
                                            fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                            consultarecibo = "Insert into ticket values('" & totalApagar & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','','','" & tipoDoc & "','','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
                                            comandoRecibo = New SqlCommand
                                            comandoRecibo.Connection = conexionempresa
                                            comandoRecibo.CommandText = consultarecibo
                                            'comandoRecibo.ExecuteNonQuery()
                                            idRecibo = comandoRecibo.ExecuteScalar
                                            fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                            horadepago = tiempo

                                            ' Dim comandoIdRecibo As OleDb.OleDbCommand
                                            'Dim consultaIdRecibo As String
                                            ' consultaIdRecibo = "Select top 1 idRecibo from recibos order by idRecibo desc "
                                            ' comandoIdRecibo = New OleDb.OleDbCommand
                                            ' comandoIdRecibo.Connection = conexionempresa
                                            ' comandoIdRecibo.CommandText = consultaIdRecibo
                                            'idRecibo = comandoIdRecibo.ExecuteScalar


                                            Dim pagados As String


                                            saldo = total
                                            Dim interesrecibo As Double = MultasLiquidacion
                                            Dim pagonormalrecibo As Double = MontoLiquidacionSmultas
                                            a = New DetallePago(0, 0, MontoLiquidacionSmultas, MultasLiquidacion, 0, 0, MontoLiquidacionSmultas, "Liquidación", txtRecibido.Text, descuentoApago)
                                            array.Add(a)
                                            ' saldo = total
                                            ' Dim interesrecibo As Double = 0
                                            ' Dim pagonormalrecibo As Double = 0



                                            Dim ComandoActRecibo As SqlCommand
                                            Dim consultaActRecibo As String
                                            ComandoActRecibo = New SqlCommand

                                            consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                            ComandoActRecibo.Connection = conexionempresa
                                            ComandoActRecibo.CommandText = consultaActRecibo
                                            ComandoActRecibo.ExecuteNonQuery()
                                            ' MessageBox.Show("listo")
                                            'Principal.BackgroundWorker1.RunWorkerAsync()
                                            '  Me.Close()


                                            Dim ComandoLiquidacion As SqlCommand
                                            Dim consultaLiquidacion As String
                                            Dim readerliquidacion As SqlDataReader
                                            consultaLiquidacion = "select idpago,monto,interes from calendarionormal where id_credito = '" & idCreditoRecibo & "' and (estado = 'V' or estado = 'P')"
                                            ComandoLiquidacion = New SqlCommand
                                            ComandoLiquidacion.Connection = conexionempresa
                                            ComandoLiquidacion.CommandText = consultaLiquidacion
                                            readerliquidacion = ComandoLiquidacion.ExecuteReader
                                            While readerliquidacion.Read
                                                Dim comandoliquidar As SqlCommand
                                                Dim consultaliquidar As String
                                                consultaliquidar = "update calendarionormal set pendiente = '0',estado = 'L',fechaultimopago = '" & fechadePago & "', abonado = '" & Val(readerliquidacion("monto")) + Val(readerliquidacion("interes")) & "' where idpago = '" & readerliquidacion("idpago") & "'"
                                                comandoliquidar = New SqlCommand
                                                comandoliquidar.Connection = conexionempresa
                                                comandoliquidar.CommandText = consultaliquidar
                                                comandoliquidar.ExecuteNonQuery()

                                                Dim comandoAbonoLiquidar As SqlCommand
                                                Dim consultaAbonoLiquidar As String
                                                consultaAbonoLiquidar = "Insert into ticketdetalle(idpago,fecha,monto,idticket,intereses,pagonormal,Concepto,tipodoc,estado,descuento) values('" & readerliquidacion("idpago") & "',convert(date,'" & fechainsercionhasta & "',102),'0','" & idRecibo & "','0','0','Total','" & tipoDoc & "','A',0)"
                                                comandoAbonoLiquidar = New SqlCommand
                                                comandoAbonoLiquidar.Connection = conexionempresa
                                                comandoAbonoLiquidar.CommandText = consultaAbonoLiquidar
                                                comandoAbonoLiquidar.ExecuteNonQuery()
                                            End While


                                            Dim pagosemana As Double
                                            pagosemana = (montocredito / 1000) * pcmil


                                            Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
                                            For copy As Integer = 1 To 2
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
                                                    .WriteChars(idRecibo)
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
                                                    .WriteChars("CRÉDITO NO.:")
                                                    .Bold = False
                                                    .GotoSixth(3)
                                                    .WriteChars(idCreditoRecibo)
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .Bold = True
                                                    .FontSize = 6.3
                                                    .WriteChars("MONTO DEL CRÉDITO:")
                                                    .Bold = False
                                                    .FontSize = 7.3
                                                    .GotoSixth(3)
                                                    .WriteChars((montocredito).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .Bold = True
                                                    .WriteChars("CLIENTE:")
                                                    .GotoSixth(3)
                                                    .Bold = False
                                                    .FontSize = 6.5
                                                    .WriteChars(nombre_credito)
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
                                                    .WriteChars("FECHA Y HORA DE PAGO:  ")
                                                    .Bold = False
                                                    .WriteChars("  " & fechadePago & " - " & horadepago)

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
                                                            .WriteChars("Capital de " & s.getConcepto)
                                                            .GotoSixth(5)
                                                            .WriteChars((s.getAbonado).ToString("$ ##,##00.00"))

                                                            .WriteLine("")
                                                            .GotoSixth(1)
                                                        End If

                                                        If s.getInteres <> 0 Then
                                                            .GotoSixth(1)
                                                            .WriteChars("Multas")

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
                                                    .WriteChars((totalpago).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)

                                                    .WriteChars("Descuento")
                                                    .GotoSixth(5)
                                                    .WriteChars((descuentoAticket).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)

                                                    .WriteChars("Total")
                                                    .GotoSixth(5)
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .WriteChars("Recibido")
                                                    .GotoSixth(5)
                                                    Dim recibido As Double
                                                    recibido = Convert.ToDouble(txtRecibido.Text)
                                                    .WriteChars((recibido).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .WriteChars("Cambio")
                                                    .GotoSixth(5)
                                                    Dim cambio As Double
                                                    If txtCambio.Text = "" Then
                                                        cambio = 0
                                                    Else
                                                        cambio = Convert.ToDouble(txtCambio.Text)
                                                    End If
                                                    .WriteChars((cambio).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .DrawLine()
                                                    .GotoSixth(1)
                                                    Dim StringNumeroLetra As String
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalApagar.ToString, True))
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

                                            Next
                                            Me.Invoke(Sub()
                                                          ' Principal.idAnterior = idCreditoRecibo
                                                          inicio.BackgroundWorker1.RunWorkerAsync()
                                                      End Sub)
                                            ' PanelConsultando.Visible = False
                                            'FlatButton1.Enabled = True
                                            Cargando.Close()
                                            Me.Close()
                                        End If

                                    End Sub)

    End Sub

    Private Async Sub ImprimeTicketEmpeño()
        Await Task.Factory.StartNew(Sub()
                                        Dim NumeroLetra As New NumLetra
                                        Dim tiempo As String = TimeOfDay.ToString("HH:mm:ss")
                                        If recibido < totalApagar Then
                                            Cargando.TopMost = False
                                            Cargando.SendToBack()
                                            Me.TopMost = False
                                            Dim result As DialogResult = MessageBox.Show("El pago recibido es menor al total a pagar, en el pago de un empeño el monto recibido no puede ser menor al monto total a pagar",
                                                          "SAC",
                                                          MessageBoxButtons.OK)


                                        Else
                                            Cargando.Show()
                                            Cargando.MonoFlat_Label1.Text = "Generando Ticket"
                                            Cargando.TopMost = True
                                            Dim comandoNumeroRefrendo As SqlCommand
                                            Dim consultaNumeroRefrendo As String
                                            Dim noRefrendo As String
                                            consultaNumeroRefrendo = "Select top 1 concepto from ticket where idcredito = '" & idCreditoRecibo & "' and tipodoc= '" & tipoDoc & "' order by concepto desc"
                                            comandoNumeroRefrendo = New SqlCommand
                                            comandoNumeroRefrendo.Connection = conexionempresa
                                            comandoNumeroRefrendo.CommandText = consultaNumeroRefrendo
                                            noRefrendo = comandoNumeroRefrendo.ExecuteScalar + 1
                                            Dim comandoRecibo As SqlCommand
                                            Dim consultarecibo As String
                                            iniciarconexionempresa()
                                            Dim fechainsercionhasta As String
                                            fechainsercionhasta = Now.Date
                                            If interesEmpeño = 0 Then
                                                noRefrendo = ""
                                            Else

                                                If GetNombreDoc(tipoDoc) = "Comisión por avalúo" Then
                                                    noRefrendo = ""
                                                End If

                                            End If
                                            Dim fechasqlhasta As Date
                                            fechasqlhasta = fechainsercionhasta
                                            fechainsercionhasta = Format(fechasqlhasta, "yyyy-MM-dd")
                                            consultarecibo = "Insert into ticket values('" & totalApagar & "','" & recibido & "','" & txtCambio.Text & "','" & fechainsercionhasta & "','" & tiempo & "','" & idCreditoRecibo & "','" & capitalEmpeño & "','" & interesEmpeño & "','" & tipoDoc & "','" & noRefrendo & "','" & nmusr & "','" & noCaja & "','" & descuentoAticket & "','A','" & nm_completeusr & "','" & total & "') SELECT SCOPE_IDENTITY()"
                                            comandoRecibo = New SqlCommand
                                            comandoRecibo.Connection = conexionempresa
                                            comandoRecibo.CommandText = consultarecibo
                                            'comandoRecibo.ExecuteNonQuery()
                                            idRecibo = comandoRecibo.ExecuteScalar
                                            fechadePago = Format(fechasqlhasta, "dd/MM/yyyy")
                                            horadepago = tiempo

                                            ' Dim comandoIdRecibo As OleDb.OleDbCommand
                                            'Dim consultaIdRecibo As String
                                            ' consultaIdRecibo = "Select top 1 idRecibo from recibos order by idRecibo desc "
                                            ' comandoIdRecibo = New OleDb.OleDbCommand
                                            ' comandoIdRecibo.Connection = conexionempresa
                                            ' comandoIdRecibo.CommandText = consultaIdRecibo
                                            'idRecibo = comandoIdRecibo.ExecuteScalar


                                            ' Dim pagados As String


                                            '  saldo = total
                                            ' Dim interesrecibo As Double = MultasLiquidacion
                                            ' Dim pagonormalrecibo As Double = MontoLiquidacionSmultas
                                            ' a = New DetallePago(0, 0, MontoLiquidacionSmultas, MultasLiquidacion, 0, 0, MontoLiquidacionSmultas, "Liquidación", txtRecibido.Text, descuentoApago)
                                            ' array.Add(a)
                                            ' saldo = total
                                            ' Dim interesrecibo As Double = 0
                                            ' Dim pagonormalrecibo As Double = 0



                                            '  Dim ComandoActRecibo As SqlCommand
                                            '  Dim consultaActRecibo As String
                                            '  ComandoActRecibo = New SqlCommand

                                            ' consultaActRecibo = "update ticket set intereses = '" & interesrecibo & "',pagonormal = '" & pagonormalrecibo & "' where id = '" & idRecibo & "'"
                                            ' ComandoActRecibo.Connection = conexionempresa
                                            ' ComandoActRecibo.CommandText = consultaActRecibo
                                            ' ComandoActRecibo.ExecuteNonQuery()
                                            ' MessageBox.Show("listo")
                                            'Principal.BackgroundWorker1.RunWorkerAsync()
                                            '  Me.Close()


                                            Dim comandoActEmpeño As SqlCommand
                                            Dim consultaActEmpeño As String
                                            If pendienteEmpeño = 0 Then
                                                consultaActEmpeño = "update empeños set pendiente = '" & pendienteEmpeño & "', abonado = '" & abonadoEmpeño & "',fechaultimopago = '" & Now.Date.ToString("yyyy-MM-dd") & "', estado = 'T' where id = '" & idCreditoRecibo & "'"

                                            Else
                                                consultaActEmpeño = "update empeños set pendiente = '" & pendienteEmpeño & "', abonado = '" & abonadoEmpeño & "',fechaultimopago = '" & Now.Date.ToString("yyyy-MM-dd") & "' where id = '" & idCreditoRecibo & "'"

                                            End If
                                            comandoActEmpeño = New SqlCommand
                                            comandoActEmpeño.Connection = conexionempresa
                                            comandoActEmpeño.CommandText = consultaActEmpeño
                                            comandoActEmpeño.ExecuteNonQuery()






                                            Dim P As New PrinterClass(Impresora, Application.StartupPath, False)
                                            For copy As Integer = 1 To 2
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
                                                    .WriteChars(idRecibo)
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
                                                    .WriteChars("EMPEÑO NO.:")
                                                    .Bold = False
                                                    .GotoSixth(3)
                                                    .WriteChars(idCreditoRecibo)
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .Bold = True
                                                    .FontSize = 6.3
                                                    .WriteChars("MONTO DEL EMPEÑO:")
                                                    .Bold = False
                                                    .FontSize = 7.3
                                                    .GotoSixth(3)
                                                    .WriteChars((montocredito).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .Bold = True
                                                    .WriteChars("CLIENTE:")
                                                    .GotoSixth(3)
                                                    .Bold = False
                                                    .FontSize = 6.5
                                                    .WriteChars(nombre_credito)
                                                    .FontSize = 7.3
                                                    .WriteLine("")
                                                    .GotoSixth(1)


                                                    .Bold = True
                                                    .WriteChars("FECHA Y HORA DE PAGO:  ")
                                                    .Bold = False
                                                    .WriteChars("  " & fechadePago & " - " & horadepago)

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
                                                    If GetNombreDoc(tipoDoc) = "Comisión por avalúo" Then
                                                        .GotoSixth(1)

                                                        .WriteChars("Comisión por avalúo ")
                                                        .GotoSixth(5)
                                                        .WriteChars((interesEmpeño).ToString("$ ##,##00.00"))


                                                        .WriteLine("")
                                                    Else
                                                        If interesEmpeño <> 0 Then
                                                            .GotoSixth(1)

                                                            .WriteChars("Pago de refrendo no. " & noRefrendo)
                                                            .GotoSixth(5)
                                                            .WriteChars((interesEmpeño).ToString("$ ##,##00.00"))


                                                            .WriteLine("")
                                                        End If

                                                        'subtotal16 = subtotal16 + s.GenInteres(pcmil)


                                                        If capitalEmpeño <> 0 Then
                                                            .GotoSixth(1)
                                                            .WriteChars("Abono a capital")

                                                            .GotoSixth(5)
                                                            .WriteChars((capitalEmpeño).ToString("$ ##,##00.00"))

                                                            .WriteLine("")
                                                        End If


                                                    End If

                                                    .DrawLine()

                                                    .GotoSixth(1)
                                                    .WriteChars("Subtotal Tasa 16%")

                                                    .GotoSixth(5)
                                                    .WriteChars((interesEmpeño / 1.16).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .WriteChars("I.V.A")


                                                    .GotoSixth(5)
                                                    .WriteChars(((interesEmpeño / 1.16) * 0.16).ToString("$ ##,##00.00"))
                                                    .WriteLine("")

                                                    .DrawLine()

                                                    .GotoSixth(1)
                                                    .WriteChars("SubTotal")
                                                    .GotoSixth(5)
                                                    .WriteChars((total).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)

                                                    .WriteChars("Descuento")
                                                    .GotoSixth(5)
                                                    .WriteChars((descuentoAticket).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)

                                                    .WriteChars("Total")
                                                    .GotoSixth(5)
                                                    .WriteChars((totalApagar).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .WriteChars("Recibido")
                                                    .GotoSixth(5)
                                                    Dim recibido As Double
                                                    recibido = Convert.ToDouble(txtRecibido.Text)
                                                    .WriteChars((recibido).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .WriteChars("Cambio")
                                                    .GotoSixth(5)
                                                    Dim cambio As Double
                                                    If txtCambio.Text = "" Then
                                                        cambio = 0
                                                    Else
                                                        cambio = Convert.ToDouble(txtCambio.Text)
                                                    End If
                                                    .WriteChars((cambio).ToString("$ ##,##00.00"))
                                                    .WriteLine("")
                                                    .GotoSixth(1)
                                                    .DrawLine()
                                                    .GotoSixth(1)
                                                    Dim StringNumeroLetra As String
                                                    StringNumeroLetra = (NumeroLetra.Convertir(totalApagar.ToString, True))
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
                                                    If pendienteEmpeño = 0 Then
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

                                            Next
                                            Me.Invoke(Sub()
                                                          ' Principal.idAnterior = idCreditoRecibo
                                                          CobroEmpeño.BackgroundWorker1.RunWorkerAsync()
                                                      End Sub)
                                            ' PanelConsultando.Visible = False
                                            'FlatButton1.Enabled = True
                                            Cargando.Close()
                                            Me.Close()
                                        End If

                                    End Sub)

    End Sub


End Class