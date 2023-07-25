using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IRepository
{
    public interface IHistoryRepository
    {
       public  Task<List<History>> GetHistoryForStudent(string studentId);
    }
}
