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

        private void BtnAddRep_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(TbRepName.Text))
            {
                bool postoji = false;
                string ImeRep = TbRepName.Text;

                foreach (ListViewItem Item in LvCntryList.Items)
                {
                    if(Item.Text == ImeRep)
                    {
                        postoji = true;
                    }
                }

                if(!postoji)
                {
                    ListViewItem lv1 = new ListViewItem(ImeRep);
                    LvCntryList.Items.Add(lv1);
                }
                else
                {
                    MessageBox.Show("Reprezentacija"+ ImeRep +" je vec na spisku!!");
                }
            }
            else
            {
                MessageBox.Show("Unesite ime reprezentacije!!");
            }
        }

        private void BtnAddCntry_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(TbCntryName.Text))
            {
                bool postoji = false;

                string imeDrzave = TbCntryName.Text;

                foreach(ListViewItem Item in LvStatistics.Items)
                {
                    if(Item.Text == imeDrzave)
                    {
                        postoji = true;
                    }
                }

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

            string spisakDrzava = "";
            foreach(ListViewItem lv1 in LvCntryList.Items)
            {
                spisakDrzava += lv1.Text;
            }
            spisakDrzava = spisakDrzava.TrimEnd(',');

            string statistika = "";
            foreach(ListViewItem lv2 in LvStatistics.Items)
            {
                statistika += lv2.Text;
            }
            statistika = statistika.TrimEnd(',');

            //dodavanje podataka u pokusaju
            try
            {
                Takmicenje novoTakmicenje = new Takmicenje();
                novoTakmicenje.Ime = ime;
                novoTakmicenje.Opis = opis;
                novoTakmicenje.SpisakDrzava = spisakDrzava;
                novoTakmicenje.SistemIgranja = sysIgranja;
                novoTakmicenje.PoslednjiPobednik = posPobednik;
                novoTakmicenje.Statistika = statistika;

                var client = new MongoClient();
                var database = client.GetDatabase("test");

                var collection = database.GetCollection<BsonDocument>("takmicenja");
                var filter = new BsonDocument();
                var document = novoTakmicenje.ToBsonDocument();
                collection.InsertOne(document);
                MessageBox.Show("Uspesno dodato novo Takmicenje!");
                this.Dispose();
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
            
        }
    }
}
