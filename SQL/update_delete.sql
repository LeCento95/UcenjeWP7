-- update naredba briše podatke iz tablice
select * from smjerovi where sifra=2;

update smjerovi
set trajanje=300
where sifra=2;


-- menjanje vise kolona (serviser)
update smjerovi
set trajanje=200, cijena=1000, vaucer=0
where sifra=3;
update smjerovi set cijena = 1244.99 where sifra=1;
update smjerovi set cijena = 999 where sifra=2;
update smjerovi set cijena = 1000 where sifra =3;
update smjerovi set cijena = 777.55 where sifra=4;

-- uvećanje cijene za 10 posto
select * from smjerovi;
update smjerovi set cijena = cijena * 1.1;
select * from smjerovi;

-- umanjenje cijene za 10 €
select * from smjerovi;
update smjerovi set cijena = cijena - 10;
select * from smjerovi;

-- promjenjivanje početka izvođenja
select * from smjerovi;
update smjerovi set izvodiseod = '2024-10-02 18:30:00'
where sifra = 3;

-- delete naredba briše podatke iz tablice

-- delete briše samo redove iz tablice
-- briše cijeli red

delete smjerovi where sifra = 1;

select * from grupe;

delete grupe where smjer = 1;

delete from clanovi where grupa = 2;

-- dodati sebi omiljenu osobu

select * from polaznici;
insert into polaznici (ime, prezime, email) values
('Nikolina', 'Renčić', 'nikolinarencic@gmail.com');

-- promjeniti OIB omiljenoj osobi na 64733268826

update polaznici set oib = '64733268826'
where sifra = 29;

-- obrisati omiljenu osobu kao polaznika

delete from polaznici where sifra = 29;










