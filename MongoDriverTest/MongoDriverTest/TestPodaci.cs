using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.DomainModel;
using MongoDB.Driver;

namespace MongoDriverTest
{
    class TestPodaci
    {
        public static void dodajIgrace()
        {
            try
            {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<Igrac>("igraci");
                var filter = new BsonDocument();

                string punoIme = "";
                string mestoRodjenja = "";
                string datumRodjenja = "";
                string visina = "";
                string trenutniKlub = "";
                string pozicija = "";
                bool pripadaReprezentaciji = false;
                string sportskaBiografija = "";
                string reprezentativnaKarijera = "";
                string statistika = "";
                string trofeji = "";

                Igrac noviIgrac = new Igrac();

                // 1
                punoIme = "Branislav 'Bane' Ivanović";
                mestoRodjenja = "Srbija, Sremska Mitrovica";
                datumRodjenja = " 22.2.1984";
                visina = "1.85";
                trenutniKlub = "Celsi";
                pozicija = "RB";
                sportskaBiografija = "Ivanović je počeo svoju karijeru u Sremu, nakon čega je prešao u OFK Beograd 2003. godine. Dve i po sezone je proveo u Beogradu i odigrao je 55 prvenstvenih utakmica, postigao pet golova i zaradio samo četiri žuta kartona." +
 "U zimskom prelaznom roku 2006. godine, potpisao je ugovor sa Lokomotivom iz Moskve, koju je tada trenirao Slavoljub Muslin. U prvoj sezoni je odigrao 28 utakmica u šampionatu i postigao dva gola. Naredne sezone je nastupio na 26 utakmica, samo jednom je zamenjen i uspeo je da postigne tri pogotka." + 
 "U januaru 2008. potpisao je ugovor sa Čelsijem, uz obeštećenje od 9,7 miliona funti, koje su isplaćene njegovom bivšem klubu što je bio najveći transfer u istoriji ruskog fudbala. Ivanović je potpisao ugovor na tri i po godine i zadužio je dres sa brojem dva. Za njega su pored Čelsija bili zainteresovani Milan, Inter, Juventus i Ajaks. Do kraja sezone 2008/09. nije dobio priliku da igra. Tadašnji trener, Avram Grant je smatrao da Bane nije dovoljno fizički spreman jer se rusko prvenstvo završilo nekoliko meseci ranije, pa je Ivanović tokom tok perioda bio bez takmičarskih utakmica."+
 "Tokom leta 2008. pojavile su se informacije da bi Ivanović mogao da napusti klub i pređe u Milan ili Juventus. Novi trener Čelsija, Luis Felipe Skolari je odbio takvu mogućnost jer je računao na Ivanovića za narednu sezonu. Tek nakon osam meseci po dolasku na Stamford bridž, Ivanović je odigrao svoj prvi meč za Čelsi. Bilo je to 24. septembra 2008. na utakmici Karling kupa protiv Portsmuta. U Premijer ligi je debitovao 5. oktobra 2008. u pobedi Čelsija od 2-0 nad Aston Vilom."+
 "U januaru 2009. trener Fiorentine pokazao je veliko interesovanje za Ivanovića,[1] da bi te špekulacije 27. januara potvrdio i Ivanovićev menadžer, međutim Čelsi nije želeo da se odrekne Ivanovića."+
 "Tek nakon smene Skolarija i dolaska Gusa Hidinka na mesto trenera, Ivanović je dobio pravu šansu. Na utakmici sa Njukasl junajtedom 4. aprila 2009. je nastupio za Čelsi u prvenstvu nakon više od tri meseca. Prvi gol u dresu Čelsija je postigao protiv Liverpula na Enfildu, u četvrtfinalu Lige šampiona. Gol je postigao glavom i doneo je svom klubu početnu prednost. Kasnije je na tom meču posigao još jedan gol glavom i Čelsi je dobio sa 3-1."+
 "U sezoni 2009/10. je igrao u finalu Komjuniti šild protiv Mančester junajteda. U poluvremenu ga je zamenio Žoze Bosingva. Čelsi je taj meč dobio nakon boljeg izvođenja penala.";
                reprezentativnaKarijera = "Za mladu fudbalsku reprezentaciju Srbije je odigrao 38 utakmica i postigao 4 gola, (2003-2007);"+
"Za seniorsku reprezentaciju Srbije je odigrao 60 utakmica i postigao je 7 golova, (2005- )"+
"Za mladu reprezentaciju je debitovao 15. decembra 2003. protiv Makedonije u Ohridu (4-1). Prvi pogodak je postigao samo dva dana kasnije na istom mestu i protiv istog protivnika (7-0)."+
"Učestvovao je na tri Evropska prvenstva za igrače do 21 godine i osvojio je dve srebrne medalje. Na Evropskom prvenstvu 2005. u Nemačkoj je sa reprezentacijom stigao do finala u kojem su poraženi od Italije. Na Evropskom prvenstvu 2006. u Portugaliji je odigrao četiri utakmice i jednom je bio strelac. Reprezentacija je tada ispala u polufinalu, u utakmici koju je Ukrajina dobila nakon izvođenja jedanesteraca. Na Evropskom prvenstvu 2007. u Holandiji je sa reprezentacijom Srbije stigao do finala u kojem su poraženi od Holandije. Na tom prvenstvu je bio kapiten, a ukupno je nosio 12 puta kapitensku traku na mečevima mlade reprezentacije. Ivanović je tada zajedno sa Damirom Kahrimanom, Aleksandarom Kolarovim i Boškom Jankovićem bio izabran u najbolji tim šampionata."+
"Za seniorsku reprezentaciju Srbije je debitovao 8. juna 2005. na prijateljskoj utakmici protiv Italije (1-1) u Torontu. U igru je tada ušao u 77. minutu umesto Marka Baše. Prvi gol u dresu reprezentacije je postigao 12. septembra 2007. protiv Portugala u Lisabonu. Gol je postigao nakon slobodnog udarca Dejana Stankovića čime je u 88. minutu postavio konačnih 1-1. Bez obzira to što uglavnom nije igrao za svoj klub, kod selektora Radomira Antića je redovno igrao u Kvalifikacijama za Svetsko prvenstvo 2010. Bane je tokom tih kvalifikacija tri puta bio strelac.";
                statistika = "Golovi: 7. oktobar 2011.	Beograd, Srbija	protiv Italije,	Kvalifikacije za Evropsko prvenstvo 2012."+
                "	28. februar 2012.	Limasol, Kipar	protiv Jermenije Prijateljska"  +
                "	11. septembar 2012.	Novi Sad, Srbija protiv Velsa, Kvalifikacije za Svetsko prvenstvo 2014.";
                trofeji = "Lokomotiva: Kup Rusije (1) 2007. ;; Čelsi: Liga šampiona (1) : 2011/12. Liga Evrope (1) : 2012/13. Premijer Liga (2) : 2009/10, 2014/15. FA kup (3) : 2009, 2010, 2012. Liga kup (1) : 2015. Komjuniti šild (1) : 2009.";

                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                // 2
                punoIme = "Nemanja Matić";
                mestoRodjenja = "Srbija, Vrelo";
                datumRodjenja = "1.8.1988";
                visina = "1.94";
                trenutniKlub = "Čelsi";
                pozicija = "DMF";
                sportskaBiografija = "Matića je 31. januara 2011. kupila Benfika, i to u okviru transfera Davida Luiza u Čelsi, kao i 25 miliona evra obeštećenja, dok je Čelsi još dodatno Benfici prosledio Matića. Međutim, ipak mu je dozvoljeno da završi sezonu u Viteseu na pozajmici. Zvanično se pridružio Benfici od sezone 2011/12. Prvi gol u dresu Benfike je postigao 14. januara 2012. protiv Vitorije Setubal. Nakon odlaska Havija Garsije u Mančester siti 31. avgusta 2012. Matić je postao starter u veznom redu Benfike."+
                "Nakon gola u derbiju protiv Porta 13. januara 2013, već sledećeg dana Matić je nagrađen produženjem ugovora do 2018. godine, sa otkupnom klauzulom postavljenom na 45 miliona evra.";
                reprezentativnaKarijera = "Matić je bio potpuno nepoznat igrač u Srbiji sve dok Vladimir Vermezović, u to vreme trener slovačkog Spartaka iz Trnave, nije preporučio njega i Marka Milinkovića tadašnjem selektoru mlade reprezentacije Slobodanu Krčmareviću. Oba dva fudbalera su dobila šansu da debituju za mladu selekciju 11. oktobra 2008. na meču protiv Danske.[1]"+
"Nakon samo tri utakmice i dva gola u dresu mlade, selektor Antić ga je uvrstio u sastav seniorske reprezentacije za prijateljsku utakmicu protiv Poljske. Na toj utakmici odigranoj 14. decembra 2008. Matić je debitovao za najbolju selekciju Srbije."+
"Sa mladom reprezentacijom je učestvovao na Evropskom prvenstvu 2009. Povredio se u prvoj utakmici protiv Italije, nakon 85 minuta provedenih na terenu. Nakon te povrede morao je na operaciju stopala. Od 2008. do 2010. za reprezentaciju Srbije do 21 godine je odigrao jedanaest utakmica i postigao dva gola.";
                statistika = "Golovi: 29. mart 2015.	Stadion svetlosti	Lisabon, protiv Portugalije, Kvalifikacije za Evropsko prvenstvo 2016.";
                trofeji = "Košice: Kup Slovačke (1): 2008/09. Čelsi: FA kup (1): 2009/10. Liga kup (1): 2014/2015. Benfika: Prvenstvo Portugalije (1): 2013/14. Kup Portugalije (1): 2013/14. Liga kup (1): 2011/12.";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                // 3
                punoIme = "Aleksandar Kolarov";
                mestoRodjenja = "Srbija, Zemun";
                datumRodjenja = "10.11.1985";
                visina = "1.87";
                trenutniKlub = "FK Mančester Siti";
                pozicija = "LB";
                sportskaBiografija = "Tokom leta 2007. godine, prelazi u italijanski Lacio iz OFK Beograda za sumu od 700.000 evra. Sa Lacijom je osvojio Kup Italije 2008. godine i Superkup Italije 2009. godine. U Laciju je proveo tri godine, odigrao je 82. meča i postigao 6 golova. Tokom leta 2010. godine, potpisuje ugovor sa Mančester sitijem za sumu od 19. miliona evra. Debitovao je 14. avgusta 2010. na meču sa Totenhemom.";
                reprezentativnaKarijera = "Nadimak „srpski Roberto Karlos“ dobio je posle prvenstva za igrače do 21 godine 2007. zbog razornog slobodnog udarca sličnog Karlosovom. Često ga porede i sa Sinišom Mihajlovićem. Oženjen je i ima ćerku i sina.";
                statistika = "Golovi: 11. septembar 2012. Novi Sad, Srbija	protiv Velsa, Kvalifikacije za Svetsko prvenstvo 2014."+
"7. jun 2013.	Brisel, Belgija	protiv Belgije, Kvalifikacije za Svetsko prvenstvo 2014."+
"10. septembar 2013.	Kardif, Vels Protiv Velsa, Kvalifikacije za Svetsko prvenstvo 2014.";
                trofeji = "";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                // 4
                punoIme = "Adem Ljajić";
                mestoRodjenja = "Srbija, Novi Pazar";
                datumRodjenja = "29.9.1991";
                visina = "1.82";
                trenutniKlub = "Inter";
                pozicija = "LMF,RMF,SS";
                sportskaBiografija = "Fudbal je počeo da igra u FK Jošanica iz Novog Pazara. Kao 14-godišnjak 2005. Ljajić prelazi u Partizan iz Beograda. Svoj prvi nastup za Partizan imao je na prvoj utakmici drugog kola kvalifikacija za Ligu šampiona 2008/09. 29. jula 2008, kada je ušao kao rezerva u drugom poluvremenu.[1] Svoj prvi takmičarski pogodak za Partizan postigao je 23. novembra 2008, u utakmici protiv OFK Beograda.";
                reprezentativnaKarijera = "Nastupao je za sve mlađe selekcije Srbije. Za seniorsku reprezentaciju Srbije je debitovao 17. novembra 2010. na prijateljskom susretu sa reprezentacijom Bugarske u Sofiji (1:0 za Srbiju).";
                statistika = "";
                trofeji = "Partizan: Prvenstvo Srbije (1) : 2008/09. Kup Srbije (1) : 2008/09.";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                // 5
                punoIme = "Aleksandar Mitrović";
                mestoRodjenja = "Srbijam, Smederevo";
                datumRodjenja = "16.9.1994";
                visina = "1.89";
                trenutniKlub = "Njukasl junajted";
                pozicija = "CF";
                sportskaBiografija = "27. juna 2012, je zajedno sa još dva saigrača iz Teleoptika, potpisao prvi profesionalni ugovor sa Partizanom.[1] Svoj debi u crno-belom dresu, imao je u kvalifikacijama za Ligu Šampiona, protiv Valete sa Malte, postigavši gol devet minuta nakon što je ušao u igru.[2] 23. avgusta 2012, postigao je gol glavom na meču sa Tromsom u plejofu za ulazak u Ligu Evrope.[3] Tri dana kasnije postigao je svoj prvi gol u Superligi Srbije, na meču sa Jagodinom.[4] Takođe je u grupnoj fazi Liga Evrope postigao gol protiv Nefčija iz Bakua";
                reprezentativnaKarijera = "Za reprezentaciju Srbije debitovao 7. juna 2013. protiv Belgije u Briselu (1:2)[17][18] u kvalifikacijama za Svetsko prvenstvo 2014. u Brazilu. Na utakmici protiv Hrvatske, odigranoj 6. septembra 2013, postigao je svoj prvenac u dresu reprezentacije.";
                statistika = "Od 129 meceva, postigao je 58 pogotka";
                trofeji = "Partizan: Prvenstvo Srbije (1) : 2012/13. Anderleht: Prvenstvo Belgije (1) : 2013/14. Superkup Belgije (1) : 2014. Kup Belgije (1) : 2014/15.";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                // 6
                punoIme = "Zoran Tošić";
                mestoRodjenja = "Srbija, Zrenjanin";
                datumRodjenja = "28.4.1987";
                visina = "1,71";
                trenutniKlub = "	CSKA Moskva";
                pozicija = "LMF,RMF";
                sportskaBiografija = "";
                reprezentativnaKarijera = "";
                statistika = "Postigao je 11 golova za reprezentaciju";
                trofeji = "";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                // 7
                punoIme = "Lazar Marković";
                mestoRodjenja = "Srbija, Čačak";
                datumRodjenja = " 2.3.1994";
                visina = "";
                trenutniKlub = "Fenerbahče";
                pozicija = "LMF,RMF,SS";
                sportskaBiografija = "Fudbal je počeo igrati u čačanskom Borcu, a 2006. je došao u beogradski Partizan ."+
"Za seniorski tim Partizana debitovao je 9. maja 2011. u meču protiv užičke Slobode (2:1),[2] a svoj prvi prvenstveni gol postigao je 13. avgusta 2011. na meču protiv Novog Pazara."+
"Prvi profesionalni ugovor sa Partizanom Marković je potpisao u julu 2011."+
"Školovao se u Sportskoj gimnaziji u Beogradu";
                reprezentativnaKarijera = "U oktobru 2009. debitovao za reprezentaciju Srbije do 17 godina, a u maju 2011. nastupio je za reprezentaciju Srbije na Evropskom prvenstvu U-17 čiji je domaćin bila Srbija."+
"Nije nastupao za reprezentaciju do 19 godina jer je pozvan u mladu reprezentaciju u kojoj je debitovao na utakmici protiv Danske oktobra 2011."+
"Za seniorsku reprezentaciju Srbije debitovao je 28. februara 2012. u prijateljskom meču protiv Jermenije (2:0) u Limasolu.";
                statistika = "14. novembar 2012.	Sankt Galen, Švajcarska	protiv Čilea Prijateljska i	10. septembar 2013.	Kardif, Vels protiv Velsa, Kvalifikacije za Svetsko prvenstvo 2014.";
                trofeji = "Partizan: Prvenstvo Srbije (3) : 2010/11, 2011/12, 2012/13. Kup Srbije (1) : 2010/11. Benfika: Prvenstvo Portugala (1) : 2013/14. Kup Portugala (1) : 2013/14. Liga kup Portugala (1) : 2013/14.";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                // 8
                punoIme = "Vladimir Stojković";
                mestoRodjenja = "Srbija, Loznica";
                datumRodjenja = " 28.6.1983";
                visina = "";
                trenutniKlub = "Makabi Haifa";
                pozicija = "GK";
                sportskaBiografija = "Dana 27. avgusta 2010. godine objavljeno je da je Stojković potpisao jednosezonski ugovor o pozajmici sa prvakom srpske lige Partizanom, samo nekoliko dana pošto je uspeo da se plasira u Ligu Šampiona.[2] Ugovor između Sportinga i Partizana je takav da Stojković 45.000 evra mesečno dobija 80% od portugalskog tima a ostalih 20% od srpskog, što znači da bi on za 10 meseci bio plaćen od Sportinga 360.000 evra a od Partizana 90.000.";
                reprezentativnaKarijera = "Dana 18. juna 2010. u utakmici grupe D protiv reprezentacije Nemačke na Svetskom prvenstvu 2010. u Južnoj Africi, Vladimir je odbranio penal Podolskog, čime je doprineo pobedi Srbije od 1:0, a na kraju meča je proglašen igračem utakmice.";
                statistika = "";
                trofeji = "Partizan: Prvenstvo Srbije 2010/11., 2011/12. i 2012/13. Kup Srbije 2011.";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                 // 9
                punoIme = "Matija Nastasić";
                mestoRodjenja = "Srbija, Valjevo";
                datumRodjenja = "28.3.1993";
                visina = "1,87";
                trenutniKlub = "Šalke";
                pozicija = "CB";
                sportskaBiografija = "Fudbalom je počeo da se bavi u Valjevskom ZSK-u, odakle je kao talentovani pionir prešao u Partizan. Sa sedamnaest godina potpisao je prvi profesionalni ugovor sa crno-belima.[1] Prodat je 2010. u Fjorentinu za 2,5 miliona evra, ali je ostao na pozajmici u Teleoptiku do punoletstva.[2] Nastasić je po dolasku u Firencu prvo trenirao sa mladim timom, ali je zbog nedostatka rešenja na poziciji štopera, što zbog povreda što zbog suspenzija, trenirao sa prvim timom dosta puta. Siniša Mihajlović mu je pružio priliku da debituje u Seriji A 11. septembra 2011. u pobedi od 2-0 nad Bolonjom.";
                reprezentativnaKarijera = "Nastasić je igrao za sve mlađe reprezentacije Srbije, a za seniorski tim je debitovao 29. februara 2012. na prijateljskom meču protiv Kipra.";
                statistika = "";
                trofeji = "";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                 // 10
                punoIme = "Nikola Maksimović";
                mestoRodjenja = "Srbija, Bajina Bašta";
                datumRodjenja = "25.11.1991";
                visina = "1.90";
                trenutniKlub = "Torino";
                pozicija = "CB";
                sportskaBiografija = "Svoju karijeru započeo je u prvom timu Slobode iz Užica, gde je proveo tri godine. U decembru 2011. godine pridružio se timu Srbije do 21 godine i Crvenoj zvezdi za 300.000 evra. Sa Crvenom zvezdom je osvojio Kup Srbije, a na kraju je bio u timu sezone Superlige za sezonu 2011/12. U julu 2013. odlazi na jednogodišnju pozajmicu u Torino koji će nakon toga odlučiti da li će potpisati ugovor sa njim.";
                reprezentativnaKarijera = "";
                statistika = "";
                trofeji = "Crvena zvezda: Srbija Kup Srbije (1) : 2011/12.";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                //11
                punoIme = "Sergej Milinković-Savić";
                mestoRodjenja = "Ljeida";
                datumRodjenja = "27.2.1995";
                visina = "1.92";
                trenutniKlub = "Lacio";
                pozicija = "CMF,DMF";
                sportskaBiografija = "";
                reprezentativnaKarijera = "";
                statistika = "";
                trofeji = "Vojvodina: Kup Srbije (1) : 2013/14.Srbija: Evropsko prvenstvo do 19 godina (1) : 2013. Svetsko prvenstvo do 20. godine (1) : 2015.";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                //12
                punoIme = "Dušan Tadić";
                mestoRodjenja = "";
                datumRodjenja = "20.11.1988";
                visina = "1.81";
                trenutniKlub = "Sauthemptonom";
                pozicija = "LMF,AMF";
                sportskaBiografija = "rve fudbalske korake je napravio u lokalnom klubu AIK iz Bačke Topole, a od 2002. je član novosadske Vojvodine. Za seniorski tim Vojvodine je debitovao u sezoni 2006/07, a 2010. godine ga je prodala FK Groningenu za 1.55 miliona američkih dolara."+
"Od 2012. do 2014. je nastupao za Tvente a u julu 2014. je potpisao četvorogodišnji ugovor sa engleskim premijerligašem Sauthemptonom.";
                reprezentativnaKarijera = "";
                statistika = "Na 86 meceva, 23 golova";
                trofeji = "";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                //13
                punoIme = "Predrag Rajković";
                mestoRodjenja = "";
                datumRodjenja = "31.10.1995";
                visina = "1.91";
                trenutniKlub = "Makabi Tel Aviv";
                pozicija = "GK";
                sportskaBiografija = "Branio je u mlađim kategorijama FK Hajduk Veljka iz Negotina odakle je 2009. godine došao u Jagodinu. Svoj debi u Superligi Srbije je imao 9. marta 2013. na meču sa Partizanom. Za Jagodinu je odigrao ukupno 4 superligaške utakmice. U avgustu 2013. je potpisao ugovor sa Crvenom zvezdom.[3] Nakon dve sezone provedene u taboru beogradskih crveno—belih Rajković se krajem avgusta 2015. godine preselio u redove izraelskog šampiona Makabi Tel Aviv.";
                reprezentativnaKarijera = "Rajković je prošao sve mlađe selekcije reprezentacije Srbije. Sa reprezentacijom do 19 godina je osvojio Evropsko prvenstvo u Litvaniji 2013. godine. Na celom prvenstvu je branio sjajno a posebno se istakao u polufinalnoj utakmici protiv Portugala kada je u penal seriji odbranio dva penala. Sa reprezentacijom Srbije do 20 godine postao je prvak sveta na prvenstvu na Novom Zelandu 2015. godine. Za seniorsku reprezentaciju je debitovao 14. avgusta 2013. na prijateljskom meču sa Kolumbijom.[1]";
                statistika = "";
                trofeji = "Jagodina: Kup Srbije (1) : 2013. Crvena zvezda: Prvenstvo Srbije (1) : 2013/14.";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                //14
                punoIme = "Petar Škuletić";
                mestoRodjenja = "Danilovgrad";
                datumRodjenja = "29.6.1990";
                visina = "1,93";
                trenutniKlub = "Lokomotiva Moskva";
                pozicija = "CF";
                sportskaBiografija = "Škuletić je bio u mlađim kategorijama Partizana, ali nije potpisao za prvi tim već je igrao za filijalu crno-belih Teleoptik. U leto 2009. odlazi u austrijski LASK Linc. Međutim nije uspeo da se nametne pa je tokom 2011. bio na pozajmici u Zeti.[1] U avgustu 2011. je potpisao trogodišnji ugovor sa Vojvodinom. Tokom 2013. je bio na pozajmici u Radničkom iz Niša.[2] Nakon povratka sa pozajmice postao je standardan u Vojvodini, i tokom jesenjeg dela sezone 2013/14. je skrenuo pažnju na sebe. Posebno je dobre partije pružao u kvalifikacijama za Ligu Evrope gde je postigao 4 gola na 8 utakmica. U januaru 2014. je potpisao četvorogodišnji ugovor sa Partizanom.[3] Škuletić je u anketi „Večernjih novosti“ izabran za najboljeg fudbalera Superlige Srbije u 2014. godini pošto je za njega glasala većina kapitena timova učesnika u Superligi Srbije.";
                reprezentativnaKarijera = "Iako je rođen u Crnoj Gori Škuletić je igrao za mlađe selekcije Srbije. Takođe je izjavio da želi da igra za seniorsku reprezentaciju Srbije.";
                statistika = "";
                trofeji = "";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                //15
                punoIme = "Nemanja Gudelj";
                mestoRodjenja = "Srbija, Beograd";
                datumRodjenja = "16.11.1991";
                visina = "1.87";
                trenutniKlub = "FK Ajaks";
                pozicija = "CMF,AMF";
                sportskaBiografija = "rvi profesionalni ugovor je potpisao u julu 2009. godine za holandski prvoligaški klub NAC Breda. Za NAC Bredu je nastupao u 79 utakmica i postigao 8 golova. Bio je povređen od 24. novembra 2011. godine do 29. marta 2012. godine. Od jula 2013. godine je počeo da igra za AZ Alkmar sa kojim je potpisao ugovor na 4 godine. U februaru 2014. godine procenjena tržišna vrednost Nemanje Gudelja je iznosila 4.000.000 €";
                reprezentativnaKarijera = "Za Fudbalsku reprezentaciju Srbije do 21 godine je odigrao 14 utakmica i postigao 2 gola. Pre toga je za Fudbalsku reprezentaciju Srbije do 19 godine nastupao u 3 utakmice. Krajem februara 2014. godine je dobio poziv da nastupa za seniorsku Fudbalsku reprezentaciju Srbije za koju je debitovao na prijateljskom meču protiv Fudbalske reprezentacije Irske 5. marta 2014. godine. Dobio je i poziv da nastupa za Fudbalsku reprezentaciju Bosne i Hercegovine, ali je odbio poziv";
                statistika = "";
                trofeji = "";

                noviIgrac = new Igrac();
                noviIgrac.PunoIme = punoIme;
                noviIgrac.MestoRodjenja = mestoRodjenja;
                noviIgrac.DatumRodjenja = datumRodjenja;
                noviIgrac.Visina = visina;
                noviIgrac.TrenutniKlub = trenutniKlub;
                noviIgrac.Pozicija = pozicija;
                noviIgrac.PripadaReprezentaciji = pripadaReprezentaciji;
                noviIgrac.SportskaBiografija = sportskaBiografija;
                noviIgrac.ReprezentativnaKarijera = reprezentativnaKarijera;
                noviIgrac.Statistika = statistika;
                noviIgrac.Trofeji = trofeji;
                collection.InsertOne(noviIgrac);

                // -------------------------------- //

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
        }
    }
}
