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
using MongoDB.Driver.Builders;
using System.Media;
using WMPLib;
using MongoDB.DomainModel;
using MongoDriverTest.DomainModel;
namespace MongoDriverTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            var document = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "2 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Italian" },
                { "grades", new BsonArray
                {
                new BsonDocument
                {
                    { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                    { "grade", "A" },
                    { "score", 11 }
                },
                new BsonDocument
                {
                    { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                    { "grade", "B" },
                    { "score", 17 }
                }
            }
        },
        { "name", "Vella" },
        { "restaurant_id", "41704620" }
    };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            collection.InsertOne(document);
            MessageBox.Show("Done");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            
            var collection = _database.GetCollection<BsonDocument>("radnici");
            var filter = new BsonDocument();
            //var count = 0;
            var cursor = collection.Find(filter);
            var lista = cursor.ToList();
                if (cursor.Count() > 0)
                {
                    var batch = cursor.ToJson();
                    MessageBox.Show(batch);
                }
                else { MessageBox.Show("Nema nista"); }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("preduzece");

            var collection = _database.GetCollection<BsonDocument>("radnici");
            var filter = new BsonDocument();
            var document = new BsonDocument
            {
                {"ime","Dule"},
                {"broj",1},
                {"lud",true}
            };
            collection.InsertOne(document);
            MessageBox.Show("Done");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("preduzece");
            
            var collection = _database.GetCollection<BsonDocument>("radnici");
            var filter = new BsonDocument();
            //var count = 0;
            var cursor = collection.Find(filter);
            var lista = cursor.ToList();
            
             var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
            //JObject json = JObject.Parse(prvi.ToJson<MongoDB.Bson.BsonDocument>(jsonWriterSettings));

            var prvi = lista.First().ToJson(jsonWriterSettings);
            Radnik r = Newtonsoft.Json.JsonConvert.DeserializeObject<Radnik>(prvi);
            MessageBox.Show(r.ime);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MemoryStream mem = new MemoryStream();

            Image image = Image.FromFile("E:\\a za fax\\VII semestar\\Grafika\\Sky.jpg");
            AuxLib.AddImageToGridFS(image, "nebo", "jpg");
           // byte[] data;
           // MemoryStream m = new MemoryStream();
           
           // image.Save(m, image.RawFormat);
           // data = m.ToArray();
           
           // string host = "localhost";
           // int port = 27017;
           // string databaseName = "docs";

           // var _client = new MongoClient();
           //// var _database = (MongoDatabase)_client.GetDatabase("docs");



           // var grid = new MongoGridFS(new MongoServer(new MongoServerSettings { Server = new MongoServerAddress(host, port) }), databaseName, new MongoGridFSSettings());
            
           // grid.Upload(m, "Test", new MongoGridFSCreateOptions
           // {
           //     Id = 1,
           //     ContentType = "image/bmp"
           // });



            //Stream memoryStream = new MemoryStream(book.Data);
            //MongoGridFSFileInfo gfsi = database.GridFS.Upload(memoryStream, book.Name);
            //BsonDocument photoMetadata = new BsonDocument
            //                             { { "FileName", "PAT39.BMT" },
            //                             { "Type", "image/bmp"},
            //                             { "Width", 128 },
            //                             { "Height", 128 }};
            //database.GridFS.SetMetadata(gfsi, photoMetadata);
            //book.ImageId = gfsi.Id.AsObjectId;
            //collection.Insert(book);
            MessageBox.Show("Added drvo in GridFS.");
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //string host = "localhost";
            //int port = 27017;
            //string databaseName = "docs";

            //var _client = new MongoClient();
            //// var _database = (MongoDatabase)_client.GetDatabase("docs");

           
            //MemoryStream m = new MemoryStream();
            
            //var grid = new MongoGridFS(new MongoServer(new MongoServerSettings { Server = new MongoServerAddress(host, port) }), databaseName, new MongoGridFSSettings());

            //var file = grid.FindOne("Test");
            ////MongoGridFSStream read = grid.OpenRead("Test");
            ////read.CopyTo(m);
            //Image slika;
            //var newFileName = "D:\\new_Untitled.jpg";
            //using (var stream = file.OpenRead())
            //{
            //    var bytes = new byte[stream.Length];
            //    stream.Read(bytes, 0, (int)stream.Length);
                
                
               
            //    using (var newFs = new FileStream(newFileName, FileMode.Create))
            //    {
                    
            //        newFs.Write(bytes, 0, bytes.Length);
            //        //slika = Image.FromStream(newFs);
            //    } 
            //}

            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("docs");
            var fs = new GridFSBucket(database);

            //var aaa = fs.Find()
            var test = fs.DownloadAsBytesByName("nebo");

            MemoryStream stream = new MemoryStream(test);

            this.pictureBox1.Image = Image.FromStream(stream);

            
           
        }

        private void reprezentacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FReprezentacija forma = new FReprezentacija();
            forma.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("docs");
            var fs = new GridFSBucket(database);

            var test = fs.DownloadAsBytesByName("Test");

            //System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            //Image img = (Image)converter.ConvertFrom(test);

            //MemoryStream mem = new MemoryStream(test);

            Image returnImage = null;
            using (MemoryStream ms = new MemoryStream(test))
            {
                returnImage = Image.FromStream(ms);
            }
            //return returnImage;
            //Bitmap x = new Bitmap(mem, true);

            this.pictureBox1.Image = returnImage;
            this.pictureBox1.Height = returnImage.Height;
            this.pictureBox1.Width = returnImage.Width;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Image slika;
            FileStream stream;
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("docs");
            var fs = new GridFSBucket(database);
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                stream = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                slika = Image.FromStream(stream);

                GridFSUploadOptions opcije = new GridFSUploadOptions();
                opcije.ContentType = "image/jpg";
                opcije.ChunkSizeBytes = Convert.ToInt32(stream.Length);

                int duzina = Convert.ToInt32(stream.Length);
                byte[] bajtovi = new byte[duzina];
                stream.Seek(0, SeekOrigin.Begin);
                int bytesRead = stream.Read(bajtovi, 0, duzina);

                fs.UploadFromBytes("Test", bajtovi, opcije);

            }
            MessageBox.Show("done");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FileStream stream;
            OpenFileDialog ofd = new OpenFileDialog();
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("docs");
            var fs = new GridFSBucket(database);
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                stream = new System.IO.FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                //SoundPlayer simpleSound = new SoundPlayer(stream);
                //simpleSound.Play();
                var split = ofd.SafeFileName.Split('.');
                if(split[1] != "mp3")
                {
                    MessageBox.Show("Izaberite mp3 fajl!");
                    return;
                }
                GridFSUploadOptions opcije = new GridFSUploadOptions();
                opcije.ContentType = "audio/mp3";
                opcije.ChunkSizeBytes = Convert.ToInt32(stream.Length)/4;

                int duzina = Convert.ToInt32(stream.Length);
                byte[] bajtovi = new byte[duzina];
                stream.Seek(0, SeekOrigin.Begin);
                int bytesRead = stream.Read(bajtovi, 0, duzina);

                fs.UploadFromBytes(ofd.SafeFileName, bajtovi, opcije);

            }
           
        }
        //Audio needs this .
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
        private void button10_Click(object sender, EventArgs e)
        {
            
            
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("docs");
            var fs = new GridFSBucket(database);
            
            //var aaa = fs.Find()
            var test = fs.DownloadAsBytesByName("Muzika");

            MemoryStream memStream = new MemoryStream(test);

            //OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "Audio File (*.mp3;*.wav)|*.mp3;*.wav;";
            //if (open.ShowDialog() != DialogResult.OK) return;

            DisposeWave();

           // if (open.FileName.EndsWith(".mp3"))
           // {
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(memStream));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
           // }
           // else if (open.FileName.EndsWith(".wav"))
            //{
            //    NAudio.Wave.WaveStream pcm = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));
            //    stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
            //}
            //else throw new InvalidOperationException("Not a correct audio file type.");

            output = new NAudio.Wave.DirectSoundOut();
            output.Init(stream);
            output.Play();


            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeWave();
        }

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void takmicenjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDodajTakmicenje forma = new FDodajTakmicenje();
            forma.ShowDialog();
        }

        private void igraciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDodavanjeIgraca forma = new FDodavanjeIgraca();
            forma.ShowDialog();
        }

        private void brisanjeIIzmenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBrisanjeIzmenaPodataka forma = new FBrisanjeIzmenaPodataka();
            forma.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            var collection = _database.GetCollection<BsonDocument>("testKolekcija");
   
            Reprezentacija r = new Reprezentacija();

            
            //r.Ime = null;
            //r.FifaRang = null;
            //r.id = null;

            var bsn = r.ToBsonDocument();

            collection.InsertOne(bsn);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            
        }

        private void infoFormaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reprezentacija r1 = new Reprezentacija();
            r1.Ime = "Srbija";           
            Reprezentacija r2 = new Reprezentacija();
            r2.Ime = "Nemacka";           
            Stadion s1 = new Stadion();
            s1.Ime = "Test";
            FInfoZaMec test = new FInfoZaMec(r1,r2,s1);
            test.ShowDialog();
        }

        private void stadionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDodavanjeStadiona test = new FDodavanjeStadiona();
            test.ShowDialog();
        }

        private void trenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDodavanjeTrenera test = new FDodavanjeTrenera();
            test.ShowDialog();

            FFudbalskaIgra ffi = new FFudbalskaIgra();
            ffi.ShowDialog();

        }
    }
}
