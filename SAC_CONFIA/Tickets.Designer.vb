<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tickets

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tickets))
        Me.MonoFlat_HeaderLabel1 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.dtdatos = New Bunifu.Framework.UI.BunifuCustomDataGrid()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCredito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Caja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MonoFlat_CheckBox1 = New SAC_CONFIA.MonoFlat.MonoFlat_CheckBox()
        Me.dateDesde = New Bunifu.Framework.UI.BunifuDatepicker()
        Me.dateHasta = New Bunifu.Framework.UI.BunifuDatepicker()
        Me.MonoFlat_Label1 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.MonoFlat_Label2 = New SAC_CONFIA.MonoFlat.MonoFlat_Label()
        Me.ComboFiltro = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuThinButton22 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MonoFlat_HeaderLabel2 = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.lbltotal = New SAC_CONFIA.MonoFlat.MonoFlat_HeaderLabel()
        Me.BackgroundCajas = New System.ComponentModel.BackgroundWorker()
        CType(Me.dtdatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MonoFlat_HeaderLabel1
        '
        Me.MonoFlat_HeaderLabel1.AutoSize = True
        Me.MonoFlat_HeaderLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel1.Location = New System.Drawing.Point(3, 3)
        Me.MonoFlat_HeaderLabel1.Name = "MonoFlat_HeaderLabel1"
        Me.MonoFlat_HeaderLabel1.Size = New System.Drawing.Size(128, 20)
        Me.MonoFlat_HeaderLabel1.TabIndex = 1
        Me.MonoFlat_HeaderLabel1.Text = "Tickets por fecha"
        '
        'dtdatos
        '
        Me.dtdatos.AllowUserToAddRows = False
        Me.dtdatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtdatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtdatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtdatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtdatos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dtdatos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtdatos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtdatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtdatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtdatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.idCredito, Me.Nombre, Me.Monto, Me.Fecha, Me.Hora, Me.Tipo, Me.Caja, Me.Estado})
        Me.dtdatos.DoubleBuffered = True
        Me.dtdatos.EnableHeadersVisualStyles = False
        Me.dtdatos.HeaderBgColor = System.Drawing.Color.DarkSlateGray
        Me.dtdatos.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.dtdatos.Location = New System.Drawing.Point(1, 122)
        Me.dtdatos.Name = "dtdatos"
        Me.dtdatos.ReadOnly = True
        Me.dtdatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtdatos.RowHeadersVisible = False
        Me.dtdatos.Size = New System.Drawing.Size(1194, 447)
        Me.dtdatos.TabIndex = 7
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 42
        '
        'idCredito
        '
        Me.idCredito.HeaderText = "idCrédito"
        Me.idCredito.Name = "idCredito"
        Me.idCredito.ReadOnly = True
        Me.idCredito.Width = 87
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 79
        '
        'Monto
        '
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        Me.Monto.Width = 70
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 68
        '
        'Hora
        '
        Me.Hora.HeaderText = "Hora"
        Me.Hora.Name = "Hora"
        Me.Hora.ReadOnly = True
        Me.Hora.Width = 59
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 55
        '
        'Caja
        '
        Me.Caja.HeaderText = "Caja"
        Me.Caja.Name = "Caja"
        Me.Caja.ReadOnly = True
        Me.Caja.Width = 59
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 71
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Panel1.Controls.Add(Me.MonoFlat_CheckBox1)
        Me.Panel1.Controls.Add(Me.MonoFlat_HeaderLabel1)
        Me.Panel1.Location = New System.Drawing.Point(1, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1194, 36)
        Me.Panel1.TabIndex = 8
        '
        'MonoFlat_CheckBox1
        '
        Me.MonoFlat_CheckBox1.Checked = False
        Me.MonoFlat_CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.MonoFlat_CheckBox1.Location = New System.Drawing.Point(216, 8)
        Me.MonoFlat_CheckBox1.Name = "MonoFlat_CheckBox1"
        Me.MonoFlat_CheckBox1.Size = New System.Drawing.Size(148, 16)
        Me.MonoFlat_CheckBox1.TabIndex = 2
        Me.MonoFlat_CheckBox1.Text = "Vista Previa"
        '
        'dateDesde
        '
        Me.dateDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.dateDesde.BorderRadius = 0
        Me.dateDesde.ForeColor = System.Drawing.Color.White
        Me.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateDesde.FormatCustom = Nothing
        Me.dateDesde.Location = New System.Drawing.Point(285, 67)
        Me.dateDesde.Name = "dateDesde"
        Me.dateDesde.Size = New System.Drawing.Size(177, 33)
        Me.dateDesde.TabIndex = 6
        Me.dateDesde.Value = New Date(2018, 2, 2, 22, 50, 16, 603)
        '
        'dateHasta
        '
        Me.dateHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.dateHasta.BorderRadius = 0
        Me.dateHasta.ForeColor = System.Drawing.Color.White
        Me.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateHasta.FormatCustom = Nothing
        Me.dateHasta.Location = New System.Drawing.Point(528, 67)
        Me.dateHasta.Name = "dateHasta"
        Me.dateHasta.Size = New System.Drawing.Size(177, 33)
        Me.dateHasta.TabIndex = 7
        Me.dateHasta.Value = New Date(2018, 2, 2, 22, 50, 16, 603)
        '
        'MonoFlat_Label1
        '
        Me.MonoFlat_Label1.AutoSize = True
        Me.MonoFlat_Label1.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label1.Location = New System.Drawing.Point(282, 49)
        Me.MonoFlat_Label1.Name = "MonoFlat_Label1"
        Me.MonoFlat_Label1.Size = New System.Drawing.Size(39, 15)
        Me.MonoFlat_Label1.TabIndex = 8
        Me.MonoFlat_Label1.Text = "Desde"
        '
        'MonoFlat_Label2
        '
        Me.MonoFlat_Label2.AutoSize = True
        Me.MonoFlat_Label2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MonoFlat_Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(116, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(132, Byte), Integer))
        Me.MonoFlat_Label2.Location = New System.Drawing.Point(525, 49)
        Me.MonoFlat_Label2.Name = "MonoFlat_Label2"
        Me.MonoFlat_Label2.Size = New System.Drawing.Size(37, 15)
        Me.MonoFlat_Label2.TabIndex = 9
        Me.MonoFlat_Label2.Text = "Hasta"
        '
        'ComboFiltro
        '
        Me.ComboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFiltro.FormattingEnabled = True
        Me.ComboFiltro.ItemHeight = 13
        Me.ComboFiltro.Location = New System.Drawing.Point(23, 79)
        Me.ComboFiltro.Name = "ComboFiltro"
        Me.ComboFiltro.Size = New System.Drawing.Size(239, 21)
        Me.ComboFiltro.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(20, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Cajas"
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "Exportar"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton21.Location = New System.Drawing.Point(865, 67)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(92, 31)
        Me.BunifuThinButton21.TabIndex = 4
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuThinButton22
        '
        Me.BunifuThinButton22.ActiveBorderThickness = 1
        Me.BunifuThinButton22.ActiveCornerRadius = 20
        Me.BunifuThinButton22.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton22.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton22.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BunifuThinButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.BunifuThinButton22.BackgroundImage = CType(resources.GetObject("BunifuThinButton22.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton22.ButtonText = "Consultar"
        Me.BunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton22.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton22.ForeColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton22.IdleBorderThickness = 1
        Me.BunifuThinButton22.IdleCornerRadius = 20
        Me.BunifuThinButton22.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton22.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton22.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.BunifuThinButton22.Location = New System.Drawing.Point(749, 67)
        Me.BunifuThinButton22.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton22.Name = "BunifuThinButton22"
        Me.BunifuThinButton22.Size = New System.Drawing.Size(92, 31)
        Me.BunifuThinButton22.TabIndex = 5
        Me.BunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundWorker1
        '
        '
        'MonoFlat_HeaderLabel2
        '
        Me.MonoFlat_HeaderLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MonoFlat_HeaderLabel2.AutoSize = True
        Me.MonoFlat_HeaderLabel2.BackColor = System.Drawing.Color.Transparent
        Me.MonoFlat_HeaderLabel2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.MonoFlat_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MonoFlat_HeaderLabel2.Location = New System.Drawing.Point(988, 99)
        Me.MonoFlat_HeaderLabel2.Name = "MonoFlat_HeaderLabel2"
        Me.MonoFlat_HeaderLabel2.Size = New System.Drawing.Size(44, 20)
        Me.MonoFlat_HeaderLabel2.TabIndex = 2
        Me.MonoFlat_HeaderLabel2.Text = "Total"
        '
        'lbltotal
        '
        Me.lbltotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltotal.AutoSize = True
        Me.lbltotal.BackColor = System.Drawing.Color.Transparent
        Me.lbltotal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbltotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbltotal.Location = New System.Drawing.Point(1059, 99)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(21, 20)
        Me.lbltotal.TabIndex = 34
        Me.lbltotal.Text = "..."
        '
        'BackgroundCajas
        '
        '
        'Tickets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1197, 581)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.MonoFlat_HeaderLabel2)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.BunifuThinButton22)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ComboFiltro)
        Me.Controls.Add(Me.MonoFlat_Label2)
        Me.Controls.Add(Me.MonoFlat_Label1)
        Me.Controls.Add(Me.dtdatos)
        Me.Controls.Add(Me.dateHasta)
        Me.Controls.Add(Me.dateDesde)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Tickets"
        Me.Text = "Desembolsos"
        CType(Me.dtdatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MonoFlat_HeaderLabel1 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents dtdatos As Bunifu.Framework.UI.BunifuCustomDataGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents dateDesde As Bunifu.Framework.UI.BunifuDatepicker
    Friend WithEvents dateHasta As Bunifu.Framework.UI.BunifuDatepicker
    Friend WithEvents MonoFlat_Label1 As MonoFlat.MonoFlat_Label
    Friend WithEvents MonoFlat_Label2 As MonoFlat.MonoFlat_Label
    Friend WithEvents BunifuThinButton22 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents ComboFiltro As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents MonoFlat_HeaderLabel2 As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents lbltotal As MonoFlat.MonoFlat_HeaderLabel
    Friend WithEvents BackgroundCajas As System.ComponentModel.BackgroundWorker
    Friend WithEvents MonoFlat_CheckBox1 As MonoFlat.MonoFlat_CheckBox
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents idCredito As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Monto As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents Hora As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents Caja As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
End Class
