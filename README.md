# TLDLoggerProject

The idea of this Project is to create Itemlogger for the game The Long Dark, its mainly for myselft and my learning journey to coding and the code c#

DataStructure
Se on sellainen tavaran kirjaud järjestelmä.
Eli valitsen tavaran ja annansille ominaisuuksia (esim: päiväys, kunto)  ja kirjaan sen järjestelmään/databaseen
Sitten se listaa kaikki tavarat mitä olen listannut

luon tavarataulukon johon listaan kaikki tavarat
se tavara minkä listaa on ennaltamäärätyltä tietokannalta haettava jossa sillä tavaralla on lisää ominaisuuksia
tavaroilla voi olla useampi ominaisuus
(esimerkkinä ominaisuuksista voisi olla: vaatteet ja ruoka, vaatteet: vaatten koko, vaatteen malli, ja ruualle: pilaantumis pv ja valmistus pv)

Teen jokaiselle ominaisuudelle omantaulukon esim. tKoko(jossa kerrotaan vaatteen koko) (joihinkin ominaisuustaulukkoihin voi kuulua myösuseampi ominaisuus)

luon myös ominaisuustaulukon jossa on kaikkien eriominaisuustaulukoiden nimet
sitten luon taulukon jossa on tavarakey ja ominaisuustaulukonKey jossa sillä tavaralla on ominaisuuksia ja hakemalla tämän taulukon voin pyytä kaikki ominaisuudet jotka kuuluvat sille tavaralle.

Sitten tarvitsen kategoria taulukon 
ja sitten tarvtitsen taulukon johon tulee tavaraKey ja Kategoria Key
Kategoriakeylla voi listata kaikki samaan kategoriaan kuuluvata tavarat

Sitten tarvitsen näkymätaulukon
ja sitten tarvtitsen taulukon johon tulee tavaraKey ja näkymäKey
Näkymä taulukossa on vain numero joka kertoon mitä kaikkean tulee listata kun katsotaan omia tavaroita


# Roadmap

This is the roadmap for LoggerProject for learnign purposes

Done - Database structure for all TLD items

- Create SQL database querying and system for that

- Create a VIEW that shows your added inventory

- Create a nice GUI

- Create Todo tasklist app for planning

- Create an overlay so you do not have to alt tab

- Sql quering system beta 001 working it needs:
  comments
  cleaning up code
  checks to see if data is valid
  exeption catchers

- inventory view beta 001 id done as well, work needs:
  comments
  nice gui
  specified method for displaying vInventory
