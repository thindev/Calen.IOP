using System.Collections.Generic;
using System.Threading.Tasks;
using Calen.IOP.DTO.Common;

namespace Calen.IOP.DataPortal
{
    public interface IDataPortal
    {
        Task AddDepartments(ICollection<department> ds);
        Task<ICollection<department>> GetDepartmentTreeAsync();
        Task UpdateDepartments(ICollection<department> ds);
        Task<int> DeleteDepartments(ICollection<department> ds, bool recursive);
        Task<ICollection<hireType>> GetAllHireTypesAsync();
        Task<int> AddHireTypes(hireType[] hts);
    }
}