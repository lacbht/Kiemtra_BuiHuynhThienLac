using Kiemtra_BuiHuynhThienLac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kiemtra_BuiHuynhThienLac.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        MyDataDataContext context = new MyDataDataContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, SinhVien Sv)
        {
            var MaHP = collection["MaHP"];
            var TenHP = collection["TenHP"];
            var SoTinChi = collection["SoTinChi"];

        }
    }
}