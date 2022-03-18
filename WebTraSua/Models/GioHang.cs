using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace WebTraSua.Models
{
    public class GioHang
    {
        DataSQL db = new DataSQL();

        public int STT { get; set; }

        public int ID { get; set;}
        public string TenSP { get; set; }
        public string Anh { get; set; }
        public long Gia { get; set; }
        public string Loai { get; set; }
        public string Size { get; set; }
        public string Duong { get; set; }
        public string Da { get; set; }
        public string[] ListTP { get; set; }
        public long SL { get; set; }

        public string[] _GetNameTP()
        {
            
            if (this.ListTP != null)
            {
                string[] haha = new string[this.ListTP.Count()];
                for (int j = 0; j < this.ListTP.Count(); j++)
                {
                    int id_tp = 0;
                    Int32.TryParse(this.ListTP[j], out id_tp);
                    if (ID != 0)
                    {
                        haha[j] = db.Toppings.FirstOrDefault(p => p.ID == id_tp).tenTP;
                    }
                }
                return haha;
            }
            return null;
        }

        public GioHang(int STT,int ID, int SL, int Gia, string Loai, string Size, string Duong, string Da, string[] ListTP)
        {
            this.STT = STT;
            this.ID = ID;
            SanPham sp = db.SanPhams.FirstOrDefault(p => p.ID == ID);
            this.TenSP = sp.tenSP;
            this.Anh = sp.Anh;
            this.SL = SL;
            this.Gia = (long)Gia;
            this.Loai = Loai;
            this.Size = Size;
            this.Duong = Duong;
            this.Da = Da;
            this.ListTP = ListTP;
        }


        public virtual ICollection<GioHang> GioHangs { get; set; }
    }
}