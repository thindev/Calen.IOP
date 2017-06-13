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

namespace Calen.IOP.Client.Desktop.View
{
    /// <summary>
    /// LeftSideNavigationPanel.xaml 的交互逻辑
    /// </summary>
    public partial class LeftSideNavigationPanel:UserControl
    {
        double _expandedWidth = 160;
        public double ExpandedWidth
        {
            get { return _expandedWidth; }
            set
            {
                _expandedWidth = value;
                this.ExpandMenuPanel();
            }
        }
        public LeftSideNavigationPanel()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            this.ExpandMenuPanel();
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            this.CollapseMenuPanel();
        }

        void ExpandMenuPanel()
        {
            this.rightColumn.Width = new GridLength(_expandedWidth);
            if(this.container!=null)
            this.container.Visibility = Visibility.Visible;
            if (this.navTglb1 != null)
                this.navTglb1.Visibility = Visibility.Collapsed;
        }
        void CollapseMenuPanel()
        {
            this.rightColumn.Width = new GridLength(0);
            if (this.container != null)
                this.container.Visibility = Visibility.Collapsed;
            if (this.navTglb1 != null)
                this.navTglb1.Visibility = Visibility.Visible;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
            TreeViewItem item = (TreeViewItem)treeView.SelectedItem;
            if (item != null && item.HasItems)
            {
                TreeViewItem old = e.OldValue as TreeViewItem;
                if (old != null && !old.HasItems)
                {
                    old.IsSelected = true;
                }
            }
        }
    }
}
