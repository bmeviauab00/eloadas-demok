using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CodeBehindSample
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>

	public sealed partial class MainWindow : Window
	{
		private void myButton_Click(object sender, RoutedEventArgs e)
		{
			tmr.Stop();
			myButton.Content = "You win!";
		}


		DispatcherTimer tmr = new DispatcherTimer();
		Random random = new Random();

		public MainWindow()
		{
			this.InitializeComponent();
			tmr.Interval = TimeSpan.FromMilliseconds(600);
			tmr.Tick += Tmr_Tick;
			tmr.Start();
		}

		private void Tmr_Tick(object sender, object e)
		{
			Canvas.SetLeft(myButton, random.Next(0, 400));
			Canvas.SetTop(myButton, random.Next(0, 300));
		}

	}
}
