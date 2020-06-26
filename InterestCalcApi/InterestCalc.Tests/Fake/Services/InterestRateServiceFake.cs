using InterestCalc.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalc.Tests.Fake.Services
{
	public class InterestRateServiceFake : IInterestRateService
	{
		public float GetInterestRate()
		{
			return 0.01F;
		}
	}
}
