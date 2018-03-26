'Incluir libreria para utilizar puertos seriales
Imports System.IO.Ports

Public Class frmPrincipal
    Sub resetCampos() 'Limpiar campos del formulario
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
        fotoRegistroPb.Image = Nothing
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

    Sub habilitarEnvio() 'Verifica que todos los campos segun correspondan esten llenos para habilitar el boton Aceptar
        'Obtiene la cantidad de dias de vida de la persona segun su fecha de nacimiento
        Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
        If (fechaNac >= 6570) Then
            'Si la persona es mayor de edad
            If (cedulaRegistroTxt.Text <> "" And carnetRegistroTxt.Text <> "" And nombreRegistroTxt.Text <> "" And
                apellido1RegistroTxt.Text <> "" And apellido2RegistroTxt.Text <> "" And generoRegistroCmb.Text <> "" And
                provinciaRegistroTxt.Text <> "" And cantonRegistroTxt.Text <> "" And distritoRegistroTxt.Text <> "" And
                direccionRegistroTxt.Text <> "" And especialidadRegistroCmb.Text <> "" And becadoRegistroCmb.Text <> "" And
                nivelRegistroCmb.Text <> "" And seccionRegistroCmb.Text <> "" And fotoRegistroPb.Image Is Nothing) Then
                aceptarRegistroBtn.Enabled = True
            End If
        Else
            'Si la persona es menor de edad 
            If (cedulaRegistroTxt.Text <> "" And carnetRegistroTxt.Text <> "" And nombreRegistroTxt.Text <> "" And
                apellido1RegistroTxt.Text <> "" And apellido2RegistroTxt.Text <> "" And generoRegistroCmb.Text <> "" And
                provinciaRegistroTxt.Text <> "" And cantonRegistroTxt.Text <> "" And distritoRegistroTxt.Text <> "" And
                direccionRegistroTxt.Text <> "" And especialidadRegistroCmb.Text <> "" And becadoRegistroCmb.Text <> "" And
                nivelRegistroCmb.Text <> "" And seccionRegistroCmb.Text <> "" And fotoRegistroPb.ImageLocation <> "" And
                nombreEncargado1Txt.Text <> "" And apellido1Encargado1Txt.Text <> "" And apellido2Encargado1Txt.Text <> "" And
                identificacionEncargado1Txt.Text <> "" And nacionalidadEncargado1Txt.Text <> "" And
                generoEncargado1Cmb.Text <> "" And relacionEncargado1Txt.Text <> "") Then
                aceptarRegistroBtn.Enabled = True
            End If
        End If
    End Sub

    Private Sub buscarPuerto() 'Obtiene los dispositivos conectados a la computadora por medio de puertos seriales
        Try
            'Limpia el combobox de los puertos seriales para evitar que se muestren dispositivos repetidos
            puertoCmb.Items.Clear()
            'Agrega todos los dispositivos detectados de la computadora al combobox
            For Each puerto As String In My.Computer.Ports.SerialPortNames
                puertoCmb.Items.Add(puerto)
            Next
            'Si la lista no esta vacia muestra el primer dispositivo en el combobox
            If puertoCmb.Items.Count > 0 Then
                puertoCmb.SelectedIndex = 0
            Else
                'Si no le indica al usuario que conecte el lector
                MsgBox("Por favor conectar el dispositivo lector")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Muestra la fecha actual en los campos de fecha
        fnacimientoRegistroDtp.Value = Now
        consultaDtp.Value = Now
        'Ejecuta la funcion de buscar puertos
        buscarPuerto()
    End Sub
    Private Sub cancelarBtn_Click_1(sender As Object, e As EventArgs) Handles salirRegistroBtn.Click
        'Cierra la aplicacion
        Application.Exit()
    End Sub

    Private Sub aceptarBtn_Click(sender As Object, e As EventArgs) Handles aceptarRegistroBtn.Click
        'Limpia los campos de texto del formulario
        resetCampos()
        'Escribe la palabra CORRECTO en el formulario si se insertaron bien los datos
        correctoLbl.Text = "CORRECTO"
    End Sub

    Private Sub borrarBtn_Click_1(sender As Object, e As EventArgs) Handles borrarRegistroBtn.Click
        'Limpia los campos de texto en el formulario
        resetCampos()
    End Sub

    Private Sub fnacimientoDtp_ValueChanged(sender As Object, e As EventArgs) Handles fnacimientoRegistroDtp.ValueChanged
        Try
            'Extrae la diferentes entre la fecha actual y la fecha de nacimiento de la persona y la convierte en dias
            Dim fechaNac As Integer = Now.Date.Subtract(Me.fnacimientoRegistroDtp.Value.Date).Days
            'Si la persona es menor de edad se despliega la informacion de los encargados
            If (fechaNac < 6570) Then 'Si la persona es menor a 6570 dias (18 años)
                encargado1GB.Visible = True
                encargado2GB.Visible = True
                mostrarEncargadosBtn.Visible = False
                ocultarEncargadosBtn.Visible = False
            Else
                'Si no la oculta pero muestra un boton para desplegar dicha informacion de nuevo en caso de ser necesaria
                encargado1GB.Visible = False
                encargado2GB.Visible = False
                mostrarEncargadosBtn.Visible = True
                mostrarEncargadosBtn.Enabled = True
                ocultarEncargadosBtn.Visible = False
            End If
            'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
            habilitarEnvio()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub buscarporCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles buscarporCmb.SelectedIndexChanged
        'Visualiza los controles a mostrar segun lo que desea buscar el usuario
        'If (buscarporCmb.Text = "# de veces que asistio al comedor") Then
        '    carnetConsultaLbl.Visible = True
        '    consultaConsultaTxt.Visible = True
        '    fechaConsultaLbl.Visible = False
        '    consultaDtp.Visible = False
        'ElseIf (buscarporCmb.Text = "Cantidad de estudiantes que asistieron al comedor") Then
        '    fechaConsultaLbl.Visible = True
        '    consultaDtp.Visible = True
        '    carnetConsultaLbl.Visible = False
        '    consultaConsultaTxt.Visible = False
        'End If
    End Sub

    Private Sub salirConsultaBtn_Click(sender As Object, e As EventArgs) Handles salirConsultaBtn.Click
        'Sale de la aplicacion al presionar el boton
        Application.Exit()
    End Sub

    Private Sub salirComedorBtn_Click(sender As Object, e As EventArgs) Handles salirComedorBtn.Click
        'Sale de la aplicacion al presionar el boton
        Application.Exit()
    End Sub

    Private Sub nivelRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles nivelRegistroCmb.SelectedIndexChanged
        'Muestra en el combobox de secciones la diferentes secciones segun corresponda el nivel que se ingreso
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
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub cedulaRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles cedulaRegistroTxt.TextChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub carnetRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles carnetRegistroTxt.TextChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub nombreRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles nombreRegistroTxt.TextChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub apellido1RegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles apellido1RegistroTxt.TextChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub apellido2RegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles apellido2RegistroTxt.TextChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub generoRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles generoRegistroCmb.SelectedIndexChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub provinciaRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles provinciaRegistroTxt.TextChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub cantonRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles cantonRegistroTxt.TextChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub distritoRegistroTxt_TextChanged(sender As Object, e As EventArgs) Handles distritoRegistroTxt.TextChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub especialidadRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles especialidadRegistroCmb.SelectedIndexChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub seccionRegistroCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles seccionRegistroCmb.SelectedIndexChanged
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    Private Sub fotoRegistroPb_Click(sender As Object, e As EventArgs) Handles fotoRegistroPb.Click
        'Valida si todos los campos estan debidamente completos para habilitar el boton aceptar
        habilitarEnvio()
    End Sub

    'Si a una persona mayor de edad se le deben ingresar los datos del encargado se pueden mostrar presionando este boton 
    Private Sub mostrarEncargadosBtn_Click(sender As Object, e As EventArgs) Handles mostrarEncargadosBtn.Click
        ocultarEncargadosBtn.Visible = True
        ocultarEncargadosBtn.Enabled = True
        mostrarEncargadosBtn.Visible = False
        encargado1GB.Visible = True
        encargado2GB.Visible = True
    End Sub

    'En caso de que se quiera ocultar el registro de los datos de los encargados se presiona este boton
    Private Sub ocultarEncargadosBtn_Click(sender As Object, e As EventArgs) Handles ocultarEncargadosBtn.Click
        mostrarEncargadosBtn.Visible = True
        mostrarEncargadosBtn.Enabled = True
        ocultarEncargadosBtn.Visible = False
        encargado1GB.Visible = False
        encargado2GB.Visible = False
    End Sub

    'Realiza la conexion o desconexion del lector de tarjetas
    Private Sub conectarBtn_Click(sender As Object, e As EventArgs) Handles conectarBtn.Click
        If conectarBtn.Text = "Desconectar" Then
            conectarBtn.Text = "Conectar"
            spPuerto.Close()
        Else
            Try
                With spPuerto
                    .BaudRate = 9600
                    .DataBits = 8
                    .Parity = IO.Ports.Parity.None
                    .StopBits = 1
                    .PortName = puertoCmb.Text
                    .Open()
                    If .IsOpen Then
                        conectarBtn.Text = "Desconectar"
                    Else
                        MsgBox("Conexion fallida", MsgBoxStyle.Critical)
                    End If
                End With
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    'Permite la repcion de informacion desde el lector de tarjetas
    Sub spPuerto_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles spPuerto.DataReceived
        Dim buffer As String
        buffer = spPuerto.ReadExisting
        carnetRegistroTxt.Text = buffer
    End Sub

    'Abre la ventana para la toma de la fotografia del estudiante
    Private Sub tomarFotoRegistroBtn_Click(sender As Object, e As EventArgs) Handles tomarFotoRegistroBtn.Click
        Me.Hide()
        tomarFotoFrm.Show()
    End Sub
End Class