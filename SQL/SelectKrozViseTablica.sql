select b.naziv as grupa, a.naziv as smjer, b.predavac
from smjerovi a inner join grupe b
on a.sifra = b.smjer;


select a.naziv, b.naziv as grupa, b.predavac
from smjerovi a left join grupe b
on a.sifra = b.smjer;

update grupe set predavac='Karla Let' where sifra=4;

select b.naziv as grupa, 
a.naziv as smjer,
d.ime, d.prezime
from smjerovi a 
inner join grupe b on a.sifra=b.smjer
inner join clanovi c on b.sifra=c.grupa
inner join polaznici d on d.sifra=c.polaznik;

select * from smjerovi;

use knjiznica;

-- izlistaj ime i prezime autora, naslov, izdavač i mjesto izdavanja
-- concat spajanje dvije kolone u jednu
select concat( a.ime, '', a.prezime) as autor,
b.naslov, c.naziv as izdavac,
d.naziv as mjesto
from autor a
inner join katalog b on a.sifra = b.autor
inner join izdavac c on c.sifra = b.izdavac
inner join mjesto d on d.sifra = b.mjesto
where a.ime like 'I%'
order by a.prezime;

-- alternativa
select autor.ime, autor.prezime,
katalog.naslov, izdavac.naziv as izdavac,
mjesto.naziv as mjesto
from autor
inner join katalog on autor.sifra = katalog.autor
inner join izdavac on izdavac.sifra = katalog.izdavac
inner join mjesto on mjesto.sifra = katalog.mjesto;

use svastara;

select a.dugiNaziv, b.cijena, b.kolicina,
b.cijena * b.kolicina as vrijednost
from Artikli a
inner join ArtikliNaPrimci b on a.sifra = b.artikl
inner join Primke c on c.sifra = b.primka
where c.redniBroj='1/2008';

select sum(b.cijena * b.kolicina) as vrijednost
from Artikli a
inner join ArtikliNaPrimci b on a.sifra = b.artikl
inner join Primke c on c.sifra = b.primka
where c.redniBroj='1/2008';

select c. redniBroj,
d.naziv,
sum(b.cijena * b.kolicina) as vrijednost
from Artikli a
inner join ArtikliNaPrimci b on a.sifra = b.artikl
inner join Primke c on c.sifra = b.primka
inner join Dobavljaci d on c.dobavljac=d.sifra
group by c.redniBroj, d.naziv
having sum(b.cijena * b.kolicina)>13000000
order by 2 desc;

-- podupit

select count(*) from Artikli; -- 52601
select distinct artikl from ArtikliNaPrimci;  -- 52599

select * from artikli where sifra not in(
select distinct artikl from ArtikliNaPrimci
);

delete from Artikli where sifra in (79102, 90661);





