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
using System.IO;
using MongoDB.DomainModel;

namespace MongoDriverTest
{
    public partial class FDodajTakmicenje : Form
    {
        public FDodajTakmicenje()
        {
            InitializeComponent();
        }
        // ----- ucitavanje podataka za reprezentacije iz baze i popunjavanje listview-a -----
        private void BtnAddRep_Click(object sender, EventArgs e)
        {
            //samo sam pozvao funkciju iz AuxLib
            AuxLib.UpdateReprezentacijeListView(this.LvCntryList);
        }
        // ---- popunjavanje listview imenima drzava, i za svaku se upisuje broj pobeda -----
        private void BtnAddCntry_Click(object sender, EventArgs e)
        {
            // provera da li postoji vec drzava sa imenom u LV.
            if(!String.IsNullOrWhiteSpace(TbCntryName.Text))
            {
                
                bool postoji = false;

                string imeDrzave = TbCntryName.Text;

                foreach(ListViewItem Item in LvStatistics.Items)
                {
                    //ako postoji samo se oznacava da vec postoji
                    if(Item.Text == imeDrzave)
                    {
                        postoji = true;
                    }
                }
                // --- popunjavanje lv-a!
                if(!postoji)
                {
                    ListViewItem lv1 = new ListViewItem(imeDrzave);
                    LvStatistics.Items.Add(lv1);
                }
                else
                {
                    MessageBox.Show("Za izabranu drzavu"+ imeDrzave +" vec postoji statistika!!");
                }
            }
            else
            {
                MessageBox.Show("Unesite ime drzave i koliko puta je pobedila!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ime = TbIme.Text;
            string opis = RtbOpis.Text;
            string sysIgranja = RtbSysIgr.Text;
            string posPobednik = TbLstWin.Text;
            //ne smeju da budu null!
            if(String.IsNullOrWhiteSpace(ime))
            {
                MessageBox.Show("Unesite ime takmicenja!");
            }
            if(String.IsNullOrWhiteSpace(opis))
            {
                MessageBox.Show("unesite opis takmicenja!");
            }
            if (String.IsNullOrWhiteSpace(sysIgranja))
            {
                MessageBox.Show("Unesite Sistem igranja!");
            }
            if (String.IsNullOrWhiteSpace(posPobednik))
            {
                MessageBox.Show("Unesite ime one reprezentacije koja je poslednja pobedila!");
            }
            //---- ucitavanje sa Lv-a
            string spisakDrzava = "";
            foreach(ListViewItem lv1 in LvCntryList.SelectedItems)
            {
                spisakDrzava += lv1.Text;
                spisakDrzava += ",";
                
            }
            
            string statistika = "";
            foreach(ListViewItem lv2 in LvStatistics.Items)
            {
                statistika += lv2.Text;
                statistika += ",";
            }
            

            
            try
            {
                
                //pristup bazi
                var client = new MongoClient();
                var database = client.GetDatabase("test");
                var collection = database.GetCollection<BsonDocument>("takmicenja");
                //filtri
                var filter = new BsonDocument();
                var filterForUniquCheck = Builders<BsonDocument>.Filter.Eq("Ime", ime);

                //provera da li postoji takmicenje
                var test = collection.Find(filterForUniquCheck).Count();

                Takmicenje novoTakmicenje = new Takmicenje();
                novoTakmicenje.Ime = StringCleaner.checkString(ime);
                novoTakmicenje.Opis = StringCleaner.checkString(opis);
                novoTakmicenje.SpisakDrzava = StringCleaner.checkString(spisakDrzava);
                novoTakmicenje.SistemIgranja = StringCleaner.checkString(sysIgranja);
                novoTakmicenje.PoslednjiPobednik = StringCleaner.checkString(posPobednik);
                novoTakmicenje.Statistika = StringCleaner.checkString(statistika);

                var document = novoTakmicenje.ToBsonDocument();

                if(test == 0)
                {
                    collection.InsertOne(document);
                    MessageBox.Show("Uspesno dodato takmicenje: " + novoTakmicenje.Ime + "!");
                }
                else
                {
                    collection.ReplaceOne(filterForUniquCheck, document);
                    MessageBox.Show("Takmicenje: " + novoTakmicenje.Ime + "je uspesno azurirano!");
                }
                this.Dispose();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
            
        }

        private void BtnRemRep_Click(object sender, EventArgs e)
        {
            if(LvCntryList.SelectedItems.Count !=0)
            {
                LvCntryList.SelectedItems[0].Remove();
            }
        }

        private void BtnRemCntry_Click(object sender, EventArgs e)
        {
            if(LvStatistics.SelectedItems.Count != 0)
            {
                LvStatistics.SelectedItems[0].Remove();
            }
        }
    }
}
