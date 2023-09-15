Imports System.Runtime.InteropServices




Module Keyboard
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Function SetWindowsHookEx(ByVal idHook As Integer, ByVal HookProc As KeyHook, ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
    End Function
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Function CallNextHookEx(ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
    End Function
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Function UnhookWindowsHookEx(ByVal idHook As Integer) As Boolean
    End Function
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Function GetModuleHandle(ByVal name As String) As IntPtr
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As Keys
        Public scanCode As Keys
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure
    Public Const HC_ACTION As Integer = 0

    Public Const WH_KEYBOARD_LL As Integer = 13

    Public Delegate Function KeyHook(ByVal Code As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer

    '<MarshalAs(UnmanagedType.FunctionPtr)>
    Public callback As KeyHook
End Module

