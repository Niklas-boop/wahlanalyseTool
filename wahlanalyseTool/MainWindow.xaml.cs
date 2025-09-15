using System;
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

namespace wahlanalyseTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Start_programm_Click(object sender, RoutedEventArgs e)
        {
            int selected = 0;
            selected = Cbox_select_workload.SelectedIndex;

            switch (selected)
            {
                case -1:
                    MessageBox.Show("Kein Element ausgewählt.");
                    break;
                case 0:
                    file_show File_show =new file_show();
                    File_show.Show();
                    break;
                case 1:
                    datagrid Datagrid = new datagrid();
                    Datagrid.Show();
                    break;
                default:
                    //AnzeigeText.Text = $"Ein anderes Element wurde ausgewählt. Index: {index}";
                    break;
            }
        }
    }
}