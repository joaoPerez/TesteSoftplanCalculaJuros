using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalc.Core.Models.Request
{
	public class CompoundInterestRequestModel
	{
		public decimal InitialValue { get; set; }
		public int Months { get; set; }
	}
}
