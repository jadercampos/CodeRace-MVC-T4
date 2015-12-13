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
    public class NivelUsuarioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NivelUsuario
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
                sortOrder = String.IsNullOrEmpty(sortOrder) ? "NivelUsuario" : "";
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
            var nivelUsuario = from e in db.NivelUsuario.OrderBy(n => n.Nome) select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                //  nivelUsuario = nivelUsuario.Where(e => e.Nome.ToUpper().Contains(searchString.ToUpper())
                //                         || e.Descricao.ToUpper().Contains(searchString.ToUpper()));
            }
            //  switch (sortOrder)
            //  {
            // case "NivelUsuario_desc":
            //     nivelUsuario = nivelUsuario.OrderByDescending(e => e.Nome);
            //     break;
            // case "Descrição":
            //     nivelUsuario = nivelUsuario.OrderBy(e => e.Descricao);
            //      break;
            //  case "Descrição_desc":
            //  nivelUsuario = nivelUsuario.OrderByDescending(e => e.Descricao);
            //  break;
            // default:
            //   nivelUsuario = nivelUsuario.OrderBy(e => e.Nome);
            //    break;
            //}
            int pageNumber = (page ?? 1);
            return View(nivelUsuario.ToPagedList(pageNumber, pageSize));
        }
        // GET: NivelUsuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelUsuario nivelUsuario = db.NivelUsuario.Find(id);
            if (nivelUsuario == null)
            {
                return HttpNotFound();
            }
            return View(nivelUsuario);
        }

        // GET: NivelUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelUsuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NivelUsuarioId,Nome,PontuacaoInicial,PontuacaoFinal,Peso")] NivelUsuario nivelUsuario)
        {
            if (ModelState.IsValid)
            {

                db.NivelUsuario.Add(nivelUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nivelUsuario);
        }

        // GET: NivelUsuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelUsuario nivelUsuario = db.NivelUsuario.Find(id);
            if (nivelUsuario == null)
            {
                return HttpNotFound();
            }
            return View(nivelUsuario);
        }

        // POST: NivelUsuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NivelUsuarioId,Nome,PontuacaoInicial,PontuacaoFinal,Peso")] NivelUsuario nivelUsuario)
        {
            if (ModelState.IsValid)
            {

                db.Entry(nivelUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelUsuario);
        }

        // GET: NivelUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NivelUsuario nivelUsuario = db.NivelUsuario.Find(id);
            if (nivelUsuario == null)
            {
                return HttpNotFound();
            }
            return View(nivelUsuario);
        }

        // POST: NivelUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NivelUsuario nivelUsuario = db.NivelUsuario.Find(id);
            db.NivelUsuario.Remove(nivelUsuario);
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
