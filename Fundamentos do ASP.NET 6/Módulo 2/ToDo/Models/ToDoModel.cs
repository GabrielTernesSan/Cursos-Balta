﻿namespace ToDo.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
