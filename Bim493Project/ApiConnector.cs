using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TMDbLib.Client;
using TMDbLib.Objects.Collections;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.People;
using TMDbLib.Objects.Search;

namespace Bim493Project
{
    public class ApiConnector
    {
        TMDbClient client = new TMDbClient("3f76c9878669bb515b1ab41812fb8fe1");
        string main_url_for_poster = "https://image.tmdb.org/t/p/original/";
        public ApiConnector()
        {
           
            //string bearerToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIzZjc2Yzk4Nzg2NjliYjUxNWIxYWI0MTgxMmZiOGZlMSIsInN1YiI6IjYxZTA2ODkyMTUxMWFhMDA5ZTQwYjBkMyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.e2baZ-FMyJ5H_QMEckyiYyDwBC73mjCn-cN5p5Nvs5I";
            //MovieDbFactory.RegisterSettings(bearerToken);

            //var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            //var peopleApi = MovieDbFactory.Create<IApiPeopleRequest>().Value;

            ////  ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync("Lord Of The Rings");
            //ApiSearchResponse<MovieInfo> response = await movieApi.GetPopularAsync(5, "en");
            //ApiSearchResponse<PersonInfo> personresponse = await peopleApi.SearchByNameAsync("Leonardo", 5);
            //foreach (MovieInfo info in response.Results)
            //{
            //    Console.WriteLine($"{info.Title} ({info.ReleaseDate}): {info.Overview}");
            //}


            //Movie movie = client.GetMovieAsync(47964).Result;
            //SearchContainer<SearchMovie> movies = client.SearchMovieAsync("Lord of the Rings").Result;
            // // SearchContainer<SearchPerson> movies2 = client.SearchPersonAsync("Leonardo DiCaprio").Result;
            //SearchContainer<SearchCollection> collectons = client.SearchCollectionAsync("Lord of the Rings").Result;
            //SearchContainer<SearchMovie> movies3= client.GetMovieRecommendationsAsync(1,1).Result;
            //Collection jamesBonds = client.GetCollectionAsync(collectons.Results.First().Id).Result;

            //Console.WriteLine($"Collection: {jamesBonds.Name}");
            //Console.WriteLine();
        }
        public List<SearchMovie> getlist(string name,string genre)
        {
            SearchContainer<SearchMovie> movies = client.SearchMovieAsync(name).Result;
            //SearchContainer<SearchPerson> persons = client.SearchPersonAsync("Kemal Sunal").Result;
            foreach (SearchMovie item in movies.Results)
            {
                item.PosterPath = main_url_for_poster + item.PosterPath;


            }
            return movies.Results;
            
        }
        public List<SearchMovie> getTrending() {
            SearchContainer<SearchMovie> movies = client.GetTrendingMoviesAsync(TMDbLib.Objects.Trending.TimeWindow.Week, 5).Result ;
            foreach (SearchMovie item in movies.Results)
            {
                item.PosterPath = main_url_for_poster + item.PosterPath;


            }
          
            return movies.Results;
        }

        public List<String> getGenres()
        {
            List<Genre> genreList = client.GetMovieGenresAsync().Result;
            List<String> genres = new List<string>();
            foreach(Genre item in genreList)
            {
                genres.Add(item.Name);
            }
          
            return genres;
        }
        public List<SearchPerson> getActorswithMovies(string name)
        {
            SearchContainer<SearchPerson> persons = client.SearchPersonAsync(name).Result;
            foreach (SearchPerson item in persons.Results)
            {
                foreach(KnownForBase index in item.KnownFor)
                {
                    index.PosterPath = main_url_for_poster + index.PosterPath;
                }

                ;


            }
            return persons.Results;
        }


    }
}
