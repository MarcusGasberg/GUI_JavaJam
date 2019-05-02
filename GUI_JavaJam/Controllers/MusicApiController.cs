using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUI_JavaJam.Data;
using GUI_JavaJam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GUI_JavaJam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicApiController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MusicApiController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetMusicians")]
        [ProducesResponseType(200,Type = typeof(List<MusicianModel>))]
        [ProducesResponseType(404)]
        public ActionResult<List<MusicianModel>> GetMusicians()
        {
            var musicians = _dbContext.MusicianModels.ToList();
            if (musicians.Any() == false)
            {
                return NotFound();
            }
            return musicians;
        }

        [HttpGet("GetMusicians/{date}")]
        [ProducesResponseType(200, Type = typeof(List<MusicianModel>))]
        [ProducesResponseType(404)]
        public ActionResult<List<MusicianModel>> GetMusicians(DateTime date)
        {
            var musicians = _dbContext.MusicianModels.Where(m => m.TimeOfPerformance.Date == date.Date).ToList();
            if (musicians.Any() == false)
            {
                return NotFound();
            }
            return musicians;
        }



        [HttpGet("GetMusician")]
        [ProducesResponseType(200, Type = typeof(MusicianModel))]
        [ProducesResponseType(404)]
        public ActionResult<MusicianModel> GetMusician(int? id)
        {
            var musician = _dbContext.MusicianModels.Find(id);
            if (musician == null)
            {
                return NotFound();
            }
            return musician;
        }
    }
}