use master;
go
drop database if exists Restorant_Manager_Reservation;
go
create database Restoran_Manager_Reservation;
go
use Restoran_Manager_Reservation;
go

create table restoran (
sifra int primary key identity (1,1) not null,
naziv varchar (50) not null,
telefon varchar (20) not null,
e_mail varchar (50) not null,
adresa varchar (50) not null
);

create table gosti (
sifra int primary key identity (1,1) not null,
ime varchar (50) not null,
prezime varchar (50) not null,
telefon varchar (20) not null,
e_mail varchar (50) not null
);

create table kategorije (
sifra int primary key identity (1,1) not null,
naziv varchar (50) not null
);


create table stolovi (
sifra int primary key identity (1,1) not null,
restoran int references restoran(sifra) not null,
kapacitet int not null,
status bit
);

create table rezervacija (
sifra int primary key identity (1,1) not null,
datum date not null,
vrijeme time not null,
gosti int references gosti(sifra) not null,
stolovi int references stolovi(sifra) not null
);

create table meni (
sifra int primary key identity (1,1) not null,
naziv_jela varchar (50) not null,
cijena decimal (18,2) not null,
kategorije int references kategorije(sifra) not null
);

create table narudzba (
sifra int primary key identity (1,1) not null,
kolicina int not null,
rezervacija int references rezervacija(sifra) not null,
meni int references meni(sifra) not null,
status bit
);