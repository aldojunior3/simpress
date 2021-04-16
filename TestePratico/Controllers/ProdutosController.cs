using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestePratico.Models;

namespace Mvc_Imagem.Controllers
{
    public class ProdutosController : Controller
    {
        MapeamentoProduto db;
        public ProdutosController()
        {
            db = new MapeamentoProduto();
        }
        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = db.Produtos.ToList();
            return View(produtos);
        }

        //POST INSERIR
        public ActionResult Create()
        {
            ViewBag.Categorias = db.Categorias;
            var model = new ProdutoViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel model)
        {           
            if (ModelState.IsValid)
            {
                var produto = new Produto();
                produto.Nome = model.Nome;                
                produto.Descricao = model.Descricao;
                produto.CategoriaID = model.CategoriaID;
                produto.Ativo = model.Ativo;
                produto.Perecivel = model.Perecivel;
                
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Se ocorrer um erro retorna para pagina
            ViewBag.Categories = db.Categorias;
            return View(model);
        }

        //PUT EDITAR
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categorias = db.Categorias;
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,CategoriaID,Ativo,Perecivel")] Produto model)
        {
            if (ModelState.IsValid)
            {
                var produto = db.Produtos.Find(model.Id);
                if (produto == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                produto.Nome = model.Nome;
                produto.Descricao = model.Descricao;
                produto.CategoriaID = model.CategoriaID;
                produto.Ativo = model.Ativo;
                produto.Perecivel = model.Perecivel;             

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = db.Categorias;
            return View(model);
        }

        //DELETE PRODUTOS
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = db.Categorias.Find(produto.Id).Nome;
            return View(produto);
        }
        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}