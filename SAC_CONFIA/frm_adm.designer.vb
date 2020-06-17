<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_adm
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BunifuFlatButton7 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton6 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnusuarios = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnconfiguracion = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.notificaciones = New SAC_CONFIA.MonoFlat.MonoFlat_NotificationBox()
        Me.imgperfil = New Bunifu.Framework.UI.BunifuImageButton()
        Me.panelmenus = New System.Windows.Forms.Panel()
        Me.BunifuFlatButton5 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timerwidthmenos = New System.Windows.Forms.Timer(Me.components)
        Me.Timerwidthmas = New System.Windows.Forms.Timer(Me.components)
        Me.TimerPermisos = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.imgperfil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelmenus.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.BunifuFlatButton7)
        Me.Panel1.Controls.Add(Me.BunifuFlatButton6)
        Me.Panel1.Controls.Add(Me.btnusuarios)
        Me.Panel1.Controls.Add(Me.btnconfiguracion)
        Me.Panel1.Controls.Add(Me.notificaciones)
        Me.Panel1.Controls.Add(Me.imgperfil)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(890, 66)
        Me.Panel1.TabIndex = 0
        '
        'BunifuFlatButton7
        '
        Me.BunifuFlatButton7.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton7.BorderRadius = 0
        Me.BunifuFlatButton7.ButtonText = "Retiro"
        Me.BunifuFlatButton7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton7.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton7.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton7.Iconimage = Global.SAC_CONFIA.My.Resources.Resources.reproductor
        Me.BunifuFlatButton7.Iconimage_right = Nothing
        Me.BunifuFlatButton7.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton7.Iconimage_Selected = Nothing
        Me.BunifuFlatButton7.IconMarginLeft = 0
        Me.BunifuFlatButton7.IconMarginRight = 0
        Me.BunifuFlatButton7.IconRightVisible = True
        Me.BunifuFlatButton7.IconRightZoom = 0R
        Me.BunifuFlatButton7.IconVisible = True
        Me.BunifuFlatButton7.IconZoom = 90.0R
        Me.BunifuFlatButton7.IsTab = False
        Me.BunifuFlatButton7.Location = New System.Drawing.Point(414, 6)
        Me.BunifuFlatButton7.Name = "BunifuFlatButton7"
        Me.BunifuFlatButton7.Normalcolor = System.Drawing.Color.Empty
        Me.BunifuFlatButton7.OnHovercolor = System.Drawing.Color.Gray
        Me.BunifuFlatButton7.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton7.selected = False
        Me.BunifuFlatButton7.Size = New System.Drawing.Size(122, 48)
        Me.BunifuFlatButton7.TabIndex = 6
        Me.BunifuFlatButton7.Text = "Retiro"
        Me.BunifuFlatButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton7.Textcolor = System.Drawing.Color.WhiteSmoke
        Me.BunifuFlatButton7.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton7.Visible = False
        '
        'BunifuFlatButton6
        '
        Me.BunifuFlatButton6.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton6.BorderRadius = 0
        Me.BunifuFlatButton6.ButtonText = "Pago Extraordinario"
        Me.BunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton6.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton6.Iconimage = Global.SAC_CONFIA.My.Resources.Resources._86114
        Me.BunifuFlatButton6.Iconimage_right = Nothing
        Me.BunifuFlatButton6.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton6.Iconimage_Selected = Nothing
        Me.BunifuFlatButton6.IconMarginLeft = 0
        Me.BunifuFlatButton6.IconMarginRight = 0
        Me.BunifuFlatButton6.IconRightVisible = True
        Me.BunifuFlatButton6.IconRightZoom = 0R
        Me.BunifuFlatButton6.IconVisible = True
        Me.BunifuFlatButton6.IconZoom = 90.0R
        Me.BunifuFlatButton6.IsTab = False
        Me.BunifuFlatButton6.Location = New System.Drawing.Point(286, 6)
        Me.BunifuFlatButton6.Name = "BunifuFlatButton6"
        Me.BunifuFlatButton6.Normalcolor = System.Drawing.Color.Empty
        Me.BunifuFlatButton6.OnHovercolor = System.Drawing.Color.Gray
        Me.BunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton6.selected = False
        Me.BunifuFlatButton6.Size = New System.Drawing.Size(122, 48)
        Me.BunifuFlatButton6.TabIndex = 5
        Me.BunifuFlatButton6.Text = "Pago Extraordinario"
        Me.BunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton6.Textcolor = System.Drawing.Color.WhiteSmoke
        Me.BunifuFlatButton6.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnusuarios
        '
        Me.btnusuarios.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnusuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnusuarios.BorderRadius = 0
        Me.btnusuarios.ButtonText = "Detalle de Caja"
        Me.btnusuarios.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnusuarios.DisabledColor = System.Drawing.Color.Gray
        Me.btnusuarios.Iconcolor = System.Drawing.Color.Transparent
        Me.btnusuarios.Iconimage = Global.SAC_CONFIA.My.Resources.Resources.inv
        Me.btnusuarios.Iconimage_right = Nothing
        Me.btnusuarios.Iconimage_right_Selected = Nothing
        Me.btnusuarios.Iconimage_Selected = Nothing
        Me.btnusuarios.IconMarginLeft = 0
        Me.btnusuarios.IconMarginRight = 0
        Me.btnusuarios.IconRightVisible = True
        Me.btnusuarios.IconRightZoom = 0R
        Me.btnusuarios.IconVisible = True
        Me.btnusuarios.IconZoom = 90.0R
        Me.btnusuarios.IsTab = False
        Me.btnusuarios.Location = New System.Drawing.Point(3, 9)
        Me.btnusuarios.Name = "btnusuarios"
        Me.btnusuarios.Normalcolor = System.Drawing.Color.Empty
        Me.btnusuarios.OnHovercolor = System.Drawing.Color.Gray
        Me.btnusuarios.OnHoverTextColor = System.Drawing.Color.Transparent
        Me.btnusuarios.selected = False
        Me.btnusuarios.Size = New System.Drawing.Size(140, 48)
        Me.btnusuarios.TabIndex = 5
        Me.btnusuarios.Text = "Detalle de Caja"
        Me.btnusuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnusuarios.Textcolor = System.Drawing.Color.Transparent
        Me.btnusuarios.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnconfiguracion
        '
        Me.btnconfiguracion.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnconfiguracion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnconfiguracion.BorderRadius = 0
        Me.btnconfiguracion.ButtonText = "Configuración"
        Me.btnconfiguracion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnconfiguracion.DisabledColor = System.Drawing.Color.Gray
        Me.btnconfiguracion.Iconcolor = System.Drawing.Color.Transparent
        Me.btnconfiguracion.Iconimage = Global.SAC_CONFIA.My.Resources.Resources.config
        Me.btnconfiguracion.Iconimage_right = Nothing
        Me.btnconfiguracion.Iconimage_right_Selected = Nothing
        Me.btnconfiguracion.Iconimage_Selected = Nothing
        Me.btnconfiguracion.IconMarginLeft = 0
        Me.btnconfiguracion.IconMarginRight = 0
        Me.btnconfiguracion.IconRightVisible = True
        Me.btnconfiguracion.IconRightZoom = 0R
        Me.btnconfiguracion.IconVisible = True
        Me.btnconfiguracion.IconZoom = 90.0R
        Me.btnconfiguracion.IsTab = False
        Me.btnconfiguracion.Location = New System.Drawing.Point(149, 8)
        Me.btnconfiguracion.Name = "btnconfiguracion"
        Me.btnconfiguracion.Normalcolor = System.Drawing.Color.Empty
        Me.btnconfiguracion.OnHovercolor = System.Drawing.Color.Gray
        Me.btnconfiguracion.OnHoverTextColor = System.Drawing.Color.White
        Me.btnconfiguracion.selected = False
        Me.btnconfiguracion.Size = New System.Drawing.Size(141, 48)
        Me.btnconfiguracion.TabIndex = 5
        Me.btnconfiguracion.Text = "Configuración"
        Me.btnconfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnconfiguracion.Textcolor = System.Drawing.Color.WhiteSmoke
        Me.btnconfiguracion.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'notificaciones
        '
        Me.notificaciones.BorderCurve = 8
        Me.notificaciones.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.notificaciones.Image = Nothing
        Me.notificaciones.Location = New System.Drawing.Point(675, 6)
        Me.notificaciones.MinimumSize = New System.Drawing.Size(100, 40)
        Me.notificaciones.Name = "notificaciones"
        Me.notificaciones.NotificationType = SAC_CONFIA.MonoFlat.MonoFlat_NotificationBox.Type.Notice
        Me.notificaciones.RoundCorners = False
        Me.notificaciones.ShowCloseButton = True
        Me.notificaciones.Size = New System.Drawing.Size(157, 52)
        Me.notificaciones.TabIndex = 3
        Me.notificaciones.Text = "MonoFlat_NotificationBox1"
        '
        'imgperfil
        '
        Me.imgperfil.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.imgperfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgperfil.Image = Global.SAC_CONFIA.My.Resources.Resources.usuario
        Me.imgperfil.ImageActive = Nothing
        Me.imgperfil.Location = New System.Drawing.Point(838, 13)
        Me.imgperfil.Name = "imgperfil"
        Me.imgperfil.Size = New System.Drawing.Size(45, 43)
        Me.imgperfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgperfil.TabIndex = 2
        Me.imgperfil.TabStop = False
        Me.imgperfil.Zoom = 10
        '
        'panelmenus
        '
        Me.panelmenus.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.panelmenus.Controls.Add(Me.BunifuFlatButton5)
        Me.panelmenus.Controls.Add(Me.BunifuFlatButton3)
        Me.panelmenus.Controls.Add(Me.BunifuFlatButton2)
        Me.panelmenus.Controls.Add(Me.BunifuFlatButton1)
        Me.panelmenus.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelmenus.Location = New System.Drawing.Point(0, 66)
        Me.panelmenus.Name = "panelmenus"
        Me.panelmenus.Size = New System.Drawing.Size(258, 376)
        Me.panelmenus.TabIndex = 1
        '
        'BunifuFlatButton5
        '
        Me.BunifuFlatButton5.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.BunifuFlatButton5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BunifuFlatButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton5.BorderRadius = 0
        Me.BunifuFlatButton5.ButtonText = "Cerrar Empresa"
        Me.BunifuFlatButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton5.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton5.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton5.Iconimage = Global.SAC_CONFIA.My.Resources.Resources.icono_cerrar_empresa
        Me.BunifuFlatButton5.Iconimage_right = Nothing
        Me.BunifuFlatButton5.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton5.Iconimage_Selected = Nothing
        Me.BunifuFlatButton5.IconMarginLeft = 0
        Me.BunifuFlatButton5.IconMarginRight = 0
        Me.BunifuFlatButton5.IconRightVisible = True
        Me.BunifuFlatButton5.IconRightZoom = 0R
        Me.BunifuFlatButton5.IconVisible = True
        Me.BunifuFlatButton5.IconZoom = 90.0R
        Me.BunifuFlatButton5.IsTab = True
        Me.BunifuFlatButton5.Location = New System.Drawing.Point(1, 164)
        Me.BunifuFlatButton5.Name = "BunifuFlatButton5"
        Me.BunifuFlatButton5.Normalcolor = System.Drawing.SystemColors.ButtonFace
        Me.BunifuFlatButton5.OnHovercolor = System.Drawing.Color.Gray
        Me.BunifuFlatButton5.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton5.selected = False
        Me.BunifuFlatButton5.Size = New System.Drawing.Size(258, 48)
        Me.BunifuFlatButton5.TabIndex = 5
        Me.BunifuFlatButton5.Text = "Cerrar Empresa"
        Me.BunifuFlatButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton5.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton5.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.BunifuFlatButton3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 0
        Me.BunifuFlatButton3.ButtonText = "Reportes"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.Iconimage = Global.SAC_CONFIA.My.Resources.Resources.icono_reportes
        Me.BunifuFlatButton3.Iconimage_right = Nothing
        Me.BunifuFlatButton3.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton3.Iconimage_Selected = Nothing
        Me.BunifuFlatButton3.IconMarginLeft = 0
        Me.BunifuFlatButton3.IconMarginRight = 0
        Me.BunifuFlatButton3.IconRightVisible = True
        Me.BunifuFlatButton3.IconRightZoom = 0R
        Me.BunifuFlatButton3.IconVisible = True
        Me.BunifuFlatButton3.IconZoom = 90.0R
        Me.BunifuFlatButton3.IsTab = False
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(1, 110)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.SystemColors.ButtonFace
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(258, 48)
        Me.BunifuFlatButton3.TabIndex = 3
        Me.BunifuFlatButton3.Text = "Reportes"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton3.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "Créditos Autorizados"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = Global.SAC_CONFIA.My.Resources.Resources._16fc2b28_6980_4eaa_af5f_2105ebb20039
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 90.0R
        Me.BunifuFlatButton2.IsTab = True
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(1, 56)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.SystemColors.ButtonFace
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(258, 48)
        Me.BunifuFlatButton2.TabIndex = 2
        Me.BunifuFlatButton2.Text = "Créditos Autorizados"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "Pago de crédito"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Global.SAC_CONFIA.My.Resources.Resources._75804849_ccc1_40d0_b0aa_672e22556ad5
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = True
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(1, 2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.SystemColors.ButtonFace
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(258, 48)
        Me.BunifuFlatButton1.TabIndex = 1
        Me.BunifuFlatButton1.Text = "Pago de crédito"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Timer2
        '
        '
        'Timerwidthmenos
        '
        '
        'Timerwidthmas
        '
        '
        'TimerPermisos
        '
        Me.TimerPermisos.Interval = 3600000
        '
        'frm_adm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(890, 442)
        Me.Controls.Add(Me.panelmenus)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(672, 480)
        Me.Name = "frm_adm"
        Me.Opacity = 0.1R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SAC"
        Me.Panel1.ResumeLayout(False)
        CType(Me.imgperfil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelmenus.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents panelmenus As System.Windows.Forms.Panel
    Friend WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents imgperfil As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents notificaciones As SAC_CONFIA.MonoFlat.MonoFlat_NotificationBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Timerwidthmenos As System.Windows.Forms.Timer
    Friend WithEvents Timerwidthmas As System.Windows.Forms.Timer
    Friend WithEvents btnusuarios As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnconfiguracion As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BunifuFlatButton6 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BunifuFlatButton5 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BunifuFlatButton7 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents TimerPermisos As Timer
End Class
