<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MonoFlat_Button2 = New SAC_CONFIA.MonoFlat.MonoFlat_Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MonoFlat_LinkLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_LinkLabel()
        Me.MonoFlat_Button1 = New SAC_CONFIA.MonoFlat.MonoFlat_Button()
        Me.MonoFlat_Label2 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.MonoFlat_Label1 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.txtcontra = New SAC_CONFIA.MonoFlat.MonoFlat_TextBox()
        Me.txtusr = New SAC_CONFIA.MonoFlat.MonoFlat_TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'MonoFlat_Button2
        '
        Me.MonoFlat_Button2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Button2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.MonoFlat_Button2.Image = Nothing
        Me.MonoFlat_Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MonoFlat_Button2.Location = New System.Drawing.Point(320, 357)
        Me.MonoFlat_Button2.Name = "MonoFlat_Button2"
        Me.MonoFlat_Button2.Size = New System.Drawing.Size(146, 41)
        Me.MonoFlat_Button2.TabIndex = 18
        Me.MonoFlat_Button2.Text = "MonoFlat_Button2"
        Me.MonoFlat_Button2.TextAlignment = System.Drawing.StringAlignment.Center
        Me.MonoFlat_Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(356, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'MonoFlat_LinkLabel1
        '
        Me.MonoFlat_LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.MonoFlat_LinkLabel1.AutoSize = True
        Me.MonoFlat_LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.MonoFlat_LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.MonoFlat_LinkLabel1.Location = New System.Drawing.Point(317, 258)
        Me.MonoFlat_LinkLabel1.Name = "MonoFlat_LinkLabel1"
        Me.MonoFlat_LinkLabel1.Size = New System.Drawing.Size(141, 15)
        Me.MonoFlat_LinkLabel1.TabIndex = 14
        Me.MonoFlat_LinkLabel1.TabStop = True
        Me.MonoFlat_LinkLabel1.Text = "¿Olvidaste tu contraseña?"
        Me.MonoFlat_LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(42, Byte), Integer))
        '
        'MonoFlat_Button1
        '
        Me.MonoFlat_Button1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MonoFlat_Button1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.MonoFlat_Button1.Image = Nothing
        Me.MonoFlat_Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MonoFlat_Button1.Location = New System.Drawing.Point(345, 292)
        Me.MonoFlat_Button1.Name = "MonoFlat_Button1"
        Me.MonoFlat_Button1.Size = New System.Drawing.Size(146, 41)
        Me.MonoFlat_Button1.TabIndex = 13
        Me.MonoFlat_Button1.Text = "Ingresar"
        Me.MonoFlat_Button1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'MonoFlat_Label2
        '
        Me.MonoFlat_Label2.AutoSize = True
        Me.MonoFlat_Label2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label2.Location = New System.Drawing.Point(317, 98)
        Me.MonoFlat_Label2.Name = "MonoFlat_Label2"
        Me.MonoFlat_Label2.Size = New System.Drawing.Size(47, 15)
        Me.MonoFlat_Label2.TabIndex = 16
        Me.MonoFlat_Label2.Text = "Usuario"
        '
        'MonoFlat_Label1
        '
        Me.MonoFlat_Label1.AutoSize = True
        Me.MonoFlat_Label1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label1.Location = New System.Drawing.Point(317, 181)
        Me.MonoFlat_Label1.Name = "MonoFlat_Label1"
        Me.MonoFlat_Label1.Size = New System.Drawing.Size(67, 15)
        Me.MonoFlat_Label1.TabIndex = 15
        Me.MonoFlat_Label1.Text = "Contraseña"
        '
        'txtcontra
        '
        Me.txtcontra.BackColor = System.Drawing.Color.Transparent
        Me.txtcontra.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtcontra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtcontra.Image = Global.SAC_CONFIA.My.Resources.Resources.contraseña
        Me.txtcontra.Location = New System.Drawing.Point(320, 199)
        Me.txtcontra.MaxLength = 32767
        Me.txtcontra.Multiline = False
        Me.txtcontra.Name = "txtcontra"
        Me.txtcontra.ReadOnly = False
        Me.txtcontra.Size = New System.Drawing.Size(202, 41)
        Me.txtcontra.TabIndex = 1
        Me.txtcontra.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtcontra.UseSystemPasswordChar = True
        '
        'txtusr
        '
        Me.txtusr.BackColor = System.Drawing.Color.Transparent
        Me.txtusr.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtusr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtusr.Image = Global.SAC_CONFIA.My.Resources.Resources.usr
        Me.txtusr.Location = New System.Drawing.Point(320, 116)
        Me.txtusr.MaxLength = 32767
        Me.txtusr.Multiline = False
        Me.txtusr.Name = "txtusr"
        Me.txtusr.ReadOnly = False
        Me.txtusr.Size = New System.Drawing.Size(202, 41)
        Me.txtusr.TabIndex = 0
        Me.txtusr.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtusr.UseSystemPasswordChar = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SAC_CONFIA.My.Resources.Resources.logo_dando_vueltas
        Me.PictureBox1.Location = New System.Drawing.Point(45, 119)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(189, 178)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(565, 36)
        Me.Panel1.TabIndex = 19
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 3)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(174, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 21
        Me.MonoFlat_HeaderLabel1.Text = "Préstamos Confía - SAC"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(496, 3)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 20
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(567, 452)
        Me.Controls.Add(Me.txtusr)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MonoFlat_Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MonoFlat_LinkLabel1)
        Me.Controls.Add(Me.MonoFlat_Button1)
        Me.Controls.Add(Me.MonoFlat_Label2)
        Me.Controls.Add(Me.MonoFlat_Label1)
        Me.Controls.Add(Me.txtcontra)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de sesión"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MonoFlat_Button2 As MonoFlat.MonoFlat_Button
    Friend WithEvents Button1 As Button
    Friend WithEvents MonoFlat_LinkLabel1 As MonoFlat.MonoFlat_LinkLabel
    Friend WithEvents MonoFlat_Button1 As MonoFlat.MonoFlat_Button
    Friend WithEvents MonoFlat_Label2 As MonoFlat.MonoFlat_Label
    Friend WithEvents MonoFlat_Label1 As MonoFlat.MonoFlat_Label
    Friend WithEvents txtcontra As MonoFlat.MonoFlat_TextBox
    Friend WithEvents txtusr As MonoFlat.MonoFlat_TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
End Class
