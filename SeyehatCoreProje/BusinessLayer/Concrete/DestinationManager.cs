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
	public class DestinationManager : IDestinationService
	{
		IDestinationDal _destinationDal;

		public DestinationManager(IDestinationDal destinationDal)
		{
			_destinationDal = destinationDal;
		}
		public List<Destination> GetAll()
		{
			return _destinationDal.GetList();
		}

		public void TAdd(Destination t)
		{
			 _destinationDal.Add(t);
		}

		public Destination TGetById(int id)
		{
			return _destinationDal.GetById(id);
		}

		public Destination TGetDestinationWithGuide(int id)
		{
			return _destinationDal.GetDestinationWithGuide(id);
		}

		public List<Destination> TGetLastFourDestinations()
		{
			return _destinationDal.GetLastFourDestinations();
		}

		public void TRemove(Destination t)
		{
			_destinationDal.Delete(t);
		}

		public void TUpdate(Destination t)
		{
			_destinationDal.Update(t);
		}
	}
}
