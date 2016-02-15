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
        //private Image slikaReprezentacije;
        private FileStream himnaStream;
        private string formatHimna;
        private string formatSlika;
       // private string imeSlike;
        
        private Igrac elKapetano;
        //private bool testData;
        public FReprezentacija()
        {
            InitializeComponent();
            elKapetano = null;
            //testData = false;
        }

        private string CheckTeam()
        {
            int nGoalKeeper = 0;
            int nDefansive = 0;
            int nMidField = 0;
            int nOffansive = 0;
            int sum = 0;
            string [] Defansive  = {"SW","LB","CB","RB","LWB","RWB"};
            string [] MidField = {"DMF","CMF","LMF","RMF","AMF"};
            string [] Offansive = {"LWS","RWS","SS","CF"};
            foreach(ListViewItem igrac in this.LVSastav.Items)
            {
                //provera za svakog igraca gde igra.
                if (igrac.SubItems[6].Text == "GK")
                    nGoalKeeper++;
                else if (Defansive.Contains(igrac.SubItems[6].Text))
                    nDefansive++;
                else if (MidField.Contains(igrac.SubItems[6].Text))
                    nMidField++;
                else if (Offansive.Contains(igrac.SubItems[6].Text))
                    nOffansive++;
                sum++;
            }
            if(sum >= 11)
            {
                if (nGoalKeeper == 0)
                    return "Fali golman";
                if (nDefansive <= 3)
                    return "Fale " + (4 - nDefansive).ToString() + " u odbrani";
                if (nMidField <= 2)
                    return "Fale " + (3 - nMidField).ToString() + " na sredini";
                if (nOffansive == 0)
                    return "Nemate napadaca";

                return "Ok";
            }
            else
            {
                return "Nedovoljno igraca";
            }
        }


        private void FReprezentacija_Load(object sender, EventArgs e)
        {

            var filterForListView = new BsonDocument() 
                {
                    {"PripadaReprezentaciji",false}
                };
            AuxLib.UpdateIgraciListView(this.LvIgraci, filterForListView);
                
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
            if (String.IsNullOrWhiteSpace(this.tbIme.Text))
            {
                MessageBox.Show("Ime reprezentacije je obavezno!");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.tbSkracenica.Text))
            {
                MessageBox.Show("Skracenica je obavezna!(3 slova)");
                return;
            }
            if (String.IsNullOrWhiteSpace(this.tbSelektor.Text))
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
            string temp = this.CheckTeam();
            //provera pozicija tima
            if (temp != "Ok")
            {
                MessageBox.Show(temp);
                return;
            };

            try
            {
                //database access
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<Reprezentacija>("reprezentacije");
                //filters
                var filterAllCount = new BsonDocument();
                //var filterForUniqueCheck = Builders<BsonDocument>.Filter.Eq("Ime", this.tbIme.Text);
                var filter = new BsonDocument()
                {
                    {"Ime",tbIme.Text}
                };

                //test if reprezentacija exists
                var test = collection.Find(filter).FirstOrDefault();
                
                var countForID = collection.Count(filterAllCount);

                // model creating
                Reprezentacija forSave = new Reprezentacija();
                forSave.FifaRang = Convert.ToInt32(numFifaRang.Value);

                forSave.id = 777;
                forSave.IgracSaNajviseNastupa = StringCleaner.checkString(this.tbIgracSaNajviseNastupa.Text);
                forSave.Ime = StringCleaner.checkString(this.tbIme.Text);
                forSave.Kapiten = StringCleaner.checkString(elKapetano.PunoIme);
                forSave.Nadimak = StringCleaner.checkString(tbNadimak.Text);
                forSave.NajboljiStrelac = StringCleaner.checkString(this.tbNajboljiStrelac.Text);
                forSave.NajvecaPobedaPoraz = StringCleaner.checkString(this.tbNajvecaPobedaPoraz.Text);
                forSave.OsvojeneMedalje = StringCleaner.checkString(this.rtbOsvojeneMedalje.Text);
                foreach (ListViewItem item in this.LVSastav.Items)
                {
                    forSave.Sastav += item.SubItems[1].Text;
                    forSave.Sastav += ",";
                    forSave.SastavIDs += item.SubItems[0].Text;
                    forSave.SastavIDs += ",";
                }
                forSave.Sastav = forSave.Sastav.TrimEnd(',');
                forSave.SastavIDs = forSave.SastavIDs.TrimEnd(',');
                forSave.Selektor = StringCleaner.checkString(tbSelektor.Text);
                forSave.Skracenica = StringCleaner.checkString(tbSkracenica.Text);
                forSave.SportskaBiografija = StringCleaner.checkString(rtbSportskaBiografija.Text);


                //Serialization and BsonDocument creation


                //var document = forSave.ToBsonDocument();


                // insert or update check.
                if (test == null)
                {
                    collection.InsertOne(forSave);
                    AuxLib.UpdateIgracStatus(forSave.SastavIDs.Split(','), true);
                    
                    
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
                    forSave._id = test._id;
                    
                    //collection.UpdateOne(filterForUniqueCheck, document);
                    collection.ReplaceOne(filter, forSave);
                    MessageBox.Show("Reprezentacija :" + forSave.Ime + " uspesno azurirana.");
                }

                //ucitavanje slike iz strima u GridFS
                if(this.PBslikaReprezentacije.Image != null)
                {
                    AuxLib.deleteFromGridFS(forSave.Ime+"zastava");
                    if (!AuxLib.AddImageToGridFS(this.PBslikaReprezentacije.Image, forSave.Ime + "zastava", formatSlika))
                    {
                        MessageBox.Show("Slika nije ucitana uspesno.");
                    };
                }
                else 
                {
                    MessageBox.Show("Slika nije selektovana zato nije ubacena.");
                }

                //ucitavanje himne iz strima u GridFS
                if(himnaStream != null)
                {
                    if (AuxLib.AddSoundToGridFS(himnaStream, this.tbIme.Text + "himna", formatHimna))
                    {
                        MessageBox.Show("Uspesno ste dodali mp3 sadrzaja kao himnu reprezentacije.");
                    }
                }
                else 
                {
                    MessageBox.Show("Himna nije ubacena.");
                }
                //reset kapetana na null
                elKapetano = null;
                var filterForListView = new BsonDocument() 
                {
                    {"PripadaReprezentaciji",false}
                };
                AuxLib.UpdateIgraciListView(this.LvIgraci, filterForListView);
                this.LVSastav.Items.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string [] imena = { "Vladimir Stojkovic","Nemanja Vidic","Neven Subotic","Aleksandar Kolarov","Branislav Ivanovic",
                                  "Dusan Tadic","Zoran Tosic","Dejan Stankovic","Nemanja Matic","Aleksandar Mitrovic", "Adem Ljajic",
                                  "Simon Minjole","Mamadu Sako","Martin Skrtel","Alberto Moreno","N. Klajn","Cutinho","Adam Lalana",
                                  "Jordan Henderson","Lucas Leiva","Daniel Starigde","Robert Firmino"};
            string[] pozicije = { "GK", "CB", "CB", "LB", "RB", "LMF", "RMF", "CMF", "DMF", "CF", "SS", "GK", "CB", "CB", "LB", "RB", "LMF", "RMF", "CMF", "DMF", "CF", "SS" };
            //if(!testData)
           // {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<Igrac>("igraci");
                var filter = new BsonDocument();

               

                for(int i = 0 ; i < 22 ; i++)
                {
                    //Random r = new Random();
                    Igrac document = new Igrac();
                    document.PunoIme = imena[i];
                    document.Pozicija = pozicije[i];
                    document.DatumRodjenja = DateTime.Now.ToString();
                    document.PripadaReprezentaciji = false;
                    collection.InsertOne(document);
                }
                
                //collection.UpdateOne(filter,document);
                //testData = true;

                var filterForListView = new BsonDocument() 
                {
                    {"PripadaReprezentaciji",false}
                };
                AuxLib.UpdateIgraciListView(this.LvIgraci, filterForListView);
                MessageBox.Show("Done" + "Count:" + collection.Count(filter).ToString());
            //}
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if(testData)
           // {
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");

                //var collection = _database.GetCollection<BsonDocument>("igraci");
                _database.DropCollection("igraci");
                var filterForListView = new BsonDocument() 
                {
                    {"PripadaReprezentaciji",false}
                };
                AuxLib.UpdateIgraciListView(this.LvIgraci, filterForListView);
                MessageBox.Show("Obrisano.");
           // }
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if(this.tbIme.Text == "")
            //{
            //    MessageBox.Show("Unesite prvo ime reprezentacije.");
            //    return;
            //}
            FileStream fs;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var forSpliting = ofd.SafeFileName.Split('.');
                //imeSlike = this.tbIme.Text + "zastava";//forSpliting[0];
                formatSlika = forSpliting[1];

                if(formatSlika == "png" || formatSlika =="jpg" || formatSlika == "jpeg" || formatSlika == "bmp")
                {
                    fs = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    //slikaReprezentacije = Image.FromStream(fs);
                    PBslikaReprezentacije.Image = Image.FromStream(fs);
                }
                else
                {
                    MessageBox.Show("Podrzani formati slika su : png,jpg,jpeg i bmp.");
                }

                /*int duzina = Convert.ToInt32(fs.Length);
                byte[] bajtovi = new byte[duzina];
                fs.Seek(0, SeekOrigin.Begin);
                int bytesRead = fs.Read(bajtovi, 0, duzina);*/
            }  
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //if(this.tbIme.Text == "")
            //{
            //    MessageBox.Show("Unesite ime reprezentacije za koju ucitavate himnu.");
            //    return;
            //}
            try
            {
                //FileStream fs;
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var forSpliting = ofd.SafeFileName.Split('.');
                    //string imePesme = forSpliting[0];
                    formatHimna = forSpliting[1];
                    //if (format != "mp3")
                    //{
                    //    MessageBox.Show("Fajl mora biti u mp3 formatu.");
                    //    return;
                    //}
                    if (formatHimna == "mp3" || formatHimna == "MP3")
                    {
                        himnaStream = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                        MessageBox.Show("Himna uspesno ucitana.");
                        
                    }
                    else 
                    {
                        MessageBox.Show("Podrzani format je mp3."); 
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
