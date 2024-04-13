using BlazorApp1.Client.Services;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages
{
	public partial class CategoryUpdate
	{
		Category category = new Category();
		[Inject]
		IMainServices<Category> _services { get; set; }
        [Parameter]
        public string id { get; set; }
		protected async override Task OnInitializedAsync()
		{
			category = await _services.GetRow($"api/Categories/GetCategory/{id}");
		}

		[Inject]
		NavigationManager _navigationManager { get; set; }
		public async Task UpdateCat()
		{
			await _services.UpdateRow(category, $"api/Categories/UpdateCategory");
			_navigationManager.NavigateTo("/categories");
		}
	}
}
