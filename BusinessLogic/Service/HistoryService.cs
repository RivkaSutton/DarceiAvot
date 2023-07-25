using BusinessLogic.IRepository;
using BusinessLogic.Repository;
using DataAccess.DBModels;
using DataAccess.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class HistoryService: IHistoryService
    {
        IHistoryRepository historyRepository;
        public HistoryService(IHistoryRepository historyRepository)
        {
            this.historyRepository = historyRepository;
        }
        public async Task<List<History>> GetHistoryForStudent(string studentId)
        {
            return await historyRepository.GetHistoryForStudent(studentId);
        }
    }
}
