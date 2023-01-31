Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class LiquidacionInsoluto
    Public idCredito As String
    Public tipoDoc As Integer
    Dim nombreCredito, montocredito As String
    Dim plazo As Integer
    Dim totalApagar, interescredito As Double
    Dim multasApagar As Double
    Dim totalCredito As Double
    Private Sub LiquidacionInsoluto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargando.Show()
        Cargando.MonoFlat_Label1.Text = "Cargando Información"
        Cargando.TopMost = True
        BackgroundInsoluto.RunWorkerAsync()

    End Sub

    Private Sub BackgroundInsoluto_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundInsoluto.DoWork
        iniciarconexionempresa()
        Dim comandoInsoluto As SqlCommand
        Dim consultaInsoluto As String
        Dim readerInsoluto As SqlDataReader
        consultaInsoluto = "select insoluto.id,insoluto.Nombre,insoluto.Monto,insoluto.Pagare,insoluto.totalInteres,insoluto.FechaEntrega,insoluto.Plazo,insoluto.interes,insoluto.HastaHoy,insoluto.UltimoPago,insoluto.vidaCredito,insoluto.InteresDiario,insoluto.interesAcumulado,insoluto.abonadoSinMultas,insoluto.totalDeuda,(insoluto.Restante - AbonadoCreditoC) as Restante,insoluto.multas,insoluto.AbonadoMultasV,insoluto.AbonadoMultasL,insoluto.TotalAbonadoC,insoluto.AbonadoMultasC,insoluto.AbonadoCreditoC,insoluto.AbonadoMultas as AbonadoMultasNormal, AbonadoMultas+AbonadoMultasC as AbonadoMultas,multas-AbonadoMultas-AbonadoMultasC as MultasPendientes,((restante-AbonadoCreditoC)+(multas-AbonadoMultas-AbonadoMultasC)) as SaldoApagar from
