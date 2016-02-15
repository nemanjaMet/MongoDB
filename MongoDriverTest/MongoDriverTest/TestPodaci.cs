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

                //1
                punoIme = "Džerom Boateng";
                mestoRodjenja = "Nemacka, Berlin";
                datumRodjenja = " 3.9.1988";
                visina = "";
                trenutniKlub = "Bajern Minhen";
                pozicija = "LB,RB";
                sportskaBiografija = "Rođen je u Berlinu, iz mešovitog braka Nemice i Ganijca. Njegov stric, Robert Boateng je bivši reprezentativac Gane. Džeromov polubrat Kevin Prins, nastpa za Milan. Karijeru je počeo u Herti, kroz čije je sve mlađe selekcije prošao. Izborio je mesto u prvom timu u kojem je odigrao jednu sezonu pre nego što je prešao u Hamburger. Sa ekipom Hamburgera je dva puta uzastupno uspeo da izbori plasman u polufinale Lige Evrope." +
                    "U Mančester siti je prešao 5. juna 2010. uz obeštećenje od 10.400.000 funti. Debitovao je za Siti u prijateljskoj utakmici sa Valensijom. Tada je u igru ušao sa klube umesto Majke Ričardsa i asistirao je Garetu Bariju prilikom postizanja gola. Početak sezone je propustio zbog povrede koju je zaradio dok je nastupao za reprezentaciju u prijateljskoj utakmici sa Danskom[1]. Zbog toga je u zvaničnoj utakmici za Siti debitovao tek 25. septembra 2010. kada je u igru ušao sa klupe u pobedi nad Čelsijem od 1:0. Prvi put je bio u startnoj postavi protiv Juventusa (1:1) u utakmici Lige Evrope" +
                    "Ne zadovoljan minutažom i time što je najčešće igrao na pozciji desnog beka, a ne štopera, odlučio je da napusti Mančester siti[3]. U Bajern Minhen je prešao 14. jula 2011. uz obeštećenje od 13.500.000 evra. U dresu novog kluba je debitovao 27. jula 2011. protiv Milana u utakmici Audi kupa, kada je u igru ušao sa klupe umesto Rafinje. Za Bajern je u prvenstvu debitovao 6. avgusta 2011. u porazu na domaćem terenu od Borusije Menhengladbah.";
                reprezentativnaKarijera = "Boateng je igrao za sve mlađe selekcije reprezentacije. Sa reprezentacijom da 21 godine je osvojio Evropsko prvenstvo 2009. Za seniorsku reprezentaciju Nemačke je debitovao 10. oktobra 2009. protiv Rusije[4]. U drugom poluvremenu te utakmice je zaradio drugi žuti karton čime je postao prvi nemački reprezentativac koji je isključen na debiju" +
                    "Selektor Joakim Lev je uvrstio Boatenga na spisak putnika za Svetsko prvenstvo 2010. u Južnoj Africi. Boateng je 23. juna 2010. igrao protiv svog brata Kevina Prinsa koji je nastupao za reprezentaciju Gane[6]. Nemačka je slavila sa 1:0, i to je bila prva utakmica u istoriji svetskih prvenstava u kojoj su dva brata igrala jedan protiv drugog u dresovima različitih reprezentacija[7]. Boateng je bio starter i u pobedi nad Engleskom 4:1 u osmini finala, a zatim i u pobedi nad Argentinom 4:0 u četvrtfinalu[8]. U Polufinalu je Nemačka poražena od evropskog prvaka Španije 1:0, golom Karlesa Pujola[9]. U utakmici za treće mesto savladan je Urugvaj 3:2, a Boateng je bio asistent Marselu Jansenu kod drugog gola, čime je Nemačka došla do drugog uzastopnog trećeg mesta na svetskim prvnstvima" +
                    "Boateng je učestvovao i na Evropskom prvenstvu 2012. i bio prvi izbor selektora Leva na poziciji desnog beka.";
                statistika = "";
                trofeji = "Mančester siti: FA kup (1) : 2010/11. Bajern Minhen: Prvenstvo Nemačke (3) : 2012/13, 2013/14, 2014/15. Kup Nemačke (2) : 2012/13, 2013/14. Superkup Nemačke (1) : 2012. Telekom kup Nemačke (2) : 2013, 2014. Liga šampiona (1) : 2012/13. (finale 2011/12). UEFA superkup (1) : 2013. Svetsko klupsko prvenstvo (1) : 2013. Reprezentacija Nemačke: Evropsko prvenstvo do 21. godine (1) : 2009. Svetsko prvenstvo (1) : 2014. Svetsko prvenstvo : (treće mesto) 2010.";

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

                //2
                punoIme = "Mats Hummels";
                mestoRodjenja = "Bergisch Gladbach";
                datumRodjenja = "16.12.1988";
                visina = "1.91";
                trenutniKlub = "Borusia Dortmund";
                pozicija = "CB";
                sportskaBiografija = "";
                reprezentativnaKarijera = "Za reprezentaciju je debitovao 2010. godine, a od Eura 2012 postao je standardni prvotimac.";
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

                //3
                punoIme = "Toni Kros";
                mestoRodjenja = "";
                datumRodjenja = "4.1.1990";
                visina = "";
                trenutniKlub = "Real Madrid";
                pozicija = "CMF,DMF";
                sportskaBiografija = "Kros je napravio neverovatni početak karijere u Bajernu. Na svom debiju u Bajernu 26. septembra 2007. u pobedi od 5:0 protiv Energi Kotbusaa je u 18 odigranih minuta ima dve asistencije za dva gola Miroslava Klozea. 9. januara 2009. je otišao na pozajmicu u Bajer Leverkuzen na godinu dana, a nakon jedne i po sezone u Bajeru vratio se u Bajern nakon završetka sezone 2009/10.";
                reprezentativnaKarijera = "";
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

                //4
                punoIme = "Tomas Miler";
                mestoRodjenja = " Vajlhajm";
                datumRodjenja = "13.9.1989.";
                visina = "";
                trenutniKlub = "Bajern Minhen";
                pozicija = "CF,SS";
                sportskaBiografija = "Miler je u Minhenski Bajern otišao 2000., sa samo 10 godina, a razvio se u Bajernovoj školi fudbala. Za rezervnu ekipu Bajerna, Miler je debitovao u martu 2008. godine, protiv SpVgg Unterhachin. U debiju je postigao pogodak, a odigrao je još dve utakmice u 2007./08. sezoni, pre nego što se povredio." +
                    "Sledeće sezone, Bajernove rezerve su se kvalifikovale za tada novoosnovanu 3. Ligu, a Miler je postao jedan od ključnih igrača - nastupio je u 32 od 38 utakmica, a postigao je 15 pogodaka i postao peti strelac sezone. Zaigrao je i za prvi tim, u prijateljskim presezonskim utakmicama, a prvi Bundesligaški nastup imao je 15. avgusta 2008. protiv Hamburga. Imao je još tri nastupa u Bundesligi te sezone; a uz to, debitovao je i u Ligi prvaka 10. marta 2009., ušavši u 72. minuti umesto Švajnštajgera, u 7:1 pobedi protiv Sportinga. Postigao je poslednji pogodak za Bajern na toj utakmici." +
                    "Miler je početkom sezone 2009./10. često igrao za prvu postavu Bajerna, dok je u avgustu 2009. pozvan u nemačku U-21 reprezentaciju, debitujući u 3:1 pobedi protiv Turske." +
                    "12. avgusta 12 2009., Miler je ušao sa klupe u utakmici Bajerna protiv dortmundske Borusije i postigao dva pogotka u 5:1 pobedi. Tri dana kasnije, Miler je postigao novi pogodak u Ligi šampiona, protiv Makabija iz Haife.";
                reprezentativnaKarijera = "";
                statistika = "Na 92 utakmice dao je 36 golova";
                trofeji = "Bajern Minhen: Prvenstvo Nemačke (4) : 2009/10, 2012/13, 2013/14, 2014/15. Kup Nemačke (3) : 2009/10, 2012/13, 2013/14. Superkup Nemačke (2) : 2010, 2012. Telekom kup Nemačke (2) : 2013, 2014. Liga šampiona (1) : 2012/13. (finale 2009/10, 2011/12). UEFA superkup (1) : 2013. Svetsko klupsko prvenstvo (1) : 2013. Nemačka: Svetsko prvenstvo (1) : 2014[4] Svetsko prvenstvo : treće mesto 2010[5]";

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

                //5
                punoIme = "Mesut Ozil";
                mestoRodjenja = "Gelzenkirhen";
                datumRodjenja = " 15.10.1988";
                visina = "1.80";
                trenutniKlub = "Arsenal";
                pozicija = "LMF,RMF";
                sportskaBiografija = "Ozil je u mlađim kategorijama igrao za više timova iz Gelzenkirhena. Nakon toga je pet godina proveo u Rot vajsu iz Esena. U Šalke 04 je došao 2005. i prvo je jednu sezonu proveo igrajući u omladinskom timu ove ekipe, pre nego što je prekomandovan u prvi tim. Debitovao je za prvi tim u Liga kupu protiv Bajer Leverkuzena. Iako je pokazao da se radi o talentovanom igraču, zbog neslaganja sa upravom, 2008. godine je prešao u Verder Bremen." +
                    "U Verder Bremen je prešao 31. januara 2008. uz obeštećenje od 4,3 miliona evra. Predvodio je Verder do trofeja u Kupu Nemačke 2009. Bio je strelac jedinog gola na utakmici finala protiv Bajer Leverkuzena, odigranoj u Berlinu. Te sezone je njegov klub stigao i do finala Kupa UEFA u kome je poražen od Šahtjora. Verder je tu sezonu završio na razočaravajućem desetom mestu u prvenstvu, dok je Ozil postigao 3 gola i bio asistent kod čak 15 golova. U narednoj sezoni, poslednjoj Ozilovoj u klubu, koju je Verder završio kao treći, Ezil je 16 puta bio asistent." +
                    "Nakon sjajnih partija na Svetskom prvenstvu 2010. interesovanje za Ozila je pokazao Real Madrid. Verder Bremen je 17. avgusta 2010. objavio da je postigao dogovor sa Realom oko transfera Ezila. Obeštećenje je iznosilo negde oko 15 miliona evra. U dresu novog kluba je debitovao 22. avgusta u prijateljskoj utakmici sa Herkulesom (3-1). Debitovao je u španskoj ligi protiv Majorke (0-0) kada je u igru ušao u 62. minutu umesto Anhela di Marije. Prvi gol za Real Madrid je postigao protiv Deportivo la Korunje (6-1) 3. oktobra 2010, dok je prvi gol u Ligi šampiona postigao 19. oktobra 2010. protiv Milana." +
                    "U letnjem prelaznom roku, 1. septembra 2013. godine, Ezil prelazi u Arsenal. Iznos transfera bio je 50 miliona evra, i to je ujedno bio drugi najveći transfer u Premijer ligi.";
                reprezentativnaKarijera = "Ozil je bio član mlađih selekcija reprezentacije Nemačke. Prvi put je u septembru 2006. pozvan u reprezentaciju do 17 godina. Član reprezentacije do 21 godine je bio od 2007. Sa ovom reprezentacijom je na Evropskom prvenstvu za igrače do 21. godine 2009. osvojio prvo mesto. U finalnoj utakmici odigranoj 29. juna 2009. u kojoj je njegova reprezentacija savladala Englesku 4-0, proglašen je najboljim igračem tog meča." +
                    "Za seniorsku reprezentaciju Nemačke je debitovao 11. februara 2009. u prijateljskoj utakmici sa Norveškom. Prvi gol za reprezentaciju je postigao u svom trećem nastupu 5. septembra 2009. u prijateljskoj utakmici sa Južnom Afrikom u Leverkuzenu. Našao se i na spisku učesnika Svetskog prvenstva 2010. Bio je starter na svih sedam utakmica, a u poslednjoj utakmici grupne faze protiv Gane postigao je jedini gol na tom meču. Zbog odličnih igara na ovom prvenstvu bio jej jedan od deset nominovanih fudbalera za zlatnu kopačku.";
                statistika = "";
                trofeji = "Verder Bremen: Kup (1): 2009. Kup UEFA (finalista): 2009. Nemačka: Evropsko prvenstvo do 21. godine (prvo mesto): 2009. Svetsko prvenstvo (treće mesto): 2010.";

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

                //6
                punoIme = "Bastijan (Srpski zet) Švajnštajger";
                mestoRodjenja = "Kolbermoru";
                datumRodjenja = "1.8.1984";
                visina = "";
                trenutniKlub = "Mančester junajted";
                pozicija = "CMF,DMF";
                sportskaBiografija = "Do 1992. igrao je za FK Oberaudorf, da bi narednih šest godina (1992 — 1998) proveo u SK 1860 Rozenhajm. Od 1998. igra za FK Bajern iz Minhena. Do polovine sezone 2009/2010 odigrao je ukupno 207 utakmica za Bajern i pritom postigao 21 gol";
                reprezentativnaKarijera = "Prvi put je zaigrao za reprezentaciju Nemačke 6. juna 2004. u Kajzerslauternu, na utakmici protiv Mađarske. U dresu reprezentacije, gde nosi broj 7, igrao je 72 puta i pogađao 19 puta (stanje 18. novembar 2009.)";
                statistika = "";
                trofeji = "Drugi na Evropskom prvenstvu 2008. Treći na Svetskom prvenstvu 2006. Prvak Nemačke 2003, 2005, 2006. i 2008. Pobednik Nemačkog kupa 2003, 2005, 2006 i 2008.";

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

                //7
                punoIme = "Manuel Nojer";
                mestoRodjenja = " Gelzenkirhen";
                datumRodjenja = "27.3.1986";
                visina = "1.93";
                trenutniKlub = "	Bajern Minhen";
                pozicija = "GK";
                sportskaBiografija = "U julu 2011. godine Nojer potpisuje petogodišnji ugovor koji će trajati do 2016. godine. Ovaj transfer bio je vredan 22 miliiona evra, što ga je automatski stavilo na drugu poziciju najskupljih golmana svih vremena. U prvoj sezoni u klubu pomogao je Bajern-u da prođe u finale Lige šampiona eliminisavši Real Madrid. Utakmica je završena penalima, gde je Nojer zaustavio udarce Kristijana Ronalda i Kake.[5] U finalu ih je dočekao Čelsi. I ova je utakmica došla do penala, gde je Nojer čak i postigao gol u trećoj seriji, ali ni to nije pomoglo, jer je Čelsi slavio sa 4-3 na Alijanc Areni, na kojoj inače i igra Bajern Minhen. Nastupajući za Bajern uspeo je da obori rekord čuvenog Olivera Kana da više od 1000 minuta ne primi gol!";
                reprezentativnaKarijera = "Nojer je u maju 2009. godine pozvan u A reprezentaciju Nemačke.[6] Debitovao je u junu protiv Ujedinjenih Arapskih Emirata. Zbog povrede Rene Adlera i smrti Roberta Enkea, Nojer je izabran kao broj 1 za SP u Južnoj Africi. Tokom grupne faze, primio je samo jedan gol, i to protiv Srbije, a strelac je bio Milan Jovanović. Nemačka je u utakmici za 3. mesto pobedila reprezentaciju Urugvaja i osvojila bronzu." +
                    "Nojer je bio prvi golman i na ovom prvenstvu koje se igralo u Poljskoj i Ukrajini. Nemačka je bila u grupi B i to sa : Holandijom , Danskom i Portugalijom. Pobedili su sve tri , a Nojer je primio dva gola. Savladali su Grčku u četvrtfinalu , a izgubili od Italije u polufinalu. Izabran je u postavi najboljih jedanaest ovog prvenstva.";
                statistika = "";
                trofeji = "Šalke: Kup Nemačke (1) : 2010/11. Liga kup Nemačke (1) : 2005. Bajern Minhen: Prvenstvo Nemačke (3) : 2012/13, 2013/14, 2014/15. Kup Nemačke (2) : 2012/13, 2013/14. Superkup Nemačke (1) : 2012. Telekom kup Nemačke (2) : 2013, 2014. Liga šampiona (1) : 2012/13. (finale 2011/12). UEFA superkup (1) : 2013. Svetsko klupsko prvenstvo (1) : 2013. Nemačka: Svetsko prvenstvo (1) : 2014. Evropsko prvenstvo do 21 godine (1) : 2009.";

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

                //8
                punoIme = "Mario Gece";
                mestoRodjenja = "Memingen";
                datumRodjenja = "3.5.1992";
                visina = "1.76";
                trenutniKlub = "Bajern Minhen";
                pozicija = "SS";
                sportskaBiografija = "Dana 23. aprila 2013. objavljeno je da će se Gece pridružiti Bajernu iz Minhena 1. jula 2013, nakon što je ovaj tim platio klazulu od 37. miliona evra.[7][8][9] Taj transfer je u tom momentu napravio Gecea najskupljim nemačkim igračem svih vremena.[10][11] Mesut Ezil je taj rekord oborio nakon što je u septembru 2013. otišao u Arsenal za 50 miliona evra.[12] Trener Dortumnda Klop je rekao da je Gece otišao u Bajern zbog trenera Gvardiole koji je preuzeo tim tog leta.[13] Klop je priznao da je bio besan nakon što je transfer Gecea objavljen samo 36 sati pre polufinalne utakmice Lige šampiona sa Realom.[14] Klop je kasnije rekao da nije bilo nikakve šanse da zadrži Gecea jer je on bio velika želja Gvardiole." +
                    "Dana 11. avgusta 2013. Gece je debitovao za Bajern ušavši kao zamena za Mičela Vajzera, na prijateljskom meču sa mađarskim šampionom Đerom. Postigao je dva gola na tom meču u pobedi svog tima od 4:1.[16] Svoj debi u Bundesligi je imao 24. avgusta 2013. na meču sa Nirnbergom, koji je Bajern dobio sa 2:0.[17] Dana 19. oktobra 2013. Gece je ušao kao zamena i namestio dve asistencije za pobedu svog tima od 4:1 nad Majncom" +
                    "Dana 23. oktobra 2013, Gece je postigao svoj prvi gol u Ligi Šampiona za Bajern, u pobedi od 5:0 nad Plzenjom na Alijanc areni. Takođe je asistitrao Švajnštajgeru za jedan gol.[19] Dana 26. oktobra 2013, Gece je ušao kao zamena za Tonija Krosa u 25. minutu i postigao svoj prvi gol u Bundesligi u dresu Bajerna u pobedi od 3:2 nad Hertom.";
                reprezentativnaKarijera = "Nakon što je prošao sve mlađe selekcije, Gece je svoj debi u seniorskoj reprezentaciji imao 17. novembra 2010. protiv Švedske. Ušao je kao zamena svom nekadašnjem saigraču Kevinu Groskrojcu u 78. minutu[21] i postao najmlađi nemački reprezentativac posle Uvea Zelera. Svoj prvi gol za reprezentaciju je postigao 10. avgusta 2011. protiv Brazila. Tada je imao 19. godina i 68. dana čime je u dan izjednačio rekord Klausa Štirmera iz 1954, kao najmlađi strelac u istoriji Nemačke.";
                statistika = "Dao je 13 golova za reprezentaciju.";
                trofeji = "Borusija Dortmund: Prvenstvo Nemačke (2) : 2010/11, 2011/12. Kup Nemačke (1) : 2011/12. Telekom kup Nemačke (1) : 2011. Liga šampiona : finale 2012/13. Bajern Minhen: Prvenstvo Nemačke (2) : 2013/14, 2014/15. Kup Nemačke (1) : 2013/14. Telekom kup Nemačke (2) : 2013, 2014. UEFA superkup (1) : 2013. Svetsko klupsko prvenstvo (1) : 2013. Nemačka:  Svetsko prvenstvo (1) : 2014. Svetsko prvenstvo do 17. godina (1) : 2009.";

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

                //9
                punoIme = "Julian Draxle";
                mestoRodjenja = "Gladbeck, Germany";
                datumRodjenja = "20.9.1993";
                visina = "1.87";
                trenutniKlub = "VfL Wolfsburg";
                pozicija = "LMF,RMF";
                sportskaBiografija = "";
                reprezentativnaKarijera = "";
                statistika = "Na 190 utakmica dao je 34 golova.";
                trofeji = "Schalke 04: DFB-Pokal: 2010–11 DFL-Supercup: 2011";

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


                //10
                punoIme = "Andre Širle";
                mestoRodjenja = "Ludvigshafen na Rajni";
                datumRodjenja = " 6.11.1990";
                visina = "";
                trenutniKlub = "Volfsburg";
                pozicija = "LMF,RMF";
                sportskaBiografija = "Fudbalsku karijeru je započeo u lokalnom klubu Ludvigshafen u sezoni 2005/06. Naredne sezone prelazi u Majnc takođe u juniorski tim, za koje je igrao do 2009. godine kada prelazi u seniorski tim. Dobrim igrama na početku sezone u Bundesligi, potpisuje svoj prvi profesionalni ugovor sa Majncom krajem septembra 2009. godine. 2011. prelazi u Bajer Leverkuzen gde je uspešno igrao dve sezone. 2013. godine odlazi u Englesku gde je igrao za Čelsi.[1] U zimskom prelaznom roku, februara 2015. godine vraća se u nemačku Bundesligu i sa Volfsburgom potpisuje ugovor do 2019. Transfer je procenjen na 22 miliona funti.";
                reprezentativnaKarijera = "2008. godine je debitovao za reprezentaciju Nemačke do 19 godina, da bi nakon dobrih igara u Majncu nastupao i za nacionalni sastav do 21 godine. Za seniorsku reprezentaciju je debitovao 17. novembra 2010. godine u prijateljskom meču protiv Švedske ušavši u igru u 78. minuti zamenivši Luisa Holtbija. Prvi gol za reprezentaciju je dao u prijateljskom meču protiv Urugvaja 29. maja 2011. godine. Selektor nemačke reprezentacije Joahim Lev ga je uvrstio na spisak igrača za Evropsko prvenstvo 2012. u Poljskoj i Ukrajini. 2014. godine je učestvovao i na Svetskom prvenstvu u Brazilu kada sa reprezentacijom osvaja prvo mesto pobedivši u finalu reprezentaciju Argentine. Na Svetskom prvenstvu je odigrao pet utakmica i dao tri gola, jedan protiv Alžira, a dva u polufinalu protiv Brazila.";
                statistika = "Postigao je 20 golova za reprezentaciju";
                trofeji = "Nemačka: Svetsko prvenstvo prvo mesto: 2014.";

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
                punoIme = "Antonio Rüdiger";
                mestoRodjenja = "";
                datumRodjenja = "3.3.1993";
                visina = "1.90";
                trenutniKlub = "Roma";
                pozicija = "CB";
                sportskaBiografija = "";
                reprezentativnaKarijera = "";
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

                //12
                punoIme = "Kevin Großkreutz";
                mestoRodjenja = "";
                datumRodjenja = "196.1988";
                visina = "1.86";
                trenutniKlub = "VfB Stuttgart";
                pozicija = "RB";
                sportskaBiografija = "";
                reprezentativnaKarijera = "";
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

                //13
                punoIme = "Marcel Schmelzer";
                mestoRodjenja = "";
                datumRodjenja = "221.1988";
                visina = "1.80";
                trenutniKlub = "	Borussia Dortmund";
                pozicija = "LB";
                sportskaBiografija = "";
                reprezentativnaKarijera = "";
                statistika = "Na 298 utakmica postigao 4 gola.";
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

                

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
        }
    }
}
