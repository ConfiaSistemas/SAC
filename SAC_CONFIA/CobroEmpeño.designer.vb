<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CobroEmpeño

    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ZeroitMetroWebChartPoint1 As Zeroit.Framework.Metro.ZeroitMetroWebChartPoint = New Zeroit.Framework.Metro.ZeroitMetroWebChartPoint()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(inicio))
        Me.dtimpuestos = New Bunifu.Framework.UI.BunifuCustomDataGrid()
        Me.Pagar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IdPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Npago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Interes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Abonado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pendiente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Convenio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtid = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MonoFlat_Label1 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblnombre = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel2 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblpago = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.ZeroitMetroWebChart1 = New Zeroit.Framework.Metro.ZeroitMetroWebChart()
        Me.SwitchTipo = New Zeroit.Framework.Metro.ZeroitMetroSwitch()
        Me.lblTipoCredito = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.PanelLiquidacion = New System.Windows.Forms.Panel()
        Me.btn_actualizar = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.TimerLiquidación = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundLiquidacionNormal = New System.ComponentModel.BackgroundWorker()
        CType(Me.dtimpuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLiquidacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtimpuestos
        '
        Me.dtimpuestos.AllowUserToAddRows = False
        Me.dtimpuestos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtimpuestos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtimpuestos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtimpuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtimpuestos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dtimpuestos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtimpuestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtimpuestos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtimpuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtimpuestos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pagar, Me.IdPago, Me.Npago, Me.Fecha, Me.Monto, Me.Interes, Me.Abonado, Me.Pendiente, Me.Estado, Me.Convenio})
        Me.dtimpuestos.DoubleBuffered = True
        Me.dtimpuestos.EnableHeadersVisualStyles = False
        Me.dtimpuestos.HeaderBgColor = System.Drawing.Color.DarkSlateGray
        Me.dtimpuestos.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.dtimpuestos.Location = New System.Drawing.Point(12, 120)
        Me.dtimpuestos.Name = "dtimpuestos"
        Me.dtimpuestos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtimpuestos.RowHeadersVisible = False
        Me.dtimpuestos.Size = New System.Drawing.Size(1289, 427)
        Me.dtimpuestos.TabIndex = 5
        '
        'Pagar
        '
        Me.Pagar.HeaderText = "Pagar"
        Me.Pagar.Name = "Pagar"
        Me.Pagar.Width = 47
        '
        'IdPago
        '
        Me.IdPago.HeaderText = "IdPago"
        Me.IdPago.Name = "IdPago"
        Me.IdPago.ReadOnly = True
        Me.IdPago.Width = 73
        '
        'Npago
        '
        Me.Npago.HeaderText = "NPago"
        Me.Npago.Name = "Npago"
        Me.Npago.ReadOnly = True
        Me.Npago.Width = 71
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 68
        '
        'Monto
        '
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        Me.Monto.Width = 70
        '
        'Interes
        '
        Me.Interes.HeaderText = "Interés"
        Me.Interes.Name = "Interes"
        Me.Interes.ReadOnly = True
        Me.Interes.Width = 71
        '
        'Abonado
        '
        Me.Abonado.HeaderText = "Abonado"
        Me.Abonado.Name = "Abonado"
        Me.Abonado.ReadOnly = True
        Me.Abonado.Width = 87
        '
        'Pendiente
        '
        Me.Pendiente.HeaderText = "Pendiente"
        Me.Pendiente.Name = "Pendiente"
        Me.Pendiente.ReadOnly = True
        Me.Pendiente.Width = 92
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 71
        '
        'Convenio
        '
        Me.Convenio.HeaderText = "Convenio"
        Me.Convenio.Name = "Convenio"
        Me.Convenio.Width = 89
        '
        'txtid
        '
        Me.txtid.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtid.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtid.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtid.HintForeColor = System.Drawing.Color.Empty
        Me.txtid.HintText = ""
        Me.txtid.isPassword = False
        Me.txtid.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtid.LineIdleColor = System.Drawing.Color.Gray
        Me.txtid.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtid.LineThickness = 3
        Me.txtid.Location = New System.Drawing.Point(12, 80)
        Me.txtid.Margin = New System.Windows.Forms.Padding(4)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(263, 33)
        Me.txtid.TabIndex = 6
        Me.txtid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(282, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 21)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "F2"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MonoFlat_Label1
        '
        Me.MonoFlat_Label1.AutoSize = True
        Me.MonoFlat_Label1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label1.Location = New System.Drawing.Point(12, 61)
        Me.MonoFlat_Label1.Name = "MonoFlat_Label1"
        Me.MonoFlat_Label1.Size = New System.Drawing.Size(18, 15)
        Me.MonoFlat_Label1.TabIndex = 15
        Me.MonoFlat_Label1.Text = "ID"
        '
        'BackgroundWorker1
        '
        '
        'lblnombre
        '
        Me.lblnombre.AutoSize = True
        Me.lblnombre.BackColor = System.Drawing.Color.Transparent
        Me.lblnombre.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblnombre.ForeColor = System.Drawing.Color.Gray
        Me.lblnombre.Location = New System.Drawing.Point(12, 9)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(13, 20)
        Me.lblnombre.TabIndex = 16
        Me.lblnombre.Text = "."
        '
        'MonoFlat_HeaderLabel2
        '
        Me.MonoFlat_HeaderLabel2.AutoSize = True
        Me.MonoFlat_HeaderLabel2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel2.ForeColor = System.Drawing.Color.Gray
        Me.MonoFlat_HeaderLabel2.Location = New System.Drawing.Point(605, 93)
        Me.MonoFlat_HeaderLabel2.Name = "MonoFlat_HeaderLabel2"
        Me.MonoFlat_HeaderLabel2.Size = New System.Drawing.Size(105, 20)
        Me.MonoFlat_HeaderLabel2.TabIndex = 17
        Me.MonoFlat_HeaderLabel2.Text = "Total a Pagar:"
        '
        'lblpago
        '
        Me.lblpago.AutoSize = True
        Me.lblpago.BackColor = System.Drawing.Color.Transparent
        Me.lblpago.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblpago.ForeColor = System.Drawing.Color.Gray
        Me.lblpago.Location = New System.Drawing.Point(716, 93)
        Me.lblpago.Name = "lblpago"
        Me.lblpago.Size = New System.Drawing.Size(13, 20)
        Me.lblpago.TabIndex = 18
        Me.lblpago.Text = "."
        '
        'ZeroitMetroWebChart1
        '
        Me.ZeroitMetroWebChart1.BezierCurve = False
        Me.ZeroitMetroWebChart1.CornerBorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.ZeroitMetroWebChart1.CornerFillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.ZeroitMetroWebChart1.DesignModeColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.ZeroitMetroWebChart1.FillColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.ZeroitMetroWebChart1.FillMode = Zeroit.Framework.Metro.ZeroitMetroWebChart.FillModes.Gradient
        Me.ZeroitMetroWebChart1.FillSecondColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.ZeroitMetroWebChart1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ZeroitMetroWebChart1.InnerStructureColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.ZeroitMetroWebChart1.Location = New System.Drawing.Point(0, 0)
        Me.ZeroitMetroWebChart1.Name = "ZeroitMetroWebChart1"
        Me.ZeroitMetroWebChart1.OuterStructureBorder = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.ZeroitMetroWebChart1.Size = New System.Drawing.Size(250, 250)
        Me.ZeroitMetroWebChart1.Style = Zeroit.Framework.Metro.Design.Style.Custom
        Me.ZeroitMetroWebChart1.TabIndex = 0
        Me.ZeroitMetroWebChart1.WebBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(163, Byte), Integer))
        ZeroitMetroWebChartPoint1.Color = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(219, Byte), Integer))
        ZeroitMetroWebChartPoint1.Text = ""
        ZeroitMetroWebChartPoint1.Value = 0
        Me.ZeroitMetroWebChart1.WebPoints = ZeroitMetroWebChartPoint1
        '
        'SwitchTipo
        '
        Me.SwitchTipo.BackColor = System.Drawing.Color.Transparent
        Me.SwitchTipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.SwitchTipo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.SwitchTipo.CheckColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.SwitchTipo.Checked = True
        Me.SwitchTipo.DefaultColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.SwitchTipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SwitchTipo.HoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SwitchTipo.Location = New System.Drawing.Point(331, 64)
        Me.SwitchTipo.Name = "SwitchTipo"
        Me.SwitchTipo.Size = New System.Drawing.Size(75, 23)
        Me.SwitchTipo.SwitchColor = System.Drawing.Color.White
        Me.SwitchTipo.TabIndex = 19
        Me.SwitchTipo.Text = "ZeroitMetroSwitch1"
        '
        'lblTipoCredito
        '
        Me.lblTipoCredito.AutoSize = True
        Me.lblTipoCredito.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTipoCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.lblTipoCredito.Location = New System.Drawing.Point(328, 45)
        Me.lblTipoCredito.Name = "lblTipoCredito"
        Me.lblTipoCredito.Size = New System.Drawing.Size(47, 15)
        Me.lblTipoCredito.TabIndex = 20
        Me.lblTipoCredito.Text = "Normal"
        '
        'PanelLiquidacion
        '
        Me.PanelLiquidacion.BackColor = System.Drawing.Color.Transparent
        Me.PanelLiquidacion.Controls.Add(Me.btn_actualizar)
        Me.PanelLiquidacion.Location = New System.Drawing.Point(315, 83)
        Me.PanelLiquidacion.Name = "PanelLiquidacion"
        Me.PanelLiquidacion.Size = New System.Drawing.Size(141, 31)
        Me.PanelLiquidacion.TabIndex = 21
        '
        'btn_actualizar
        '
        Me.btn_actualizar.ActiveBorderThickness = 1
        Me.btn_actualizar.ActiveCornerRadius = 20
        Me.btn_actualizar.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_actualizar.ActiveForecolor = System.Drawing.Color.Transparent
        Me.btn_actualizar.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btn_actualizar.BackColor = System.Drawing.Color.Transparent
        Me.btn_actualizar.BackgroundImage = CType(resources.GetObject("btn_actualizar.BackgroundImage"), System.Drawing.Image)
        Me.btn_actualizar.ButtonText = "Calcular Liquidación"
        Me.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_actualizar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btn_actualizar.IdleBorderThickness = 1
        Me.btn_actualizar.IdleCornerRadius = 20
        Me.btn_actualizar.IdleFillColor = System.Drawing.Color.White
        Me.btn_actualizar.IdleForecolor = System.Drawing.Color.Gray
        Me.btn_actualizar.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_actualizar.Location = New System.Drawing.Point(4, 1)
        Me.btn_actualizar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(134, 29)
        Me.btn_actualizar.TabIndex = 21
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerLiquidación
        '
        Me.TimerLiquidación.Interval = 1
        '
        'inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SAC_CONFIA.My.Resources.Resources.SAC
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1313, 765)
        Me.Controls.Add(Me.PanelLiquidacion)
        Me.Controls.Add(Me.lblTipoCredito)
        Me.Controls.Add(Me.SwitchTipo)
        Me.Controls.Add(Me.lblpago)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel2)
        Me.Controls.Add(Me.lblnombre)
        Me.Controls.Add(Me.MonoFlat_Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.dtimpuestos)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "inicio"
        Me.RightToLeftLayout = True
        Me.Text = "inicio"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        CType(Me.dtimpuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLiquidacion.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtimpuestos As Bunifu.Framework.UI.BunifuCustomDataGrid
    Friend WithEvents txtid As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents Button1 As Button
    Friend WithEvents MonoFlat_Label1 As MonoFlat.MonoFlat_Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblnombre As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel2 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblpago As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents Pagar As DataGridViewCheckBoxColumn
    Friend WithEvents IdPago As DataGridViewTextBoxColumn
    Friend WithEvents Npago As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Monto As DataGridViewTextBoxColumn
    Friend WithEvents Interes As DataGridViewTextBoxColumn
    Friend WithEvents Abonado As DataGridViewTextBoxColumn
    Friend WithEvents Pendiente As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents Convenio As DataGridViewTextBoxColumn
    Friend WithEvents ZeroitMetroWebChart1 As Zeroit.Framework.Metro.ZeroitMetroWebChart
    Friend WithEvents SwitchTipo As Zeroit.Framework.Metro.ZeroitMetroSwitch
    Friend WithEvents lblTipoCredito As MonoFlat.MonoFlat_Label
    Friend WithEvents PanelLiquidacion As Panel
    Friend WithEvents btn_actualizar As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents TimerLiquidación As Timer
    Friend WithEvents BackgroundLiquidacionNormal As System.ComponentModel.BackgroundWorker
End Class
