using Calen.IOP.Client.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml.Serialization;

namespace Calen.IOP.Client.Desktop
{
    public class FunctionMgr : DependencyObject
    {
        public static readonly DependencyProperty FunctionIdProperty = DependencyProperty.RegisterAttached("FunctionId", typeof(string), typeof(FunctionMgr), new PropertyMetadata(null,FunctionIdChanged));

        private static void FunctionIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement fe = d as FrameworkElement;
            if (fe == null)
            {
                return;
            }
            if (e.NewValue != null)
            {

                if (!_functionItemElements.Contains(fe))
                {
                    fe.Unloaded += Fe_Unloaded;
                    _functionItemElements.Add(fe);
                    fe.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                if (_functionItemElements.Contains(fe))
                {
                    fe.Unloaded -= Fe_Unloaded;
                    _functionItemElements.Remove(fe);
                }
            }
        }

        public static readonly DependencyProperty FunctionNameProperty = DependencyProperty.RegisterAttached("FunctionName", typeof(string), typeof(FunctionMgr), new PropertyMetadata(null));
        public static readonly DependencyProperty FunctionPageUriProperty = DependencyProperty.RegisterAttached("FunctionPageUri", typeof(string), typeof(FunctionMgr), new PropertyMetadata(null));
        public static readonly DependencyProperty FunctionDescriptionProperty = DependencyProperty.RegisterAttached("FunctionDescription", typeof(string), typeof(FunctionMgr), new PropertyMetadata(null));

        private static List<FrameworkElement> _functionItemElements = new List<FrameworkElement>();
       

        private static void Fe_Unloaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe == null)
            {
                return;
            }
            fe.Unloaded -= Fe_Unloaded;
            if (_functionItemElements.Contains(fe))
            {
                _functionItemElements.Remove(fe);
            }
        }

        public static void EnableFunctions()
        {
            foreach(var fe in _functionItemElements)
            {
                string id = GetFunctionId(fe);
                if (_functionDic.ContainsKey(id))
                {
                    FunctionVM vm = _functionDic[id];
                    SetFunctionName(fe,vm.Name);
                    SetFunctionPageUri(fe,vm.Uri);
                    SetFunctionDescription(fe, vm.Description);
                    fe.Visibility = Visibility.Visible;
                    fe.ToolTip = string.IsNullOrEmpty(vm.Description) ? null : vm.Description;
                }
                else
                {
                    fe.Visibility = Visibility.Collapsed;
                }
            }
           
        }
        public static void SetFunctionDescription(DependencyObject obj,string value)
        {
            obj.SetValue(FunctionDescriptionProperty, value);
        }
        public static string GetFunctionDescription(DependencyObject obj)
        {
            return (string)obj.GetValue(FunctionDescriptionProperty);
        }

        public static void SetFunctionId(DependencyObject obj, string value)
        {
            obj.SetValue(FunctionIdProperty, value);
        }
      
        public static string GetFunctionId(DependencyObject obj)
        {
            return (string)obj.GetValue(FunctionIdProperty);
        }

        public static void SetFunctionName(DependencyObject obj, string value)
        {
            obj.SetValue(FunctionNameProperty, value);
        }

        public static string GetFunctionName(DependencyObject obj)
        {
            return (string)obj.GetValue(FunctionNameProperty);
        }

        public static void SetFunctionPageUri(DependencyObject obj, string value)
        {
            obj.SetValue(FunctionPageUriProperty, value);
        }

        public static string GetFunctionPageUri(DependencyObject obj)
        {
            return (string)obj.GetValue(FunctionPageUriProperty);
        }
        static IReadOnlyList<FunctionVM> _functionTree;
        static Dictionary<string, FunctionVM> _functionDic=new Dictionary<string, FunctionVM>();
        public static IReadOnlyList<FunctionVM> FunctionTree
        {
            get { return _functionTree; }
        }
        public static void InitFunctionTree(string file)
        {
            if(File.Exists(file))
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(FunctionConfig));
                    FunctionConfig fc=(FunctionConfig) xml.Deserialize(fs);
                    if(fc.FunctionItems!=null)
                    {
                        List<FunctionVM> list = new List<FunctionVM>();
                        foreach (var f in fc.FunctionItems)
                        {
                            list.Add(FunctionItemToFunctionVM(f));
                        }
                        _functionTree = list.AsReadOnly();
                    }
                }
            }
        }

        private static FunctionVM FunctionItemToFunctionVM(FunctionItem item)
        {
            FunctionVM vm = new FunctionVM();
            vm.Id = item.Id;
            vm.Name = item.Name;
            vm.Uri = item.Uri;
            vm.Description = item.Description;
            if(item.SubFunctions!=null&&item.SubFunctions.Length>0)
            {
                foreach(var f in item.SubFunctions)
                {
                    vm.SubFunctions.Add(FunctionItemToFunctionVM(f));
                }
            }
            _functionDic[vm.Id] = vm;
            return vm;
        }

    }

    public class FunctionItem
    {
        [XmlAttribute]
        public string Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Uri { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
        public FunctionItem[] SubFunctions { get; set; }
    }
    public class FunctionConfig
    {
        public FunctionItem[] FunctionItems { get; set; }
    }
}
