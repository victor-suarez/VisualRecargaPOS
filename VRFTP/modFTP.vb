Option Strict On
Imports System.IO
Imports System.Security.AccessControl
Imports System.Security.Principal

Friend Module modFTP
    Private ftpSERVER As String
    Private ftpUSER As String
    Private ftpPASSWD As String
    Private ftpDOWNLOAD As String
    Private ftpFILE As String
    Private ftpSIZE As Integer
    Private ftpAPPRUN As String

    Private AppPath As String
    Private Sub Download()
        Try
            'Create a request
            Dim URI As String = "ftp://" & ftpSERVER & "/" & ftpDOWNLOAD
            Dim ftp As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(URI), System.Net.FtpWebRequest)
            'Set the credentials
            ftp.Credentials = New System.Net.NetworkCredential(ftpUSER, ftpPASSWD)
            'Turn off KeepAlive (will close connection on completion)
            ftp.KeepAlive = False
            'we want a binary
            ftp.UseBinary = True
            'Use pasive mode
            ftp.UsePassive = True
            'Define the action required (in this case, download a file)
            ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile
            'Get the response to the Ftp request and the associated stream
            Dim response As System.Net.FtpWebResponse = CType(ftp.GetResponse, System.Net.FtpWebResponse)
            Dim responseStream As IO.Stream = response.GetResponseStream
            'loop to read & write to file
            Dim sDownFileName As String
            ' Si no es alguno de los programas que actualizan, se llama tal cual,
            ' sino, se renombra luego porque puede estar corriendo.
            If ftpFILE.ToUpper() <> "VRFTP.EXE" And ftpFILE.ToUpper() <> "VRBLOB.EXE" Then
                sDownFileName = AppPath & ftpDOWNLOAD
            Else
                sDownFileName = AppPath & ftpFILE
            End If
            Dim fs As New IO.FileStream(sDownFileName, IO.FileMode.Create)
            If response.ContentLength > 0 Then
                frmFTP.barFTP.Maximum = CInt(response.ContentLength)
            Else
                frmFTP.barFTP.Maximum = ftpSIZE
            End If
            Dim buffer(2047) As Byte
            Dim read As Integer = 0
            Do
                read = responseStream.Read(buffer, 0, buffer.Length)
                fs.Write(buffer, 0, read)
                frmFTP.barFTP.Value += read
                frmFTP.barFTP.Refresh()
            Loop Until read = 0 'see Note(1)
            responseStream.Close()
            fs.Flush()
            fs.Close()
            frmFTP.barFTP.Value = frmFTP.barFTP.Maximum
            response.Close()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source & ": " & ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Asterisk)
            End
        End Try
    End Sub

    Private Function GetFileSize() As Integer
        Try
            Dim URI As String = "ftp://" & ftpSERVER & "/" & ftpDOWNLOAD
            Dim ftp As System.Net.FtpWebRequest = CType(System.Net.FtpWebRequest.Create(URI), System.Net.FtpWebRequest)
            ftp.Credentials = New System.Net.NetworkCredential(ftpUSER, ftpPASSWD)
            ftp.UsePassive = True
            ftp.Method = System.Net.WebRequestMethods.Ftp.GetFileSize
            Dim response As System.Net.FtpWebResponse = CType(ftp.GetResponse, System.Net.FtpWebResponse)
            Dim dataLength As Integer = CType(ftp.GetResponse().ContentLength, Integer)
            response.Close()
            Return dataLength
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Source & ": " & ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Asterisk)
            End
        End Try
    End Function

    Private Sub KillApp(strApp As String)
        Dim myProcesses As Process()
        Try
            myProcesses = Process.GetProcessesByName(strApp)
            'myProcesses = Process.GetProcesses()
            'For i = 0 To myProcesses.Length - 1 : Debug.Print(myProcesses(i).ProcessName) : Next i
            If myProcesses.Length = 1 Then Debug.Print(myProcesses(0).ProcessName) : myProcesses(0).Kill()
        Catch ex As Exception
            Throw ex
        End Try
        myProcesses = Nothing
    End Sub

    Sub Main()
        'Recibe los parámetros e inicializa el directorio de trabajo
        Dim strLocalApp As String = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        ''Dim strLocalApp As String = Application.StartupPath()
        Dim strInput As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        AppPath = strLocalApp
        If Not AppPath.EndsWith("\") Then AppPath = AppPath & "\"

        If strInput Is Nothing Then Windows.Forms.MessageBox.Show("Error: Faltan los argumentos del programa", "ERROR FTP", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Asterisk) : End
        If strInput.Count < 5 Then Windows.Forms.MessageBox.Show("Error: Los parámetros están incompletos", "ERROR FTP", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Asterisk) : End
        '  ftpSERVER   ftpUSER  ftpPASSWD ftpDOWNLOAD ftpFILE
        '72.46.238.203 esconftp f7p35c0n  vrpos100    VisualRecargaPOS.exe
        ftpSERVER = strInput.Item(0)    '72.46.238.203
        ftpUSER = strInput.Item(1)      'esconftp
        ftpPASSWD = strInput.Item(2)    'f7p35c0n
        ftpDOWNLOAD = strInput.Item(3)  'vrpos100
        ftpFILE = strInput.Item(4)      'VisualRecargaPOS.exe
        'ftpAPPRUN (OPCIONAL) POS/ADM 
        If strInput.Count = 6 Then ftpAPPRUN = strInput.Item(5)
        frmFTP.Show()
        frmFTP.lblFile.Text = "Verificando " & ftpDOWNLOAD & "..."
        frmFTP.Refresh()
        ftpSIZE = GetFileSize()
        If ftpSIZE = -1 Then
            Windows.Forms.MessageBox.Show("No se encuentra el archivo " & ftpDOWNLOAD & " en el servidor.", "ERROR FTP", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Asterisk)
            frmFTP.Dispose()
            End
        End If
        'Solicitar permisos para escribir en ProgramFiles donde está instalado el programa (ACL)
        Call AddDirectorySecurity(AppPath, WindowsIdentity.GetCurrent().Name, FileSystemRights.CreateFiles And FileSystemRights.Delete, AccessControlType.Allow)

        frmFTP.lblFile.Text = "Descargando " & ftpDOWNLOAD & " (" & ftpSIZE & ") bytes..."
        frmFTP.lblFile.Refresh()
        Call Download()
        File.Create("TRANSFER_COMPLETED")
        'frmFTP.Dispose()

        'Renombrar la aplicación
        If ftpFILE.ToUpper() <> "VRFTP.EXE" And ftpFILE.ToUpper() <> "VRBLOB.EXE" Then
            If ftpFILE.StartsWith("Visual") Then
                frmFTP.lblFile.Text = "Cerrando la aplicación..."
                frmFTP.lblFile.Refresh()
                If ftpDOWNLOAD = "VRPOS" Then
                    Try
                        Call KillApp("VisualRecargaPOS")
                        Windows.Forms.Application.DoEvents()
                    Catch ex As Exception
                        Windows.Forms.MessageBox.Show("Error terminando la aplicación Visual Recarga (Punto de Venta)." & ex.Message, "Error cerrando aplicación", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        End
                    End Try
                ElseIf ftpDOWNLOAD = "VRADM" Then
                    Try
                        Call KillApp("VisualRecargaADM")
                        Windows.Forms.Application.DoEvents()
                    Catch ex As Exception
                        Windows.Forms.MessageBox.Show("Error terminando la aplicación Visual Recarga (Administrativo)." & ex.Message, "Error cerrando aplicación", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        End
                    End Try
                End If
                If IO.File.Exists(AppPath & ftpFILE) Then
                    If IO.File.Exists(AppPath & ftpFILE & ".BAK") Then
                        IO.File.Delete(AppPath & ftpFILE & ".BAK")
                        Windows.Forms.Application.DoEvents()
                    End If
                    frmFTP.lblFile.Text = "Eliminando versión anterior del programa " & AppPath & ftpFILE & "..."
                    frmFTP.lblFile.Refresh()
                    Try
                        IO.File.Move(AppPath & ftpFILE, AppPath & ftpFILE & ".BAK")
                        Windows.Forms.Application.DoEvents()
                    Catch ex As Exception
                        Windows.Forms.MessageBox.Show("Error eliminando versión anterior del programa " & AppPath & ftpFILE & " inténtelo manualmente." & ex.Message, "Error eliminando archivo", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        End
                    End Try
                End If

                frmFTP.lblFile.Text = "Renombrando el archivo..."
                frmFTP.lblFile.Refresh()
                Try
                    IO.File.Move(AppPath & ftpDOWNLOAD, AppPath & ftpFILE)  ' Rename file.
                Catch ex As Exception
                    Windows.Forms.MessageBox.Show("Error renombrando el archivo " & AppPath & ftpDOWNLOAD & " como " & AppPath & ftpFILE & " inténtelo manualmente." & ex.Message, "Error renombrando archivo", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                    End
                End Try
                Windows.Forms.Application.DoEvents()

                'If ftpAPPRUN <> "" Then
                'End If

                Dim lAppRun As String = AppPath & ftpFILE
                frmFTP.lblFile.Text = "Intento ejecutar " & lAppRun
                frmFTP.lblFile.Refresh()
                Try
                    Dim pRET As Process = Process.Start(lAppRun, "")
                Catch ex As System.ComponentModel.Win32Exception
                    Windows.Forms.MessageBox.Show("Error ejecutando la aplicación: " & lAppRun & " " & ex.Message, "Archivo No Existe", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Catch ex As FileNotFoundException
                    Windows.Forms.MessageBox.Show("No consigo la aplicación: " & lAppRun, "Archivo No Existe", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Catch ex As IOException
                    Windows.Forms.MessageBox.Show(ex.Source & " " & ex.Message, "Error Ejecutando Aplicación", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
                End Try
            Else
                If IO.File.Exists(AppPath & ftpFILE) Then
                    frmFTP.lblFile.Text = "Eliminando versión anterior del programa " & AppPath & ftpFILE & "..."
                    frmFTP.lblFile.Refresh()
                    Try
                        IO.File.Delete(AppPath & ftpFILE)
                    Catch ex As Exception
                        Windows.Forms.MessageBox.Show("Error eliminando versión anterior del programa " & AppPath & ftpFILE & " inténtelo manualmente." & ex.Message, "Error eliminando archivo", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        End
                    End Try
                    Windows.Forms.Application.DoEvents()
                End If
                frmFTP.lblFile.Text = "Renombrando el archivo..."
                frmFTP.lblFile.Refresh()
                Try
                    IO.File.Move(AppPath & ftpDOWNLOAD, AppPath & ftpFILE)  ' Rename file.
                Catch ex As Exception
                    Windows.Forms.MessageBox.Show("Error renombrando el archivo " & AppPath & ftpDOWNLOAD & " como " & AppPath & ftpFILE & " inténtelo manualmente." & ex.Message, "Error renombrando archivo", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                    End
                End Try
            End If
        End If
        'Cancelar permisos para escribir en ProgramFiles donde está instalado el programa (ACL)
        Call RemoveDirectorySecurity(AppPath, WindowsIdentity.GetCurrent().Name, FileSystemRights.CreateFiles And FileSystemRights.Delete, AccessControlType.Allow)
        frmFTP.lblFile.Text = "Finalizando el programa!"
        frmFTP.lblFile.Refresh()
        End
    End Sub

    ' Adds an ACL entry on the specified directory for the specified account.
    Sub AddDirectorySecurity(ByVal DirName As String, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal ControlType As AccessControlType)
        ' Create a new DirectoryInfoobject.
        Dim dInfo As New DirectoryInfo(DirName)

        ' Get a DirectorySecurity object that represents the 
        ' current security settings.
        Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()

        ' Add the FileSystemAccessRule to the security settings. 
        dSecurity.AddAccessRule(New FileSystemAccessRule(Account, Rights, ControlType))

        ' Set the new access settings.
        dInfo.SetAccessControl(dSecurity)
    End Sub

    ' Removes an ACL entry on the specified directory for the specified account.
    Sub RemoveDirectorySecurity(ByVal DirName As String, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal ControlType As AccessControlType)
        ' Create a new DirectoryInfo object.
        Dim dInfo As New DirectoryInfo(DirName)

        ' Get a DirectorySecurity object that represents the 
        ' current security settings.
        Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()

        ' Add the FileSystemAccessRule to the security settings. 
        dSecurity.RemoveAccessRule(New FileSystemAccessRule(Account, Rights, ControlType))

        ' Set the new access settings.
        dInfo.SetAccessControl(dSecurity)
    End Sub
End Module
