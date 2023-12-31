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

namespace _02.Thread_Home
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new();

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            this.DataContext = viewModel;
            PrimeNumbersListBox.ItemsSource = PrimaryNums;
        }
        private List<int> FibonacciNums = new List<int>();
        private List<int> PrimaryNums = new List<int>();

        private void Fibonacci(int right)
        {
            int a = 0;
            int b = 1;
            if (right < 0)
            { right = 100; }
            for (int i = 0; i < right; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
                FibonacciNums.Add(a);
            }
        }
        private bool IsPrimeNumber(int n)
        {
            var result = true;

            if (n > 1)
            {
                for (var i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
        private int PrimeNums(int left, int right)
        {
            if (left > right)
            {
                int tmp;
                tmp = left;
                left = right;
                right = tmp;
            }
            int Count = 0;
            for (int i = left; i < right; i++)
            {
                if (IsPrimeNumber(i))
                {
                    PrimaryNums.Add(i);
                    Count++;
                }
            }
            return Count;
        }
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            PrimeNums(viewModel.leftPrimary, viewModel.rightPrimary);
            Fibonacci(viewModel.rightFibonacci);
        }


        [PropertyChanged.AddINotifyPropertyChangedInterface]
        public class ViewModel
        {
            public int leftPrimary;
            public int rightPrimary;
            public int rightFibonacci;


        }

    }
}
