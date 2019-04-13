using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ToDoList.Data;
    using ToDoList.Models;
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new ToDoDb())
            {
                var allTasks = db.Task.ToList();
                return View(allTasks);
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string title, string comments)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(comments))
            //if (!(ModelState.IsValid))
            {
                return RedirectToAction("Index");
            }
            Task NewTask = new Task
            {
                Title = title,
                Comments = comments,
            };
            using (var db = new ToDoDb())
            {
                db.Task.Add(NewTask);
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit (int Id)
        {
            using (var db = new ToDoDb())
            {
                var TaskToEdit = db.Task.FirstOrDefault(t => t.Id == Id);
                if (TaskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return View(TaskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Task TaskToEdit)
        {
            using (var db = new ToDoDb())
            {
                var oldTask = db.Task.FirstOrDefault(t => t.Id == TaskToEdit.Id);
                if (oldTask == null)
                {
                    return RedirectToAction("Index");
                }
                oldTask.Title = TaskToEdit.Title;
                oldTask.Comments = TaskToEdit.Comments;
                if (string.IsNullOrEmpty(oldTask.Title) || string.IsNullOrEmpty(oldTask.Comments))
                {
                    return RedirectToAction("Index");
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            using (var db = new ToDoDb())
            {
                var taskToDelete = db.Task.FirstOrDefault(t => t.Id == Id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                db.Task.Remove(taskToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
