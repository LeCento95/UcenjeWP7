use master;
go
drop database if exists ERA_Vjezba1;
go
create database ERA_Vjezba1;
go
use ERA_Vjezba1;

create table IspitniRok(
sifra int not null primary key identity (1,1), --da se ide 1 za 1
predmet varchar (50) not null,
trajanje int not null,
izvodi_se_od datetime null, -- null se ne mora pisati
pristupio bit not null,
);

create table Pristupnici (
ispitni_rok int not null references IspitniRok(sifra),
student varchar (50) not null,
broj_bodova varchar (100) not null,
ocijena varchar (50)
);