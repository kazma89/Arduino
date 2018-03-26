'Incluye la libreria para la conexion a la DB
Imports MySql.Data.MySqlClient
Public Class frmPrincipal
    'Se crea la variable oConexion para que sirva de parametro a la hora de hacer las respectivas conexiones con la DB
    Dim oConexion As New MySqlConnection("server=localhost;user id=root;password=;database=prueba_db;port=3306")
    'Se crea la variable oDataAdapter para que sirva de traductor para traducir 
    'de cadena de caracteres a verdaderas sentencias SQL
    Dim oDataAdapter As New MySqlDataAdapter
    'Se crea la variable oDataSet para almacenar lo traducido del oDataAdapter y poder
    'luego llevarlo a la DB
    Dim oDataSet As New DataSet
    'Se crea una variable de tipo String para almacenar las consultas a realizar
    Dim sSql As String
    Private Sub cancelarBtn_Click_1(sender As Object, e As EventArgs) Handles salirRegistroBtn.Click
        'Cierra la aplicacion
        Application.Exit()
    End Sub

    Private Sub aceptarBtn_Click(sender As Object, e As EventArgs) Handles aceptarRegistroBtn.Click

        Try
            'Abre la conexion a la DB
            oConexion.Open()
        Catch ex As Exception
            'Lanza el siguiente mensaje de error si no se pudo completar la conexion
            MessageBox.Show("Error al conectar", "Sistema")
        End Try
        Try
            'Valida que todos los campos requeridos no esten vacios
            If (cedulaRegistroTxt.Text = "" Or carnetRegistroTxt.Text = "" Or nombreRegistroTxt.Text = "" Or
                apellido1RegistroTxt.Text = "" Or apellido2RegistroTxt.Text = "" Or
                generoRegistroCmb.Text = "" Or direccionRegistroTxt.Text = "" Or
                becadoRegistroCmb.Text = "" Or seccionRegistroCmb.Text = "") Then
                MessageBox.Show("Existen campos en blanco", "Registro")
            Else
                'realiza la consulta para poder ingresar todos los datos del formulario a la DB
                sSql = "INSERT INTO usuario VALUES('" & cedulaRegistroTxt.Text & "','" &
                    carnetRegistroTxt.Text & "','" & nombreRegistroTxt.Text & "','" &
                    apellido1RegistroTxt.Text & "','" & apellido2RegistroTxt.Text & "','" &
                    fnacimientoRegistroDtp.Value.ToString("yyyy-MM-dd") & "','" &
                    generoRegistroCmb.Text & "','" & provinciaRegistroTxt.Text & "' , '" &
                cantonRegistroTxt.Text & "','" & distritoRegistroTxt.Text & "','" &
                direccionRegistroTxt.Text & "','" & especialidadRegistroCmb.Text & "','" &
                becadoRegistroCmb.Text & "','" & seccionRegistroCmb.Text & "','" &
                fotoRegistroPb.ImageLocation & "','" & nombreEncargado1Txt.Text & "','" &
                apellido1Encargado1Txt.Text & "','" & apellido2Encargado1Txt.Text & "','" &
                generoEncargado1Cmb.Text & "','" & relacionEncargado1Txt.Text & "','" &
                nombreEncargado2Txt.Text & "','" & apellido1Encargado2Txt.Text & "','" &
                apellido2Encargado2Txt.Text & "','" & generoEncargado2Cmb.Text & "','" &
                relacionEncargado2Txt.Text & "');"
                'Utilizamos el oDataAdapter para traducir lo escrito en la variable sSql y llevarlo a la DB dada
                'en la variable oConexion 
                'oDataAdapter = New MySqlDataAdapter(sSql, oConexion)
                'Utilizamos el oComando para traducir lo escrito en la variable sSql y llevarlo a la DB dada en la
                'variable oConexion
                Dim oComando As New MySqlCommand(sSql, oConexion)
                'Ejecuta el comando dado a oComando
                oComando.ExecuteNonQuery()
                'Escribe la palabra CORRECTO en el formulario
                correctoLbl.Text = "CORRECTO"
                'Limpia los campos de texto del formulario
                cedulaRegistroTxt.Text = ""
                carnetRegistroTxt.Text = ""
                nombreRegistroTxt.Text = ""
                apellido1RegistroTxt.Text = ""
                apellido2RegistroTxt.Text = ""
                generoRegistroCmb.Text = ""
                fnacimientoRegistroDtp.Value = Now
                direccionRegistroTxt.Text = ""
                becadoRegistroCmb.Text = ""
                seccionRegistroCmb.Text = ""
            End If
        Catch ex As Exception
            'Si hay errrores en alguno de los comandos anteriores lanza un mensaje de error al formulario
            MessageBox.Show("Error al insertar los datos", "Sistema")
            errorLbl.Text = "ERROR"
        End Try
    End Sub

    Private Sub borrarBtn_Click_1(sender As Object, e As EventArgs) Handles borrarRegistroBtn.Click
        'Limpia los campos de texto en el formulario
        cedulaRegistroTxt.Text = ""
        carnetRegistroTxt.Text = ""
        nombreRegistroTxt.Text = ""
        apellido1RegistroTxt.Text = ""
        apellido2RegistroTxt.Text = ""
        generoRegistroCmb.Text = ""
        fnacimientoRegistroDtp.Value = Now
        provinciaRegistroTxt.Text = ""
        cantonRegistroTxt.Text = ""
        distritoRegistroTxt.Text = ""
        direccionRegistroTxt.Text = ""
        especialidadRegistroCmb.Text = ""
        becadoRegistroCmb.Text = ""
        nivelRegistroCmb.Text = ""
        seccionRegistroCmb.Text = ""
        fotoRegistroPb.ImageLocation = ""
        nombreEncargado1Txt.Text = ""
        apellido1Encargado1Txt.Text = ""
        apellido2Encargado1Txt.Text = ""
        generoEncargado1Cmb.Text = ""
        relacionEncargado1Txt.Text = ""
        nombreEncargado2Txt.Text = ""
        apellido1Encargado2Txt.Text = ""
        apellido2Encargado2Txt.Text = ""
        generoEncargado2Cmb.Text = ""
        relacionEncargado2Txt.Text = ""
        correctoLbl.Text = ""
        errorLbl.Text = ""
    End Sub

    Private Sub fnacimientoDtp_ValueChanged(sender As Object, e As EventArgs) Handles fnacimientoRegistroDtp.ValueChanged
        Try
            'Extrae la diferentes entre la fecha actual y la fecha de nacimiento de la persona y la convierte en dias
            Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
            'Si la persona es menor de edad se despliega la informacion de los encargados
            If (fechaNac < 6570) Then
                encargado1GB.Visible = True
                encargado2GB.Visible = True
            End If
            'Si la persona es mayor de edad valida que los campos requeridos esten llenos para habilitar el boton aceptar
            If fechaNac >= 6570 Then
                If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                    apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                    provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                    direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                    nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                    aceptarRegistroBtn.Enabled = True
                End If
            Else
                'Si la persona es menor de edad valida que los campos requeridos esten llenos para habilitar el boton aceptar 
                If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                    apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                    provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                    direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                    nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                    nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                    generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                    aceptarRegistroBtn.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub buscarporCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles buscarporCmb.SelectedIndexChanged
        'Visualiza los controles a mostrar segun lo que desea buscar el usuario
        If (buscarporCmb.Text = "# de veces que asistio al comedor") Then
            carnetConsultaLbl.Visible = True
            consultaConsultaTxt.Visible = True
            fechaConsultaLbl.Visible = False
            consultaConsultaDtp.Visible = False
        ElseIf (buscarporCmb.Text = "Cantidad de estudiantes que asistieron al comedor") Then
            fechaConsultaLbl.Visible = True
            consultaConsultaDtp.Visible = True
            carnetConsultaLbl.Visible = False
            consultaConsultaTxt.Visible = False
        End If
    End Sub

    Private Sub salirConsultaBtn_Click(sender As Object, e As EventArgs) Handles salirConsultaBtn.Click
        'Sale de la aplicacion al presionar el boton
        Application.Exit()
    End Sub

    Private Sub salirComedorBtn_Click(sender As Object, e As EventArgs) Handles salirComedorBtn.Click
        'Sale de la aplicacion al presionar el boton
        Application.Exit()
    End Sub

    Private Sub aceptarComedorBtn_Click(sender As Object, e As EventArgs) Handles aceptarComedorBtn.Click 
        Try
            'Intenta hacer una conexion a la DB
            oConexion.Open()
        Catch ex As Exception
            'Lanza el siguiente mensaje si no puede conectarse
            MessageBox.Show("Error al conectar", "Comedor")
        End Try
        Try
            'Realiza la consulta de los dias 
            sSql = "SELECT * FROM estudiantes_tb WHERE carnet='" & carnetComedorTxt.Text & "';"
            oDataAdapter = New MySqlDataAdapter(sSql, oConexion)
            oDataSet.Clear()
            oDataAdapter.Fill(oDataSet, "estudiantes_tb")
            If (carnetComedorTxt.Text = "") Then
                MessageBox.Show("Campos en blanco", "Comedor")
            ElseIf (oDataSet.Tables("estudiantes_tb").Rows.Count <> 0) Then
                Dim fechaActual As Date = Today
                sSql = "INSERT INTO Registros_TB (carnet, fecha) VALUES('" & carnetComedorTxt.Text & "','" & fechaActual.ToString("yyyy-MM-dd HH:MM:SS") & "');"
                Dim oComando As New MySqlCommand(sSql, oConexion)
                oComando.ExecuteNonQuery()
                carnetComedorTxt.Text = ""
                carnetComedorTxt.Focus()
            Else

            End If
        Catch ex As Exception
            MessageBox.Show("Error al insertar los datos", "Comedor")
        End Try
    End Sub

    Private Sub consultaBtn_Click(sender As Object, e As EventArgs) Handles consultaBtn.Click
        sSql = "Select cedula.estudiantes_tb AS Cedula, carnet.estudiantes_tb AS Carnet, " &
               "(apellido1.estudiantes_tb, apellido2.estudiantes_tb, nombre.estudiantes_tb)" &
               "AS Nombre_Estudiante, genero.estudiants_tb AS Genero, seccion.estudiantes_tb AS Seccion," &
               "COUNT(registro) Numero_de_veces_aplicada_la_beca" &
               "FROM estudiantes_tb, registros_tb" &
               "WHERE carnet =" & consultaConsultaTxt.Text & ";"


        sSql = "Select Fecha, COUNT(registro) AS Cantidad de becas" &
               "FROM Resgistro_TB" &
               "WHERE fecha = " & consultaConsultaDtp.Value & ";"
    End Sub

    Private Sub nivelRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles nivelRegistroCmb.SelectedIndexChanged
        Select Case (nivelRegistroCmb.Text)
            Case "7° año"
                seccionRegistroCmb.Items.Clear()
                seccionRegistroCmb.Items.Add("7-1")
                seccionRegistroCmb.Items.Add("7-2")
                seccionRegistroCmb.Items.Add("7-3")
                seccionRegistroCmb.Items.Add("7-4")
                seccionRegistroCmb.Items.Add("7-5")
                seccionRegistroCmb.Items.Add("7-6")
            Case "8° año"
                seccionRegistroCmb.Items.Clear()
                seccionRegistroCmb.Items.Add("8-1")
                seccionRegistroCmb.Items.Add("8-2")
                seccionRegistroCmb.Items.Add("8-3")
                seccionRegistroCmb.Items.Add("8-4")
                seccionRegistroCmb.Items.Add("8-5")
            Case "9° año"
                seccionRegistroCmb.Items.Clear()
                seccionRegistroCmb.Items.Add("9-1")
                seccionRegistroCmb.Items.Add("9-2")
                seccionRegistroCmb.Items.Add("9-3")
                seccionRegistroCmb.Items.Add("9-4")
            Case "10° año"
                seccionRegistroCmb.Items.Clear()
                seccionRegistroCmb.Items.Add("10-1")
                seccionRegistroCmb.Items.Add("10-2")
                seccionRegistroCmb.Items.Add("10-3")
            Case "11° año"
                seccionRegistroCmb.Items.Clear()
                seccionRegistroCmb.Items.Add("11-1")
                seccionRegistroCmb.Items.Add("11-2")
                seccionRegistroCmb.Items.Add("11-3")
            Case "12° año"
                seccionRegistroCmb.Items.Clear()
                seccionRegistroCmb.Items.Add("12-1")
                seccionRegistroCmb.Items.Add("12-2")
                seccionRegistroCmb.Items.Add("12-3")
        End Select
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub cedulaRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles cedulaRegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub carnetRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles carnetRegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub nombreRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles nombreRegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub apellido1RegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles apellido1RegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub apellido2RegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles apellido2RegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub generoRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles generoRegistroCmb.SelectedIndexChanged
        Try
            Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
            If fechaNac >= 6570 Then
                If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                    apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                    provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                    direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                    nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                    aceptarRegistroBtn.Enabled = True
                End If
            Else
                If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                    apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                    provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                    direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                    nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                    nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                    generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                    aceptarRegistroBtn.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub provinciaRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles provinciaRegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub cantonRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles cantonRegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub distritoRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles distritoRegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub direccionRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles direccionRegistroTxt.TextChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub especialidadRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles especialidadRegistroCmb.SelectedIndexChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub becadoRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles becadoRegistroCmb.SelectedIndexChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub seccionRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles seccionRegistroCmb.SelectedIndexChanged
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub fotoRegistroPb_Click(sender As Object, e As EventArgs) Handles fotoRegistroPb.Click
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If fechaNac >= 18 Then
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            If (cedulaRegistroTxt.Text <> "" Or carnetRegistroTxt.Text <> "" Or nombreRegistroTxt.Text <> "" Or
                apellido1RegistroTxt.Text <> "" Or apellido2RegistroTxt.Text <> "" Or generoRegistroCmb.Text <> "" Or
                provinciaRegistroTxt.Text <> "" Or cantonRegistroTxt.Text <> "" Or distritoRegistroTxt.Text <> "" Or
                direccionRegistroTxt.Text <> "" Or especialidadRegistroCmb.Text <> "" Or becadoRegistroCmb.Text <> "" Or
                nivelRegistroCmb.Text <> "" Or seccionRegistroCmb.Text <> "" Or fotoRegistroPb.ImageLocation <> "" Or
                nombreEncargado1Txt.Text = "" Or apellido1Encargado1Txt.Text = "" Or apellido2Encargado1Txt.Text Or
                generoEncargado1Cmb.Text = "" Or relacionEncargado1Txt.Text = "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub
End Class
