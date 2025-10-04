using Microsoft.AspNetCore.Mvc;
using TodoMvc.Models;

namespace TodoMvc.Controllers
{
    public class TodosController : Controller
    {
        // Временное хранилище задач (пока без базы)
        private static List<TodoItem> _todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Купить хлеб", IsComplete = false },
            new TodoItem { Id = 2, Title = "Позаниматься C#", IsComplete = true }
        };

        public IActionResult Index()
        {
            // Передаём список задач во View
            return View(_todos);
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
                todo.Id = _todos.Count + 1;
                _todos.Add(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // Редактирование

        // Показ формы редактирования
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return NotFound();

            return View(todo);
        }

        // Обработка изменений
        [HttpPost]
        public IActionResult Edit(TodoItem updatedTodo)
        {
            var existing = _todos.FirstOrDefault(t => t.Id == updatedTodo.Id);
            if (existing == null)
                return NotFound();

            existing.Title = updatedTodo.Title;
            existing.Description = updatedTodo.Description;
            existing.IsComplete = updatedTodo.IsComplete;

            return RedirectToAction("Index");
        }

        // Удаление

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
                return NotFound();

            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
                _todos.Remove(todo);

            return RedirectToAction("Index");
        }
    }
}

