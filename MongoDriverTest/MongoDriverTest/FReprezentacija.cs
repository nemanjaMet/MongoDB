using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.DomainModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using MongoDB.Driver.Builders;
namespace MongoDriverTest
{
    public partial class FReprezentacija : Form
    {
        private Image slikaReprezentacije;
        private string format;
        private string imeSlike;
        
        private Igrac elKapetano;
        private bool testData;
        public FReprezentacija()
        {
            InitializeComponent();
            elKapetano = null;
            testData = false;
        }

       

        //update liste igraca prototip
        //private async void UpdateListView()
        //{
        //    var _client = new MongoClient();
        //    var _database = _client.GetDatabase("test");
        //    // mora Nemca da mi kaze gde ih smesta koja kolekcija
        //    var collection = _database.GetCollection<Igrac>("igraci");
        //    var filter = new BsonDocument();

        //    var result = await collection.Find(filter).ToListAsync<Igrac>();
            
        //    foreach (Igrac doc in result)
        //    {
        //        //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                
        //        //var json = doc.ToJson(jsonWriterSettings);
        //        //Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);

        //        ListViewItem lv1 = new ListViewItem(doc._id.ToString());
        //        lv1.SubItems.Add(doc.PunoIme);
        //        lv1.SubItems.Add(doc.DatumRodjenja.ToString());
        //        lv1.SubItems.Add(doc.Pozicija);
        //        lv1.SubItems.Add(doc.TrenutniKlub);

