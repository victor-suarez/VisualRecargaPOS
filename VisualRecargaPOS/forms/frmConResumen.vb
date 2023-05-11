Option Strict On
Imports Microsoft.VisualBasic
Public Class frmConResumen
    Private Sub CargarResumen()
        Dim rsReTr As New ADODB.Recordset
        Dim item As ListViewItem
        Dim hStart As DateTime = Now
        Dim lvwHeight As Integer = 0
        lvwTransacciones.Items.Clear()
        glSQL = "EXEC [Sp_Rec_Qry_Ventas_Diarias5] 1," & glCodVen.ToString & "," & glEstacion.ToString
        '''' DATA DE PRUEBA!!!
        '''''glSQL = "EXEC [Sp_Rec_Qry_Ventas_Diarias5] 1"
        rsReTr = Conx.Execute(glSQL)
        If Not rsReTr.EOF Then
            Do While Not rsReTr.EOF
                item = lvwTransacciones.Items.Add(rsReTr("Operadora").Value.ToString)
                lvwHeight += lvwTransacciones.GetItemRect(item.Index).Height
                item.SubItems.Add(If(IsDBNull(rsReTr("Monto").Value), "0", CInt(rsReTr("Monto").Value).ToString("###,###,##0")))
                item.SubItems.Add(If(IsDBNull(rsReTr("Trans.").Value), "0", rsReTr("Trans.").Value.ToString))
                item.SubItems.Add(If(IsDBNull(rsReTr("Aprob.").Value), "0", rsReTr("Aprob.").Value.ToString))
                item.SubItems.Add(If(IsDBNull(rsReTr("Rchaz.").Value), "0", rsReTr("Rchaz.").Value.ToString))
                item.SubItems.Add(If(IsDBNull(rsReTr("%Rchaz.").Value), "0%", rsReTr("%Rchaz.").Value.ToString & "%"))
                item.SubItems.Add(rsReTr("Estatus").Value.ToString)

                item.BackColor = If(rsReTr("Estatus").Value.ToString = "I", Color.Red, lvwTransacciones.BackColor)
                rsReTr.MoveNext()
            Loop
            'Le agrego un adicional por el header
            lvwHeight += lvwTransacciones.GetItemRect(0).Height
        End If
        rsReTr.Close()
        rsReTr = Nothing
        lvwTransacciones.Height = lvwHeight + 6
        btnSalir.Top = lvwTransacciones.Bottom + 2
        Me.AutoSize = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmConResumen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = Me.MdiParent.ClientSize.Width - Me.Width - 6
        Me.Top = 1
        Call CargarResumen()
        tmrConsulta.Start()
    End Sub

    Private Sub frmConResumen_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Me.Left = Me.MdiParent.ClientSize.Width - Me.Width - 6
    End Sub

    Private Sub tmrConsulta_Tick(sender As Object, e As EventArgs) Handles tmrConsulta.Tick
        tmrConsulta.Stop()
        Call CargarResumen()
        tmrConsulta.Start()
    End Sub
End Class