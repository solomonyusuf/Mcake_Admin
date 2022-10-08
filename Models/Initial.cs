using System;
using System.ComponentModel.DataAnnotations;

namespace MCake_Manage.Models
{
    public class Initial
    {
        [Key]
        public virtual Guid InitialId { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual string User { get; set; }
        public virtual string Status { get; set; }
        public virtual Guid ProductId { get; set; }
        public virtual string Image_1 { get; set; }
        public virtual string Quantity { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Price { get; set; }
        public virtual string ShippingPrice { get; set; }
    }
}
