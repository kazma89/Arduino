Imports MySql.Data.MySqlClient
Module conexionSQL
    Dim oConexion As New MySqlConnection("server=localhost;user=root;password=;database=prueba;port=3306")
    Dim oDataAdapter As New MySqlDataAdapter
    'Dim oComando As New MySqlCommand
    Dim oDataSet As New DataSet
    Dim sSql As String
    Dim sw As Boolean = False
    Function abrirConexion() As Boolean
        Try
            oConexion.Open()
            'oDataSet.Clear()
            sw = True
        Catch ex As Exception
            MessageBox.Show("No se pudo abrir la conexion", "Sistema")
        End Try
        Return sw
    End Function
    Function cerrarConexion() As Boolean
        Try
            oConexion.Close()
            sw = True
        Catch ex As Exception
            MessageBox.Show("No se pudo cerrar la conexion", "Sistema")
        End Try
        Return sw
    End Function
    Function insertarDatos(ByVal id As Integer, ByVal login As String, ByVal nombre As String, ByVal apellido1 As String,
                           ByVal apellido2 As String, fnacimiento As String, ByVal genero As String,
                           ByVal direccion As String, ByVal usuario As String) As Boolean
        Try
            sSql = "INSERT INTO usuario VALUES('" & id & "','" & login & "','" & nombre & "','" & apellido1 & "','" &
                apellido2 & "','" & fnacimiento & "','" & genero & "','" & direccion & "','" & usuario & "');"
            Dim oComando As New MySqlCommand(sSql, oConexion)
            oComando.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("No se pudo insertar registro", "Sistema")
        End Try
        Return sw
    End Function
End Module
