<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OtraCantidadEmpeño
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OtraCantidadEmpeño))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.MonoFlat_HeaderLabel2 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblminimo = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.txtcantidad = New Bunifu.Framework.UI.BunifuMetroTextbox()
        Me.txtOtraCantidad = New System.Windows.Forms.Button()
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
        Me.Panel1.Size = New System.Drawing.Size(492, 36)
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
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(146, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Pagar otra cantidad"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(423, 5)
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
        Me.MonoFlat_HeaderLabel2.AutoSize = True
        Me.MonoFlat_HeaderLabel2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel2.Location = New System.Drawing.Point(12, 61)
        Me.MonoFlat_HeaderLabel2.Name = "MonoFlat_HeaderLabel2"
        Me.MonoFlat_HeaderLabel2.Size = New System.Drawing.Size(124, 20)
        Me.MonoFlat_HeaderLabel2.TabIndex = 2
        Me.MonoFlat_HeaderLabel2.Text = "Mínimo a pagar:"
        '
        'lblminimo
        '
        Me.lblminimo.AutoSize = True
        Me.lblminimo.BackColor = System.Drawing.Color.Transparent
        Me.lblminimo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblminimo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblminimo.Location = New System.Drawing.Point(142, 61)
        Me.lblminimo.Name = "lblminimo"
        Me.lblminimo.Size = New System.Drawing.Size(21, 20)
        Me.lblminimo.TabIndex = 4
        Me.lblminimo.Text = "..."
        '
        'txtcantidad
        '
        Me.txtcantidad.BorderColorFocused = System.Drawing.Color.Blue
        Me.txtcantidad.BorderColorIdle = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcantidad.BorderColorMouseHover = System.Drawing.Color.Blue
        Me.txtcantidad.BorderThickness = 3
        Me.txtcantidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcantidad.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtcantidad.ForeColor = System.Drawing.Color.White
        Me.txtcantidad.isPassword = False
        Me.txtcantidad.Location = New System.Drawing.Point(121, 101)
        Me.txtcantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(260, 44)
        Me.txtcantidad.TabIndex = 5
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'txtOtraCantidad
        '
        Me.txtOtraCantidad.FlatAppearance.BorderSize = 3
        Me.txtOtraCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtOtraCantidad.ForeColor = System.Drawing.Color.Transparent
        Me.txtOtraCantidad.Location = New System.Drawing.Point(213, 163)
        Me.txtOtraCantidad.Name = "txtOtraCantidad"
        Me.txtOtraCantidad.Size = New System.Drawing.Size(76, 45)
        Me.txtOtraCantidad.TabIndex = 43
        Me.txtOtraCantidad.Text = "Aceptar"
        Me.txtOtraCantidad.UseVisualStyleBackColor = True
        '
        'OtraCantidadEmpeño
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(494, 224)
        Me.Controls.Add(Me.txtOtraCantidad)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.lblminimo)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OtraCantidadEmpeño"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Otra Cantidad"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents MonoFlat_HeaderLabel2 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblminimo As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents txtcantidad As Bunifu.Framework.UI.BunifuMetroTextbox
    Friend WithEvents txtOtraCantidad As Button
End Class
