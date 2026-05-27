create database db_criarConta;

use db_criarConta;

create table tb_usuario(
Id int primary key auto_increment,
Nome varchar (50) not null,
Email varchar(50) not null,
senha varchar (150),
Nivel varchar (150) default ('Usuario')
);


