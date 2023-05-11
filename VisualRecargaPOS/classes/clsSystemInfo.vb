Option Strict On
Imports System.Environment
Public Class clsSystemInfo

    '**CONSTANTS
    Private Const EM_UNDO As Long = &HC7
    Private Const PROCESSOR_INTEL_386 As Integer = 386
    Private Const PROCESSOR_INTEL_486 As Integer = 486
    Private Const PROCESSOR_INTEL_PENTIUM As Integer = 586
    Private Const PROCESSOR_MIPS_R4000 As Integer = 4000
    Private Const PROCESSOR_ALPHA_21064 As Integer = 21064
    Private Const ENTERPRISE_TYPE_LIVESTOCK As Long = 1
    Private Const ENTERPRISE_TYPE_CROP As Long = 2

    ' Local variable(s) to hold property value(s)
    Private mvarWinVersion As String 'local copy
    Private mvarWinName As String 'local copy
    Private mvarCPUVersion As String 'local copy
    Private mvarMemoryTotal As Long 'local copy
    Private mvarMemoryFree As Long 'local copy
    Private mvarVirtualMemoryTotal As Long 'local copy
    Private mvarVirtualMemoryFree As Object 'local copy
    Private mvarIEVersion As String 'local copy

    Public ReadOnly Property VirtualMemoryFree() As Long
        Get
            VirtualMemoryFree = CLng(mvarVirtualMemoryFree)
        End Get
    End Property
    Public ReadOnly Property VirtualMemoryTotal() As Long
        Get
            VirtualMemoryTotal = mvarVirtualMemoryTotal
        End Get
    End Property
    Public ReadOnly Property MemoryFree() As Long
        Get
            MemoryFree = mvarMemoryFree
        End Get
    End Property
    Public ReadOnly Property MemoryTotal() As Long
        Get
            MemoryTotal = mvarMemoryTotal
        End Get
    End Property
    Public ReadOnly Property WinVersion() As String
        Get
            WinVersion = mvarWinVersion
        End Get
    End Property
    Public ReadOnly Property WinName() As String
        Get
            WinName = mvarWinName
        End Get
    End Property
    Public ReadOnly Property CPUVersion() As String
        Get
            CPUVersion = mvarCPUVersion
        End Get
    End Property
    Public ReadOnly Property IEVersion() As String
        Get
            IEVersion = mvarIEVersion
        End Get
    End Property

    Private Sub SystemInformation()
        Select Case Environment.OSVersion.Platform
            Case PlatformID.Win32S
                mvarWinName = "Win 3.1"
            Case PlatformID.Win32Windows
                Select Case Environment.OSVersion.Version.Minor
                    Case 0
                        mvarWinName = "Win95"
                    Case 10
                        mvarWinName = "Win98"
                    Case 90
                        mvarWinName = "WinME"
                    Case Else
                        mvarWinName = "Unknown"
                End Select
            Case PlatformID.Win32NT
                Select Case Environment.OSVersion.Version.Major
                    Case 3
                        mvarWinName = "NT 3.51"
                    Case 4
                        mvarWinName = "NT 4.0"
                    Case 5
                        Select Case Environment.OSVersion.Version.Minor
                            Case 0
                                mvarWinName = "Win2000"
                            Case 1
                                mvarWinName = "WinXP"
                            Case 2
                                mvarWinName = "Win2003"
                        End Select
                    Case 6
                        Select Case Environment.OSVersion.Version.Minor
                            Case 0
                                mvarWinName = "Vista/Win2008Server"
                            Case 1
                                mvarWinName = "Win7/Win2008Server R2"
                            Case 2
                                mvarWinName = "Win8/Win2012Server"
                            Case 3
                                mvarWinName = "Win8.1/Win2012Server R2"
                        End Select
                    Case Else
                        mvarWinName = "Unknown"
                End Select
            Case PlatformID.WinCE
                mvarWinName = "Win CE"
        End Select
        mvarWinVersion = OSVersion.Version.Major & "." &
                         OSVersion.Version.Minor &
                         " (Build " & OSVersion.Version.Revision.ToString() & ")"
        ' VER QUE OTRAS COSAS SE PUEDEN BUSCAR AQUI. PENDIENTE!
    End Sub

    Public Sub New()
        Call SystemInformation()
    End Sub
End Class
