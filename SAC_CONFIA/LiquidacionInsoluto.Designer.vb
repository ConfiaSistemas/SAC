<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LiquidacionInsoluto
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LiquidacionInsoluto))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.MonoFlat_HeaderLabel2 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblnombre = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblmonto = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel5 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblPagare = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel7 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblInteresAhoy = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel9 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblFechaEntrega = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel11 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblFechaUltimoPago = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel13 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblInteresDiario = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel15 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblDiasDeCredito = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel17 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblInteresAcumulado = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel19 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblDeudaAhoy = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel21 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblAbonadoCredito = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel23 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblMultas = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel25 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblMultasAbonadas = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel27 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblMultasPendientes = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel29 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblRestanteSmultas = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel31 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblLiquidacion = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel33 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblDiasTranscurridos = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel35 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.BackgroundInsoluto = New System.ComponentModel.BackgroundWorker()
        Me.btn_actualizar = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(843, 36)
        Me.Panel1.TabIndex = 20
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 3)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(219, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Liquidación por saldo insoluto"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(774, 3)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 0
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'MonoFlat_HeaderLabel2
        '
        Me.MonoFlat_HeaderLabel2.AutoSize = True
        Me.MonoFlat_HeaderLabel2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel2.Location = New System.Drawing.Point(12, 60)
        Me.MonoFlat_HeaderLabel2.Name = "MonoFlat_HeaderLabel2"
        Me.MonoFlat_HeaderLabel2.Size = New System.Drawing.Size(71, 20)
        Me.MonoFlat_HeaderLabel2.TabIndex = 2
        Me.MonoFlat_HeaderLabel2.Text = "Nombre:"
        '
        'lblnombre
        '
        Me.lblnombre.AutoSize = True
        Me.lblnombre.BackColor = System.Drawing.Color.Transparent
        Me.lblnombre.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblnombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblnombre.Location = New System.Drawing.Point(89, 60)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(21, 20)
        Me.lblnombre.TabIndex = 21
        Me.lblnombre.Text = "..."
        '
        'lblmonto
        '
        Me.lblmonto.AutoSize = True
        Me.lblmonto.BackColor = System.Drawing.Color.Transparent
        Me.lblmonto.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblmonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblmonto.Location = New System.Drawing.Point(89, 95)
        Me.lblmonto.Name = "lblmonto"
        Me.lblmonto.Size = New System.Drawing.Size(21, 20)
        Me.lblmonto.TabIndex = 23
        Me.lblmonto.Text = "..."
        '
        'MonoFlat_HeaderLabel5
        '
        Me.MonoFlat_HeaderLabel5.AutoSize = True
        Me.MonoFlat_HeaderLabel5.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel5.Location = New System.Drawing.Point(12, 95)
        Me.MonoFlat_HeaderLabel5.Name = "MonoFlat_HeaderLabel5"
        Me.MonoFlat_HeaderLabel5.Size = New System.Drawing.Size(60, 20)
        Me.MonoFlat_HeaderLabel5.TabIndex = 22
        Me.MonoFlat_HeaderLabel5.Text = "Monto:"
        '
        'lblPagare
        '
        Me.lblPagare.AutoSize = True
        Me.lblPagare.BackColor = System.Drawing.Color.Transparent
        Me.lblPagare.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblPagare.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblPagare.Location = New System.Drawing.Point(357, 95)
        Me.lblPagare.Name = "lblPagare"
        Me.lblPagare.Size = New System.Drawing.Size(21, 20)
        Me.lblPagare.TabIndex = 25
        Me.lblPagare.Text = "..."
        '
        'MonoFlat_HeaderLabel7
        '
        Me.MonoFlat_HeaderLabel7.AutoSize = True
        Me.MonoFlat_HeaderLabel7.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel7.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel7.Location = New System.Drawing.Point(280, 95)
        Me.MonoFlat_HeaderLabel7.Name = "MonoFlat_HeaderLabel7"
        Me.MonoFlat_HeaderLabel7.Size = New System.Drawing.Size(61, 20)
        Me.MonoFlat_HeaderLabel7.TabIndex = 24
        Me.MonoFlat_HeaderLabel7.Text = "Pagaré:"
        '
        'lblInteresAhoy
        '
        Me.lblInteresAhoy.AutoSize = True
        Me.lblInteresAhoy.BackColor = System.Drawing.Color.Transparent
        Me.lblInteresAhoy.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblInteresAhoy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblInteresAhoy.Location = New System.Drawing.Point(731, 95)
        Me.lblInteresAhoy.Name = "lblInteresAhoy"
        Me.lblInteresAhoy.Size = New System.Drawing.Size(21, 20)
        Me.lblInteresAhoy.TabIndex = 27
        Me.lblInteresAhoy.Text = "..."
        '
        'MonoFlat_HeaderLabel9
        '
        Me.MonoFlat_HeaderLabel9.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel9.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel9.Location = New System.Drawing.Point(521, 95)
        Me.MonoFlat_HeaderLabel9.Name = "MonoFlat_HeaderLabel9"
        Me.MonoFlat_HeaderLabel9.Size = New System.Drawing.Size(213, 46)
        Me.MonoFlat_HeaderLabel9.TabIndex = 26
        Me.MonoFlat_HeaderLabel9.Text = "Interés (hasta el último día de la vida del crédito)"
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaEntrega.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblFechaEntrega.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblFechaEntrega.Location = New System.Drawing.Point(150, 164)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(21, 20)
        Me.lblFechaEntrega.TabIndex = 29
        Me.lblFechaEntrega.Text = "..."
        '
        'MonoFlat_HeaderLabel11
        '
        Me.MonoFlat_HeaderLabel11.AutoSize = True
        Me.MonoFlat_HeaderLabel11.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel11.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel11.Location = New System.Drawing.Point(12, 164)
        Me.MonoFlat_HeaderLabel11.Name = "MonoFlat_HeaderLabel11"
        Me.MonoFlat_HeaderLabel11.Size = New System.Drawing.Size(132, 20)
        Me.MonoFlat_HeaderLabel11.TabIndex = 28
        Me.MonoFlat_HeaderLabel11.Text = "Fecha de entrega:"
        '
        'lblFechaUltimoPago
        '
        Me.lblFechaUltimoPago.AutoSize = True
        Me.lblFechaUltimoPago.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaUltimoPago.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblFechaUltimoPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblFechaUltimoPago.Location = New System.Drawing.Point(429, 164)
        Me.lblFechaUltimoPago.Name = "lblFechaUltimoPago"
        Me.lblFechaUltimoPago.Size = New System.Drawing.Size(21, 20)
        Me.lblFechaUltimoPago.TabIndex = 31
        Me.lblFechaUltimoPago.Text = "..."
        '
        'MonoFlat_HeaderLabel13
        '
        Me.MonoFlat_HeaderLabel13.AutoSize = True
        Me.MonoFlat_HeaderLabel13.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel13.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel13.Location = New System.Drawing.Point(262, 164)
        Me.MonoFlat_HeaderLabel13.Name = "MonoFlat_HeaderLabel13"
        Me.MonoFlat_HeaderLabel13.Size = New System.Drawing.Size(165, 20)
        Me.MonoFlat_HeaderLabel13.TabIndex = 30
        Me.MonoFlat_HeaderLabel13.Text = "Fecha de Último Pago:"
        '
        'lblInteresDiario
        '
        Me.lblInteresDiario.AutoSize = True
        Me.lblInteresDiario.BackColor = System.Drawing.Color.Transparent
        Me.lblInteresDiario.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblInteresDiario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblInteresDiario.Location = New System.Drawing.Point(406, 219)
        Me.lblInteresDiario.Name = "lblInteresDiario"
        Me.lblInteresDiario.Size = New System.Drawing.Size(21, 20)
        Me.lblInteresDiario.TabIndex = 33
        Me.lblInteresDiario.Text = "..."
        '
        'MonoFlat_HeaderLabel15
        '
        Me.MonoFlat_HeaderLabel15.AutoSize = True
        Me.MonoFlat_HeaderLabel15.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel15.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel15.Location = New System.Drawing.Point(292, 219)
        Me.MonoFlat_HeaderLabel15.Name = "MonoFlat_HeaderLabel15"
        Me.MonoFlat_HeaderLabel15.Size = New System.Drawing.Size(108, 20)
        Me.MonoFlat_HeaderLabel15.TabIndex = 32
        Me.MonoFlat_HeaderLabel15.Text = "Interés Diario:"
        '
        'lblDiasDeCredito
        '
        Me.lblDiasDeCredito.AutoSize = True
        Me.lblDiasDeCredito.BackColor = System.Drawing.Color.Transparent
        Me.lblDiasDeCredito.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiasDeCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDiasDeCredito.Location = New System.Drawing.Point(700, 164)
        Me.lblDiasDeCredito.Name = "lblDiasDeCredito"
        Me.lblDiasDeCredito.Size = New System.Drawing.Size(21, 20)
        Me.lblDiasDeCredito.TabIndex = 35
        Me.lblDiasDeCredito.Text = "..."
        '
        'MonoFlat_HeaderLabel17
        '
        Me.MonoFlat_HeaderLabel17.AutoSize = True
        Me.MonoFlat_HeaderLabel17.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel17.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel17.Location = New System.Drawing.Point(575, 164)
        Me.MonoFlat_HeaderLabel17.Name = "MonoFlat_HeaderLabel17"
        Me.MonoFlat_HeaderLabel17.Size = New System.Drawing.Size(119, 20)
        Me.MonoFlat_HeaderLabel17.TabIndex = 34
        Me.MonoFlat_HeaderLabel17.Text = "Días de Crédito:"
        '
        'lblInteresAcumulado
        '
        Me.lblInteresAcumulado.AutoSize = True
        Me.lblInteresAcumulado.BackColor = System.Drawing.Color.Transparent
        Me.lblInteresAcumulado.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblInteresAcumulado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblInteresAcumulado.Location = New System.Drawing.Point(727, 219)
        Me.lblInteresAcumulado.Name = "lblInteresAcumulado"
        Me.lblInteresAcumulado.Size = New System.Drawing.Size(21, 20)
        Me.lblInteresAcumulado.TabIndex = 37
        Me.lblInteresAcumulado.Text = "..."
        '
        'MonoFlat_HeaderLabel19
        '
        Me.MonoFlat_HeaderLabel19.AutoSize = True
        Me.MonoFlat_HeaderLabel19.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel19.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel19.Location = New System.Drawing.Point(575, 219)
        Me.MonoFlat_HeaderLabel19.Name = "MonoFlat_HeaderLabel19"
        Me.MonoFlat_HeaderLabel19.Size = New System.Drawing.Size(146, 20)
        Me.MonoFlat_HeaderLabel19.TabIndex = 36
        Me.MonoFlat_HeaderLabel19.Text = "Interés Acumulado:"
        '
        'lblDeudaAhoy
        '
        Me.lblDeudaAhoy.AutoSize = True
        Me.lblDeudaAhoy.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaAhoy.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDeudaAhoy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDeudaAhoy.Location = New System.Drawing.Point(164, 264)
        Me.lblDeudaAhoy.Name = "lblDeudaAhoy"
        Me.lblDeudaAhoy.Size = New System.Drawing.Size(21, 20)
        Me.lblDeudaAhoy.TabIndex = 39
        Me.lblDeudaAhoy.Text = "..."
        '
        'MonoFlat_HeaderLabel21
        '
        Me.MonoFlat_HeaderLabel21.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel21.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel21.Location = New System.Drawing.Point(12, 264)
        Me.MonoFlat_HeaderLabel21.Name = "MonoFlat_HeaderLabel21"
        Me.MonoFlat_HeaderLabel21.Size = New System.Drawing.Size(146, 45)
        Me.MonoFlat_HeaderLabel21.TabIndex = 38
        Me.MonoFlat_HeaderLabel21.Text = "Deuda Hasta Hoy (sin multas):"
        '
        'lblAbonadoCredito
        '
        Me.lblAbonadoCredito.AutoSize = True
        Me.lblAbonadoCredito.BackColor = System.Drawing.Color.Transparent
        Me.lblAbonadoCredito.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblAbonadoCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAbonadoCredito.Location = New System.Drawing.Point(433, 264)
        Me.lblAbonadoCredito.Name = "lblAbonadoCredito"
        Me.lblAbonadoCredito.Size = New System.Drawing.Size(21, 20)
        Me.lblAbonadoCredito.TabIndex = 41
        Me.lblAbonadoCredito.Text = "..."
        '
        'MonoFlat_HeaderLabel23
        '
        Me.MonoFlat_HeaderLabel23.AutoSize = True
        Me.MonoFlat_HeaderLabel23.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel23.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel23.Location = New System.Drawing.Point(283, 264)
        Me.MonoFlat_HeaderLabel23.Name = "MonoFlat_HeaderLabel23"
        Me.MonoFlat_HeaderLabel23.Size = New System.Drawing.Size(144, 20)
        Me.MonoFlat_HeaderLabel23.TabIndex = 40
        Me.MonoFlat_HeaderLabel23.Text = "Abonado a Crédito:"
        '
        'lblMultas
        '
        Me.lblMultas.AutoSize = True
        Me.lblMultas.BackColor = System.Drawing.Color.Transparent
        Me.lblMultas.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblMultas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblMultas.Location = New System.Drawing.Point(155, 315)
        Me.lblMultas.Name = "lblMultas"
        Me.lblMultas.Size = New System.Drawing.Size(21, 20)
        Me.lblMultas.TabIndex = 43
        Me.lblMultas.Text = "..."
        '
        'MonoFlat_HeaderLabel25
        '
        Me.MonoFlat_HeaderLabel25.AutoSize = True
        Me.MonoFlat_HeaderLabel25.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel25.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel25.Location = New System.Drawing.Point(12, 315)
        Me.MonoFlat_HeaderLabel25.Name = "MonoFlat_HeaderLabel25"
        Me.MonoFlat_HeaderLabel25.Size = New System.Drawing.Size(139, 20)
        Me.MonoFlat_HeaderLabel25.TabIndex = 42
        Me.MonoFlat_HeaderLabel25.Text = "Multas Generadas:"
        '
        'lblMultasAbonadas
        '
        Me.lblMultasAbonadas.AutoSize = True
        Me.lblMultasAbonadas.BackColor = System.Drawing.Color.Transparent
        Me.lblMultasAbonadas.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblMultasAbonadas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblMultasAbonadas.Location = New System.Drawing.Point(433, 315)
        Me.lblMultasAbonadas.Name = "lblMultasAbonadas"
        Me.lblMultasAbonadas.Size = New System.Drawing.Size(21, 20)
        Me.lblMultasAbonadas.TabIndex = 45
        Me.lblMultasAbonadas.Text = "..."
        '
        'MonoFlat_HeaderLabel27
        '
        Me.MonoFlat_HeaderLabel27.AutoSize = True
        Me.MonoFlat_HeaderLabel27.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel27.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel27.Location = New System.Drawing.Point(292, 315)
        Me.MonoFlat_HeaderLabel27.Name = "MonoFlat_HeaderLabel27"
        Me.MonoFlat_HeaderLabel27.Size = New System.Drawing.Size(135, 20)
        Me.MonoFlat_HeaderLabel27.TabIndex = 44
        Me.MonoFlat_HeaderLabel27.Text = "Multas Abonadas:"
        '
        'lblMultasPendientes
        '
        Me.lblMultasPendientes.AutoSize = True
        Me.lblMultasPendientes.BackColor = System.Drawing.Color.Transparent
        Me.lblMultasPendientes.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblMultasPendientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblMultasPendientes.Location = New System.Drawing.Point(705, 315)
        Me.lblMultasPendientes.Name = "lblMultasPendientes"
        Me.lblMultasPendientes.Size = New System.Drawing.Size(21, 20)
        Me.lblMultasPendientes.TabIndex = 47
        Me.lblMultasPendientes.Text = "..."
        '
        'MonoFlat_HeaderLabel29
        '
        Me.MonoFlat_HeaderLabel29.AutoSize = True
        Me.MonoFlat_HeaderLabel29.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel29.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel29.Location = New System.Drawing.Point(555, 315)
        Me.MonoFlat_HeaderLabel29.Name = "MonoFlat_HeaderLabel29"
        Me.MonoFlat_HeaderLabel29.Size = New System.Drawing.Size(142, 20)
        Me.MonoFlat_HeaderLabel29.TabIndex = 46
        Me.MonoFlat_HeaderLabel29.Text = "Multas Pendientes:"
        '
        'lblRestanteSmultas
        '
        Me.lblRestanteSmultas.AutoSize = True
        Me.lblRestanteSmultas.BackColor = System.Drawing.Color.Transparent
        Me.lblRestanteSmultas.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblRestanteSmultas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblRestanteSmultas.Location = New System.Drawing.Point(721, 264)
        Me.lblRestanteSmultas.Name = "lblRestanteSmultas"
        Me.lblRestanteSmultas.Size = New System.Drawing.Size(21, 20)
        Me.lblRestanteSmultas.TabIndex = 49
        Me.lblRestanteSmultas.Text = "..."
        '
        'MonoFlat_HeaderLabel31
        '
        Me.MonoFlat_HeaderLabel31.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel31.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel31.Location = New System.Drawing.Point(549, 264)
        Me.MonoFlat_HeaderLabel31.Name = "MonoFlat_HeaderLabel31"
        Me.MonoFlat_HeaderLabel31.Size = New System.Drawing.Size(171, 49)
        Me.MonoFlat_HeaderLabel31.TabIndex = 48
        Me.MonoFlat_HeaderLabel31.Text = "Deuda Restante Hasta Hoy (sin multas)"
        '
        'lblLiquidacion
        '
        Me.lblLiquidacion.AutoSize = True
        Me.lblLiquidacion.BackColor = System.Drawing.Color.Transparent
        Me.lblLiquidacion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblLiquidacion.ForeColor = System.Drawing.Color.Yellow
        Me.lblLiquidacion.Location = New System.Drawing.Point(433, 353)
        Me.lblLiquidacion.Name = "lblLiquidacion"
        Me.lblLiquidacion.Size = New System.Drawing.Size(21, 20)
        Me.lblLiquidacion.TabIndex = 51
        Me.lblLiquidacion.Text = "..."
        '
        'MonoFlat_HeaderLabel33
        '
        Me.MonoFlat_HeaderLabel33.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel33.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel33.ForeColor = System.Drawing.Color.Yellow
        Me.MonoFlat_HeaderLabel33.Location = New System.Drawing.Point(324, 353)
        Me.MonoFlat_HeaderLabel33.Name = "MonoFlat_HeaderLabel33"
        Me.MonoFlat_HeaderLabel33.Size = New System.Drawing.Size(103, 30)
        Me.MonoFlat_HeaderLabel33.TabIndex = 50
        Me.MonoFlat_HeaderLabel33.Text = "Liquida Con:"
        '
        'lblDiasTranscurridos
        '
        Me.lblDiasTranscurridos.AutoSize = True
        Me.lblDiasTranscurridos.BackColor = System.Drawing.Color.Transparent
        Me.lblDiasTranscurridos.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiasTranscurridos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDiasTranscurridos.Location = New System.Drawing.Point(155, 219)
        Me.lblDiasTranscurridos.Name = "lblDiasTranscurridos"
        Me.lblDiasTranscurridos.Size = New System.Drawing.Size(21, 20)
        Me.lblDiasTranscurridos.TabIndex = 53
        Me.lblDiasTranscurridos.Text = "..."
        '
        'MonoFlat_HeaderLabel35
        '
        Me.MonoFlat_HeaderLabel35.AutoSize = True
        Me.MonoFlat_HeaderLabel35.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel35.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel35.Location = New System.Drawing.Point(12, 219)
        Me.MonoFlat_HeaderLabel35.Name = "MonoFlat_HeaderLabel35"
        Me.MonoFlat_HeaderLabel35.Size = New System.Drawing.Size(142, 20)
        Me.MonoFlat_HeaderLabel35.TabIndex = 52
        Me.MonoFlat_HeaderLabel35.Text = "Días Transcurridos:"
        '
        'BackgroundInsoluto
        '
        '
        'btn_actualizar
        '
        Me.btn_actualizar.ActiveBorderThickness = 1
        Me.btn_actualizar.ActiveCornerRadius = 20
        Me.btn_actualizar.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_actualizar.ActiveForecolor = System.Drawing.Color.White
        Me.btn_actualizar.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btn_actualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.btn_actualizar.BackgroundImage = CType(resources.GetObject("btn_actualizar.BackgroundImage"), System.Drawing.Image)
        Me.btn_actualizar.ButtonText = "Continuar"
        Me.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_actualizar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btn_actualizar.IdleBorderThickness = 1
        Me.btn_actualizar.IdleCornerRadius = 20
        Me.btn_actualizar.IdleFillColor = System.Drawing.Color.White
        Me.btn_actualizar.IdleForecolor = System.Drawing.Color.Gray
        Me.btn_actualizar.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_actualizar.Location = New System.Drawing.Point(328, 400)
        Me.btn_actualizar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(207, 38)
        Me.btn_actualizar.TabIndex = 54
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LiquidacionInsoluto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(847, 465)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.lblDiasTranscurridos)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel35)
        Me.Controls.Add(Me.lblLiquidacion)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel33)
        Me.Controls.Add(Me.lblRestanteSmultas)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel31)
        Me.Controls.Add(Me.lblMultasPendientes)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel29)
        Me.Controls.Add(Me.lblMultasAbonadas)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel27)
        Me.Controls.Add(Me.lblMultas)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel25)
        Me.Controls.Add(Me.lblAbonadoCredito)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel23)
        Me.Controls.Add(Me.lblDeudaAhoy)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel21)
        Me.Controls.Add(Me.lblInteresAcumulado)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel19)
        Me.Controls.Add(Me.lblDiasDeCredito)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel17)
        Me.Controls.Add(Me.lblInteresDiario)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel15)
        Me.Controls.Add(Me.lblFechaUltimoPago)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel13)
        Me.Controls.Add(Me.lblFechaEntrega)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel11)
        Me.Controls.Add(Me.lblInteresAhoy)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel9)
        Me.Controls.Add(Me.lblPagare)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel7)
        Me.Controls.Add(Me.lblmonto)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel5)
        Me.Controls.Add(Me.lblnombre)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LiquidacionInsoluto"
        Me.Text = "Liquidación Insoluto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents MonoFlat_HeaderLabel2 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblnombre As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblmonto As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel5 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblPagare As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel7 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblInteresAhoy As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel9 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblFechaEntrega As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel11 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblFechaUltimoPago As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel13 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblInteresDiario As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel15 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblDiasDeCredito As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel17 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblInteresAcumulado As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel19 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblDeudaAhoy As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel21 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblAbonadoCredito As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel23 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblMultas As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel25 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblMultasAbonadas As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel27 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblMultasPendientes As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel29 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblRestanteSmultas As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel31 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblLiquidacion As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel33 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblDiasTranscurridos As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel35 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents BackgroundInsoluto As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_actualizar As Bunifu.Framework.UI.BunifuThinButton2
End Class