        //        LvIgraci.Items.Add(lv1);
        //    }
        //}
        private void FReprezentacija_Load(object sender, EventArgs e)
        {

            AuxLib.UpdateIgraciListView(this.LvIgraci);
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // PROVERAVA PO IMENU AKO IME NIJE UNIQUE NECE MOCI DVA SA ISTIM IMENOM U SASTAV
            /*if (this.LvIgraci.SelectedItems.Count != 0)
            {
                if(this.LVSastav.Items.Count == 30)
                {
                    MessageBox.Show("Sastav popunjen.");
                    return;
                }
                bool postoji = false;
                var test = this.LvIgraci.SelectedItems[0];
                foreach(ListViewItem item in LVSastav.Items)
                {
                    if(item.Text == test.Text)
                    {
                        postoji = true;
                    }
                }
                if(!postoji)
                {
                    var klon = test.Clone();
                    this.LVSastav.Items.Add((ListViewItem)klon);
                }
            }*/
    
            // Multiple select
            if (this.LvIgraci.SelectedItems.Count > 0)
            {
                foreach (ListViewItem ListItem in this.LvIgraci.Items)
                {
                    if (ListItem.Selected == true)
                    {
                        var klon = ListItem.Clone(); ;
                       /* if (!LVSastav.Items.Contains((ListViewItem)klon))
                        {
                            this.LVSastav.Items.Add((ListViewItem)klon);
                        }*/
                        ListViewItem duplikat = LVSastav.FindItemWithText(ListItem.Text);
                         if (duplikat == null)
                         {
                             this.LVSastav.Items.Add((ListViewItem)klon);
                         }
                    }
                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           /* if (this.LVSastav.SelectedItems.Count != 0)
            {
                for (int i = 0; i < this.LVSastav.Items.Count; i++)
                {
                    if (this.LVSastav.Items[i].Text == this.LVSastav.SelectedItems[0].Text)
                    {
                        this.LVSastav.Items.RemoveAt(i);
                    }
                }
                
            }*/

            if (this.LVSastav.SelectedItems.Count != 0)
            {
                this.LVSastav.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izbacis iz sastava!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.LVSastav.SelectedItems.Count != 0)
            {
                
                
                
                //long id = Convert.ToInt64(this.LVSastav.SelectedItems[0].Text);
                string id = this.LVSastav.SelectedItems[0].Text;
                ObjectId dbID= new ObjectId(id);
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<Igrac>("igraci");
                var filter = new BsonDocument() 
                {
                    {"_id",dbID}
                };
                
                //var count = 0;
                var cursor = collection.Find(filter);
                //var lista = cursor.First();

                //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                //JObject json = JObject.Parse(prvi.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));

                //var prvi = lista.First().ToJson(jsonWriterSettings);
                Igrac r = cursor.First();

                elKapetano = r;


                MessageBox.Show("Pronadjen  " + r.PunoIme);
                //upit u bazu sa filterom
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.tbIme.Text == "")
            {
                MessageBox.Show("Ime reprezentacije je obavezno!");
                return;
            }
            if (this.tbSkracenica.Text == "")
            {
                MessageBox.Show("Skracenica je obavezna!(3 slova)");
                return;
            }
            if (this.tbSelektor.Text == "")
            {
                MessageBox.Show("Selektor je obavezan!");
                return;
            }
            if (this.LVSastav.Items.Count < 11)
            {
                MessageBox.Show("Sastav je nepotpun!");
                return;
            }
            if (elKapetano == null)
            {
                MessageBox.Show("Morate izabrati kapitena!");
                return;
            }
            if (elKapetano != null)
            {
                ListViewItem kapitenNijeUlistu = LVSastav.FindItemWithText(elKapetano._id.ToString());
                if (kapitenNijeUlistu == null)
                {
                    MessageBox.Show("Morate izabrati kapitena!");
                    return;
                }                    
            }
            try
            {
                //database access
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<BsonDocument>("reprezentacije");
                //filters
                var filterAllCount = new BsonDocument();
                var filterForUniqueCheck = Builders<BsonDocument>.Filter.Eq("Ime", this.tbIme.Text);


                //test if reprezentacija exists
                var test = collection.Find(filterForUniqueCheck).Count();
                
                var countForID = collection.Count(filterAllCount);

                // model creating
                Reprezentacija forSave = new Reprezentacija();
                forSave.FifaRang = Convert.ToInt32(numFifaRang.Value);
                if (test == 0)
                {
                    forSave.id = countForID;
                }

                forSave.IgracSaNajviseNastupa = StringCleaner.checkString(this.tbIgracSaNajviseNastupa.Text);
                forSave.Ime = StringCleaner.checkString(this.tbIme.Text);
                forSave.Kapiten = StringCleaner.checkString(elKapetano.PunoIme);
                forSave.Nadimak = StringCleaner.checkString(tbNadimak.Text);
                forSave.NajboljiStrelac = StringCleaner.checkString(this.tbNadimak.Text);
                forSave.NajvecaPobedaPoraz = StringCleaner.checkString(this.tbNajvecaPobedaPoraz.Text);
                forSave.OsvojeneMedalje = StringCleaner.checkString(this.rtbOsvojeneMedalje.Text);
                foreach (ListViewItem item in this.LVSastav.Items)
                {
                    forSave.Sastav += item.SubItems[1].Text;
                    forSave.Sastav += ",";
                }
                forSave.Sastav = forSave.Sastav.TrimEnd(',');
                forSave.Selektor = StringCleaner.checkString(tbSelektor.Text);
                forSave.Skracenica = StringCleaner.checkString(tbSkracenica.Text);
                forSave.SportskaBiografija = StringCleaner.checkString(rtbSportskaBiografija.Text);


                //Serialization and BsonDocument creation


                var document = forSave.ToBsonDocument();


                // insert or update check.
                if (test == 0)
                {
                    collection.InsertOne(document);
                    MessageBox.Show("Reprezentacija :" + forSave.Ime + " uspesno dodata.");
                }
                else
                {
                    //var filter = Builders<BsonDocument>.Filter.Eq("name", "Juni");
                    //var update = Builders<BsonDocument>.Update
                    //    .Set("Ime", "American (New)")
                    //    .CurrentDate("lastModified")
                    //    .Set("","");
                    //var result = await collection.UpdateOneAsync(filter, update);

                    //collection.UpdateOne(filterForUniqueCheck, document);
                    collection.ReplaceOne(filterForUniqueCheck, document);
                    MessageBox.Show("Reprezentacija :" + forSave.Ime + " uspesno azurirana.");
                }
                if(slikaReprezentacije != null)
                {
                    AuxLib.AddImageToGridFS(slikaReprezentacije, imeSlike, format);
                }
                else 
                {
                    MessageBox.Show("Slika nije selektovana zato nije ubacena.");
                }
                //reset kapetana na null
                elKapetano = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!testData)
            {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<BsonDocument>("igraci");
                var filter = new BsonDocument();

               

                for(int i = 0 ; i < 11 ; i++)
                {
                    var test = collection.Count(filter);
                    var document = new BsonDocument
                    {
                   
                        {"id",test.ToString()},
                        {"PunoIme","Test"+test.ToString()},
                        {"Pozicija","Sve"},
                        {"TrenutniKlub","Real MadZid"},
                        {"DatumRodjenja","1.1.1991"}
                    

                    };
                collection.InsertOne(document);
                }
                
                //collection.UpdateOne(filter,document);
                testData = true;
                AuxLib.UpdateIgraciListView(this.LvIgraci);
                MessageBox.Show("Done" + "Count:" + collection.Count(filter).ToString());
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(testData)
            {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");

                var collection = _database.GetCollection<BsonDocument>("igraci");
                var filter = new BsonDocument()
                {
                    {"Pozicija","Sve"}
                };
                collection.DeleteMany(filter);
                testData = false;
                this.LvIgraci.Items.Clear();
                AuxLib.UpdateIgraciListView(this.LvIgraci);
                MessageBox.Show("Obrisano.");
            }
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(this.tbIme.Text == "")
            {
                MessageBox.Show("Unesite prvo ime reprezentacije.");
                return;
            }
            FileStream fs;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var forSpliting = ofd.SafeFileName.Split('.');
                imeSlike = this.tbIme.Text + "zastava";//forSpliting[0];
                format = forSpliting[1];

                fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                slikaReprezentacije = Image.FromStream(fs);
                PBslikaReprezentacije.Image = Image.FromStream(fs);

                /*int duzina = Convert.ToInt32(fs.Length);
                byte[] bajtovi = new byte[duzina];
                fs.Seek(0, SeekOrigin.Begin);
                int bytesRead = fs.Read(bajtovi, 0, duzina);*/
            }  
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(this.tbIme.Text == "")
            {
                MessageBox.Show("Unesite ime reprezentacije za koju ucitavate himnu.");
                return;
            }
            try
            {
                FileStream fs;
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var forSpliting = ofd.SafeFileName.Split('.');
                    string imePesme = forSpliting[0];
                    string format = forSpliting[1];
                    if (format != "mp3")
                    {
                        MessageBox.Show("Fajl mora biti u mp3 formatu.");
                        return;
                    }
                    fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);


                    if (AuxLib.AddSoundToGridFS(fs, this.tbIme.Text+"himna", format))
                    {
                        MessageBox.Show("Uspesno ste dodali mp3 sadrzaja kao himnu reprezentacije.");
                    }
                    
                    
                    /*int duzina = Convert.ToInt32(fs.Length);
                    byte[] bajtovi = new byte[duzina];
                    fs.Seek(0, SeekOrigin.Begin);
                    int bytesRead = fs.Read(bajtovi, 0, duzina);*/
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }
    }
}
