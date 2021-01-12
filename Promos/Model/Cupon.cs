using System;
using System.Collections.Generic;
using System.Text;

namespace UAS_Pemrograman.Model
{
    public class Cupon
    {
        public string title { get; set; }
        public double diskon { get; set; }

        public double diskonPersen { get; set; }

        public Cupon(string title, double disc = 0, double discInPercent = 0)
        {
            this.title = title;
            this.diskon = disc;
            this.diskonPersen = discInPercent;
        }
    }
}
