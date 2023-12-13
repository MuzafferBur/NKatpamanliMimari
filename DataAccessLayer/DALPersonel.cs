using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand kmt = new SqlCommand("Select * From Tbl_Personel", Baglanti.bgl);
            if (kmt.Connection.State != ConnectionState.Open)
            {
                kmt.Connection.Open();
            }
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Sehir = dr["SEHiR"].ToString();
                ent.Meslek = dr["MESLEK"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static int PersonelEkle(EntityPersonel P)
        {    
            SqlCommand kmt2 = new SqlCommand("insert into Tbl_Personel (AD,SOYAD,MESLEK,SEHiR,MAAS) VALUES (@P1,@P2,@P3,@P4,@P5)",Baglanti.bgl);

            if (kmt2.Connection.State != ConnectionState.Open)
            { 
                kmt2.Connection.Open();
            }

            kmt2.Parameters.AddWithValue("@p1", P.Ad);
            kmt2.Parameters.AddWithValue("@p2", P.Soyad);
            kmt2.Parameters.AddWithValue("@p3", P.Meslek);
            kmt2.Parameters.AddWithValue("@p4", P.Sehir);
            kmt2.Parameters.AddWithValue("@p5", P.Maas);
            return kmt2.ExecuteNonQuery();
        }

        public static bool PersonelSil(int P)
        {
            SqlCommand kmt3 = new SqlCommand("Delete From Tbl_Personel Where ID= @p1", Baglanti.bgl);
            
            if (kmt3.Connection.State != ConnectionState.Open)
            {
                kmt3.Connection.Open();
            }
            kmt3.Parameters.AddWithValue("@p1", P);
            return kmt3.ExecuteNonQuery() > 0;
        }

        public static bool PersonelGuncelle(EntityPersonel p)
        {
            SqlCommand kmt4 = new SqlCommand("Update Tbl_Personel Set Ad=@p1,Soyad=@p2,Sehir=@p3,Meslek=@p4,Maas=@p5 Where ID=@p6", Baglanti.bgl);
            
            if(kmt4.Connection.State != ConnectionState.Open)
            {
                kmt4.Connection.Open(); 
            }

            kmt4.Parameters.AddWithValue("@p1", p.Ad);
            kmt4.Parameters.AddWithValue("@p2", p.Soyad);
            kmt4.Parameters.AddWithValue("@p3", p.Sehir);
            kmt4.Parameters.AddWithValue("@p4", p.Meslek);
            kmt4.Parameters.AddWithValue("@p5", p.Maas);
            kmt4.Parameters.AddWithValue("@p6", p.Id);
            return kmt4.ExecuteNonQuery() > 0;
        }
    }
}
