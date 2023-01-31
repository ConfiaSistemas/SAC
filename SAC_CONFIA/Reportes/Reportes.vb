Public Class Reportes

    'Public catservicios As New servicios
    'Public catimpuestos As New impuestos
    Public ventanapanel As String
    'Public catTiposDocumentos As New TiposDocumentosSolicitud
    'Public CatTiposdecreditos As New CatTiposdeCredito
    ' Public CatCreditosActivos As New CreditosActivos
    'Public catCajas As New Cajas



    Public CatTickets As New Tickets
    Public catRetiros As New Retiros

    Private Sub inv_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Select Case ventanapanel
            Case "Tickets"
                CatTickets.Size = Panel1.Size
            Case "Retiros"
                catRetiros.Size = Panel1.Size
            Case "TiposDocumentos"
                'catTiposDocumentos.Size = Panel1.Size
            Case "TiposDeCredito"
                'CatTiposdecreditos.Size = Panel1.Size
            Case "CreditosActivos"
               ' CatCreditosActivos.Size = Panel1.Size
            Case "Cajas"
                'catCajas.Size = Panel1.Size
        End Select


    End Sub

    Private Sub MonoFlat_Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MonoFlat_Button4_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub MonoFlat_Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub MonoFlat_Button5_Click(sender As Object, e As EventArgs) Handles MonoFlat_Button5.Click

        'catimpuestos.Visible = False
        'CatTiposdecreditos.Visible = False
        'catservicios.Visible = False
        'catTiposDocumentos.Visible = False
        'catCajas.Visible = False
        CatTickets.Visible = True
        CatTickets.TopLevel = False
        catRetiros.Visible = False

        CatTickets.Size = Panel1.Size
        CatTickets.Location = New System.Drawing.Point(0, 0)
        CatTickets.WindowState = FormWindowState.Normal
        CatTickets.Visible = True
        ventanapanel = "Tickets"
        Panel1.Controls.Add(CatTickets)


    End Sub

    Private Sub MonoFlat_Button6_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub MonoFlat_Button1_Click_1(sender As Object, e As EventArgs) Handles MonoFlat_Button1.Click
        catRetiros.Visible = True
        catRetiros.TopLevel = False

        catRetiros.Size = Panel1.Size
        catRetiros.Location = New System.Drawing.Point(0, 0)
        catRetiros.WindowState = FormWindowState.Normal
        CatTickets.Visible = False
        catRetiros.Visible = True
        ventanapanel = "Retiros"
        Panel1.Controls.Add(catRetiros)
    End Sub
End Class