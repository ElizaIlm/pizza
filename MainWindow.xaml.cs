using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace eliza13pr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string localPath;
        //public static string localPath = Directory.GetCurrentDirectory();
        public MainWindow()
        {
            InitializeComponent();
            localPath = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName).FullName;
            OpenPages(pages.main);
           
        }
        public enum pages
        {
            main
        }
        public void OpenPages(pages _pages)
        {
            if (_pages == pages.main)
                frame.Navigate(new Layout.Main(this));
        }
    }
}
