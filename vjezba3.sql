use master;
go
drop database if exists vjezba3;
go
create database vjezba3;
go

create table IspitniRok(
sifra int,
predmet varchar (50),
trajanje int,
izvodi_se_od datetime,
pristupio bit,
);

create table Pristupnici (
ispitni_rok int,
student varchar (50),
broj_bodova varchar (100),
ocijena varchar (10)
);