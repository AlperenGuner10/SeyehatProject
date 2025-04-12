using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfGuideDal : GenericRepository<Guide>, IGuideDal
	{
		Context cnt = new Context();

		public void ChangeToFalseByGuide(int id)
		{
			var values = cnt.Guides.Find(id);
			values.Status = false;
			cnt.Update(values);
			cnt.SaveChanges();
		}

		public void ChangeToTrueByGuide(int id)
		{
			var values = cnt.Guides.Find(id);
			values.Status = true;
			cnt.Update(values);
			cnt.SaveChanges();
		}
	}
}
