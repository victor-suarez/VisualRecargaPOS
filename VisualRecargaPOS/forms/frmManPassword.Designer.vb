<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManPassword
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOldPasswd = New System.Windows.Forms.TextBox()
        Me.txtNewPasswd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtConPasswd = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCambiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Contraseña actual:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOldPasswd
        '
        Me.txtOldPasswd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOldPasswd.Location = New System.Drawing.Point(128, 8)
        Me.txtOldPasswd.MaxLength = 15
        Me.txtOldPasswd.Name = "txtOldPasswd"
        Me.txtOldPasswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPasswd.Size = New System.Drawing.Size(84, 20)
        Me.txtOldPasswd.TabIndex = 1
        '
        'txtNewPasswd
        '
        Me.txtNewPasswd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewPasswd.Location = New System.Drawing.Point(128, 36)
        Me.txtNewPasswd.MaxLength = 15
        Me.txtNewPasswd.Name = "txtNewPasswd"
        Me.txtNewPasswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPasswd.Size = New System.Drawing.Size(84, 20)
        Me.txtNewPasswd.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nueva Contraseña:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtConPasswd
        '
        Me.txtConPasswd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConPasswd.Location = New System.Drawing.Point(128, 64)
        Me.txtConPasswd.MaxLength = 15
        Me.txtConPasswd.Name = "txtConPasswd"
        Me.txtConPasswd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConPasswd.Size = New System.Drawing.Size(84, 20)
        Me.txtConPasswd.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Confirmar Contraseña:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCambiar
        '
        Me.btnCambiar.Location = New System.Drawing.Point(30, 92)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(75, 23)
        Me.btnCambiar.TabIndex = 6
        Me.btnCambiar.Text = "&Cambiar"
        Me.btnCambiar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(118, 92)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmManPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(222, 125)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnCambiar)
        Me.Controls.Add(Me.txtConPasswd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNewPasswd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOldPasswd)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmManPassword"
        Me.Text = "Cambio de contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOldPasswd As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPasswd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConPasswd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCambiar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
