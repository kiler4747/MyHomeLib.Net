using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeLib.Net
{
	public class BdContext:DbContext
	{
		public BdContext()
			:base()
		{
			
		}

		public BdContext(string connectionStringName)
			: base("name=ConnectionStringName")
		{
			
		}

		public DbSet<Autor> Autors { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Sequence> Sequences { get; set; }
	}
}
