using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;
using WebTraSua.MoMo;

namespace WebTraSua.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "WebTraSua");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        // Lay GIo Hang
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

        // Thêm Hàng Vào Giỏ
        [HttpPost]
        public ActionResult ThemGioHang(int ID, int SL, int Gia, string Loai, string Size, string Duong, string Da, string[] ListTP, string reURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = new GioHang(lstGioHang.Count + 1, ID, SL, Gia, Loai, Size, Duong, Da, ListTP);
            lstGioHang.Add(sp);
            return Redirect(reURL);
        }

        [HttpPost]
        public ActionResult TangSoLuong(int STT, string reURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            foreach (var item in lstGioHang)
            {
                if (item.STT == STT)
                {
                    item.SL++; 
                }
            }
            return Redirect(reURL);
        }

        //Giam SO Luong
        [HttpPost]
        public ActionResult GiamSoLuong(int STT, string reURL)
        {
            GioHang itemR = null;
            List<GioHang> lstGioHang = LayGioHang();
            foreach (var item in lstGioHang)
            {
                if (item.STT == STT)
                {
                    item.SL--;
                    if (item.SL < 1)
                    {
                        itemR = item;
                    }
                }
            }
            if (itemR != null ) lstGioHang.Remove(itemR);
            return Redirect(reURL);
        }

        // Xoa Tat Ca

        [HttpPost]
        public ActionResult XoaTatCa(string reURL)
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return Redirect(reURL);
        }
        //
        [HttpGet]
        public ActionResult DatHang(string ten, string sdt, string diachi, string ptship)
        {
            DataSQL db = new DataSQL();
            if (String.IsNullOrEmpty(ten) || String.IsNullOrEmpty(sdt) || String.IsNullOrEmpty(diachi) || String.IsNullOrEmpty(ptship))
            {
                return Json("ERROR", JsonRequestBehavior.AllowGet);
            }

            if (ptship == "cod")
            {
                HoaDon hd = new HoaDon();
                hd.ID_NguoiDung = Int32.Parse(Session["ID"].ToString());
                hd.HoTen = ten;
                hd.SDT = sdt;
                hd.DiaChi = diachi;
                hd.TinhTrang = "chuaxacnhan";
                hd.ThoiGianDat = DateTime.Now;
                hd.maPT = ptship;
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
            }
            else if (ptship == "momo")
            {
                // Thanh Toan MoMo
                string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
                string partnerCode = "MOMOVBN720210707";
                string accessKey = "ou33aqXDAQRT2tJe";
                string serectkey = "lbzm6prdzfQvJnQSb04bmx1c4j7D0Q4t";
                string orderInfo = "Thanh Toán 4 Anh Em";
                string host = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "");
                string returnUrl = host + "/ReturnMoMo";
                string notifyurl = host + "/NotifyMoMo";
                string amount = TongTien().ToString();
                string orderid = Guid.NewGuid().ToString();
                string requestId = Guid.NewGuid().ToString();
                string extraData = "";

                //Before sign HMAC SHA256 signature
                string rawHash = "partnerCode=" +
                    partnerCode + "&accessKey=" +
                    accessKey + "&requestId=" +
                    requestId + "&amount=" +
                    amount + "&orderId=" +
                    orderid + "&orderInfo=" +
                    orderInfo + "&returnUrl=" +
                    returnUrl + "&notifyUrl=" +
                    notifyurl + "&extraData=" +
                    extraData;
                MoMoSecurity crypto = new MoMoSecurity();
                //sign signature SHA256
                string signature = crypto.signSHA256(rawHash, serectkey);

                //build body json request
                JObject message = new JObject{
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }
                };
                // Lưu Gia Trị Vào Session
                Session["tenDatHang"] = ten;
                Session["sdtDatHang"] = sdt;
                Session["diachiDatHang"] = diachi;
                Session["ptshipDatHang"] = ptship;
                string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());
                JObject jmessage = JObject.Parse(responseFromMomo);
                string linkurl = jmessage.GetValue("payUrl").ToString();
                return Json(linkurl, JsonRequestBehavior.AllowGet);
            }
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        // Tinh So Luong

        private long TongSoLuong()
        {
            List<GioHang> lstGioHang = LayGioHang();
            return lstGioHang.Sum(p => p.SL);
        }

        private long TongTien()
        {
            List<GioHang> lstGioHang = LayGioHang();
            return lstGioHang.Sum(p => p.Gia * p.SL);
        }

        public ActionResult LoadGioHang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView(lstGioHang);
        }
    }
}