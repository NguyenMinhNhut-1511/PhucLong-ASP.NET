using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;

namespace WebTraSua.Controllers
{
    public class OrderController : Controller
    {
        // GET: DatHang
        DataSQL db = new DataSQL();

        public ActionResult Index()
        {
            List<LoaiSanPham> listLoai = db.LoaiSanPhams.OrderBy(p=>p.ID).ToList();
            ViewBag.LoaiSP = listLoai;
            List<Topping> listTP = db.Toppings.ToList();
            string json = "";
            foreach (var item in listTP)
            {
                json += "{\'ID\" : \""+ item.ID + "\', \'tenTP\" : \""+item.tenTP+"\', \'Gia\" : \""+item.Gia+"\', \"Quyen\': \""+item.maTinhTrang+"\'},";
            }
            ViewBag.ListTP = "[" + json.Substring(0, json.Length - 1) + "]";
            List<SanPham> listSP = db.SanPhams.ToList();
            return View(listSP);
        }

        public ActionResult ListLoaiSP()
        {
            List<LoaiSanPham> listLoai = db.LoaiSanPhams.OrderBy(p => p.ID).ToList();
            int[] count = new int[20];
            foreach (var item in listLoai)
            {
                count[item.ID] = db.SanPhams.Where(p => p.maLoai == item.maLoai).Count();
            }
            ViewBag.Count = count;
            return PartialView(listLoai);
        }
    }
}