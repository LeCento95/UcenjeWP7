use master;
go
drop database if exists Restorant_Manager_Reservation;
go
create database Restoran_Manager_Reservation;
go
use Restoran_Manager_Reservation;
go

create table stolovi (
sifra int primary key identity (1,1) not null,
broj_stola int not null,
kapacitet bit not null,
status bit not null
);

create table gosti (
sifra int primary key identity (1,1) not null,
ime varchar (50) not null,
prezime varchar (50) not null,
telefon varchar (20) not null,
e_mail varchar (50) not null
);

create table meni (
sifra int primary key identity (1,1) not null,
naziv_jela varchar (50) not null,
cijena decimal (18,2) not null,
kategorija varchar (50) not null
);