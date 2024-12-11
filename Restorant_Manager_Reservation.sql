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
kapacitet int not null,
lokacija varchar (50) not null
);

create table meni (
sifra int primary key identity (1,1) not null,
naziv_jela varchar (100) not null,
cijena decimal (10,2) not null,
kategorija varchar (50) not null
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
rezervacija int not null references rezervacije(sifra),
meni int not null references meni(sifra)
);

select * from stolovi;
insert into stolovi (kapacitet, lokacija)
values
(2, 'A 1'),
(4, 'A 2');

select * from meni;
insert into meni (naziv_jela, cijena, kategorija)
values
('Pizza Slavonska', 14.00, 'Pizza'),
('Sarma', 9.00, 'Zimska jela');

select * from rezervacije;
insert into rezervacije (datum, broj_osoba, stol, ime_gosta)
values
('2024-12-10', 4, 2, 'Tomislav Jakopec'),
('2024-12-12', 2, 4, 'Nikola Nikolić');

select * from narudzba;
insert into narudzba (rezervacija, meni)
values
(1, 1), -- rezervacija 1, pizza slavonska
(1, 3); -- rezervacija 1, sarma

select * from stolovi;
select * from meni;
select * from rezervacije;
select * from narudzba;