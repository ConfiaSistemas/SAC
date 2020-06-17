<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetalleCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetalleCaja))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.EvolveControlBox1 = New SAC_CONFIA.EvolveControlBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNoCaja = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFondoCaja = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lblCantRetiros = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCantTickets = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalCobrado = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalRetiros = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotalCaja = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.btn_actualizar = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Controls.Add(Me.EvolveControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(535, 36)
        Me.Panel1.TabIndex = 4
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 7)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(112, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Detalle de Caja"
        '
        'EvolveControlBox1
        '
        Me.EvolveControlBox1.Colors = New SAC_CONFIA.Bloom(-1) {}
        Me.EvolveControlBox1.Customization = ""
        Me.EvolveControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.EvolveControlBox1.Image = Nothing
        Me.EvolveControlBox1.Location = New System.Drawing.Point(466, 3)
        Me.EvolveControlBox1.MaxButton = False
        Me.EvolveControlBox1.MinButton = True
        Me.EvolveControlBox1.Name = "EvolveControlBox1"
        Me.EvolveControlBox1.NoRounding = False
        Me.EvolveControlBox1.Size = New System.Drawing.Size(66, 16)
        Me.EvolveControlBox1.TabIndex = 0
        Me.EvolveControlBox1.Text = "EvolveControlBox1"
        Me.EvolveControlBox1.Transparent = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(25, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Número de caja"
        '
        'lblNoCaja
        '
        Me.lblNoCaja.AutoSize = True
        Me.lblNoCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblNoCaja.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblNoCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblNoCaja.Location = New System.Drawing.Point(24, 81)
        Me.lblNoCaja.Name = "lblNoCaja"
        Me.lblNoCaja.Size = New System.Drawing.Size(21, 20)
        Me.lblNoCaja.TabIndex = 2
        Me.lblNoCaja.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(25, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Fondo"
        '
        'lblFondoCaja
        '
        Me.lblFondoCaja.AutoSize = True
        Me.lblFondoCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblFondoCaja.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblFondoCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblFondoCaja.Location = New System.Drawing.Point(24, 148)
        Me.lblFondoCaja.Name = "lblFondoCaja"
        Me.lblFondoCaja.Size = New System.Drawing.Size(21, 20)
        Me.lblFondoCaja.TabIndex = 14
        Me.lblFondoCaja.Text = "..."
        '
        'lblCantRetiros
        '
        Me.lblCantRetiros.AutoSize = True
        Me.lblCantRetiros.BackColor = System.Drawing.Color.Transparent
        Me.lblCantRetiros.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantRetiros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblCantRetiros.Location = New System.Drawing.Point(170, 148)
        Me.lblCantRetiros.Name = "lblCantRetiros"
        Me.lblCantRetiros.Size = New System.Drawing.Size(21, 20)
        Me.lblCantRetiros.TabIndex = 16
        Me.lblCantRetiros.Text = "..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(171, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Cantidad de Retiros"
        '
        'lblCantTickets
        '
        Me.lblCantTickets.AutoSize = True
        Me.lblCantTickets.BackColor = System.Drawing.Color.Transparent
        Me.lblCantTickets.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCantTickets.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblCantTickets.Location = New System.Drawing.Point(342, 148)
        Me.lblCantTickets.Name = "lblCantTickets"
        Me.lblCantTickets.Size = New System.Drawing.Size(21, 20)
        Me.lblCantTickets.TabIndex = 18
        Me.lblCantTickets.Text = "..."
        Me.lblCantTickets.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(343, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Cantidad de Tickets"
        '
        'lblTotalCobrado
        '
        Me.lblTotalCobrado.AutoSize = True
        Me.lblTotalCobrado.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCobrado.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCobrado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTotalCobrado.Location = New System.Drawing.Point(24, 223)
        Me.lblTotalCobrado.Name = "lblTotalCobrado"
        Me.lblTotalCobrado.Size = New System.Drawing.Size(21, 20)
        Me.lblTotalCobrado.TabIndex = 20
        Me.lblTotalCobrado.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(25, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Total Cobrado"
        '
        'lblTotalRetiros
        '
        Me.lblTotalRetiros.AutoSize = True
        Me.lblTotalRetiros.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalRetiros.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalRetiros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTotalRetiros.Location = New System.Drawing.Point(170, 223)
        Me.lblTotalRetiros.Name = "lblTotalRetiros"
        Me.lblTotalRetiros.Size = New System.Drawing.Size(21, 20)
        Me.lblTotalRetiros.TabIndex = 22
        Me.lblTotalRetiros.Text = "..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(171, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Total Retiros"
        '
        'lblTotalCaja
        '
        Me.lblTotalCaja.AutoSize = True
        Me.lblTotalCaja.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCaja.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTotalCaja.Location = New System.Drawing.Point(342, 223)
        Me.lblTotalCaja.Name = "lblTotalCaja"
        Me.lblTotalCaja.Size = New System.Drawing.Size(21, 20)
        Me.lblTotalCaja.TabIndex = 24
        Me.lblTotalCaja.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(343, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Total en Caja"
        '
        'BackgroundWorker1
        '
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
        Me.btn_actualizar.Location = New System.Drawing.Point(156, 299)
        Me.btn_actualizar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(207, 38)
        Me.btn_actualizar.TabIndex = 25
        Me.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DetalleCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(540, 390)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Controls.Add(Me.lblTotalCaja)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblTotalRetiros)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblTotalCobrado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCantTickets)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblCantRetiros)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFondoCaja)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNoCaja)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DetalleCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Caja"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents EvolveControlBox1 As EvolveControlBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNoCaja As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblFondoCaja As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lblCantRetiros As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblCantTickets As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalCobrado As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTotalRetiros As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotalCaja As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_actualizar As Bunifu.Framework.UI.BunifuThinButton2
End Class
