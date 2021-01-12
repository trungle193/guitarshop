using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GuitarShopWeb.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PageContent { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
