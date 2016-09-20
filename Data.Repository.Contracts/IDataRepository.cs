﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Contracts
{
	public interface IDataRepository
	{
	}

	public interface IDataRepository<T> : IDataRepository
		where T : class, new()
	{

	}
}
