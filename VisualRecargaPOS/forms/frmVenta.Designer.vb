<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVenta
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
        Me.grpInicio = New System.Windows.Forms.GroupBox()
        Me.lblTranPend = New System.Windows.Forms.Label()
        Me.btnVentaIniciar = New System.Windows.Forms.Button()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.lblMsgLimites = New System.Windows.Forms.Label()
        Me.pnlBotonesDatos = New System.Windows.Forms.Panel()
        Me.btnDatosAceptar = New System.Windows.Forms.Button()
        Me.btnDatosRegresar = New System.Windows.Forms.Button()
        Me.cmbOperadora = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblPrefijo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnVentaSalir = New System.Windows.Forms.Button()
        Me.lblUltTrans = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpVerificar = New System.Windows.Forms.GroupBox()
        Me.pnlBotonesVerificar = New System.Windows.Forms.Panel()
        Me.btnVerificarRegresar = New System.Windows.Forms.Button()
        Me.btnVerificarAceptar = New System.Windows.Forms.Button()
        Me.lblVerificarNumero = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblVerificarCedula = New System.Windows.Forms.Label()
        Me.lblTitCedula = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblProcesando = New System.Windows.Forms.Label()
        Me.tmrBlink = New System.Windows.Forms.Timer(Me.components)
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.lblTitSaldo = New System.Windows.Forms.Label()
        Me.grpInicio.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatos.SuspendLayout()
        Me.pnlBotonesDatos.SuspendLayout()
        Me.grpVerificar.SuspendLayout()
        Me.pnlBotonesVerificar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInicio
        '
        Me.grpInicio.Controls.Add(Me.lblTranPend)
        Me.grpInicio.Controls.Add(Me.btnVentaIniciar)
        Me.grpInicio.Location = New System.Drawing.Point(1, 86)
        Me.grpInicio.Name = "grpInicio"
        Me.grpInicio.Size = New System.Drawing.Size(698, 325)
        Me.grpInicio.TabIndex = 0
        Me.grpInicio.TabStop = False
        '
        'lblTranPend
        '
        Me.lblTranPend.AutoSize = True
        Me.lblTranPend.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTranPend.Location = New System.Drawing.Point(67, 249)
        Me.lblTranPend.Name = "lblTranPend"
        Me.lblTranPend.Size = New System.Drawing.Size(564, 24)
        Me.lblTranPend.TabIndex = 1
        Me.lblTranPend.Text = "Verificando Transacción Pendiente .... Espere un momento"
        Me.lblTranPend.Visible = False
        '
        'btnVentaIniciar
        '
        Me.btnVentaIniciar.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVentaIniciar.Location = New System.Drawing.Point(165, 73)
        Me.btnVentaIniciar.Name = "btnVentaIniciar"
        Me.btnVentaIniciar.Size = New System.Drawing.Size(369, 114)
        Me.btnVentaIniciar.TabIndex = 0
        Me.btnVentaIniciar.Text = "&Iniciar Venta"
        Me.btnVentaIniciar.UseVisualStyleBackColor = True
        '
        'picLogo
        '
        Me.picLogo.Location = New System.Drawing.Point(0, 2)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(230, 50)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picLogo.TabIndex = 1
        Me.picLogo.TabStop = False
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.lblMsgLimites)
        Me.grpDatos.Controls.Add(Me.pnlBotonesDatos)
        Me.grpDatos.Controls.Add(Me.cmbOperadora)
        Me.grpDatos.Controls.Add(Me.Label7)
        Me.grpDatos.Controls.Add(Me.lblAyuda)
        Me.grpDatos.Controls.Add(Me.txtMonto)
        Me.grpDatos.Controls.Add(Me.txtNumero)
        Me.grpDatos.Controls.Add(Me.lblPrefijo)
        Me.grpDatos.Controls.Add(Me.Label5)
        Me.grpDatos.Controls.Add(Me.Label4)
        Me.grpDatos.Controls.Add(Me.lblCodigo)
        Me.grpDatos.Controls.Add(Me.txtCedula)
        Me.grpDatos.Controls.Add(Me.lblCedula)
        Me.grpDatos.Controls.Add(Me.Label2)
        Me.grpDatos.Location = New System.Drawing.Point(1, 86)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(698, 325)
        Me.grpDatos.TabIndex = 1
        Me.grpDatos.TabStop = False
        Me.grpDatos.Visible = False
        '
        'lblMsgLimites
        '
        Me.lblMsgLimites.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgLimites.Location = New System.Drawing.Point(473, 201)
        Me.lblMsgLimites.Name = "lblMsgLimites"
        Me.lblMsgLimites.Size = New System.Drawing.Size(219, 59)
        Me.lblMsgLimites.TabIndex = 15
        Me.lblMsgLimites.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'pnlBotonesDatos
        '
        Me.pnlBotonesDatos.Controls.Add(Me.btnDatosAceptar)
        Me.pnlBotonesDatos.Controls.Add(Me.btnDatosRegresar)
        Me.pnlBotonesDatos.Location = New System.Drawing.Point(449, 266)
        Me.pnlBotonesDatos.Name = "pnlBotonesDatos"
        Me.pnlBotonesDatos.Size = New System.Drawing.Size(249, 59)
        Me.pnlBotonesDatos.TabIndex = 14
        '
        'btnDatosAceptar
        '
        Me.btnDatosAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatosAceptar.Location = New System.Drawing.Point(11, 10)
        Me.btnDatosAceptar.Name = "btnDatosAceptar"
        Me.btnDatosAceptar.Size = New System.Drawing.Size(110, 38)
        Me.btnDatosAceptar.TabIndex = 12
        Me.btnDatosAceptar.Text = "&Aceptar"
        Me.btnDatosAceptar.UseVisualStyleBackColor = True
        '
        'btnDatosRegresar
        '
        Me.btnDatosRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDatosRegresar.Location = New System.Drawing.Point(128, 10)
        Me.btnDatosRegresar.Name = "btnDatosRegresar"
        Me.btnDatosRegresar.Size = New System.Drawing.Size(110, 38)
        Me.btnDatosRegresar.TabIndex = 13
        Me.btnDatosRegresar.Text = "&Regresar"
        Me.btnDatosRegresar.UseVisualStyleBackColor = True
        '
        'cmbOperadora
        '
        Me.cmbOperadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperadora.FormattingEnabled = True
        Me.cmbOperadora.Location = New System.Drawing.Point(325, 54)
        Me.cmbOperadora.Name = "cmbOperadora"
        Me.cmbOperadora.Size = New System.Drawing.Size(279, 32)
        Me.cmbOperadora.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(95, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(223, 32)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "&Operadora:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAyuda
        '
        Me.lblAyuda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAyuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAyuda.Location = New System.Drawing.Point(473, 89)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(131, 112)
        Me.lblAyuda.TabIndex = 11
        Me.lblAyuda.Text = "Para cambiar el prefijo de la operadora presione F4"
        Me.lblAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAyuda.UseMnemonic = False
        Me.lblAyuda.Visible = False
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(325, 232)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(142, 29)
        Me.txtMonto.TabIndex = 10
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(325, 195)
        Me.txtNumero.MaxLength = 7
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(142, 29)
        Me.txtNumero.TabIndex = 8
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrefijo
        '
        Me.lblPrefijo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPrefijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrefijo.Location = New System.Drawing.Point(325, 129)
        Me.lblPrefijo.Name = "lblPrefijo"
        Me.lblPrefijo.Size = New System.Drawing.Size(142, 58)
        Me.lblPrefijo.TabIndex = 6
        Me.lblPrefijo.Text = "0416"
        Me.lblPrefijo.UseMnemonic = False
        Me.lblPrefijo.Visible = False
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(95, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(223, 32)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "&Monto a Recargar:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(95, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(223, 32)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "&Nro. Teléfono o Tarjeta:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodigo
        '
        Me.lblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(95, 129)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(223, 32)
        Me.lblCodigo.TabIndex = 5
        Me.lblCodigo.Text = "Código:"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCodigo.Visible = False
        '
        'txtCedula
        '
        Me.txtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCedula.Location = New System.Drawing.Point(325, 91)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(142, 29)
        Me.txtCedula.TabIndex = 4
        Me.txtCedula.Text = "0"
        Me.txtCedula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCedula.Visible = False
        '
        'lblCedula
        '
        Me.lblCedula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCedula.Location = New System.Drawing.Point(95, 91)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(223, 32)
        Me.lblCedula.TabIndex = 3
        Me.lblCedula.Text = "&Cédula:"
        Me.lblCedula.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCedula.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(82, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(535, 37)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Introduzca los datos de la recarga"
        '
        'btnVentaSalir
        '
        Me.btnVentaSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVentaSalir.Location = New System.Drawing.Point(578, 414)
        Me.btnVentaSalir.Name = "btnVentaSalir"
        Me.btnVentaSalir.Size = New System.Drawing.Size(110, 38)
        Me.btnVentaSalir.TabIndex = 3
        Me.btnVentaSalir.Text = "&Salir"
        Me.btnVentaSalir.UseVisualStyleBackColor = True
        '
        'lblUltTrans
        '
        Me.lblUltTrans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUltTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltTrans.Location = New System.Drawing.Point(159, 428)
        Me.lblUltTrans.Name = "lblUltTrans"
        Me.lblUltTrans.Size = New System.Drawing.Size(134, 24)
        Me.lblUltTrans.TabIndex = 2
        Me.lblUltTrans.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblUltTrans.UseMnemonic = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 428)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Última Trans.#"
        '
        'grpVerificar
        '
        Me.grpVerificar.Controls.Add(Me.pnlBotonesVerificar)
        Me.grpVerificar.Controls.Add(Me.lblVerificarNumero)
        Me.grpVerificar.Controls.Add(Me.Label3)
        Me.grpVerificar.Controls.Add(Me.lblVerificarCedula)
        Me.grpVerificar.Controls.Add(Me.lblTitCedula)
        Me.grpVerificar.Controls.Add(Me.GroupBox1)
        Me.grpVerificar.Controls.Add(Me.Label8)
        Me.grpVerificar.Controls.Add(Me.lblProcesando)
        Me.grpVerificar.Location = New System.Drawing.Point(1, 86)
        Me.grpVerificar.Name = "grpVerificar"
        Me.grpVerificar.Size = New System.Drawing.Size(698, 325)
        Me.grpVerificar.TabIndex = 4
        Me.grpVerificar.TabStop = False
        Me.grpVerificar.Visible = False
        '
        'pnlBotonesVerificar
        '
        Me.pnlBotonesVerificar.Controls.Add(Me.btnVerificarRegresar)
        Me.pnlBotonesVerificar.Controls.Add(Me.btnVerificarAceptar)
        Me.pnlBotonesVerificar.Location = New System.Drawing.Point(449, 266)
        Me.pnlBotonesVerificar.Name = "pnlBotonesVerificar"
        Me.pnlBotonesVerificar.Size = New System.Drawing.Size(249, 59)
        Me.pnlBotonesVerificar.TabIndex = 14
        '
        'btnVerificarRegresar
        '
        Me.btnVerificarRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerificarRegresar.Location = New System.Drawing.Point(128, 10)
        Me.btnVerificarRegresar.Name = "btnVerificarRegresar"
        Me.btnVerificarRegresar.Size = New System.Drawing.Size(110, 38)
        Me.btnVerificarRegresar.TabIndex = 1
        Me.btnVerificarRegresar.Text = "&Regresar"
        Me.btnVerificarRegresar.UseVisualStyleBackColor = True
        '
        'btnVerificarAceptar
        '
        Me.btnVerificarAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerificarAceptar.Location = New System.Drawing.Point(11, 10)
        Me.btnVerificarAceptar.Name = "btnVerificarAceptar"
        Me.btnVerificarAceptar.Size = New System.Drawing.Size(110, 38)
        Me.btnVerificarAceptar.TabIndex = 0
        Me.btnVerificarAceptar.Text = "&Aceptar"
        Me.btnVerificarAceptar.UseVisualStyleBackColor = True
        '
        'lblVerificarNumero
        '
        Me.lblVerificarNumero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVerificarNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerificarNumero.Location = New System.Drawing.Point(229, 213)
        Me.lblVerificarNumero.Name = "lblVerificarNumero"
        Me.lblVerificarNumero.Size = New System.Drawing.Size(363, 37)
        Me.lblVerificarNumero.TabIndex = 13
        Me.lblVerificarNumero.Text = "0424 1703249"
        Me.lblVerificarNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(108, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 37)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Número :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVerificarCedula
        '
        Me.lblVerificarCedula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVerificarCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerificarCedula.Location = New System.Drawing.Point(229, 172)
        Me.lblVerificarCedula.Name = "lblVerificarCedula"
        Me.lblVerificarCedula.Size = New System.Drawing.Size(363, 37)
        Me.lblVerificarCedula.TabIndex = 11
        Me.lblVerificarCedula.Text = "99.999.999"
        Me.lblVerificarCedula.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblVerificarCedula.Visible = False
        '
        'lblTitCedula
        '
        Me.lblTitCedula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCedula.Location = New System.Drawing.Point(108, 172)
        Me.lblTitCedula.Name = "lblTitCedula"
        Me.lblTitCedula.Size = New System.Drawing.Size(111, 37)
        Me.lblTitCedula.TabIndex = 10
        Me.lblTitCedula.Text = "Cédula :"
        Me.lblTitCedula.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTitCedula.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblPrecio)
        Me.GroupBox1.Controls.Add(Me.lblProducto)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(66, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(566, 120)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recarga de saldo"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(137, 76)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(183, 29)
        Me.lblPrecio.TabIndex = 2
        Me.lblPrecio.Text = "Bs. 100.000,00"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(137, 25)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(274, 29)
        Me.lblProducto.TabIndex = 1
        Me.lblProducto.Text = "RECARGA MOVISTAR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(98, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(505, 29)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Verifique con el cliente los datos de compra ..."
        '
        'lblProcesando
        '
        Me.lblProcesando.AutoSize = True
        Me.lblProcesando.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcesando.ForeColor = System.Drawing.Color.Red
        Me.lblProcesando.Location = New System.Drawing.Point(263, 257)
        Me.lblProcesando.Name = "lblProcesando"
        Me.lblProcesando.Size = New System.Drawing.Size(174, 29)
        Me.lblProcesando.TabIndex = 15
        Me.lblProcesando.Text = "Procesando..."
        Me.lblProcesando.Visible = False
        '
        'tmrBlink
        '
        Me.tmrBlink.Interval = 500
        '
        'lblSaldo
        '
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(392, 428)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(134, 24)
        Me.lblSaldo.TabIndex = 6
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSaldo.UseMnemonic = False
        '
        'lblTitSaldo
        '
        Me.lblTitSaldo.AutoSize = True
        Me.lblTitSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitSaldo.Location = New System.Drawing.Point(325, 428)
        Me.lblTitSaldo.Name = "lblTitSaldo"
        Me.lblTitSaldo.Size = New System.Drawing.Size(63, 24)
        Me.lblTitSaldo.TabIndex = 5
        Me.lblTitSaldo.Text = "Saldo"
        '
        'frmVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 454)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.lblTitSaldo)
        Me.Controls.Add(Me.btnVentaSalir)
        Me.Controls.Add(Me.lblUltTrans)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.grpVerificar)
        Me.Controls.Add(Me.grpInicio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVenta"
        Me.grpInicio.ResumeLayout(False)
        Me.grpInicio.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.pnlBotonesDatos.ResumeLayout(False)
        Me.grpVerificar.ResumeLayout(False)
        Me.grpVerificar.PerformLayout()
        Me.pnlBotonesVerificar.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpInicio As System.Windows.Forms.GroupBox
    Friend WithEvents lblTranPend As System.Windows.Forms.Label
    Friend WithEvents btnVentaIniciar As System.Windows.Forms.Button
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents btnDatosRegresar As System.Windows.Forms.Button
    Friend WithEvents btnDatosAceptar As System.Windows.Forms.Button
    Friend WithEvents lblAyuda As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lblPrefijo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbOperadora As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnVentaSalir As System.Windows.Forms.Button
    Friend WithEvents lblUltTrans As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpVerificar As System.Windows.Forms.GroupBox
    Friend WithEvents pnlBotonesVerificar As System.Windows.Forms.Panel
    Friend WithEvents btnVerificarRegresar As System.Windows.Forms.Button
    Friend WithEvents btnVerificarAceptar As System.Windows.Forms.Button
    Friend WithEvents lblVerificarNumero As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVerificarCedula As System.Windows.Forms.Label
    Friend WithEvents lblTitCedula As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblProcesando As System.Windows.Forms.Label
    Friend WithEvents pnlBotonesDatos As System.Windows.Forms.Panel
    Friend WithEvents tmrBlink As System.Windows.Forms.Timer
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents lblTitSaldo As System.Windows.Forms.Label
    Friend WithEvents lblMsgLimites As System.Windows.Forms.Label
End Class
