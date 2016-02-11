using MongoDB.Bson;
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
using MongoDB.Driver.GridFS;

namespace MongoDriverTest
{
    public partial class FBrisanjeIzmenaPodataka : Form
    {
        public FBrisanjeIzmenaPodataka()
        {
            InitializeComponent();
        }

        private void BtnIzbrisiIgraca_Click(object sender, EventArgs e)
        {
            if (LvIgraci.SelectedItems.Count != 0)
            {
                //db removal
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");

                    var collection = _database.GetCollection<BsonDocument>("igraci");
                    ObjectId dbID = new  ObjectId(LvIgraci.SelectedItems[0].Text);
                    var filter = new BsonDocument()
                    {
                        {"_id",dbID}
                    };
                    collection.DeleteOne(filter);

                    // ---- Brisanje slike igraca iz baze ----
                    string imeSlike = "igrac" + LvIgraci.SelectedItems[0].SubItems[1].Text;
                    AuxLib.deleteFromGridFS(imeSlike);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                //string LvIgraci.SelectedItems[0].Text;

                // ---- Izbaci igraca iz listView ----
                LvIgraci.SelectedItems[0].Remove();

            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izbrises!");
            }
        }

        private void BtnIzmeniIgraca_Click(object sender, EventArgs e)
        {
            if (LvIgraci.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");
                    ObjectId dbID = new ObjectId(LvIgraci.SelectedItems[0].Text);
                    var collection = _database.GetCollection<BsonDocument>("igraci");
                    var filter = new BsonDocument()
                    {
                        {"_id",dbID}
                    };
                    collection.DeleteOne(filter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izmenis!");
            }
        }

        private void BtnIzbrisiReprezentaciju_Click(object sender, EventArgs e)
        {
            if (LvReprezentacije.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");
                    
                    var collection = _database.GetCollection<BsonDocument>("reprezentacije");
                    var filter = new BsonDocument()
                    {
                        {"Ime", LvReprezentacije.SelectedItems[0].Text}
                    };
                    collection.DeleteOne(filter);

                    string imeFajla = LvReprezentacije.SelectedItems[0].Text;
                    // Brisanje zastave
                    AuxLib.deleteFromGridFS("zastava"+imeFajla);
                    // Brisanje himne
                    AuxLib.deleteFromGridFS("himna"+imeFajla);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // ---- Izbaci igraca iz listView ----
                LvReprezentacije.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj reprezentaciju koju hoces da izbrises!");
            }
        }

        private void BtnIzmeniReprezentaciju_Click(object sender, EventArgs e)
        {
            if (LvReprezentacije.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");
                    ObjectId dbID = new ObjectId(LvIgraci.SelectedItems[0].Text);
                    var collection = _database.GetCollection<BsonDocument>("igraci");
                    var filter = new BsonDocument()
                    {

                        {"_id",dbID}

                    };
                    collection.DeleteOne(filter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izmenis!");
            }
        }

        private void BtnIzbrisiTakmicenje_Click(object sender, EventArgs e)
        {
            if (LvTakmicanja.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");

                    var collection = _database.GetCollection<BsonDocument>("takmicenja");
                    var filter = new BsonDocument()
                    {
                        {"Ime",LvTakmicanja.SelectedItems[0].Text}
                    };
                    collection.DeleteOne(filter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // ---- Izbaci igraca iz listView ----
                LvTakmicanja.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj takmicenje koje hoces da izbrises!");
            }
        }

        private void BtnIzmeniTakmicenje_Click(object sender, EventArgs e)
        {
            if (LvTakmicanja.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");
                    ObjectId dbID = new ObjectId(LvIgraci.SelectedItems[0].Text);
                    var collection = _database.GetCollection<BsonDocument>("igraci");
                    var filter = new BsonDocument()
                    {

                        {"_id",dbID}

                    };
                    collection.DeleteOne(filter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selektuj igraca kog hoces da izmenis!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LVStadioni.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");

                    var collection = _database.GetCollection<BsonDocument>("stadioni");
                    var filter = new BsonDocument()
                    {
                        {"Ime",LVStadioni.SelectedItems[0].Text}
                    };
                    collection.DeleteOne(filter);

                    // Brisanje slike
                    string imeStadiona = LVStadioni.SelectedItems[0].Text;
                    AuxLib.deleteFromGridFS("stadion" + imeStadiona);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // ---- Izbaci igraca iz listView ----
                LVStadioni.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj stadion koji hoces da izbrises!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (LVTreneri.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");
                    ObjectId dbID = new ObjectId(LVTreneri.SelectedItems[0].Text);
                    var collection = _database.GetCollection<BsonDocument>("treneri");
                    var filter = new BsonDocument()
                    {

                        {"_id",dbID}

                    };
                    collection.DeleteOne(filter);
                    
                    // Brisanje slike
                    string imeSlike = LVTreneri.SelectedItems[0].Text;
                    AuxLib.deleteFromGridFS("trener" + imeSlike);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // ---- Izbaci igraca iz listView ----
                LVTreneri.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Selektuj trenera kog hoces da izbrises!");
            }
        }

        private void FBrisanjeIzmenaPodataka_Shown(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            AuxLib.UpdateIgraciListView(this.LvIgraci);
            AuxLib.UpdateReprezentacijeListView(this.LvReprezentacije);
            AuxLib.UpdateStadionListView(this.LVStadioni);
            AuxLib.UpdateTakmicenjeListView(this.LvTakmicanja);
            AuxLib.UpdateTrenerListView(this.LVTreneri);
            
        }
       
    }
}
