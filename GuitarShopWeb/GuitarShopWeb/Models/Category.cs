using System;
using System.Collections;
using System.Collections.Generic;

namespace GuitarShopWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryType { get; set; }
        public int Level { get; set; }


        public int? ParentId { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Childrens { get; set; }
    }
}