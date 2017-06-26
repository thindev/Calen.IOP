using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public abstract class EntityVMBase<T>:ViewModelBase
    {
        protected string _id;
        protected string _code;
        protected string _name;
        protected string _description;
        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set { Set(() => Name, ref _name, value); } }
        public string Description { get => _description; set { Set(() => Description, ref _description, value); } }
        public string Code { get => _code; set { Set(() => Code, ref _code, value); } }

        public abstract T DeepClone();
    }
}
