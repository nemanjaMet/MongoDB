﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MongoDriverTest.DomainModel
{
    class Stadion
    {
        public String Ime { get; set; } // Ime stadiona pr: 'Cair'
        public String Lokacija { get; set; } // pr: 'Srbija, Nis'
        public String Vlasnik { get; set; } // Klub koji koristi stadion pr: 'FK Radnicki Nis'
        public String Kapacitet { get; set; } // Pr: '18.151'
        public String Istorija { get; set; } // Nesto o stadionu
        //public Image SlikaStadiona { get; set; }
        //public String Izgradjen { get; set; } // Izgradjen ili otvoren;; mada ovo ne mora
    }
}
