using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
#if(WINDOWS_WPF)
using RelayCommand= GalaSoft.MvvmLight.CommandWpf.RelayCommand;
#else
using RelayCommand= GalaSoft.MvvmLight.Command.RelayCommand;
#endif

namespace Calen.IOP.Client.ViewModel
{
    public class ManagerBase<T>:ViewModelBase
    {
        bool _isBusy;
        T _selectedItem;
        private bool _isEditing;
        private T _currentEditingItem;
        private T _presentItem;
        private ICommand _addCommand;
        private ICommand _deleteCommand;
        private ICommand _startEditCommand;
        private ICommand _saveEditingCommad;
        private ICommand _cancelEditingCommand;

        public bool IsBusy { get => _isBusy; set { Set(() => IsBusy, ref _isBusy, value); } }
        /// <summary>
        ///列表（树）上当前被先中的项
        /// </summary>
        public T SelectedItem
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
        public T CurrentEditingItem
        {
            get => _currentEditingItem;
            set
            {
                this.PresentItem = value;
                Set(() => CurrentEditingItem, ref _currentEditingItem, value);
            }
        }

        /// <summary>
        /// 当前呈现项
        /// </summary>
        public T PresentItem { get => _presentItem; set { Set(() => PresentItem, ref _presentItem, value); } }

        public ICommand AddCommand
        {
            get => _addCommand;

            set
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(AddExcute, AddPredicate);
                }
            }
        }

        private bool AddPredicate()
        {
            return true;
        }

        protected virtual void AddExcute()
        {
            
        }

        public ICommand DeleteCommand
        {
            get => _deleteCommand;
            set {
                if(_deleteCommand==null)
                {
                    _deleteCommand = new RelayCommand(DeleteExcute, DeletePredicate);
                }
            }
        }

        private bool DeletePredicate()
        {
            return this.PresentItem != null;
        }

        private void DeleteExcute()
        {
            
        }

        public ICommand StartEditCommand { get => _startEditCommand; set => _startEditCommand = value; }
        public ICommand SaveEditingCommad { get => _saveEditingCommad; set => _saveEditingCommad = value; }
        public ICommand CancelEditingCommand { get => _cancelEditingCommand; set => _cancelEditingCommand = value; }
    }
}
