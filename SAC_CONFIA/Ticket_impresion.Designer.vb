<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Ticket_impresion

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ticket_impresion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.txtTotal = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.MonoFlat_HeaderLabel2 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.MonoFlat_HeaderLabel3 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.txtRecibido = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.MonoFlat_HeaderLabel4 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.txtCambio = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MonoFlat_HeaderLabel5 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.txtDescuento = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.btn_actualizar = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.MonoFlat_HeaderLabel6 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.txtTotalApagar = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(475, 36)
        Me.Panel1.TabIndex = 2
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 5)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(51, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Ticket"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(406, 8)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 0
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtTotal.ForeColor = System.Drawing.Color.White
        Me.txtTotal.HintForeColor = System.Drawing.Color.Empty
        Me.txtTotal.HintText = ""
        Me.txtTotal.isPassword = False
        Me.txtTotal.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtTotal.LineIdleColor = System.Drawing.Color.Gray
        Me.txtTotal.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtTotal.LineThickness = 3
        Me.txtTotal.Location = New System.Drawing.Point(95, 92)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(263, 33)
        Me.txtTotal.TabIndex = 7
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'MonoFlat_HeaderLabel2
        '
        Me.MonoFlat_HeaderLabel2.AutoSize = True
        Me.MonoFlat_HeaderLabel2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel2.Location = New System.Drawing.Point(91, 68)
        Me.MonoFlat_HeaderLabel2.Name = "MonoFlat_HeaderLabel2"
        Me.MonoFlat_HeaderLabel2.Size = New System.Drawing.Size(56, 20)
        Me.MonoFlat_HeaderLabel2.TabIndex = 2
        Me.MonoFlat_HeaderLabel2.Text = "Monto"
        '
        'MonoFlat_HeaderLabel3
        '
        Me.MonoFlat_HeaderLabel3.AutoSize = True
        Me.MonoFlat_HeaderLabel3.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel3.Location = New System.Drawing.Point(91, 309)
        Me.MonoFlat_HeaderLabel3.Name = "MonoFlat_HeaderLabel3"
        Me.MonoFlat_HeaderLabel3.Size = New System.Drawing.Size(69, 20)
        Me.MonoFlat_HeaderLabel3.TabIndex = 8
        Me.MonoFlat_HeaderLabel3.Text = "Recibido"
        '
        'txtRecibido
        '
        Me.txtRecibido.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.txtRecibido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRecibido.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtRecibido.ForeColor = System.Drawing.Color.White
        Me.txtRecibido.HintForeColor = System.Drawing.Color.White
        Me.txtRecibido.HintText = ""
        Me.txtRecibido.isPassword = False
        Me.txtRecibido.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtRecibido.LineIdleColor = System.Drawing.Color.Gray
        Me.txtRecibido.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtRecibido.LineThickness = 3
        Me.txtRecibido.Location = New System.Drawing.Point(95, 333)
        Me.txtRecibido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRecibido.Name = "txtRecibido"
        Me.txtRecibido.Size = New System.Drawing.Size(263, 33)
        Me.txtRecibido.TabIndex = 9
        Me.txtRecibido.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'MonoFlat_HeaderLabel4
        '
        Me.MonoFlat_HeaderLabel4.AutoSize = True
        Me.MonoFlat_HeaderLabel4.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel4.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel4.Location = New System.Drawing.Point(91, 402)
        Me.MonoFlat_HeaderLabel4.Name = "MonoFlat_HeaderLabel4"
        Me.MonoFlat_HeaderLabel4.Size = New System.Drawing.Size(62, 20)
        Me.MonoFlat_HeaderLabel4.TabIndex = 10
        Me.MonoFlat_HeaderLabel4.Text = "Cambio"
        '
        'txtCambio
        '
        Me.txtCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.txtCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCambio.Enabled = False
        Me.txtCambio.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtCambio.ForeColor = System.Drawing.Color.White
        Me.txtCambio.HintForeColor = System.Drawing.Color.Empty
        Me.txtCambio.HintText = ""
        Me.txtCambio.isPassword = False
        Me.txtCambio.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtCambio.LineIdleColor = System.Drawing.Color.Gray
        Me.txtCambio.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtCambio.LineThickness = 3
        Me.txtCambio.Location = New System.Drawing.Point(95, 426)
        Me.txtCambio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.Size = New System.Drawing.Size(263, 33)
        Me.txtCambio.TabIndex = 11
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'BackgroundWorker1
        '
        '
        'MonoFlat_HeaderLabel5
        '
        Me.MonoFlat_HeaderLabel5.AutoSize = True
        Me.MonoFlat_HeaderLabel5.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel5.Location = New System.Drawing.Point(91, 149)
        Me.MonoFlat_HeaderLabel5.Name = "MonoFlat_HeaderLabel5"
        Me.MonoFlat_HeaderLabel5.Size = New System.Drawing.Size(83, 20)
        Me.MonoFlat_HeaderLabel5.TabIndex = 21
        Me.MonoFlat_HeaderLabel5.Text = "Descuento"
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.txtDescuento.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescuento.Enabled = False
        Me.txtDescuento.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtDescuento.ForeColor = System.Drawing.Color.White
        Me.txtDescuento.HintForeColor = System.Drawing.Color.Empty
        Me.txtDescuento.HintText = ""
        Me.txtDescuento.isPassword = False
        Me.txtDescuento.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtDescuento.LineIdleColor = System.Drawing.Color.Gray
        Me.txtDescuento.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtDescuento.LineThickness = 3
        Me.txtDescuento.Location = New System.Drawing.Point(95, 173)
        Me.txtDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(263, 33)
        Me.txtDescuento.TabIndex = 22
        Me.txtDescuento.Text = "0"
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
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
        Me.btn_actualizar.ButtonText = "Aceptar"
        Me.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_actualizar.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_actualizar.ForeColor = System.Drawing.Color.DarkBlue
        Me.btn_actualizar.IdleBorderThickness = 1
        Me.btn_actualizar.IdleCornerRadius = 20
        Me.btn_actualizar.IdleFillColor = System.Drawing.Color.White
        Me.btn_actualizar.IdleForecolor = System.Drawing.Color.Gray
        Me.btn_actualizar.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btn_actualizar.Location = New System.Drawing.Point(121, 507)
        Me.btn_actualizar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(207, 38)
        Me.btn_actualizar.TabIndex = 20
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MonoFlat_HeaderLabel6
        '
        Me.MonoFlat_HeaderLabel6.AutoSize = True
        Me.MonoFlat_HeaderLabel6.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel6.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel6.Location = New System.Drawing.Point(91, 233)
        Me.MonoFlat_HeaderLabel6.Name = "MonoFlat_HeaderLabel6"
        Me.MonoFlat_HeaderLabel6.Size = New System.Drawing.Size(44, 20)
        Me.MonoFlat_HeaderLabel6.TabIndex = 23
        Me.MonoFlat_HeaderLabel6.Text = "Total"
        '
        'txtTotalApagar
        '
        Me.txtTotalApagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.txtTotalApagar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalApagar.Enabled = False
        Me.txtTotalApagar.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.txtTotalApagar.ForeColor = System.Drawing.Color.White
        Me.txtTotalApagar.HintForeColor = System.Drawing.Color.Empty
        Me.txtTotalApagar.HintText = ""
        Me.txtTotalApagar.isPassword = False
        Me.txtTotalApagar.LineFocusedColor = System.Drawing.Color.Blue
        Me.txtTotalApagar.LineIdleColor = System.Drawing.Color.Gray
        Me.txtTotalApagar.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.txtTotalApagar.LineThickness = 3
        Me.txtTotalApagar.Location = New System.Drawing.Point(95, 257)
        Me.txtTotalApagar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalApagar.Name = "txtTotalApagar"
        Me.txtTotalApagar.Size = New System.Drawing.Size(263, 33)
        Me.txtTotalApagar.TabIndex = 24
        Me.txtTotalApagar.Text = "0"
        Me.txtTotalApagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Ticket_impresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(480, 566)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel6)
        Me.Controls.Add(Me.txtTotalApagar)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel5)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel4)
        Me.Controls.Add(Me.txtCambio)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel3)
        Me.Controls.Add(Me.txtRecibido)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel2)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Ticket_impresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ticket_Comision"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents txtTotal As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents MonoFlat_HeaderLabel2 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents MonoFlat_HeaderLabel3 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents txtRecibido As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents MonoFlat_HeaderLabel4 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents txtCambio As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents btn_actualizar As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents MonoFlat_HeaderLabel5 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents txtDescuento As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents MonoFlat_HeaderLabel6 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents txtTotalApagar As Bunifu.Framework.UI.BunifuMaterialTextbox
End Class
