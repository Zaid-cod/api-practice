using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_practice.Model;
using System.Linq;

namespace api_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
        new VideoGame
        {
            Id = 1,
            Title = "SpiderMan",
            Platform = "PS5",
            Developer = "Sony",
            Publisher = "Sony-Interactive"
        },
        new VideoGame
        {
            Id = 5,
            Title = "Batman",
            Platform = "PC",
            Developer = "DC",
            Publisher = "DC-Interactive"
        },
        new VideoGame
        {
            Id = 8,
            Title = "RDR",
            Platform = "PC",
            Developer = "Rockstart",
            Publisher = "Take-Two"
        },
        new VideoGame
        {
            Id = 11,
            Title = "Legend of Zelda",
            Platform = "Nintendo",
            Developer = "CD-Project",
            Publisher = "CD-Interactive"
        }


       };
        //kinda like query
        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }
        [HttpGet("{id}")]
        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            //linq and lambda goes to operator => and comparison 
            var game = videoGames.FirstOrDefault(g => g.Id == id);

            if (game == null)
            {
                return NotFound("Game not found.");
            }

            return Ok(game);
        }
    }
}
