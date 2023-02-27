using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fryzjerski.Models;

namespace Fryzjerski.Controllers
{
    public class FryzjerController : Controller
    {
        private ZakladFryzjerskiEntities db = new ZakladFryzjerskiEntities();

        // GET: Fryzjer
        public async Task<ActionResult> Index()
        {
            return View(await db.Fryzjer.ToListAsync());
        }

        // GET: Fryzjer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fryzjer fryzjer = await db.Fryzjer.FindAsync(id);
            if (fryzjer == null)
            {
                return HttpNotFound();
            }
            return View(fryzjer);
        }

        // GET: Fryzjer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fryzjer/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FryzjerID,Imie,Nazwisko,DataUrodzenia,StazPracy")] Fryzjer fryzjer)
        {
            if (ModelState.IsValid)
            {
                db.Fryzjer.Add(fryzjer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fryzjer);
        }

        // GET: Fryzjer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fryzjer fryzjer = await db.Fryzjer.FindAsync(id);
            if (fryzjer == null)
            {
                return HttpNotFound();
            }
            return View(fryzjer);
        }

        // POST: Fryzjer/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FryzjerID,Imie,Nazwisko,DataUrodzenia,StazPracy")] Fryzjer fryzjer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fryzjer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fryzjer);
        }

        // GET: Fryzjer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fryzjer fryzjer = await db.Fryzjer.FindAsync(id);
            if (fryzjer == null)
            {
                return HttpNotFound();
            }
            return View(fryzjer);
        }

        // POST: Fryzjer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fryzjer fryzjer = await db.Fryzjer.FindAsync(id);
            db.Fryzjer.Remove(fryzjer);
            await db.SaveChangesAsync();
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
