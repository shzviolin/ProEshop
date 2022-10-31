using ProEshop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEshop.Services.Services;

public class HttpClientService: IHttpClientService
{
	private readonly HttpClient _httpClient;

	public HttpClientService()
	{
		_httpClient = new HttpClient();
	}

	public async Task<HttpResponseMessage> SendAsync(
		string url,
		HttpMethod method,
		Dictionary<string, string> headers = null,
		string content = "",
		string mediaType = "application/json")
	{
		var request = new HttpRequestMessage
		{
			Method = method,
			RequestUri = new Uri(url),
			Content = new StringContent(content, Encoding.UTF8, mediaType),
		};
		if (headers != null)
			foreach (var header in headers)
				request.Headers.Add(header.Key, header.Value);
		return await _httpClient.SendAsync(request);
	}
}
