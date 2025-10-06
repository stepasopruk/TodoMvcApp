# ✅ Todo MVC App

Простое приложение **ASP.NET Core MVC** для управления списком задач (To-Do List).  
Проект демонстрирует реализацию **паттерна MVC**, работу с базой данных через **Entity Framework Core** и выполнение операций **CRUD**.

---

## 🚀 Возможности

- ➕ Добавление задач  
- ✏️ Редактирование  
- ❌ Удаление  
- 👀 Просмотр списка задач  
- 💾 Хранение данных в базе SQLite  

---

## 🧠 Используемые технологии

- **C# / ASP.NET Core 8**
- **Entity Framework Core**
- **SQLite**
- **Razor Pages / MVC**
- **Bootstrap 5**

---

## ⚙️ Как запустить проект

1. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/stepasopruk/TodoMvcApp.git
   ```
2. Перейдите в папку проекта:
   ```bash
   cd TodoMvcApp
   ```
3. Примените миграции и создайте базу данных:
   ```bash
   dotnet ef database update
   ```
4. Запустите приложение:
   ```bash
   dotnet run
   ```
5. Откройте в браузере:
👉 https://localhost:5001/Todos

## 🎯 Цели проекта

Этот проект создан в учебных целях, чтобы:
- Изучить основы ASP.NET Core MVC
- Освоить работу с Entity Framework Core
- Научиться выполнять операции CRUD
- Понять структуру MVC-приложений на практике
