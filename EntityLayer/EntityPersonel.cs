using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityPersonel
    {
        private int id;
        private string ad;
        private string soyad;
        private string sehir;
        private string meslek;
        private short maas;

        //bu yapi kapsulleme olarak adlandiriliyor
        public int Id { get => id; set => id = value; }//ve bunlarin her bir satirina property denir
        public string Ad { get => ad; set => ad = value; }//get oku set deger ata
        public string Soyad { get => soyad; set => soyad = value; }
        public string Sehir { get => sehir; set => sehir = value; }
        public string Meslek { get => meslek; set => meslek = value; }
        public short Maas { get => maas; set => maas = value; }
    }
}
