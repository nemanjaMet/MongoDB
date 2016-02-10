using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB.DomainModel
{
    public class Reprezentacija
    {
        [BsonId]
        public ObjectId _id { get; set; }
        // ---- Osnovni podaci ----
        public long id { get; set; }
        public String Ime { get; set; }
        [BsonIgnoreIfNull]
        public String Nadimak { get; set; }
        public String Skracenica { get; set; } /*(sifra) 3 slovca, npr. SRB*/
        public String Selektor { get; set; } /*Trenutni selektor*/
        public String Kapiten { get; set; }
        [BsonIgnoreIfNull]
        public String IgracSaNajviseNastupa { get; set; } /*Igrac br.Nastupa;;1 do 3 igraca sa najvise nastupa*/
        [BsonIgnoreIfNull]
        public String NajboljiStrelac { get; set; } /*Igrac br.Golova;;1 do 3 igraca sa najvise golova*/
        [BsonIgnoreIfNull]
        public int FifaRang { get; set; } /*Moze i int da bude*/
        [BsonIgnoreIfNull]
        public String NajvecaPobedaPoraz { get; set; } /*Moze i da se odvoji, da ne budu zajedno*/
        // ---- Ostali podaci ----
        [BsonIgnoreIfNull]
        public String SportskaBiografija { get; set; } /*Neki opis o reprezentaciji*/
        [BsonIgnoreIfNull]
        public String OsvojeneMedalje { get; set; } /*Mozda nam treba reprezentacija sa najvecim brojem medalja???*/
        public String Sastav { get; set; } /*Trenutni sastav*/
        //public Image SlikaZastave { get; set; } /*ILI MOZDA BOLJE SLIKA GRBA*/
        //public Byte[] Himna { get; set; } /*Ne znam koji tip za mp3*/
    }
}
