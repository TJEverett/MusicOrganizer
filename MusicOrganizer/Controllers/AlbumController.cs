using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System;
using System.Collections.Generic;


namespace MusicOrganizer.Controllers
{
  public class AlbumController : Controller
  {
    [HttpGet("/album")]
    public ActionResult Index()
    {
      List<Album> albumList = Album.GetAll();
      return View(albumList);
    }

    [HttpGet("/album/new")]
    public ActionResult New()
    {
      List<Artist> artistList = Artist.GetAll();
      return View(artistList);
    }

    [HttpPost("/album")]
    public ActionResult Create(string title, string genre, int songs, int artist)
    {
      if(!String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(genre) && songs != 0 && artist != 0)
      {
        Album newAlbum = new Album(title, genre, songs, artist);
        Artist foundArtist = Artist.FindById(artist);
        foundArtist.AddAlbum(newAlbum);
      }
      return RedirectToAction("Index");
    }

    [HttpGet("/artist/{artistId}/album/{albumId}")]
    public ActionResult Show(int artistId, int albumId)
    {
      Album album = Album.FindById(albumId);
      Artist artist = Artist.FindById(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("album", album);
      model.Add("artist", artist);
      return View(model);
    }
  }
}