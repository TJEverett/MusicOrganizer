using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Album
  {
    public string Title { get; set; }
    public string Genre { get; set; }
    public int NumberSongs { get; set; }
    public int ArtistId { get; }
    public int Id { get; }
    private static List<Album> _instances = new List<Album>();

    public Album(string title, string genre, int songs, int artistId)
    {
      Title = title;
      Genre = genre;
      NumberSongs = songs;
      ArtistId = artistId;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Album> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Album FindById(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}