﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property Host() As String
            Get
                Return CType(Me("Host"),String)
            End Get
            Set
                Me("Host") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BaseDatos() As String
            Get
                Return CType(Me("BaseDatos"),String)
            End Get
            Set
                Me("BaseDatos") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property AutoLogin() As Boolean
            Get
                Return CType(Me("AutoLogin"),Boolean)
            End Get
            Set
                Me("AutoLogin") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property AutoPasswd() As String
            Get
                Return CType(Me("AutoPasswd"),String)
            End Get
            Set
                Me("AutoPasswd") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property UltUser() As String
            Get
                Return CType(Me("UltUser"),String)
            End Get
            Set
                Me("UltUser") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property CodVendedor() As Integer
            Get
                Return CType(Me("CodVendedor"), Integer)
            End Get
            Set(value As Integer)
                Me("CodVendedor") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("COM1:")> _
        Public Property PrintPort() As String
            Get
                Return CType(Me("PrintPort"), String)
            End Get
            Set(value As String)
                Me("PrintPort") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property Estacion() As Short
            Get
                Return CType(Me("Estacion"), Short)
            End Get
            Set(value As Short)
                Me("Estacion") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property Version() As Short
            Get
                Return CType(Me("Version"), Short)
            End Get
            Set(value As Short)
                Me("Version") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property Impresora() As Short
            Get
                Return CType(Me("Impresora"), Short)
            End Get
            Set(value As Short)
                Me("Impresora") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property PrintTo() As Short
            Get
                Return CType(Me("PrintTo"), Short)
            End Get
            Set(value As Short)
                Me("PrintTo") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property TipoLetra() As Short
            Get
                Return CType(Me("TipoLetra"), Short)
            End Get
            Set(value As Short)
                Me("TipoLetra") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("False")> _
        Public Property NombreEnTickets() As Boolean
            Get
                Return CType(Me("NombreEnTickets"), Boolean)
            End Get
            Set(value As Boolean)
                Me("NombreEnTickets") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property SaltarLineasAntes() As Short
            Get
                Return CType(Me("SaltarLineasAntes"), Short)
            End Get
            Set(value As Short)
                Me("SaltarLineasAntes") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property SaltarLineasDespues() As Short
            Get
                Return CType(Me("SaltarLineasDespues"), Short)
            End Get
            Set(value As Short)
                Me("SaltarLineasDespues") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("0")> _
        Public Property MargenIzq() As Short
            Get
                Return CType(Me("MargenIzq"), Short)
            End Get
            Set(value As Short)
                Me("MargenIzq") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("False")> _
        Public Property CortarPapel() As Boolean
            Get
                Return CType(Me("CortarPapel"), Boolean)
            End Get
            Set(value As Boolean)
                Me("CortarPapel") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Property Servers() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("Servers"), Global.System.Collections.Specialized.StringCollection)
            End Get
            Set(value As Global.System.Collections.Specialized.StringCollection)
                Me("Servers") = value
            End Set
        End Property

        <Global.System.Configuration.UserScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("")> _
        Public Property NomVendedor() As String
            Get
                Return CType(Me("NomVendedor"), String)
            End Get
            Set(value As String)
                Me("NomVendedor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property Speed() As Integer
            Get
                Return CType(Me("Speed"),Integer)
            End Get
            Set
                Me("Speed") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property TipoTicket() As Short
            Get
                Return CType(Me("TipoTicket"),Short)
            End Get
            Set
                Me("TipoTicket") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Interlineado() As Boolean
            Get
                Return CType(Me("Interlineado"),Boolean)
            End Get
            Set
                Me("Interlineado") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.VisualRecargaPOS.My.MySettings
            Get
                Return Global.VisualRecargaPOS.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace