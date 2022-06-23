using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowIMetYourMother
{
    public class EpisodeData
    {
        public static void SaveEpisodes(List<Episode> episodes)
        {
            if (episodes != null)
            {
                using (var db = new EpisodeContext())
                {
                    foreach(Episode episode in episodes)
                    {
                        db.Add(episode);
                    }
                    db.SaveChanges();
                }
            }
        }

        public static List<Episode> DownloadEpisodes()
        {
            List<Episode> episodes = null;
            using (var db = new EpisodeContext())
            {
                episodes = db.Episodes.ToList();
            }
            return episodes;
        }

        public static List<Episode> FirstsEpisodes()
        {
            List<Episode> episodes = null;
            using(var db = new EpisodeContext())
            {
                episodes = db.Episodes.Where(w => w.EpisodeNrInSeason == 1).ToList();
            }
            return episodes;
        }

        public static List<Episode> TedInTitle()
        {
            List<Episode> episodes = null;
            using(var db = new EpisodeContext())
            {
                episodes = db.Episodes.Where(w => w.Title.Contains("Ted")).ToList();
            }
            return episodes;
        }

        public static TimeSpan HowLong()
        {
            Episode firstEpisode = null;
            Episode lastEpisode = null;
            using (var db = new EpisodeContext())
            {
                firstEpisode = db.Episodes.Where(w => w.EpisodeNrOverall == 1).ToList().First();
                lastEpisode = db.Episodes.Where(w => w.EpisodeNrOverall == 208).ToList().First();
            }
            TimeSpan howLong = (lastEpisode.Date - firstEpisode.Date);
            return howLong;
        }

        public static List<Episode> FrymanAndLloyd()
        {
            List<Episode> episodes = null;
            using (var db = new EpisodeContext())
            {
                episodes = db.Episodes.Where(w => w.DirectedBy == "Pamela Fryman" && w.WrittenBy == "Stephen Lloyd").OrderBy(o => o.Title).ToList();
            }
            return episodes;
        }


    }
}
