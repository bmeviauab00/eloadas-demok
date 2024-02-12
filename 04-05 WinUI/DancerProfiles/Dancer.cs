using CommunityToolkit.Mvvm.ComponentModel;

namespace DancerProfiles
{
	public partial class Dancer : ObservableObject
	{
		public Dancer(string name, string profilePicture, Role role, int? points = null)
		{
			this.name = name;
			this.profilePicture = profilePicture;
			this.role = role;
			this.points = points;
		}

		public static Dancer[] Dancers = new[]
		{
			new Dancer( "Kowalska Izabella", "assets/iza.jpg", Role.Follower, 6 ),
			new Dancer( "Jakub Jakoubek", "assets/jakub.jpg", Role.Leader, 12 ),
			new Dancer( "Emeline Rochefeuille", "assets/emeline.jpg", Role.Follower, 38 ),
			new Dancer( "Maxence Martin", "assets/maxence.jpg", Role.Leader, 92 ),
			new Dancer( "Virginie Grondin", "assets/virginie.jpg", Role.Follower, 24 )
		};





		[ObservableProperty]
		string name = "Fred Astaire";

		[ObservableProperty]
		string danceStyle = "Sztepp";

		[ObservableProperty]
		int? points = 0;

		[ObservableProperty]
		Role role = Role.Leader | Role.Solo;

		[ObservableProperty]
		string profilePicture = "";
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
