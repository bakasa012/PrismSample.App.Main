﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrismSample.Lib.Views
{
    /// <summary>
    /// Interaction logic for StartDateView.xaml
    /// </summary>
    public partial class StartDateView : UserControl
    {
        public StartDateView()
        {
            InitializeComponent();
        }
        public string startDate;
        public string getStartDate()
        {
            return txtBlock.Text;
        }
    }
}
