using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstXamarinApp.Models;

namespace FirstXamarinApp.Services
{
    public interface ICourseListDataStore
    {
        Task<List<Course>> GetListAsync();
    }           
}