(select cred.id,cred.Nombre,cred.Monto,cred.Pagare,(cred.Pagare-cred.Monto) as totalInteres,cred.FechaEntrega,cred.Plazo,cred.Interes,
DATEDIFF(day,FechaEntrega,GETDATE()) as HastaHoy,
(select top 1 fechapago from CalendarioNormal where id_credito =cred.id order by FechaPago desc) as UltimoPago,
DATEDIFF(day,FechaEntrega,(select top 1 fechapago from CalendarioNormal where id_credito =cred.id order by FechaPago desc)) as vidaCredito,
((cred.Pagare-cred.Monto) / DATEDIFF(day,FechaEntrega,(select top 1 fechapago from CalendarioNormal where id_credito =cred.id order by FechaPago desc)) ) as InteresDiario,
(((cred.Pagare-cred.Monto)/ DATEDIFF(day,FechaEntrega,(select top 1 fechapago from CalendarioNormal where id_credito =cred.id order by FechaPago desc)) ) * DATEDIFF(day,FechaEntrega,GETDATE())) as interesAcumulado,
isnull((select SUM(Abonado - interes) as pagonormal from CalendarioNormal where Abonado <> 0 and Abonado >= interes and id_credito = cred.id group by id_credito),0) as abonadoSinMultas,
(cred.Monto + ((((cred.Pagare-cred.Monto)/ DATEDIFF(day,FechaEntrega,(select top 1 fechapago from CalendarioNormal where id_credito =cred.id order by FechaPago desc)) ) * DATEDIFF(day,FechaEntrega,GETDATE()))) ) as totalDeuda, 
(((cred.Monto + ((((cred.Pagare-cred.Monto)/ DATEDIFF(day,FechaEntrega,(select top 1 fechapago from CalendarioNormal where id_credito =cred.id order by FechaPago desc)) ) * DATEDIFF(day,FechaEntrega,GETDATE()))) ) ) - isnull((select SUM(Abonado - interes) as pagonormal from CalendarioNormal where Abonado <> 0 and Abonado >= interes and id_credito = cred.id group by id_credito),0)) as Restante,
isnull((select SUM(CalendarioNormal.interes) as Multas from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where  CalendarioNormal.id_credito = cred.id group by CalendarioNormal.id_credito),0) as multas,
isnull((select isnull((select SUM( ((((abonado ))) )) as AbonadoInteres from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where CalendarioNormal.estado = 'V' and Abonado <= CalendarioNormal.Interes and CalendarioNormal.id_credito =cred.id group by CalendarioNormal.id_credito),0)
+
isnull((select SUM( ((((abonado -(abonado -calendarionormal.Interes) ))) )) as AbonadoInteres from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where CalendarioNormal.estado = 'V' and Abonado >=CalendarioNormal.Interes and CalendarioNormal.id_credito =cred.id group by CalendarioNormal.id_credito),0)),0) as AbonadoMultasV,
isnull((select SUM(Abonado - CalendarioNormal.monto) as AbonadoMultas from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where  CalendarioNormal.estado = 'L' and CalendarioNormal.id_credito = cred.id group by CalendarioNormal.id_credito),0) as AbonadoMultasL,
--Total Abonado en convenio o reestructura
case when cred.Estado='C' then 
(select  SUM(CASE WHen Estado='L' then case when Interes>multas then (monto+multas) else Monto+interes end else case when Abonado>(monto+Multas) then (monto+multas) else abonado end end)  

	from CalendarioConveniosSac where idConvenio=(select id from ConveniosSac where idCredito=cred.id))
 when cred.Estado='R' THEN
(select  SUM(CASE WHen Estado='L' then case when Interes>multas then (monto+multas) else Monto+interes end else case when Abonado>(monto+Multas) then (monto+multas) else abonado end end) 
	from CalendarioReestructurasSac where idConvenio=(select id from ReestructurasSac where idCredito=cred.id))
	else '0'
	 end as TotalAbonadoC,
--Multas Abonadas en convenio o reestructura
case when cred.Estado='C' then
(select SUM(CASE WHen Estado='L' then case when Interes>multas then (multas) else interes end else case when Abonado>(monto+Multas) then (multas) else case when Interes>multas and Abonado>Interes then Multas when Interes>multas and Abonado<Interes and Abonado<multas then Abonado when Interes>multas and Abonado<Interes and Abonado>multas then multas when Interes=multas and Abonado<Interes then Abonado when Interes=multas and Abonado>=Interes then interes end end end) 
from CalendarioConveniosSac where idConvenio=(select id from ConveniosSac where idCredito=cred.id)) 
 when cred.Estado='R' then
(select SUM(CASE WHen Estado='L' then case when Interes>multas then (multas) else interes end else case when Abonado>(monto+Multas) then (multas) else case when Interes>multas and Abonado>Interes then Multas when Interes>multas and Abonado<Interes and Abonado<multas then Abonado when Interes>multas and Abonado<Interes and Abonado>multas then multas when Interes=multas and Abonado<Interes then Abonado when Interes=multas and Abonado>=Interes then interes end end end) 
from CalendarioReestructurasSac where idConvenio=(select id from ReestructurasSac where idCredito=cred.id)) 
else '0'
end
 as AbonadoMultasC,
--Abonado a crédito en convenio o reestructura
case when cred.Estado='C' then
(select SUM(CASE WHen Estado='L' then case when Interes>multas then (monto+multas) else Monto+interes end else case when Abonado>(monto+Multas) then (monto+multas) else abonado end end) - SUM(CASE WHen Estado='L' then case when Interes>multas then (multas) else interes end else case when Abonado>(monto+Multas) then (multas) else case when Interes>multas and Abonado>Interes then Multas when Interes>multas and Abonado<Interes and Abonado<multas then Abonado when Interes>multas and Abonado<Interes and Abonado>multas then multas when Interes=multas and Abonado<Interes then Abonado when Interes=multas and Abonado>=Interes then interes end end end)
from CalendarioConveniosSac where idConvenio=(select id from ConveniosSac where idCredito=cred.id))
when cred.Estado='R' then
(select SUM(CASE WHen Estado='L' then case when Interes>multas then (monto+multas) else Monto+interes end else case when Abonado>(monto+Multas) then (monto+multas) else abonado end end) - SUM(CASE WHen Estado='L' then case when Interes>multas then (multas) else interes end else case when Abonado>(monto+Multas) then (multas) else case when Interes>multas and Abonado>Interes then Multas when Interes>multas and Abonado<Interes and Abonado<multas then Abonado when Interes>multas and Abonado<Interes and Abonado>multas then multas when Interes=multas and Abonado<Interes then Abonado when Interes=multas and Abonado>=Interes then interes end end end)
from CalendarioReestructurasSac where idConvenio=(select id from ReestructurasSac where idCredito=cred.id))
else '0'
 end
 as AbonadoCreditoC,
((isnull((select isnull((select SUM( ((((abonado ))) )) as AbonadoInteres from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where CalendarioNormal.estado = 'V' and Abonado <= CalendarioNormal.Interes and CalendarioNormal.id_credito =cred.id group by CalendarioNormal.id_credito),0)
+
isnull((select SUM( ((((abonado -(abonado -calendarionormal.Interes) ))) )) as AbonadoInteres from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where CalendarioNormal.estado = 'V' and Abonado >=CalendarioNormal.Interes and CalendarioNormal.id_credito =cred.id group by CalendarioNormal.id_credito),0)),0)) + (isnull((select SUM(Abonado - CalendarioNormal.monto) as AbonadoMultas from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where  CalendarioNormal.estado = 'L' and CalendarioNormal.id_credito = cred.id group by CalendarioNormal.id_credito),0))) as AbonadoMultas,
((isnull((select SUM(CalendarioNormal.interes) as Multas from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where  CalendarioNormal.id_credito = cred.id group by CalendarioNormal.id_credito),0)) - (((isnull((select isnull((select SUM( ((((abonado ))) )) as AbonadoInteres from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where CalendarioNormal.estado = 'V' and Abonado <= CalendarioNormal.Interes and CalendarioNormal.id_credito =cred.id group by CalendarioNormal.id_credito),0)
+
isnull((select SUM( ((((abonado -(abonado -calendarionormal.Interes) ))) )) as AbonadoInteres from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where CalendarioNormal.estado = 'V' and Abonado >=CalendarioNormal.Interes and CalendarioNormal.id_credito =cred.id group by CalendarioNormal.id_credito),0)),0)) + (isnull((select SUM(Abonado - CalendarioNormal.monto) as AbonadoMultas from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where  CalendarioNormal.estado = 'L' and CalendarioNormal.id_credito = cred.id group by CalendarioNormal.id_credito),0))))) as multasPendientes,
((((cred.Monto + ((((cred.Pagare-cred.Monto)/ DATEDIFF(day,FechaEntrega,(select top 1 fechapago from CalendarioNormal where id_credito =cred.id order by FechaPago desc)) ) * DATEDIFF(day,FechaEntrega,GETDATE()))) ) ) - isnull((select SUM(Abonado - interes) as pagonormal from CalendarioNormal where Abonado <> 0 and Abonado >= interes and id_credito = cred.id group by id_credito),0)) + ((isnull((select SUM(CalendarioNormal.interes) as Multas from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where  CalendarioNormal.id_credito = cred.id group by CalendarioNormal.id_credito),0)) - (((isnull((select isnull((select SUM( ((((abonado ))) )) as AbonadoInteres from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where CalendarioNormal.estado = 'V' and Abonado <= CalendarioNormal.Interes and CalendarioNormal.id_credito =cred.id group by CalendarioNormal.id_credito),0)
+
isnull((select SUM( ((((abonado -(abonado -calendarionormal.Interes) ))) )) as AbonadoInteres from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where CalendarioNormal.estado = 'V' and Abonado >=CalendarioNormal.Interes and CalendarioNormal.id_credito =cred.id group by CalendarioNormal.id_credito),0)),0)) + (isnull((select SUM(Abonado - CalendarioNormal.monto) as AbonadoMultas from CalendarioNormal inner join Credito on CalendarioNormal.id_credito = Credito.id where  CalendarioNormal.estado = 'L' and CalendarioNormal.id_credito = cred.id group by CalendarioNormal.id_credito),0)))))  ) as SaldoApagar from
(select * from Credito where id = '" & idCredito & "') cred)insoluto"
        comandoInsoluto = New SqlCommand
        comandoInsoluto.Connection = conexionempresa
        comandoInsoluto.CommandText = consultaInsoluto
        readerInsoluto = comandoInsoluto.ExecuteReader
        If readerInsoluto.HasRows Then
            While readerInsoluto.Read
                nombreCredito = readerInsoluto("Nombre")
                lblnombre.Text = readerInsoluto("Nombre")
                montocredito = readerInsoluto("Monto")
                interescredito = readerInsoluto("Interes")
                plazo = readerInsoluto("Plazo")
                lblmonto.Text = FormatCurrency(readerInsoluto("monto"), 2)
                lblPagare.Text = FormatCurrency(readerInsoluto("Pagare"), 2)
                lblInteresAhoy.Text = FormatCurrency(readerInsoluto("totalinteres"), 2)
                lblFechaEntrega.Text = readerInsoluto("FechaEntrega")
                lblFechaUltimoPago.Text = readerInsoluto("UltimoPago")
                lblDiasDeCredito.Text = readerInsoluto("vidacredito")
                lblDiasTranscurridos.Text = readerInsoluto("hastahoy")
                lblInteresDiario.Text = FormatCurrency(readerInsoluto("interesdiario"), 2)
                lblInteresAcumulado.Text = FormatCurrency(readerInsoluto("Interesacumulado"), 2)
                lblDeudaAhoy.Text = FormatCurrency(readerInsoluto("totaldeuda"), 2)
                lblAbonadoCredito.Text = FormatCurrency(readerInsoluto("abonadosinmultas"), 2)
                lblRestanteSmultas.Text = FormatCurrency(readerInsoluto("restante"), 2)
                lblMultas.Text = FormatCurrency(readerInsoluto("multas"), 2)
                lblMultasAbonadas.Text = FormatCurrency(readerInsoluto("abonadoMultasNormal"), 2)
                lblMultasPendientes.Text = FormatCurrency(readerInsoluto("multasPendientes"), 2)
                lblAbonadoCreditoC.Text = FormatCurrency(readerInsoluto("AbonadoCreditoC"), 2)
                lblAbonadoMultasC.Text = FormatCurrency(readerInsoluto("AbonadoMultasC"), 2)
                lblLiquidacion.Text = FormatCurrency(readerInsoluto("SaldoApagar"), 2)
                totalApagar = CInt(Math.Ceiling(readerInsoluto("saldoapagar")))
                multasApagar = CInt(Math.Ceiling(readerInsoluto("multaspendientes")))
                totalCredito = CInt(Math.Ceiling(readerInsoluto("restante")))
            End While
        End If

    End Sub

    Private Sub BackgroundInsoluto_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundInsoluto.RunWorkerCompleted
        Cargando.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm(Me)
        End If
    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        Ticket_impresion.idCreditoRecibo = idCredito
        Ticket_impresion.montocredito = montocredito
        Ticket_impresion.pcmil = interesCredito
        Ticket_impresion.insoluto = True
        Ticket_impresion.MultasLiquidacion = multasApagar
        Ticket_impresion.MontoLiquidacionSmultas = totalCredito
        Ticket_impresion.total = totalApagar
        Ticket_impresion.cp = plazo
        Ticket_impresion.tipoDoc = tipoDoc
        Ticket_impresion.nombre_credito = nombreCredito
        Ticket_impresion.Show()


    End Sub
End Class