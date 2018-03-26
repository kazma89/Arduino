Public Class login
    Private Sub accesarBtn_Click(sender As Object, e As EventArgs) Handles accesarBtn.Click
        'Ingresa a la ventana principal del programa
        Me.Hide()
        frmPrincipal.Show()
    End Sub

    Private Sub salirBtn_Click(sender As Object, e As EventArgs) Handles salirBtn.Click
        'Cierra la aplicacion
        Application.Exit()
    End Sub
End Class