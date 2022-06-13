create database base9

use base9


create table Alumnos(
idAlumnos int identity(1,1) primary key,
Carnet varchar(50) not null,
Nombres varchar(50) NOT NULL,
Apellidos varchar(50) NOT NULL,
Direccion varchar(150) NOT NULL,
Sexo varchar(9) NOT NULL,
Telefono varchar(15) NULL,
Email varchar(50) NOT NULL,
);

insert into Alumnos(Carnet,Nombres,Apellidos,Direccion,Sexo,Telefono,Email) values
('2717212020','Juana Ana','Orellana Juarez','Santa Tecla, La Libertad, Residencial Alpez','Femenino','79896050','juana@dudev.com'),
('2517212021','Gerson Orlando','Deodanes Benito','Santa Tecla, La Libertad, Residencial Alpez','Masculino','77958475','mdeodanes@dudev.com'),
('2617212022','Mario Douglas','Deodanes Benito','Santa Tecla, La Libertad, Residencial Alpez','Masculino','77956688','gdeodanes@dudev.com'),
('2717212023','Flor Mariela','Deodanes Benito','Santa Tecla, La Libertad, Residencial Alpez','Femenino','79989090','fdeodanes@dudev.com')


select * from Alumnos

create table Docentes(
idDocente int identity(1,1) primary key,
codigoDocente varchar(50) not null,
nombre varchar(50) not null,
apellido varchar(50) not null,
especialidad varchar(150) not null,
titulo varchar(50) not null
);

insert into Docentes(codigoDocente, nombre,apellido,especialidad,titulo) values
('10303040','Mario Douglas','Deodanes Benito','Redes','Ingenieria en redes Informaticas'),
('10303041','Gerson Orlando','Deodanes Benito','Programacion','Ingenieria en sistemas Informaticos'),
('10303042','Flor Mariela','Deodanes Bneito','Bases de datos','Ingenieria en sistemas'),
('10303043','Ana Banana','Deodanes','DevOps','Ingenieria en redes computacion')


select * from Docentes
select * from Alumnos

delete Docentes where codigoDocente=1060

create table Materias(
codMateria varchar(8) primary key not null,
nombre varchar(50) not null,
unidadValorativas int not null,
);

insert into Materias(codMateria,nombre,unidadValorativas) values('0005','Programacion II','04'),
																('0007','Redes de datos I','05'),
																('0003','Bases de datos II','03')
select * from Materias
delete Materias where codMateria=001

create table Notas(
idNotas int primary key identity(1,1),
codMateria varchar(12) not null,
carnetEstudiante varchar(12) not null,
notaObtenida varchar(5) not null,
estado varchar(10) not null
)

insert into Notas(codMateria,carnetEstudiante,notaObtenida,estado) values('001','2517212020','8','Aprobado'),
																		('002','2518212021','5','Reprobado')