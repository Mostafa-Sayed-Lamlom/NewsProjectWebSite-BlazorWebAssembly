using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages
{
	public partial class Index
	{
		[Inject]
		NavigationManager navigation {  get; set; }
		public Dictionary<string, object> ImgAttributes { get; set; } = new Dictionary<string, object>
	{
		{"src", "/Imgs/DataBase.png"},
		{"alt", "No Image found"}
	};
		public string FontColor { get; set; } = "color: red";

		public void GoToCounter()
		{
			navigation.NavigateTo("counter");
		}
	}
}
