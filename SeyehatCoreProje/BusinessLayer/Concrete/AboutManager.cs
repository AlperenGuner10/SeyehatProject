﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AboutManager : IAboutService
	{
		IAboutDal _aboutDal;//Dependicy Injection
		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}
		public List<About> GetAll()
		{
			return _aboutDal.GetList();
		}

		public void TAdd(About t)
		{
			_aboutDal.Add(t);
		}

		public About TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TRemove(About t)
		{
			_aboutDal.Delete(t);
		}

		public void TUpdate(About t)
		{
			_aboutDal.Update(t);
		}
	}
}
