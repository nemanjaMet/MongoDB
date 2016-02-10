using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDriverTest.DomainModel
{
    public class Trener
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public String PunoIme { get; set; } // Ime i Prezime
        public String MestoRodjenja { get; set; } // pr:' Srbija, Nis'
        public String DatumRodjenja { get; set; } 
        public String TrenutniKlub { get; set; } // U nasem slucaju bice reprezentacija pr: 'Srbija'
        public String TrenerskaKarijera { get; set; } // Klubove(Reprezentacije) koje je trenirao pr: 'Valencia 2004-2009, Liverpool 2009-2013, Spain 2013-?,...' ili neki tekst koji to opisuje
        //public Image SlikaTrenera { get; set; }
        public String Uspesi { get; set; } // Uspesi(medalje ili najveci uspeh) u svojoj trenerskoj karijeri;; Znaci moze vise da ih ima...
        // public String IgrackaKarijera { get; set; }

    }
}
