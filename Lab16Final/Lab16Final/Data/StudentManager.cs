using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lab16Final.Model;

namespace Lab16Final.Data
{
    public class StudentManager
    {
        private IRestService _restService;

        public StudentManager(IRestService service)
        {
            _restService = service;
        }

        public Task<List<Student>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Student item, bool isNew = false)
        {
            return _restService.SaveStudentAsync(item, isNew);
        }

        public Task DeleteTaskAsync(Student item)
        {
            return _restService.DeleteStudentAsync(item.Id);
        }
    }
}
