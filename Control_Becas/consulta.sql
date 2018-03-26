CREATE DATABASE Prueba_DB;
USE Prueba_DB;
CREATE TABLE Estudiantes_TB(
	cedula VARCHAR(20) NOT NULL,
	carnet VARCHAR(25) NOT NULL,
	nombre VARCHAR(20) NOT NULL,
	apellido1 VARCHAR(20) NOT NULL,
	apellido2 VARCHAR(20) NOT NULL,
	fnacimiento DATE NOT NULL,
	genero VARCHAR(10) NOT NULL,
	provincia VARCHAR(50) NOT NULL,
	canton VARCHAR(50) NOT NULL,
	distrito VARCHAR(50) NOT NULL,
	direccion VARCHAR(100) NOT NULL,
	especialidad VARCHAR(15) NOT NULL,
	becado VARCHAR(2) NOT NULL,
	nivel VARCHAR(2) NOT NULL,
	seccion VARCHAR(5) NOT NULL,
	foto lONGBLOB NOT NULL,
	nombreEncargado1 VARCHAR(20) NULL,
	apellido1Encargado1 VARCHAR(25) NULL,
	apellido2Encargado1 VARCHAR(25) NULL,
	generoEncargado1 VARCHAR(10) NULL,
	relacionEncargado1 VARCHAR(10) NULL,
	nombreEncargado2 VARCHAR(20) NULL,
	apellido1Encargado2 VARCHAR(25) NULL,
	apellido2Encargado2 VARCHAR(25) NULL,
	generoEncargado2 VARCHAR(10) NULL,
	relacionEncargado2 VARCHAR(10) NULL,
	PRIMARY KEY (carnet)
);
CREATE TABLE Usuarios_TB(
	id_usuario NUMERIC(5) NOT NULL,	
	usuario VARCHAR(20) NOT NULL,
	pass VARCHAR(10) NOT NULL,
	tipo VARCHAR(15) NOT NULL,
	PRIMARY KEY (id_usuario)
);
CREATE TABLE Notas_TB(
	id_registro INT AUTO_INCREMENT,
	carnet VARCHAR(25) NOT NULL,
	cedula VARCHAR(20) NOT NULL,
	español NUMERIC(3) NOT NULL,
	matematicas NUMERIC(3) NOT NULL,
	est._sociales NUMERIC(3) NOT NULL,
	civica NUMERIC(3) NOT NULL,
	ciencias NUMERIC(3) NOT NULL,
	biologia NUMERIC(3) NOT NULL,
	quimica NUMERIC(3) NOT NULL,
	fisica_mate NUMERIC(3) NOT NULL,
	ingles NUMERIC(3) NOT NULL,
	psicologia NUMERIC(3) NOT NULL,
	educ._hogar NUMERIC(3) NOT NULL,
	artes_indus NUMERIC(3) NOT NULL,
	musica NUMERIC(3) NOT NULL,
	
	PRIMARY KEY (registro),
	FOREIGN KEY (carnet) REFERENCES Estudiantes_TB (carnet),
	FOREIGN KEY (cedula) REFERENCES Estudiantes_TB (cedula),

);
CREATE TABLE Comedor_TB(
	id_registro NUMERIC(5) AUTO_INCREMENT,
	carnet VARCHAR(25) NOT NULL,
	fecha DATETIME NOT NULL,
	PRIMARY KEY (registro),
	FOREIGN KEY (carnet) REFERENCES Estudiantes_TB (carnet)
);