using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _011_MvcApplication.Models;

namespace _011_MvcApplication.Controllers
{
    public class PessoaController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Pessoa/

        public ActionResult About()
        {
            ViewBag.Mensagem = "Não tem mensagem!";

            return View();
        }
    

        public ActionResult Index()
        {
            return View(db.PessoaSet.ToList());
        }

        //
        // GET: /Pessoa/Details/5

        public ActionResult Details(int id = 0)
        {
            Pessoa pessoa = db.PessoaSet.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        //
        // GET: /Pessoa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pessoa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.PessoaSet.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }

        //
        // GET: /Pessoa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pessoa pessoa = db.PessoaSet.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        //
        // POST: /Pessoa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        //
        // GET: /Pessoa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pessoa pessoa = db.PessoaSet.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        //
        // POST: /Pessoa/Delete/5

        [HttpPost] 
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.PessoaSet.Find(id);
            db.PessoaSet.Remove(pessoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}