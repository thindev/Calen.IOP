﻿using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calen.IOP.DataAccess;

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
                em.ServingRecords.Clear();
            }
            em.Address = dto.address;
            em.BirthDay = dto.birthDay;
            em.Code = dto.code;
            em.Description = dto.description;
            em.Education = (EducationLevel)dto.education;
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
                birthDay = model.BirthDay,
                code = model.Code,
                departmentId = model.Department.Id,
                departmentName = model.Department.Name,
                description = model.Description,
                education = (int)model.Education,
                email = model.Email,
                id = model.Id,
                idCardCode = model.IdCardCode,
                isVirtual = model.IsVirtual,
                mobileNumber = model.MobileNumber,
                name = model.Name,
                passWord = model.Passwrod,
                serveState = (int)model.ServeState,
                sex = (int)model.Sex,
                userId = model.UserId,
            };
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
