
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = My.Computer.Screen.Bounds.Height
        Me.Width = My.Computer.Screen.Bounds.Width
        Dim hr As HandlerRoutine = AddressOf ConsoleCtrlCheck
        SetConsoleCtrlHandler(hr, True)
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim g As Graphics = Me.CreateGraphics()
        Dim myIcon As Icon = SystemIcons.Warning
        g.DrawIcon(myIcon, e.X, e.Y)
    End Sub

   
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
