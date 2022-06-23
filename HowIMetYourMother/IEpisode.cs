using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowIMetYourMother
{
    public interface IEpisode
    {
        int SeasonNr { get; set; }
        int EpisodeNrInSeason { get; set; }
        int EpisodeNrOverall { get; set; }
        string Title { get; set; }
        string DirectedBy { get; set; }
        string WrittenBy { get; set; }
        DateTime Date { get; set; }
        string ProductionCode { get; set; }

    }
}