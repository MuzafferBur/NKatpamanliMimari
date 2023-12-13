using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }

        public static int LLPersonelEkle(EntityPersonel P)
        {
            if(P.Ad!="" &&  P.Soyad!="" &&  P.Maas>=11500 && P.Ad.Length >= 3)
            {
                return DALPersonel.PersonelEkle(P);
            }
            else
            {
                return -1; 
            }
        }

        public static bool LLPersonelSil(int Per)
        {
            if (Per >0)
            {
                return DALPersonel.PersonelSil(Per);
            }
            else 
            {
                return false; 
            }
        }

        public static bool LLPersonelGuncelle(EntityPersonel Per)
        {
            if (Per.Ad.Length>2 && Per.Soyad.Length >=2 && Per.Meslek!="")
            {
                return DALPersonel.PersonelGuncelle(Per);
            }
            else
            {
                return false;
            }
        }
    }
}
