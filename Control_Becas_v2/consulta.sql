CREATE DATABASE SBCT_DB;
USE SBCT_DB;
CREATE TABLE Usuarios_TB(
    id_usuario NUMERIC AUTO_INCREMENT,
    usuario VARCHAR(20) NOT NULL,
    nombre VARCHAR(20) NOT NULL,
    apellido1 VARCHAR(20) NOT NULL,
    apellido2 VARCHAR(20) NOT NULL,
    pass VARCHAR(10) NOT NULL,
    tipo VARCHAR(15) NOT NULL,
    PRIMARY KEY (id_usuario)
);
CREATE TABLE Estudiantes_TB(
    cedula VARCHAR(20) NOT NULL,
    nombre VARCHAR(20) NOT NULL,
    apellido1 VARCHAR(20) NOT NULL,
    apellido2 VARCHAR(20) NOT NULL,
    fnacimiento DATE NOT NULL,
    genero VARCHAR(9) NOT NULL,
    provincia VARCHAR(11) NOT NULL,
    canton VARCHAR(25) NOT NULL,
    distrito VARCHAR(25) NOT NULL,
    direccion VARCHAR(50) NOT NULL,
    especialidad VARCHAR(25) NOT NULL,
    becaComedor VARCHAR(2) NOT NULL,
    becaTransporte VARCHAR(2) NOT NULL,
    nivel VARCHAR(2) NOT NULL,
    seccion VARCHAR(6) NOT NULL,
    foto lONGBLOB NOT NULL,
    nombreEncargado1 VARCHAR(20) NULL,
    apellido1Encargado1 VARCHAR(25) NULL,
    apellido2Encargado1 VARCHAR(25) NULL,
    cedulaEncargado1 VARCHAR(20) NULL,
    generoEncargado1 VARCHAR(9) NULL,
    relacionEncargado1 VARCHAR(10) NULL,
    nombreEncargado2 VARCHAR(20) NULL,
    apellido1Encargado2 VARCHAR(25) NULL,
    apellido2Encargado2 VARCHAR(25) NULL,
    cedulaEncargado2   VARCHAR(20) NULL,
    generoEncargado2 VARCHAR(9) NULL,
    relacionEncargado2 VARCHAR(10) NULL,
    PRIMARY KEY (cedula)
);
CREATE TABLE Comedor_TB(
    id_registro NUMERIC AUTO_INCREMENT,
    cedula VARCHAR(20) NOT NULL,
    fecha DATETIME NOT NULL,
    PRIMARY KEY (id_registro),
    FOREIGN KEY (cedula) REFERENCES Estudiantes_TB (cedula)
);
CREATE TABLE Transporte_TB(
    id_registro NUMERIC AUTO_INCREMENT,
    cedula VARCHAR(20) NOT NULL,
    fecha DATETIME NOT NULL,
    PRIMARY KEY (id_registro),
    FOREIGN KEY (cedula) REFERENCES Estudiantes_TB (cedula)
);
/*
CREATE TABLE Notas_TB(
    id_registro INT AUTO_INCREMENT,
    carnet VARCHAR(25) NOT NULL,
    cedula VARCHAR(20) NOT NULL,
    español NUMERIC(3) NOT NULL,
    matematicas NUMERIC(3) NOT NULL,
    est_sociales NUMERIC(3) NOT NULL,
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
    PRIMARY KEY (id_registro),
    FOREIGN KEY (carnet) REFERENCES Estudiantes_TB (carnet),
    FOREIGN KEY (cedula) REFERENCES Estudiantes_TB (cedula),
);
*/