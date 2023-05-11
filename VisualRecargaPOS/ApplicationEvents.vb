Namespace My

    ' The following events are available for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim clC As New clsCesar ', lcAppRegistro As String
            If 1 <> 1 Then
                modSLM.ConectemosAhora()
                Exit Sub
            End If
            '''''''''''''''''''''''''''''''''''''''
            'My.Application.ChangeCulture("es-VE")
            With My.Application.Culture.NumberFormat
                If .CurrencyDecimalSeparator = .CurrencyGroupSeparator Or
                   .NumberDecimalSeparator = .NumberGroupSeparator Then
                    MessageBox.Show("Su configuración regional está usando el mismo caracter para el separador decimal" & vbCrLf &
                                    "y el separador de millares. El programa se cerrará, corrija y vuelva a intentar.", "Error en Configuración Regional", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End
                End If
            End With
            glCurSym = My.Application.Culture.NumberFormat.CurrencySymbol
            Dim word2 As String = "Taquilla" 'OJO OJO OJO Cambiar para cada programa
            glIsDebuggin = System.Diagnostics.Debugger.IsAttached
            ' Modulo por seguridad
#If Not DEBUG Then
            modSLM.ConectarAmiSQL() 'OJO OJO Seguridad desactivada en debug!
#End If
            glAppPath = If(Application.Info.DirectoryPath().EndsWith("\"), Application.Info.DirectoryPath(), Application.Info.DirectoryPath() & "\").ToString
            glUsrPath = If(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).EndsWith("\"), Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "Temp\", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Temp\").ToString
            glDBDef = "VR" 'OJO OJO OJO Cambiar para cada programa
#If Not DEBUG Then
            modSLM.ConectarAmiSQL() 'OJO OJO Seguridad desactivada en debug!
#End If
            ' Obtener parte de las variables de conexion para ser enviados al socket para su registro
            ' Obtener serial del disco
            'Call ObtenerSerial()
            glSerialDD = FingerPrint.DISK_ID
            glSerial = FingerPrint.Value
            If Not GetAppDataAgencia() Then
                MessageBox.Show("El programa Visual Recarga POS no está registrado apropiadamente." & vbCrLf & "Vamos a registrar la estación.", "Estación no registrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim frmReg As New frmParamReg
                iRET = frmReg.ShowDialog()
                If glIPServer = "" Then End
                If glGrupo = "" Then End
                If glCodVen = 0 Then End
                If glEstacion = 0 Then End
            End If

            ' Obtener el directorio de windows de la maquina
            glWinDir = System.Environment.GetEnvironmentVariable("windir")
            'iRET = GetWindowsDirectory(glWinDir, glWinDir.Lenght)
            If Not glWinDir.EndsWith("\") Then glWinDir &= "\"

            ' Obtener la version del sistema operativo de la maquina
            SInf = New clsSystemInfo
            glSistOper = SInf.WinName
            SInf = Nothing
        End Sub

        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            e.BringToForeground = True
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Call MensajeError(e.Exception, "Error no manejado por el programa.")
        End Sub
    End Class
End Namespace

