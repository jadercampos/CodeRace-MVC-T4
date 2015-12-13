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
    public class PerguntaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pergunta
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
                sortOrder = String.IsNullOrEmpty(sortOrder) ? "Pergunta" : "";
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
            var pergunta = from e in db.Pergunta.OrderBy(p => p.Descricao) select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                //  pergunta = pergunta.Where(e => e.Nome.ToUpper().Contains(searchString.ToUpper())
                //                         || e.Descricao.ToUpper().Contains(searchString.ToUpper()));
            }
            //  switch (sortOrder)
            //  {
            // case "Pergunta_desc":
            //     pergunta = pergunta.OrderByDescending(e => e.Nome);
            //     break;
            // case "Descrição":
            //     pergunta = pergunta.OrderBy(e => e.Descricao);
            //      break;
            //  case "Descrição_desc":
            //  pergunta = pergunta.OrderByDescending(e => e.Descricao);
            //  break;
            // default:
            //   pergunta = pergunta.OrderBy(e => e.Nome);
            //    break;
            //}
            int pageNumber = (page ?? 1);
            return View(pergunta.ToPagedList(pageNumber, pageSize));
        }
        // GET: Pergunta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // GET: Pergunta/Create
        public ActionResult Create()
        {
            ViewBag.MateriaId = new SelectList(db.Materia, "MateriaId", "Nome");
            return View();
        }

        // POST: Pergunta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerguntaId,Descricao,MateriaId,Dificuldade")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {

                db.Pergunta.Add(pergunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MateriaId = new SelectList(db.Materia, "MateriaId", "Nome", pergunta.MateriaId);
            return View(pergunta);
        }

        // GET: Pergunta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            ViewBag.MateriaId = new SelectList(db.Materia, "MateriaId", "Nome", pergunta.MateriaId);
            return View(pergunta);
        }

        // POST: Pergunta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerguntaId,Descricao,MateriaId,Dificuldade")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {

                db.Entry(pergunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MateriaId = new SelectList(db.Materia, "MateriaId", "Nome", pergunta.MateriaId);
            return View(pergunta);
        }

        // GET: Pergunta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pergunta pergunta = db.Pergunta.Find(id);
            if (pergunta == null)
            {
                return HttpNotFound();
            }
            return View(pergunta);
        }

        // POST: Pergunta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pergunta pergunta = db.Pergunta.Find(id);
            db.Pergunta.Remove(pergunta);
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
