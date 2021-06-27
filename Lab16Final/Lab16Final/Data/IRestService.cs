using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lab16Final.Model;

namespace Lab16Final.Data
{
    public interface IRestService
    {
        Task<List<Student>> RefreshDataAsync();
        Task SaveStudentAsync(Student student, bool isNew);
        Task DeleteStudentAsync(String id);
    }
}
