using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MongoDB.DomainModel;

namespace MongoDriverTest
{
    public partial class FFudbalskaIgra : Form
    {
        //private FInfoZaMec info;
        private Reprezentacija domacin;
        private Reprezentacija gost;
        public FFudbalskaIgra()
        {
            InitializeComponent();
        }
        public FFudbalskaIgra(FInfoZaMec test,Reprezentacija domacin,Reprezentacija gost)
        {
          
            this.domacin = domacin;
            this.gost = gost;
            InitializeComponent();

            this.DomacinSkracenica.Text = domacin.Skracenica;
            this.GostSkracenica.Text = gost.Skracenica;

            

            test.Dispose();
        }

        
        Thread simulacijaUtakmice;

        public void updateMinut(string minut)
        {
            Minuti.Text = minut;
        }

        public void updateDomacinRez(string brojGolova)
        {
            RezultatDomacin.Text = brojGolova;
        }

        public void updateGostRez(string brojGolova)
        {
            RezultatGost.Text = brojGolova;
        }

        public void updateTeamDomacin(string skillPostave)
        {
            string[] skilovi = skillPostave.Split(';');
            string textOutput = "";
            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    textOutput += "GK   ";
                }
                else if (i == 1)
                {
                    textOutput += "LB    ";
                }
                else if (i > 1 && i < 4)
                {
                    textOutput += "CB   ";
                }
                else if (i == 4)
                {
                    textOutput += "RB   ";
                }
                else if ( i == 5)
                {
                    textOutput += "LMF ";
                }
                else if (i > 5 && i < 8)
                {
                    textOutput += "CMF";
                }
                else if (i == 8)
                {
                    textOutput += "RMF";
                }
                else if (i < 11)
                {
                    textOutput += "CF   ";
                }

                textOutput += "   " + skilovi[i] + Environment.NewLine ;
            }

            string rezervniIgraci = "" + Environment.NewLine;
            rezervniIgraci += "Rezervni igraci" + Environment.NewLine;
            bool klupa = false;
            for (int i = 11; i < skilovi.Length; i++)
            {
                klupa = true;
                rezervniIgraci += (i + 1).ToString() + ". " + skilovi[i] + Environment.NewLine;
            }

            if (klupa)
            {
                textOutput += rezervniIgraci;
            }

            RtbSastavDomacin.Text = textOutput;

