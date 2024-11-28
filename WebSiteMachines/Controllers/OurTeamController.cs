using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.OurTeam;
using WebSiteMachines.Interfaces;
using WebSiteMachines.Models;
using WebSiteMachines.Repositories;

namespace WebSiteMachines.Controllers
{
    public class OurTeamController : Controller
    {
        private readonly IOurTeamService _ourTeamService;
        private readonly IPhotoService _photoService;

        public OurTeamController(IOurTeamService ourTeamService, IPhotoService photoService)
        {
            _ourTeamService = ourTeamService;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _ourTeamService.GetAll();

            var VM = new OurTeamViewModel
            {
               OurTeams = model
            };

            return View(VM);
        }

        public async Task<IActionResult> Create()
        {
            var model = new OurTeamUpsertViewModel();

            return View(model);

        }

        [HttpPost] 
        public async Task<IActionResult> Create(OurTeamUpsertViewModel Vm)
        {
            if (!ModelState.IsValid)
            {
                string imageUrl = null;
                if (Vm.FileImage != null)
                {
                    var result = await _photoService.AddPhotoAsync(Vm.FileImage);
                    if (result != null && result.Url != null)
                    {
                        imageUrl = result.Url.ToString();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Photo upload failed");
                        return View(Vm);
                    }
                }
                var entity = new OurTeam
                {
                    Name = Vm.Name,
                    position=Vm.position,
                    Image= imageUrl

                };
                _ourTeamService.Add(entity);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(Vm);
        }

        public async Task<ActionResult> Edit(int id)
        {
            OurTeam ourTeam = await _ourTeamService.GetById(id);
            if (ourTeam == null) return NotFound();


            var VM = new OurTeamUpsertViewModel
            {
                Name = ourTeam.Name,
                position = ourTeam.position,
                Image = ourTeam.Image,

            };
            return View(VM);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id , OurTeamUpsertViewModel VM)
        {
            if (!ModelState.IsValid)
            {
                var exitingOurTeam = await _ourTeamService.GetById(id);
                if (exitingOurTeam == null) return NotFound();

                string imageUrl = exitingOurTeam.Image;

                if (VM.FileImage != null)
                {
                    var result = await _photoService.AddPhotoAsync(VM.FileImage); 
                    if (result != null && result.Url != null)
                    {
                        imageUrl = result.Url.ToString();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Photo upload failed");
                        return View(VM);
                    }

                }
                exitingOurTeam.Name = VM.Name;
                exitingOurTeam.position = VM.position;
                exitingOurTeam.Image = imageUrl;

                _ourTeamService.Update(exitingOurTeam);
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Invalid data provided");
            return View(VM);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var member = await _ourTeamService.GetById(id);
            if (member == null) return View("Error");

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _ourTeamService.GetById(id);
            if (member == null) { return View("Error"); }

            _ourTeamService.Delete(member);
            return RedirectToAction("Index");
        }
    }
}
