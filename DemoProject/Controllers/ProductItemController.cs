using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class ProductItemController : Controller
    {
        // GET: ProductItem
        public ActionResult ProductAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(ItemMst items) {
            List<ItemMst> itemList = new List<ItemMst>();

            if (ModelState.IsValid) {

                if (Request.Files.Count > 0) {
                    var files = Request.Files[0];
                    if (files != null && files.ContentLength > 0) {
                        var fileName = Path.GetFileName(files.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                        var savedPath = "/UploadedFiles/" + fileName;
                        files.SaveAs(path);
                        items.ImagePath = savedPath;
                    }

                }

                var db = new ShoppingEntities();
                db.ItemMsts.Add(items);
                db.SaveChanges();
                itemList = db.ItemMsts.ToList();
            }

            return View(itemList);

        }

        public ActionResult AddItem() {
            return View();
        }

        [HttpGet]
        public ActionResult RemoveItem(int uID) {

            List<ItemMst> itemList = new List<ItemMst>();
            var db = new ShoppingEntities();
            var obj = db.ItemMsts.Where(a => a.IID.ToString().Equals(uID.ToString())).FirstOrDefault();
            if (obj != null) {
                db.ItemMsts.Remove(obj);
                db.SaveChanges();
            }

            itemList = db.ItemMsts.ToList();

            return View("AddItem",itemList);
        }


        [HttpGet]
        public ActionResult EditItem(int uID) {
            ShoppingEntities entity = new ShoppingEntities();
            var obj = entity.ItemMsts.Where(a => a.IID.ToString().Equals(uID.ToString())).FirstOrDefault();

            if (obj!=null){
                return View(obj);
            }
            return View();
        }

        [HttpPost]
        public ActionResult SaveItems(ItemMst data) {
            List<ItemMst> listingITems = new List<ItemMst>();
            ShoppingEntities entity = new ShoppingEntities();
          var obj=  entity.ItemMsts.Where(a => a.IID.ToString().Equals(data.IID.ToString())).FirstOrDefault();
            if (obj != null) {
                obj.IName = data.IName;
                obj.ImagePath = data.ImagePath;
                obj.Price = data.Price;
                obj.Qnt = data.Qnt;
                obj.Size = data.Size;
                obj.Detail = data.Detail;
                obj.EntryDate = data.EntryDate;
                obj.CName = data.CName;
                entity.SaveChanges();


            }

            listingITems = entity.ItemMsts.ToList();

            return View("AddItem",listingITems);
        }


       

       
    }
}