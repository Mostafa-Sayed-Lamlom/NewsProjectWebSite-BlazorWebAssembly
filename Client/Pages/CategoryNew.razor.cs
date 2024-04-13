using BlazorApp1.Client.Services;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages
{
    public partial class CategoryNew : ComponentBase
    {
        public Category category { get; set; } = new Category();
        [Inject]
        public IMainServices<Category> _model { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string MyMessages { get; set; } = "";

        public async Task CreateCat()
        {
            try
            {
                await _model.AddNewRow(category, "api/Categories/AddCategory");
                _navigationManager.NavigateTo("/categories");
            }
            catch (Exception ex)
            {                             
                if (ex.Message.Contains("Category name is already exists"))
                    MyMessages = "Category name is already exists";
                //MyMessages = ex.Message;
            }
        }
    }
}
