using System;
using System.Collections.Generic;
using System.IO;
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

namespace Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

        public static string directory = System.IO.Path.GetDirectoryName(path);

        public static string targetFile = directory + @"\secret.ppv";


        public bool fileExists;

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(targetFile))
            {
                Button3.Content = "Open File";
                fileExists = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            

            if (fileExists == true)
            {
                new OpenFile().ShowDialog();

            } else
            {
                new CreateFile().ShowDialog();
                
            }
            
        }
    }
}
