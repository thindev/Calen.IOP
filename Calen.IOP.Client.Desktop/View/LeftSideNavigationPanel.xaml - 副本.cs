﻿using System;
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
    /// TimeManageLeftSidePanel.xaml 的交互逻辑
    /// </summary>
    public partial class LeftSideNavigationPanel : UserControl
    {
        double _expandedWidth=160;
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
           
        }
        void CollapseMenuPanel()
        {
            
        }
    }
}
