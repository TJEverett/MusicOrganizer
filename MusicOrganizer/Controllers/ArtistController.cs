using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class ArtistController : Controller
  {
    [HttpGet("/artist")]
    public ActionResult Index()
    {
      List<Artist> artistList = Artist.GetAll();
      return View(artistList);
    }

    [HttpGet("/artist/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artist")]
    public ActionResult Create(string name)
    {
      if(!(String.IsNullOrEmpty(name)))
      {
        Artist newArtist = new Artist(name);
      }
      return RedirectToAction("Index");
    }

    [HttpGet("/artist/{id}")]
    public ActionResult Show(int id)
    {
      Artist foundArtist = Artist.FindById(id);
      return View(foundArtist);
    }
  }
}