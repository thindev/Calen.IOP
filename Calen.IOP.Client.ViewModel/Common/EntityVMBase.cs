using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{

    public class EntityVMBase : ViewModelBase
    {
        string _id;
        string _code;
        string _name;
        string _description;
        bool _isNew;
        bool _isDirty;
        bool _isEditing;
        bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set { Set(() => IsSelected, ref _isSelected, value); }
        }
        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set { Set(() => Name, ref _name, value); } }
        public string Description { get => _description; set { Set(() => Description, ref _description, value); } }
        public string Code { get => _code; set { Set(() => Code, ref _code, value); } }

        /// <summary>
        /// 是否是新增的
        /// </summary>
        public bool IsNew { get => _isNew; set { Set(() => IsNew, ref _isNew, value); } }
        /// <summary>
        /// 是否有更改
        /// </summary>
        public bool IsDirty { get => _isDirty; set { Set(() => IsDirty, ref _isDirty, value); } }
        /// <summary>
        /// 是否正在编辑
        /// </summary>
        public bool IsEditing { get => _isEditing; set { Set(() => IsEditing, ref _isEditing, value); } }
    }
    public abstract class EntityVMBase<T>:EntityVMBase
    {
        public abstract T DeepClone();

       
    }
}
