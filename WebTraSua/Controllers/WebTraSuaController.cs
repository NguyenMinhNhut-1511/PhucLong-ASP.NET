using Imgur.API.Authentication;
using Imgur.API.Endpoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;

namespace WebTraSua.Controllers
{
    
    public class WebTraSuaController : Controller
    {
        // GET: WebTraSua
        DataSQL db = new DataSQL();

        public ActionResult Index()
        {
            List<SanPham> SPs = db.SanPhams.Take(6).ToList();
            return View(SPs);
        }
    }
}