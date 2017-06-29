using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class FunctionVM:ViewModelBase
    {
        string _id;
        string _name;
        string _uri;
        string _description;
        bool _isChecked;
        bool _isReadOnly;
        FunctionVM _parentFuntion;
        ObservableCollection<FunctionVM> _subFunctions = new ObservableCollection<FunctionVM>();

        public string Id { get => _id; set { Set(() => Id, ref _id, value); } }
        public string Name { get => _name; set { Set(() => Name, ref _name, value); } }
        public string Description { get => _description; set { Set(() => Description, ref _description, value); } }
        public bool IsChecked { get => _isChecked;
            set
            {
                if(_isChecked!=value)
                {
                    _isChecked = value;
                    if(value&&this.ParentFuntion!=null)
                    {
                        this.ParentFuntion.IsChecked = value;
                    }
                    if(!value)
                    {
                        foreach(var item in this.SubFunctions)
                        {
                            item.IsChecked = value;
                        }
                    }
                    RaisePropertyChanged(()=>IsChecked);
                }
            }
        }
        public bool IsReadOnly { get => _isReadOnly; set { Set(()=>IsReadOnly,ref _isReadOnly,value); } }
        public ObservableCollection<FunctionVM> SubFunctions { get => _subFunctions; }
        public string Uri { get => _uri; set { Set(() => Uri, ref _uri, value); } }

        public FunctionVM ParentFuntion { get => _parentFuntion; set { Set(() => ParentFuntion, ref _parentFuntion, value); } }
    }
}
