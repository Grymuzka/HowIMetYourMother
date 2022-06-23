using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace HowIMetYourMother
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************** JAK POZNAŁEM WASZĄ MATKĘ ******************\n");

            List<Episode> episodesInfo = new List<Episode>();

            // -------------------- Wywołanie funkcji pobierającej dane --------------------

            //GetEpisodes(@"Files\himym_episodes.csv", episodesInfo);

            // -------------------- Wywołanie funkcji zapisującej dane w bazie --------------------

            //EpisodeData.SaveEpisodes(episodesInfo);
            Console.WriteLine("Dane zostały pomyślnie zapisane w bazie danych");

            // -------------------- Wywołanie funkcji zapisującej dane w bazie --------------------

            List<Episode> episodesAll = EpisodeData.DownloadEpisodes();
            Console.WriteLine("...\nDane zostały pomyślnie pobrane z bazy danych");
            Console.WriteLine($"Na liście znalazło się {episodesAll.Count} odcinków\n");

            // -------------------- LINQ --------------------

            Console.WriteLine("********* Tytuły pierwszych odcinków sezonów *******\n");
            foreach(Episode episode in EpisodeData.FirstsEpisodes())
            {
                Console.WriteLine(episode.Title);
            }

            Console.WriteLine("\n********* Odcinki zawierające w tytule imię głównego bohatera *******\n");
            foreach(Episode episode in EpisodeData.TedInTitle())
            {
                Console.WriteLine(episode.Title);
            }

            Console.WriteLine($"\n********* Emisja \"Jak poznałem waszą matkę\" trwała {EpisodeData.HowLong().Days} dni *******\n");

            Console.WriteLine("*****Odcinki napisane przez Pamela Fryman oraz wyreżyserowane przez Stephen Lloyd***\n");
            foreach(Episode episode in EpisodeData.FrymanAndLloyd())
            {
                Console.WriteLine(episode.Title);
            }

            Console.ReadKey();
        }

        // -------------------- Funkcja pobierająca dane z pliku csv --------------------

        /*
        public static List<Episode> GetEpisodes(string file, List<Episode> episodes)
        {
            List<Episode> episodesList = null;
            if (File.Exists(file))
            {
                using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<HimymMap>();
                    episodesList = csv.GetRecords<Episode>().ToList();
                    if (episodes != null)
                        episodes.AddRange(episodesList);
                }
            }
            return episodesList;
        }
        */
    }
}