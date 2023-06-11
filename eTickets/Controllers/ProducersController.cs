using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service=service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //Get:Producers/Details/1

        public async Task<IActionResult> Details (int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null) return View("Not Found");
            return View(producerDetails);
        }

        
        //Get: Producers/Create

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producers/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);

            if (producersDetails == null) return View("Not Found");
            return View(producersDetails);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //GEt: Producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);

            if (producersDetails == null) return View("Not Found");
            return View(producersDetails);
        }


        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var producersDetails = await _service.GetByIdAsync(id);
            if (producersDetails == null) return View("Not Found");
            
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
