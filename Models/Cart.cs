using System;
using System.ComponentModel.DataAnnotations;

namespace MCake_Manage.Models
{
    public class Cart
    {
        [Key]
        public virtual Guid CartId { get; set; }
        public virtual string User { get; set; }
        public virtual long ShippingPrice { get; set; }
        public virtual long Total { get; set; }
        public virtual DateTime Stamp { get; set; }

    }
}
