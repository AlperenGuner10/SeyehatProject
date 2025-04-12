using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class SmallFeatureManager : ISmallFeatureService
	{
		ISmallFeautreDal _smallFeautreDal;

		public SmallFeatureManager(ISmallFeautreDal smallFeautreDal)
		{
			_smallFeautreDal = smallFeautreDal;
		}
		public List<SmallFeature> GetAll()
		{
			throw new NotImplementedException();
		}

		public void TAdd(SmallFeature t)
		{
			throw new NotImplementedException();
		}

		public SmallFeature TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TRemove(SmallFeature t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(SmallFeature t)
		{
			throw new NotImplementedException();
		}
	}
}
