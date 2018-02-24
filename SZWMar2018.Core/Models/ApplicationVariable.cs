using SQLite;

namespace SZWMar2018.Core.Models
{
    public class ApplicationVariable
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[Indexed(Unique = true)]
		public string Key { get; set; }

		public string Value { get; set; }
	}
}
