﻿Imports System.Security
Imports Microsoft.Win32
Imports System.Security.Principal
Imports System.Security.AccessControl
Public Class Form

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        'richtextbox自动滚动
        '设置richtextbox的SelectionStart属性为文本的长度，表示光标移动到文本末尾
        RichTextBox1.SelectionStart = RichTextBox1.TextLength
        '调用richtextbox的ScrollToCaret方法，表示滚动到光标位置
        RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '0.定义注册表键值
        '下为第一步

        Button1.Enabled = False
        Button1.Text = "部署中"
        CheckBox1.Enabled = False
        '下为第二步

        '下为第三步
        ProgressBar1.Value = 1
        RichTextBox1.Text = "已开始部署。"
        '1.操作注册表1
        ProgressBar1.Value = 2
        RichTextBox1.AppendText(Environment.NewLine)
        RichTextBox1.AppendText("已成功修改注册表键值。")
        '2.操作注册表2
        ProgressBar1.Value = 3
        RichTextBox1.AppendText(Environment.NewLine)
        RichTextBox1.AppendText("已成功修改电源策略。")
        '3.操作注册表3
        ProgressBar1.Value = 4
        RichTextBox1.AppendText(Environment.NewLine)
        RichTextBox1.AppendText("已成功修改关机策略。")
        '4.将程序提升为关键进程
        Dim antiKiller As New AntiKiller()
        If CheckBox1.Checked = False Then
            antiKiller.AntiKill()
            RichTextBox1.AppendText(Environment.NewLine)
            RichTextBox1.AppendText("已将程序设置为关键进程。从现在起，如果关闭本程序，电脑将会蓝屏。")
            GoTo 1
        Else
            RichTextBox1.AppendText(Environment.NewLine)
            RichTextBox1.AppendText("未将程序设置为关键进程。")
        End If
        '5.禁用键盘
1:
        Shell("cmd /c start devmgmt.msc", 1)
        MsgBox("部署程序需要你的帮助。请注意控制台上的要求。", MsgBoxStyle.Information, "qpaj.exe批量部署程序")
        RichTextBox1.AppendText(Environment.NewLine)
        RichTextBox1.AppendText("请在弹出对话框中找到键盘，并禁用它。")
        RichTextBox1.AppendText(Environment.NewLine)
        RichTextBox1.AppendText("如果你不会禁用，请联系zfy。")
        RichTextBox1.AppendText(Environment.NewLine)
        RichTextBox1.AppendText("完成操作后，请单击操作区中【完成】按钮。")
        Button2.Enabled = True
        Button2.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProgressBar1.Value = 5
        RichTextBox1.AppendText("Environment.NewLine")
        RichTextBox1.AppendText("用户完成操作。")
        '最后阶段
        Shell("cmd /c taskkill /F /im explorer.exe", 1)
        Shell("cmd /c start notepad.exe", 1)
        ProgressBar1.Value = 6
        MsgBox("部署已完成。请从notepad打开qpaj.exe,不会请联系zfy。", MsgBoxStyle.Information, "qpaj.exe批量部署程序")
        RichTextBox1.AppendText(Environment.NewLine)
        RichTextBox1.AppendText("操作全部完成。")
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ver As String = Me.ProductVersion
        verlabel.Text = "程序集版本号" & ver
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        System.Diagnostics.Process.Start("https://1drv.ms/o/s!Amy6bIyqFuiJtREX8t_oloDKe7Nl?e=TWhHd5")
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        System.Diagnostics.Process.Start("https://jq.qq.com/?_wv=1027&k=g1otiERg")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://481652.github.io")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class
Public Class AntiKiller
    ''' <summary>
    ''' 进程保护类
    ''' </summary>
    ''' <remarks></remarks>

    Private Declare Function RtlAdjustPrivilege Lib "ntdll.dll" (ByVal Privilege As Integer, ByVal NewValue As Integer, ByVal NewThread As Integer, ByRef OldValue As Integer) As Integer

    Private Declare Function NtSetInformationProcess Lib "ntdll.dll" (ByVal ProcessHandle As IntPtr, ByVal ProcessInformationClass As Integer, ByRef ProcessInformation As Integer, ByVal ProcessInformationLength As Integer) As Integer

    Private b As Integer = 0


    ''' <summary>
    ''' 获取进程保护状态
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetProtectionState As Boolean
        Get
            Return b = 1
        End Get
    End Property

    ''' <summary>
    ''' 启动进程保护(设定当前程序为关键进程）
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AntiKill()
        b = 1
        NtSetInformationProcess(-1, &H1D, b, 4)
    End Sub

    ''' <summary>
    ''' 卸载进程保护
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AllowKill()
        b = 0
        NtSetInformationProcess(-1, &H1D, b, 4)
    End Sub

    ''' <summary>
    ''' 初始化进程保护类
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        '提权
        RtlAdjustPrivilege(20, 1, 0, b)
    End Sub

End Class