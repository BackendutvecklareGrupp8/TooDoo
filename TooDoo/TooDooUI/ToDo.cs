using System;

namespace ToDoList
{
    /// <summary>
    /// Represents a list item in a ToDo list
    /// </summary>
    public class ToDo
    {
        public ToDo() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Finnished { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeadLine { get; set; }
        public int EstimationTime { get; set; }
        public bool IsImportant { get; set; }
    }
}