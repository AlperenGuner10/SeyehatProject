using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		Context cnt = new Context();
		public void Delete(T t)
		{
			cnt.Remove(t);
			cnt.SaveChanges();
		}

		public List<T> GetList()
		{
			return cnt.Set<T>().ToList();
		}

		public void Add(T t)
		{
			cnt.Add(t);
			cnt.SaveChanges();
		}

		public void Update(T t)
		{
			cnt.Update(t);
			cnt.SaveChanges();
		}

		public T GetById(int id)
		{
			return cnt.Set<T>().Find(id);
		}

		public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
		{
			return cnt.Set<T>().Where(filter).ToList();//Arama işleminde kullanıyoruz
		}
	}
}
