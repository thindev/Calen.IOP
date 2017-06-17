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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace Calen.IOP.Client.Desktop.View
{
    /// <summary>
    /// ContentContainerPanel.xaml 的交互逻辑
    /// </summary>
    public partial class ContentContainerPanel : UserControl
    {
        Dictionary<Uri, Page> _pagesDic = new Dictionary<Uri, Page>(); 
        public ContentContainerPanel()
        {
            InitializeComponent();
        }
        
        public void GoToPage(Uri uri,string funName)
        {
            Page page = null;
           if(uri!=null&&_pagesDic.ContainsKey(uri))
            {
                page = _pagesDic[uri];
            }
           else
            {
                this.frame.Navigate(uri,uri);
            }
           
            this.frame.Content = page;
            if(this.frame.CanGoBack)
            this.frame.RemoveBackEntry();
        }

        private void frame_Navigated(object sender, NavigationEventArgs e)
        {
            if(e.ExtraData!=null)
            {
                _pagesDic.Add((Uri)e.ExtraData, (Page)e.Content);
            }
        }
    }
}
