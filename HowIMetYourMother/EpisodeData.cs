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

    }
}
