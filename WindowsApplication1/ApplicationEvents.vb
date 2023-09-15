Namespace My

    ' 以下事件可用于 MyApplication: 
    ' 
    ' Startup:  应用程序启动时在创建启动窗体之前引发。
    ' Shutdown:  在关闭所有应用程序窗体后引发。  如果应用程序异常终止，则不会引发此事件。
    ' UnhandledException:  在应用程序遇到未经处理的异常时引发。
    ' StartupNextInstance:  在启动单实例应用程序且应用程序已处于活动状态时引发。
    ' NetworkAvailabilityChanged:  在连接或断开网络连接时引发。
    Partial Friend Class MyApplication
            '我们捕捉到的全局例外之一是不是线程安全的，所以我们需要首先使其线程安全。
            Private Delegate Sub SafeApplicationThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)

            Private Sub ShowDebugOutput(ByVal ex As Exception)
                '显示输出错误的From窗体
                Dim frmD As New Form2()
                '显示解决方案名
                frmD.TextBox1.AppendText("Product Name：" & My.Application.Info.ProductName & vbNewLine)
                '显示当前版本号
                frmD.TextBox1.AppendText("Product Version：" & My.Application.Info.Version.ToString() & vbNewLine)
                frmD.TextBox1.AppendText("OS Name：" & My.Computer.Info.OSFullName & vbNewLine)
                frmD.TextBox1.AppendText("OS Version：" & My.Computer.Info.OSVersion & vbNewLine)
                'NET2.0下判断x86还是64
                If Environment.GetEnvironmentVariable("ProgramFiles(x86)") = "" Then
                    frmD.TextBox1.AppendText("OS Platform：x86" & vbNewLine)
                Else
                    frmD.TextBox1.AppendText("OS Platform：x64" & vbNewLine)
                End If
                frmD.TextBox1.AppendText("--------------------" & vbCrLf)
                '显示错误
                frmD.TextBox1.AppendText(ex.ToString())
                frmD.ShowDialog()
            '执行应用程序清理
            'TODO: 在这里添加您的应用程序清理代码。
            '退出应用程序 - 或尝试从异常中恢复：
        End Sub
        End Class


End Namespace

