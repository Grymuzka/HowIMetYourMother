using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace HowIMetYourMother
{
    [Table("EpisodesDetails")]
    public class Episode : IEpisode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Season")]
        public int SeasonNr { get; set; }
        [Column("EpisodeNumInSeason")]
        public int EpisodeNrInSeason { get; set; }
        [Column("EpisodeNumOverall")]
        public int EpisodeNrOverall { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        [Column("DirectedBy")]
        public string DirectedBy { get; set; }
        [Column("WrittenBy")]
        public string WrittenBy { get; set; }
        [Column("OriginalAirDate")]
        public DateTime Date { get; set; }
        [Column("ProductionCode")]
        public string ProductionCode { get; set; }
    }

    public class HimymMap : ClassMap<Episode>
    {
        public HimymMap()
        {
            Map(m => m.SeasonNr).Name("season");
            Map(m => m.EpisodeNrInSeason).Name("episode_num_in_season");
            Map(m => m.EpisodeNrOverall).Name("episode_num_overall");
            Map(m => m.Title).Name("title");
            Map(m => m.DirectedBy).Name("directed_by");
            Map(m => m.WrittenBy).Name("written_by");
            Map(m => m.Date).Name("original_air_date").TypeConverterOption.Format("yyyy-MM-dd");
            Map(m => m.ProductionCode).Name("prod_code");
        }
    }
}