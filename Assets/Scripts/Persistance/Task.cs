    public class Task
    {
        private int Id;
        private int Name;
        private int Path;

        public Task(int id, int name, int path)
        {
            Id = id;
            Name = name;
            Path = path;
        }

        public int Id1
        {
            get => Id;
            set => Id = value;
        }

        public int Name1
        {
            get => Name;
            set => Name = value;
        }
 
        public int Path1
        {
            get => Path;
            set => Path = value;
        }
   }