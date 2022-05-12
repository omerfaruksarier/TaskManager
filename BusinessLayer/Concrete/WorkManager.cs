using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    [Authorize]
    public class WorkManager : IWorkService
    {

        IWorkDal _workDal;

        public WorkManager(IWorkDal workDal)
        {
            _workDal = workDal;
        }

        public Work GetById(int id)
        {
            return _workDal.GetById(id);
        }

        public List<Work> GetWorkById(int id)
        {
            return _workDal.GetListAll(x => x.WorkId == id);
        }

        public List<Work> GetList()
        {
            return _workDal.GetListAll();
        }
        //public List<Work> GetWorkListWithUser()
        //{
        //    return _workDal.GetListWithUser();
        //}
        public List<Work> GetWorkListWithUser(int id)
        {
            return _workDal.GetListWithUser(id);
        }
        public void TAdd(Work t)
        {
            _workDal.Insert(t);
        }

        public void TDelete(Work t)
        {
            _workDal.Delete(t);
        }

        public void TUpdate(Work t)
        {
            _workDal.Update(t);
        }


    }
}
