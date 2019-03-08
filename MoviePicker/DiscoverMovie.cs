using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using MoviePicker.Models.API;
using MoviePicker.Models.IndexModels;

namespace MoviePicker
{
    public static class DiscoverSearch
    {

        private const string url = "https://api.themoviedb.org/3/discover/movie";
        private const string apiKey = "c0c0e1329a987381aee73758cc0c96ba";

        public static string actorId;

        public static List<RootObject> Search(IndexModel parameterValues)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (parameterValues.actor != null)
            {
                parameters.Add("query", parameterValues.actor);

                List<RootObject> actorResponse = ApiHelper.DiscoverActor(parameters);

                actorId = Convert.ToString(actorResponse[0].Results[0].id);

                parameters.Clear();
                parameters.Add("with_cast", actorId);
            }

            parameters.Add("primary_release_year", parameterValues.year);
            parameters.Add("with_genres", parameterValues.genre);
            parameters.Add("sort_by", parameterValues.sort_by);
            parameters.Add("page", parameterValues.page);

            List<RootObject> response;

            if (parameterValues.type == "movie")
            {
                return response = ApiHelper.DiscoverMovie(parameters);
            }
            else
            {
                return response = ApiHelper.DiscoverTv(parameters);
            }
        }
    }
}
