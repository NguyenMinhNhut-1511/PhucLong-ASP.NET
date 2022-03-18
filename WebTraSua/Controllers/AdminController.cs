using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;
using WebTraSua.Controllers;
using Newtonsoft.Json;

namespace WebTraSua.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataSQL db = new DataSQL();

        public ActionResult Index()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<HoaDon> listHD = db.HoaDons.ToList();
            long DoanhThuNgay = 0;
            long DoanhThuThang = 0;
            long TongTien = 0;
            foreach (var item in listHD)
            {
                if (item.TinhTrang == "dagiao" && item.ThoiGianDat.GetValueOrDefault().Year == DateTime.Now.Year)
                {
                    if (item.ThoiGianDat.GetValueOrDefault().Day == DateTime.Now.Day)
                    {
                        DoanhThuNgay += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                    }
                    if (item.ThoiGianDat.GetValueOrDefault().Month == DateTime.Now.Month)
                    {
                        DoanhThuThang += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                    }
                    TongTien += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                }
            }
            ViewBag.DoanhThuNgay = DoanhThuNgay;
            ViewBag.DoanhThuThang = DoanhThuThang;
            ViewBag.TongTien = TongTien;
            ViewBag.TongDonHang = db.HoaDons.Count();
            return View();
        }

        [HttpPost]
        public ActionResult GetDoanhThuTheoThang()
        {
            long Thang1 = 0; long Thang2 = 0; long Thang3= 0; long Thang4 = 0; long Thang5 = 0; long Thang6 = 0;
            long Thang7 = 0; long Thang8 = 0; long Thang9 = 0; long Thang10 = 0; long Thang11 = 0; long Thang12 = 0;
            List<HoaDon> listHD = db.HoaDons.ToList();
            foreach (var item in listHD)
            {
                if (item.ThoiGianDat.GetValueOrDefault().Year == DateTime.Now.Year)
                {
                    if (item.TinhTrang == "dagiao")
                    {
                        switch (item.ThoiGianDat.GetValueOrDefault().Month)
                        {
                            case 1:
                                Thang1 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 2:
                                Thang2 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 3:
                                Thang3 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 4:
                                Thang4 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 5:
                                Thang5 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 6:
                                Thang6 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 7:
                                Thang7 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 8:
                                Thang8 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 9:
                                Thang9 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 10:
                                Thang10 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 11:
                                Thang11 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            case 12:
                                Thang12 += (long)db.CTHoaDons.Where(p => p.ID_HoaDon == item.ID).Sum(i => i.Gia * i.SoLuong);
                                break;
                            default:
                                break;
                        }
                    }
                }
                
            }
            return Json(new { Thang1, Thang2, Thang3, Thang4, Thang5, Thang6, Thang7, Thang8, Thang9, Thang10, Thang11, Thang12 });
        }

        [HttpPost]
        public ActionResult GetPTShip()
        {
            long ShipCOD = 0;
            float cod = 0;
            long MoMo = 0;
            float momo = 0;
            List<HoaDon> listHD = db.HoaDons.ToList();
            foreach (var item in listHD)
            {
                if (item.maPT == "cod")
                {
                    ShipCOD++;
                }
                else if (item.maPT == "momo")
                {
                    MoMo++;
                }

            }
            long tong = (ShipCOD + MoMo) == 0 ? 1 : (ShipCOD + MoMo);
            cod = (ShipCOD * 100) / tong;
            momo = (MoMo * 100) / tong;
            return Json(new { cod, momo });
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string tk = form["TaiKhoan"];
            string mk = form["MatKhau"];
            if (String.IsNullOrEmpty(tk))
            {
                ViewBag.ThongBao = "! Tài Khoản Không Được Để Trống";
            }
            else if (String.IsNullOrEmpty(mk))
            {
                ViewBag.ThongBao = "! Mật Khẩu Không Được Để Trống";
            }
            else if (mk.Length > 18)
            {
                ViewBag.ThongBao = "! Mật Khẩu Không Được Quá 18 Ký Tự";
            }
            else
            {
                string md5Pass = AccountsController.MD5Hash(mk);
                Administrator nv = db.Administrators.FirstOrDefault(p => p.TaiKhoan == tk && p.MatKhau == md5Pass);
                if (nv != null)
                {
                    Session["IDAdmin"] = nv.ID;
                    Session["TaiKhoanAdmin"] = nv.TaiKhoan;
                    Session["NameAdmin"] = nv.HoTen;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.ThongBao = "! Tài Khoản Và Mật Khẩu Không Hợp Lệ!";
                }
            }
            return RedirectToAction("Login", "Accounts", new { thongbao = ViewBag.ThongBao });
        }

        [HttpPost]
        public ActionResult ChangePassAdmin(string passOld, string passNew, string passNew2)
        {
            if (Session["TaiKhoanAdmin"] == null) return Json("ERROR");
            if (String.IsNullOrEmpty(passOld) || String.IsNullOrEmpty(passOld) || String.IsNullOrEmpty(passOld))
            {
                return Json("ERROR");
            }
            if (passNew != passNew2) return Json("ERROR");
            string tk = Session["TaiKhoanAdmin"].ToString();
            string passMD5 = AccountsController.MD5Hash(passOld);
            Administrator ad = db.Administrators.FirstOrDefault(p => p.TaiKhoan == tk && p.MatKhau == passMD5);
            if (ad == null) return Json("ERROR");
            ad.MatKhau = AccountsController.MD5Hash(passNew);
            db.SaveChanges();
            return Json("OK");
        }

        [HttpGet]
        public ActionResult SanPham()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<SanPham> list = db.SanPhams.Where(p=> p.maTinhTrang == "active").ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult BlockSP(int id)
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            SanPham sp = db.SanPhams.Find(id);
            sp.maTinhTrang = "block";
            db.SaveChanges();
            return Json("OK");
        }

        [HttpPost]
        public ActionResult GetSP(int id)
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            SanPham sp = db.SanPhams.Find(id);
            List<LoaiSanPham> listLoai = db.LoaiSanPhams.OrderBy(p=> p.ID).ToList();
            List<string[]> listLoaiStr = new List<string[]>();
            foreach (var item in listLoai)
            {
                listLoaiStr.Add(new string[] { item.ID.ToString(), item.maLoai, item.tenLoai });
            }
            List<Topping> listTP = db.Toppings.OrderBy(p => p.ID).ToList();
            List<string[]> listTPStr = new List<string[]>();
            foreach (var item in listTP)
            {
                listTPStr.Add(new string[] { item.ID.ToString(), item.tenTP, item.Gia.ToString() });
            }
            string[] array = { sp.ID.ToString(), sp.tenSP, sp.Gia.ToString(), sp.GiamGia.ToString(), sp.maLoai, sp.Anh, sp.Mota, sp.ChonLoai, sp.ChonSize, sp.ChonDuong, sp.ChonDa, Newtonsoft.Json.JsonConvert.SerializeObject(listLoaiStr), Newtonsoft.Json.JsonConvert.SerializeObject(listTPStr), Newtonsoft.Json.JsonConvert.SerializeObject(sp.ChonTopping) };
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(array));
        }

        [HttpPost]
        public ActionResult GetLoaiVsTP()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<LoaiSanPham> listLoai = db.LoaiSanPhams.OrderBy(p => p.ID).ToList();
            List<string[]> listLoaiStr = new List<string[]>();
            foreach (var item in listLoai)
            {
                listLoaiStr.Add(new string[] { item.ID.ToString(), item.maLoai, item.tenLoai });
            }
            List<Topping> listTP = db.Toppings.OrderBy(p => p.ID).ToList();
            List<string[]> listTPStr = new List<string[]>();
            foreach (var item in listTP)
            {
                listTPStr.Add(new string[] { item.ID.ToString(), item.tenTP, item.Gia.ToString() });
            }
            string[] array = {Newtonsoft.Json.JsonConvert.SerializeObject(listLoaiStr), Newtonsoft.Json.JsonConvert.SerializeObject(listTPStr)};
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(array));
        }

        [HttpPost]
        public ActionResult UpdateSP(string ID, string tenSP, string Gia, string Mota, string Anh, string ChonLoai, string ChonSize, string ChonDuong, string ChonDa, string ChonTopping, string GiamGia, string maLoai)
        {
            if (Session["TaiKhoanAdmin"] == null) return Json("ERROR");
            if (String.IsNullOrEmpty(ID) || String.IsNullOrEmpty(tenSP) || String.IsNullOrEmpty(Gia) || String.IsNullOrEmpty(Anh) || String.IsNullOrEmpty(ChonLoai) || String.IsNullOrEmpty(ChonSize) || String.IsNullOrEmpty(ChonDuong) || String.IsNullOrEmpty(ChonDa) || String.IsNullOrEmpty(ChonTopping) || String.IsNullOrEmpty(GiamGia) || String.IsNullOrEmpty(maLoai))
            {
                return Json("ERROR");
            }
            int GiaTien;
            bool check = Int32.TryParse(Gia, out GiaTien);
            if (!check)
            {
                return Json("ERROR");
            }
            int giamgia;
            check = Int32.TryParse(GiamGia, out giamgia);
            if (!check)
            {
                return Json("ERROR");
            }
            if (giamgia < 0 || giamgia > 100)
            {
                return Json("ERROR");
            }
            int id = Int32.Parse(ID);
            SanPham sp = db.SanPhams.FirstOrDefault(p => p.ID == id);
            sp.tenSP = tenSP;
            sp.Gia = GiaTien;
            sp.Mota = Mota;
            sp.Anh = Anh;
            sp.ChonLoai = ChonLoai;
            sp.ChonSize = ChonSize;
            sp.ChonDuong = ChonDuong;
            sp.ChonDa = ChonDa;
            sp.ChonTopping = ChonTopping;
            sp.GiamGia = giamgia;
            sp.maLoai = maLoai;
            db.SaveChanges();
            return Json("OK");
        }

        [HttpPost]
        public ActionResult CreateSP(string tenSP, string Gia, string Mota, string Anh, string ChonLoai, string ChonSize, string ChonDuong, string ChonDa, string ChonTopping, string GiamGia, string maLoai)
        {
            if (Session["TaiKhoanAdmin"] == null) return Json("ERROR");
            if (String.IsNullOrEmpty(tenSP) || String.IsNullOrEmpty(Gia) || String.IsNullOrEmpty(Anh) || String.IsNullOrEmpty(ChonLoai) || String.IsNullOrEmpty(ChonSize) || String.IsNullOrEmpty(ChonDuong) || String.IsNullOrEmpty(ChonDa) || String.IsNullOrEmpty(ChonTopping) || String.IsNullOrEmpty(GiamGia) || String.IsNullOrEmpty(maLoai))
            {
                return Json("ERROR");
            }
            int GiaTien;
            bool check = Int32.TryParse(Gia, out GiaTien);
            if (!check)
            {
                return Json("ERROR");
            }
            int giamgia;
            check = Int32.TryParse(GiamGia, out giamgia);
            if (!check)
            {
                return Json("ERROR");
            }
            if (giamgia < 0 || giamgia > 100)
            {
                return Json("ERROR");
            }
            SanPham sp = new SanPham();
            sp.tenSP = tenSP;
            sp.Gia = GiaTien;
            sp.Mota = Mota;
            sp.Anh = Anh;
            sp.ChonLoai = ChonLoai;
            sp.ChonSize = ChonSize;
            sp.ChonDuong = ChonDuong;
            sp.ChonDa = ChonDa;
            sp.ChonTopping = ChonTopping;
            sp.GiamGia = giamgia;
            sp.maLoai = maLoai;
            sp.maTinhTrang = "active";
            db.SanPhams.Add(sp);
            db.SaveChanges();
            return Json("OK");
        }

        [HttpGet]
        public ActionResult Topping()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<Topping> list = db.Toppings.Where(p=> p.maTinhTrang == "active").ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult BlockTP(int id)
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            Topping tp = db.Toppings.Find(id);
            tp.maTinhTrang = "block";
            db.SaveChanges();
            return Json("OK");
        }

        [HttpPost]
        public ActionResult UpdateTP(string id, string name, string gia)
        {
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(gia))
                return Json("ERROR");
            int giatien;
            bool a = Int32.TryParse(gia, out giatien);
            if (!a) return Json("ERROR");
            int ID = Int32.Parse(id);
            Topping tp = db.Toppings.Find(ID);
            tp.tenTP = name;
            tp.Gia = giatien;
            db.SaveChanges();
            return Json("OK");
        }

        [HttpPost]
        public ActionResult CreateTP(string name, string gia)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(gia))
                return Json("ERROR");
            int giatien;
            bool a = Int32.TryParse(gia, out giatien);
            if (!a) return Json("ERROR");
            Topping tp = new Topping();
            tp.tenTP = name;
            tp.Gia = giatien;
            tp.maTinhTrang = "active";
            db.Toppings.Add(tp);
            db.SaveChanges();
            return Json("OK");
        }

        [HttpGet]
        public ActionResult LoaiSanPham()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<LoaiSanPham> list = db.LoaiSanPhams.ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult UpdateLoai(string maLoai, string name)
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            if (String.IsNullOrEmpty(maLoai) || String.IsNullOrEmpty(name))
                return Json("ERROR");
            LoaiSanPham loai = db.LoaiSanPhams.Find(maLoai);
            loai.tenLoai = name;
            db.SaveChanges();
            return Json("OK");
        }

        [HttpPost]
        public ActionResult CreateLoai(string maLoai, string name)
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            if (String.IsNullOrEmpty(maLoai) || String.IsNullOrEmpty(name))
                return Json("ERROR");

            if (maLoai.Length > 10 || name.Length > 30)
                return Json("ERROR");

            LoaiSanPham loai = db.LoaiSanPhams.FirstOrDefault(p => p.maLoai == maLoai);
            if (loai != null) return Json("ERROR");

            LoaiSanPham newLoai = new LoaiSanPham();
            newLoai.maLoai = maLoai;
            newLoai.tenLoai = name;
            db.LoaiSanPhams.Add(newLoai);

            db.SaveChanges();
            return Json("OK");
        }

        [HttpGet]
        public ActionResult CTHoaDon(int ?id)
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            if (id == null) return RedirectToAction("Index", "Admin");
            List<CTHoaDon> list = db.CTHoaDons.Where(p => p.ID_HoaDon == id).ToList();
            ViewBag.IDHoaDon = id;
            return View(list);
        }

        [HttpGet]
        public ActionResult DonHangChuaXacNhan()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<HoaDon> listHD = db.HoaDons.Where(p => p.TinhTrang == "chuaxacnhan").ToList();
            return View(listHD);
        }

        [HttpPost]
        public ActionResult SetTinhTrangHoaDon(string id, string trangthai)
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            int ID = Int32.Parse(id);
            HoaDon hd = db.HoaDons.Find(ID);
            if (hd != null)
            {
                if (hd.TinhTrang == "danggiao") hd.ThoiGianNhan = DateTime.Now;
                hd.TinhTrang = trangthai;
                db.SaveChanges();
                return Json("OK");
            }
            return Json("ERROR");
        }

        [HttpGet]
        public ActionResult DonHangDaXacNhan()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<HoaDon> listHD = db.HoaDons.Where(p => p.TinhTrang == "xacnhan").ToList();
            return View(listHD);
        }

        [HttpGet]
        public ActionResult GiaoHang()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<HoaDon> listHDD = db.HoaDons.Where(p => p.TinhTrang == "danggiao").ToList();
            return View(listHDD);
        }

        [HttpGet]
        public ActionResult LichSuHoaDon()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<HoaDon> listHDD = db.HoaDons.Where(p => p.TinhTrang == "dagiao").ToList();
            return View(listHDD);
        }

        [HttpGet]
        public ActionResult QuanLyNguoiDung()
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            List<NguoiDung> QlNguoiDung = db.NguoiDungs.ToList();
            return View(QlNguoiDung);
        }

        [HttpPost]
        public ActionResult GetTenTP(string id, string className)
        {
            if (Session["TaiKhoanAdmin"] == null) return RedirectToAction("Login", "Admin");
            int ID = Int32.Parse(id);
            return Json(new { db.Toppings.FirstOrDefault(p => p.ID == ID).tenTP, className});
        }

        [HttpPost]
        public ActionResult SetTinhTrang(string id , string tt)
        {
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(tt))
            {
                return Json("ERROR");
            }
            int ID;
            bool a = Int32.TryParse(id, out ID);
            if (a == false) return Json("ERROR");
            NguoiDung nd = db.NguoiDungs.Find(ID);
            if (nd == null) return Json("ERROR");
            nd.maTinhTrang = tt;
            db.SaveChanges();
            return Json("OK");
        }
    }
}