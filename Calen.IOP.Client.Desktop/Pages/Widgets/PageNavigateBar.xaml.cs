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

namespace Calen.IOP.Client.Desktop.Pages.Widgets
{
    /// <summary>
    /// PageNavigateBar.xaml 的交互逻辑
    /// </summary>
    public partial class PageNavigateBar : UserControl
    {
        public PageNavigateBar()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty PageCountProperty = DependencyProperty.Register("PageCount", typeof(int), typeof(PageNavigateBar));
        public static readonly DependencyProperty TotalCountProperty = DependencyProperty.Register("TotalCount", typeof(int), typeof(PageNavigateBar));
        public static readonly DependencyProperty CountPerPageProperty = DependencyProperty.Register("CountPerPage", typeof(int), typeof(PageNavigateBar));
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register("CurrentPage", typeof(int), typeof(PageNavigateBar));
        public static readonly DependencyProperty PageIndexListProperty = DependencyProperty.Register("PageIndexList", typeof(int[]), typeof(PageNavigateBar));
        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }
        public int TotalCount
        {
            get { return (int)GetValue(TotalCountProperty); }
            set { SetValue(TotalCountProperty, value); }
        }
        public int CountPerPage
        {
            get { return (int)GetValue(CountPerPageProperty); }
            set { SetValue(CountPerPageProperty, value); }
        }
        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }
         public int[] PageIndexList
        {
            get { return (int[])GetValue(PageIndexListProperty); }
            set { SetValue(PageIndexListProperty, value); }
        }
        public ICommand ToFirstPageCommand
        {
            get { return btn_to_fist.Command; }
            set { btn_to_fist.Command = value; }
        }
        public ICommand ToPrePageCommand
        {
            get { return btn_to_pre.Command; }
            set { btn_to_pre.Command = value; }
        }
        public ICommand ToNextPageCommand
        {
            get { return btn_to_next.Command; }
            set { btn_to_next.Command = value; }
        }
        public ICommand ToLastCommand
        {
            get { return btn_to_last.Command; }
            set { btn_to_last.Command = value; }
        }
    }
}
