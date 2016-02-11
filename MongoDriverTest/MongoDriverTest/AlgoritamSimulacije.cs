using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MongoDriverTest
{
    class AlgoritamSimulacije
    {
        public delegate void delUpdateFormInformations(string info);

        FFudbalskaIgra forma;

        public AlgoritamSimulacije(FFudbalskaIgra ffi)
        {
            forma = ffi;
        }

        // ---- Simuliranje utakmice ----
        public void simulirajUtakmicu()
        {
            double[] domacin = new double[11];
            double[] gost = new double[11];

            // ---- Dodela skilova ----
            domacin = noviSkilovi(domacin, true, 1);
            gost = noviSkilovi(gost, false, 1);

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

                if (i == 15 || i == 30 || i == 45 || i == 60 || i == 75)
                {
                    // ---- Nova dodela skilova ----
                    domacin = noviSkilovi(domacin, true, 2);
                    gost = noviSkilovi(gost, false, 2);

                    if (i == 45)
                    {                      
                        forma.Minuti.BeginInvoke(updateMin, "Poluvreme (5s)");
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

            if (izborTima < 16)
            {
                // Napada Domacin
                return 1;
            }
            else if (izborTima > 84)
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
            string noveOcene = "";
            // ---- Generisi random brojeve za oba tima naizmenicno ----
            for (int i = 0; i < 11; i++)
            {
                int skill = rand.Next(1, 10);
                team[i] = Math.Round((team[i] + skill) / podeliSa, 1);
                noveOcene += team[i].ToString() + ';';
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
        }

    }
}
