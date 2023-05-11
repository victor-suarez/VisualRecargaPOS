<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepositos
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cmbBancosVzla = New System.Windows.Forms.ComboBox()
        Me.cmbTipoDeposito = New System.Windows.Forms.ComboBox()
        Me.pnlCheque = New System.Windows.Forms.Panel()
        Me.txtChequeCuenta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCheque = New System.Windows.Forms.TextBox()
        Me.lvwDepositos = New System.Windows.Forms.ListView()
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBanco = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumero = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMonto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNroCuenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNroCheque = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbCtasVisual = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtNroDeposito = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.pnlCheque.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Fecha del depósito:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "&Nro. del depósito:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "&Banco del depósito:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "&Tipo de depósito:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "&Monto del depósito:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(121, 6)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(107, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'cmbBancosVzla
        '
        Me.cmbBancosVzla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBancosVzla.FormattingEnabled = True
        Me.cmbBancosVzla.Location = New System.Drawing.Point(121, 34)
        Me.cmbBancosVzla.Name = "cmbBancosVzla"
        Me.cmbBancosVzla.Size = New System.Drawing.Size(220, 21)
        Me.cmbBancosVzla.TabIndex = 3
        '
        'cmbTipoDeposito
        '
        Me.cmbTipoDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDeposito.FormattingEnabled = True
        Me.cmbTipoDeposito.Location = New System.Drawing.Point(121, 91)
        Me.cmbTipoDeposito.Name = "cmbTipoDeposito"
        Me.cmbTipoDeposito.Size = New System.Drawing.Size(136, 21)
        Me.cmbTipoDeposito.TabIndex = 7
        '
        'pnlCheque
        '
        Me.pnlCheque.Controls.Add(Me.txtChequeCuenta)
        Me.pnlCheque.Controls.Add(Me.Label7)
        Me.pnlCheque.Controls.Add(Me.Label6)
        Me.pnlCheque.Controls.Add(Me.txtCheque)
        Me.pnlCheque.Location = New System.Drawing.Point(262, 91)
        Me.pnlCheque.Name = "pnlCheque"
        Me.pnlCheque.Size = New System.Drawing.Size(224, 62)
        Me.pnlCheque.TabIndex = 12
        Me.pnlCheque.Visible = False
        '
        'txtChequeCuenta
        '
        Me.txtChequeCuenta.Location = New System.Drawing.Point(81, 8)
        Me.txtChequeCuenta.MaxLength = 20
        Me.txtChequeCuenta.Name = "txtChequeCuenta"
        Me.txtChequeCuenta.Size = New System.Drawing.Size(136, 20)
        Me.txtChequeCuenta.TabIndex = 1
        Me.txtChequeCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Nro. Cheque:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cta. Cheque:"
        '
        'txtCheque
        '
        Me.txtCheque.Location = New System.Drawing.Point(81, 32)
        Me.txtCheque.MaxLength = 20
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(136, 20)
        Me.txtCheque.TabIndex = 3
        Me.txtCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lvwDepositos
        '
        Me.lvwDepositos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFecha, Me.colBanco, Me.colTipo, Me.colNumero, Me.colMonto, Me.colEstado, Me.colNroCuenta, Me.colNroCheque})
        Me.lvwDepositos.FullRowSelect = True
        Me.lvwDepositos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwDepositos.Location = New System.Drawing.Point(1, 176)
        Me.lvwDepositos.MultiSelect = False
        Me.lvwDepositos.Name = "lvwDepositos"
        Me.lvwDepositos.Size = New System.Drawing.Size(498, 144)
        Me.lvwDepositos.TabIndex = 13
        Me.lvwDepositos.UseCompatibleStateImageBehavior = False
        Me.lvwDepositos.View = System.Windows.Forms.View.Details
        '
        'colFecha
        '
        Me.colFecha.Text = "Fecha"
        '
        'colBanco
        '
        Me.colBanco.Text = "Banco"
        '
        'colTipo
        '
        Me.colTipo.Text = "Tipo"
        '
        'colNumero
        '
        Me.colNumero.Text = "Número"
        '
        'colMonto
        '
        Me.colMonto.Text = "Monto"
        '
        'colEstado
        '
        Me.colEstado.Text = "Estado"
        '
        'colNroCuenta
        '
        Me.colNroCuenta.Text = "Nro. Cuenta"
        '
        'colNroCheque
        '
        Me.colNroCheque.Text = "Nro. Cheque"
        '
        'cmbCtasVisual
        '
        Me.cmbCtasVisual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCtasVisual.FormattingEnabled = True
        Me.cmbCtasVisual.Location = New System.Drawing.Point(121, 61)
        Me.cmbCtasVisual.Name = "cmbCtasVisual"
        Me.cmbCtasVisual.Size = New System.Drawing.Size(220, 21)
        Me.cmbCtasVisual.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "&Cuenta Visual:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(168, 326)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 14
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(249, 326)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 15
        Me.btnModificar.Text = "M&odificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(330, 326)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 16
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(411, 326)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtNroDeposito
        '
        Me.txtNroDeposito.Location = New System.Drawing.Point(121, 121)
        Me.txtNroDeposito.MaxLength = 20
        Me.txtNroDeposito.Name = "txtNroDeposito"
        Me.txtNroDeposito.Size = New System.Drawing.Size(136, 20)
        Me.txtNroDeposito.TabIndex = 9
        Me.txtNroDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(121, 150)
        Me.txtMonto.MaxLength = 12
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(103, 20)
        Me.txtMonto.TabIndex = 11
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmDepositos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 355)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cmbCtasVisual)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lvwDepositos)
        Me.Controls.Add(Me.pnlCheque)
        Me.Controls.Add(Me.cmbTipoDeposito)
        Me.Controls.Add(Me.cmbBancosVzla)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNroDeposito)
        Me.Controls.Add(Me.txtMonto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDepositos"
        Me.Text = "Depósito Bancario"
        Me.pnlCheque.ResumeLayout(False)
        Me.pnlCheque.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbBancosVzla As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents pnlCheque As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lvwDepositos As System.Windows.Forms.ListView
    Friend WithEvents cmbCtasVisual As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents colFecha As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colBanco As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumero As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMonto As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNroCheque As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNroCuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtNroDeposito As System.Windows.Forms.TextBox
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents txtChequeCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
End Class
