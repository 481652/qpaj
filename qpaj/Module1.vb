Imports System.Runtime.InteropServices

Module Module1

    Public Enum ConsoleEvent
        CTRL_C_EVENT = 0
        CTRL_BREAK_EVENT = 1
        CTRL_CLOSE_EVENT = 2
        CTRL_LOGOFF_EVENT = 5
        CTRL_SHUTDOWN_EVENT = 6
    End Enum

    Public Delegate Function HandlerRoutine(ByVal CtrlType As ConsoleEvent) As Boolean

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Function SetConsoleCtrlHandler(ByVal Handler As HandlerRoutine, ByVal Add As Boolean) As Boolean
    End Function
    Public Function ConsoleCtrlCheck(ByVal ctrlType As ConsoleEvent) As Boolean
        Select Case ctrlType
            Case ConsoleEvent.CTRL_C_EVENT, ConsoleEvent.CTRL_BREAK_EVENT, ConsoleEvent.CTRL_CLOSE_EVENT, ConsoleEvent.CTRL_LOGOFF_EVENT, ConsoleEvent.CTRL_SHUTDOWN_EVENT
                Return True
            Case Else
                Return True
        End Select
    End Function
End Module
