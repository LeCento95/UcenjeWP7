select * from smjerovi;

-- minimalna select naredba
select 1;

-- FILTRIRANJE KOLONA (između select i from)
-- select * sve kolone
-- naziv kolone
-- konstatna
-- izraz

-- as (redefinira naziv kolone)
select *, naziv, 1 as iznos, getdate() as datum from smjerovi;

select naziv as predmet, getdate() as datumpocetka from smjerovi;

select sifra, naziv from smjerovi;

select ime, prezime from polaznici;

-- FILTRIRANJE REDOVA
-- ide u where dio
-- operatori
-- uspoređivanja: =(uspoređivanje vrijednosti), 
select * from smjerovi where sifra=1;
--                !(dobije se sve osim traženog)
select * from smjerovi where sifra!=1;
--                <(dobije se 1 i 2 )
select * from smjerovi where sifra<3;
--                >(dobije se od 2 na dalje)
select * from smjerovi where sifra>2;
--               <=(dobije se taj broj i na više)
select * from smjerovi where sifra<=3;
--               >=(dobije se taj broj i na manje)
select * from smjerovi where sifra>=3;
-- logički operatori: and, or, not
select * from smjerovi
where sifra>1 and sifra<4; -- dobije se 2 i 3
select * from smjerovi
where sifra=1 or sifra=4;  -- dobije se 1 i 4
select * from smjerovi
where not (sifra =1 or sifra=4); -- dobije se 2 i 3
-- ostali operatori: like je slično(% za bilo koji znak)
--              npr. like S% izbaciti će sve nazive koja počinju na S                                                         
--              npr. like %a izbaciti će sve nazive koji završavaju na a
--              npr. like %an% izbaciti će sve nazive koji u sebi imaju ova slova an
select * from polaznici
where prezime like'%an%';

-- s najmajnom greškom ispišite sve polaznice
select * from polaznici
where ime like '%a';

-- ostali operatori: between (zamjena za and)
--                   najčešće se koristi pri datumima
select * from polaznici where sifra>=10 and sifra<=15;
select * from polaznici where sifra between 10 and 15;

-- Postavite da 3 smjera započinju u različitim
-- mjesecima: siječanj, travanj, listopad, prosinac

select * from smjerovi;

update smjerovi set izvodiseod='2024-01-17 18:30' 
where sifra = 2;
update smjerovi set izvodiseod='2024-04-19 18:30' 
where sifra = 3;
update smjerovi set izvodiseod='2024-10-26 18:30' 
where sifra = 4;

-- izlistajte sve smjerove koji počinju u prvoj polovini 2024 g.

select * from smjerovi 
where izvodiseod between '2021-01-01' and '2024-06-30'

use knjiznica;

-- slaganje rezultata
select prezime, ime from autor order by prezime asc, ime desc;
select prezime, ime from autor order by 1 asc, 2 desc;

-- ograničavanje rezultata
select top 10 * from autor; -- izbaci samo top 10 rez

select top 10 percent * from autor; -- izbaci 10% rez.

select top 10 * from mjesto;

-- rezultate select naredbe možemo spremiti u novu tablicu

select top 10 * into nova from mjesto;

select * from nova;
drop table nova; -- brisanje tablice

-- unesite sebe kao autora
select top 10 * from autor -- order by sifra; (order ide po pk)
insert into autor (sifra, ime, prezime, datumrodenja) values
(4,'Stojan', 'Carić', '1995-10-25');

-- Mladi Perica boluje jer ga je ostavila cura
-- Što bi mu preporučili da čita iz Vaše knjižnice

select count(*) from katalog; -- koliko ima zapisa

select * from katalog
where naslov like '%ljubav%' and
sifra in (2541, 2660, 2664, 2938);

-- koliko ima izdavača koji su društvo s ograničenom odgovornošću

select count(*) from izdavac;
select * from izdavac
where naziv like '%d%o%o%';

use svastara;
select count(*) from Artikli;

