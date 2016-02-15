using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MongoDB.Bson;
using MongoDB.DomainModel;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDriverTest.DomainModel;
using MongoDB;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MongoDriverTest
{
    class AlgoritamSimulacije
    {
        public delegate void delUpdateFormInformations(string info);

        FFudbalskaIgra forma;
        int brojIgracaDomaci = 0;
        int brojIgracaGosti = 0;
        string[] idsNamePosDomaci;
        string[] idsNamePosGosti;

        public AlgoritamSimulacije(FFudbalskaIgra ffi,string idDomacini,string idGosti)
        {
            forma = ffi;

            //string idIgraca = "56befc3ab309b02250124487,56befc62b309b02250124488,56befc8eb309b02250124489," +
            //"56befcd7b309b0225012448a,56befd6db309b0225012448b,56befdd0b309b0225012448c," +
            //"56befe10b309b0225012448d,56befe2fb309b0225012448e,56befe53b309b0225012448f,56befea4b309b02250124490,56befeceb309b02250124491,56beff42b309b02250124492," +
            //"56beffbeb309b02250124494,56bf0012b309b02250124495,56bf004eb309b02250124496," +
            //"56bf009db309b02250124497,56bf00dfb309b02250124498,56bf011cb309b02250124499,56bf0151b309b0225012449a," +
            //"56bf017bb309b0225012449b,56bf01afb309b0225012449c," +
            //"56bf01d2b309b0225012449d,56bf01f4b309b0225012449e,56bf021bb309b0225012449f,56bf024db309b022501244a0,56bf026bb309b022501244a1,56bf02a6b309b022501244a2,56bf02fdb309b022501244a3," +
            //"56bf0333b309b022501244a4,56bf0353b309b022501244a5,56bf037cb309b022501244a6,56bf0398b309b022501244a7,56bf03c6b309b022501244a8,56bf03f9b309b022501244a9";

            // Za domace
            getNamesAndPosition(idDomacini, true);
            // Za goste
            getNamesAndPosition(idGosti, false);
        }

        // ---- Simuliranje utakmice ----
        public void simulirajUtakmicu()
        {
            string[] domaciStartnih11 = izaberiIgrace(true);
            Thread.Sleep(500);
            string[] gostiStartnih11 = izaberiIgrace(false);
             
            double[] domacin = new double[11];
            double[] gost = new double[11];

            for (int i = 0; i < 11; i++)
            {
                string[] nameSkillDom = domaciStartnih11[i].Split(':');
                domacin[i] = Convert.ToDouble(nameSkillDom[1]);
                string[] nameSkillGos = gostiStartnih11[i].Split(':');
                gost[i] = Convert.ToDouble(nameSkillGos[1]);
            }

            updateSastavForm(domacin, domaciStartnih11, true);
            updateSastavForm(gost, gostiStartnih11, false);

            // ---- Dodela skilova ----
           /* domacin = noviSkilovi(domacin, true, 1);
            gost = noviSkilovi(gost, false, 1); */

            int domacinGolovi = 0;
            int gostGolovi = 0;

            delUpdateFormInformations updateDogadjaj = new delUpdateFormInformations(forma.updateDogadjaji);         

            // ---- Krece utakmica -----
            for (int i = 0; i < 90; i++)
            {
                // korak 1
                int napadaTim = izborTimaKojiNapada();
                Thread.Sleep(500); // Da se ne bi izgubio pointer u algoritam
                
                bool nastavakAkcije = false;
                bool nikoNemaAkciju = true;               
                if (napadaTim == 1)
                {
                    nastavakAkcije = true;
                    nikoNemaAkciju = false;                   
                }
                else if (napadaTim == 2)
                {
                    nastavakAkcije = true;
                    nikoNemaAkciju = false;                   
                }

                if (!nikoNemaAkciju & nastavakAkcije)
                {
                    // Korak 2 ---- da li je predjen centar
                    if (napadaTim == 1)
                    {
                        nastavakAkcije = sredinaPobedjena(domacin, gost);

                        // Update-ujemo dogadjaj na formu
                        forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i+1).ToString() + "' DOMACIN: Zapocinje akciju");
                        Thread.Sleep(500);
                    }
                    else if (napadaTim == 2)
                    {
                        nastavakAkcije = sredinaPobedjena(gost, domacin);

                        // Update-ujemo dogadjaj na formu
                        forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' GOST: Zapocinje akciju");
                        Thread.Sleep(500);
                    }


                    if (nastavakAkcije)
                    {
                        // ---- Korak 3 ---- da li je predjena odbrana
                        if (napadaTim == 1)
                        {
                            nastavakAkcije = odbranaPobedjena(domacin, gost);

                            // Update-ujemo dogadjaj na formu
                            forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' DOMACIN: Lepo razmenjuju pasove i prolaze centar");
                            Thread.Sleep(500);
                        }
                        else if (napadaTim == 2)
                        {
                            nastavakAkcije = odbranaPobedjena(gost, domacin);

                            // Update-ujemo dogadjaj na formu
                            forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' GOST: Lepo razmenjuju pasove i prolaze centar");
                            Thread.Sleep(500);
                        }

                        if (nastavakAkcije)
                        {
                            // ---- Korak 4 --- da li je dat gol
                            if (napadaTim == 1)
                            {
                                nastavakAkcije = odbranaGolmana(domacin, gost);

                                // Update-ujemo dogadjaj na formu
                                forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' DOMACIN: Prolaze protivnicku odbranu");
                                Thread.Sleep(500);
                            }
                            else if (napadaTim == 2)
                            {
                                nastavakAkcije = odbranaGolmana(gost, domacin);

                                // Update-ujemo dogadjaj na formu
                                forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' GOST: Prolaze protivnicku odbranu");
                                Thread.Sleep(500);
                            }

                            // ---- Postignu gol ----
                            if (nastavakAkcije)
                            {
                                if (napadaTim == 1)
                                {
                                    domacinGolovi++;
                                    // Update-ujemo dogadjaj na formu
                                    delUpdateFormInformations updateGol = new delUpdateFormInformations(forma.updateDomacinRez);
                                    forma.RezultatDomacin.BeginInvoke(updateGol, domacinGolovi.ToString());
                                    Thread.Sleep(500);
                                    forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' DOMACIN: GOOOL !!!");
                                    Thread.Sleep(500);                                   
                                    gost = noviSkilovi(gost, false, 2);
                                    updateSastavForm(gost, gostiStartnih11, false);
                                }
                                else if (napadaTim == 2)
                                {
                                    gostGolovi++;
                                    // Update-ujemo dogadjaj na formu
                                    delUpdateFormInformations updateGol = new delUpdateFormInformations(forma.updateGostRez);
                                    forma.RezultatGost.BeginInvoke(updateGol, gostGolovi.ToString());
                                    Thread.Sleep(500);
                                    forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' GOST: GOOOL !!!");
                                    Thread.Sleep(500);
                                    domacin = noviSkilovi(domacin, true, 2);
                                    updateSastavForm(domacin, domaciStartnih11, true);
                                }
                            }
                            else
                            {
                                // Golman brani
                                if (napadaTim == 1)
                                {
                                    // Update-ujemo dogadjaj na formu
                                    forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' GOST: Kakva odbrana golmana");
                                    Thread.Sleep(500);
                                    
                                }
                                else if (napadaTim == 2)
                                {
                                    // Update-ujemo dogadjaj na formu
                                    forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' DOMACIN: Kakva odbrana golmana");
                                    Thread.Sleep(500);
                                }
                            }
                        }
                        else
                        {
                            // Odbrana dobro reaguje
                            if (napadaTim == 1)
                            {
                                // Update-ujemo dogadjaj na formu
                                forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' GOST: Odbrana otklanja opasnost");
                                Thread.Sleep(500);
                            }
                            else if (napadaTim == 2)
                            {                             
                                // Update-ujemo dogadjaj na formu
                                forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' DOMACIN: Odbrana otklanja opasnost");
                                Thread.Sleep(500);
                            }
                        }
                    }
                    else
                    {
                        // Oduzeta lopta na sredinu
                        if (napadaTim == 1)
                        {
                            // Update-ujemo dogadjaj na formu
                            forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' GOST: Igraci sredine terena veoma dobro pokrivaju protivnike");
                            Thread.Sleep(500);
                        }
                        else if (napadaTim == 2)
                        {
                            
                            // Update-ujemo dogadjaj na formu
                            forma.RtbDogadjaji.BeginInvoke(updateDogadjaj, (i + 1).ToString() + "' DOMACIN: Igraci sredine terena veoma dobro pokrivaju protivnike");
                            Thread.Sleep(500);
                        }
                    }
                }

                // ---- Update minuta
                delUpdateFormInformations updateMin = new delUpdateFormInformations(forma.updateMinut);
                forma.Minuti.BeginInvoke(updateMin, (i+1).ToString() + "'");
                Thread.Sleep(500);

                if (i+1 == 15 || i+1 == 30 || i+1 == 45 || i+1 == 60 || i+1 == 75)
                {
                    // ---- Nova dodela skilova ----
                    domacin = noviSkilovi(domacin, true, 2);
                    gost = noviSkilovi(gost, false, 2);

                    updateSastavForm(domacin, domaciStartnih11, true);
                    updateSastavForm(gost, gostiStartnih11, false);

                    if (i+1 == 45)
                    {                      
                        forma.Minuti.BeginInvoke(updateMin, "HT");
                        Thread.Sleep(5000);
                    }
                }

            }
        }

        // ----- PRVI KORAK ----
        // ----- Izbor tima koji napada ----
        int izborTimaKojiNapada()
        {
            // Test POSED LOPTE: 25% Team1 - 50% Napad je propao - 25% Team2
            Random rand = new Random();
            int izborTima = rand.Next(1, 100);           

            if (izborTima < 11)
            {
                // Napada Domacin
                return 1;
            }
            else if (izborTima > 89)
            {
                // Napada gost
                return 2;
            }
            else
            {
                // Niko ne napada
                return 0;
            }
        }

        // ---- DRUGI KORAK ----
        // ---- Da li se prolazi sredina protivnickog tima -----
        bool sredinaPobedjena(double[] attackingTeam, double[] defendingTeam)
        {
            double ATEAM = 0;
            double DTEAM = 0;

            for (int i = 5; i < 11; i++)
            {
                // Uzimamo igrace sredine i napadace
                ATEAM += attackingTeam[i];

                if (i < 9)
                {
                    // Uzimamo igrace sredine
                    DTEAM += defendingTeam[i];
                }
            }

            Random rand = new Random();
            double faktorSreceATEAM = 1;
            double faktorSreceDTEAM = 1;
            faktorSreceATEAM = Math.Round(rand.NextDouble() * (1.5 - 0.5) + 0.5, 1);
            faktorSreceDTEAM = Math.Round(rand.NextDouble() * (2.0 - 0.5) + 0.5, 1);

            //string msg = ATEAM.ToString() + "*" + faktorSreceATEAM.ToString() + " VS " + DTEAM.ToString() + "*" + faktorSreceDTEAM.ToString();

            ATEAM = Math.Round(ATEAM * faktorSreceATEAM, 2);
            DTEAM = Math.Round(DTEAM * faktorSreceDTEAM, 2);

            if (ATEAM > DTEAM)
                return true;
            else
                return false;

        }

        // ---- TRECI KORAK ----
        // ---- Da li se prolazi protivnicka odbrana ----
        bool odbranaPobedjena(double[] attackingTeam, double[] defendingTeam)
        {
            double ATEAM = 0;
            double DTEAM = 0;

            for (int i = 0; i < 11; i++)
            {               
                if (i > 0 && i < 5)
                {
                    // ---- Uzimamo igrace odbrane
                    DTEAM += defendingTeam[i];
                }
                if (i > 4)
                {
                    // ---- Uzimamo igrace sredine i napadace
                    ATEAM += attackingTeam[i];
                }
            }

            Random rand = new Random();
            double faktorSreceATEAM = 1;
            double faktorSreceDTEAM = 1;
            faktorSreceATEAM = Math.Round(rand.NextDouble() * (1.0 - 0.5) + 0.5, 1);
            faktorSreceDTEAM = Math.Round(rand.NextDouble() * (2.0 - 0.5) + 0.5, 1);

            //string msg = ATEAM.ToString() + "*" + faktorSreceATEAM.ToString() + " VS " + DTEAM.ToString() + "*" + faktorSreceDTEAM.ToString();

            ATEAM = Math.Round(ATEAM * faktorSreceATEAM, 2);
            DTEAM = Math.Round(DTEAM * faktorSreceDTEAM, 2);

            if (ATEAM > DTEAM)
                return true;
            else
                return false;
        }

        // ---- KORAK 4 -----
        bool odbranaGolmana(double[] attackingTeam, double[] defendingTeam)
        {
            double ATEAM = 0;
            double DTEAM = 0;

            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    // Uzimamo golmana ekipe koja se brani
                    DTEAM += defendingTeam[i];
                }
                if (i > 4)
                {
                    // Uzimamo igrace sredine i napadace ekipe koja napada
                    ATEAM += attackingTeam[i];
                }
            }

            Random rand = new Random();
            double faktorSreceATEAM = 1;
            double faktorSreceDTEAM = 1;
            faktorSreceATEAM = Math.Round(rand.NextDouble() * (1.5 - 0.1) + 0.1, 1);
            faktorSreceDTEAM = Math.Round(rand.NextDouble() * (2.0 - 0.5) + 0.5, 1);


            //string msg = ATEAM.ToString() + "*" + faktorSreceATEAM.ToString() + " VS " + DTEAM.ToString() + "*" + faktorSreceDTEAM.ToString();

            ATEAM = Math.Round(ATEAM * faktorSreceATEAM, 2);
            DTEAM = Math.Round(DTEAM * faktorSreceDTEAM, 2);

            if (ATEAM > DTEAM)
                return true;
            else
                return false;
        }

        // ---- Update skilova igraca ----
        public double[] noviSkilovi(double[] team, bool domacin, int podeliSa)
        {
            Random rand = new Random();
            //string noveOcene = "";
            // ---- Generisi random brojeve za oba tima naizmenicno ----
            for (int i = 0; i < team.Length; i++)
            {
                int skill = rand.Next(1, 10);
                team[i] = Math.Round((team[i] + skill) / podeliSa, 1);
            }

            return team;
        }

        /*public double[] noviSkilovi(double[] team, bool domacin, int podeliSa)
        {
            Random rand = new Random();
            string noveOcene = "";
            // ---- Generisi random brojeve za oba tima naizmenicno ----
            for (int i = 0; i < team.Length; i++)
            {
                int skill = rand.Next(1, 10);
                team[i] = Math.Round((team[i] + skill) / podeliSa, 1);

                string[] separators = new string[] { "<&>" };
                if (domacin)
                {
                    string[] podela = idsNamePosDomaci[i].Split(separators, StringSplitOptions.None);
                    noveOcene += (i + 1).ToString() + ". " + podela[1] + " " + team[i].ToString() + ';'; 
                }
                else
                {
                    string[] podela = idsNamePosGosti[i].Split(separators, StringSplitOptions.None);
                    noveOcene += (i + 1).ToString() + ". " + podela[1] + " " + team[i].ToString() + ';';
                }
               // noveOcene += team[i].ToString() + ';';
            }
            noveOcene = noveOcene.TrimEnd(';');

            // ---- Update-ovanje ocene timova na formi
            if (domacin)
            {
                delUpdateFormInformations updatePostava = new delUpdateFormInformations(forma.updateTeamDomacin);
                forma.RtbSastavDomacin.BeginInvoke(updatePostava, noveOcene);
                Thread.Sleep(500);

            }
            else
            {
                delUpdateFormInformations updatePostava = new delUpdateFormInformations(forma.updateTeamGost);
                forma.RtbSastavGost.BeginInvoke(updatePostava, noveOcene);
                Thread.Sleep(500);
            }
            return team;
        }*/

        private void getNamesAndPosition(string idIgraca, bool domaci)
        {
            string[] podelaID = idIgraca.Split(',');
            //string[] podelaID2 = Regex.Split(idIgraca, ",");
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
      
            var collection = _database.GetCollection<Igrac>("igraci");
           // var testFilter = Builders<BsonDocument>.Filter.
            var filter = new BsonDocument();

            
            /*MongoCollection<BsonDocument> igraci;
            var query = new QueryDocument("_id", "");
            string[] fields = { "PunoIme", "Pozicija" };
            var cursor22 = igraci.Find(query).SetFields(fields);*/
   
            string[] namePos = new string[podelaID.Length];
            int position = 0;
            foreach (string ID in podelaID)
            {
                var query = new QueryDocument("_id", new ObjectId(ID));
                try
                {
                    var result = collection.Find(query).FirstOrDefault();
                    namePos[position] = ID + "<&>" + result.PunoIme + "<&>" + result.Pozicija;
                    position++;
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.ToString());
                }             
            }

            if (domaci)
            {
                brojIgracaDomaci = podelaID.Length;
                //idsNamePosDomaci = new string[brojIgracaDomaci];
                idsNamePosDomaci = namePos;
            }
            else
            {
                brojIgracaGosti = podelaID.Length;
                //idsNamePosDomaci = new string[brojIgracaGosti];
                idsNamePosGosti = namePos;
            }
            
        }

        string[] izaberiIgrace(bool domacin)
        {
            int brojIgraca = 0;
            string[] ekipaIdsNamePos;
            if (domacin)
            {
                ekipaIdsNamePos = idsNamePosDomaci;
                brojIgraca = brojIgracaDomaci;
            }
            else
            {
                ekipaIdsNamePos = idsNamePosGosti;
                brojIgraca = brojIgracaGosti;
            }

            double[] igraciSkill = new double[brojIgraca];
           // double[] gostSkill = new double[brojIgracaGosti];

            // ---- Dodela skilova ----
            igraciSkill = noviSkilovi(igraciSkill, domacin, 1);
            noviSkilovi(igraciSkill, domacin, 2); // smanjivanje velike vrednosti
          //  gostSkill = noviSkilovi(gostSkill, false, 1);

           // int[] domaciStartnih11 = new int[11];
            List<int> startnih11 = new List<int>();
          //  int[] gostiStartnih11 = new int[11];

            List<int> GK = new List<int>();
            List<int> LB = new List<int>();
            List<int> CB = new List<int>();
            List<int> RB = new List<int>();
            List<int> LMF = new List<int>();
            List<int> CMF = new List<int>();
            List<int> RMF = new List<int>();
            List<int> CF = new List<int>();

            int pos = 0;
            string[] separators = new string[] { "<&>" };
            foreach (string namePos in ekipaIdsNamePos)
            {             
                string[] podela = namePos.Split(separators, StringSplitOptions.None);

                if (podela[2].Contains("GK"))
                {
                    GK.Add(pos);
                }
                if (podela[2].Contains("LB"))
                {
                    LB.Add(pos);
                }
                if (podela[2].Contains("CB") || podela[2].Contains("SW"))
                {
                    CB.Add(pos);
                }
                if (podela[2].Contains("RB") || podela[2].Contains("RWB"))
                {
                    RB.Add(pos);
                }
                if (podela[2].Contains("LMF"))
                {
                    LMF.Add(pos);
                }
                if (podela[2].Contains("CMF") || podela[2].Contains("DMF") || podela[2].Contains("AMF"))
                {
                    CMF.Add(pos);
                }
                if (podela[2].Contains("RMF"))
                {
                    RMF.Add(pos);
                }
                if (podela[2].Contains("CF") || podela[2].Contains("SS") || podela[2].Contains("LWS") || podela[2].Contains("RWS"))
                {
                    CF.Add(pos);
                }
                pos++;
            }

            try
            {
                startnih11.Add(izaberiNajboljeg(GK, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(LB, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(CB, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(CB, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(RB, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(LMF, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(CMF, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(CMF, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(RMF, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(CF, igraciSkill, startnih11));
                startnih11.Add(izaberiNajboljeg(CF, igraciSkill, startnih11));
            }
            catch (Exception ec)
            {
                MessageBox.Show("Doslo je do greske prilikom izbora tima! Da li igraci u reprezentaciji pokrivaju osnovne pozicije (Golman, Levi i desni bek, 2xstopera, levo i desno krilo, 2x vezna igraca i 2x napadaca) ?");
                MessageBox.Show(ec.ToString());
            }

            string[] posOcena = new string[11];

            for (int i = 0; i < 11; i++)
            {
                posOcena[i] = startnih11[i].ToString() + ":" + igraciSkill[startnih11[i]];
            }

            return posOcena;
        }


        int izaberiNajboljeg(List<int> position, double[] ekipaSkilovi, List<int> sastav)
        {
            double maxSkill = 0;
            int maxPos = -1;

            for (int i = 0; i < position.Count; i++)
            {
                if (maxSkill < ekipaSkilovi[position[i]])
                {
                    maxSkill = ekipaSkilovi[position[i]];
                    maxPos = position[i];
                }
            }

            while (sastav.Contains(maxPos))
            {
                if (position.Count == 0)
                    break;

                position.Remove(maxPos);

                maxSkill = 0;
                maxPos = -1;
                for (int i = 0; i < position.Count; i++)
                {
                    if (maxSkill < ekipaSkilovi[position[i]])
                    {
                        maxSkill = ekipaSkilovi[position[i]];
                        maxPos = position[i];
                    }
                }
            }

            return maxPos;
        }

        void updateSastavForm(double[] teamSkills, string[] posAndSkill, bool domacin)
        {
            Random rand = new Random();
            string noveOcene = "";
            // ---- Generisi random brojeve za oba tima naizmenicno ----
            string[] separators = new string[] { "<&>" };
            for (int i = 0; i < teamSkills.Length; i++)
            {
                string[] posSkill = posAndSkill[i].Split(':');
                int pos = Convert.ToInt32(posSkill[0]);
                if (domacin)
                {
                    string[] podela = idsNamePosDomaci[pos].Split(separators, StringSplitOptions.None);
                    noveOcene += (i + 1).ToString() + ". " + podela[1] + " " + teamSkills[i].ToString() + ';';
                }
                else 
                {
                    string[] podela = idsNamePosGosti[pos].Split(separators, StringSplitOptions.None);
                    noveOcene += (i + 1).ToString() + ". " + podela[1] + " " + teamSkills[i].ToString() + ';';
                }
            }
            noveOcene = noveOcene.TrimEnd(';');

            // ---- Update-ovanje ocene timova na formi
            if (domacin)
            {
                delUpdateFormInformations updatePostava = new delUpdateFormInformations(forma.updateTeamDomacin);
                forma.RtbSastavDomacin.BeginInvoke(updatePostava, noveOcene);
                Thread.Sleep(500);

            }
            else
            {
                delUpdateFormInformations updatePostava = new delUpdateFormInformations(forma.updateTeamGost);
                forma.RtbSastavGost.BeginInvoke(updatePostava, noveOcene);
                Thread.Sleep(500);
            }
  
        }

    }
}
