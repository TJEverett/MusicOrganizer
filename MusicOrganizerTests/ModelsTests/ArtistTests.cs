using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MusicOrganizer.Models;

namespace MusicOrganizerTests
{
  [TestClass]
  public class ArtistTests : IDisposable
  {
    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreateArtistInstance_Artist()
    {
      Artist newArtist = new Artist("name");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void ArtistProperties_ReturnsProperties_True()
    {
      Artist newArtist = new Artist("name");
      Assert.AreEqual("name", newArtist.Name);
    }

    [TestMethod]
    public void ArtistProperties_SetProperties_True()
    {
      Artist newArtist = new Artist("name");
      newArtist.Name = "Hollywood Undead";
      Assert.AreEqual("Hollywood Undead", newArtist.Name);
    }

    [TestMethod]
    public void GetAll_ReturnEmptyList_List()
    {
      List<Artist> emptyList = new List<Artist>();
      List<Artist> artistList = Artist.GetAll();
      CollectionAssert.AreEqual(emptyList, artistList);
    }

    [TestMethod]
    public void GetAll_ReturnList_List()
    {
      Artist newArtist = new Artist("name");
      Artist newerArtist = new Artist("Hollywood Undead");
      List<Artist> newList = new List<Artist>() { newArtist, newerArtist };
      List<Artist> artistList = Artist.GetAll();
      CollectionAssert.AreEqual(newList, artistList);
    }

    [TestMethod]
    public void FindById_ReturnRightArtist_Artist()
    {
      Artist newArtist = new Artist("name");
      Artist newerArtist = new Artist("Hollywood Undead");
      Artist foundArtist = Artist.FindById(2);
      Assert.AreEqual(newerArtist, foundArtist);
    }

    [TestMethod]
    public void AddAlbum_AddsAlbumToArtist_True()
    {
      Album newAlbum = new Album("New Empire, Vol. 1", "Rock", 9, 0);
      List<Album> newList = new List<Album>() { newAlbum };
      Artist newArtist = new Artist("Hollywood Undead");
      newArtist.AddAlbum(newAlbum);
      CollectionAssert.AreEqual(newList, newArtist.Albums);
    }
  }
}