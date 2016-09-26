using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Util
{
	public static class StaticRefUtil
	{
		// https://andersmalmgren.com/2014/08/20/implicit-dependencies-and-copy-local-fails-to-copy/
		public static void EnsureStaticReference<T>()
		{
			var dummy = typeof(T);
			if (dummy == null)
				throw new Exception("This code is used to ensure that the compiler will include assembly");
		}
	}
}
