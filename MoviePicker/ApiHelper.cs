using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using MoviePicker.Models.API;

namespace MoviePicker
{
    public class ApiHelper
    {
        private const string apiKey = "c0c0e1329a987381aee73758cc0c96ba";
        private const string BaseUrl = "https://api.themoviedb.org/3/";

        public static List<RootObject> DiscoverActor(Dictionary<string, string> parameters)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("search/person");

            return ApiRequest(client, request, parameters);
        }

        public static List<RootObject> DiscoverMovie(Dictionary<string, string> parameters)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("discover/movie");

            return ApiRequest(client, request, parameters);

        }

        public static List<RootObject> DiscoverTv(Dictionary<string, string> parameters)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("discover/tv");

            return ApiRequest(client, request, parameters);

        }

        private static List<RootObject> ApiRequest(RestClient client, RestRequest request, Dictionary<string, string> parameters)
        {
            request.AddParameter("api_key", apiKey);

            foreach (KeyValuePair<string, string> param in parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }

            IRestResponse<List<RootObject>> response = client.Execute<List<RootObject>>(request);

            return response.Data;
        }
    }
}
