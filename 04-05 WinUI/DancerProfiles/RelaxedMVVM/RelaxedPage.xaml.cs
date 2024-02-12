using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DancerProfiles.RelaxedMVVM
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class RelaxedPage : Page
	{
		public DancerDialogViewModel VM { get; } = new DancerDialogViewModel();

		public RelaxedPage()
		{
			this.InitializeComponent();
		}

		private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			VM.SelectedDancer.Name = "Michael Jackson";
			Debug.WriteLine(VM.SelectedDancer.Name);
		}
	}
}
