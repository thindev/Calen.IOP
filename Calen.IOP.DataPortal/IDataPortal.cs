using System.Collections.Generic;
using System.Threading.Tasks;
using Calen.IOP.DTO.Common;

namespace Calen.IOP.DataPortal
{
    public interface IDataPortal
    {
        Task AddDepartments(ICollection<department> items);
        Task<ICollection<department>> GetDepartmentTreeAsync();
        Task UpdateDepartments(ICollection<department> ds);
        Task<int> DeleteDepartments(ICollection<department> ds, bool recursive);
        Task<ICollection<hireType>> GetAllHireTypesAsync();
        Task<int> AddHireTypes(IEnumerable<hireType> items);
        Task<int> DeleteHireTypes(IEnumerable<hireType> items);
        Task<int> UpdateHireTypes(IEnumerable<hireType> items);

        #region jobTypes
        Task<ICollection<jobType>> GetAllJobTypesAsync();
        Task<int> AddJobTypes(IEnumerable<jobType> items);
        Task<int> DeletJobTypes(IEnumerable<jobType> items);
        Task<int> UpdateJobTypes(IEnumerable<jobType> items);
        #endregion
        #region jobPositionLevel
        Task<ICollection<jobPositionLevel>> GetAllJobPositionLevelsAsync();
        Task<int> AddJobPositionLevels(IEnumerable<jobPositionLevel> items);
        Task<int> DeletJobPositionLevels(IEnumerable<jobPositionLevel> items);
        Task<int> UpdateJobPositionLevels(IEnumerable<jobPositionLevel> items);
        #endregion
    }
}