use master;
go
drop database if exists Restorant_Manager_Reservation;
go
create database Restorant_Manager_Reservation collate Croatian_CI_AS;
go
use Restorant_Manager_Reservation;
go

create table Stolovi (
stol_sifra int primary key identity (1,1) not null,
kapacitet int,
lokacija varchar (50)
);

create table Meni (
meni_sifra int primary key identity (1,1) not null,
jela varchar (100),
cijena decimal (10,2),
kategorija varchar (50)
);

create table Rezervacije (
rezervacija_sifra int primary key identity (1,1) not null,
datum_vrijeme datetime,
broj_osoba int,
ime_gosta varchar (100),
stol_sifra int,
foreign key (stol_sifra) references stolovi(stol_sifra)
);

create table Narudzba (
narudzba_sifra int primary key identity (1,1) not null,
kolicina int,
stol_sifra int,
meni_sifra int,
foreign key (stol_sifra) references stolovi(stol_sifra),
foreign key (meni_sifra) references meni(meni_sifra)
);

insert into Stolovi (stol_sifra, kapacitet, lokacija)
values (11, 6, 'Kamin');

insert into Meni (meni_sifra, cijena, kategorija)
values ('Pica Slavonska', 12.00, 'Pizza');

insert into Rezervacije (datum_vrijeme, broj_osoba, ime_gosta, stol_sifra)
VALUES ('2024-12-12 19:00:00', 4, 'Tomislav Jakopec', 10);

insert into Narudzba (stol_sifra, meni_sifra, kolicina)
select 10, meni_sifra, 2
from Meni
where jela = 'Pica Slavonska'