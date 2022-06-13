using Kiemtra_BuiHuynhThienLac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kiemtra_BuiHuynhThienLac.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        Model1 context = new Model1();
        public ActionResult Index()
        {
            var all_sv = from tt in context.SinhViens select tt;
            return View(all_sv);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            SinhVien masv = new SinhVien();
            masv.MaSV = collection["MaSv"];
            masv.HoTen = collection["HoTen"];
            masv.GioiTinh = collection["GioiTinh"];
            masv.NgaySinh = DateTime.Parse(collection["NgaySinh"]);
            masv.Hinh = collection["Hinh"];
            masv.MaNganh = collection["MaNganh"];
            context.SinhViens.Add(masv);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(string id)
        {
            SinhVien D_sv = context.SinhViens.FirstOrDefault(p => p.MaSV == id);
            return View(D_sv);
        }

      
       
        public ActionResult Delete(string id)
        {
            var D_sach = context.SinhViens.First(m => m.MaSV == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sach = context.SinhViens.Where(m => m.MaSV == id).First();
            context.SinhViens.Remove(D_sach);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            var E_sv = context.SinhViens.First(m => m.MaSV == id);
            return View(E_sv);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_sv = context.SinhViens.First(m => m.MaSV == id);
            var E_tensv = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_man = collection["MaNganh"];
            E_sv.MaSV = id;
            if (string.IsNullOrEmpty(E_tensv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_sv.HoTen = E_tensv;
                E_sv.GioiTinh = E_gioitinh;
                E_sv.NgaySinh = E_ngaysinh;
                E_sv.Hinh = E_hinh;
                E_sv.MaNganh = E_man;
                UpdateModel(E_sv);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }


    }
}