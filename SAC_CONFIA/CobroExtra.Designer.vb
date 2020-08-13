<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CobroExtra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CobroExtra))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.MonoFlat_HeaderLabel2 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.txtMonto = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.txtConcepto = New Zeroit.Framework.Metro.ZeroitMetroTextbox()
        Me.MonoFlat_Label1 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.MonoFlat_Label2 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.btn_actualizar = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(515, 36)
        Me.Panel1.TabIndex = 3
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 5)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(155, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Cobro Extraordinario"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(446, 5)
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
        Me.MonoFlat_HeaderLabel2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel2.Cursor = System.Windows.Forms.Cursors.No
        Me.MonoFlat_HeaderLabel2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel2.Location = New System.Drawing.Point(5, 41)
        Me.MonoFlat_HeaderLabel2.Name = "MonoFlat_HeaderLabel2"
        Me.MonoFlat_HeaderLabel2.Size = New System.Drawing.Size(501, 44)
        Me.MonoFlat_HeaderLabel2.TabIndex = 2
        Me.MonoFlat_HeaderLabel2.Text = "Nota: Éste ticket no afecta la cuenta de ningún cliente, pero sí el acumulado de " &
    "la caja"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.txtMonto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMonto.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtMonto.ForeColor = System.Drawing.Color.White
        Me.txtMonto.HintForeColor = System.Drawing.Color.White
        Me.txtMonto.HintText = ""
        Me.txtMonto.isPassword = False
        Me.txtMonto.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtMonto.LineIdleColor = System.Drawing.Color.Gray
        Me.txtMonto.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtMonto.LineThickness = 3
        Me.txtMonto.Location = New System.Drawing.Point(110, 271)
        Me.txtMonto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(318, 33)
        Me.txtMonto.TabIndex = 11
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'txtConcepto
        '
        Me.txtConcepto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.txtConcepto.Border = 1
        Me.txtConcepto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.txtConcepto.DefaultColor = System.Drawing.Color.White
        Me.txtConcepto.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtConcepto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConcepto.HideSelection = False
        Me.txtConcepto.HoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtConcepto.Location = New System.Drawing.Point(101, 131)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtConcepto.Size = New System.Drawing.Size(327, 100)
        Me.txtConcepto.TabIndex = 12
        '
        'MonoFlat_Label1
        '
        Me.MonoFlat_Label1.AutoSize = True
        Me.MonoFlat_Label1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label1.Location = New System.Drawing.Point(98, 102)
        Me.MonoFlat_Label1.Name = "MonoFlat_Label1"
        Me.MonoFlat_Label1.Size = New System.Drawing.Size(62, 15)
        Me.MonoFlat_Label1.TabIndex = 13
        Me.MonoFlat_Label1.Text = "Concepto:"
        '
        'MonoFlat_Label2
        '
        Me.MonoFlat_Label2.AutoSize = True
        Me.MonoFlat_Label2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label2.Location = New System.Drawing.Point(107, 252)
        Me.MonoFlat_Label2.Name = "MonoFlat_Label2"
        Me.MonoFlat_Label2.Size = New System.Drawing.Size(46, 15)
        Me.MonoFlat_Label2.TabIndex = 14
        Me.MonoFlat_Label2.Text = "Monto:"
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
        Me.btn_actualizar.Location = New System.Drawing.Point(166, 327)
        Me.btn_actualizar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(207, 38)
        Me.btn_actualizar.TabIndex = 21
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CobroExtra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(518, 389)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.MonoFlat_Label2)
        Me.Controls.Add(Me.MonoFlat_Label1)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CobroExtra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CobroExtra"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents MonoFlat_HeaderLabel2 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents txtMonto As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents txtConcepto As Zeroit.Framework.Metro.ZeroitMetroTextbox
    Friend WithEvents MonoFlat_Label1 As MonoFlat.MonoFlat_Label
    Friend WithEvents MonoFlat_Label2 As MonoFlat.MonoFlat_Label
    Friend WithEvents btn_actualizar As Bunifu.Framework.UI.BunifuThinButton2
End Class
