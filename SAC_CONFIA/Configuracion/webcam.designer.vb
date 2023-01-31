<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class webcam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(webcam))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.VideoSourcePlayer1 = New AForge.Controls.VideoSourcePlayer()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Btn_iniciar = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btn_detener = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.btn_capturar = New Bunifu.Framework.UI.BunifuThinButton2()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(502, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(79, 29)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "WebCam"
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(68, 23)
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'VideoSourcePlayer1
        '
        Me.VideoSourcePlayer1.Location = New System.Drawing.Point(79, 81)
        Me.VideoSourcePlayer1.Name = "VideoSourcePlayer1"
        Me.VideoSourcePlayer1.Size = New System.Drawing.Size(287, 179)
        Me.VideoSourcePlayer1.TabIndex = 17
        Me.VideoSourcePlayer1.Text = "VideoSourcePlayer1"
        Me.VideoSourcePlayer1.VideoSource = Nothing
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(79, 36)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 18
        '
        'Btn_iniciar
        '
        Me.Btn_iniciar.ActiveBorderThickness = 1
        Me.Btn_iniciar.ActiveCornerRadius = 20
        Me.Btn_iniciar.ActiveFillColor = System.Drawing.Color.DimGray
        Me.Btn_iniciar.ActiveForecolor = System.Drawing.Color.White
        Me.Btn_iniciar.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.Btn_iniciar.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_iniciar.BackgroundImage = CType(resources.GetObject("Btn_iniciar.BackgroundImage"), System.Drawing.Image)
        Me.Btn_iniciar.ButtonText = "Iniciar"
        Me.Btn_iniciar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btn_iniciar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_iniciar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Btn_iniciar.IdleBorderThickness = 1
        Me.Btn_iniciar.IdleCornerRadius = 20
        Me.Btn_iniciar.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Btn_iniciar.IdleForecolor = System.Drawing.Color.WhiteSmoke
        Me.Btn_iniciar.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.Btn_iniciar.Location = New System.Drawing.Point(221, 25)
        Me.Btn_iniciar.Margin = New System.Windows.Forms.Padding(5)
        Me.Btn_iniciar.Name = "Btn_iniciar"
        Me.Btn_iniciar.Size = New System.Drawing.Size(89, 41)
        Me.Btn_iniciar.TabIndex = 19
        Me.Btn_iniciar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_detener
        '
        Me.btn_detener.ActiveBorderThickness = 1
        Me.btn_detener.ActiveCornerRadius = 20
        Me.btn_detener.ActiveFillColor = System.Drawing.Color.DimGray
        Me.btn_detener.ActiveForecolor = System.Drawing.Color.White
        Me.btn_detener.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btn_detener.BackColor = System.Drawing.SystemColors.Control
        Me.btn_detener.BackgroundImage = CType(resources.GetObject("btn_detener.BackgroundImage"), System.Drawing.Image)
        Me.btn_detener.ButtonText = "Detener"
        Me.btn_detener.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_detener.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_detener.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_detener.IdleBorderThickness = 1
        Me.btn_detener.IdleCornerRadius = 20
        Me.btn_detener.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_detener.IdleForecolor = System.Drawing.Color.WhiteSmoke
        Me.btn_detener.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btn_detener.Location = New System.Drawing.Point(320, 25)
        Me.btn_detener.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_detener.Name = "btn_detener"
        Me.btn_detener.Size = New System.Drawing.Size(89, 41)
        Me.btn_detener.TabIndex = 20
        Me.btn_detener.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(509, 12)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 13
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'btn_capturar
        '
        Me.btn_capturar.ActiveBorderThickness = 1
        Me.btn_capturar.ActiveCornerRadius = 20
        Me.btn_capturar.ActiveFillColor = System.Drawing.Color.DimGray
        Me.btn_capturar.ActiveForecolor = System.Drawing.Color.White
        Me.btn_capturar.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btn_capturar.BackColor = System.Drawing.SystemColors.Control
        Me.btn_capturar.BackgroundImage = CType(resources.GetObject("btn_capturar.BackgroundImage"), System.Drawing.Image)
        Me.btn_capturar.ButtonText = "Capturar"
        Me.btn_capturar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_capturar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_capturar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn_capturar.IdleBorderThickness = 1
        Me.btn_capturar.IdleCornerRadius = 20
        Me.btn_capturar.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btn_capturar.IdleForecolor = System.Drawing.Color.WhiteSmoke
        Me.btn_capturar.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btn_capturar.Location = New System.Drawing.Point(412, 25)
        Me.btn_capturar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_capturar.Name = "btn_capturar"
        Me.btn_capturar.Size = New System.Drawing.Size(89, 41)
        Me.btn_capturar.TabIndex = 21
        Me.btn_capturar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'webcam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 304)
        Me.Controls.Add(Me.btn_capturar)
        Me.Controls.Add(Me.btn_detener)
        Me.Controls.Add(Me.Btn_iniciar)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.VideoSourcePlayer1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.EvolveControlBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "webcam"
        Me.Text = "webcam"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EvolveControlBox1 As SAC_CONFIA.EvolveControlBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents VideoSourcePlayer1 As AForge.Controls.VideoSourcePlayer
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_iniciar As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btn_detener As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btn_capturar As Bunifu.Framework.UI.BunifuThinButton2
End Class
