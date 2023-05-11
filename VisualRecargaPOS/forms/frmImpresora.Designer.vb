<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpresora
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
        Me.txtPrn = New System.Windows.Forms.TextBox()
        Me.grpButtons = New System.Windows.Forms.GroupBox()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.grpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPrn
        '
        Me.txtPrn.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrn.Location = New System.Drawing.Point(0, 0)
        Me.txtPrn.MaxLength = 0
        Me.txtPrn.Multiline = True
        Me.txtPrn.Name = "txtPrn"
        Me.txtPrn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPrn.Size = New System.Drawing.Size(332, 464)
        Me.txtPrn.TabIndex = 2
        Me.txtPrn.TabStop = False
        '
        'grpButtons
        '
        Me.grpButtons.Controls.Add(Me.btnCerrar)
        Me.grpButtons.Controls.Add(Me.btnImprimir)
        Me.grpButtons.Location = New System.Drawing.Point(54, 468)
        Me.grpButtons.Name = "grpButtons"
        Me.grpButtons.Size = New System.Drawing.Size(224, 41)
        Me.grpButtons.TabIndex = 3
        Me.grpButtons.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(116, 12)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(92, 24)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(17, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(92, 24)
        Me.btnImprimir.TabIndex = 0
        Me.btnImprimir.Text = "&Imprimir [ESC]"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'frmImpresora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(332, 515)
        Me.Controls.Add(Me.txtPrn)
        Me.Controls.Add(Me.grpButtons)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmImpresora"
        Me.grpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrn As System.Windows.Forms.TextBox
    Friend WithEvents grpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
