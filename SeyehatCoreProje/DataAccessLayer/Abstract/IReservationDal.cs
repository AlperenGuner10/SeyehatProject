﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IReservationDal : IGenericDal<Reservation>
	{
		List<Reservation> GetListWithReservationByAccepted(int id);
		List<Reservation> GetListWithReservationByPast(int id);
		List<Reservation> GetListWithReservationByWaitApproval(int id);
	}
}
