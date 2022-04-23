using Flurl.Http;

namespace Web.Client.Ui.Services
{
    public record User(Guid Id, string Name, string Email, string Username);

    public class UserService
    {
        private readonly IConfiguration _config;

        public string ApiHost { get; private set; }

        public UserService(IConfiguration config)
        {
            _config = config;
            ApiHost = _config["UserApiConfig:Host"];
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var request = new FlurlRequest($"http://{ApiHost}/api/user/getUsers");
            var response = await request.GetJsonAsync<IEnumerable<User>>();
            return response;
        }

        public async Task<User> GetUser(Guid id)
        {
            var request = new FlurlRequest($"http://{ApiHost}/api/user/getUser/{id}");
            var response = await request.GetJsonAsync<User>();
            return response;
        }
    }
}
