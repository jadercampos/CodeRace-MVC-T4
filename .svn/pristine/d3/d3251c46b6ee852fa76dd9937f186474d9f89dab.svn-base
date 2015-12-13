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
    public class RespostaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resposta
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
                sortOrder = String.IsNullOrEmpty(sortOrder) ? "Resposta" : "";
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
            var resposta = from e in db.Resposta.OrderBy(r => r.Pergunta.Descricao).ThenBy(r => r.Descricao) select e;
            if (!String.IsNullOrEmpty(searchString))
            {
              //  resposta = resposta.Where(e => e.Nome.ToUpper().Contains(searchString.ToUpper())
              //                         || e.Descricao.ToUpper().Contains(searchString.ToUpper()));
            }
          //  switch (sortOrder)
          //  {
               // case "Resposta_desc":
               //     resposta = resposta.OrderByDescending(e => e.Nome);
               //     break;
               // case "Descrição":
               //     resposta = resposta.OrderBy(e => e.Descricao);
              //      break;
              //  case "Descrição_desc":
                  //  resposta = resposta.OrderByDescending(e => e.Descricao);
                  //  break;
               // default:
                 //   resposta = resposta.OrderBy(e => e.Nome);
                //    break;
            //}
            int pageNumber = (page ?? 1);
            return View(resposta.ToPagedList(pageNumber, pageSize));
			}
        // GET: Resposta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Resposta.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // GET: Resposta/Create
        public ActionResult Create()
        {
            ViewBag.PerguntaId = new SelectList(db.Pergunta, "PerguntaId", "Descricao");
            return View();
        }

        // POST: Resposta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RespostaId,PerguntaId,Descricao,Correta")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
				
                db.Resposta.Add(resposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PerguntaId = new SelectList(db.Pergunta, "PerguntaId", "Descricao", resposta.PerguntaId);
            return View(resposta);
        }

        // GET: Resposta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Resposta.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerguntaId = new SelectList(db.Pergunta, "PerguntaId", "Descricao", resposta.PerguntaId);
            return View(resposta);
        }

        // POST: Resposta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RespostaId,PerguntaId,Descricao,Correta")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
			
                db.Entry(resposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PerguntaId = new SelectList(db.Pergunta, "PerguntaId", "Descricao", resposta.PerguntaId);
            return View(resposta);
        }

        // GET: Resposta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposta resposta = db.Resposta.Find(id);
            if (resposta == null)
            {
                return HttpNotFound();
            }
            return View(resposta);
        }

        // POST: Resposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resposta resposta = db.Resposta.Find(id);
            db.Resposta.Remove(resposta);
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
