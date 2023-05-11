<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmParamReg
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public WithEvents LBNroTaquilla As System.Windows.Forms.Label
    Public WithEvents LBVendedor As System.Windows.Forms.Label
    Public WithEvents _Label1_11 As System.Windows.Forms.Label
    Public WithEvents _Label1_7 As System.Windows.Forms.Label
    Public WithEvents _Label1_6 As System.Windows.Forms.Label
    Public WithEvents LBSerialReg As System.Windows.Forms.Label
    Public WithEvents _Label1_5 As System.Windows.Forms.Label
    Public WithEvents LBNombrePCReg As System.Windows.Forms.Label
    Public WithEvents FrRegLocal As System.Windows.Forms.GroupBox
    Public WithEvents BTVerificar As System.Windows.Forms.Button
    Public WithEvents BTSalir As System.Windows.Forms.Button
    Public WithEvents BTEnvSerial As System.Windows.Forms.Button
    Public WithEvents INNroTaquilla As System.Windows.Forms.TextBox
    Public WithEvents INVendedor As System.Windows.Forms.TextBox
    Public WithEvents LBNombrePCAct As System.Windows.Forms.Label
    Public WithEvents _Label1_2 As System.Windows.Forms.Label
    Public WithEvents LBSerialAReg As System.Windows.Forms.Label
    Public WithEvents _Label1_1 As System.Windows.Forms.Label
    Public WithEvents _Label1_10 As System.Windows.Forms.Label
    Public WithEvents _Label1_0 As System.Windows.Forms.Label
    Public WithEvents FrReg As System.Windows.Forms.GroupBox
    Public WithEvents CBVersion As System.Windows.Forms.ComboBox
    Public WithEvents INServidor As System.Windows.Forms.TextBox
    Public WithEvents INBaseDatos As System.Windows.Forms.TextBox
    Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
    Public WithEvents _Label1_8 As System.Windows.Forms.Label
    Public WithEvents _Label1_9 As System.Windows.Forms.Label
    Public WithEvents frmConexion As System.Windows.Forms.GroupBox
    Public WithEvents _Label1_3 As System.Windows.Forms.Label
    Public WithEvents LBNomVendedor As System.Windows.Forms.Label
    Public WithEvents TitVerificado As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParamReg))
        Me.FrRegLocal = New System.Windows.Forms.GroupBox()
        Me.LBNroTaquilla = New System.Windows.Forms.Label()
        Me.LBVendedor = New System.Windows.Forms.Label()
        Me._Label1_11 = New System.Windows.Forms.Label()
        Me._Label1_7 = New System.Windows.Forms.Label()
        Me._Label1_6 = New System.Windows.Forms.Label()
        Me.LBSerialReg = New System.Windows.Forms.Label()
        Me._Label1_5 = New System.Windows.Forms.Label()
        Me.LBNombrePCReg = New System.Windows.Forms.Label()
        Me.BTVerificar = New System.Windows.Forms.Button()
        Me.BTSalir = New System.Windows.Forms.Button()
        Me.FrReg = New System.Windows.Forms.GroupBox()
        Me.BTEnvSerial = New System.Windows.Forms.Button()
        Me.INNroTaquilla = New System.Windows.Forms.TextBox()
        Me.INVendedor = New System.Windows.Forms.TextBox()
        Me.LBNombrePCAct = New System.Windows.Forms.Label()
        Me._Label1_2 = New System.Windows.Forms.Label()
        Me.LBSerialAReg = New System.Windows.Forms.Label()
        Me._Label1_1 = New System.Windows.Forms.Label()
        Me._Label1_10 = New System.Windows.Forms.Label()
        Me._Label1_0 = New System.Windows.Forms.Label()
        Me.frmConexion = New System.Windows.Forms.GroupBox()
        Me.CBVersion = New System.Windows.Forms.ComboBox()
        Me.INServidor = New System.Windows.Forms.TextBox()
        Me.INBaseDatos = New System.Windows.Forms.TextBox()
        Me._lblLabels_3 = New System.Windows.Forms.Label()
        Me._Label1_8 = New System.Windows.Forms.Label()
        Me._Label1_9 = New System.Windows.Forms.Label()
        Me._Label1_3 = New System.Windows.Forms.Label()
        Me.LBNomVendedor = New System.Windows.Forms.Label()
        Me.TitVerificado = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FrRegLocal.SuspendLayout()
        Me.FrReg.SuspendLayout()
        Me.frmConexion.SuspendLayout()
        Me.SuspendLayout()
        '
        'FrRegLocal
        '
        Me.FrRegLocal.BackColor = System.Drawing.SystemColors.Control
        Me.FrRegLocal.Controls.Add(Me.LBNroTaquilla)
        Me.FrRegLocal.Controls.Add(Me.LBVendedor)
        Me.FrRegLocal.Controls.Add(Me._Label1_11)
        Me.FrRegLocal.Controls.Add(Me._Label1_7)
        Me.FrRegLocal.Controls.Add(Me._Label1_6)
        Me.FrRegLocal.Controls.Add(Me.LBSerialReg)
        Me.FrRegLocal.Controls.Add(Me._Label1_5)
        Me.FrRegLocal.Controls.Add(Me.LBNombrePCReg)
        Me.FrRegLocal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FrRegLocal.Location = New System.Drawing.Point(391, 103)
        Me.FrRegLocal.Name = "FrRegLocal"
        Me.FrRegLocal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrRegLocal.Size = New System.Drawing.Size(379, 145)
        Me.FrRegLocal.TabIndex = 4
        Me.FrRegLocal.TabStop = False
        Me.FrRegLocal.Text = "Registro Local Actual"
        '
        'LBNroTaquilla
        '
        Me.LBNroTaquilla.BackColor = System.Drawing.SystemColors.Control
        Me.LBNroTaquilla.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBNroTaquilla.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBNroTaquilla.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBNroTaquilla.Location = New System.Drawing.Point(100, 49)
        Me.LBNroTaquilla.Name = "LBNroTaquilla"
        Me.LBNroTaquilla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LBNroTaquilla.Size = New System.Drawing.Size(31, 21)
        Me.LBNroTaquilla.TabIndex = 3
        Me.LBNroTaquilla.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBVendedor
        '
        Me.LBVendedor.BackColor = System.Drawing.SystemColors.Control
        Me.LBVendedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBVendedor.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBVendedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBVendedor.Location = New System.Drawing.Point(100, 17)
        Me.LBVendedor.Name = "LBVendedor"
        Me.LBVendedor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LBVendedor.Size = New System.Drawing.Size(76, 20)
        Me.LBVendedor.TabIndex = 1
        Me.LBVendedor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_Label1_11
        '
        Me._Label1_11.AutoSize = True
        Me._Label1_11.BackColor = System.Drawing.Color.Transparent
        Me._Label1_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_11.Location = New System.Drawing.Point(12, 21)
        Me._Label1_11.Name = "_Label1_11"
        Me._Label1_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_11.Size = New System.Drawing.Size(81, 13)
        Me._Label1_11.TabIndex = 0
        Me._Label1_11.Text = "Cod. Vendedor:"
        '
        '_Label1_7
        '
        Me._Label1_7.BackColor = System.Drawing.Color.Transparent
        Me._Label1_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_7.Location = New System.Drawing.Point(12, 53)
        Me._Label1_7.Name = "_Label1_7"
        Me._Label1_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_7.Size = New System.Drawing.Size(81, 13)
        Me._Label1_7.TabIndex = 2
        Me._Label1_7.Text = "Nro. Estación:"
        '
        '_Label1_6
        '
        Me._Label1_6.AutoSize = True
        Me._Label1_6.BackColor = System.Drawing.Color.Transparent
        Me._Label1_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_6.Location = New System.Drawing.Point(12, 85)
        Me._Label1_6.Name = "_Label1_6"
        Me._Label1_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_6.Size = New System.Drawing.Size(36, 13)
        Me._Label1_6.TabIndex = 4
        Me._Label1_6.Text = "Serial:"
        '
        'LBSerialReg
        '
        Me.LBSerialReg.BackColor = System.Drawing.SystemColors.Control
        Me.LBSerialReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBSerialReg.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBSerialReg.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBSerialReg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBSerialReg.Location = New System.Drawing.Point(88, 81)
        Me.LBSerialReg.Name = "LBSerialReg"
        Me.LBSerialReg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LBSerialReg.Size = New System.Drawing.Size(280, 21)
        Me.LBSerialReg.TabIndex = 5
        Me.LBSerialReg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_Label1_5
        '
        Me._Label1_5.AutoSize = True
        Me._Label1_5.BackColor = System.Drawing.Color.Transparent
        Me._Label1_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_5.Location = New System.Drawing.Point(12, 112)
        Me._Label1_5.Name = "_Label1_5"
        Me._Label1_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_5.Size = New System.Drawing.Size(64, 13)
        Me._Label1_5.TabIndex = 6
        Me._Label1_5.Text = "Nombre PC:"
        '
        'LBNombrePCReg
        '
        Me.LBNombrePCReg.BackColor = System.Drawing.SystemColors.Control
        Me.LBNombrePCReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBNombrePCReg.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBNombrePCReg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBNombrePCReg.Location = New System.Drawing.Point(88, 112)
        Me.LBNombrePCReg.Name = "LBNombrePCReg"
        Me.LBNombrePCReg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LBNombrePCReg.Size = New System.Drawing.Size(280, 21)
        Me.LBNombrePCReg.TabIndex = 7
        '
        'BTVerificar
        '
        Me.BTVerificar.BackColor = System.Drawing.SystemColors.Control
        Me.BTVerificar.CausesValidation = False
        Me.BTVerificar.Cursor = System.Windows.Forms.Cursors.Default
        Me.BTVerificar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BTVerificar.Location = New System.Drawing.Point(301, 256)
        Me.BTVerificar.Name = "BTVerificar"
        Me.BTVerificar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BTVerificar.Size = New System.Drawing.Size(83, 25)
        Me.BTVerificar.TabIndex = 6
        Me.BTVerificar.Text = "V&erificar"
        Me.BTVerificar.UseVisualStyleBackColor = False
        '
        'BTSalir
        '
        Me.BTSalir.BackColor = System.Drawing.SystemColors.Control
        Me.BTSalir.CausesValidation = False
        Me.BTSalir.Cursor = System.Windows.Forms.Cursors.Default
        Me.BTSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTSalir.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BTSalir.Location = New System.Drawing.Point(393, 256)
        Me.BTSalir.Name = "BTSalir"
        Me.BTSalir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BTSalir.Size = New System.Drawing.Size(83, 25)
        Me.BTSalir.TabIndex = 7
        Me.BTSalir.Text = "S&alir"
        Me.BTSalir.UseVisualStyleBackColor = False
        '
        'FrReg
        '
        Me.FrReg.BackColor = System.Drawing.SystemColors.Control
        Me.FrReg.Controls.Add(Me.BTEnvSerial)
        Me.FrReg.Controls.Add(Me.INNroTaquilla)
        Me.FrReg.Controls.Add(Me.INVendedor)
        Me.FrReg.Controls.Add(Me.LBNombrePCAct)
        Me.FrReg.Controls.Add(Me._Label1_2)
        Me.FrReg.Controls.Add(Me.LBSerialAReg)
        Me.FrReg.Controls.Add(Me._Label1_1)
        Me.FrReg.Controls.Add(Me._Label1_10)
        Me.FrReg.Controls.Add(Me._Label1_0)
        Me.FrReg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FrReg.Location = New System.Drawing.Point(6, 103)
        Me.FrReg.Name = "FrReg"
        Me.FrReg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrReg.Size = New System.Drawing.Size(379, 145)
        Me.FrReg.TabIndex = 3
        Me.FrReg.TabStop = False
        Me.FrReg.Text = "Registro a Realizar"
        '
        'BTEnvSerial
        '
        Me.BTEnvSerial.BackColor = System.Drawing.SystemColors.Control
        Me.BTEnvSerial.CausesValidation = False
        Me.BTEnvSerial.Cursor = System.Windows.Forms.Cursors.Default
        Me.BTEnvSerial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BTEnvSerial.Location = New System.Drawing.Point(142, 47)
        Me.BTEnvSerial.Name = "BTEnvSerial"
        Me.BTEnvSerial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BTEnvSerial.Size = New System.Drawing.Size(83, 25)
        Me.BTEnvSerial.TabIndex = 8
        Me.BTEnvSerial.Text = "En&viar Serial"
        Me.BTEnvSerial.UseVisualStyleBackColor = False
        Me.BTEnvSerial.Visible = False
        '
        'INNroTaquilla
        '
        Me.INNroTaquilla.AcceptsReturn = True
        Me.INNroTaquilla.BackColor = System.Drawing.SystemColors.Window
        Me.INNroTaquilla.CausesValidation = False
        Me.INNroTaquilla.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.INNroTaquilla.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INNroTaquilla.Location = New System.Drawing.Point(97, 49)
        Me.INNroTaquilla.MaxLength = 2
        Me.INNroTaquilla.Name = "INNroTaquilla"
        Me.INNroTaquilla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INNroTaquilla.Size = New System.Drawing.Size(31, 20)
        Me.INNroTaquilla.TabIndex = 3
        Me.INNroTaquilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'INVendedor
        '
        Me.INVendedor.AcceptsReturn = True
        Me.INVendedor.BackColor = System.Drawing.SystemColors.Window
        Me.INVendedor.CausesValidation = False
        Me.INVendedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.INVendedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INVendedor.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.INVendedor.Location = New System.Drawing.Point(97, 17)
        Me.INVendedor.MaxLength = 5
        Me.INVendedor.Name = "INVendedor"
        Me.INVendedor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INVendedor.Size = New System.Drawing.Size(76, 20)
        Me.INVendedor.TabIndex = 1
        '
        'LBNombrePCAct
        '
        Me.LBNombrePCAct.BackColor = System.Drawing.SystemColors.Control
        Me.LBNombrePCAct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBNombrePCAct.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBNombrePCAct.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBNombrePCAct.Location = New System.Drawing.Point(88, 112)
        Me.LBNombrePCAct.Name = "LBNombrePCAct"
        Me.LBNombrePCAct.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LBNombrePCAct.Size = New System.Drawing.Size(280, 21)
        Me.LBNombrePCAct.TabIndex = 7
        '
        '_Label1_2
        '
        Me._Label1_2.AutoSize = True
        Me._Label1_2.BackColor = System.Drawing.Color.Transparent
        Me._Label1_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_2.Location = New System.Drawing.Point(12, 112)
        Me._Label1_2.Name = "_Label1_2"
        Me._Label1_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_2.Size = New System.Drawing.Size(64, 13)
        Me._Label1_2.TabIndex = 6
        Me._Label1_2.Text = "Nombre PC:"
        '
        'LBSerialAReg
        '
        Me.LBSerialAReg.BackColor = System.Drawing.SystemColors.Control
        Me.LBSerialAReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBSerialAReg.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBSerialAReg.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBSerialAReg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBSerialAReg.Location = New System.Drawing.Point(88, 81)
        Me.LBSerialAReg.Name = "LBSerialAReg"
        Me.LBSerialAReg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LBSerialAReg.Size = New System.Drawing.Size(280, 21)
        Me.LBSerialAReg.TabIndex = 5
        '
        '_Label1_1
        '
        Me._Label1_1.AutoSize = True
        Me._Label1_1.BackColor = System.Drawing.Color.Transparent
        Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_1.Location = New System.Drawing.Point(12, 85)
        Me._Label1_1.Name = "_Label1_1"
        Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_1.Size = New System.Drawing.Size(36, 13)
        Me._Label1_1.TabIndex = 4
        Me._Label1_1.Text = "Serial:"
        '
        '_Label1_10
        '
        Me._Label1_10.BackColor = System.Drawing.Color.Transparent
        Me._Label1_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_10.Location = New System.Drawing.Point(12, 53)
        Me._Label1_10.Name = "_Label1_10"
        Me._Label1_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_10.Size = New System.Drawing.Size(79, 13)
        Me._Label1_10.TabIndex = 2
        Me._Label1_10.Text = "&Nro. Estación:"
        '
        '_Label1_0
        '
        Me._Label1_0.AutoSize = True
        Me._Label1_0.BackColor = System.Drawing.Color.Transparent
        Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_0.Location = New System.Drawing.Point(12, 21)
        Me._Label1_0.Name = "_Label1_0"
        Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_0.Size = New System.Drawing.Size(81, 13)
        Me._Label1_0.TabIndex = 0
        Me._Label1_0.Text = "&Cod. Vendedor:"
        '
        'frmConexion
        '
        Me.frmConexion.BackColor = System.Drawing.SystemColors.Control
        Me.frmConexion.Controls.Add(Me.CBVersion)
        Me.frmConexion.Controls.Add(Me.INServidor)
        Me.frmConexion.Controls.Add(Me.INBaseDatos)
        Me.frmConexion.Controls.Add(Me._lblLabels_3)
        Me.frmConexion.Controls.Add(Me._Label1_8)
        Me.frmConexion.Controls.Add(Me._Label1_9)
        Me.frmConexion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmConexion.Location = New System.Drawing.Point(12, 16)
        Me.frmConexion.Name = "frmConexion"
        Me.frmConexion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmConexion.Size = New System.Drawing.Size(562, 50)
        Me.frmConexion.TabIndex = 0
        Me.frmConexion.TabStop = False
        Me.frmConexion.Text = "Conexión"
        '
        'CBVersion
        '
        Me.CBVersion.BackColor = System.Drawing.SystemColors.Window
        Me.CBVersion.CausesValidation = False
        Me.CBVersion.Cursor = System.Windows.Forms.Cursors.Default
        Me.CBVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBVersion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CBVersion.Items.AddRange(New Object() {"Web", "Wireless", "USBModem", "Chip (CEL)"})
        Me.CBVersion.Location = New System.Drawing.Point(447, 17)
        Me.CBVersion.Name = "CBVersion"
        Me.CBVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CBVersion.Size = New System.Drawing.Size(107, 21)
        Me.CBVersion.TabIndex = 5
        '
        'INServidor
        '
        Me.INServidor.AcceptsReturn = True
        Me.INServidor.BackColor = System.Drawing.SystemColors.Window
        Me.INServidor.CausesValidation = False
        Me.INServidor.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.INServidor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.INServidor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INServidor.Location = New System.Drawing.Point(63, 17)
        Me.INServidor.MaxLength = 150
        Me.INServidor.Name = "INServidor"
        Me.INServidor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INServidor.Size = New System.Drawing.Size(186, 20)
        Me.INServidor.TabIndex = 1
        '
        'INBaseDatos
        '
        Me.INBaseDatos.AcceptsReturn = True
        Me.INBaseDatos.BackColor = System.Drawing.SystemColors.Window
        Me.INBaseDatos.CausesValidation = False
        Me.INBaseDatos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.INBaseDatos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.INBaseDatos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.INBaseDatos.Location = New System.Drawing.Point(296, 17)
        Me.INBaseDatos.MaxLength = 20
        Me.INBaseDatos.Name = "INBaseDatos"
        Me.INBaseDatos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.INBaseDatos.Size = New System.Drawing.Size(91, 20)
        Me.INBaseDatos.TabIndex = 3
        '
        '_lblLabels_3
        '
        Me._lblLabels_3.AutoSize = True
        Me._lblLabels_3.BackColor = System.Drawing.Color.Transparent
        Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_3.Location = New System.Drawing.Point(397, 21)
        Me._lblLabels_3.Name = "_lblLabels_3"
        Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_3.Size = New System.Drawing.Size(45, 13)
        Me._lblLabels_3.TabIndex = 4
        Me._lblLabels_3.Text = "&Versión:"
        '
        '_Label1_8
        '
        Me._Label1_8.BackColor = System.Drawing.Color.Transparent
        Me._Label1_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_8.Location = New System.Drawing.Point(6, 21)
        Me._Label1_8.Name = "_Label1_8"
        Me._Label1_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_8.Size = New System.Drawing.Size(49, 13)
        Me._Label1_8.TabIndex = 0
        Me._Label1_8.Text = "&Servidor:"
        '
        '_Label1_9
        '
        Me._Label1_9.AutoSize = True
        Me._Label1_9.BackColor = System.Drawing.Color.Transparent
        Me._Label1_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_9.Location = New System.Drawing.Point(254, 21)
        Me._Label1_9.Name = "_Label1_9"
        Me._Label1_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_9.Size = New System.Drawing.Size(39, 13)
        Me._Label1_9.TabIndex = 2
        Me._Label1_9.Text = "&Grupo:"
        '
        '_Label1_3
        '
        Me._Label1_3.AutoSize = True
        Me._Label1_3.BackColor = System.Drawing.Color.Transparent
        Me._Label1_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._Label1_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Label1_3.Location = New System.Drawing.Point(14, 77)
        Me._Label1_3.Name = "_Label1_3"
        Me._Label1_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Label1_3.Size = New System.Drawing.Size(49, 13)
        Me._Label1_3.TabIndex = 1
        Me._Label1_3.Text = "Agencia:"
        '
        'LBNomVendedor
        '
        Me.LBNomVendedor.BackColor = System.Drawing.SystemColors.Control
        Me.LBNomVendedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LBNomVendedor.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBNomVendedor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBNomVendedor.Location = New System.Drawing.Point(66, 73)
        Me.LBNomVendedor.Name = "LBNomVendedor"
        Me.LBNomVendedor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LBNomVendedor.Size = New System.Drawing.Size(369, 21)
        Me.LBNomVendedor.TabIndex = 2
        '
        'TitVerificado
        '
        Me.TitVerificado.AutoSize = True
        Me.TitVerificado.BackColor = System.Drawing.SystemColors.Control
        Me.TitVerificado.Cursor = System.Windows.Forms.Cursors.Default
        Me.TitVerificado.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitVerificado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TitVerificado.Location = New System.Drawing.Point(12, 253)
        Me.TitVerificado.Name = "TitVerificado"
        Me.TitVerificado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TitVerificado.Size = New System.Drawing.Size(175, 27)
        Me.TitVerificado.TabIndex = 5
        Me.TitVerificado.Text = "Verificación OK"
        Me.TitVerificado.Visible = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblVersion.Location = New System.Drawing.Point(589, 37)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(49, 13)
        Me.lblVersion.TabIndex = 8
        Me.lblVersion.Text = "Versión"
        '
        'txtPassword
        '
        Me.txtPassword.AcceptsReturn = True
        Me.txtPassword.BackColor = System.Drawing.SystemColors.Window
        Me.txtPassword.CausesValidation = False
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPassword.Location = New System.Drawing.Point(657, 73)
        Me.txtPassword.MaxLength = 15
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPassword.Size = New System.Drawing.Size(112, 20)
        Me.txtPassword.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(591, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "C&ontraseña:"
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.SystemColors.Window
        Me.txtUsuario.CausesValidation = False
        Me.txtUsuario.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUsuario.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUsuario.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtUsuario.Location = New System.Drawing.Point(492, 73)
        Me.txtUsuario.MaxLength = 15
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUsuario.Size = New System.Drawing.Size(93, 20)
        Me.txtUsuario.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(441, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "&Usuario:"
        '
        'frmParamReg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.BTSalir
        Me.ClientSize = New System.Drawing.Size(776, 290)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.FrRegLocal)
        Me.Controls.Add(Me.BTVerificar)
        Me.Controls.Add(Me.BTSalir)
        Me.Controls.Add(Me.FrReg)
        Me.Controls.Add(Me.frmConexion)
        Me.Controls.Add(Me._Label1_3)
        Me.Controls.Add(Me.LBNomVendedor)
        Me.Controls.Add(Me.TitVerificado)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 29)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParamReg"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros de Registro de Estación Visual Recarga POS"
        Me.FrRegLocal.ResumeLayout(False)
        Me.FrRegLocal.PerformLayout()
        Me.FrReg.ResumeLayout(False)
        Me.FrReg.PerformLayout()
        Me.frmConexion.ResumeLayout(False)
        Me.frmConexion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtUsuario As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
#End Region
End Class