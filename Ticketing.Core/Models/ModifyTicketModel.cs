using System.ComponentModel.DataAnnotations;

namespace Ticketing.Core.Models
{
    public class ModifyTicketModel
    {
        public ModifyTicketModel()
        {
            Sections = new();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "فیلد عنوان الزامی است")]
        [StringLength(128, ErrorMessage = "عنوان حداقل 5 و حداکثر 128 کاراکتر باید باشد", MinimumLength = 5)]
        public string Title { get; set; }
        [Required(ErrorMessage = "فیلد متن الزامی است")]
        public string Description { get; set; }
        public int SectionId { get; set; }
        public List<SectionModel> Sections { get; set; }
    }
}
