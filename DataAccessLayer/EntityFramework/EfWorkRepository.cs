﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWorkRepository : GenericRepository<Work>, IWorkDal
    {
        public List<Work> GetListWithUser(int id)
        {
            using (var c = new Context())
            {
                return c.Works.Where(x=>x.UserId == id ).Include(x => x.User).OrderBy(x=>x.WorkEndDate).ToList();
            }
        }
    }
}
