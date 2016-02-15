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
using MongoDB.Driver.Linq;
using System.IO;
using MongoDB.Driver.Builders;
using System.Media;
using WMPLib;
using MongoDB.DomainModel;
using MongoDriverTest.DomainModel;

namespace MongoDriverTest
{
    public partial class GlavnaForma : Form
    {
        public GlavnaForma()
        {
            InitializeComponent();
        }

        private void PbIgrac_Click(object sender, EventArgs e)
        {
            FDodavanjeIgraca fdi = new FDodavanjeIgraca();
            fdi.ShowDialog();
        }

        private void PbDodajStadion_Click(object sender, EventArgs e)
        {
            FDodavanjeStadiona fds = new FDodavanjeStadiona();
            fds.ShowDialog();
        }

        private void PbDodajReprezentaciju_Click(object sender, EventArgs e)
        {
            FReprezentacija fdr = new FReprezentacija();
            fdr.ShowDialog();
        }

        private void PbSimulirajUtakmicu_Click(object sender, EventArgs e)
        {
            FIzborReprezentacijaZaUtakmicu fsu = new FIzborReprezentacijaZaUtakmicu();
            fsu.ShowDialog();
        }

        private void PbDodajTakmicenje_Click(object sender, EventArgs e)
        {
            FDodajTakmicenje fdt = new FDodajTakmicenje();
            fdt.ShowDialog();
        }

        private void PbBrisanjePodataka_Click(object sender, EventArgs e)
        {
            FBrisanjeIzmenaPodataka fbp = new FBrisanjeIzmenaPodataka();
            fbp.ShowDialog();
        }

        private void PbDodajTrenera_Click(object sender, EventArgs e)
        {
            FDodavanjeTrenera fdt = new FDodavanjeTrenera();
            fdt.ShowDialog();
        }

        private void PbIgrac_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "KLIKNI";
        }

        private void PbIgrac_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "Dodaj igraca";
        }

        private void PbDodajStadion_MouseEnter(object sender, EventArgs e)
        {
            label2.Text = "KLIKNI";
        }

        private void PbDodajStadion_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = "Dodaj stadion";
        }

        private void PbDodajReprezentaciju_MouseEnter(object sender, EventArgs e)
        {
            label3.Text = "KLIKNI";
        }

        private void PbDodajReprezentaciju_MouseLeave(object sender, EventArgs e)
        {
            label3.Text = "Dodaj reprezentaciju";
        }

        private void PbSimulirajUtakmicu_MouseEnter(object sender, EventArgs e)
        {
            label4.Text = "KLIKNI";
        }

        private void PbSimulirajUtakmicu_MouseLeave(object sender, EventArgs e)
        {
            label4.Text = "Simuliraj utakmicu";
        }

        private void PbDodajTakmicenje_MouseEnter(object sender, EventArgs e)
        {
            label5.Text = "KLIKNI";
        }

        private void PbDodajTakmicenje_MouseLeave(object sender, EventArgs e)
        {
            label5.Text = "Dodaj takmicenje";
        }

        private void PbBrisanjePodataka_MouseEnter(object sender, EventArgs e)
        {
            label6.Text = "KLIKNI";
        }

        private void PbBrisanjePodataka_MouseLeave(object sender, EventArgs e)
        {
            label6.Text = "Brisanje podataka";
        }

        private void PbDodajTrenera_MouseEnter(object sender, EventArgs e)
        {
            label7.Text = "KLIKNI";
        }

        private void PbDodajTrenera_MouseLeave(object sender, EventArgs e)
        {
            label7.Text = "Dodaj trenera";
        }
    }
}
