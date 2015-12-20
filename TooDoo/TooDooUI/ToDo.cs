﻿using System;

namespace ToDoList
{
    internal class ToDo
    {
        public ToDo() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finnished { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int EstimationTime { get; set; }
    }
}