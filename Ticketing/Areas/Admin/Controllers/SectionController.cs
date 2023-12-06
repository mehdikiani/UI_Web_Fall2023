using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.Models;
using Ticketing.Core;
using Ticketing.Services;
using Ticketing.Core.EntityMappings;
using Ticketing.Data;
namespace Ticketing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectionController : BaseAdminController
    {
        private readonly ISectionService sectionService;

        public SectionController(
            ISectionService sectionService)
        {
            this.sectionService = sectionService;
        }
        public IActionResult Index() => RedirectToAction(nameof(List));
        public IActionResult List()
        {
            var model = sectionService.GetAllSections()?.ToSectionModelList();
            return View(model);
        }

        #region CreateSection
        [HttpGet]
        public IActionResult CreateSection()
        {
            return View(new ModifySectionModel());
        }
        [HttpPost]
        public IActionResult CreateSection(ModifySectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            sectionService.AddSection(model.Title, model.IsActive);

            return RedirectToAction(nameof(List));
        }
        #endregion

        #region Update Section
        [HttpGet]
        public IActionResult UpdateSection(int id)
        {
            //Authentication Authorization Accounting
            var section = sectionService.GetSectionById(id);
            if (section == null)
            //throw new ArgumentException("Section not found");
            {
                AddError("Invalid Section");
                return RedirectToAction(nameof(List));
            }
            var model = new ModifySectionModel
            {
                Id = section.Id,
                Title = section.Title,
                IsActive = section.IsActive
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateSection(ModifySectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var section = sectionService.GetSectionById(model.Id);
            if (section == null)
            {
                ModelState.AddModelError("", "invalid section");
                return View(model);
            }
            section.Title = model.Title;
            section.IsActive = model.IsActive;
            section.ModifyDate = DateTime.Now;
            var result = sectionService.UpdateSection(section);
            if (result > 0)
            {
                AddSuccess("Section was updated successfully");
                return RedirectToAction(nameof(List));
            }
            else
            {
                ModelState.AddModelError("", "Error on updating. Please try again.");
                return View(model);
            }


        }
        #endregion


        #region Delete Section
        [HttpGet]
        public IActionResult DeleteSection(int id)
        {
            //Authentication Authorization Accounting
            var section = sectionService.GetSectionById(id);
            if (section == null)
            //throw new ArgumentException("Section not found");
            {
                AddError("Invalid Section");
                return RedirectToAction(nameof(List));
            }
            var model = new DeleteSectionModel
            {
                Id = section.Id,
                Title = section.Title
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteSection(DeleteSectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var section = sectionService.GetSectionById(model.Id);
            if (section == null)
            {
                ModelState.AddModelError("", "invalid section");
                return View(model);
            }
            var result = sectionService.DeleteSection(section);
            if (result > 0)
            {
                AddSuccess("Section was deleted successfully");
                return RedirectToAction(nameof(List));
            }
            else
            {
                ModelState.AddModelError("", "Error on deleting. Please try again.");
                return View(model);
            }

        }
        #endregion
    }
}
