using CommentProject.BusinessLayer.Abstract;
using CommentProject.DataAccessLayer.Abstract;
using CommentProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.BusinessLayer.Concrete
{
    public class TitleManager : ITitleService
    {

        ITitleDal _titleDal;

        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        public void Add(Title entity)
        {
            _titleDal.Add(entity);
        }

        public void Update(Title entity)
        {
            _titleDal.Update(entity);
        }

        public void Delete(Title entity)
        {
            _titleDal.Delete(entity);
        }

        public Title GetById(int id)
        {
            return _titleDal.GetById(id);
        }

        public List<Title> GetList()
        {
            return _titleDal.GetList();
        }

        public List<Title> GetListByFilter(Expression<Func<Title, bool>> filter)
        {
            return _titleDal.GetListByFilter(filter);
        }
    }
}
