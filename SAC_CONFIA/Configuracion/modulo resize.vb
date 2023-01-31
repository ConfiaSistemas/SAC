Module Module_resize

#Region " Functions and Constants "

    'Width of the 'resizable border', the area where you can resize.
    Public Const BorderWidth As Integer = 6
    Public _resizeDir As ResizeDirection = ResizeDirection.None

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HTBORDER As Integer = 18
    Public Const HTBOTTOM As Integer = 15
    Public Const HTBOTTOMLEFT As Integer = 16
    Public Const HTBOTTOMRIGHT As Integer = 17
    Public Const HTCAPTION As Integer = 2
    Public Const HTLEFT As Integer = 10
    Public Const HTRIGHT As Integer = 11
    Public Const HTTOP As Integer = 12
    Public Const HTTOPLEFT As Integer = 13
    Public Const HTTOPRIGHT As Integer = 14

    Public Declare Function ReleaseCapture Lib "user32.dll" () As Boolean
    Public Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

#End Region

    Public Enum ResizeDirection
        None = 0
        Left = 1
        TopLeft = 2
        Top = 3
        TopRight = 4
        Right = 5
        BottomRight = 6
        Bottom = 7
        BottomLeft = 8
    End Enum

    Public Property resizeDir(ByVal frm As Form) As Module_resize.ResizeDirection
        Get
            Return _resizeDir
        End Get
        Set(ByVal value As Module_resize.ResizeDirection)
            _resizeDir = value
            Select Case value 'Change cursor
                Case ResizeDirection.Left
                    frm.Cursor = Cursors.SizeWE
                Case ResizeDirection.Right
                    frm.Cursor = Cursors.SizeWE
                Case ResizeDirection.Top
                    frm.Cursor = Cursors.SizeNS
                Case ResizeDirection.Bottom
                    frm.Cursor = Cursors.SizeNS
                Case ResizeDirection.BottomLeft
                    frm.Cursor = Cursors.SizeNESW
                Case ResizeDirection.TopRight
                    frm.Cursor = Cursors.SizeNESW
                Case ResizeDirection.BottomRight
                    frm.Cursor = Cursors.SizeNWSE
                Case ResizeDirection.TopLeft
                    frm.Cursor = Cursors.SizeNWSE
                Case Else
                    frm.Cursor = Cursors.Default
            End Select
        End Set

    End Property

#Region " Moving & Resizing methods "

    Public Sub MoveForm(frm As Form)
        ReleaseCapture()
        SendMessage(frm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub

    Public Sub ResizeForm(ByVal frm As Form, ByVal direction As ResizeDirection)
        Dim dir As Integer = -1

        Select Case direction
            Case ResizeDirection.Left
                dir = HTLEFT
            Case ResizeDirection.TopLeft
                dir = HTTOPLEFT
            Case ResizeDirection.Top
                dir = HTTOP
            Case ResizeDirection.TopRight
                dir = HTTOPRIGHT
            Case ResizeDirection.Right
                dir = HTRIGHT
            Case ResizeDirection.BottomRight
                dir = HTBOTTOMRIGHT
            Case ResizeDirection.Bottom
                dir = HTBOTTOM
            Case ResizeDirection.BottomLeft
                dir = HTBOTTOMLEFT
        End Select
        If dir <> -1 Then
            ' Resize form
            ReleaseCapture()
            SendMessage(frm.Handle, WM_NCLBUTTONDOWN, dir, 0)

        End If
    End Sub

    Public Sub SetDirection(ByVal frm As Form)

        Dim C_Location = frm.PointToClient(Cursor.Position)

        'Calculate which direction to resize based on mouse position
        If C_Location.X < BorderWidth And C_Location.Y < BorderWidth Then
            resizeDir(frm) = ResizeDirection.TopLeft
        ElseIf C_Location.X < BorderWidth And C_Location.Y > frm.Height - BorderWidth Then
            resizeDir(frm) = ResizeDirection.BottomLeft
        ElseIf C_Location.X > frm.Width - BorderWidth And C_Location.Y > frm.Height - BorderWidth Then
            resizeDir(frm) = ResizeDirection.BottomRight
        ElseIf C_Location.X > frm.Width - BorderWidth And C_Location.Y < BorderWidth Then
            resizeDir(frm) = ResizeDirection.TopRight
        ElseIf C_Location.X < BorderWidth Then
            resizeDir(frm) = ResizeDirection.Left
        ElseIf C_Location.X > frm.Width - BorderWidth Then
            resizeDir(frm) = ResizeDirection.Right
        ElseIf C_Location.Y < BorderWidth Then
            resizeDir(frm) = ResizeDirection.Top
        ElseIf C_Location.Y > frm.Height - BorderWidth Then
            resizeDir(frm) = ResizeDirection.Bottom
        Else
            resizeDir(frm) = ResizeDirection.None
        End If

    End Sub

#End Region

End Module