﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MongoDB.DomainModel
{
    class Reprezentacija
    {
        // ---- Osnovni podaci ----
        public long id { get; set; }
        public String Ime { get; set; }
        public String Nadimak { get; set; }
        public String Skracenica { get; set; } /*(sifra) 3 slovca, npr. SRB*/
        public String Selektor { get; set; } /*Trenutni selektor*/
        public String Kapiten { get; set; }
        public String IgracSaNajviseNastupa { get; set; } /*Igrac br.Nastupa;;1 do 3 igraca sa najvise nastupa*/
        public String NajboljiStrelac { get; set; } /*Igrac br.Golova;;1 do 3 igraca sa najvise golova*/
        public int FifaRang { get; set; } /*Moze i int da bude*/
        public String NajvecaPobedaPoraz { get; set; } /*Moze i da se odvoji, da ne budu zajedno*/
        // ---- Ostali podaci ----
        public String SportskaBiografija { get; set; } /*Neki opis o reprezentaciji*/
        public String OsvojeneMedalje { get; set; } /*Mozda nam treba reprezentacija sa najvecim brojem medalja???*/
        public String Sastav { get; set; } /*Trenutni sastav*/
        //public Image SlikaZastave { get; set; } /*ILI MOZDA BOLJE SLIKA GRBA*/
        //public Byte[] Himna { get; set; } /*Ne znam koji tip za mp3*/
    }
}
