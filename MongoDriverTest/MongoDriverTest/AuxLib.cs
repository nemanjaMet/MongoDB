﻿using MongoDB.Bson;
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
        //setuje igracu sa datim IDom property pripadaReprezentaciji
        public static  void UpdateIgracStatus(string [] IDs,bool value)
        {
            
            foreach(string id in IDs)
            {
                ObjectId Oid = new ObjectId(id);
                var _client = new MongoClient();
                var _database = _client.GetDatabase("test");
                var collection = _database.GetCollection<BsonDocument>("igraci");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", Oid);
                var update = Builders<BsonDocument>.Update
                    .Set("PripadaReprezentaciji", value)
                    .CurrentDate("lastModified");

                var result =  collection.UpdateOne(filter, update);
            }
            
        }
        //public static async void UpdateFREEIgraciListView(ListView LVForAdding)
        //{
        //    LVForAdding.Items.Clear();
        //    var _client = new MongoClient();
        //    var _database = _client.GetDatabase("test");
        //    // mora Nemca da mi kaze gde ih smesta koja kolekcija
        //    var collection = _database.GetCollection<Igrac>("igraci");
        //    var filter = new BsonDocument() 
        //    {
        //        {"PripadaReprezentaciji",false}
        //    };

        //    var result = await collection.Find(filter).ToListAsync<Igrac>();

        //    foreach (Igrac doc in result)
        //    {
        //        //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

        //        //var json = doc.ToJson(jsonWriterSettings);
        //        //Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);

        //        ListViewItem lv1 = new ListViewItem(doc._id.ToString());
        //        lv1.SubItems.Add(doc.PunoIme);
        //        lv1.SubItems.Add(doc.MestoRodjenja);
        //        lv1.SubItems.Add(doc.DatumRodjenja.ToString());
        //        lv1.SubItems.Add(doc.TrenutniKlub);
        //        lv1.SubItems.Add(doc.Visina);
        //        lv1.SubItems.Add(doc.Pozicija);

        //        // lv1.SubItems.Add(doc.Visina);
        //        // lv1.SubItems.Add(doc.Pozicija);
        //        LVForAdding.Items.Add(lv1);
        //    }
        //}
        public static async void UpdateIgraciListView(ListView LVForAdding,BsonDocument filter)
        {
            LVForAdding.Items.Clear();
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Igrac>("igraci");
            //var filter = new BsonDocument();
            

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

        //-------- funkcija koja se poziva kad se ucitavaju informacije o domacem timu ---------
        internal static Reprezentacija PrikaziDomacinaRTB(RichTextBox RTBDomacinInfo, string p)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Reprezentacija>("reprezentacije");
            var filter = new BsonDocument() 
            {
                {"Ime",p}
            };

            //var result = await collection.Find(filter).ToListAsync<Reprezentacija>();
            var doc = collection.Find<Reprezentacija>(filter).FirstOrDefault();
            
            //foreach (Reprezentacija doc in result)
           // {
                //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

                // ---- proveravam da li se u bazi nalazi reprezentacija sa zadatim imenom? -------
                if (doc != null)
                {
                    // ----- ako se nalazi popunjavam RichTextBox sa osnovnim podacima --- -- --
                    RTBDomacinInfo.Text += "Ime: ";
                    RTBDomacinInfo.Text += doc.Ime;
                    RTBDomacinInfo.Text += Environment.NewLine;
                    RTBDomacinInfo.Text += "Nadimak: ";
                    RTBDomacinInfo.Text += doc.Nadimak;
                    RTBDomacinInfo.Text += Environment.NewLine;
                    RTBDomacinInfo.Text += "Skracenica: ";
                    RTBDomacinInfo.Text += doc.Skracenica;
                    RTBDomacinInfo.Text += Environment.NewLine;
                    RTBDomacinInfo.Text += "Selektor: ";
                    RTBDomacinInfo.Text += doc.Selektor;
                    RTBDomacinInfo.Text += Environment.NewLine;
                    RTBDomacinInfo.Text += "Kapiten: ";
                    RTBDomacinInfo.Text += doc.Kapiten;
                    RTBDomacinInfo.Text += Environment.NewLine;
                    RTBDomacinInfo.Text += "Igrac koji je najvise nastupao: ";
                    RTBDomacinInfo.Text += doc.IgracSaNajviseNastupa;
                    RTBDomacinInfo.Text += Environment.NewLine;
                    RTBDomacinInfo.Text += "Najbolji strelac: ";
                    RTBDomacinInfo.Text += doc.NajboljiStrelac;
                    RTBDomacinInfo.Text += Environment.NewLine;
                    RTBDomacinInfo.Text += "Rang: ";
                    RTBDomacinInfo.Text += doc.FifaRang;
                    if (doc.NajvecaPobedaPoraz != null && !String.IsNullOrWhiteSpace(doc.NajvecaPobedaPoraz))
                    {
                        RTBDomacinInfo.Text += Environment.NewLine;
                        RTBDomacinInfo.Text += "Najveca pobeda i poraz: ";
                        RTBDomacinInfo.Text += doc.NajvecaPobedaPoraz;
                    }
                    if (doc.OsvojeneMedalje != null && !String.IsNullOrWhiteSpace(doc.OsvojeneMedalje))
                    {
                        RTBDomacinInfo.Text += Environment.NewLine;
                        RTBDomacinInfo.Text += "Osvojene medalje: ";
                        RTBDomacinInfo.Text += doc.OsvojeneMedalje;
                    }
                    if (doc.SportskaBiografija != null && !String.IsNullOrWhiteSpace(doc.OsvojeneMedalje))
                    {
                        RTBDomacinInfo.Text += Environment.NewLine;
                        RTBDomacinInfo.Text += Environment.NewLine;
                        RTBDomacinInfo.Text += "Sportska biografija: ";
                        RTBDomacinInfo.Text += doc.SportskaBiografija;
                    }
                    return doc;
                }
                else
                {
                    MessageBox.Show("Ne postoji domaca reprezentacija sa navedenim imenom!");
                    return null;
                }
            //}
        }
        //funkcija za gosta
        internal static Reprezentacija PrikaziGostaRTB(RichTextBox RTBGostInfo, string p)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Reprezentacija>("reprezentacije");
            var filter = new BsonDocument() 
            {
                {"Ime",p}
            };

            //var result = await collection.Find(filter).ToListAsync<Reprezentacija>();
            var doc = collection.Find<Reprezentacija>(filter).FirstOrDefault();

            //foreach (Reprezentacija doc in result)
            //{
                //var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };

                //var json = doc.ToJson(jsonWriterSettings);
                //Igrac r = Newtonsoft.Json.JsonConvert.DeserializeObject<Igrac>(json);
                if (doc != null)
                {
                    RTBGostInfo.Text += "Ime: ";
                    RTBGostInfo.Text += doc.Ime;
                    RTBGostInfo.Text += Environment.NewLine;
                    RTBGostInfo.Text += "Nadimak: ";
                    RTBGostInfo.Text += doc.Nadimak;
                    RTBGostInfo.Text += Environment.NewLine;
                    RTBGostInfo.Text += "Skracenica: ";
                    RTBGostInfo.Text += doc.Skracenica;
                    RTBGostInfo.Text += Environment.NewLine;
                    RTBGostInfo.Text += "Selektor: ";
                    RTBGostInfo.Text += doc.Selektor;
                    RTBGostInfo.Text += Environment.NewLine;
                    RTBGostInfo.Text += "Kapiten: ";
                    RTBGostInfo.Text += doc.Kapiten;
                    RTBGostInfo.Text += Environment.NewLine;
                    RTBGostInfo.Text += "Igrac koji je najvise nastupao: ";
                    RTBGostInfo.Text += doc.IgracSaNajviseNastupa;
                    RTBGostInfo.Text += Environment.NewLine;
                    RTBGostInfo.Text += "Najbolji strelac: ";
                    RTBGostInfo.Text += doc.NajboljiStrelac;
                    RTBGostInfo.Text += Environment.NewLine;
                    RTBGostInfo.Text += "Rang: ";
                    RTBGostInfo.Text += doc.FifaRang;
                    RTBGostInfo.Text += Environment.NewLine;
                    return doc;
                }
                else
                {
                    MessageBox.Show("Ne postoji gostujuca reprezentacija sa navedenim imenom!");
                    return null;
                }
            
        }
        // ------- Funkcija kojom uzimamo podatke o stadionu i prikazujemo informacije u RichTextBoxu --------
        internal static  Stadion PrikaziStadionRTB(RichTextBox RTBStadionInfo, Reprezentacija domacin)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Stadion>("stadioni");
            var filter = new BsonDocument() 
            {
                {"ReprezentacijaID",domacin._id.ToString()}
            };
            var doc = collection.Find<Stadion>(filter).FirstOrDefault();
            //var result = await collection.Find(filter).ToListAsync<Stadion>();
            char[] delimeters = {','};
            //foreach (Stadion doc in result)
            //{
                //provera da li stadion postoji
                if(doc != null)
                {
                    RTBStadionInfo.Text += "Ime: ";
                    RTBStadionInfo.Text += doc.Ime;
                    RTBStadionInfo.Text += Environment.NewLine;
                    //da procitamo posebno drzavu a posebno grad!
                    string[] drziGrad = doc.Lokacija.Split(delimeters);
                    RTBStadionInfo.Text += "Drzava: ";
                    RTBStadionInfo.Text += drziGrad[0];
                    RTBStadionInfo.Text += Environment.NewLine;
                    RTBStadionInfo.Text += "Glavni grad: ";
                    RTBStadionInfo.Text += drziGrad[1];
                    RTBStadionInfo.Text += Environment.NewLine;
                    RTBStadionInfo.Text += "Vlasnik: ";
                    RTBStadionInfo.Text += doc.Vlasnik;
                    RTBStadionInfo.Text += Environment.NewLine;
                    RTBStadionInfo.Text += "Kapacitet: ";
                    RTBStadionInfo.Text += doc.Kapacitet;
                    RTBStadionInfo.Text += Environment.NewLine;
                    RTBStadionInfo.Text += "Istorija: ";
                    RTBStadionInfo.Text += doc.Istorija;
                    RTBStadionInfo.Text += Environment.NewLine;
                    return doc;
                }
                else
                {
                    MessageBox.Show("Stadion nije pronadjen!!");
                    return null;
                }
            //}
        }

        //delete from GridFS (old api)
        public static void deleteFromGridFS(string imeFajla)
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            var database = server.GetDatabase("docs");
            var gridFs = new MongoGridFS(database);
            gridFs.Delete(imeFajla);
        }

        // proverava da li je u ime u tekstboxu validna reprezentacija u bazi i signalizira bojom
        public static async void Check(string ime,TextBox TBox)
        {
            var _client = new MongoClient();
            var _database = _client.GetDatabase("test");
            // mora Nemca da mi kaze gde ih smesta koja kolekcija
            var collection = _database.GetCollection<Reprezentacija>("reprezentacije");
            var filter = new BsonDocument() 
            {
                {"Ime",ime}
            };

            var result = await collection.Find(filter).FirstOrDefaultAsync<Reprezentacija>();

            if(result == null)
            {
                TBox.BackColor = Color.Red;
            }
            else 
            {
                TBox.BackColor = Color.Green;
            }
        }
        
        
    }
}
