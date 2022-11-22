using WMS_Inventory_API_Client.Helpers;
using WMS_Inventory_API_Client.Models;
using WMS_Inventory_API_Client.Services.Interfaces;
namespace WMS_Inventory_API_Client.Services
{
    public class ContentService : IContentService
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/content/";
        public ContentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<Content>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);
            var response = await responseGet.ReadContentAsync<List<Content>>();
            return response;
        }
        public async Task<Content> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);
            var response = await responseGet.ReadContentAsync<Content>();
            var content = new Content(response.Id, response.Quantity, response.Description, response.ContainerId);
            return content;
        }
    }
}