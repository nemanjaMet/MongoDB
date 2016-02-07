﻿using MongoDB.Bson;
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
                    var filter = new BsonDocument()
                    {
                        {"_id",LvIgraci.SelectedItems[0].Text}
                    };
                    collection.DeleteOne(filter);
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

                    var collection = _database.GetCollection<BsonDocument>("igraci");
                    var filter = new BsonDocument()
                    {
                        {"_id",LvIgraci.SelectedItems[0].Text}
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
                        {"Ime",LvIgraci.SelectedItems[0].Text}
                    };
                    collection.DeleteOne(filter);
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

                    var collection = _database.GetCollection<BsonDocument>("igraci");
                    var filter = new BsonDocument()
                    {
                        {"_id",LvIgraci.SelectedItems[0].Text}
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
                        {"Ime",LvIgraci.SelectedItems[0].Text}
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

                    var collection = _database.GetCollection<BsonDocument>("igraci");
                    var filter = new BsonDocument()
                    {
                        {"_id",LvIgraci.SelectedItems[0].Text}
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
            if (LvTakmicanja.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");

                    var collection = _database.GetCollection<BsonDocument>("stadioni");
                    var filter = new BsonDocument()
                    {
                        {"Ime",LvIgraci.SelectedItems[0].Text}
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
                MessageBox.Show("Selektuj igraca kog hoces da izbrises!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (LvTakmicanja.SelectedItems.Count != 0)
            {
                try
                {
                    var _client = new MongoClient();
                    var _database = _client.GetDatabase("test");

                    var collection = _database.GetCollection<BsonDocument>("treneri");
                    var filter = new BsonDocument()
                    {
                        {"_id",LvIgraci.SelectedItems[0].Text}
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
                MessageBox.Show("Selektuj igraca kog hoces da izbrises!");
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