            int brojKarakteraNovi = 0;
            int brojKarakteraStari = 0;
            int brojLinija = 0;
            foreach (string line in RtbSastavDomacin.Lines)
            {
                if (brojLinija == 0)
                {
                    brojKarakteraStari = brojKarakteraNovi;
                    brojKarakteraNovi += line.Length;
                    RtbSastavDomacin.Select(brojKarakteraStari, brojKarakteraNovi);
                    RtbSastavDomacin.SelectionColor = Color.Orange;
                }
                else if (brojLinija > 0 && brojLinija < 5)
                {
                    brojKarakteraStari = brojKarakteraNovi;
                    brojKarakteraNovi += line.Length + 1;
                    RtbSastavDomacin.Select(brojKarakteraStari, brojKarakteraNovi);
                    RtbSastavDomacin.SelectionColor = Color.Blue;
                }
                else if (brojLinija > 4 && brojLinija < 9)
                {
                    brojKarakteraStari = brojKarakteraNovi;
                    brojKarakteraNovi += line.Length + 1;
                    RtbSastavDomacin.Select(brojKarakteraStari, brojKarakteraNovi);
                    RtbSastavDomacin.SelectionColor = Color.Green;
                }
                else if (brojLinija > 8 && brojLinija < 12)
                {
                    brojKarakteraStari = brojKarakteraNovi;
                    brojKarakteraNovi += line.Length + 1;
                    RtbSastavDomacin.Select(brojKarakteraStari, brojKarakteraNovi);
                    RtbSastavDomacin.SelectionColor = Color.Red;
                }
                brojLinija++;
            }
            RtbSastavDomacin.Select(brojKarakteraStari, RtbSastavGost.TextLength);
            RtbSastavDomacin.SelectionColor = Color.Black;
        }

        public void updateTeamGost(string skillPostave)
        {
            string[] skilovi = skillPostave.Split(';');
            string textOutput = "";
            for (int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    textOutput += "GK   ";
                }
                else if (i == 1)
                {
                    textOutput += "LB    ";
                }
                else if (i > 1 && i < 4)
                {
                    textOutput += "CB   ";
                }
                else if (i == 4)
                {
                    textOutput += "RB   ";
                }
                else if (i == 5)
                {
                    textOutput += "LMF ";
                }
                else if (i > 5 && i < 8)
                {
                    textOutput += "CMF";
                }
                else if (i == 8)
                {
                    textOutput += "RMF";
                }
                else if (i < 11)
                {
                    textOutput += "CF   ";
                }               

                textOutput += "   " + skilovi[i] + Environment.NewLine;
            }

            string rezervniIgraci = "" + Environment.NewLine;
            rezervniIgraci += "Rezervni igraci" + Environment.NewLine;
            bool klupa = false;
            for (int i = 11; i < skilovi.Length; i++)
            {
                klupa = true;
                rezervniIgraci += (i + 1).ToString() + ". " + skilovi[i] + Environment.NewLine;
                // rezervniIgraci += Environment.NewLine + "Rezervni igraci" + Environment.NewLine;
            }

            if (klupa)
            {
                textOutput += rezervniIgraci;
            }

            RtbSastavGost.SelectionColor = Color.Black;
            RtbSastavGost.Text = textOutput;

            int brojKarakteraNovi = 0;
            int brojKarakteraStari = 0;
            int brojLinija = 0;
            foreach (string line in RtbSastavGost.Lines)
            {
                if (brojLinija == 0)
                {
                    brojKarakteraStari = brojKarakteraNovi;
                    brojKarakteraNovi += line.Length;
                    RtbSastavGost.Select(brojKarakteraStari, brojKarakteraNovi);
                    RtbSastavGost.SelectionColor = Color.Orange;
                }
                else if (brojLinija > 0 && brojLinija < 5)
                {
                    brojKarakteraStari = brojKarakteraNovi;
                    brojKarakteraNovi += line.Length+1;
                    RtbSastavGost.Select(brojKarakteraStari, brojKarakteraNovi);
                    RtbSastavGost.SelectionColor = Color.Blue;
                }
                else if (brojLinija > 4 && brojLinija < 9)
                {
                    brojKarakteraStari = brojKarakteraNovi ;
                    brojKarakteraNovi += line.Length+1;
                    RtbSastavGost.Select(brojKarakteraStari, brojKarakteraNovi);
                    RtbSastavGost.SelectionColor = Color.Green;
                }
                else if (brojLinija > 8 && brojLinija < 12)
                {
                    brojKarakteraStari = brojKarakteraNovi;
                    brojKarakteraNovi += line.Length+1;
                    RtbSastavGost.Select(brojKarakteraStari, brojKarakteraNovi);
                    RtbSastavGost.SelectionColor = Color.Red;
                }
                brojLinija++;
            }
            RtbSastavGost.Select(brojKarakteraStari, RtbSastavGost.TextLength);
            RtbSastavGost.SelectionColor = Color.Black;


        }

        public void updateDogadjaji(string dogadjaj)
        {

            string outputText = dogadjaj + Environment.NewLine;
            outputText += Environment.NewLine + RtbDogadjaji.Text;
            RtbDogadjaji.Text = outputText;

            int brojKarakteraStari = 0;
            int brojKarakteraNovi = -1;
            foreach (string line in RtbDogadjaji.Lines)
            {
                brojKarakteraNovi += line.Length + 1;
                if (line.Contains("DOMACIN"))
                {
                    RtbDogadjaji.SelectionLength = brojKarakteraNovi;
                    RtbDogadjaji.SelectionStart = brojKarakteraStari;
                    RtbDogadjaji.SelectionColor = Color.DarkRed;
                }
                else if (line.Contains("GOST"))
                {
                    RtbDogadjaji.SelectionLength = brojKarakteraNovi;
                    RtbDogadjaji.SelectionStart = brojKarakteraStari;
                    RtbDogadjaji.SelectionColor = Color.DarkBlue;
                }
                else
                {
                    RtbDogadjaji.SelectionLength = brojKarakteraNovi;
                    RtbDogadjaji.SelectionStart = brojKarakteraStari;
                    RtbDogadjaji.SelectionColor = Color.Black;
                }
                brojKarakteraStari = brojKarakteraNovi;

                //RtbDogadjaji.Select(brojKarakteraStari, RtbDogadjaji.TextLength);
            }
        }

        private void BtnSimulacijaUtakmice_Click(object sender, EventArgs e)
        {
            ScoreBoard.Visible = true;
            RtbDogadjaji.Enabled = true;
            RtbSastavDomacin.Enabled = true;
            RtbSastavGost.Enabled = true;

            

           // BtnSimulacijaUtakmice.Visible = false;
            if (simulacijaUtakmice == null || !simulacijaUtakmice.IsAlive)
            {
                AlgoritamSimulacije algo = new AlgoritamSimulacije(this,domacin.SastavIDs,gost.SastavIDs);
                simulacijaUtakmice = new Thread(new ThreadStart(algo.simulirajUtakmicu));
                simulacijaUtakmice.Start();
            }
        }

        public void SimulacijaGreska(string greska)
        {
            MessageBox.Show(greska);
            if (simulacijaUtakmice != null && simulacijaUtakmice.IsAlive)
            {
                simulacijaUtakmice.Abort();
            }
            this.Dispose();
        }

        private void FFudbalskaIgra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (simulacijaUtakmice != null && simulacijaUtakmice.IsAlive)
            {
                simulacijaUtakmice.Abort();
            }
        }
    }
}
