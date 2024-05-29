using Microsoft.AspNetCore.Mvc;

namespace WebAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : Controller
    {
        private List<string> Animals = new List<string> { "Pig", "Dog", "Cat", "Bird", "Rabbit" };
        private List<string> Colors = new List<string> { "Red", "Blue", "Black", "Green", "Orange"};
        [HttpGet(Name = "GetAnimal")]
        public Animal Get() {
            return new Animal
            {
                Name = Animals[Random.Shared.Next(Animals.Count)],
                Age = Random.Shared.Next(12),
                Color = Colors[Random.Shared.Next(Colors.Count)]
            };
        }
           
        
    }
}
