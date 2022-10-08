using System;
using System.ComponentModel.DataAnnotations;

namespace MCake_Manage.Models
{
    public class Pay
    {
        [Key]
        public virtual Guid PayId { get; set; }
        public virtual string UserId { get; set; }
    }
}
