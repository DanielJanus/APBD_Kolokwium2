using S18782_Daniel_Janus_Kolos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace S18782_Daniel_Janus_Kolos2.Service
{
    public class MusicLabelService : IMusicLabelService
    {
        MusicLabelContext _context = new MusicLabelContext();

        public Musican DeleteMusician(int musicianId)
        {

            var MusicianToDelete = _context.Musican.Find(musicianId);
            if (!_context.Musican.Where(Id => Id.IdMusican == musicianId).Any())
                throw new Exception($"Wytwórnia o id {musicianId} nie ma w bazie");


            var result = (from musicId in _context.Musican
                          join musicTrackId in _context.Musican_Track on musicId.IdMusican equals musicTrackId.IdMusician
                          join trackId in _context.Track on musicTrackId.IdTrack equals trackId.IdTrack
                          where musicId.IdMusican == musicianId
                          select trackId.IdMusicAlbum).Any();
            if (result)
                try
                {
                    var deleteto = _context.Musican_Track.Where(mt => mt.IdMusician == musicianId).ToList();

                    _context.Musican.Remove(MusicianToDelete);
                    _context.Musican_Track.RemoveRange(deleteto);
                    _context.SaveChanges();

                    return MusicianToDelete;
                }
                catch (Exception ex)
                {
                    return null;
                }
            else
                return null; 
        }

        public IList<GetMusicList> GetMusicList(int musicId)
        {
            if (!_context.MusicLabel.Where(label => label.IdMusicLabel == musicId).Any())
                throw new Exception($"Wytwórni o id {musicId} nie ma w bazie");

            var result = (from musicLabel in _context.MusicLabel
                          join album in _context.Album on musicLabel.IdMusicLabel equals album.IdMusicLabel
                          where musicLabel.IdMusicLabel == musicId
                          orderby album.PublishDate descending
                          select new GetMusicList
                          {
                            IdMusicLabel = musicLabel.IdMusicLabel,
                            Name = musicLabel.Name,
                            IdAlbum = album.IdAlbum,
                            AlbumName = album.AlbumName,
                            PublishDate = album.PublishDate
                          }).ToList();

            if(result == null)
            {
                return null;
            }

            try
            {
                return result;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
