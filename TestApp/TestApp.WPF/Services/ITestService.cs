using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.WPF.Services
{
    public interface ITestService
    {
        Task<string> GetData();
    }
}
