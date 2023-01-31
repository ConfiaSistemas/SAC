<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Autorizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Autorizacion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.MonoFlat_Label2 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.MonoFlat_Label1 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.txtcontra = New SAC_CONFIA.MonoFlat.MonoFlat_TextBox()
        Me.txtusr = New SAC_CONFIA.MonoFlat.MonoFlat_TextBox()
        Me.MonoFlat_Button1 = New SAC_CONFIA.MonoFlat.MonoFlat_Button()
        Me.MonoFlat_Button2 = New SAC_CONFIA.MonoFlat.MonoFlat_Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.FlowEspere = New System.Windows.Forms.FlowLayoutPanel()
        Me.MonoFlat_Label3 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.Panel1.SuspendLayout()
        Me.FlowEspere.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(292, 36)
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
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(98, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Autorización"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(223, 3)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 0
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'MonoFlat_Label2
        '
        Me.MonoFlat_Label2.AutoSize = True
        Me.MonoFlat_Label2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label2.Location = New System.Drawing.Point(50, 97)
        Me.MonoFlat_Label2.Name = "MonoFlat_Label2"
        Me.MonoFlat_Label2.Size = New System.Drawing.Size(47, 15)
        Me.MonoFlat_Label2.TabIndex = 20
        Me.MonoFlat_Label2.Text = "Usuario"
        '
        'MonoFlat_Label1
        '
        Me.MonoFlat_Label1.AutoSize = True
        Me.MonoFlat_Label1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label1.Location = New System.Drawing.Point(50, 180)
        Me.MonoFlat_Label1.Name = "MonoFlat_Label1"
        Me.MonoFlat_Label1.Size = New System.Drawing.Size(67, 15)
        Me.MonoFlat_Label1.TabIndex = 19
        Me.MonoFlat_Label1.Text = "Contraseña"
        '
        'txtcontra
        '
        Me.txtcontra.BackColor = System.Drawing.Color.Transparent
        Me.txtcontra.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtcontra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtcontra.Image = Global.SAC_CONFIA.My.Resources.Resources.contraseña
        Me.txtcontra.Location = New System.Drawing.Point(53, 198)
        Me.txtcontra.MaxLength = 32767
        Me.txtcontra.Multiline = False
        Me.txtcontra.Name = "txtcontra"
        Me.txtcontra.ReadOnly = False
        Me.txtcontra.Size = New System.Drawing.Size(202, 41)
        Me.txtcontra.TabIndex = 18
        Me.txtcontra.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtcontra.UseSystemPasswordChar = True
        '
        'txtusr
        '
        Me.txtusr.BackColor = System.Drawing.Color.Transparent
        Me.txtusr.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.txtusr.ForeColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.txtusr.Image = Global.SAC_CONFIA.My.Resources.Resources.usr
        Me.txtusr.Location = New System.Drawing.Point(53, 115)
        Me.txtusr.MaxLength = 32767
        Me.txtusr.Multiline = False
        Me.txtusr.Name = "txtusr"
        Me.txtusr.ReadOnly = False
        Me.txtusr.Size = New System.Drawing.Size(202, 41)
        Me.txtusr.TabIndex = 17
        Me.txtusr.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtusr.UseSystemPasswordChar = False
        '
        'MonoFlat_Button1
        '
        Me.MonoFlat_Button1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MonoFlat_Button1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.MonoFlat_Button1.Image = Nothing
        Me.MonoFlat_Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MonoFlat_Button1.Location = New System.Drawing.Point(53, 254)
        Me.MonoFlat_Button1.Name = "MonoFlat_Button1"
        Me.MonoFlat_Button1.Size = New System.Drawing.Size(85, 41)
        Me.MonoFlat_Button1.TabIndex = 21
        Me.MonoFlat_Button1.Text = "Aceptar"
        Me.MonoFlat_Button1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'MonoFlat_Button2
        '
        Me.MonoFlat_Button2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MonoFlat_Button2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.MonoFlat_Button2.Image = Nothing
        Me.MonoFlat_Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MonoFlat_Button2.Location = New System.Drawing.Point(170, 254)
        Me.MonoFlat_Button2.Name = "MonoFlat_Button2"
        Me.MonoFlat_Button2.Size = New System.Drawing.Size(85, 41)
        Me.MonoFlat_Button2.TabIndex = 22
        Me.MonoFlat_Button2.Text = "Cancelar"
        Me.MonoFlat_Button2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'BackgroundWorker1
        '
        '
        'FlowEspere
        '
        Me.FlowEspere.Controls.Add(Me.MonoFlat_Label3)
        Me.FlowEspere.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowEspere.Location = New System.Drawing.Point(268, 115)
        Me.FlowEspere.Name = "FlowEspere"
        Me.FlowEspere.Size = New System.Drawing.Size(23, 180)
        Me.FlowEspere.TabIndex = 23
        Me.FlowEspere.Visible = False
        '
        'MonoFlat_Label3
        '
        Me.MonoFlat_Label3.AutoSize = True
        Me.MonoFlat_Label3.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonoFlat_Label3.ForeColor = System.Drawing.Color.White
        Me.MonoFlat_Label3.Location = New System.Drawing.Point(3, 0)
        Me.MonoFlat_Label3.Name = "MonoFlat_Label3"
        Me.MonoFlat_Label3.Size = New System.Drawing.Size(18, 140)
        Me.MonoFlat_Label3.TabIndex = 0
        Me.MonoFlat_Label3.Text = "Espere."
        '
        'Autorizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(296, 322)
        Me.Controls.Add(Me.FlowEspere)
        Me.Controls.Add(Me.MonoFlat_Button2)
        Me.Controls.Add(Me.MonoFlat_Button1)
        Me.Controls.Add(Me.MonoFlat_Label2)
        Me.Controls.Add(Me.MonoFlat_Label1)
        Me.Controls.Add(Me.txtcontra)
        Me.Controls.Add(Me.txtusr)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Autorizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorizacion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowEspere.ResumeLayout(False)
        Me.FlowEspere.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents MonoFlat_Label2 As MonoFlat.MonoFlat_Label
    Friend WithEvents MonoFlat_Label1 As MonoFlat.MonoFlat_Label
    Friend WithEvents txtcontra As MonoFlat.MonoFlat_TextBox
    Friend WithEvents txtusr As MonoFlat.MonoFlat_TextBox
    Friend WithEvents MonoFlat_Button1 As MonoFlat.MonoFlat_Button
    Friend WithEvents MonoFlat_Button2 As MonoFlat.MonoFlat_Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents FlowEspere As FlowLayoutPanel
    Friend WithEvents MonoFlat_Label3 As MonoFlat.MonoFlat_Label
End Class
