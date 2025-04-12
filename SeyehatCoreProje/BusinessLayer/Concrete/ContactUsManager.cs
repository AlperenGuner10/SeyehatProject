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
	public class ContactUsManager : IContactUsService
	{
		IContactUsDal _getContactUs;

		public ContactUsManager(IContactUsDal getContactUs)
		{
			_getContactUs=getContactUs;
		}

		public List<ContactUs> GetAll()
		{
			return _getContactUs.GetList();
		}

		public void TAdd(ContactUs t)
		{
			_getContactUs.Add(t);
		}

		public void TContactUsStatusChangeToFalse(int id)
		{
			throw new NotImplementedException();
		}

		public ContactUs TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<ContactUs> TGetListContactUsByFalse()
		{
			return _getContactUs.GetListContactUsByFalse();
		}

		public List<ContactUs> TGetListContactUsByTrue()
		{
			return _getContactUs.GetListContactUsByTrue();
		}

		public void TRemove(ContactUs t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(ContactUs t)
		{
			throw new NotImplementedException();
		}
	}
}
