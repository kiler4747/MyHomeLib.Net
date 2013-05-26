using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyHomeLib.Net
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public BdContext Context = new BdContext();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource bdContextAutorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bdContextAutorsViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			//Context.Autors.Take(50000).Select(x => new { FirstName = x.FirstName, LastName = x.LastName, MiddleName = x.MiddleName }).ToArray().Load();
			bdContextAutorsViewSource.Source = Context.Autors.Where(y => y.Books.Count > 0).Select(x => new { x.IdAutor, x.FirstName, x.LastName, x.MiddleName }).AsParallel().ToArray();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			System.Windows.Data.CollectionViewSource bdContextAutorsViewSource =
				((System.Windows.Data.CollectionViewSource) (this.FindResource("bdContextAutorsViewSource")));
			var words = SearchTextBox.Text.Split(new[] {' '});
			var query = Context.Autors.AsQueryable();
			query = words.Aggregate(query,
			                        (current, word) =>
			                        current.Where(x => x.FirstName == word || x.MiddleName == word || x.LastName == word));
			//object result = default(object);
			new Thread(() =>
				{
					var result = query.Select(x => new {x.IdAutor, x.FirstName, x.LastName, x.MiddleName})
							                                        .AsParallel()
							                                        .ToArray();
					if (!result.Any())
						return;
					bdContextAutorsViewSource.Dispatcher.Invoke(() =>
						{
							bdContextAutorsViewSource.Source = result;
						});
				}

	).Start();
			//if (!result.Any())
			//	return;
			//bdContextAutorsViewSource.Source = result;
		}

		static T CastType<T>(object obj, T type) { return (T)obj; }

		private void autorsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			System.Windows.Data.CollectionViewSource bdContextAutorsBooksViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bdContextAutorsBooksViewSource")));
			//var autor = ((new {FirstName = "", LastName = "", MiddleName = ""}))autorsDataGrid.SelectedItem;
			//bdContextAutorsBooksViewSource.Source = autor.Books;
			var a = CastType(autorsDataGrid.SelectedValue, new { IdAutor = 0, FirstName = "", LastName = "", MiddleName = "" });
			if (a == null)
			{
				bdContextAutorsBooksViewSource.Source = null;
				return;
			}
			bdContextAutorsBooksViewSource.Source = Context.Books.Where(x => x.Autors.Any(y => y.IdAutor == a.IdAutor)).ToArray();
		}
	}
}
