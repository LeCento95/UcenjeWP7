use master;
go
drop database if exists Restorant_Manager_Reservation;
go
create database Restorant_Manager_Reservation collate Croatian_CI_AS;
go
use Restorant_Manager_Reservation;
go

create table stolovi (
sifra int primary key identity (1,1) not null,
kapacitet int,
lokacija varchar (50)
);

create table meni (
sifra int primary key identity (1,1) not null,
naziv_jela varchar (100),
cijena decimal (10,2),
kategorija varchar (50)
);

create table rezervacije (
sifra int primary key identity (1,1) not null,
datum datetime not null,
broj_osoba int not null,
stol int not null references stolovi(sifra),
ime_gosta varchar (100) not null
);

create table narudzba (
sifra int primary key identity (1,1) not null,
rezervacija int not null references stolovi(sifra),
meni int not null references meni(sifra)
);

--1
select * from stolovi;
insert into stolovi (kapacitet, lokacija)
values (10, 'Kamin');

--2
select * from meni;
insert into meni (naziv_jela, cijena, kategorija)
values ('Sarma', 9.00, 'Zimska jela');

--3
insert into rezervacije (datum_vrijeme, broj_osoba, stol, ime_gosta)
values ('2024-12-09', 6, 10,'Tomislav Jakopec')

--4
insert into narudzba (rezervacija, meni)
values ()