using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Models
{
    public class ModifySectionModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "فیلد عنوان الزامی است")]
        [StringLength(256, ErrorMessage = "عنوان حداقل 5 و حداکثر 128 کاراکتر باید باشد", MinimumLength = 5)]
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
