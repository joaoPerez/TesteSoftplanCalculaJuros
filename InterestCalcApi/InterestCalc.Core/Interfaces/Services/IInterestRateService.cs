using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalc.Core.Interfaces.Services
{
	public interface IInterestRateService
	{
		Task<float> GetInterestRateAsync();
	}
}
