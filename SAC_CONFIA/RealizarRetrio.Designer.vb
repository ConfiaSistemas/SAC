<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RealizarRetrio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RealizarRetrio))
        Me.MonoFlat_HeaderLabel3 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.txtmonto = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.Combofiltro = New System.Windows.Forms.ComboBox()
        Me.MonoFlat_HeaderLabel2 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblconcepto = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.txtConcepto = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.btn_actualizar = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BackgroundRetiro = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MonoFlat_HeaderLabel3
        '
        Me.MonoFlat_HeaderLabel3.AutoSize = True
        Me.MonoFlat_HeaderLabel3.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel3.Location = New System.Drawing.Point(75, 47)
        Me.MonoFlat_HeaderLabel3.Name = "MonoFlat_HeaderLabel3"
        Me.MonoFlat_HeaderLabel3.Size = New System.Drawing.Size(56, 20)
        Me.MonoFlat_HeaderLabel3.TabIndex = 10
        Me.MonoFlat_HeaderLabel3.Text = "Monto"
        '
        'txtmonto
        '
        Me.txtmonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.txtmonto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtmonto.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtmonto.ForeColor = System.Drawing.Color.White
        Me.txtmonto.HintForeColor = System.Drawing.Color.White
        Me.txtmonto.HintText = ""
        Me.txtmonto.isPassword = False
        Me.txtmonto.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtmonto.LineIdleColor = System.Drawing.Color.Gray
        Me.txtmonto.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtmonto.LineThickness = 3
        Me.txtmonto.Location = New System.Drawing.Point(79, 71)
        Me.txtmonto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(263, 33)
        Me.txtmonto.TabIndex = 11
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 36)
        Me.Panel1.TabIndex = 12
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 7)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(111, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Realizar Retiro"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(364, 3)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 0
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'Combofiltro
        '
        Me.Combofiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combofiltro.FormattingEnabled = True
        Me.Combofiltro.Items.AddRange(New Object() {"Retiro por límite excedido", "Retiro por cierre de día", "Otro"})
        Me.Combofiltro.Location = New System.Drawing.Point(79, 172)
        Me.Combofiltro.Name = "Combofiltro"
        Me.Combofiltro.Size = New System.Drawing.Size(184, 21)
        Me.Combofiltro.TabIndex = 13
        '
        'MonoFlat_HeaderLabel2
        '
        Me.MonoFlat_HeaderLabel2.AutoSize = True
        Me.MonoFlat_HeaderLabel2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel2.Location = New System.Drawing.Point(75, 137)
        Me.MonoFlat_HeaderLabel2.Name = "MonoFlat_HeaderLabel2"
        Me.MonoFlat_HeaderLabel2.Size = New System.Drawing.Size(75, 20)
        Me.MonoFlat_HeaderLabel2.TabIndex = 14
        Me.MonoFlat_HeaderLabel2.Text = "Concepto"
        '
        'lblconcepto
        '
        Me.lblconcepto.AutoSize = True
        Me.lblconcepto.BackColor = System.Drawing.Color.Transparent
        Me.lblconcepto.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblconcepto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblconcepto.Location = New System.Drawing.Point(75, 212)
        Me.lblconcepto.Name = "lblconcepto"
        Me.lblconcepto.Size = New System.Drawing.Size(75, 20)
        Me.lblconcepto.TabIndex = 15
        Me.lblconcepto.Text = "Concepto"
        Me.lblconcepto.Visible = False
        '
        'txtConcepto
        '
        Me.txtConcepto.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.txtConcepto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConcepto.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtConcepto.ForeColor = System.Drawing.Color.White
        Me.txtConcepto.HintForeColor = System.Drawing.Color.White
        Me.txtConcepto.HintText = ""
        Me.txtConcepto.isPassword = False
        Me.txtConcepto.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtConcepto.LineIdleColor = System.Drawing.Color.Gray
        Me.txtConcepto.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtConcepto.LineThickness = 3
        Me.txtConcepto.Location = New System.Drawing.Point(79, 236)
        Me.txtConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(263, 33)
        Me.txtConcepto.TabIndex = 16
        Me.txtConcepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtConcepto.Visible = False
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
        Me.btn_actualizar.ButtonText = "Realizar Retiro"
        Me.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_actualizar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btn_actualizar.IdleBorderThickness = 1
        Me.btn_actualizar.IdleCornerRadius = 20
        Me.btn_actualizar.IdleFillColor = System.Drawing.Color.White
        Me.btn_actualizar.IdleForecolor = System.Drawing.Color.Gray
        Me.btn_actualizar.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_actualizar.Location = New System.Drawing.Point(121, 309)
        Me.btn_actualizar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(207, 38)
        Me.btn_actualizar.TabIndex = 26
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundRetiro
        '
        '
        'RealizarRetrio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(437, 379)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.lblconcepto)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel2)
        Me.Controls.Add(Me.Combofiltro)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel3)
        Me.Controls.Add(Me.txtmonto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RealizarRetrio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Realizar Retiro"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MonoFlat_HeaderLabel3 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents txtmonto As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents Combofiltro As ComboBox
    Friend WithEvents MonoFlat_HeaderLabel2 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblconcepto As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents txtConcepto As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents btn_actualizar As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BackgroundRetiro As System.ComponentModel.BackgroundWorker
End Class
