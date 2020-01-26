using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicatin.Models;

namespace WebApplicatin.Infrastructure.Interfaces
{
    /// Интерфейс для работы с сотрудниками
    public interface IEmployeesService
    {
        IEnumerable<EmployeeView> GetAll();
        EmployeeView GetById(int id);
        void Commit();
        void AddNew(EmployeeView model);
        void Delete(int id);
    }
}
