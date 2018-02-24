using SQLite;

namespace SZWMar2018.Core.Models
{
    public class Objective
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed(Unique = true)]
        public int ObjectiveNo { get; set; }
    }
}
