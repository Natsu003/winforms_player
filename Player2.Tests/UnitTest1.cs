using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using Player2;

namespace Player2.Tests
{
    //Playlist
    [TestFixture]
    public class PlaylistTests
    {
        [Test]
        public void AddTrack_TrackAppearsInPlaylist()
        {
            var pl = new Playlist { Name = "Test" };
            string track = @"C:\music\test.mp3";

            pl.Tracks.Add(track);

            Assert.That(pl.Tracks, Contains.Item(track));
        }

        [Test]
        public void RemoveTrack_TrackDisappearsFromPlaylist()
        {
            var pl = new Playlist { Name = "Test" };
            string track = @"C:\music\test.mp3";
            pl.Tracks.Add(track);

            pl.Tracks.Remove(track);

            Assert.That(pl.Tracks, Does.Not.Contain(track));
        }

        [Test]
        public void Serialization_RoundTrip_PreservesAllData()
        {
            var original = new Playlist
            {
                Name = "MyPlaylist",
                Tracks = new List<string> { "a.mp3", "b.mp3" }
            };

            string json = JsonConvert.SerializeObject(original);
            var copy = JsonConvert.DeserializeObject<Playlist>(json);

            // Дивимось, що десеріалізація не повернула null
            Assert.That(copy, Is.Not.Null, "Deserialised playlist is null");

            Assert.Multiple(() =>
            {
                Assert.That(copy.Name, Is.EqualTo(original.Name));
                Assert.That(copy.Tracks.Count, Is.EqualTo(original.Tracks.Count));
                Assert.That(copy.Tracks, Is.EquivalentTo(original.Tracks));
            });
        }
    }

    //Library
    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void AddTrack_TrackExistsInCollection()
        {
            var library = new List<string>();
            string track = "song.mp3";

            library.Add(track);

            Assert.That(library, Contains.Item(track));
        }

        [Test]
        public void SaveAndLoadJson_RestoresTheSameList()
        {
            var library = new List<string> { "one.mp3", "two.mp3" };
            string tmp = Path.GetTempFileName();

            // зберегти
            File.WriteAllText(tmp, JsonConvert.SerializeObject(library));

            // завантажити
            var loaded = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(tmp));

            Assert.That(loaded, Is.EquivalentTo(library));

            File.Delete(tmp);
        }
    }

    //TrackItem
    [TestFixture]
    public class TrackItemTests
    {
        [Test]
        public void ToString_ReturnsFileNameOnly()
        {
            string fullPath = @"C:\music\track.mp3";
            var item = new TrackItem { FilePath = fullPath };

            Assert.That(item.ToString(), Is.EqualTo("track.mp3"));
        }

        [Test]
        public void TwoInstancesWithSamePath_HaveEqualFilePath()
        {
            string path = @"C:\music\track.mp3";
            var first = new TrackItem { FilePath = path };
            var second = new TrackItem { FilePath = path };

            Assert.That(first.FilePath, Is.EqualTo(second.FilePath));
        }
    }
}
