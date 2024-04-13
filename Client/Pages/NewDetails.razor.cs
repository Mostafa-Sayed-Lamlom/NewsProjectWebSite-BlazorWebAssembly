using BlazorApp1.Client.Services;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages
{
    public partial class NewDetails
    {
        List<Comment> _comments { get; set; } = new List<Comment>();
        [Inject]
        public IMainServices<Comment> _commentServices { get; set; }
        NewsList newsList = new NewsList();
		[Inject]
		IMainServices<NewsList> MainServices { get; set; }
		[Parameter]
		public string id { get; set; }
        public Comment newComment { get; set; } = new Comment();
        protected async override Task OnInitializedAsync()
		{
			newsList = await MainServices.GetRow($"api/NewsList/GetNew/{id}");
			_comments = await _commentServices.GetAll($"api/Comments/GetAllComments/{id}");
		}
		private async Task AddComment()
		{
			newComment.newsListId = int.Parse(id);
			await _commentServices.AddNewRow(newComment, "api/Comments/AddComment");
			newComment = new Comment();
            _comments = await _commentServices.GetAll($"api/Comments/GetAllComments/{id}");
        }
	}
}
