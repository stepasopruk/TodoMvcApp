using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            // Передаём список задач во View
            return View(_context.Todos);
        }

        // Показ формы
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Обработка формы
        [HttpPost]
        public IActionResult Create(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                todo.Id = _context.Todos.Count() + 1;
                _context.Todos.Add(todo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // Редактирование

        // Показ формы редактирования
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return NotFound();

            _context.SaveChanges();
            return View(todo);
        }

        // Обработка изменений
        [HttpPost]
        public IActionResult Edit(TodoItem updatedTodo)
        {
            var existing = _context.Todos.FirstOrDefault(t => t.Id == updatedTodo.Id);
            if (existing == null)
                return NotFound();

            existing.Title = updatedTodo.Title;
            existing.Description = updatedTodo.Description;
            existing.IsComplete = updatedTodo.IsComplete;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Удаление

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return NotFound();

            _context.SaveChanges();
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
                _context.Todos.Remove(todo);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

