using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; set; }
    public List<Album> Albums { get; }
    public int Id { get; }
    private static List<Artist> _instances = new List<Artist>();

    public Artist(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _instances.Count;
      Albums = new List<Album>();
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Artist FindById(int searchId)
    {
      return _instances[searchId - 1];
    }

    public void AddAlbum(Album album)
    {
      Albums.Add(album);
    }
  }
}