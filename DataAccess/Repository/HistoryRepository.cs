using BusinessLogic.IRepository;
using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BusinessLogic.Repository
{ 
        public class HistoryRepository: IHistoryRepository
    {   
        DarceiAvotContext _dbContext;
            public HistoryRepository(DarceiAvotContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<History>> GetHistoryForStudent(string studentId)
        {
            try
            {
                  List<History> history= await _dbContext.Histories.Include(s => s.Status).Where(s=>s.StudentId.Equals(studentId)).ToListAsync();

               // List<History> history = await _dbContext.Histories.Include(s => s.StatusId).Where(s => s.StudentId == studentId).ToListAsync();
                return history;
            }



            catch (Exception ex)
            {
                throw new Exception("Error in Get History For Student" + ex.Message);
            }
        }

        //public async Task<List<History>> GetHistoryForStudent(int studentId)
        //{
        //    try
        //    {
        //        List<History> history = await _dbContext.Histories.Where(s => s.StudentId == studentId).ToListAsync();
        //        return history;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error in Get History For Student" + ex.Message);
        //    }
        //}

    }
}

          