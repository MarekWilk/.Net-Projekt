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
    public class UslugaController : Controller
    {
        private ZakladFryzjerskiEntities db = new ZakladFryzjerskiEntities();

        // GET: Usluga
        public async Task<ActionResult> Index()
        {
            return View(await db.Usługa.ToListAsync());
        }

        // GET: Usluga/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usługa usługa = await db.Usługa.FindAsync(id);
            if (usługa == null)
            {
                return HttpNotFound();
            }
            return View(usługa);
        }

        // GET: Usluga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usluga/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UsługaID,Nazwa,Cena")] Usługa usługa)
        {
            if (ModelState.IsValid)
            {
                db.Usługa.Add(usługa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usługa);
        }

        // GET: Usluga/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usługa usługa = await db.Usługa.FindAsync(id);
            if (usługa == null)
            {
                return HttpNotFound();
            }
            return View(usługa);
        }

        // POST: Usluga/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UsługaID,Nazwa,Cena")] Usługa usługa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usługa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usługa);
        }

        // GET: Usluga/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usługa usługa = await db.Usługa.FindAsync(id);
            if (usługa == null)
            {
                return HttpNotFound();
            }
            return View(usługa);
        }

        // POST: Usluga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usługa usługa = await db.Usługa.FindAsync(id);
            db.Usługa.Remove(usługa);
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
