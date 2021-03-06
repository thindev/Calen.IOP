﻿using System.Collections.Generic;
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

        #region userRole
        Task<ICollection<userRole>> GetAllUserRolesAsync();
        Task<int> AddUserRoles(IEnumerable<userRole> items);
        Task<int> DeleteUserRoles(IEnumerable<userRole> items);
        Task<int> UpdateUserRoles(IEnumerable<userRole> items);
        #endregion userRole
        #region employee
        Task<resultForEmployees> FetchEmployees(criteriaForEmployees criteria);
        Task<int> AddEmployees(IEnumerable<employee> items);
        Task<int> DeleteEmployees(IEnumerable<employee> items);
        Task<int> UpdateEmployees(IEnumerable<employee> items);
        #endregion employee
        #region vipCards
        Task<IEnumerable<vipCard>> FetchAllVipCards();
        Task<int> AddVipCards(IEnumerable<vipCard> items);
        Task<int> DeleteVipCards(IEnumerable<string> ids);
        Task<int> UpdateVipCards(IEnumerable<vipCard> items);
        #endregion vipCards

        #region customer
        Task<resultForCustomers> FetchCustomers(criteriaForCustomer criteria);
        Task<int> AddCustomers(IEnumerable<customer> items);
        Task<int> DeleteCustomers(IEnumerable<string> itemIds);
        Task<int> UpdateCustomers(IEnumerable<customer> items);
        #endregion customer
    }
}