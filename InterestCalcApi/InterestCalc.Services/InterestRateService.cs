using InterestCalc.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalc.Services
{
	public class InterestRateService : IInterestRateService
	{
		private readonly IConfiguration _configuration;
		private HttpClient client = new HttpClient();

		public InterestRateService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<float> GetInterestRateAsync()
		{
			string uri = _configuration.GetSection("InterestRateApi").Value;

			string value = await client.GetAsync(uri).Result.Content.ReadAsStringAsync();

			return float.Parse(value);
		}
	}
}
