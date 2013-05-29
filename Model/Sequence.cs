using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHomeLib.Net
{
	public class Sequence
	{
		public Sequence()
		{
			Books = new List<Book>();
		}
		[Key]
		public int IdSequence { get; set; }

		public string Name { get; set; }
		public List<Book> Books { get; set; }
	}
}