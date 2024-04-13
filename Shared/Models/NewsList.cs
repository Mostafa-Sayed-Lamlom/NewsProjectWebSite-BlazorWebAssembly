﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class NewsList
    {
        public int Id { get; set; }
        public DateTime NewDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string SubTiltle { get; set; }
        public string ShortDetails { get; set; }
        public string Details { get; set; }
        public string? ImgPath { get; set; }
        public int categoryId { get; set; }
        public Category? category { get; set; }
    }
}
