using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoEstoque.Data;
using ProjetoEstoque.Models;

namespace ProjetoEstoque.Controllers
{
    public class CompraVendasController : Controller
    {
        private ProjetoEstoqueContext db = new ProjetoEstoqueContext();

        // GET: CompraVendas
        public ActionResult Index()
        {
            return View(db.CompraVendas.ToList());
        }

        // GET: CompraVendas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenda compraVenda = db.CompraVendas.Find(id);
            if (compraVenda == null)
            {
                return HttpNotFound();
            }
            return View(compraVenda);
        }

        // GET: CompraVendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompraVendas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NomeProdutoC,ValorFornecedor,ValorCliente,QuantidadeComprada,QuantidadeVendida,ProdutosId")] CompraVenda compraVenda)
        {
            if (ModelState.IsValid)
            {
                db.CompraVendas.Add(compraVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compraVenda);
        }

        // GET: CompraVendas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenda compraVenda = db.CompraVendas.Find(id);
            if (compraVenda == null)
            {
                return HttpNotFound();
            }
            return View(compraVenda);
        }

        // POST: CompraVendas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NomeProdutoC,ValorFornecedor,ValorCliente,QuantidadeComprada,QuantidadeVendida,ProdutosId")] CompraVenda compraVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compraVenda);
        }

        // GET: CompraVendas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenda compraVenda = db.CompraVendas.Find(id);
            if (compraVenda == null)
            {
                return HttpNotFound();
            }
            return View(compraVenda);
        }

        // POST: CompraVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CompraVenda compraVenda = db.CompraVendas.Find(id);
            db.CompraVendas.Remove(compraVenda);
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
