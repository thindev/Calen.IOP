using Calen.IOP.Client.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
   public class FunctionManagerVM
    {
         List<FunctionVM> _functionTree=new List<FunctionVM>();
         Dictionary<string, FunctionVM> _functionDic = new Dictionary<string, FunctionVM>();
        public List<FunctionVM> FunctionTree
        {
            get
            {
                return _functionTree;
            }
        }

        public Dictionary<string, FunctionVM> FunctionDic { get => _functionDic;  }

        private  FunctionVM Copy(FunctionVM vm, IEnumerable<string> checkedIds)
        {
            FunctionVM copy = new FunctionVM();
            copy.Description = vm.Description;
            copy.Id = vm.Id;
            copy.IsChecked = vm.IsChecked;
            copy.IsReadOnly = vm.IsReadOnly;
            copy.Name = vm.Name;
            copy.Uri = vm.Uri;
            if (vm.SubFunctions != null && vm.SubFunctions.Count > 0)
            {
                foreach (var item in vm.SubFunctions)
                {
                    var sub = Copy(item, checkedIds);
                    copy.SubFunctions.Add(sub);
                    sub.ParentFuntion = copy;
                }
            }
            if (checkedIds != null && copy.Id != null && checkedIds.Contains(copy.Id))
            {
                copy.IsChecked = true;
            }
            return copy;
        }
        public  List<FunctionVM> CloneFunctionTree(IEnumerable<string> checkedIds = null)
        {
            List<FunctionVM> list = new List<FunctionVM>();
            foreach (var item in FunctionTree)
            {
                list.Add(Copy(item, checkedIds));
            }
            return list;
        }

        public void UpdateFunctionTreeCheckedState(IEnumerable<FunctionVM> funs, IEnumerable<string> checkedIds)
        {
            foreach(var item in funs)
            {
                this.UpdateFunctionCheckedState(item, checkedIds);
            }
        }

        private void UpdateFunctionCheckedState(FunctionVM item, IEnumerable<string> checkedIds)
        {
            item.IsChecked = checkedIds.Contains(item.Id);
            if(item.SubFunctions!=null)
            {
                foreach (var sub in item.SubFunctions)
                {
                    this.UpdateFunctionCheckedState(sub,checkedIds);
                }
            }
        }
    }
}
