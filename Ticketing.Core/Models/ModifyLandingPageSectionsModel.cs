using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Core.Models
{
    public class ModifyLandingPageSectionsModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "فیلد بخش 1 الزامی است")]
        public string Section1 { get; set; }
        [Required(ErrorMessage = "فیلد بخش 2 الزامی است")]
        public string Section2 { get; set; }

    }
}
