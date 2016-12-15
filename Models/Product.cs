using System;
using System.Collections.Generic;
namespace entityStore.Models
{
    public class Product : BaseEntity
    {  
        public Product ()
        {
            Orders = new List<Order>();
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        private string _Url;
        public string Url 
        { 
            get
            {
                return _Url;
            }
            set
            {
                if (value != null)
                {
                    _Url = value;
                }
                else
                {
                    _Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/600px-No_image_available.svg.png";
                }
            } 
        }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Order> Orders { get; set; }
    }
}