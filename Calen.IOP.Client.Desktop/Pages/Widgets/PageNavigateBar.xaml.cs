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

        public static readonly DependencyProperty ToFirstPageCommandProperty = DependencyProperty.Register("ToFirstPageCommand", typeof(ICommand), typeof(PageNavigateBar),new PropertyMetadata(null, ToFirstPageCommandChanged));

        private static void ToFirstPageCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PageNavigateBar bar = (PageNavigateBar)d;
            bar.btn_to_fist.Command = e.NewValue as ICommand;
        }

        private static void ToNextPageCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PageNavigateBar bar = (PageNavigateBar)d;
            bar.btn_to_next.Command = e.NewValue as ICommand;
        }

        public static readonly DependencyProperty ToPrePageCommandProperty = DependencyProperty.Register("ToPrePageCommand", typeof(ICommand), typeof(PageNavigateBar), new PropertyMetadata(null, ToPrePagePageCommandChanged));

        private static void ToPrePagePageCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PageNavigateBar bar = (PageNavigateBar)d;
            bar.btn_to_pre.Command = e.NewValue as ICommand;
        }

        public static readonly DependencyProperty ToNextPageCommandProperty = DependencyProperty.Register("ToNextPageCommand", typeof(ICommand), typeof(PageNavigateBar), new PropertyMetadata(null, ToNextPageCommandChanged));
        public static readonly DependencyProperty ToLastCommandProperty = DependencyProperty.Register("ToLastCommand", typeof(ICommand), typeof(PageNavigateBar), new PropertyMetadata(null, ToLastCommandChanged));

        private static void ToLastCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PageNavigateBar bar = (PageNavigateBar)d;
            bar.btn_to_last.Command = e.NewValue as ICommand;
        }

     
        public ICommand ToFirstPageCommand
        {
            set { SetValue(ToFirstPageCommandProperty,value); }
            get { return (ICommand)GetValue(ToFirstPageCommandProperty); }
        }
        public ICommand ToPrePageCommand
        {
            set { SetValue(ToPrePageCommandProperty, value); }
            get { return (ICommand)GetValue(ToPrePageCommandProperty); }
        }
        public ICommand ToNextPageCommand
        {
            set { SetValue(ToNextPageCommandProperty, value); }
            get { return (ICommand)GetValue(ToNextPageCommandProperty); }
        }
        public ICommand ToLastCommand
        {
            set { SetValue(ToLastCommandProperty, value); }
            get { return (ICommand)GetValue(ToLastCommandProperty); }
        }
    }
}
