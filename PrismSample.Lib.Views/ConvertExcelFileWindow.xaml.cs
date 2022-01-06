using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrismSample.Lib.Views
{
    /// <summary>
    /// Interaction logic for ConvertExcelFileWindow.xaml
    /// </summary>
    public partial class ConvertExcelFileWindow : Window
    {
        public ConvertExcelFileWindow()
        {
            Style dpStyle = new Style(typeof(DatePicker));
            dpStyle.Setters.Add(new Setter(DatePicker.LanguageProperty, System.Windows.Markup.XmlLanguage.GetLanguage("zh-cn")));
            this.Resources.Add(typeof(DatePicker), dpStyle);
            InitializeComponent();
        }
    }
}
