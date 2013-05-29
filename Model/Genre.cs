using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHomeLib.Net
{
	public class Genre
	{
		public Genre()
		{
			Books = new List<Book>();
		}

		[Key]
		public int IdGenre { get; set; }

		public string GenreCode { get; set; }
		public string Description { get; set; }
		public string Meta { get; set; }

		public List<Book> Books { get; set; }
	}
}