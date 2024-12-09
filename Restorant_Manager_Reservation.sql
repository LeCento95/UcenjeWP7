use master;
go
drop database if exists Restorant_Manager_Reservation;
go
create database Restorant_Manager_Reservation collate Croatian_CI_AS;
go
use Restorant_Manager_Reservation;
go

create table Stolovi (
sifra int primary key identity (1,1) not null,
kapacitet int,
lokacija varchar (50)
);

create table Meni (
sifra int primary key identity (1,1) not null,
jela varchar (100),
cijena decimal (10,2),
kategorija varchar (50)
);

create table Rezervacije (
sifra int primary key identity (1,1) not null,
datum_vrijeme datetime,
broj_osoba int,
ime_gosta varchar (100),
stol int not null references stolovi(sifra)
);

create table Narudzba (
sifra int primary key identity (1,1) not null,
kolicina int,
stol int not null references stolovi(sifra),
meni int not null references Meni(sifra)
);
insert into Stolovi (kapacitet, lokacija)
values (10, 6, 'Kamin');

insert into Meni (meni_sifra, cijena, kategorija)
values ('Pica Slavonska', 12.00, 'Pizza');

insert into Rezervacije (datum_vrijeme, broj_osoba, ime_gosta, stol_sifra)
values ('2024-12-12 19:00:00', 4, 'Tomislav Jakopec', 10);

insert into Narudzba (stol_sifra, meni_sifra, kolicina)
select 10, meni_sifra, 2
from Meni
where jela = 'Pica Slavonska'