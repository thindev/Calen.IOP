using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.Client.ViewModel.Common
{
    public interface IConfirmDialog
    {
        Task<bool> ShowDialog(string msg, string title);
    }
}
