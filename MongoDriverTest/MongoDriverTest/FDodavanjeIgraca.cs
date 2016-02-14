using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.DomainModel;
using System.Text.RegularExpressions;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Bson.IO;
using MongoDB.Driver.GridFS;
using System.IO;
using System.Drawing;

namespace MongoDriverTest
{
    public partial class FDodavanjeIgraca : Form
    {
        private Image slika;
        private string format;
        public FDodavanjeIgraca()
        {
            InitializeComponent();
        }

        // --- Brisanje pozicije iz listView-a
        private void BtnIzbrisiPoziciju_Click(object sender, EventArgs e)
        {
            if (LvPozicijeIgraca.SelectedItems.Count != 0)
            {
                LvPozicijeIgraca.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj poziciju koju hoces da izbrises!");
            }
        }

        private void BtnDodajPoziciju_Click(object sender, EventArgs e)
        {
            // --- Provera da li je nesto selektovano u ComboBoxu ---
            if (Convert.ToInt32(CbPosition.SelectedIndex) != -1)
            {
                bool postoji = false;
                string pozicija = CbPosition.SelectedItem.ToString();
                // --- Proveravamo da li ta pozicija vec postoji u listi ---
                foreach (ListViewItem Item in LvPozicijeIgraca.Items)
                {
                    if (Item.Text == pozicija)
                    {
                        postoji = true;
                    }
                }
                // --- Ako ne postoji, ubacujemo poziciju ---
                if (!postoji)
                {
                    ListViewItem lv1 = new ListViewItem(pozicija);
                    LvPozicijeIgraca.Items.Add(lv1);

                    CbPosition.SelectedItem = null;
                    CbPosition.Text = "Izaberi poziciju";
                }
                else
                {
                    MessageBox.Show("Pozicija '" + pozicija + "' je vec dodata.");
                }
            }
            else
            {
                MessageBox.Show("Izaberite poziciju!");
            }
        }

        private void TbVisina_KeyPress(object sender, KeyPressEventArgs e)
        {
            // --- Omogucavanje backspace-a tj. brisanje jednog karaktera ---
            if (e.KeyChar == '\b')
            {
                if (TbVisina.Text.Length > 0)
                    TbVisina.Text = TbVisina.Text.Remove(TbVisina.Text.Length - 1);             
            }

            // --- Ako je duzina texta 1 onda dozvoli samo tacku ---
            if (TbVisina.Text.Length == 1)
            {
                if (e.KeyChar != '.')
                {
                    e.Handled = true;                   
                }
            }
            else // --- dozvoli unos bilo kog broja ---
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void BtnDodajIgraca_Click(object sender, EventArgs e)
        {
            // ---- Provera ispravnosti licnih podataka ----
            if (String.IsNullOrWhiteSpace(TbPunoIme.Text))
            {
                MessageBox.Show("Unesite puno ime igraca!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbMestoRodjenja.Text))
            {
                MessageBox.Show("Unesite mesto rodjenja igraca!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbTrenutniKlub.Text))
            {
                MessageBox.Show("Unesite trenutni (ili poslednji) klub igraca!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbVisina.Text) || TbVisina.Text.Length != 4)
            {   
                MessageBox.Show("Unesite ispravno vrednost visine igraca! Na primer '1.92' ");
                return; /*AKO JE OBAVEZNO POLJE*/
            }
            else if (LvPozicijeIgraca.Items.Count == 0)
            {
                MessageBox.Show("Ubacite poziciju/je na kojoj igrac igra!");
                return;
            }

            // ---- Izvlacimo pozicije igraca ----
            string pozicije = "";
            foreach (ListViewItem lvi in LvPozicijeIgraca.Items)
            {
                pozicije += lvi.Text + ", ";
            }
            pozicije = pozicije.TrimEnd(',');

            // ---- Ubacujemo podatke u objekat ----
            Igrac noviIgrac = new Igrac();
            // ---- Licni podaci ----
            noviIgrac.PunoIme = StringCleaner.checkString(TbPunoIme.Text);
            noviIgrac.MestoRodjenja = StringCleaner.checkString(TbMestoRodjenja.Text);
            noviIgrac.DatumRodjenja = DpDatumRodjenja.Text; /*Treba se ispravi*/
            noviIgrac.Visina = StringCleaner.checkString(TbVisina.Text);
            noviIgrac.TrenutniKlub = StringCleaner.checkString(TbTrenutniKlub.Text);
            noviIgrac.Pozicija = StringCleaner.checkString(pozicije);
            // ---- Ostali podaci ----
            noviIgrac.SportskaBiografija = StringCleaner.checkString(RtbSportksaBiografija.Text);
            noviIgrac.ReprezentativnaKarijera = StringCleaner.checkString(RtbReprezentativnaKarijera.Text);
            noviIgrac.Statistika = StringCleaner.checkString(RtbStatistika.Text);
            noviIgrac.Trofeji = StringCleaner.checkString(RtbTrofeji.Text);

            // ------------------ID------------------------


            //noviIgrac.Id = new BsonObjectId("");
            
            //----------------------------------------------

            // ---- Rad sa bazom ----
            try
            {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");

                var collection = _database.GetCollection<Igrac>("igraci");
                var filter = new BsonDocument();
               // var document = noviIgrac.ToBsonDocument();
                collection.InsertOne(noviIgrac);
                collection.ReplaceOne(filter, noviIgrac);
                if(slika != null)
                {
                    AuxLib.deleteFromGridFS(noviIgrac._id + "igrac");
                    AuxLib.AddImageToGridFS(slika, noviIgrac._id + "igrac", format);
                }
                MessageBox.Show("Uspesno dodat novi igrac!");
                
                // ---- Zatvaranje forme ----
                this.Dispose();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
            
        }


        private void BtnUcitajSliku_Click_1(object sender, EventArgs e)
        {
            try
            {
                FileStream fs;
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (ofd.SafeFileName.Split('.')[1] == "jpg" || ofd.SafeFileName.Split('.')[1] == "png" || ofd.SafeFileName.Split('.')[1] == "jpeg")
                    {
                        format = ofd.SafeFileName.Split('.')[1];
                        fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                        slika = Image.FromStream(fs);
                        PbSlikaIgraca.Image = Image.FromStream(fs);

                        int duzina = Convert.ToInt32(fs.Length);
                        byte[] bajtovi = new byte[duzina];
                        fs.Seek(0, SeekOrigin.Begin);
                        int bytesRead = fs.Read(bajtovi, 0, duzina);
                    }

                    else
                    {
                        MessageBox.Show("Nepodrzan tip podataka,slika moze biti u jpg ili png formatu.");
                        return;
                    }


                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
              
        }


    }
}
