﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public BdContext Context;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			System.Windows.Data.CollectionViewSource bdContextViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bdContextViewSource")));
			// Load data by setting the CollectionViewSource.Source property:
			// bdContextViewSource.Source = [generic data source]
		}
	}
}