using S18782_Daniel_Janus_Kolos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S18782_Daniel_Janus_Kolos2.Service
{
    public interface IMusicLabelService
    {
        public IList<GetMusicList> GetMusicList(int musicId);

        public Musican DeleteMusician(int musicianId);
    }
}
