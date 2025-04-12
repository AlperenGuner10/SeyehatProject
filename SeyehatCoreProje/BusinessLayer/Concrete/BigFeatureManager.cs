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
	public class BigFeatureManager : IBigFeatureService
	{
		IBigFeatureDal _bigFeatureDal;

		public BigFeatureManager(IBigFeatureDal bigFeatureDal)
		{
			_bigFeatureDal = bigFeatureDal;	
		}

		public List<BigFeature> GetAll()
		{
			return _bigFeatureDal.GetList();
		}

		public void TAdd(BigFeature t)
		{
			throw new NotImplementedException();
		}

		public BigFeature TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TRemove(BigFeature t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(BigFeature t)
		{
			throw new NotImplementedException();
		}
	}
}
