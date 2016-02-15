using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Bson.IO;
using MongoDB.Driver.GridFS;
using MongoDB.DomainModel;
using System.IO;

namespace MongoDriverTest.DomainModel
{
    public partial class FDodavanjeTrenera : Form
    {
        private Image slikaTrenera;
        private string format;
        private string imeSlike;
        public FDodavanjeTrenera()
        {
            InitializeComponent();
        }

        // ---- Ucitavanje slike -----
        private void BtnUcitajSlikuTrenera_Click(object sender, EventArgs e)
        {
            //Image slika;
            FileStream fs;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var forSpliting = ofd.SafeFileName.Split('.');
                imeSlike = forSpliting[0];
                format = forSpliting[1];

                fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                slikaTrenera = Image.FromStream(fs);
                PbSlikaTrenera.Image = Image.FromStream(fs);

                /*int duzina = Convert.ToInt32(fs.Length);
                byte[] bajtovi = new byte[duzina];
                fs.Seek(0, SeekOrigin.Begin);
                int bytesRead = fs.Read(bajtovi, 0, duzina);*/
            }   
        }

        // ---- Ubacivanje podataka u bazi ----
        private void BtnSubmitData_Click(object sender, EventArgs e)
        {
            // ---- Provera ispravnosti podataka ----
            if (String.IsNullOrWhiteSpace(TbPunoIme.Text))
            {
                MessageBox.Show("Unesi Puno ime trenera!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbMestoRodjenja.Text))
            {
                MessageBox.Show("Unesi mesto rodjenja trenera!");
                return;
            }
            else if (String.IsNullOrWhiteSpace(TbTrenutniKlub.Text))
            {
                MessageBox.Show("Unesi trenutni klub(reprezentaciju) koju trenira trener!");
                return;
            }
            else if (this.TbTrenutniKlub.BackColor == Color.Red)
            {
                MessageBox.Show("Napisana reprezentacija ne postoji u bazi.");
                return;
            }
            Trener forSave = new Trener();
            forSave.PunoIme = StringCleaner.checkString(TbPunoIme.Text);
            forSave.MestoRodjenja = StringCleaner.checkString(TbMestoRodjenja.Text);
            forSave.TrenutniKlub = StringCleaner.checkString(TbTrenutniKlub.Text);
            forSave.TrenerskaKarijera = StringCleaner.checkString(RtbTrenerskaKarijera.Text);
            forSave.Uspesi = StringCleaner.checkString(RtbUspesi.Text);
            forSave.DatumRodjenja = StringCleaner.checkString(dateTimePicker1.Value.ToShortDateString());

            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");

            var collection = _database.GetCollection<Trener>("treneri");
            
            var filter = new BsonDocument() 
            {
                {"PunoIme",TbPunoIme.Text}
            };


            //var document = forSave.ToBsonDocument();
            //test if  exists
            var test = collection.Find(filter).Count();

            if(test == 0)
            {
                collection.InsertOne(forSave);
                if (slikaTrenera != null)
                {
                    AuxLib.AddImageToGridFS(slikaTrenera, forSave.PunoIme+"trener", format);
                }
                
                MessageBox.Show("Uspesno dodat novi trener!");
            }
            else
            {
                //TO DO : URADITI UPDATE SLIKE (AuxLib treba da ima remove image i remove mp3 i da se izbaci slika i ubaci nova);
                collection.ReplaceOne(filter, forSave);
                MessageBox.Show("Uspesno azuriran trener!");
            }
            
            
        }

        private void TbTrenutniKlub_Leave(object sender, EventArgs e)
        {
            AuxLib.Check(this.TbTrenutniKlub.Text, this.TbTrenutniKlub);
        }
    }
}
