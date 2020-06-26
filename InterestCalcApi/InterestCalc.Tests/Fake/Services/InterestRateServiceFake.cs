using InterestCalc.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalc.Tests.Fake.Services
{
	public class InterestRateServiceFake : IInterestRateService
	{
		public async Task<float> GetInterestRateAsync()
		{
			return 0.01F;
		}
	}
}
