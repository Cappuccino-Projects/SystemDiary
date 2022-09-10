using Models.Disciplines;
using Models.Users;
using RestSharp;

namespace ClientAPI
{
    public sealed class Client
    {
        #region Users

        public async Task<User> GetUserData(string publicId)
        {
            var client = new RestClient($"https://localhost:7253/api/UserData/Get/{publicId}");

            var request = new RestRequest();
            request.Method = Method.Get;
            request.RequestFormat = DataFormat.Json;

            return await client.GetAsync<User>(request);
        }

        public async Task<string> GetUserRole(string publicId)
        {
            var client = new RestClient($"https://localhost:7253/api/UserData/Get/UserRole/{publicId}/Name");

            var request = new RestRequest();
            request.Method = Method.Get;
            request.RequestFormat = DataFormat.Json;

            return await client.GetAsync<string>(request);
        }

        public async Task<List<User>> GetAllUsers() 
        {
            var client = new RestClient($"https://localhost:7253/api/UserData/Get/All");

            var request = new RestRequest();
            request.Method = Method.Get;
            request.RequestFormat = DataFormat.Json;

            return await client.PostAsync<List<User>>(request);
        }

        public async Task<string> GetUserState(string publicId) 
        {
            var client = new RestClient($"https://localhost:7253/api/UserData/Get/UserState/{publicId}/Name");

            var request = new RestRequest();
            request.Method = Method.Get;
            request.RequestFormat = DataFormat.Json;

            return await client.GetAsync<string>(request);
        }

        #endregion

        #region Disciplines

        public async Task<List<DisciplineModel>> GetAllDisciplines()
        {
            var client = new RestClient($"https://localhost:7253/api/Discipline/Get/All");

            var request = new RestRequest();
            request.Method = Method.Post;
            request.RequestFormat = DataFormat.Json;

            return await client.PostAsync<List<DisciplineModel>>(request);

        }

        #endregion
    }
}