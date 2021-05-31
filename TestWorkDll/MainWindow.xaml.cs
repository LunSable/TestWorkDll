using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace TestWorkDll
{

    public partial class MainWindow : Window
    {
        string path = @"";
        public MainWindow()
        {
            
            InitializeComponent();
            
            
        }
        public void DllRead(string pathAll)
        {
            DirectoryInfo File_get = new DirectoryInfo(pathAll);
            int count_f= File_get.GetFiles().Length;
            foreach (var file in File_get.GetFiles("*.dll"))
            {
                
                Assembly SampleAssembly = Assembly.LoadFrom(pathAll+@"/"+file.Name);
                TxBox.Text += file.Name + @"/";
                //Lab1.Content += SampleAssembly.GetName()+ "\n";
                foreach (Type oType in SampleAssembly.GetTypes())
                {
                    
                    TxBox.Text += oType.Name + "\n";
                        foreach (MemberInfo members in oType.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                        {
                                TxBox.Text += "    -" + members.Name + "\n";
                        }
                    
                }
            }
            

        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (TBox2.Text.Length>2)
            {
                path = TBox2.Text;
                DllRead(path);
            }
        }
    }
}
