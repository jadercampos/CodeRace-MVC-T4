using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using EducacaoConhecimento.Models;

namespace EducacaoConhecimento.Controllers
{
    public class MateriaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Materia
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, int? pages)
        {
            int pageSize = 3;
            if (pages.HasValue)
            {
                pageSize = pages.Value;
            }
            ViewBag.pages = pageSize;
            ViewBag.CurrentSort = sortOrder;
            if (sortOrder == null)
            {
                sortOrder = String.IsNullOrEmpty(sortOrder) ? "Materia" : "";
            }
            else
            {
                if (sortOrder.Contains("_desc"))
                {
                    sortOrder = sortOrder.Replace("_desc", "");
                }
                else
                {
                    sortOrder = sortOrder + "_desc";
                }
            }
            ViewBag.NameSortParm = sortOrder;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var materia = from e in db.Materia.OrderBy(m => m.Nome) select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                //  materia = materia.Where(e => e.Nome.ToUpper().Contains(searchString.ToUpper())
                //                         || e.Descricao.ToUpper().Contains(searchString.ToUpper()));
            }
            //  switch (sortOrder)
            //  {
            // case "Materia_desc":
            //     materia = materia.OrderByDescending(e => e.Nome);
            //     break;
            // case "Descrição":
            //     materia = materia.OrderBy(e => e.Descricao);
            //      break;
            //  case "Descrição_desc":
            //  materia = materia.OrderByDescending(e => e.Descricao);
            //  break;
            // default:
            //   materia = materia.OrderBy(e => e.Nome);
            //    break;
            //}
            int pageNumber = (page ?? 1);
            return View(materia.ToPagedList(pageNumber, pageSize));
            
        }
        // GET: Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = db.Materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MateriaId,Nome")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Materia.Add(materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materia);
        }

        // GET: Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = db.Materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: Materia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MateriaId,Nome")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia);
        }

        // GET: Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = db.Materia.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materia materia = db.Materia.Find(id);
            db.Materia.Remove(materia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
