using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstXamarinApp.Models;
using FirstXamarinApp.Services;

namespace FirstXamarinApp.ViewModels
{
    public class ItemPageViewModel : BaseViewModel
    {
        ICourseListDataStore courseListDataStore = new MockCourseListDataStore();

        public Item Item { get; set; }
        public List<Course> CourseList { get; private set; }

        public ItemPageViewModel(Item item = null)
        {
            InitializeCourseList();
            if (item != null)
            {
                item.Course = CourseList.First(x => x.Name.Equals(item.Course.Name));
            }
            Item = item ?? new Item
            {
                Id = new Guid().ToString(),
                Course = CourseList.FirstOrDefault()
            };
        }

        private async void InitializeCourseList()
        {
            CourseList = await courseListDataStore.GetListAsync();
        }
    }
}
