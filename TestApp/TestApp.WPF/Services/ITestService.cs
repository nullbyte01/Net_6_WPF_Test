using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Shared.Models;

namespace TestApp.WPF.Services
{
    public interface ITestService
    {
        Task<IEnumerable<Information>> GetAllInformations();
        Task<Information> GetInformationById(int id);
        Task<Information> AddInformation(Information information);
        Task<Information> UpdateInformation(int id, Information information);
        Task<bool> DeleteInformation(int id);
    }
}
