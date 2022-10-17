using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using prjFinal.Models;
using PagedList;
using PagedList.Mvc;

namespace prjFinal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        dbmovieEntities db = new dbmovieEntities();

        // GET: Home
        [Authorize(Users = "Hsiao")]
        public ActionResult Index(int category = 1)
        {
            if (category == 1)
            {
                ViewBag.catname = db.Tabletcategory1091750
                    .FirstOrDefault().fcategoryName + "";
            }
            else
            {
                ViewBag.catname = db.Tabletcategory1091750
                .Where(m => m.fcategoryId == category)
                .FirstOrDefault().fcategoryName + "";
            }

            CVMcatemovie vm = new CVMcatemovie()
            {
                tabletcategories = db.Tabletcategory1091750.ToList(),
                tabletmovies = db.Tabletmovie1091750
               .Where(m => m.fcategoryId == category).OrderBy(m => m.fmovieId).ToList()
            };
            
            if (category == 1)
            {
                vm = new CVMcatemovie()
                {
                    tabletcategories = db.Tabletcategory1091750.ToList(),
                    tabletmovies = db.Tabletmovie1091750.OrderBy(m => m.fmovieId).ToList()
                };
            }
           return View(vm);
        }

        [Authorize(Users = "Hsiao")]
        public ActionResult Create()
        {
            return View(db.Tabletcategory1091750.ToList());
        }

        [HttpPost]
        public ActionResult Create(Tabletmovie1091750 movie)
        {
            try
            {
                db.Tabletmovie1091750.Add(movie);
                db.SaveChanges();
                return RedirectToAction
                    ("Index", new { category = 1 });
            }
            catch (Exception ex)
            { }
            return View(movie);
        }

        public ActionResult Delete(string fmovieId)
        {
            var movie = db.Tabletmovie1091750
                .Where(m => m.fmovieId == fmovieId)
                .FirstOrDefault();

            db.Tabletmovie1091750.Remove(movie);
            db.SaveChanges();
            return RedirectToAction
                ("Index");
        }

        public ActionResult Edit(string Count)
        {
            var e = db.Tabletmovie1091750
                .Where(m => m.fmovieId == Count).FirstOrDefault();
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Tabletmovie1091750 num)
        {
            if (ModelState.IsValid)
            {
                var temp = db.Tabletmovie1091750
                    .Where(m => m.fmovieId == num.fmovieId)
                    .FirstOrDefault();
                temp.fmovieId = num.fmovieId;
                temp.fmovieName = num.fmovieName;
                temp.fdate = num.fdate;
                temp.flevel = num.flevel;
                temp.fevaluation = num.fevaluation;
                temp.fcategoryId = num.fcategoryId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(num);
        }

        allmovieEntities allmovie = new allmovieEntities();
        int pagesize = 10;

        [Authorize(Users = "Hsiao")]
        public ActionResult all(int page = 1)
        {
            int currentpage = page < 1 ? 1 : page;
            var movie = allmovie.Tabletmovieall1091750
                .OrderBy(m => m.tmovieId).ToList();
            var result = movie.ToPagedList(currentpage, pagesize);
            return View(result);
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();//登出
            return RedirectToAction("Login");
        }

        [Authorize(Users = "Hsiao")]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(search id)
        {
            ViewBag.SearchNum = id;
            return RedirectToAction("SearchResult", new { SearchNum = id.s });
        }

        public ActionResult SearchResult(string SearchNum)
        {
            ViewData["SearchNum"] = SearchNum;
            var result = (from m in db.Tabletmovie1091750
                          where m.fmovieId == SearchNum
                          select m).ToList();
            return View(result);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string txtUid, string txtPwd)
        {
            string[] uidAry = new string[] { "Hsiao" };
            string[] pwdAry = new string[] { "1234" };

            //循序搜尋法
            int index = -1;
            for (int i = 0; i < uidAry.Length; i++)
            {
                if (uidAry[i] == txtUid && pwdAry[i] == txtPwd)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                ViewBag.Err = "帳密錯誤";
            }
            else
            {
                //表單驗證服務，授權指定的帳號
                FormsAuthentication.RedirectFromLoginPage(txtUid, true);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}