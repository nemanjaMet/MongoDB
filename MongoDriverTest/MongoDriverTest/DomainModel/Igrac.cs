using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MongoDB.DomainModel
{
    public class Igrac
    {
        // ---- Licni podaci ---- 

        public long id { get; set; }

       // public String Id { get; set; }
        [BsonId]
        public ObjectId _id { get; set; }
        public String PunoIme { get; set; }
/*
        public DateTime DatumRodjenja { get; set; }
	
*/
        [BsonIgnoreIfNull] //u implementaciji si stavio da moze da bude nullable, ako ne moze ovo brisi a tamo dodaj.
	    public String DatumRodjenja { get; set; }
        public String MestoRodjenja { get; set; }
        public String Visina { get; set; }
        public String Pozicija { get; set; }
        public String TrenutniKlub { get; set; }
        // ---- Ostali podaci ----
        [BsonIgnoreIfNull]
        public String SportskaBiografija { get; set; }
        [BsonIgnoreIfNull]
        public String ReprezentativnaKarijera { get; set; }
        [BsonIgnoreIfNull]
        public String Statistika { get; set; }
        [BsonIgnoreIfNull]
        public String Trofeji { get; set; }
        //public Image Slika { get; set; }
    }
}
