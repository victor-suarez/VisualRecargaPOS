Public NotInheritable Class frmAcercaDe

    Private Sub frmAcercaDe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 1
        Me.Left = 1

        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description

        Me.TextBoxRegional.AppendText("Idioma(Región) " & My.Application.Culture.DisplayName & vbCrLf)
        Me.TextBoxRegional.AppendText("Sep. Decimal  (" & My.Application.Culture.NumberFormat.CurrencyDecimalSeparator & ")" & vbCrLf)
        Me.TextBoxRegional.AppendText("Sep. Millares (" & My.Application.Culture.NumberFormat.CurrencyGroupSeparator & ")" & vbCrLf)
        Me.TextBoxRegional.AppendText("Moneda        (" & My.Application.Culture.NumberFormat.CurrencySymbol & ")")
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class
