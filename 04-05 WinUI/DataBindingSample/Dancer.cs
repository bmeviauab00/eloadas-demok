using CommunityToolkit.Mvvm.ComponentModel;

namespace DataBindingSample
{
	public partial class Dancer : ObservableObject
	{
		[ObservableProperty]
		string name = "Fred Astaire";

		[ObservableProperty]
		string danceStyle = "Sztepp";

		[ObservableProperty]
		int? points = 0;

		[ObservableProperty]
		Role role = Role.Leader | Role.Solo;
	}

	/*
	public class Dancer : INotifyPropertyChanged
	{
		string name = "";
		public string Name
		{
			get => name;
			set
			{
				if (name == value) return;
				name = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public string DanceStyle { get; set; } = "Sztepp";

		public int? Points { get; set; }
		public string Nationality { get; set; } = "American";
		public Role Role { get; set; } = Role.Leader | Role.Solo;
	}
	*/

	public enum Role
	{
		Leader = 0b000,
		Follower = 0b001,
		Solo = 0b010,
	}
}
