use master;
go
drop database if exists Restorant_Manager_Reservation;
go
create database Restoran_Manager_Reservation;
go
use Restoran_Manager_Reservation;
go

create table gost (
sifra int primary key identity (1,1) not null,
ime varchar (50) not null,
prezime varchar (50) not null,
telefon varchar (20) null,
e_mail varchar (50)  null
);

create table rezervacija (
sifra int primary key identity (1,1) not null,
datum date not null,
vrijeme time not null,
gost int references gost(sifra) not null,
stol int references stolovi(sifra) not null
);

create table stolovi (
sifra int primary key identity (1,1) not null,
broj_stola int not null,
kapacitet bit not null,
status bit not null
);

create table meni (
sifra int primary key identity (1,1) not null,
naziv_jela varchar (50) not null,
cijena decimal (18,2) not null,
kategorija varchar (50) not null
);

create table narudzba (
sifra int primary key identity (1,1) not null,
kolicina varchar (50) not null,
datum timestamp null,
status bit,
gost int references gosti(sifra) not null,
jelo int references meni(sifra) not null
);