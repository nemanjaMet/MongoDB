using MongoDB.Bson;
using MongoDB.DomainModel;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDriverTest.DomainModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDriverTest
{
    public class AuxLib
    {
        public static async void UpdateIgraciListView(ListView LVForAdding)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Igrac>("igraci");
            var filter = new BsonDocument();

            var result = await collection.Find(filter).ToListAsync<Igrac>();

            foreach (Igrac doc in result)
            {
                //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

                //var json = doc.ToJson(jsonWriterSettings);
                //Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);

                ListViewItem lv1 = new ListViewItem(doc._id.ToString());
                lv1.SubItems.Add(doc.PunoIme);
                lv1.SubItems.Add(doc.MestoRodjenja);
                lv1.SubItems.Add(doc.DatumRodjenja.ToString());
                lv1.SubItems.Add(doc.TrenutniKlub);
                lv1.SubItems.Add(doc.Visina);
                lv1.SubItems.Add(doc.Pozicija);
                
               // lv1.SubItems.Add(doc.Visina);
               // lv1.SubItems.Add(doc.Pozicija);
                LVForAdding.Items.Add(lv1);
            }
        }
        public static async void UpdateReprezentacijeListView(ListView LVForAdding)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Reprezentacija>("reprezentacije");
            var filter = new BsonDocument();

            var result = await collection.Find(filter).ToListAsync<Reprezentacija>();

            foreach (Reprezentacija doc in result)
            {
                //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

                //var json = doc.ToJson(jsonWriterSettings);
                //Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);

                ListViewItem lv1 = new ListViewItem(doc.Ime);
                lv1.SubItems.Add(doc.Skracenica);
                lv1.SubItems.Add(doc.Selektor);
                lv1.SubItems.Add(doc.Kapiten);
                //lv1.SubItems.Add(doc.TrenutniKlub);

                LVForAdding.Items.Add(lv1);
            }
        }
        public static async void UpdateStadionListView(ListView LVForAdding)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Stadion>("stadioni");
            var filter = new BsonDocument();

            var result = await collection.Find(filter).ToListAsync<Stadion>();

            foreach (Stadion doc in result)
            {
                //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

                //var json = doc.ToJson(jsonWriterSettings);
                //Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);

                ListViewItem lv1 = new ListViewItem(doc.Ime);
                lv1.SubItems.Add(doc.Kapacitet);
                lv1.SubItems.Add(doc.Vlasnik);
                lv1.SubItems.Add(doc.Lokacija);
                lv1.SubItems.Add(doc.Istorija);

                LVForAdding.Items.Add(lv1);
            }
        }
        public static async void UpdateTakmicenjeListView(ListView LVForAdding)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Takmicenje>("takmicenja");
            var filter = new BsonDocument();

            var result = await collection.Find(filter).ToListAsync<Takmicenje>();

            foreach (Takmicenje doc in result)
            {
                //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

                //var json = doc.ToJson(jsonWriterSettings);
                //Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);

                ListViewItem lv1 = new ListViewItem(doc.Ime);
                lv1.SubItems.Add(doc.Opis);
                lv1.SubItems.Add(doc.SpisakDrzava.ToString());
                lv1.SubItems.Add(doc.SistemIgranja);
                lv1.SubItems.Add(doc.PoslednjiPobednik);
                lv1.SubItems.Add(doc.Statistika);

                LVForAdding.Items.Add(lv1);
            }
        }
        public static async void UpdateTrenerListView(ListView LVForAdding)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Trener>("treneri");
            var filter = new BsonDocument();

            var result = await collection.Find(filter).ToListAsync<Trener>();

            foreach (Trener doc in result)
            {
                //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

                //var json = doc.ToJson(jsonWriterSettings);
                //Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);

                ListViewItem lv1 = new ListViewItem(doc._id.ToString());
                lv1.SubItems.Add(doc.PunoIme);
                lv1.SubItems.Add(doc.DatumRodjenja);
                lv1.SubItems.Add(doc.TrenutniKlub);
                lv1.SubItems.Add(doc.TrenerskaKarijera);
                lv1.SubItems.Add(doc.MestoRodjenja);
                lv1.SubItems.Add(doc.Uspesi);
                LVForAdding.Items.Add(lv1);
            }
        }

        public static bool AddImageToGridFS(Image slika,string imeSlike,string format)
        {
            try
            {
                //provera da li postoji slika
                //var client = new MongoClient("mongodb://localhost");
                //var database = client.GetDatabase("docs");
                //var fs = new GridFSBucket(database);

                //var test = fs.DownloadAsBytesByName(imeSlike);
                
                
                byte[] data;
                MemoryStream stream = new MemoryStream();


                slika.Save(stream, slika.RawFormat);
                data = stream.ToArray();

                //string host = "localhost";
                //int port = 27017;
                //string databaseName = "docs";

                //var _client = new MongoClient();
                // var _database = (MongoDatabase)_client.GetDatabase("docs");

                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("docs");
                var fs = new GridFSBucket(database);
                GridFSUploadOptions opcije = new GridFSUploadOptions();

                opcije.ContentType = "image/"+format;
                opcije.ChunkSizeBytes = Convert.ToInt32(stream.Length) / 4;

                fs.UploadFromBytes(imeSlike, data, opcije);

                //var grid = new MongoGridFS(new MongoServer(new MongoServerSettings { Server = new MongoServerAddress(host, port) }), databaseName, new MongoGridFSSettings());

               // grid.Upload(m, imeSlike, new MongoGridFSCreateOptions
                //{
                    //Id = 1,
               //     ContentType = "image/"+format
               // });

                return true;
            }
           catch(Exception ex)
           {
               MessageBox.Show(ex.Message);
               return false;
           }
        }

        public static Image LoadImageFromGridFS(string imeSlike)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("docs");
                var fs = new GridFSBucket(database);

                
                var data = fs.DownloadAsBytesByName(imeSlike);

                MemoryStream stream = new MemoryStream(data);

                return Image.FromStream(stream);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static bool AddSoundToGridFS(FileStream stream,string imePesme,string format)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("docs");
                var fs = new GridFSBucket(database);
                //BsonValue test = new BsonValue();
                //fs.Delete()
                GridFSUploadOptions opcije = new GridFSUploadOptions();
                opcije.ContentType = "audio/"+format;
                opcije.ChunkSizeBytes = Convert.ToInt32(stream.Length) / 4;
                
                int duzina = Convert.ToInt32(stream.Length);
                byte[] bajtovi = new byte[duzina];
                stream.Seek(0, SeekOrigin.Begin);
                int bytesRead = stream.Read(bajtovi, 0, duzina);

                fs.UploadFromBytes(imePesme, bajtovi, opcije);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static byte[] LoadSoundFromGridFS(string reprezentacija)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost");
                var database = client.GetDatabase("docs");
                var fs = new GridFSBucket(database);

                var data = fs.DownloadAsBytesByName(reprezentacija);

                return data;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
