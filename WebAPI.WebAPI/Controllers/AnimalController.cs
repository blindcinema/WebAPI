using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[Controller]/[Action]")]
    public class AnimalController : ControllerBase
    {
        private static readonly List<string> _animalNames = new List<string> { "Pig", "Dog", "Cat", "Bird", "Rabbit" };
        private static readonly List<string> _colors = new List<string> { "Red", "Blue", "Black", "Green", "Orange" };
        public static List<Animal> Animals = new List<Animal> { }; 
        /*
         * public static List<Animal> Animals = new List<Animal> { new Animal {
            Id = Guid.NewGuid(),
            Name = _animalNames[Random.Shared.Next(_animalNames.Count)],
            Age = Random.Shared.Next(12),
            Color = _colors[Random.Shared.Next(_colors.Count)]
            },
            new Animal
            {   Id = Guid.NewGuid(),
                Name = "THIS NAME DOESNT CHANGE",
                Age = 12,
                Color = "THIS COLOR DOESNT CHANGE"
            }


        };
        */
        [HttpGet(Name = "GetAnimal")]
        public  IActionResult GetAnimal()    
        {
            // TODO if list empty return something
            if (!Animals.Any()) {
                return new ObjectResult("No animals were found");

            } else
            {
                return new ObjectResult(Animals);
            }

        }
        [HttpDelete(Name = "DeleteAnimal")]
        
        public IActionResult DeleteAnimal(Guid Id)
        {
            try {
                if (!Animals.Any())
                {
                    return new ObjectResult(StatusCode(400,"Nothing to delete"));
                }
                // if it doesnt match add a return that says so
                Animals.RemoveAll((Animal item) => item.Id == Id);
                return new ObjectResult(Animals);
                }
            catch (Exception ex) {
                return StatusCode(500, ex);
            }
;

        }
        [HttpPost(Name = "CreateAnimal")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        // todo HttpResponseMessage
        public ActionResult<Animal> CreateAnimal(string name, string color, int age)
        {
            Animal createdAnimal = new Animal { Name = name, Color = color , Age = age, Id = Guid.NewGuid() };
            Animals.Add(createdAnimal);
            return CreatedAtAction("CreateAnimal", createdAnimal); 
            //return Ok();
            
        }
        [HttpPut(Name = "PutAnimal")]
        public ActionResult<Animal> PutAnimal(Animal animal, string name, string color, int age, Guid Id)
        {
            try
            {   //currently just adds, fix to update if animal matches a key
                if (Animals.Any())
                {
                    animal.Name = name;
                    animal.Color = color;
                    animal.Age = age;
                    return Ok();

                }
                else
                {
                    return new ObjectResult(StatusCode(400));
                }
            }
            catch (Exception ex)
            { return StatusCode(500, ex);
            }
        }
        
     }
}

