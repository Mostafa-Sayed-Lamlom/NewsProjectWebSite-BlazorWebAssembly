using BlazorApp1.Client.Services;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Pages
{
    public partial class Categories : ComponentBase
    {
        [Inject]
        public IMainServices<Category> _categoryService { get; set; }
        List<Category> _categories { get; set; } = null;
        [Inject]
        public IJSRuntime JS { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(GetAllData);
        }
        private async Task GetAllData()
        {
            System.Threading.Thread.Sleep(2000);
            _categories = new List<Category>();
            _categories = await _categoryService.GetAll("api/Categories/GetAllCategories");
        }
        public async Task DeleteCat(int id)
        {
            var Confirmed = await JS.InvokeAsync<bool>("confirm", "Delete row?");
            if (Confirmed)
            {
                await _categoryService.DeleteRow($"api/Categories/DeleteCategory/{id}");
                _categories = await _categoryService.GetAll("api/Categories/GetAllCategories");
            }
           
        }
    }
}
