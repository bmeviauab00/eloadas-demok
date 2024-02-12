using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace XAMLsample
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			Button b = new Button();
			b.Content = "OK";
			b.Click += Button_Click;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}
