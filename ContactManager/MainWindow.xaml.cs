using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ContactManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public ObservableCollection<Contact> Contacts { get; set; }

		public MainWindow()
		{
			InitializeComponent();

			Contacts = new ObservableCollection<Contact>();

			DataContext = Contacts;
		}

		private void MenuItem_AddContact(object sender, RoutedEventArgs e)
		{
			Opacity = 0.5;

			AddContactWindow addContactWindow = new AddContactWindow();
            if (addContactWindow.ShowDialog()!.Value)
            {
				Contacts.Add(addContactWindow.NewContact);
            }

			Opacity = 1;
        }

		private void MenuItem_Exit(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItem_ClearContacts(object sender, RoutedEventArgs e)
		{
			Contacts.Clear();
		}

		private void MenuItem_About(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("This is a simple contact manager.", "Contact Manager", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void Delete_ContactCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
            if (ContactListBox.SelectedIndex != -1)
            {
				e.CanExecute = true;
				return;
            }
			e.CanExecute = false;
		}

		private void Delete_ContactCommand_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			MessageBox.Show($"{ContactListBox.SelectedItem.GetType()}");
		}

		public static class CustomCommands
		{
			public static readonly RoutedUICommand Delete_Contact = new RoutedUICommand(
				"Delete Contact",
				"Delete Contact",
				typeof(CustomCommands)
				);
		}

	}
}
