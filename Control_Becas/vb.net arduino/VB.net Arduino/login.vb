Imports MySql.Data.MySqlClient 'Se importa la libreria MySQLCLient al proyecto
Public Class login
    'Se crea la variable oConexion para que sirva de parametro a la hora de hacer las respectivas conexiones con la DB
    Dim oConexion As New MySqlConnection("server=localhost;user id=root;password=;database=prueba_db;port=3306")
    'Se crea la variable oDataAdapter para que sirva de traductor para traducir 
    'de cadena de caracteres a verdaderas sentencias SQL 
    Dim oDataAdapter As MySqlDataAdapter
    'Se crea la variable oDataSet para almacenar lo traducido del oDataAdapter y poder
    'luego llevarlo a la DB
    Dim oDataSet As New DataSet
    'Se crea una variable de tipo String para almacenar las consultas a realizar
    Dim sSql As String
    'Se crea una variable contador para contar las veces que el usuario a tratado de 
    'ingresar al sistema
    Dim contador As Integer = 0
    Private Sub accesarBtn_Click(sender As Object, e As EventArgs) Handles accesarBtn.Click
        'Validador para ver si los campos estan vacios
        If (loginTxt.Text = "" Or passTxt.Text = "") Then
            MessageBox.Show("Existen campos vacios. Verifique de nuevo!!!", "Login")
        Else
            Try
                'Consulta para ver si el usuario y la contraseña ingresada por el usuario existan en la DB
                sSql = "SELECT * FROM usuarios_tb WHERE usuario='" & loginTxt.Text & "' and pass='" & passTxt.Text & "';"
                'Se abre la conexion a la DB
                oConexion.Open()
                'Utilizamos el oDataAdapter para traducir lo escrito en la variable sSql y llevarlo a la DB dada
                'en la variable oConexion
                oDataAdapter = New MySqlDataAdapter(sSql, oConexion)
                'Limpiamos el oDataSet para asegurarnos de que no pase ningun error por tener alguna consulta almacenada
                oDataSet.Clear()
                'Llenamos el oDataSet con la informacion dada por la tabla usuarios
                oDataAdapter.Fill(oDataSet, "usuarios_tb")
                'Verificamos si la consulta dada anteriormente dio alguna fila de respuesta en la tabla especificada
                'por lo que hacemos un conteo de consultas
                If (oDataSet.Tables("usuarios_tb").Rows.Count() <> 0) Then
                    MessageBox.Show("Bienvenido al sistema " & loginTxt.Text, "Login")
                    'Escondemos el formulario de login
                    Me.Hide()
                    'Creamos una instancia del formulario principal
                    Dim principal As New frmPrincipal()
                    'Mostramos el formulario principal
                    principal.Show()
                    'Cerramos la conexion a la DB por seguridad
                    oConexion.Close()
                    'Si el usuario a intentado ingresar sin exito en 3 ocasiones muestra el mensaje de error y 
                    'cierra el formulario
                ElseIf contador = 3 Then
                    MessageBox.Show("Numero de intentos alcanzados. No puede ingresar al sistema", "Login")
                    Application.Exit()
                    ' Si el usuario a ingresado mal el usuario o la contraseña muestra el siguiente mensaje y
                    'suma 1 al contador de los intentos fallidos, borra lo escrito por el usuario y coloca el cursor en
                    'el cuadro de texto de login
                Else
                    contador = contador + 1
                    MessageBox.Show("Usuario y/o contraseña invalida. Intente de nuevo", "Login")
                    loginTxt.Text = ""
                    passTxt.Text = ""
                    loginTxt.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show("Error al intentar loguear al sistema", "Login")
            End Try
        End If
    End Sub

    Private Sub salirBtn_Click(sender As Object, e As EventArgs) Handles salirBtn.Click
        'Cierra la aplicacion
        Application.Exit()
    End Sub
End Class