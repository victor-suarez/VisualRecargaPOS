<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConResumen
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
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lvwTransacciones = New System.Windows.Forms.ListView()
        Me.colOperadora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMonto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTrans = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAprob = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRchaz = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProcRchz = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tmrConsulta = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(242, 20)
        Me.lblTitulo.TabIndex = 7
        Me.lblTitulo.Text = "Resumen de transacciones..."
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalir.Location = New System.Drawing.Point(255, 213)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(110, 38)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lvwTransacciones
        '
        Me.lvwTransacciones.AutoArrange = False
        Me.lvwTransacciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colOperadora, Me.colMonto, Me.colTrans, Me.colAprob, Me.colRchaz, Me.colProcRchz, Me.colStatus})
        Me.lvwTransacciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lvwTransacciones.FullRowSelect = True
        Me.lvwTransacciones.GridLines = True
        Me.lvwTransacciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwTransacciones.HideSelection = False
        Me.lvwTransacciones.LabelWrap = False
        Me.lvwTransacciones.Location = New System.Drawing.Point(0, 24)
        Me.lvwTransacciones.MultiSelect = False
        Me.lvwTransacciones.Name = "lvwTransacciones"
        Me.lvwTransacciones.ShowGroups = False
        Me.lvwTransacciones.Size = New System.Drawing.Size(619, 186)
        Me.lvwTransacciones.TabIndex = 5
        Me.lvwTransacciones.UseCompatibleStateImageBehavior = False
        Me.lvwTransacciones.View = System.Windows.Forms.View.Details
        '
        'colOperadora
        '
        Me.colOperadora.Text = "Operadora"
        Me.colOperadora.Width = 148
        '
        'colMonto
        '
        Me.colMonto.Text = "Monto"
        Me.colMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMonto.Width = 82
        '
        'colTrans
        '
        Me.colTrans.Text = "Trans."
        Me.colTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTrans.Width = 70
        '
        'colAprob
        '
        Me.colAprob.Text = "Aprob."
        Me.colAprob.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colAprob.Width = 70
        '
        'colRchaz
        '
        Me.colRchaz.Text = "Rchaz."
        Me.colRchaz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colRchaz.Width = 70
        '
        'colProcRchz
        '
        Me.colProcRchz.Text = "%Rchaz."
        Me.colProcRchz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colProcRchz.Width = 76
        '
        'colStatus
        '
        Me.colStatus.Text = "Estatus"
        Me.colStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colStatus.Width = 73
        '
        'tmrConsulta
        '
        Me.tmrConsulta.Interval = 1000
        '
        'frmConResumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(620, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lvwTransacciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConResumen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lvwTransacciones As System.Windows.Forms.ListView
    Friend WithEvents colOperadora As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMonto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTrans As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAprob As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRchaz As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProcRchz As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrConsulta As System.Windows.Forms.Timer
End Class
