<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComisionEnganche
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.btnEnganche = New Zeroit.Framework.Metro.ZeroitMetroButton()
        Me.btnComision = New Zeroit.Framework.Metro.ZeroitMetroButton()
        Me.BackgroundCobrados = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(566, 36)
        Me.Panel1.TabIndex = 4
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 5)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(157, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Comisión y enganche"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(497, 5)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 0
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'btnEnganche
        '
        Me.btnEnganche.BackColor = System.Drawing.Color.Transparent
        Me.btnEnganche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEnganche.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnEnganche.DefaultColor = System.Drawing.Color.White
        Me.btnEnganche.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnEnganche.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEnganche.HoverColor = System.Drawing.Color.White
        Me.btnEnganche.IsRound = True
        Me.btnEnganche.Location = New System.Drawing.Point(327, 84)
        Me.btnEnganche.Name = "btnEnganche"
        Me.btnEnganche.PressedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnEnganche.RoundingArc = 106
        Me.btnEnganche.Size = New System.Drawing.Size(106, 106)
        Me.btnEnganche.TabIndex = 7
        Me.btnEnganche.Text = "Enganche"
        '
        'btnComision
        '
        Me.btnComision.BackColor = System.Drawing.Color.Transparent
        Me.btnComision.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnComision.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnComision.DefaultColor = System.Drawing.Color.White
        Me.btnComision.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnComision.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnComision.HoverColor = System.Drawing.Color.White
        Me.btnComision.IsRound = True
        Me.btnComision.Location = New System.Drawing.Point(114, 84)
        Me.btnComision.Name = "btnComision"
        Me.btnComision.PressedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnComision.RoundingArc = 106
        Me.btnComision.Size = New System.Drawing.Size(106, 106)
        Me.btnComision.TabIndex = 6
        Me.btnComision.Text = "Comisión por apertura"
        '
        'BackgroundCobrados
        '
        '
        'ComisionEnganche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(569, 272)
        Me.Controls.Add(Me.btnEnganche)
        Me.Controls.Add(Me.btnComision)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ComisionEnganche"
        Me.Text = "ComisionEnganche"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents btnEnganche As Zeroit.Framework.Metro.ZeroitMetroButton
    Friend WithEvents btnComision As Zeroit.Framework.Metro.ZeroitMetroButton
    Friend WithEvents BackgroundCobrados As System.ComponentModel.BackgroundWorker
End Class
