'Importa la libreria AForge que es la que permite capturar imagenes desde un dispositivo de video e insertarlos en el formulario
Imports AForge.Video.DirectShow

Public Class tomarFotoFrm
    'Variables globales para obtener los dispositivos de video y tomar las fotografias
    Private Dispositivos As FilterInfoCollection
    Private FuenteDeVideo As VideoCaptureDevice

    'Al cargar la ventana se mostrara la lista de los dispositivos de video insertados en la computadora incluyendo la webcam
    'si se posee una
    Private Sub tomarFoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dispositivos = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        For Each x As FilterInfo In Dispositivos
            dispositivosCb.Items.Add(x.Name)
        Next
        'Muestra en el combobox el primer dispositivo de la lista
        dispositivosCb.SelectedIndex = 0
    End Sub

    'Inicia la captura de imagenes de la camara, muestra la imagen en el control de preview
    Private Sub iniciarBtn_Click(sender As Object, e As EventArgs) Handles iniciarBtn.Click
        FuenteDeVideo = New VideoCaptureDevice(Dispositivos(dispositivosCb.SelectedIndex).MonikerString)
        previewVsp.VideoSource = FuenteDeVideo
        previewVsp.Start()
    End Sub

    'Detiene la visualizacion de imagenes en el control de preview
    Private Sub terminarBtn_Click(sender As Object, e As EventArgs) Handles terminarBtn.Click
        previewVsp.SignalToStop()
    End Sub

    'Toma la foto y la muestra en una ventana de preview
    Private Sub capturarBtn_Click(sender As Object, e As EventArgs) Handles capturarBtn.Click
        'Toma el ultimo fotograma tomado de la camara y lo converte en un bitmap
        Dim img As Bitmap = previewVsp.GetCurrentVideoFrame()
        'Coloca la imagen en el control de preview de la ventana de preview
        previewFrm.previaPb.Image = img
        'Cierra la ventana
        Me.Hide()
        'Abre la venta de preview
        previewFrm.Show()
    End Sub

    Private Sub cerrarBtn_Click(sender As Object, e As EventArgs) Handles cerrarBtn.Click
        'Cerrar ventana y abrir ventana de formulario principal
        Me.Hide()
        frmPrincipal.Show()
    End Sub
End Class