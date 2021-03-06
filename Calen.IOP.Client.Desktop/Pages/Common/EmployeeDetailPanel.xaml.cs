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

namespace Calen.IOP.Client.Desktop.Pages.Common
{
    /// <summary>
    /// EmployeeDetailPanel.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeDetailPanel : UserControl
    {
        public EmployeeDetailPanel()
        {
            InitializeComponent();
        }
        public bool IsBaseInfoExpanded
        {
            set
            {
                epd_baseInfo.IsExpanded = value;
            }
        }
        public bool IsAccountInfoExpanded
        {
            set
            {
                epd_accountInfo.IsExpanded = value;
            }
        }
        public bool IsAdditionalInfoExpanded
        {
            set
            {
                epd_additional.IsExpanded = value;
            }
        }
    }
}
