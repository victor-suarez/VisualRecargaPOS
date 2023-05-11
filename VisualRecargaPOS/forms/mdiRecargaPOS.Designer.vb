<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiRecargaPOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiRecargaPOS))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.mnuVenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeposito = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReportesImprimirUltimoRecibo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReportesVentasPorDia = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReportesTransaccionesDiarias = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuReportesEstadoDeCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConsultas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConsultasTransacciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConsultasTransaccionesEnEspera = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConsultasResumenDeTransacciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfiguracion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfiguracionImpresora = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConfiguracionContraseña = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsCascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsTileVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsTileHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsCloseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuWindowsArrangeIcons = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpContents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpIndex = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.lblInformacion = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrProyecto = New System.Windows.Forms.Timer(Me.components)
        Me.Printer = New System.Drawing.Printing.PrintDocument()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVenta, Me.mnuDeposito, Me.mnuReportes, Me.mnuConsultas, Me.mnuConfiguracion, Me.mnuWindows, Me.mnuAyuda, Me.mnuSalir})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.mnuWindows
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'mnuVenta
        '
        Me.mnuVenta.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.mnuVenta.Name = "mnuVenta"
        Me.mnuVenta.Size = New System.Drawing.Size(48, 20)
        Me.mnuVenta.Text = "&Venta"
        '
        'mnuDeposito
        '
        Me.mnuDeposito.Name = "mnuDeposito"
        Me.mnuDeposito.Size = New System.Drawing.Size(66, 20)
        Me.mnuDeposito.Text = "&Depósito"
        '
        'mnuReportes
        '
        Me.mnuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReportesImprimirUltimoRecibo, Me.mnuReportesVentasPorDia, Me.mnuReportesTransaccionesDiarias, Me.mnuReportesEstadoDeCuenta})
        Me.mnuReportes.Name = "mnuReportes"
        Me.mnuReportes.Size = New System.Drawing.Size(65, 20)
        Me.mnuReportes.Text = "&Reportes"
        '
        'mnuReportesImprimirUltimoRecibo
        '
        Me.mnuReportesImprimirUltimoRecibo.Name = "mnuReportesImprimirUltimoRecibo"
        Me.mnuReportesImprimirUltimoRecibo.Size = New System.Drawing.Size(194, 22)
        Me.mnuReportesImprimirUltimoRecibo.Text = "&Imprimir último recibo"
        '
        'mnuReportesVentasPorDia
        '
        Me.mnuReportesVentasPorDia.Name = "mnuReportesVentasPorDia"
        Me.mnuReportesVentasPorDia.Size = New System.Drawing.Size(194, 22)
        Me.mnuReportesVentasPorDia.Text = "&Ventas por día"
        '
        'mnuReportesTransaccionesDiarias
        '
        Me.mnuReportesTransaccionesDiarias.Name = "mnuReportesTransaccionesDiarias"
        Me.mnuReportesTransaccionesDiarias.Size = New System.Drawing.Size(194, 22)
        Me.mnuReportesTransaccionesDiarias.Text = "&Transacciones diarias"
        '
        'mnuReportesEstadoDeCuenta
        '
        Me.mnuReportesEstadoDeCuenta.Name = "mnuReportesEstadoDeCuenta"
        Me.mnuReportesEstadoDeCuenta.Size = New System.Drawing.Size(194, 22)
        Me.mnuReportesEstadoDeCuenta.Text = "&Estado de cuenta"
        '
        'mnuConsultas
        '
        Me.mnuConsultas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConsultasTransacciones, Me.mnuConsultasTransaccionesEnEspera, Me.mnuConsultasResumenDeTransacciones})
        Me.mnuConsultas.Name = "mnuConsultas"
        Me.mnuConsultas.Size = New System.Drawing.Size(71, 20)
        Me.mnuConsultas.Text = "&Consultas"
        '
        'mnuConsultasTransacciones
        '
        Me.mnuConsultasTransacciones.Name = "mnuConsultasTransacciones"
        Me.mnuConsultasTransacciones.Size = New System.Drawing.Size(214, 22)
        Me.mnuConsultasTransacciones.Text = "&Transacciones"
        '
        'mnuConsultasTransaccionesEnEspera
        '
        Me.mnuConsultasTransaccionesEnEspera.Name = "mnuConsultasTransaccionesEnEspera"
        Me.mnuConsultasTransaccionesEnEspera.Size = New System.Drawing.Size(214, 22)
        Me.mnuConsultasTransaccionesEnEspera.Text = "Transacciones &en espera"
        '
        'mnuConsultasResumenDeTransacciones
        '
        Me.mnuConsultasResumenDeTransacciones.Name = "mnuConsultasResumenDeTransacciones"
        Me.mnuConsultasResumenDeTransacciones.Size = New System.Drawing.Size(214, 22)
        Me.mnuConsultasResumenDeTransacciones.Text = "&Resumen de transacciones"
        '
        'mnuConfiguracion
        '
        Me.mnuConfiguracion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConfiguracionImpresora, Me.mnuConfiguracionContraseña})
        Me.mnuConfiguracion.Name = "mnuConfiguracion"
        Me.mnuConfiguracion.Size = New System.Drawing.Size(95, 20)
        Me.mnuConfiguracion.Text = "Confi&guración"
        '
        'mnuConfiguracionImpresora
        '
        Me.mnuConfiguracionImpresora.Image = Global.VisualRecargaPOS.My.Resources.Resources.PrintHS
        Me.mnuConfiguracionImpresora.Name = "mnuConfiguracionImpresora"
        Me.mnuConfiguracionImpresora.Size = New System.Drawing.Size(134, 22)
        Me.mnuConfiguracionImpresora.Text = "&Impresora"
        '
        'mnuConfiguracionContraseña
        '
        Me.mnuConfiguracionContraseña.Image = Global.VisualRecargaPOS.My.Resources.Resources.PrimaryKeyHS
        Me.mnuConfiguracionContraseña.Name = "mnuConfiguracionContraseña"
        Me.mnuConfiguracionContraseña.Size = New System.Drawing.Size(134, 22)
        Me.mnuConfiguracionContraseña.Text = "C&ontraseña"
        '
        'mnuWindows
        '
        Me.mnuWindows.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWindowsCascade, Me.mnuWindowsTileVertical, Me.mnuWindowsTileHorizontal, Me.mnuWindowsCloseAll, Me.mnuWindowsArrangeIcons})
        Me.mnuWindows.Name = "mnuWindows"
        Me.mnuWindows.Size = New System.Drawing.Size(68, 20)
        Me.mnuWindows.Text = "&Windows"
        '
        'mnuWindowsCascade
        '
        Me.mnuWindowsCascade.Name = "mnuWindowsCascade"
        Me.mnuWindowsCascade.Size = New System.Drawing.Size(150, 22)
        Me.mnuWindowsCascade.Text = "&Cascada"
        '
        'mnuWindowsTileVertical
        '
        Me.mnuWindowsTileVertical.Name = "mnuWindowsTileVertical"
        Me.mnuWindowsTileVertical.Size = New System.Drawing.Size(150, 22)
        Me.mnuWindowsTileVertical.Text = "&Vertical"
        '
        'mnuWindowsTileHorizontal
        '
        Me.mnuWindowsTileHorizontal.Name = "mnuWindowsTileHorizontal"
        Me.mnuWindowsTileHorizontal.Size = New System.Drawing.Size(150, 22)
        Me.mnuWindowsTileHorizontal.Text = "&Horizontal"
        '
        'mnuWindowsCloseAll
        '
        Me.mnuWindowsCloseAll.Name = "mnuWindowsCloseAll"
        Me.mnuWindowsCloseAll.Size = New System.Drawing.Size(150, 22)
        Me.mnuWindowsCloseAll.Text = "Cerrar &Todas"
        '
        'mnuWindowsArrangeIcons
        '
        Me.mnuWindowsArrangeIcons.Name = "mnuWindowsArrangeIcons"
        Me.mnuWindowsArrangeIcons.Size = New System.Drawing.Size(150, 22)
        Me.mnuWindowsArrangeIcons.Text = "&Arregla Iconos"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpContents, Me.mnuHelpIndex, Me.mnuHelpSearch, Me.ToolStripSeparator8, Me.mnuHelpAbout})
        Me.mnuAyuda.Name = "mnuAyuda"
        Me.mnuAyuda.Size = New System.Drawing.Size(53, 20)
        Me.mnuAyuda.Text = "A&yuda"
        '
        'mnuHelpContents
        '
        Me.mnuHelpContents.Name = "mnuHelpContents"
        Me.mnuHelpContents.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.mnuHelpContents.Size = New System.Drawing.Size(176, 22)
        Me.mnuHelpContents.Text = "&Contenido"
        '
        'mnuHelpIndex
        '
        Me.mnuHelpIndex.Image = CType(resources.GetObject("mnuHelpIndex.Image"), System.Drawing.Image)
        Me.mnuHelpIndex.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuHelpIndex.Name = "mnuHelpIndex"
        Me.mnuHelpIndex.Size = New System.Drawing.Size(176, 22)
        Me.mnuHelpIndex.Text = "&Indice"
        '
        'mnuHelpSearch
        '
        Me.mnuHelpSearch.Image = CType(resources.GetObject("mnuHelpSearch.Image"), System.Drawing.Image)
        Me.mnuHelpSearch.ImageTransparentColor = System.Drawing.Color.Black
        Me.mnuHelpSearch.Name = "mnuHelpSearch"
        Me.mnuHelpSearch.Size = New System.Drawing.Size(176, 22)
        Me.mnuHelpSearch.Text = "&Buscar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(173, 6)
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(176, 22)
        Me.mnuHelpAbout.Text = "&Acerca de ..."
        '
        'mnuSalir
        '
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(41, 20)
        Me.mnuSalir.Text = "&Salir"
        '
        'ToolStrip
        '
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblInformacion})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(632, 25)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'lblInformacion
        '
        Me.lblInformacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblInformacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblInformacion.Name = "lblInformacion"
        Me.lblInformacion.Size = New System.Drawing.Size(0, 22)
        Me.lblInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 431)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblStatus
        '
        Me.lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(617, 17)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrProyecto
        '
        Me.tmrProyecto.Interval = 60000
        '
        'Printer
        '
        '
        'mdiRecargaPOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.DoubleBuffered = True
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "mdiRecargaPOS"
        Me.Text = "Visual Recarga POS"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuHelpContents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAyuda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpIndex As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsArrangeIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsCloseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsCascade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsTileVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuWindowsTileHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuVenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuReportes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConsultas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConfiguracion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeposito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConfiguracionImpresora As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConfiguracionContraseña As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblInformacion As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tmrProyecto As System.Windows.Forms.Timer
    Friend WithEvents Printer As System.Drawing.Printing.PrintDocument
    Friend WithEvents mnuReportesImprimirUltimoRecibo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReportesVentasPorDia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReportesTransaccionesDiarias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuReportesEstadoDeCuenta As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConsultasTransacciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConsultasTransaccionesEnEspera As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuConsultasResumenDeTransacciones As System.Windows.Forms.ToolStripMenuItem

End Class
