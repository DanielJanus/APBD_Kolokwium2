using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S18782_Daniel_Janus_Kolos2.Service;

namespace S18782_Daniel_Janus_Kolos2.Controllers
{
    [Route("api/music-labels")]
    [ApiController]
    public class MusicLabelController : ControllerBase
    {
        private readonly IMusicLabelService _service;

        public MusicLabelController(IMusicLabelService service)
        {
            _service = service;
        }

        [HttpGet("{musicId}")]
        public IActionResult GetMusicLabel(int musicId)
        {
            var result = _service.GetMusicList(musicId);
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}