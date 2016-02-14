using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDriverTest
{
    public partial class FIzborReprezentacijaZaUtakmicu : Form
    {
        public FIzborReprezentacijaZaUtakmicu()
        {
            InitializeComponent();
        }

        private void BtnDomacin_Click(object sender, EventArgs e)
        {

            if (this.LvDomacin.SelectedItems.Count != 0)
            {
                //bool postoji = false;
                string imeRepke = LvDomacin.SelectedItems[0].Text;
                // --- Proveravamo da li ta pozicija vec postoji u listi ---
                if (imeRepke != TbGost.Text)
                {
                    TbDomacin.Text = imeRepke;
                }
                else
                {
                    TbGost.Text = "";
                    TbDomacin.Text = imeRepke;
                }
            }
            else
            {
                MessageBox.Show("Izaberite reprezentaciju koja je domacin!");
            }
        }

        private void BtnGost_Click(object sender, EventArgs e)
        {
            if (this.LvGost.SelectedItems.Count != 0)
            {
                //bool postoji = false;
                string imeRepke = LvGost.SelectedItems[0].Text;
                // --- Proveravamo da li ta pozicija vec postoji u listi ---
                if (imeRepke != TbDomacin.Text)
                {
                    TbGost.Text = imeRepke;
                }
                else
                {
                    TbDomacin.Text = "";
                    TbGost.Text = imeRepke;
                }
            }
            else
            {
                MessageBox.Show("Izaberite reprezentaciju koja je domacin!");
            }
        }

        private void FIzborReprezentacijaZaUtakmicu_Load(object sender, EventArgs e)
        {
            //var _client = new MongoClient();
            //var _database = _client.GetDatabase("test");
           // ListView podaci = new ListView();
           // AuxLib.UpdateReprezentacijeListView(podaci);
            AuxLib.UpdateReprezentacijeListView(LvDomacin);
            AuxLib.UpdateReprezentacijeListView(LvGost);
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TbDomacin.Text) && !String.IsNullOrWhiteSpace(TbGost.Text))
            {
                FInfoZaMec info = new FInfoZaMec(this, TbDomacin.Text, TbGost.Text);
                info.ShowDialog();
               // this.Dispose();
            }
            else
            {
                MessageBox.Show("Izaberite reprezentacije!");
            }
        }
    }
}
