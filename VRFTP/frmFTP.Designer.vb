<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFTP
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
        Me.barFTP = New System.Windows.Forms.ProgressBar
        Me.lblFile = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'barFTP
        '
        Me.barFTP.Location = New System.Drawing.Point(8, 24)
        Me.barFTP.Name = "barFTP"
        Me.barFTP.Size = New System.Drawing.Size(372, 12)
        Me.barFTP.TabIndex = 0
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(12, 4)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(39, 13)
        Me.lblFile.TabIndex = 1
        Me.lblFile.Text = "Label1"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(156, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmFTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 66)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.barFTP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFTP"
        Me.ShowInTaskbar = False
        Me.Text = "FTP - Download"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents barFTP As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
