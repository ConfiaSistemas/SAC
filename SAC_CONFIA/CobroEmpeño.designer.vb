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
        Dim ZeroitMetroWebChartPoint1 As Zeroit.Framework.Metro.ZeroitMetroWebChartPoint = New Zeroit.Framework.Metro.ZeroitMetroWebChartPoint()
        Dim Animation3 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation2 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation5 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation4 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation6 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation1 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CobroEmpeño))
        Me.txtid = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MonoFlat_Label1 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblnombre = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.ZeroitMetroWebChart1 = New Zeroit.Framework.Metro.ZeroitMetroWebChart()
        Me.MonoFlat_Label2 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.MonoFlat_Label3 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.MonoFlat_Label4 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.MonoFlat_Label5 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.MonoFlat_Label6 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.txtPrestado = New System.Windows.Forms.Button()
        Me.txtDesempeño = New System.Windows.Forms.Button()
        Me.txtUltimoPago = New System.Windows.Forms.Button()
        Me.txtInteresDiario = New System.Windows.Forms.Button()
        Me.txtRefrendo = New System.Windows.Forms.Button()
        Me.txtOtraCantidad = New System.Windows.Forms.Button()
        Me.BunifuTransition1 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.BunifuTransition2 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.BunifuTransition3 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.BunifuTransition4 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.BunifuTransition5 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.BunifuTransition6 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.SuspendLayout()
        '
        'txtid
        '
        Me.txtid.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BunifuTransition6.SetDecoration(Me.txtid, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txtid, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txtid, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.txtid, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.txtid, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.txtid, BunifuAnimatorNS.DecorationType.None)
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
        Me.BunifuTransition6.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
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
        Me.BunifuTransition6.SetDecoration(Me.MonoFlat_Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.MonoFlat_Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.MonoFlat_Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.MonoFlat_Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.MonoFlat_Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.MonoFlat_Label1, BunifuAnimatorNS.DecorationType.None)
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
        Me.BunifuTransition6.SetDecoration(Me.lblnombre, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.lblnombre, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.lblnombre, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.lblnombre, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.lblnombre, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.lblnombre, BunifuAnimatorNS.DecorationType.None)
        Me.lblnombre.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblnombre.ForeColor = System.Drawing.Color.Gray
        Me.lblnombre.Location = New System.Drawing.Point(12, 9)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(13, 20)
        Me.lblnombre.TabIndex = 16
        Me.lblnombre.Text = "."
        '
        'ZeroitMetroWebChart1
        '
        Me.ZeroitMetroWebChart1.BezierCurve = False
        Me.ZeroitMetroWebChart1.CornerBorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.ZeroitMetroWebChart1.CornerFillColor = System.Drawing.Color.FromArgb(CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.BunifuTransition6.SetDecoration(Me.ZeroitMetroWebChart1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.ZeroitMetroWebChart1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.ZeroitMetroWebChart1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.ZeroitMetroWebChart1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.ZeroitMetroWebChart1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.ZeroitMetroWebChart1, BunifuAnimatorNS.DecorationType.None)
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
        'MonoFlat_Label2
        '
        Me.MonoFlat_Label2.AutoSize = True
        Me.MonoFlat_Label2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition6.SetDecoration(Me.MonoFlat_Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.MonoFlat_Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.MonoFlat_Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.MonoFlat_Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.MonoFlat_Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.MonoFlat_Label2, BunifuAnimatorNS.DecorationType.None)
        Me.MonoFlat_Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label2.Location = New System.Drawing.Point(16, 164)
        Me.MonoFlat_Label2.Name = "MonoFlat_Label2"
        Me.MonoFlat_Label2.Size = New System.Drawing.Size(53, 15)
        Me.MonoFlat_Label2.TabIndex = 25
        Me.MonoFlat_Label2.Text = "Prestado"
        '
        'MonoFlat_Label3
        '
        Me.MonoFlat_Label3.AutoSize = True
        Me.MonoFlat_Label3.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition6.SetDecoration(Me.MonoFlat_Label3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.MonoFlat_Label3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.MonoFlat_Label3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.MonoFlat_Label3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.MonoFlat_Label3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.MonoFlat_Label3, BunifuAnimatorNS.DecorationType.None)
        Me.MonoFlat_Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label3.Location = New System.Drawing.Point(95, 164)
        Me.MonoFlat_Label3.Name = "MonoFlat_Label3"
        Me.MonoFlat_Label3.Size = New System.Drawing.Size(70, 15)
        Me.MonoFlat_Label3.TabIndex = 26
        Me.MonoFlat_Label3.Text = "Desempeño"
        '
        'MonoFlat_Label4
        '
        Me.MonoFlat_Label4.AutoSize = True
        Me.MonoFlat_Label4.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition6.SetDecoration(Me.MonoFlat_Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.MonoFlat_Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.MonoFlat_Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.MonoFlat_Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.MonoFlat_Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.MonoFlat_Label4, BunifuAnimatorNS.DecorationType.None)
        Me.MonoFlat_Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label4.Location = New System.Drawing.Point(182, 164)
        Me.MonoFlat_Label4.Name = "MonoFlat_Label4"
        Me.MonoFlat_Label4.Size = New System.Drawing.Size(73, 15)
        Me.MonoFlat_Label4.TabIndex = 27
        Me.MonoFlat_Label4.Text = "Último pago"
        '
        'MonoFlat_Label5
        '
        Me.MonoFlat_Label5.AutoSize = True
        Me.MonoFlat_Label5.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition6.SetDecoration(Me.MonoFlat_Label5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.MonoFlat_Label5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.MonoFlat_Label5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.MonoFlat_Label5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.MonoFlat_Label5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.MonoFlat_Label5, BunifuAnimatorNS.DecorationType.None)
        Me.MonoFlat_Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label5.Location = New System.Drawing.Point(278, 164)
        Me.MonoFlat_Label5.Name = "MonoFlat_Label5"
        Me.MonoFlat_Label5.Size = New System.Drawing.Size(75, 15)
        Me.MonoFlat_Label5.TabIndex = 28
        Me.MonoFlat_Label5.Text = "Interés diario"
        '
        'MonoFlat_Label6
        '
        Me.MonoFlat_Label6.AutoSize = True
        Me.MonoFlat_Label6.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition6.SetDecoration(Me.MonoFlat_Label6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.MonoFlat_Label6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.MonoFlat_Label6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.MonoFlat_Label6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.MonoFlat_Label6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.MonoFlat_Label6, BunifuAnimatorNS.DecorationType.None)
        Me.MonoFlat_Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label6.Location = New System.Drawing.Point(360, 164)
        Me.MonoFlat_Label6.Name = "MonoFlat_Label6"
        Me.MonoFlat_Label6.Size = New System.Drawing.Size(78, 15)
        Me.MonoFlat_Label6.TabIndex = 29
        Me.MonoFlat_Label6.Text = "Refrendo (F5)"
        '
        'txtPrestado
        '
        Me.BunifuTransition6.SetDecoration(Me.txtPrestado, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txtPrestado, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txtPrestado, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.txtPrestado, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.txtPrestado, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.txtPrestado, BunifuAnimatorNS.DecorationType.None)
        Me.txtPrestado.FlatAppearance.BorderSize = 3
        Me.txtPrestado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtPrestado.Location = New System.Drawing.Point(19, 182)
        Me.txtPrestado.Name = "txtPrestado"
        Me.txtPrestado.Size = New System.Drawing.Size(76, 45)
        Me.txtPrestado.TabIndex = 35
        Me.txtPrestado.UseVisualStyleBackColor = True
        Me.txtPrestado.Visible = False
        '
        'txtDesempeño
        '
        Me.BunifuTransition6.SetDecoration(Me.txtDesempeño, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txtDesempeño, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txtDesempeño, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.txtDesempeño, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.txtDesempeño, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.txtDesempeño, BunifuAnimatorNS.DecorationType.None)
        Me.txtDesempeño.FlatAppearance.BorderSize = 3
        Me.txtDesempeño.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtDesempeño.Location = New System.Drawing.Point(101, 182)
        Me.txtDesempeño.Name = "txtDesempeño"
        Me.txtDesempeño.Size = New System.Drawing.Size(76, 45)
        Me.txtDesempeño.TabIndex = 38
        Me.txtDesempeño.UseVisualStyleBackColor = True
        Me.txtDesempeño.Visible = False
        '
        'txtUltimoPago
        '
        Me.BunifuTransition6.SetDecoration(Me.txtUltimoPago, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txtUltimoPago, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txtUltimoPago, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.txtUltimoPago, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.txtUltimoPago, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.txtUltimoPago, BunifuAnimatorNS.DecorationType.None)
        Me.txtUltimoPago.FlatAppearance.BorderSize = 3
        Me.txtUltimoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtUltimoPago.Location = New System.Drawing.Point(185, 182)
        Me.txtUltimoPago.Name = "txtUltimoPago"
        Me.txtUltimoPago.Size = New System.Drawing.Size(90, 45)
        Me.txtUltimoPago.TabIndex = 39
        Me.txtUltimoPago.UseVisualStyleBackColor = True
        Me.txtUltimoPago.Visible = False
        '
        'txtInteresDiario
        '
        Me.BunifuTransition6.SetDecoration(Me.txtInteresDiario, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txtInteresDiario, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txtInteresDiario, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.txtInteresDiario, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.txtInteresDiario, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.txtInteresDiario, BunifuAnimatorNS.DecorationType.None)
        Me.txtInteresDiario.FlatAppearance.BorderSize = 3
        Me.txtInteresDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtInteresDiario.Location = New System.Drawing.Point(281, 182)
        Me.txtInteresDiario.Name = "txtInteresDiario"
        Me.txtInteresDiario.Size = New System.Drawing.Size(76, 45)
        Me.txtInteresDiario.TabIndex = 40
        Me.txtInteresDiario.UseVisualStyleBackColor = True
        Me.txtInteresDiario.Visible = False
        '
        'txtRefrendo
        '
        Me.BunifuTransition6.SetDecoration(Me.txtRefrendo, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txtRefrendo, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txtRefrendo, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.txtRefrendo, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.txtRefrendo, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.txtRefrendo, BunifuAnimatorNS.DecorationType.None)
        Me.txtRefrendo.FlatAppearance.BorderSize = 3
        Me.txtRefrendo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtRefrendo.Location = New System.Drawing.Point(363, 182)
        Me.txtRefrendo.Name = "txtRefrendo"
        Me.txtRefrendo.Size = New System.Drawing.Size(76, 45)
        Me.txtRefrendo.TabIndex = 41
        Me.txtRefrendo.UseVisualStyleBackColor = True
        Me.txtRefrendo.Visible = False
        '
        'txtOtraCantidad
        '
        Me.BunifuTransition6.SetDecoration(Me.txtOtraCantidad, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txtOtraCantidad, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txtOtraCantidad, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me.txtOtraCantidad, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.txtOtraCantidad, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me.txtOtraCantidad, BunifuAnimatorNS.DecorationType.None)
        Me.txtOtraCantidad.FlatAppearance.BorderSize = 3
        Me.txtOtraCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtOtraCantidad.Location = New System.Drawing.Point(445, 182)
        Me.txtOtraCantidad.Name = "txtOtraCantidad"
        Me.txtOtraCantidad.Size = New System.Drawing.Size(76, 45)
        Me.txtOtraCantidad.TabIndex = 42
        Me.txtOtraCantidad.Text = "Otra Cantidad"
        Me.txtOtraCantidad.UseVisualStyleBackColor = True
        Me.txtOtraCantidad.Visible = False
        '
        'BunifuTransition1
        '
        Me.BunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic
        Me.BunifuTransition1.Cursor = Nothing
        Animation3.AnimateOnlyDifferences = True
        Animation3.BlindCoeff = CType(resources.GetObject("Animation3.BlindCoeff"), System.Drawing.PointF)
        Animation3.LeafCoeff = 0!
        Animation3.MaxTime = 1.0!
        Animation3.MinTime = 0!
        Animation3.MosaicCoeff = CType(resources.GetObject("Animation3.MosaicCoeff"), System.Drawing.PointF)
        Animation3.MosaicShift = CType(resources.GetObject("Animation3.MosaicShift"), System.Drawing.PointF)
        Animation3.MosaicSize = 20
        Animation3.Padding = New System.Windows.Forms.Padding(30)
        Animation3.RotateCoeff = 0!
        Animation3.RotateLimit = 0!
        Animation3.ScaleCoeff = CType(resources.GetObject("Animation3.ScaleCoeff"), System.Drawing.PointF)
        Animation3.SlideCoeff = CType(resources.GetObject("Animation3.SlideCoeff"), System.Drawing.PointF)
        Animation3.TimeCoeff = 0!
        Animation3.TransparencyCoeff = 0!
        Me.BunifuTransition1.DefaultAnimation = Animation3
        '
        'BunifuTransition2
        '
        Me.BunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic
        Me.BunifuTransition2.Cursor = Nothing
        Animation2.AnimateOnlyDifferences = True
        Animation2.BlindCoeff = CType(resources.GetObject("Animation2.BlindCoeff"), System.Drawing.PointF)
        Animation2.LeafCoeff = 0!
        Animation2.MaxTime = 1.0!
        Animation2.MinTime = 0!
        Animation2.MosaicCoeff = CType(resources.GetObject("Animation2.MosaicCoeff"), System.Drawing.PointF)
        Animation2.MosaicShift = CType(resources.GetObject("Animation2.MosaicShift"), System.Drawing.PointF)
        Animation2.MosaicSize = 20
        Animation2.Padding = New System.Windows.Forms.Padding(30)
        Animation2.RotateCoeff = 0!
        Animation2.RotateLimit = 0!
        Animation2.ScaleCoeff = CType(resources.GetObject("Animation2.ScaleCoeff"), System.Drawing.PointF)
        Animation2.SlideCoeff = CType(resources.GetObject("Animation2.SlideCoeff"), System.Drawing.PointF)
        Animation2.TimeCoeff = 0!
        Animation2.TransparencyCoeff = 0!
        Me.BunifuTransition2.DefaultAnimation = Animation2
        '
        'BunifuTransition3
        '
        Me.BunifuTransition3.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic
        Me.BunifuTransition3.Cursor = Nothing
        Animation5.AnimateOnlyDifferences = True
        Animation5.BlindCoeff = CType(resources.GetObject("Animation5.BlindCoeff"), System.Drawing.PointF)
        Animation5.LeafCoeff = 0!
        Animation5.MaxTime = 1.0!
        Animation5.MinTime = 0!
        Animation5.MosaicCoeff = CType(resources.GetObject("Animation5.MosaicCoeff"), System.Drawing.PointF)
        Animation5.MosaicShift = CType(resources.GetObject("Animation5.MosaicShift"), System.Drawing.PointF)
        Animation5.MosaicSize = 20
        Animation5.Padding = New System.Windows.Forms.Padding(30)
        Animation5.RotateCoeff = 0!
        Animation5.RotateLimit = 0!
        Animation5.ScaleCoeff = CType(resources.GetObject("Animation5.ScaleCoeff"), System.Drawing.PointF)
        Animation5.SlideCoeff = CType(resources.GetObject("Animation5.SlideCoeff"), System.Drawing.PointF)
        Animation5.TimeCoeff = 0!
        Animation5.TransparencyCoeff = 0!
        Me.BunifuTransition3.DefaultAnimation = Animation5
        '
        'BunifuTransition4
        '
        Me.BunifuTransition4.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic
        Me.BunifuTransition4.Cursor = Nothing
        Animation4.AnimateOnlyDifferences = True
        Animation4.BlindCoeff = CType(resources.GetObject("Animation4.BlindCoeff"), System.Drawing.PointF)
        Animation4.LeafCoeff = 0!
        Animation4.MaxTime = 1.0!
        Animation4.MinTime = 0!
        Animation4.MosaicCoeff = CType(resources.GetObject("Animation4.MosaicCoeff"), System.Drawing.PointF)
        Animation4.MosaicShift = CType(resources.GetObject("Animation4.MosaicShift"), System.Drawing.PointF)
        Animation4.MosaicSize = 20
        Animation4.Padding = New System.Windows.Forms.Padding(30)
        Animation4.RotateCoeff = 0!
        Animation4.RotateLimit = 0!
        Animation4.ScaleCoeff = CType(resources.GetObject("Animation4.ScaleCoeff"), System.Drawing.PointF)
        Animation4.SlideCoeff = CType(resources.GetObject("Animation4.SlideCoeff"), System.Drawing.PointF)
        Animation4.TimeCoeff = 0!
        Animation4.TransparencyCoeff = 0!
        Me.BunifuTransition4.DefaultAnimation = Animation4
        '
        'BunifuTransition5
        '
        Me.BunifuTransition5.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic
        Me.BunifuTransition5.Cursor = Nothing
        Animation6.AnimateOnlyDifferences = True
        Animation6.BlindCoeff = CType(resources.GetObject("Animation6.BlindCoeff"), System.Drawing.PointF)
        Animation6.LeafCoeff = 0!
        Animation6.MaxTime = 1.0!
        Animation6.MinTime = 0!
        Animation6.MosaicCoeff = CType(resources.GetObject("Animation6.MosaicCoeff"), System.Drawing.PointF)
        Animation6.MosaicShift = CType(resources.GetObject("Animation6.MosaicShift"), System.Drawing.PointF)
        Animation6.MosaicSize = 20
        Animation6.Padding = New System.Windows.Forms.Padding(30)
        Animation6.RotateCoeff = 0!
        Animation6.RotateLimit = 0!
        Animation6.ScaleCoeff = CType(resources.GetObject("Animation6.ScaleCoeff"), System.Drawing.PointF)
        Animation6.SlideCoeff = CType(resources.GetObject("Animation6.SlideCoeff"), System.Drawing.PointF)
        Animation6.TimeCoeff = 0!
        Animation6.TransparencyCoeff = 0!
        Me.BunifuTransition5.DefaultAnimation = Animation6
        '
        'BunifuTransition6
        '
        Me.BunifuTransition6.AnimationType = BunifuAnimatorNS.AnimationType.Mosaic
        Me.BunifuTransition6.Cursor = Nothing
        Animation1.AnimateOnlyDifferences = True
        Animation1.BlindCoeff = CType(resources.GetObject("Animation1.BlindCoeff"), System.Drawing.PointF)
        Animation1.LeafCoeff = 0!
        Animation1.MaxTime = 1.0!
        Animation1.MinTime = 0!
        Animation1.MosaicCoeff = CType(resources.GetObject("Animation1.MosaicCoeff"), System.Drawing.PointF)
        Animation1.MosaicShift = CType(resources.GetObject("Animation1.MosaicShift"), System.Drawing.PointF)
        Animation1.MosaicSize = 20
        Animation1.Padding = New System.Windows.Forms.Padding(30)
        Animation1.RotateCoeff = 0!
        Animation1.RotateLimit = 0!
        Animation1.ScaleCoeff = CType(resources.GetObject("Animation1.ScaleCoeff"), System.Drawing.PointF)
        Animation1.SlideCoeff = CType(resources.GetObject("Animation1.SlideCoeff"), System.Drawing.PointF)
        Animation1.TimeCoeff = 0!
        Animation1.TransparencyCoeff = 0!
        Me.BunifuTransition6.DefaultAnimation = Animation1
        '
        'CobroEmpeño
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.SAC_CONFIA.My.Resources.Resources.SAC
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1313, 765)
        Me.Controls.Add(Me.txtOtraCantidad)
        Me.Controls.Add(Me.txtRefrendo)
        Me.Controls.Add(Me.txtInteresDiario)
        Me.Controls.Add(Me.txtUltimoPago)
        Me.Controls.Add(Me.txtDesempeño)
        Me.Controls.Add(Me.txtPrestado)
        Me.Controls.Add(Me.MonoFlat_Label6)
        Me.Controls.Add(Me.MonoFlat_Label5)
        Me.Controls.Add(Me.MonoFlat_Label4)
        Me.Controls.Add(Me.MonoFlat_Label3)
        Me.Controls.Add(Me.MonoFlat_Label2)
        Me.Controls.Add(Me.lblnombre)
        Me.Controls.Add(Me.MonoFlat_Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtid)
        Me.BunifuTransition6.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition4.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition5.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CobroEmpeño"
        Me.RightToLeftLayout = True
        Me.Text = "inicio"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtid As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents Button1 As Button
    Friend WithEvents MonoFlat_Label1 As MonoFlat.MonoFlat_Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblnombre As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents ZeroitMetroWebChart1 As Zeroit.Framework.Metro.ZeroitMetroWebChart
    Friend WithEvents MonoFlat_Label2 As MonoFlat.MonoFlat_Label
    Friend WithEvents MonoFlat_Label3 As MonoFlat.MonoFlat_Label
    Friend WithEvents MonoFlat_Label4 As MonoFlat.MonoFlat_Label
    Friend WithEvents MonoFlat_Label5 As MonoFlat.MonoFlat_Label
    Friend WithEvents MonoFlat_Label6 As MonoFlat.MonoFlat_Label
    Friend WithEvents txtPrestado As Button
    Friend WithEvents txtDesempeño As Button
    Friend WithEvents txtUltimoPago As Button
    Friend WithEvents txtInteresDiario As Button
    Friend WithEvents txtRefrendo As Button
    Friend WithEvents txtOtraCantidad As Button
    Friend WithEvents BunifuTransition6 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition2 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition1 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition4 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition3 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition5 As BunifuAnimatorNS.BunifuTransition
End Class
