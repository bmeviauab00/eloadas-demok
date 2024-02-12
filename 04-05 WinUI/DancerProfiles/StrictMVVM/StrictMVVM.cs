using CommunityToolkit.Mvvm.ComponentModel;

namespace DancerProfiles.StrictMVVM
{
	// model class - no INPC
	public class Dancer
	{
		public string Name { get; set; }
	}

	// Model is embedded in ViewModel, adds INPC
	public class DancerViewModel : ObservableObject
	{
		public DancerViewModel(Dancer dancer) { this.dancer = dancer; }
		Dancer dancer;
		public string Name
		{
			get => dancer.Name;
			set => SetProperty(dancer.Name, value, dancer,
					(dancer, value) => dancer.Name = value);
		}
	}

	// Page ViewModel uses only ViewModels
	public partial class DancerDialogViewModel : ObservableObject
	{
		[ObservableProperty]
		DancerViewModel selectedDancerVM;

		public DancerDialogViewModel()
		{
			selectedDancerVM = new DancerViewModel(new Dancer { Name = "Fred Astaire" });
		}
	}

}
