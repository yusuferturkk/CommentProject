using CommentProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> GetCommentsByTitle(int id);
        List<Comment> GetCommentsByTitleWithUser(int id);
        List<Comment> GetCommentsByUserWithTitle(int id);
    }
}
