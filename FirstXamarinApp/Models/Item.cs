using System;
using System.Collections.Generic;

namespace FirstXamarinApp.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
    }
}