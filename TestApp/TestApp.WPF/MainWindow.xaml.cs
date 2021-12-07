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
using TestApp.WPF.Services;

namespace TestApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ITestService _testService;
        public MainWindow(ITestService service)
        {
            _testService = service;

            InitializeComponent();
        }
        protected async override void OnInitialized(EventArgs e)
        {
            string data = (await _testService.GetData());
            MessageBox.Show($"Retrieved Data: {data}", "Result");
        }
    }
}