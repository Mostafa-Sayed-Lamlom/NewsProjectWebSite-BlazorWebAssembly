using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentDetails { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public int newsListId { get; set; }
        public NewsList? newsList { get; set; }
    }
}
