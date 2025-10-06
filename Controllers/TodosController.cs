using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoMvc.Data;
using TodoMvc.Models;

namespace TodoMvc.Controllers
{
    public class TodosController : Controller
    {
        private readonly TodoContext _context;

        public TodosController(TodoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _context.Todos.ToListAsync();
            return View(todos);
        }

        // Показ формы
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Обработка формы
        [HttpPost]
        public async Task<IActionResult> Create(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // Редактирование

        // Показ формы редактирования
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null) 
                return NotFound();

            return View(todo);
        }

        // Обработка изменений
        [HttpPost]
        public async Task<IActionResult> Edit(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // Удаление

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            
            if (todo == null) 
                return NotFound();
            
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}

