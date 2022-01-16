using System;
using System.Linq;
using System.Collections.Generic;

namespace bScoredDatabase.Models
{
	public class Settings
	{
		public string Host { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string DestinationPath { get; set; }
		public string DefaultClub { get; set; }
		public string PassingFile { get; set; }
		public string LogoFile { get; set; }
		public string ReportLink { get; set; }
		public string TCPAddress { get; set; }
		public int TCPPort { get; set; }

		public bool AreValid()
		{
			if (String.IsNullOrWhiteSpace(PassingFile)) return false;
			if (String.IsNullOrWhiteSpace(TCPAddress)) return false;
			if (TCPPort <= 0) return false;
			return true;
		}


	}
}
