using BlazorApp1.Client.Services;
using BlazorApp1.Shared.Dtos;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp1.Client.Pages
{
    public partial class NewsAdd
    {
       
        public NewsListDto NewsListDto { get; set; } = new NewsListDto();
        [Inject]
        public IMainServices<Category> _categoryService { get; set; }
        List<Category> _categories { get; set; } = new List<Category>();
        [Inject]
        IMainServices<NewsListDto> MainServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        IBrowserFile browserFile { get; set; }
        string imgUrl { get; set; } = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            _categories = await _categoryService.GetAll("api/Categories/GetAllCategories");
        }
        public async Task Create()
        {
            NewsListDto.ImgPath = browserFile.Name;

            using (var ms = new MemoryStream())
            {
                await browserFile.OpenReadStream().CopyToAsync(ms);
                NewsListDto.NewImg = ms.ToArray();
                ms.Dispose();
            }
            await MainServices.AddNewRow(NewsListDto, "api/NewsList/AddNew");
            _navigationManager.NavigateTo("newsLists");
        }
        private async Task OnFileSelection(InputFileChangeEventArgs e)
        {
            browserFile = e.File;
            var buffers = new byte[browserFile.Size];
            await browserFile.OpenReadStream().ReadAsync(buffers);
            string imageType = browserFile.ContentType;
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
            this.StateHasChanged();
        }

    }
}
