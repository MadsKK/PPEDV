using Microsoft.Win32;
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
using System.Windows.Shapes;
using System.IO;

namespace Application
{
    /// <summary>
    /// Interaction logic for OpenFile.xaml
    /// </summary>
    public partial class OpenFile : Window
    {

        public static string directory = MainWindow.directory;

        public static string targetFile = MainWindow.targetName;

        public OpenFile()
        {
            
            InitializeComponent();
            Textbox.IsEnabled = false;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string file;
            string text;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.DefaultExt = ".ppv";
            openFileDialog1.Filter = "PPV Documents (.ppv)|*.ppv";
            openFileDialog1.InitialDirectory = MainWindow.directory;

            try
            {
                Nullable<bool> result = openFileDialog1.ShowDialog();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Argument Error");
            }

            try
            {

                file = openFileDialog1.FileName;
                
                text = File.ReadAllText(file);

                Textbox.Text = text;

                Textbox.IsEnabled = true;

            } catch (Exception)
            {
                Console.WriteLine("Error trying to open or read file");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Create(targetFile))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(Textbox.Text);
                fs.Write(info, 0, info.Length);
            }

            string msg = "You have saved your file!";

            

            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxResult result = MessageBox.Show(msg, "Confirmation", button);

            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }

        }
    }
}
