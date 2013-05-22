using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeLib.Net
{
	public class Autor
	{
		[Key]
		public int IdAutor { get; set; }

		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string NickName { get; set; }
		public string Email { get; set; }
		public string Homepage { get; set; }

		public List<Book> Books { get; set; }
	}

	public class Book
	{
		[Key]
		public int IdBook { get; set; }

		public string Title { get; set; }
		public string Title1 { get; set; }
		public int FileSize { get; set; }
		public int Year { get; set; }
		public bool Deleted { get; set; }
		public string Keywords { get; set; }
		public DateTime Time { get; set; }
		public string Lang { get; set; }
		public string FileType { get; set; }
		public DateTime Modified { get; set; }

		public List<Autor> Autors { get; set; }
		public List<Genre> Genres { get; set; }
		public List<Sequence> Sequences { get; set; }
	}

	public class Sequence
	{
		[Key]
		public int IdSequence { get; set; }

		public string Name { get; set; }
		public List<Book> Books { get; set; }
	}

	public class Genre
	{
		[Key]
		public int IdGenre { get; set; }

		public string GenreCode { get; set; }
		public string Description { get; set; }
		public string Meta { get; set; }

		public List<Book> Books { get; set; }
	}
}
