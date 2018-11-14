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
using System.Windows.Shapes;

namespace Application
{
    /// <summary>
    /// Interaction logic for CreateFile.xaml
    /// </summary>
    public partial class CreateFile : Window
    {

        public CreateFile()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string targetFile = MainWindow.targetFile;

            using (FileStream fs = File.Create(targetFile))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("This is a test");
                fs.Write(info, 0, info.Length);
            }

            new MainWindow().Show();
            this.Close();
        }
    }
}
