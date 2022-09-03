using JenkinsBuildStats.API.DTO;
using OneOf;
using System.Net;
using System.Text;
using System.Text.Json;

namespace JenkinsBuildStats.WebUI.ApiClient
{
    public abstract class BaseApiClient
    {
        protected readonly HttpClient _client;

        protected readonly JsonSerializerOptions _serializationOptions =
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

        protected BaseApiClient(HttpClient client)
        {
            _client = client;
        }

        protected async Task<OneOf<T, NotFoundDTO, InternalServerErrorDTO, UnexpectedResponse>> GetAsync<T>(string uri)
        {
            try
            {
                var response = await _client.GetAsync(uri);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return DeserializeResponse<T>(content);
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return DeserializeResponse<NotFoundDTO>(content);
                }

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return DeserializeResponse<InternalServerErrorDTO>(content);
                }

                return new UnexpectedResponse($"Unexpected response: {response.StatusCode}, '{content}'");
            }
            catch (Exception ex)
            {
                return new UnexpectedResponse($"Unexpected error: {ex}");
            }
        }

        protected async Task<OneOf<OkResponse, NotFoundDTO, BadRequestDTO, InternalServerErrorDTO, UnexpectedResponse>> PutAsync(string uri, object requestData)
        {
            try
            {           
                var contenxt = new StringContent(SerializeRequestBody(requestData),
                    Encoding.UTF8,
                    "application/json");

                var response = await _client.PutAsync(uri, contenxt);

                if (response.IsSuccessStatusCode)
                {
                    return new OkResponse();
                }

                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return DeserializeResponse<NotFoundDTO>(content);
                }

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return DeserializeResponse<BadRequestDTO>(content);
                }

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return DeserializeResponse<InternalServerErrorDTO>(content);
                }

                return new UnexpectedResponse($"Unexpected response: {response.StatusCode}, '{content}'");

            }
            catch (Exception ex)
            {
                return new UnexpectedResponse($"Unexpected error: {ex}");
            }
        }

        private T DeserializeResponse<T>(string responseContent)
        {
            return JsonSerializer
                        .Deserialize<T>(responseContent,
                            _serializationOptions);
        }

        private string SerializeRequestBody<T>(T requestData)
        {
            return JsonSerializer
                        .Serialize(requestData,
                            _serializationOptions);
        }
    }
}
