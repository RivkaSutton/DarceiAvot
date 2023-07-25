using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IService
{
    public interface IHistoryService
    {
      public Task<List<History>> GetHistoryForStudent(string studentId);
    }
}