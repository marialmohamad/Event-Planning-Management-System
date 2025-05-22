using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparklingMVC.Models;
using SparklingMVC.Services;

namespace SparklingMVC.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public EventsController(ApplicationDbContext context, IWebHostEnvironment environment) 
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var Events=context.Events.OrderByDescending(E => E.Id).ToList();
            return View(Events);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EventDto eventDto)
        {
            if(eventDto.ImageFile == null) 
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }

            if(!ModelState.IsValid)
            {
                return View(eventDto);
            }


            //save the image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(eventDto.ImageFile!.FileName);

            string imageFULLPath = environment.WebRootPath + "/Event's/" + newFileName;
            using (var stream = System.IO.File.Create(imageFULLPath))
            {
                eventDto.ImageFile.CopyTo(stream);
            }

            // save the new event in the database
            Event Event = new Event()
            {
                Name = eventDto.Name,   
                EventType = eventDto.EventType,
                Location = eventDto.Location,
                Price = eventDto.Price,
                Description = eventDto.Description,
                ImageFileName = newFileName,
                ReservationNo = DateTime.Now,
                

            };
             
            context.Events.Add(Event);
            context.SaveChanges();
            return RedirectToAction("Index", "Events");
        }


        public IActionResult Bookings(int id)
        {
            return View();
        }

        public IActionResult Reservations(int id) 
        
        {
            return View();
        }
    }
}
