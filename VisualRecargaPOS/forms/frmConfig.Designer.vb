<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpImpresion = New System.Windows.Forms.GroupBox()
        Me.chkNombreEnTicket = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipoLetra = New System.Windows.Forms.ComboBox()
        Me.cmbPrintTo = New System.Windows.Forms.ComboBox()
        Me.btnTicketPrueba = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLineasDespues = New System.Windows.Forms.NumericUpDown()
        Me.txtLineasAntes = New System.Windows.Forms.NumericUpDown()
        Me.txtMargenIzq = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkInterlineado = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSpeed = New System.Windows.Forms.ComboBox()
        Me.cmbPuerto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbImpresora = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkCortarPapel = New System.Windows.Forms.CheckBox()
        Me.grpConexion = New System.Windows.Forms.GroupBox()
        Me.lblNombrePC = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblEstacion = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblBaseDatos = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblServidor = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpImpresion.SuspendLayout()
        CType(Me.txtLineasDespues, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLineasAntes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMargenIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpConexion.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(559, 145)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(559, 173)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'grpImpresion
        '
        Me.grpImpresion.Controls.Add(Me.chkNombreEnTicket)
        Me.grpImpresion.Controls.Add(Me.Label6)
        Me.grpImpresion.Controls.Add(Me.cmbTipoLetra)
        Me.grpImpresion.Controls.Add(Me.cmbPrintTo)
        Me.grpImpresion.Controls.Add(Me.btnTicketPrueba)
        Me.grpImpresion.Controls.Add(Me.Label5)
        Me.grpImpresion.Controls.Add(Me.txtLineasDespues)
        Me.grpImpresion.Controls.Add(Me.txtLineasAntes)
        Me.grpImpresion.Controls.Add(Me.txtMargenIzq)
        Me.grpImpresion.Controls.Add(Me.Label1)
        Me.grpImpresion.Controls.Add(Me.chkInterlineado)
        Me.grpImpresion.Controls.Add(Me.Label2)
        Me.grpImpresion.Controls.Add(Me.cmbSpeed)
        Me.grpImpresion.Controls.Add(Me.cmbPuerto)
        Me.grpImpresion.Controls.Add(Me.Label8)
        Me.grpImpresion.Controls.Add(Me.Label3)
        Me.grpImpresion.Controls.Add(Me.Label7)
        Me.grpImpresion.Controls.Add(Me.cmbImpresora)
        Me.grpImpresion.Controls.Add(Me.Label4)
        Me.grpImpresion.Controls.Add(Me.chkCortarPapel)
        Me.grpImpresion.Location = New System.Drawing.Point(3, 3)
        Me.grpImpresion.Name = "grpImpresion"
        Me.grpImpresion.Size = New System.Drawing.Size(332, 311)
        Me.grpImpresion.TabIndex = 0
        Me.grpImpresion.TabStop = False
        Me.grpImpresion.Text = "Impresión"
        '
        'chkNombreEnTicket
        '
        Me.chkNombreEnTicket.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNombreEnTicket.Location = New System.Drawing.Point(7, 281)
        Me.chkNombreEnTicket.Name = "chkNombreEnTicket"
        Me.chkNombreEnTicket.Size = New System.Drawing.Size(162, 20)
        Me.chkNombreEnTicket.TabIndex = 18
        Me.chkNombreEnTicket.Text = "Nombre del &usuario en ticket"
        Me.chkNombreEnTicket.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "&Tipo de letra:"
        '
        'cmbTipoLetra
        '
        Me.cmbTipoLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoLetra.FormattingEnabled = True
        Me.cmbTipoLetra.Location = New System.Drawing.Point(156, 124)
        Me.cmbTipoLetra.Name = "cmbTipoLetra"
        Me.cmbTipoLetra.Size = New System.Drawing.Size(159, 21)
        Me.cmbTipoLetra.TabIndex = 9
        '
        'cmbPrintTo
        '
        Me.cmbPrintTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrintTo.FormattingEnabled = True
        Me.cmbPrintTo.Location = New System.Drawing.Point(156, 16)
        Me.cmbPrintTo.Name = "cmbPrintTo"
        Me.cmbPrintTo.Size = New System.Drawing.Size(159, 21)
        Me.cmbPrintTo.TabIndex = 1
        '
        'btnTicketPrueba
        '
        Me.btnTicketPrueba.Location = New System.Drawing.Point(210, 174)
        Me.btnTicketPrueba.Name = "btnTicketPrueba"
        Me.btnTicketPrueba.Size = New System.Drawing.Size(105, 27)
        Me.btnTicketPrueba.TabIndex = 19
        Me.btnTicketPrueba.Text = "Reci&bo de prueba"
        Me.btnTicketPrueba.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Líneas a saltar &después:"
        '
        'txtLineasDespues
        '
        Me.txtLineasDespues.Location = New System.Drawing.Point(156, 203)
        Me.txtLineasDespues.Name = "txtLineasDespues"
        Me.txtLineasDespues.Size = New System.Drawing.Size(48, 20)
        Me.txtLineasDespues.TabIndex = 15
        Me.txtLineasDespues.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLineasAntes
        '
        Me.txtLineasAntes.Location = New System.Drawing.Point(156, 177)
        Me.txtLineasAntes.Name = "txtLineasAntes"
        Me.txtLineasAntes.Size = New System.Drawing.Size(48, 20)
        Me.txtLineasAntes.TabIndex = 13
        Me.txtLineasAntes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMargenIzq
        '
        Me.txtMargenIzq.Location = New System.Drawing.Point(156, 151)
        Me.txtMargenIzq.Name = "txtMargenIzq"
        Me.txtMargenIzq.Size = New System.Drawing.Size(48, 20)
        Me.txtMargenIzq.TabIndex = 11
        Me.txtMargenIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Imprimir a:"
        '
        'chkInterlineado
        '
        Me.chkInterlineado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInterlineado.Location = New System.Drawing.Point(7, 255)
        Me.chkInterlineado.Name = "chkInterlineado"
        Me.chkInterlineado.Size = New System.Drawing.Size(162, 20)
        Me.chkInterlineado.TabIndex = 17
        Me.chkInterlineado.Text = "Inter&lineado doble:"
        Me.chkInterlineado.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Puerto:"
        '
        'cmbSpeed
        '
        Me.cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSpeed.FormattingEnabled = True
        Me.cmbSpeed.Location = New System.Drawing.Point(156, 70)
        Me.cmbSpeed.Name = "cmbSpeed"
        Me.cmbSpeed.Size = New System.Drawing.Size(159, 21)
        Me.cmbSpeed.TabIndex = 5
        '
        'cmbPuerto
        '
        Me.cmbPuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuerto.FormattingEnabled = True
        Me.cmbPuerto.Location = New System.Drawing.Point(156, 43)
        Me.cmbPuerto.Name = "cmbPuerto"
        Me.cmbPuerto.Size = New System.Drawing.Size(76, 21)
        Me.cmbPuerto.Sorted = True
        Me.cmbPuerto.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "&Velocidad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "I&mpresora:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 155)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Margen I&zquierdo:"
        '
        'cmbImpresora
        '
        Me.cmbImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresora.FormattingEnabled = True
        Me.cmbImpresora.Location = New System.Drawing.Point(156, 97)
        Me.cmbImpresora.Name = "cmbImpresora"
        Me.cmbImpresora.Size = New System.Drawing.Size(159, 21)
        Me.cmbImpresora.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Líneas a saltar &antes:"
        '
        'chkCortarPapel
        '
        Me.chkCortarPapel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCortarPapel.Location = New System.Drawing.Point(7, 229)
        Me.chkCortarPapel.Name = "chkCortarPapel"
        Me.chkCortarPapel.Size = New System.Drawing.Size(162, 20)
        Me.chkCortarPapel.TabIndex = 16
        Me.chkCortarPapel.Text = "C&ortar papel:"
        Me.chkCortarPapel.UseVisualStyleBackColor = True
        '
        'grpConexion
        '
        Me.grpConexion.Controls.Add(Me.lblNombrePC)
        Me.grpConexion.Controls.Add(Me.Label15)
        Me.grpConexion.Controls.Add(Me.lblEstacion)
        Me.grpConexion.Controls.Add(Me.Label13)
        Me.grpConexion.Controls.Add(Me.lblBaseDatos)
        Me.grpConexion.Controls.Add(Me.Label11)
        Me.grpConexion.Controls.Add(Me.lblServidor)
        Me.grpConexion.Controls.Add(Me.Label9)
        Me.grpConexion.Location = New System.Drawing.Point(341, 3)
        Me.grpConexion.Name = "grpConexion"
        Me.grpConexion.Size = New System.Drawing.Size(293, 133)
        Me.grpConexion.TabIndex = 1
        Me.grpConexion.TabStop = False
        Me.grpConexion.Text = "Conexión"
        '
        'lblNombrePC
        '
        Me.lblNombrePC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombrePC.Location = New System.Drawing.Point(89, 97)
        Me.lblNombrePC.Name = "lblNombrePC"
        Me.lblNombrePC.Size = New System.Drawing.Size(194, 21)
        Me.lblNombrePC.TabIndex = 7
        Me.lblNombrePC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNombrePC.UseMnemonic = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 101)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Nombre del PC:"
        '
        'lblEstacion
        '
        Me.lblEstacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEstacion.Location = New System.Drawing.Point(89, 70)
        Me.lblEstacion.Name = "lblEstacion"
        Me.lblEstacion.Size = New System.Drawing.Size(26, 21)
        Me.lblEstacion.TabIndex = 5
        Me.lblEstacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblEstacion.UseMnemonic = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Nro. Estación:"
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBaseDatos.Location = New System.Drawing.Point(89, 43)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(126, 21)
        Me.lblBaseDatos.TabIndex = 3
        Me.lblBaseDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBaseDatos.UseMnemonic = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Base de datos:"
        '
        'lblServidor
        '
        Me.lblServidor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblServidor.Location = New System.Drawing.Point(89, 16)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(194, 21)
        Me.lblServidor.TabIndex = 1
        Me.lblServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblServidor.UseMnemonic = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Servidor:"
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(637, 316)
        Me.Controls.Add(Me.grpConexion)
        Me.Controls.Add(Me.grpImpresion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.Text = "Configuración"
        Me.grpImpresion.ResumeLayout(False)
        Me.grpImpresion.PerformLayout()
        CType(Me.txtLineasDespues, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLineasAntes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMargenIzq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpConexion.ResumeLayout(False)
        Me.grpConexion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grpImpresion As System.Windows.Forms.GroupBox
    Friend WithEvents chkNombreEnTicket As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoLetra As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPrintTo As System.Windows.Forms.ComboBox
    Friend WithEvents btnTicketPrueba As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLineasDespues As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtLineasAntes As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtMargenIzq As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkInterlineado As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPuerto As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkCortarPapel As System.Windows.Forms.CheckBox
    Friend WithEvents grpConexion As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombrePC As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblEstacion As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblBaseDatos As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblServidor As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
