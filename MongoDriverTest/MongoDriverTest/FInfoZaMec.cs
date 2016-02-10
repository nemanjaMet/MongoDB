using MongoDB.Bson;
using MongoDB.DomainModel;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDriverTest.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDriverTest
{
    public partial class FInfoZaMec : Form
    {
        private Reprezentacija domacin;
        private Reprezentacija gost;
        private Stadion stadion;
        private bool notClosed;
        public FInfoZaMec()
        {
            InitializeComponent();

            this.domacin = null;
            this.gost = null;
            this.stadion = null;
            notClosed = true;
        }
        public FInfoZaMec(Reprezentacija domacin, Reprezentacija gost, Stadion stadion)
        {
            InitializeComponent();

            this.domacin = domacin;
            this.gost = gost;
            this.stadion = stadion;

            notClosed = true;
        }
        private NAudio.Wave.BlockAlignReductionStream stream = null;

        private NAudio.Wave.DirectSoundOut output = null;

        private void DisposeWave()
        {
            if (output != null)
            {
                if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                output.Dispose();
                output = null;
            }
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
        }
        private void FInfoZaMec_Load(object sender, EventArgs e)
        {
            try
            {
                //TO DO : UCITATI I FORMATIRATI INFORMACIJE O OBA TIMA I O STADIONU I UPISATI U RTB..
                //prvo za domacina
                AuxLib.PrikaziDomacinaRTB(RTBDomacinInfo, domacin.Ime);
                AuxLib.PrikaziGostaRTB(RTBGostInfo, gost.Ime);
                AuxLib.PrikaziStadionRTB(RTBStadionInfo, stadion.Ime);



                //-------------------------

                //ucitavanje slika iz gridFS-a
                this.PBDomacinZastava.Image = AuxLib.LoadImageFromGridFS(domacin.Ime + "zastava");
                this.PBGostZastava.Image = AuxLib.LoadImageFromGridFS(gost.Ime + "zastava");
                this.PBStadionZastava.Image = AuxLib.LoadImageFromGridFS(stadion.Ime + "stadion");
                //--------------------------

                //ucitamo himnu iz baze kao byte array
                byte[] domacinPesma = AuxLib.LoadSoundFromGridFS(domacin.Ime+"himna");
                //napravis stream
                MemoryStream domacinStream = new MemoryStream(domacinPesma);
                //prekines ako ima neka pesma prethodno ( za svaki slucaj );
                DisposeWave();
                //pcm pd strima
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(domacinStream));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);

                //init,hendler za drugu himnu i play
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.PlaybackStopped += output_PlaybackStopped;
                output.Play();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        //druga himna 
        void output_PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            if(notClosed)
            {
                try
                {
                    DisposeWave();

                    byte[] gostPesma = AuxLib.LoadSoundFromGridFS(gost.Ime + "himna");
                    MemoryStream gostStream = new MemoryStream(gostPesma);
                    NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(gostStream));
                    stream = new NAudio.Wave.BlockAlignReductionStream(pcm);


                    output = new NAudio.Wave.DirectSoundOut();
                    output.Init(stream);

                    output.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            
        }

        private void FInfoZaMec_FormClosing(object sender, FormClosingEventArgs e)
        {
            notClosed = false;
            this.DisposeWave();
        }
    }
}
