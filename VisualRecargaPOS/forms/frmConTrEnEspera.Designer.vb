<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConTrEnEspera
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
        Me.lvwTransacciones = New System.Windows.Forms.ListView()
        Me.colNroTransaccion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colOperadora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumero = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMonto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSegundos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colError = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.tmrConsulta = New System.Windows.Forms.Timer(Me.components)
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lvwTransacciones
        '
        Me.lvwTransacciones.AutoArrange = False
        Me.lvwTransacciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNroTransaccion, Me.colOperadora, Me.colNumero, Me.colMonto, Me.colHora, Me.colSegundos, Me.colStatus, Me.colError})
        Me.lvwTransacciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lvwTransacciones.FullRowSelect = True
        Me.lvwTransacciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwTransacciones.HideSelection = False
        Me.lvwTransacciones.LabelWrap = False
        Me.lvwTransacciones.Location = New System.Drawing.Point(0, 24)
        Me.lvwTransacciones.MultiSelect = False
        Me.lvwTransacciones.Name = "lvwTransacciones"
        Me.lvwTransacciones.Size = New System.Drawing.Size(826, 86)
        Me.lvwTransacciones.TabIndex = 0
        Me.lvwTransacciones.UseCompatibleStateImageBehavior = False
        Me.lvwTransacciones.View = System.Windows.Forms.View.Details
        '
        'colNroTransaccion
        '
        Me.colNroTransaccion.Text = "Transacción"
        Me.colNroTransaccion.Width = 113
        '
        'colOperadora
        '
        Me.colOperadora.Text = "Operadora"
        Me.colOperadora.Width = 148
        '
        'colNumero
        '
        Me.colNumero.Text = "Número"
        Me.colNumero.Width = 137
        '
        'colMonto
        '
        Me.colMonto.Text = "Monto"
        Me.colMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colMonto.Width = 74
        '
        'colHora
        '
        Me.colHora.Text = "Hora"
        Me.colHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colHora.Width = 81
        '
        'colSegundos
        '
        Me.colSegundos.Text = "Duración"
        Me.colSegundos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSegundos.Width = 93
        '
        'colStatus
        '
        Me.colStatus.Text = "Estatus"
        Me.colStatus.Width = 73
        '
        'colError
        '
        Me.colError.Text = "Cod. Error"
        Me.colError.Width = 96
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalir.Location = New System.Drawing.Point(416, 110)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(110, 38)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'tmrConsulta
        '
        Me.tmrConsulta.Interval = 1000
        '
        'btnImprimir
        '
        Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnImprimir.Location = New System.Drawing.Point(300, 110)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(110, 38)
        Me.btnImprimir.TabIndex = 1
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblHora
        '
        Me.lblHora.AutoSize = True
        Me.lblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblHora.Location = New System.Drawing.Point(745, 128)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(79, 20)
        Me.lblHora.TabIndex = 3
        Me.lblHora.Text = "99:99:99"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(267, 20)
        Me.lblTitulo.TabIndex = 4
        Me.lblTitulo.Text = "Última transacción en proceso..."
        '
        'frmConTrEnEspera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(826, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.lblHora)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lvwTransacciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConTrEnEspera"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwTransacciones As System.Windows.Forms.ListView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents colNroTransaccion As System.Windows.Forms.ColumnHeader
    Friend WithEvents colOperadora As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumero As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMonto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHora As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSegundos As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrConsulta As System.Windows.Forms.Timer
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents colError As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblHora As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
End Class
