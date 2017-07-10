using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
#if(WINDOWS_WPF)
using RelayCommand= GalaSoft.MvvmLight.CommandWpf.RelayCommand;
#else
using RelayCommand= GalaSoft.MvvmLight.Command.RelayCommand;
#endif

namespace Calen.IOP.Client.ViewModel
{
    public class ManagerBase<ItemType>:ViewModelBase where ItemType : EntityVMBase
    {

        bool _autoLoadDataOnInitialize;
        bool _isBusy;
        protected ItemType _selectedItem;
        private bool _isEditing;
        private ItemType _currentEditingItem;
        private ItemType _presentItem;
        private ICommand _addCommand;
        private ICommand _deleteCommand;
        private ICommand _editCommand;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        private ICommand _refreshItemsCommand;

        private ICommand _toFirstPageCommand;
        private ICommand _toPrePageCommand;
        private ICommand _toNextPageCommand;
        private ICommand _toLastPageCommand;

        public ICommand RefreshItemsCommand
        {
            get
            {
                if (_refreshItemsCommand == null)
                {
                    _refreshItemsCommand = new RelayCommand(RefreshItemsExcute, RefreshItemsPredicate);
                }
                return _refreshItemsCommand;
            }
        }
        ObservableCollection<ItemType> _itemList = new ObservableCollection<ItemType>();
      
        protected virtual bool RefreshItemsPredicate()
        {
            return true;
        }

        protected virtual void RefreshItemsExcute()
        {
           
        }
        public ObservableCollection<ItemType> ItemList { get => _itemList; }
        /// <summary>
        /// 是否在创建时就加载相关数据
        /// </summary>
        public bool AutoLoadDataOnInitialize { get=>_autoLoadDataOnInitialize;
            set
            {
                _autoLoadDataOnInitialize = value;
                if(value)
                {
                    if(!IsInDesignMode)
                    this.RefreshItemsExcute();
                }
            }
        }

        public bool IsBusy { get => _isBusy; set { Set(() => IsBusy, ref _isBusy, value); } }
        /// <summary>
        ///列表（树）上当前被先中的项
        /// </summary>
        public virtual ItemType SelectedItem
        {
            get => _selectedItem;
            set
            {
                if(!_isEditing)
                {
                    this.PresentItem = value;
                }
                Set(() => SelectedItem, ref _selectedItem, value);
            }
        }
        public bool IsEditing { get => _isEditing; set { Set(() => IsEditing, ref _isEditing, value); } }
        /// <summary>
        /// 当前被编辑的项
        /// </summary>
        public ItemType CurrentEditingItem
        {
            get => _currentEditingItem;
            set
            {
                if(value!=null)
                {
                    this.PresentItem = value;
                }
                Set(() => CurrentEditingItem, ref _currentEditingItem, value);
            }
        }

        /// <summary>
        /// 当前呈现项
        /// </summary>
        public ItemType PresentItem { get => _presentItem; set { Set(() => PresentItem, ref _presentItem, value); } }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(AddExecute, AddPredicate);
                }
                return _addCommand;
            }
        }
        public ICommand DeleteCommand
        {

            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(DeleteExecute, DeletePredicate);
                }
                return _deleteCommand;
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                if(_cancelCommand==null)
                {
                    _cancelCommand = new RelayCommand(CancelExecute, CancelPredicate);
                }
                return _cancelCommand;
            }
        }


        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(EditExecute, EditPredicate);
                }
                return _editCommand;
            }
        }
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(SaveExecute, SavePredicate);
                }
                return _saveCommand;
            }
        }

        protected virtual bool CancelPredicate()
        {
            return true;
        }

        protected virtual void CancelExecute()
        {
            ;
        }
        protected virtual bool AddPredicate()
        {
            return true;
        }

        protected virtual void AddExecute()
        {
            
        }

 
        protected virtual bool DeletePredicate()
        {
            return this.PresentItem != null;
        }

        protected virtual void DeleteExecute()
        {
            
        }

        protected virtual bool EditPredicate()
        {
            return true;
        }

        protected virtual void EditExecute()
        {
            ;
        }

        protected virtual bool SavePredicate()
        {
            return true;
        }

        protected virtual void SaveExecute()
        {
            ;
        }

        protected virtual void ClearEditingState()
        {
            this.IsEditing = false;
            this.CurrentEditingItem.IsEditing = false;
            this.CurrentEditingItem.IsDirty = false;
            this.CurrentEditingItem.IsNew = false;
            this.CurrentEditingItem = null;
            this.PresentItem = this.SelectedItem;
        }

        public IDeleteItemsDialog DeleteItemsDialog { get; set; }
        public IEditItemDialog EditItemDialog { get; set; }
        public ICommand ToFirstPageCommand
        {
            get
            {
                if(_toFirstPageCommand==null)
                {
                    _toFirstPageCommand = new RelayCommand(ToFirstPageExecute, ToFirstPagePredicate);
                }
                return _toFirstPageCommand;
            }
        }

        protected virtual bool ToFirstPagePredicate()
        {
            return true;
        }

        protected virtual void ToFirstPageExecute()
        {
            
        }

        public ICommand ToPrePageCommand
        {
           get
            {
                if(_toPrePageCommand==null)
                {
                    _toPrePageCommand = new RelayCommand(ToPrePageExecute, ToPrePagePredicate);
                }
                return _toPrePageCommand;
            }
        }

        protected virtual bool ToPrePagePredicate()
        {
            return true;
        }

        protected virtual void ToPrePageExecute()
        {
            ;
        }

        public ICommand ToNextPageCommand
        {
            get
            {
                if (_toNextPageCommand == null)
                {
                    _toNextPageCommand = new RelayCommand(ToNextPageExecute, ToNextPagePredicate);
                }
                return _toNextPageCommand;
            }
        }

        protected virtual bool ToNextPagePredicate()
        {
            return true;
        }

        protected virtual void ToNextPageExecute()
        {
            ;
        }

        public ICommand ToLastPageCommand
        {
            get
            {
                if (_toLastPageCommand == null)
                {
                    _toLastPageCommand = new RelayCommand(ToLastPageExecute, ToLastPagePredicate);
                }
                return _toLastPageCommand;
            }
        }

        protected virtual bool ToLastPagePredicate()
        {
            return true;
        }

        protected virtual void ToLastPageExecute()
        {
            ;
        }
    }

    public interface IDeleteItemsDialog
    {
        Task<bool> ShowDialog<T>(IEnumerable<T> vmList) where T:EntityVMBase;
        /// <summary>
        /// true:删除所有子级，false:不删子级
        /// </summary>
        bool RecursiveDelete { get; set; }
    }

    public interface IEditItemDialog
    {
        Task<bool> ShowDialogAsync<T>(T vm) where T : EntityVMBase;

    }
}
