<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMensaje
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFechaEnvio = New System.Windows.Forms.Label()
        Me.lblEnviadoPor = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.btnLeido = New System.Windows.Forms.Button()
        Me.lblNroMsg = New System.Windows.Forms.Label()
        Me.tmrMensaje = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRecibirMsg = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Envío:"
        '
        'lblFechaEnvio
        '
        Me.lblFechaEnvio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaEnvio.CausesValidation = False
        Me.lblFechaEnvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaEnvio.Location = New System.Drawing.Point(76, 4)
        Me.lblFechaEnvio.Name = "lblFechaEnvio"
        Me.lblFechaEnvio.Size = New System.Drawing.Size(96, 20)
        Me.lblFechaEnvio.TabIndex = 1
        Me.lblFechaEnvio.Text = "dd/MM/yyyy"
        Me.lblFechaEnvio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEnviadoPor
        '
        Me.lblEnviadoPor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEnviadoPor.CausesValidation = False
        Me.lblEnviadoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnviadoPor.Location = New System.Drawing.Point(76, 28)
        Me.lblEnviadoPor.Name = "lblEnviadoPor"
        Me.lblEnviadoPor.Size = New System.Drawing.Size(224, 32)
        Me.lblEnviadoPor.TabIndex = 3
        Me.lblEnviadoPor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Enviado por:"
        '
        'txtMensaje
        '
        Me.txtMensaje.CausesValidation = False
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(4, 64)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ReadOnly = True
        Me.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMensaje.Size = New System.Drawing.Size(336, 196)
        Me.txtMensaje.TabIndex = 4
        '
        'btnLeido
        '
        Me.btnLeido.Location = New System.Drawing.Point(272, 4)
        Me.btnLeido.Name = "btnLeido"
        Me.btnLeido.Size = New System.Drawing.Size(68, 23)
        Me.btnLeido.TabIndex = 5
        Me.btnLeido.Text = "&Leído"
        Me.btnLeido.UseVisualStyleBackColor = True
        '
        'lblNroMsg
        '
        Me.lblNroMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNroMsg.CausesValidation = False
        Me.lblNroMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroMsg.Location = New System.Drawing.Point(304, 28)
        Me.lblNroMsg.Name = "lblNroMsg"
        Me.lblNroMsg.Size = New System.Drawing.Size(36, 20)
        Me.lblNroMsg.TabIndex = 6
        Me.lblNroMsg.Text = "1"
        Me.lblNroMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrMensaje
        '
        Me.tmrMensaje.Interval = 1000
        '
        'tmrRecibirMsg
        '
        Me.tmrRecibirMsg.Interval = 1000
        '
        'frmMensaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblNroMsg)
        Me.Controls.Add(Me.btnLeido)
        Me.Controls.Add(Me.txtMensaje)
        Me.Controls.Add(Me.lblEnviadoPor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblFechaEnvio)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMensaje"
        Me.Opacity = 0.75R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mensaje"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFechaEnvio As System.Windows.Forms.Label
    Friend WithEvents lblEnviadoPor As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents btnLeido As System.Windows.Forms.Button
    Friend WithEvents lblNroMsg As System.Windows.Forms.Label
    Friend WithEvents tmrMensaje As System.Windows.Forms.Timer
    Friend WithEvents tmrRecibirMsg As System.Windows.Forms.Timer
End Class
