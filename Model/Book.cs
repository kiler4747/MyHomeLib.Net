using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHomeLib.Net
{
	public class Book
	{
		public Book()
		{
			Autors = new List<Author>();
			Genres = new List<Genre>();
			Sequences = new List<Sequence>();
		}

		[Key]
		public int IdBook { get; set; }

		public string Title { get; set; }
		public string Title1 { get; set; }
		public long FileSize { get; set; }
		public int Year { get; set; }
		public bool Deleted { get; set; }
		public string Keywords { get; set; }
		public DateTime Time { get; set; }
		public string Lang { get; set; }
		public string FileType { get; set; }
		public DateTime Modified { get; set; }

		public List<Author> Autors { get; set; }
		public List<Genre> Genres { get; set; }
		public List<Sequence> Sequences { get; set; }
	}
}