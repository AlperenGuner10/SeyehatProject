using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService : IGenericService<Comment>
	{
		List<Comment> TGetDestinationById(int id);//Yorumu sayfada id ile eşleştirdik
		List<Comment> TGetListCommentWithDestination();
		public List<Comment> TGetListCommentWithDestinationAndUser(int id);
	}
}
