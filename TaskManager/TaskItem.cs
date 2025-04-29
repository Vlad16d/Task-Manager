namespace TaskManager
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; } // Здесь должно быть свойство Name, а не Title
        public bool IsCompleted { get; set; }
        public List<string> Tags { get; set; } = new List<string>();

        public override string ToString()
        {
            return Name;
        }
    }

}
