using System;

namespace AppConfiguration
{
	public interface IAppConfig
	{
		DateTime MyDate { get; }
		string MySetting { get; }
		int MyValue { get; }
	}
}