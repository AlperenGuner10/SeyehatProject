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
	public class CommentManager : ICommentService
	{
		ICommentDal _commentDal;
		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}
		public List<Comment> GetAll()
		{
			return _commentDal.GetList();
		}

		public void TAdd(Comment t)
		{
			 _commentDal.Add(t);
		}

		public Comment TGetById(int id)
		{
			return _commentDal.GetById(id);
		}
		public List<Comment> TGetDestinationById(int id)
		{
			return _commentDal.GetListByFilter(x=>x.DestinationId == id);//yorumları açıklama id'ye göre ayarladık. sadece icommentservice'ye ekledik.
		}

		public List<Comment> TGetListCommentWithDestination()
		{
			return _commentDal.GetListCommentWithDestination();
		}

		public List<Comment> TGetListCommentWithDestinationAndUser(int id)
		{
			return _commentDal.GetListCommentWithDestinationAndUser(id);
		}

		public void TRemove(Comment t)
		{
			_commentDal.Delete(t);
		}

		public void TUpdate(Comment t)
		{
			_commentDal.Update(t);
		}
	}
}
