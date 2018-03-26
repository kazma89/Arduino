Public Class previewFrm
    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles guardarBtn.Click
        'Dialogo para seleccionar la ruta para guardar
        Dim sf As New SaveFileDialog()
        'Filtro de imagenes .jpg
        sf.Filter = "Imagenes JPG | *.jpg"
        'Mostrar Dialogo
        sf.ShowDialog()
        'Asegurar que tiene una ruta valida
        If sf.FileName IsNot Nothing Then
            'Variable para la imagen
            Dim img As Bitmap = tomarFotoFrm.previewVsp.GetCurrentVideoFrame()
            'Guardar imagen en el Picturebox del formulario principal
            frmPrincipal.fotoRegistroPb.Image = img
            'Borrar imagen de memoria
            img.Dispose()
            previaPb.Dispose()
            tomarFotoFrm.previewVsp.Dispose()
            'Cerrar ventana preview y abrir ventana de formulario principal
            Me.Hide()
            frmPrincipal.Show()
        End If
    End Sub

    Private Sub CerrarBtn_Click(sender As Object, e As EventArgs) Handles cerrarBtn.Click
        'Borrar imagen de memoria
        previaPb.Dispose()
        tomarFotoFrm.previewVsp.Dispose()
        'Cerrar ventana preview y abrir ventana de tomar foto
        Me.Hide()
        tomarFotoFrm.Show()
    End Sub
End Class