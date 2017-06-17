using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calen.IOP.Client.Desktop.Pages
{
    /// <summary>
    /// DepartmentManagePanel.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentManagePanel : UserControl
    {
        public DepartmentManagePanel()
        {
            InitializeComponent();
            this.DataContext= _departmentManager = new ViewModel.DepartmentManager();
            _departmentManager.RefreshDepartmentsCommand.Execute(null);
        }
        public ViewModel.DepartmentManager _departmentManager;
        public void SetTitle(string tile)
        {
            this.tb_Title.Text = tile;
        }
    }
    
}
