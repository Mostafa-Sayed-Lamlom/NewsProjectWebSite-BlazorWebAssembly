using BlazorApp1.Client.Services;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Client.Pages
{
    public partial class NewsComponent
    {
        [Inject]
        public IMainServices<NewsList> _newsServices { get; set; }
        List<NewsList> _NewsList { get; set; } = new List<NewsList>();
        [Inject]
        public IMainServices<Category> _catServices { get; set; }
        List<Category> _categories { get; set; } = new List<Category>();
        public int catId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _NewsList = await _newsServices.GetAll("api/NewsList/GetAllNews");
            _categories = await _catServices.GetAll("api/Categories/GetAllCategories");
        }
        private async Task GetNewsByCatId(int value)
        {
            _NewsList = new List<NewsList>();
            catId = value;
            if (catId == 0)
            {
                _NewsList = await _newsServices.GetAll("api/NewsList/GetAllNews");
            }
            else
            {
                _NewsList = await _newsServices.GetAll($"api/NewsList/GetAllNewsByCategoryId?id={value}");
            }
        }
    }
}
