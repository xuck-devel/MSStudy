using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSWebApp.Data;
using CSWebApp.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace CSWebApp.Controllers
{
    public class dbo_Table_3Controller : Controller
    {
        private readonly CSWebAppContext _context;

        public dbo_Table_3Controller(CSWebAppContext context)
        {
            _context = context;
        }

        // GET: dbo_Table_3
        public async Task<IActionResult> Index()
        {

            //リクエストパラメータ
            IQueryCollection reqparams = Request.Query;

            //post body
            Stream postbody = Request.Body;

            var rs2 = _context.Database.SqlQuery<string>($"SELECT DB_NAME() AS Value");
            string db = rs2.First<string>();
            Trace.WriteLine("current db:" + db);

            rs2 = _context.Database.SqlQuery<string>($"SELECT CURRENT_USER AS Value");
            string user = rs2.First<string>();
            Trace.WriteLine("current user:" + user);

            rs2 = _context.Database.SqlQuery<string>($"SELECT SCHEMA_NAME() AS Value");
            string schema = rs2.First<string>();
            Trace.WriteLine("current schema:" + schema);

            rs2 = _context.Database.SqlQuery<string>($"SELECT @@SERVICENAME AS Value");
            string servicename = rs2.First<string>();
            Trace.WriteLine("current servicename:" + servicename);

            List<dbo_Table_3> lst = await _context.dbo_Table_3.ToListAsync();

            FormattableString sql = $"SELECT Aaaa FROM dbo_Table_3";
            var convert = _context.Database.SqlQuery<dbo_Table_3>(sql);
            lst = convert.ToList();

            return View(lst);

        }

        // GET: dbo_Table_3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbo_Table_3 = await _context.dbo_Table_3
                .FirstOrDefaultAsync(m => m.Aaaa == id);
            if (dbo_Table_3 == null)
            {
                return NotFound();
            }

            string sql = @"SELECT Aaaa FROM dbo_Table_3 where Aaaa=@Aaaa";
            object[] param = new object[] { new SqlParameter("@Aaaa", id) };
            var rs = _context.Database.SqlQueryRaw<dbo_Table_3>(sql,param);
            dbo_Table_3 = rs.First<dbo_Table_3>();


            return View(dbo_Table_3);
        }

        // GET: dbo_Table_3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dbo_Table_3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Aaaa")] dbo_Table_3 dbo_Table_3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dbo_Table_3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbo_Table_3);
        }

        // GET: dbo_Table_3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbo_Table_3 = await _context.dbo_Table_3.FindAsync(id);
            if (dbo_Table_3 == null)
            {
                return NotFound();
            }
            return View(dbo_Table_3);
        }

        // POST: dbo_Table_3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Aaaa")] dbo_Table_3 dbo_Table_3)
        {
            if (id != dbo_Table_3.Aaaa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbo_Table_3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbo_Table_3Exists(dbo_Table_3.Aaaa))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dbo_Table_3);
        }

        // GET: dbo_Table_3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbo_Table_3 = await _context.dbo_Table_3
                .FirstOrDefaultAsync(m => m.Aaaa == id);
            if (dbo_Table_3 == null)
            {
                return NotFound();
            }

            return View(dbo_Table_3);
        }

        // POST: dbo_Table_3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dbo_Table_3 = await _context.dbo_Table_3.FindAsync(id);
            if (dbo_Table_3 != null)
            {
                _context.dbo_Table_3.Remove(dbo_Table_3);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dbo_Table_3Exists(string id)
        {
            return _context.dbo_Table_3.Any(e => e.Aaaa == id);
        }
    }
}
