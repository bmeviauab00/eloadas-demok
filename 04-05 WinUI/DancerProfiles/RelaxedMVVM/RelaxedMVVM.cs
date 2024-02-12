using CommunityToolkit.Mvvm.ComponentModel;

namespace DancerProfiles.RelaxedMVVM
{
	// model class - has INPC, properties etc.
	public partial class Dancer : ObservableObject
	{
		[ObservableProperty]
		string name;
	}

	// Page ViewModel exposes Models
	public partial class DancerDialogViewModel : ObservableObject
	{
		[ObservableProperty]
		Dancer selectedDancer;

		public DancerDialogViewModel()
		{
			selectedDancer = new Dancer { Name = "Fred Astaire" };
		}
	}

}
