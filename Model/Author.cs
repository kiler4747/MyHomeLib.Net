using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeLib.Net
{
	public class Author
	{
		public Author()
		{
			//Books = new List<Book>();
		}

		[Key]
		public long AuthorID { get; set; }

		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string SearchName { get; set; }

		//public List<Book> Books { get; set; }
	}
}
