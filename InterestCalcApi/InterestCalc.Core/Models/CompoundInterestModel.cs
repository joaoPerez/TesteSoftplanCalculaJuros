using System;
using System.Collections.Generic;
using System.Text;

namespace InterestCalc.Core.Models
{
	public class CompoundInterestModel
	{
		public decimal InitialValue { get; set; }
		public int TimePeriod { get; set; }
		public float Interest { get; set; }
	}
}
