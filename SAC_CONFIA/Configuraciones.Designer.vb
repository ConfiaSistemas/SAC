<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuraciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuraciones))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.txtIp = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.txtBD = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.btn_Procesar = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboImpresora = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCaja = New Bunifu.Framework.UI.BunifuMaterialTextbox()
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
        Me.Panel1.Size = New System.Drawing.Size(738, 36)
        Me.Panel1.TabIndex = 3
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 3)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(207, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Configuración de la terminal"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(669, 3)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 0
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'txtIp
        '
        Me.txtIp.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIp.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtIp.ForeColor = System.Drawing.Color.White
        Me.txtIp.HintForeColor = System.Drawing.Color.Empty
        Me.txtIp.HintText = ""
        Me.txtIp.isPassword = False
        Me.txtIp.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtIp.LineIdleColor = System.Drawing.Color.Gray
        Me.txtIp.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtIp.LineThickness = 3
        Me.txtIp.Location = New System.Drawing.Point(136, 123)
        Me.txtIp.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(379, 33)
        Me.txtIp.TabIndex = 4
        Me.txtIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'txtBD
        '
        Me.txtBD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBD.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtBD.ForeColor = System.Drawing.Color.White
        Me.txtBD.HintForeColor = System.Drawing.Color.Empty
        Me.txtBD.HintText = ""
        Me.txtBD.isPassword = False
        Me.txtBD.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtBD.LineIdleColor = System.Drawing.Color.Gray
        Me.txtBD.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtBD.LineThickness = 3
        Me.txtBD.Location = New System.Drawing.Point(136, 197)
        Me.txtBD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBD.Name = "txtBD"
        Me.txtBD.Size = New System.Drawing.Size(379, 33)
        Me.txtBD.TabIndex = 5
        Me.txtBD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btn_Procesar
        '
        Me.btn_Procesar.ActiveBorderThickness = 1
        Me.btn_Procesar.ActiveCornerRadius = 20
        Me.btn_Procesar.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_Procesar.ActiveForecolor = System.Drawing.Color.White
        Me.btn_Procesar.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btn_Procesar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.btn_Procesar.BackgroundImage = CType(resources.GetObject("btn_Procesar.BackgroundImage"), System.Drawing.Image)
        Me.btn_Procesar.ButtonText = "Guardar"
        Me.btn_Procesar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Procesar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Procesar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btn_Procesar.IdleBorderThickness = 1
        Me.btn_Procesar.IdleCornerRadius = 20
        Me.btn_Procesar.IdleFillColor = System.Drawing.Color.White
        Me.btn_Procesar.IdleForecolor = System.Drawing.Color.Gray
        Me.btn_Procesar.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_Procesar.Location = New System.Drawing.Point(230, 385)
        Me.btn_Procesar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_Procesar.Name = "btn_Procesar"
        Me.btn_Procesar.Size = New System.Drawing.Size(216, 38)
        Me.btn_Procesar.TabIndex = 32
        Me.btn_Procesar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(133, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Ip del servidor de empresas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(133, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Base de datos de empresas"
        '
        'ComboImpresora
        '
        Me.ComboImpresora.FormattingEnabled = True
        Me.ComboImpresora.Location = New System.Drawing.Point(136, 338)
        Me.ComboImpresora.Name = "ComboImpresora"
        Me.ComboImpresora.Size = New System.Drawing.Size(379, 21)
        Me.ComboImpresora.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(133, 313)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Impresora Predeterminada"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(133, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Número de Caja"
        '
        'txtCaja
        '
        Me.txtCaja.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCaja.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtCaja.ForeColor = System.Drawing.Color.White
        Me.txtCaja.HintForeColor = System.Drawing.Color.Empty
        Me.txtCaja.HintText = ""
        Me.txtCaja.isPassword = False
        Me.txtCaja.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtCaja.LineIdleColor = System.Drawing.Color.Gray
        Me.txtCaja.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtCaja.LineThickness = 3
        Me.txtCaja.Location = New System.Drawing.Point(136, 262)
        Me.txtCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Size = New System.Drawing.Size(379, 33)
        Me.txtCaja.TabIndex = 37
        Me.txtCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Configuraciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(744, 435)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCaja)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboImpresora)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_Procesar)
        Me.Controls.Add(Me.txtBD)
        Me.Controls.Add(Me.txtIp)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Configuraciones"
        Me.Text = "Configuraciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents txtIp As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents txtBD As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents btn_Procesar As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboImpresora As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCaja As Bunifu.Framework.UI.BunifuMaterialTextbox
End Class
