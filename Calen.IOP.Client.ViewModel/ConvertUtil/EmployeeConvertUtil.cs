﻿using Calen.IOP.Client.ViewModel.Common;
using Calen.IOP.DTO;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public static class EmployeeConvertUtil
    {
        public static employee ToDto(EmployeeVM vm)
        {
            employee em = new employee()
            {
                address = vm.Address,
                birthday = vm.Birthday,
                birthdayType = vm.BirthdayType,
                code = vm.Code,
                departmentId = vm.Department?.Id,
                departmentName = vm.Department?.Name,
                description = vm.Description,
                education = vm.Education,
                email = vm.Email,
                id = vm.Id,
                idCardCode = vm.IdCardCode,
                isVirtual = vm.IsVirtual,
                mobileNumber = vm.MobileNumber,
                name = vm.Name,
                passWord = vm.PassWord,
                serveState = vm.ServeState,
                sex = vm.Sex,
                nationality = vm.Nationality,
                userId = vm.UserId,
                permissionIds = vm.PermissionIds.ToArray(),
                userRoleIds = vm.UserRoleIds.ToArray(),
                pictureUrl=vm.PictureUrl,
                WeChat=vm.WeChat,
                QQ=vm.QQ
            };
            if(vm.Image!=null)
            {
                em.image= ImageConvertUtil.BitmapImageToBase64(vm.Image);
            }
            em.servingRecords = vm.ServingRecords.Select(p => ServingRecordConvertUtil.ToDto(p)).ToArray();
            return em;
        }
        public static EmployeeVM FromDto(employee dto)
        {
            EmployeeVM vm = new EmployeeVM()
            {
                Address = dto.address,
                Birthday = dto.birthday,
                BirthdayType = dto.birthdayType,
                Code = dto.code,
                Department = new DepartmentVM() { Id = dto.departmentId, Name = dto.departmentName },
                Description = dto.description,
                Education = (EducationLevels)dto.education,
                Email = dto.email,
                Name = dto.name,
                Id = dto.id,
                IdCardCode = dto.idCardCode,
                Image = dto.image == null ? null : ImageConvertUtil.Base64ToBitmapImage(dto.image),
                IsVirtual = dto.isVirtual,
                MobileNumber = dto.mobileNumber,
                PassWord = dto.passWord,
                ServeState = (ServeStates)dto.serveState,
                Sex = (SexTypes)dto.sex,
                Nationality = dto.nationality,
                UserId = dto.userId,
                WeChat = dto.WeChat,
                QQ = dto.QQ,
                PictureUrl = dto.pictureUrl,

            };
            if(dto.servingRecords!=null)
            {
                foreach(var item in dto.servingRecords)
                {
                    ServingRecordVM record = ServingRecordConvertUtil.FromDto(item);
                    record.Employee = vm;
                    vm.ServingRecords.Add(record);
                }
            }
            if(dto.userRoleIds!=null)
            {
                foreach(var item in dto.userRoleIds)
                {
                    vm.UserRoleIds.Add(item);
                }
            }
            if(dto.permissionIds!=null)
            {
                foreach (var item in dto.permissionIds)
                {
                    vm.PermissionIds.Add(item);
                }
            }
            return vm;
        }
    }

    
}
