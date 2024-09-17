namespace Productivity.Models
{
    //Model class of Tasks
    public class Tasks
    {
        public int id { get; }
        public string todo { get; set; }
        public int pending { get; set; }
        public DateTime date_day { get; set; }

    }
}
