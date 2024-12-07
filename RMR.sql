﻿use master;
go
drop database if exists Restorant_Manager_Reservation1;
go
create database Restorant_Manager_Reservation1 collate Croatian_CI_AS;
go
use Restorant_Manager_Reservation1;
go

create table stolovi (
sifra int primary key identity (1,1) not null,
kapacitet int not null,
status bit
);
create table meni (
sifra int primary key identity (1,1) not null,
naziv_jela varchar (50) not null,
cijena decimal (18,2) not null
);

create table rezervacija (
sifra int primary key identity (1,1) not null,
datum date not null,
vrijeme time not null,
stolovi int references stolovi(sifra) not null
);

create table narudzba (
sifra int primary key identity (1,1) not null,
kolicina int not null,
rezervacija int references rezervacija(sifra) not null,
meni int references meni(sifra) not null,
status bit
);
