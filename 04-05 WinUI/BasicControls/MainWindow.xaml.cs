using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BasicControls
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			// normál property
			txt.Text = "🌤️";

			// kulcs-érték pár beállítása az alaposztályon
			DependencyObject dpObj = txt;
			// a dependeny property a tárolás kulcsa
			dpObj.SetValue(TextBox.TextProperty, "🌤️");

			// kulcs-érték párokkal
			dpObj.SetValue(Canvas.LeftProperty, 120);
			dpObj.SetValue(Canvas.TopProperty, 20);
			// a csatolt tulajdonságot definiáló osztál metódusával
			Canvas.SetLeft(txt, 120);
			Canvas.SetTop(txt, 20);

			//			items.ItemsSource = new[] { "alma", "körte", "banán" };

		}
	}
}
