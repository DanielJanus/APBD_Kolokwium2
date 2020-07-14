using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S18782_Daniel_Janus_Kolos2.Service;

namespace S18782_Daniel_Janus_Kolos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicLabelService _service;

        public MusicianController(IMusicLabelService service)
        {
            _service = service;
        }

        [HttpDelete("{idmusic}")]
        public IActionResult DeleteMusician(int idmusic)
        {
            var result = _service.DeleteMusician(idmusic);

            if(result == null)
                return BadRequest("Muzyk o podanym ID nie istnieje lub wystąpił nieoczekiwany błąd");
            else
                return Ok(result);
        }
    }
}