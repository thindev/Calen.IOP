﻿using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calen.IOP.DataAccess;
using Calen.IOP.DTO;

namespace Calen.IOP.BLL.Converters
{
    class EmployeeConverter : ConverterBase<Employee, employee>
    {
        public EmployeeConverter(IOPContext ctx) : base(ctx)
        {
        }

        public override Employee FromDto(employee dto)
        {

            Employee em = DbContext.Employees.Find(dto.id);
            if (em == null)
            {
                em = new Employee()
                {
                    Id = dto.id
                };
            }
            else
            {
                DbContext.Set<ServingRecord>().RemoveRange(em.ServingRecords);
                em.ServingRecords?.Clear();
            }
            em.Address = dto.address;
            em.BirthDay = dto.birthday;
            em.BirthDayType = dto.birthdayType;
            em.Code = dto.code;
            em.Description = dto.description;
            em.Education = (EducationLevels)dto.education;
            em.Email = dto.email;
            em.Id = dto.id;
            em.IdCardCode = dto.idCardCode;
            em.IsVirtual = dto.isVirtual;
            em.MobileNumber = dto.mobileNumber;
            em.Name = dto.name;
            em.Passwrod = dto.passWord;
            em.ServeState = (ServeStates)dto.serveState;
            em.Sex = (SexTypes)dto.sex;
            em.UserId = dto.userId;
            em.Nationality = dto.nationality;
            em.WeChat = dto.WeChat;
            em.QQ = dto.QQ;
            em.PictureUrl = dto.pictureUrl;
            em.UserRoleIds = string.Join("," ,dto.userRoleIds);
            em.PermissionIds = string.Join(",", dto.permissionIds);
            em.Department = DbContext.Departments.Find(dto.departmentId);
            if (!string.IsNullOrEmpty(dto.image))
            {
                em.Image = Convert.FromBase64String(dto.image);
            }
            if(dto.servingRecords!=null)
            {
                foreach(var item in dto.servingRecords)
                {
                    if (item.jobPosition == null) continue;
                    ServingRecord record = new ServingRecord()
                    {
                        BeginTime = item.beginTime,
                        Employee = em,
                        EndTime = item.endTime,
                        Id = item.id,
                        IsConcurrent = item.isConcurrent,
                        IsCurrent = item.isCurrent,
                        JobPosition = DbContext.JobPositions.Find(item.jobPosition.id)
                    };
                    if(em.ServingRecords==null)
                    {
                        em.ServingRecords = new List<ServingRecord>();
                    }
                    em.ServingRecords.Add(record);
                }
            }
            return em;
        }

        public override employee ToDto(Employee model)
        {
            employee em = new employee()
            {
                address = model.Address,
                birthday = model.BirthDay,
                code = model.Code,
                birthdayType = model.BirthDayType,
                description = model.Description,
                education = model.Education,
                email = model.Email,
                id = model.Id,
                idCardCode = model.IdCardCode,
                isVirtual = model.IsVirtual,
                mobileNumber = model.MobileNumber,
                name = model.Name,
                passWord = model.Passwrod,
                serveState = model.ServeState,
                sex = model.Sex,
                nationality = model.Nationality,
                userId = model.UserId,
                pictureUrl = model.PictureUrl,
                QQ = model.QQ,
                WeChat=model.WeChat,
                userRoleIds= model.UserRoleIds==null?null:model.UserRoleIds.Split(','),
                 permissionIds = model.PermissionIds == null ? null : model.PermissionIds.Split(','),
             
            };
            if(model.Department!=null)
            {
                em.departmentId = model.Department.Id;
                em.departmentName = model.Department.Name;
            }
            if (model.ServingRecords != null)
            {
                var jpC = new JobPositionConverter(DbContext);
                List<servingRecord> list = new List<servingRecord>();
                foreach (var item in model.ServingRecords)
                {
                    servingRecord record = new servingRecord
                    {
                        beginTime = item.BeginTime,
                        employeeId = item.Employee.Id,
                        endTime = item.EndTime,
                        id = item.Id,
                        isConcurrent = item.IsConcurrent,
                        isCurrent = item.IsCurrent,
                        jobPosition = jpC.ToDto(item.JobPosition)
                    };
                    list.Add(record);
                }
                em.servingRecords = list.ToArray();
            }
            if (model.Image != null)
            {
                em.image = Convert.ToBase64String(model.Image);
            }
            return em;
        }
    }
}
