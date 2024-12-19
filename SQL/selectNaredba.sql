select * from smjerovi;

select 1;

select *, naziv, 1 as iznos, getdate() as datum from smjerovi;

select naziv as predmet, getdate() as datumpocetka from smjerovi;

select sifra, naziv from smjerovi;

select ime, prezime from polaznici;

select * from smjerovi 
where not (sifra=1 or sifra=4);

select * from polaznici
where prezime like '%an%';

select * from polaznici where ime like '%a';

select * from polaznici where sifra>=10 and sifra<=15;

select * from polaznici where sifra between 10 and 15;


select * from polaznici where sifra=10 or sifra=15 or sifra=1;
select * from polaznici where sifra in (10,15,1);


select * from smjerovi;

update smjerovi set izvodiseod='2024-01-15 19:00:00'
where sifra=2;

update smjerovi set izvodiseod='2024-04-15 19:00:00'
where sifra=3

update smjerovi set izvodiseod='2024-10-15 19:00:00'
where sifra=4


select * from smjerovi
where izvodiseod between '2024-01-01' and '2024-06-30'

