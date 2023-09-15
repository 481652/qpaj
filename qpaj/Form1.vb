
Imports System.Runtime.InteropServices

Public Class Form1
    '键盘钩子
    Public KeyHandle As Integer
    Public Function KeyCallback(ByVal Code As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        If Code >= HC_ACTION Then
            Dim keyStruct As KBDLLHOOKSTRUCT
            keyStruct = CType(Marshal.PtrToStructure(lParam, GetType(KBDLLHOOKSTRUCT)), KBDLLHOOKSTRUCT)
            '这里是检测并屏蔽Win按键
            If keyStruct.vkCode = Keys.LWin Or keyStruct.vkCode = Keys.RWin Then
                Return 1
            End If
        End If
        Return CallNextHookEx(KeyHandle, Code, wParam, lParam)
    End Function
    Public Sub HookKeyboard()

        callback = New KeyHook(AddressOf KeyCallback)

        Dim hins As IntPtr = IntPtr.Zero
        hins = GetModuleHandle(Process.GetCurrentProcess.MainModule.ModuleName)
        KeyHandle = SetWindowsHookEx(WH_KEYBOARD_LL, callback, hins, 0)
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Height = My.Computer.Screen.Bounds.Height
        Width = My.Computer.Screen.Bounds.Width
        HookKeyboard()
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim g As Graphics = Me.CreateGraphics()
        Dim myIcon As Icon = SystemIcons.Warning
        g.DrawIcon(myIcon, e.X, e.Y)
    End Sub


End Class