<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Liquidaciones
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Liquidaciones))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.btnNormal = New Zeroit.Framework.Metro.ZeroitMetroButton()
        Me.btnInsoluto = New Zeroit.Framework.Metro.ZeroitMetroButton()
        Me.ClickAnimator2 = New Zeroit.Framework.Metro.ClickAnimator()
        Me.ClickAnimator1 = New Zeroit.Framework.Metro.ClickAnimator()
        Me.lblRenovacion = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblnota = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(566, 36)
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
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(224, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Calcular Liquidación de Crédito"
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
        'btnNormal
        '
        Me.btnNormal.BackColor = System.Drawing.Color.Transparent
        Me.btnNormal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNormal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnNormal.DefaultColor = System.Drawing.Color.White
        Me.btnNormal.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnNormal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNormal.HoverColor = System.Drawing.Color.White
        Me.btnNormal.IsRound = True
        Me.btnNormal.Location = New System.Drawing.Point(123, 97)
        Me.btnNormal.Name = "btnNormal"
        Me.btnNormal.PressedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnNormal.RoundingArc = 106
        Me.btnNormal.Size = New System.Drawing.Size(106, 106)
        Me.btnNormal.TabIndex = 4
        Me.btnNormal.Text = "Normal"
        '
        'btnInsoluto
        '
        Me.btnInsoluto.BackColor = System.Drawing.Color.Transparent
        Me.btnInsoluto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnInsoluto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(98, Byte), Integer))
        Me.btnInsoluto.DefaultColor = System.Drawing.Color.White
        Me.btnInsoluto.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.btnInsoluto.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnInsoluto.HoverColor = System.Drawing.Color.White
        Me.btnInsoluto.IsRound = True
        Me.btnInsoluto.Location = New System.Drawing.Point(336, 97)
        Me.btnInsoluto.Name = "btnInsoluto"
        Me.btnInsoluto.PressedColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnInsoluto.RoundingArc = 106
        Me.btnInsoluto.Size = New System.Drawing.Size(106, 106)
        Me.btnInsoluto.TabIndex = 5
        Me.btnInsoluto.Text = "Saldo Insoluto"
        '
        'ClickAnimator2
        '
        Me.ClickAnimator2.ClickControl = Me.btnNormal
        Me.ClickAnimator2.Shape = Zeroit.Framework.Metro.ClickAnimator.DrawMode.Rectangle
        Me.ClickAnimator2.Speed = 11
        '
        'ClickAnimator1
        '
        Me.ClickAnimator1.ClickControl = Me.btnInsoluto
        Me.ClickAnimator1.Shape = Zeroit.Framework.Metro.ClickAnimator.DrawMode.Circle
        Me.ClickAnimator1.Speed = 11
        '
        'lblRenovacion
        '
        Me.lblRenovacion.AutoSize = True
        Me.lblRenovacion.BackColor = System.Drawing.Color.Transparent
        Me.lblRenovacion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblRenovacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblRenovacion.Location = New System.Drawing.Point(5, 51)
        Me.lblRenovacion.Name = "lblRenovacion"
        Me.lblRenovacion.Size = New System.Drawing.Size(302, 20)
        Me.lblRenovacion.TabIndex = 2
        Me.lblRenovacion.Text = "Presiona F4 para marcar como renovación"
        '
        'lblnota
        '
        Me.lblnota.AutoSize = True
        Me.lblnota.BackColor = System.Drawing.Color.Transparent
        Me.lblnota.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnota.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblnota.Location = New System.Drawing.Point(5, 243)
        Me.lblnota.Name = "lblnota"
        Me.lblnota.Size = New System.Drawing.Size(532, 17)
        Me.lblnota.TabIndex = 6
        Me.lblnota.Text = "Nota: éste movimiento afectará la cuenta del cliente pero no el acumulado de la c" &
    "aja"
        Me.lblnota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblnota.Visible = False
        '
        'Liquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(570, 272)
        Me.Controls.Add(Me.lblnota)
        Me.Controls.Add(Me.lblRenovacion)
        Me.Controls.Add(Me.btnInsoluto)
        Me.Controls.Add(Me.btnNormal)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Liquidaciones"
        Me.Text = "Liquidaciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents btnNormal As Zeroit.Framework.Metro.ZeroitMetroButton
    Friend WithEvents btnInsoluto As Zeroit.Framework.Metro.ZeroitMetroButton
    Friend WithEvents ClickAnimator2 As Zeroit.Framework.Metro.ClickAnimator
    Friend WithEvents ClickAnimator1 As Zeroit.Framework.Metro.ClickAnimator
    Friend WithEvents lblRenovacion As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblnota As MonoFlat.MonoFlat_HeaderLabel
End Class
