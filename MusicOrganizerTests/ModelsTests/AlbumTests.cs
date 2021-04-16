using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MusicOrganizer.Models;

namespace MusicOrganizerTests
{
  [TestClass]
  public class AlbumTests : IDisposable
  {
    public void Dispose()
    {
      Album.ClearAll();
    }

    [TestMethod]
    public void AlbumConstructor_CreateAlbumInstance_Album()
    {
      Album newAlbum = new Album("name", "genre", 5, 0);
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }
  
    [TestMethod]
    public void AlbumProperties_ReturnsProperties_True()
    {
      Album newAlbum = new Album("name", "genre", 5, 0);
      Assert.AreEqual("name", newAlbum.Title);
      Assert.AreEqual("genre", newAlbum.Genre);
      Assert.AreEqual(5, newAlbum.NumberSongs);
    }

    [TestMethod]
    public void AlbumProperties_SetProperties_True()
    {
      Album newAlbum = new Album("name", "genre", 5, 0);
      newAlbum.Title = "New Empire, Vol. 1";
      newAlbum.Genre = "Rock";
      newAlbum.NumberSongs = 9;
      Assert.AreEqual("New Empire, Vol. 1", newAlbum.Title);
      Assert.AreEqual("Rock", newAlbum.Genre);
      Assert.AreEqual(9, newAlbum.NumberSongs);
    }

    [TestMethod]
    public void GetAll_ReturnEmptyList_List()
    {
      List<Album> emptyList = new List<Album>();
      List<Album> albumList = Album.GetAll();
      CollectionAssert.AreEqual(emptyList, albumList);
    }

    [TestMethod]
    public void GetAll_ReturnList_List()
    {
      Album newAlbum = new Album("name", "genre" , 5, 0);
      Album newerAlbum = new Album("New Empire, Vol. 1", "Rock", 9, 0);
      List<Album> newList = new List<Album>() { newAlbum, newerAlbum };
      List<Album> albumList = Album.GetAll();
      CollectionAssert.AreEqual(newList, albumList);
    }

    [TestMethod]
    public void FindById_ReturnRightAlbum_Album()
    {
      Album newAlbum = new Album("name", "genre", 5, 0);
      Album newerAlbum = new Album("New Empire, Vol. 1", "Rock", 9, 0);
      Album foundAlbum = Album.FindById(2);
      Assert.AreEqual(newerAlbum, foundAlbum);
    }
  }
}