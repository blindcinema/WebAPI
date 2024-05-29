using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private static readonly List<string> animalNames = new List<string> { "Pig", "Dog", "Cat", "Bird", "Rabbit" };
        private static readonly List<string> colors = new List<string> { "Red", "Blue", "Black", "Green", "Orange" };
        public static List<Animal> animals = new List<Animal> { new Animal {
            id = 1,
            Name = animalNames[Random.Shared.Next(animalNames.Count)],
            Age = Random.Shared.Next(12),
            Color = colors[Random.Shared.Next(colors.Count)]
            },
            new Animal
            {   id = 2,
                Name = "THIS NAME DOESNT CHANGE",
                Age = 12,
                Color = "THIS COLOR DOESNT CHANGE"
            }


        };
        [HttpGet(Name = "GetAnimal")]
        public  IEnumerable<Animal> Get()    
        {
            Console.WriteLine(animals.Count());
            return animals;
        }
        [HttpDelete(Name = "DeleteAnimal")]
        public object  Delete(int id)
        {   if (id > animals.Count)
            {
                return StatusCode(400);
            }
            animals.RemoveAll((Animal item) => item.id == id);
            return animals;
        }
        [HttpPost(Name = "CreateAnimal")]
        //[ProducesResponseType(StatusCodes.Status201Created)]

        public ActionResult<Animal> Create(string name, string color, int age)
        {
            Animal createdAnimal = new Animal { Name = name, Color = color , Age = age};
            animals.Add(createdAnimal);
            return Ok();  
            
        }
        
     }
}

