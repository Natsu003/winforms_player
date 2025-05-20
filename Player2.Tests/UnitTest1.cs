using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Player2;

namespace Player2.Tests
{
    [TestFixture]
    public class PlaylistTests
    {
        [Test]
        public void AddTrack_TrackAppearsInPlaylist()
        {
            var pl = new Playlist { Name = "Test" };
            string trackPath = @"C:\music\test.mp3";

            pl.Tracks.Add(trackPath);

            Assert.That(pl.Tracks, Contains.Item(trackPath));
        }

        [Test]
        public void RemoveTrack_TrackRemovedFromPlaylist()
        {
            var pl = new Playlist { Name = "Test" };
            string trackPath = @"C:\music\test.mp3";
            pl.Tracks.Add(trackPath);

            pl.Tracks.Remove(trackPath);

            Assert.That(pl.Tracks, Does.Not.Contain(trackPath));
        }

        [Test]
        public void Playlist_SerializationDeserialization_WorksCorrectly()
        {
            var pl = new Playlist
            {
                Name = "Playlist1",
                Tracks = new List<string> { "track1.mp3", "track2.mp3" }
            };

            string json = JsonConvert.SerializeObject(pl);
            var deserialized = JsonConvert.DeserializeObject<Playlist>(json);

            Assert.That(deserialized.Name, Is.EqualTo(pl.Name));
            Assert.That(deserialized.Tracks.Count, Is.EqualTo(pl.Tracks.Count));
            Assert.That(deserialized.Tracks, Is.EquivalentTo(pl.Tracks));
        }
    }

    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void AddTrackToLibrary_TrackExists()
        {
            var library = new List<string>();
            string track = "track.mp3";
            library.Add(track);

            Assert.That(library, Contains.Item(track));
        }

        [Test]
        public void SaveAndLoadLibraryJson_LibraryRestored()
        {
            var library = new List<string> { "track1.mp3", "track2.mp3" };
            string tempFile = Path.GetTempFileName();

            File.WriteAllText(tempFile, JsonConvert.SerializeObject(library));
            var restored = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(tempFile));

            Assert.That(restored, Is.EquivalentTo(library));

            File.Delete(tempFile);
        }
    }

    [TestFixture]
    public class TrackItemTests
    {
        [Test]
        public void ToString_ReturnsFileName()
        {
            string path = @"C:\folder\music.mp3";
            var track = new TrackItem { FilePath = path };

            Assert.That(track.ToString(), Is.EqualTo("music.mp3"));
        }

        [Test]
        public void Equals_ReturnsTrueForSameFilePath()
        {
            string path = @"C:\folder\music.mp3";
            var t1 = new TrackItem { FilePath = path };
            var t2 = new TrackItem { FilePath = path };

            Assert.That(t1.Equals(t2), Is.True);
            Assert.That(t1.GetHashCode(), Is.EqualTo(t2.GetHashCode()));
        }
    }
}