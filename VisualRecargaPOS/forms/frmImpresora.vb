Option Strict On
Friend Class frmImpresora
    Friend Enum prnJustified
        justLeft
        justCenter
        justRight
    End Enum
    Friend iPrinterWidth As Integer = 40

    Private Sub AcomodarImgPrinter()
        'Desabilito el menú de contexto de la impresión por pantalla,
        'si no estoy en debugging. by VESC 14-11-2013
        If Not glIsDebuggin Then
            Dim _blankContextMenu As New ContextMenu()
            txtPrn.ContextMenu = _blankContextMenu
        End If
        'grpButtons.Text = iPrinterWidth.ToString
        If iPrinterWidth > 40 Then
            Me.Width = Me.MdiParent.ClientSize.Width - 10
            'Else
            '    Me.Width = CInt(Math.Round(Me.MdiParent.ClientSize.Width / 4, 0))
        End If
        Me.Height = Me.MdiParent.ClientSize.Height - mdiRecargaPOS.MenuStrip.Height - mdiRecargaPOS.ToolStrip.Height - mdiRecargaPOS.StatusStrip.Height - 25
        Me.Left = Me.MdiParent.ClientSize.Width - Me.Width - 6
        txtPrn.Width = Me.Width
        txtPrn.Height = Me.Height - 47
        grpButtons.Top = Me.Height - 45
        grpButtons.Left = CInt(Math.Round((Me.Width - grpButtons.Width) / 2, 0))
        'If glPermisos.Chars(254) = "1" Then 'EL permiso 254 prendido - NO IMPRIME TICKETS (Taquilla Pública)
        '    btnImprimir.Visible = False
        'End If

        'btnImprimir.Top = Me.Height - 27
        'btnCerrar.Top = Me.Height - 27
    End Sub

    Private Sub MoverAVirtualPrinter()
        Dim arrLines() As String
        VP.Clear()
        For idxLine As Integer = 0 To glSaltarAntes
            VP.Add("")
        Next
        arrLines = txtPrn.Text.Split(vbCr.Chars(0))
        For idxLine As Integer = 0 To arrLines.GetUpperBound(0)
            VP.Add(New String(" "c, glMargenIzq) & arrLines(idxLine).Replace(vbLf, ""))
        Next
        For idxLine As Integer = 0 To glSaltarDespues
            VP.Add("")
        Next
    End Sub

    Friend Sub mClear()
        txtPrn.Clear()
    End Sub

    Friend Sub mPrint(Optional ByVal strValue As String = "", Optional ByVal strJust As prnJustified = prnJustified.justLeft)
        Dim sPad As String
        If strValue.StartsWith("SERIAL") Then Exit Sub
        If strValue <> "" Then
            If strJust = prnJustified.justLeft Then
                txtPrn.AppendText(strValue)
            ElseIf strJust = prnJustified.justRight Then
                If strValue.Length > iPrinterWidth Then strValue = strValue.Substring(0, iPrinterWidth)
                txtPrn.AppendText(strValue.PadLeft(iPrinterWidth))
            ElseIf strJust = prnJustified.justCenter Then
                sPad = New String(" "c, CInt((iPrinterWidth - strValue.Length) / 2))
                txtPrn.AppendText(sPad & strValue)
            End If
        Else
            txtPrn.AppendText(vbCrLf)
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'If glPermisos.Chars(254) = "1" Then Exit Sub 'EL permiso 254 prendido - NO IMPRIME TICKETS (Taquilla Pública)
        Call MoverAVirtualPrinter()
        If glImpresora = vlImpresoraEnum.vlWindows Then
            Call PrintToWinDefault()
        Else
            Call PrintToPort()
        End If
        Me.Dispose()
    End Sub

    Private Sub txtPrn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrn.KeyDown
        e.Handled = True
    End Sub

    Private Sub txtPrn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrn.KeyPress
        e.Handled = True
    End Sub

    Private Sub frmImpresora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = System.Convert.ToChar(System.Windows.Forms.Keys.Escape) Then
            Call btnImprimir_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    Private Sub frmImpresora_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        Call AcomodarImgPrinter()
        Me.BringToFront()
    End Sub
End Class