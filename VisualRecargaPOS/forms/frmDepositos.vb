Public Class frmDepositos
    Private Sub BuscarBancosVzla(strBanco As String)
        For idx As Integer = 0 To (cmbBancosVzla.Items.Count - 1)
            If cmbBancosVzla.Items(idx).ToString = strBanco Then cmbBancosVzla.SelectedIndex = idx : Exit For
        Next idx
    End Sub

    Private Sub BuscarTipo(strTipo As String)
        For idx As Integer = 0 To (cmbTipoDeposito.Items.Count - 1)
            If cmbTipoDeposito.Items(idx).ToString = strTipo Then cmbTipoDeposito.SelectedIndex = idx : Exit For
        Next idx
    End Sub

    Private Sub CargarBancosVzla(ByVal cmb As ComboBox)
        Dim clsBan As New clsBancos(Conx)
        Try
            Call clsBan.CargaCombo(cmb)
        Catch ex As Exception
            Dim strFixMsg As String = "Error cargando combo de bancos."
            Call MensajeError(ex, strFixMsg)
        End Try
        clsBan = Nothing
    End Sub

    Private Sub CargaCombo(ByVal cmb As ComboBox)
        Dim clsAyu As New clsAyuda(Conx)
        Try
            Call clsAyu.CargaCombo(Me.Name, cmb)
        Catch ex As Exception
            Dim strFixMsg As String = "Error cargando combo " & cmb.Name & "."
            Call MensajeError(ex, strFixMsg)
        End Try
        clsAyu = Nothing
    End Sub

    Private Sub CargarCtasVisual()
        cmbCtasVisual.Items.Clear()
        glSQL = "EXEC PosQryBancos 'AllBancosAsoc'"
        Try
            iRET = ExecSP(glSQL, True)
            Do While Not RecSet.EOF
                cmbCtasVisual.Items.Add(New clsBancos(CInt(RecSet("ID_Banco").Value), RecSet("Nombre").Value.ToString, RecSet("Nombre").Value.ToString, "0000"))
                RecSet.MoveNext()
            Loop
        Catch ex As Exception
            Dim strFixMsg As String = "Error cargando Cuentas Visual."
            Call MensajeError(ex, strFixMsg)
        End Try
        rsetClose(RecSet)
        If cmbCtasVisual.Items.Count > 0 Then cmbCtasVisual.SelectedIndex = 0
    End Sub

    Private Sub CargarDepositosPendientes()
        Dim item As ListViewItem
        lvwDepositos.Items.Clear()
        glSQL = "EXEC PosQryDepositos 'AllDepyRechXVendNew'," & glCodVen
        Try
            iRET = ExecSP(glSQL, True)
            Do While Not RecSet.EOF
                'item = lvwDepositos.Items.Add(RecSet("ID_Deposito").Value.ToString)
                item = lvwDepositos.Items.Add(CDate(RecSet("Fecha").Value).ToString("dd/MM/yyyy"))
                item.SubItems.Add(RecSet("Banco").Value.ToString)
                item.SubItems.Add(RecSet("TipoDeposito").Value.ToString)
                item.SubItems.Add(RecSet("NroDeposito").Value.ToString)
                item.SubItems.Add(CDec(RecSet("Monto").Value).ToString("#,###,###,##0.00"))
                item.SubItems.Add(RecSet("Status").Value.ToString)
                item.SubItems.Add(RecSet("ChequeCuenta").Value.ToString)
                item.SubItems.Add(RecSet("Cheque").Value.ToString)
                item.Tag = CInt(RecSet("ID_Deposito").Value)
                RecSet.MoveNext()
            Loop
        Catch ex As Exception
            Dim strFixMsg As String = "Error cargando Depósitos Pendientes."
            Call MensajeError(ex, strFixMsg)
        End Try
        rsetClose(RecSet)
        If lvwDepositos.Items.Count = 0 Then
            lvwDepositos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        Else
            lvwDepositos.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        End If
    End Sub

    Private Sub ClearCRT()
        dtpFecha.Value = CDate(glFecHora.ToString("dd/MM/yyyy"))
        cmbBancosVzla.SelectedIndex = -1
        cmbCtasVisual.SelectedIndex = 0
        cmbTipoDeposito.SelectedIndex = -1
        txtNroDeposito.Text = ""
        txtMonto.Text = ""
        txtChequeCuenta.Text = ""
        txtCheque.Text = ""
        pnlCheque.Visible = False
        Me.Tag = Nothing
    End Sub

    Private Function ValEntReq() As Boolean
        If cmbBancosVzla.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar el banco desde donde realizó el depósito.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbBancosVzla.Focus()
            Return False
        End If
        If cmbCtasVisual.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar la cuenta Visual a donde realizó el depósito.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbCtasVisual.Focus()
            Return False
        End If
        If cmbTipoDeposito.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar el tipo de depósito realizado.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbTipoDeposito.Focus()
            Return False
        End If
        If txtNroDeposito.Text.Trim = "" Then
            MessageBox.Show("Debe indicar el número de depósito o comprobante de la transacción realizada.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNroDeposito.Focus()
            Return False
        End If
        If txtMonto.Text.Trim = "" Or CInt(txtMonto.Text.Trim) = 0 Then
            MessageBox.Show("Debe indicar monto de la transacción realizada.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMonto.Focus()
            Return False
        End If
        If cmbTipoDeposito.SelectedItem.ToString.StartsWith("CH") Then
            If txtChequeCuenta.Text = "" Then
                MessageBox.Show("Debe indicar la cuenta del cheque depositado.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtChequeCuenta.Focus()
                Return False
            End If
            If txtCheque.Text = "" Then
                MessageBox.Show("Debe indicar el número del cheque depositado.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCheque.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Me.Tag Is Nothing Then
            MessageBox.Show("Debe seleccionar en la lista el depósito a eliminar.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lvwDepositos.Focus()
            Exit Sub
        End If
        If lvwDepositos.SelectedItems(0).SubItems(5).Text <> "TRANSITO" Then
            MessageBox.Show("NO puede eliminar un depósito que no esté en tránsito.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lvwDepositos.Focus()
            Exit Sub
        End If
        If MessageBox.Show("¿Seguro desea eliminar el registro de depósito seleccionado?", "Eliminar depósito en tránsito", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                glSQL = "EXEC PosDelDepositos @ID_Deposito=" & Me.Tag.ToString
                iRET = ExecSP(glSQL, False)
                Call ClearCRT()
                Call CargarDepositosPendientes()
            Catch ex As Exception
                Dim strFixMsg As String = "Error eliminando depósito en tránsito."
                Call MensajeError(ex, strFixMsg)
            End Try
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not Me.Tag Is Nothing Then
            If MessageBox.Show("Está duplicando un registro existente. ¿Seguro que es lo que desea?", "Datos duplicados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                lvwDepositos.Focus()
                Exit Sub
            End If
        End If
        If Not ValEntReq() Then Exit Sub
        Try
            glSQL = "EXEC PosInsDepositos"
            glSQL = glSQL & " @ID_Vendedor=" & glCodVen.ToString
            glSQL = glSQL & ",@Fecha='" & dtpFecha.Value.ToString("yyyyMMdd") & "'"
            glSQL = glSQL & ",@ID_Banco=" & DirectCast(cmbCtasVisual.SelectedItem, clsBancos).ID.ToString
            glSQL = glSQL & ",@TipoDeposito='" & DirectCast(cmbTipoDeposito.SelectedItem, clsAyuda).Clave & "'"
            glSQL = glSQL & ",@NroDeposito='" & txtNroDeposito.Text & "'"
            glSQL = glSQL & ",@ChequeCuenta=" & If(txtChequeCuenta.Text = "", "NULL", "'" & txtChequeCuenta.Text & "'").ToString
            glSQL = glSQL & ",@Cheque=" & If(txtCheque.Text = "", "NULL", "'" & txtCheque.Text & "'").ToString
            glSQL = glSQL & ",@ChequeBanco=" & If(cmbBancosVzla.SelectedIndex = -1, "NULL", DirectCast(cmbBancosVzla.SelectedItem, clsBancos).ID).ToString
            glSQL = glSQL & ",@Monto=" & txtMonto.Text.Replace(",", ".")
            glSQL = glSQL & ",@UserAdd='" & glUser & "'"
            iRET = ExecSP(glSQL, False)
            Call ClearCRT()
            Call CargarDepositosPendientes()
        Catch ex As Exception
            Dim strFixMsg As String = "Error guardando depósito en tránsito."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If Me.Tag Is Nothing Then
            MessageBox.Show("Debe seleccionar en la lista el depósito a modificar.", "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lvwDepositos.Focus()
            Exit Sub
        End If
        If Not ValEntReq() Then Exit Sub
        Try
            glSQL = "EXEC PosUpdDepositos @ID_Deposito=" & Me.Tag.ToString
            glSQL = glSQL & ",@ID_Vendedor=" & glCodVen.ToString
            glSQL = glSQL & ",@Fecha='" & dtpFecha.Value.ToString("yyyyMMdd") & "'"
            glSQL = glSQL & ",@ID_Banco=" & DirectCast(cmbCtasVisual.SelectedItem, clsBancos).ID.ToString
            glSQL = glSQL & ",@TipoDeposito='" & DirectCast(cmbTipoDeposito.SelectedItem, clsAyuda).Clave & "'"
            glSQL = glSQL & ",@NroDeposito='" & txtNroDeposito.Text & "'"
            glSQL = glSQL & ",@ChequeCuenta=" & If(txtChequeCuenta.Text = "", "NULL", "'" & txtChequeCuenta.Text & "'").ToString
            glSQL = glSQL & ",@Cheque=" & If(txtCheque.Text = "", "NULL", "'" & txtCheque.Text & "'").ToString
            glSQL = glSQL & ",@ChequeBanco=" & If(cmbBancosVzla.SelectedIndex = -1, "NULL", DirectCast(cmbBancosVzla.SelectedItem, clsBancos).ID).ToString
            glSQL = glSQL & ",@Monto=" & txtMonto.Text.Replace(",", ".")
            glSQL = glSQL & ",@Usuario='" & glUser & "'"
            iRET = ExecSP(glSQL, False)
            Call ClearCRT()
            Call CargarDepositosPendientes()
        Catch ex As Exception
            Dim strFixMsg As String = "Error guardando depósito en tránsito."
            Call MensajeError(ex, strFixMsg)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub cmbTipoDeposito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDeposito.SelectedIndexChanged
        If cmbTipoDeposito.Text.StartsWith("CH") Then
            pnlCheque.Visible = True
        Else
            txtChequeCuenta.Text = ""
            txtCheque.Text = ""
            pnlCheque.Visible = False
        End If
    End Sub

    Private Sub frmDepositos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 1
        Me.Left = 1
        dtpFecha.MaxDate = glFecHora
        dtpFecha.Value = glFecHora
        Call CargarBancosVzla(cmbBancosVzla)
        Call CargarCtasVisual()
        Call CargaCombo(cmbTipoDeposito)
        Call CargarDepositosPendientes()
    End Sub

    Private Sub lvwDepositos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvwDepositos.SelectedIndexChanged
        Dim item As ListViewItem
        If lvwDepositos.SelectedItems.Count = 0 Then Exit Sub
        item = lvwDepositos.SelectedItems(0)
        Me.Tag = item.Tag
        dtpFecha.Value = CDate(item.SubItems(colFecha.Index).Text)    '0
        Call BuscarBancosVzla(item.SubItems(colBanco.Index).Text)     '1
        Call BuscarTipo(item.SubItems(colTipo.Index).Text)            '2
        txtNroDeposito.Text = item.SubItems(colNumero.Index).Text     '3
        txtMonto.Text = CDec(item.SubItems(colMonto.Index).Text)      '4
        txtChequeCuenta.Text = item.SubItems(colNroCuenta.Index).Text '6
        txtCheque.Text = item.SubItems(colNroCheque.Index).Text       '7
    End Sub

    Private Sub txtNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroDeposito.KeyPress, txtChequeCuenta.KeyPress, txtCheque.KeyPress
        If vbNumbers.IndexOf(e.KeyChar) = -1 Then e.Handled = True : Exit Sub
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If vbMonto.IndexOf(e.KeyChar) = -1 Then e.Handled = True : Exit Sub
        'no pueden haber dos comas
        If e.KeyChar = ","c And txtMonto.Text.IndexOf(",") <> -1 Then e.Handled = True : Exit Sub
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFecha.KeyPress
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub cmb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbBancosVzla.KeyPress, cmbCtasVisual.KeyPress, cmbTipoDeposito.KeyPress
        If e.KeyChar = System.Convert.ToChar(Keys.Return) Then
            e.Handled = True
            SelectNextControl(DirectCast(sender, Control), True, True, True, True)
        End If
    End Sub
End Class