
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea3_Clientes.Models;
using Tarea3_Clientes.Data;

public class ClientesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClientesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CLIENTESMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Clientes.ToListAsync());
    }

    // GET: CLIENTESMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clientesmodel = await _context.Clientes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clientesmodel == null)
        {
            return NotFound();
        }

        return View(clientesmodel);
    }

    // GET: CLIENTESMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CLIENTESMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Id_Tributaria,Num_Identificacion,Razon_Social,Direccion,Telefono,Correo,Codigo_Postal,Tiene_Credito,Creacion")] ClientesModel clientesmodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(clientesmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(clientesmodel);
    }

    // GET: CLIENTESMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clientesmodel = await _context.Clientes.FindAsync(id);
        if (clientesmodel == null)
        {
            return NotFound();
        }
        return View(clientesmodel);
    }

    // POST: CLIENTESMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Id_Tributaria,Num_Identificacion,Razon_Social,Direccion,Telefono,Correo,Codigo_Postal,Tiene_Credito,Creacion")] ClientesModel clientesmodel)
    {
        if (id != clientesmodel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(clientesmodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesModelExists(clientesmodel.Id))
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
        return View(clientesmodel);
    }

    // GET: CLIENTESMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var clientesmodel = await _context.Clientes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (clientesmodel == null)
        {
            return NotFound();
        }

        return View(clientesmodel);
    }

    // POST: CLIENTESMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var clientesmodel = await _context.Clientes.FindAsync(id);
        if (clientesmodel != null)
        {
            _context.Clientes.Remove(clientesmodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ClientesModelExists(int? id)
    {
        return _context.Clientes.Any(e => e.Id == id);
    }
}
