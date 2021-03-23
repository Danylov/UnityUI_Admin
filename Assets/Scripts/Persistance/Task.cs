    public class Task
    {
        private int Id;
        private string Code;
        private string Description;
        private string Path;

        public Task(int id, string code, string description, string path)
        {
            Id = id;
            Code = code;
            Description = description;
            Path = path;
        }

        public int Id1
        {
            get => Id;
            set => Id = value;
        }

        public string Code1
        {
            get => Code;
            set => Code = value;
        }
 

        public string Description1
        {
            get => Description;
            set => Description = value;
        }
 
        public string Path1
        {
            get => Path;
            set => Path = value;
        }
   }