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
    public class ProdutosController : Controller
    {
        private ProjetoEstoqueContext db = new ProjetoEstoqueContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.Bebidas);
            return View(produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.BebidasId = new SelectList(db.Bebidas, "BebidasId", "NomeBebida");
            ViewBag.CompraVendaId = new SelectList(db.CompraVendas, "CompraVendaId", "NomeProdutoC");
            return View();
        }

        // POST: Produtos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutosId,NomeProduto,PrecoProduto,Cerveja,Refrigerante,Outros,Doces,QuantidadeComprada,BebidasId,DataCompra,CompraVendaId")] Produtos produtos)
        {
            produtos.DataCompra = DateTime.Now;


            List<CompraVenda> compra = db.CompraVendas.Where(x => x.CompraVendaId > 0).ToList();

            foreach(var item in compra)
            {
                if (item.CompraVendaId == produtos.CompraVendaId)
                {
                    item.QuantidadeComprada -= produtos.QuantidadeComprada;
                    item.QuantidadeVendida += produtos.QuantidadeComprada;
                }
            }


            {
                db.Produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BebidasId = new SelectList(db.Bebidas, "BebidasId", "NomeBebida", produtos.BebidasId);
            return View(produtos);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            ViewBag.BebidasId = new SelectList(db.Bebidas, "BebidasId", "NomeBebida", produtos.BebidasId);
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutosId,NomeProduto,PrecoProduto,Cerveja,Refrigerante,Outros,Doces,QuantidadeComprada,BebidasId,DataCompra")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BebidasId = new SelectList(db.Bebidas, "BebidasId", "NomeBebida", produtos.BebidasId);
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            db.Produtos.Remove(produtos);
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
