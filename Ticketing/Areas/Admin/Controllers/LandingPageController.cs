using Microsoft.AspNetCore.Mvc;
using Ticketing.Core.Models;
using Ticketing.Core;
using Ticketing.Services;
using Ticketing.Core.EntityMappings;
using Ticketing.Data;
namespace Ticketing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LandingPageController : BaseAdminController
    {
        private readonly ILandingPageService LandingPageService;

        public LandingPageController(
            ILandingPageService LandingPageService)
        {
            this.LandingPageService = LandingPageService;
        }
        public IActionResult Index() => RedirectToAction(nameof(List));
        public async Task<IActionResult> List()
        {
            var model =(await LandingPageService.GetAllLandingPageSectionsAsync())?.ToLandingPageModellList();
            return View(model);
        }

        #region CreateLandingPageSections
        [HttpGet]
        public  IActionResult CreateLandingPageSections()
        {
            return View(new ModifyLandingPageSectionsModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateLandingPageSections(ModifyLandingPageSectionsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await LandingPageService.AddLandingPageSectionsAsync(model.Section1, model.Section2);

            return RedirectToAction(nameof(List));
        }
        #endregion

        #region Update LandingPageSections
        [HttpGet]
        public async Task<IActionResult> UpdateLandingPageSections(int id)
        {
            //Authentication Authorization Accounting
            var LandingPageSections =await LandingPageService.GetLandingPageSectionsByIdAsync(id);
            if (LandingPageSections == null)
            //throw new ArgumentException("LandingPageSections not found");
            {
                AddError("Invalid LandingPageSections");
                return RedirectToAction(nameof(List));
            }
            var model = new ModifyLandingPageSectionsModel
            {
                Section1 = LandingPageSections.Section1,
                Section2 = LandingPageSections.Section2
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLandingPageSections(ModifyLandingPageSectionsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var LandingPageSections =await LandingPageService.GetLandingPageSectionsByIdAsync(model.Id);
            if (LandingPageSections == null)
            {
                ModelState.AddModelError("", "invalid LandingPageSections");
                return View(model);
            }
            LandingPageSections.Section1 = model.Section1;
            LandingPageSections.Section2 = model.Section2;
            var result =await LandingPageService.UpdateLandingPageSectionsAsync(LandingPageSections);
            if (result > 0)
            {
                AddSuccess("LandingPageSections was updated successfully");
                return RedirectToAction(nameof(List));
            }
            else
            {
                ModelState.AddModelError("", "Error on updating. Please try again.");
                return View(model);
            }


        }
        #endregion


        #region Delete LandingPageSections
        [HttpGet]
        public async Task<IActionResult> DeleteLandingPageSections(int id)
        {
            //Authentication Authorization Accounting
            var LandingPageSections =await LandingPageService.GetLandingPageSectionsByIdAsync(id);
            if (LandingPageSections == null)
            {
                AddError("Invalid LandingPageSections");
                return RedirectToAction(nameof(List));
            }
            var model = new DeleteLandingPageSectionsModel
            {
                Id = LandingPageSections.Id,
                Section1 = LandingPageSections.Section1,
                Section2 = LandingPageSections.Section2
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteLandingPageSections(DeleteLandingPageSectionsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var LandingPageSections =await LandingPageService.GetLandingPageSectionsByIdAsync(model.Id);
            if (LandingPageSections == null)
            {
                ModelState.AddModelError("", "invalid LandingPageSections");
                return View(model);
            }
            var result =await LandingPageService.DeleteLandingPageSectionsAsync(LandingPageSections);
            if (result > 0)
            {
                AddSuccess("LandingPageSections was deleted successfully");
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
