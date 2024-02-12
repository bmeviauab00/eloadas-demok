using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DataBindingSample
{
	public sealed partial class MainUserControl : UserControl, INotifyPropertyChanged
	{
		public Dancer Dancer { get; set; } = new Dancer();

		public ObservableCollection<string> DanceStyles { get; }
			= new(new[] { "Salsa", "Sztepp", "West Coast Swing" });

		public bool IsStringNotEmpty(string str)
			=> !string.IsNullOrWhiteSpace(str);

		bool isValid = false;
		public bool IsValid
		{
			get => isValid;
			set
			{
				if (value == isValid) return;
				isValid = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsValid)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public MainUserControl()
		{
			this.InitializeComponent();
		}


		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Debug.WriteLine(Dancer.DanceStyle);
		}
	}
}
