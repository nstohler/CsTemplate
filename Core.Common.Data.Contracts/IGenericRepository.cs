using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Data.Contracts
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> All();
		IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties);
		void Delete(int id);
		IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
		IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
		TEntity FindByKey(int id);
		void Insert(TEntity entity);
		void Update(TEntity entity);
	}
}
