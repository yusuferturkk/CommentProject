﻿using CommentProject.DataAccessLayer.Abstract;
using CommentProject.DataAccessLayer.Concrete;
using CommentProject.DataAccessLayer.Repositories;
using CommentProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentsByTitle(int id)
        {
            var context = new Context();
            return context.Comments.Where(x => x.TitleId == id).ToList();
        }

        public List<Comment> GetCommentsByTitleWithUser(int id)
        {
            var context = new Context();
            return context.Comments.Where(x => x.TitleId == id).Include(y => y.AppUser).Include(z => z.Title.Category).ToList();
        }

        public List<Comment> GetCommentsByUserWithTitle(int id)
        {
            var context = new Context();
            return context.Comments.Where(x => x.AppUserId == id).Include(y => y.Title).ToList();
        }
    }
}
