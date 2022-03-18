using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;

namespace WebTraSua.Controllers
{
    public class ReturnMoMoController : Controller
    {
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        // GET: ReturnMoMo
        public ActionResult Index()
        {
            string url = Request.Url.PathAndQuery;
            //string url = "/ReturnMoMo?partnerCode=MOMOVBN720210707&accessKey=ou33aqXDAQRT2tJe&requestId=df74ab40-8dd9-479c-9275-195537d16223&amount=31500&orderId=ab09618d-ba98-494e-8faf-89c5fcd53074&orderInfo=Thanh%20To%C3%A1n%204%20Anh%20Em&orderType=momo_wallet&transId=2548060601&message=Success&localMessage=Th%C3%A0nh%20c%C3%B4ng&responseTime=2021-07-16%2022:05:49&errorCode=0&payType=qr&extraData=&signature=c07462a651c5f6656d79bb0e38172a1810cefe0f985fe2b39483c0b914e2f761";
            if (!url.Contains("message=Success"))
                return RedirectToAction("Index", "GioHang");

            if (Session["tenDatHang"] == null)
                return RedirectToAction("Index", "GioHang");

            DataSQL db = new DataSQL();

            HoaDon hd = new HoaDon();
            hd.ID_NguoiDung = Int32.Parse(Session["ID"].ToString());
            hd.HoTen = Session["tenDatHang"].ToString();
            hd.SDT = Session["sdtDatHang"].ToString();
            hd.DiaChi = Session["diachiDatHang"].ToString();
            hd.TinhTrang = "chuaxacnhan";
            hd.ThoiGianDat = DateTime.Now;
            hd.maPT = Session["ptshipDatHang"].ToString();
            db.HoaDons.Add(hd);
            db.SaveChanges();
            List<GioHang> giohang = LayGioHang();
            foreach (var item in giohang)
            {
                CTHoaDon cthd = new CTHoaDon();
                cthd.ID_HoaDon = hd.ID;
                cthd.ID_SanPham = item.ID;
                cthd.SoLuong = (int)item.SL;
                cthd.Gia = item.Gia;
                cthd.ChonLoai = item.Loai;
                cthd.ChonDuong = item.Duong;
                cthd.ChonSize = item.Size;
                cthd.ChonDa = item.Da;
                cthd.ChonTopping = Newtonsoft.Json.JsonConvert.SerializeObject(item.ListTP);
                db.CTHoaDons.Add(cthd);
            }
            db.SaveChanges();
            giohang.Clear();

            Session.Remove("tenDatHang");
            Session.Remove("sdtDatHang");
            Session.Remove("diachiDatHang");
            Session.Remove("ptshipDatHang");

            return RedirectToAction("NotifForm", "Accounts", new { title = "Thanh Toán Thành Công", msg = "Bạn đã thanh công thành công. Đơn hàng của bạn sẽ được ship đến sớm thôi!" });
        }
    }
}