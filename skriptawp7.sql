use master;
go
drop database if exists edunovawp7;

create database edunovawp7;
go
use edunovawp7;
go

create table smjerovi(
sifra int,
naziv varchar (50),
trajanje int,
cijena decimal (18,2),
vaucer bit,
izvodi_se_od datetime
);