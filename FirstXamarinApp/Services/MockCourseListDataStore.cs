using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstXamarinApp.Models;

namespace FirstXamarinApp.Services
{
    public class MockCourseListDataStore : ICourseListDataStore
    {
        readonly List<Course> CourseList = new List<Course> {
            new Course { Name = "Introduction to Xamarin Forms" },
            new Course { Name = "Advanced Xamarin Forms" },
            new Course { Name = "Plugging React Native to Xamarin Forms" }
        };

        public async Task<List<Course>> GetListAsync()
        {
            return await Task.FromResult(CourseList);
        }
    }
}
