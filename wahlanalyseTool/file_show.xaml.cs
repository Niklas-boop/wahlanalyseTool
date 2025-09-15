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

namespace wahlanalyseTool
{
    /// <summary>
    /// Interaktionslogik für file_show.xaml
    /// </summary>
    public partial class file_show : Window
    {
        public file_show()
        {
            InitializeComponent();
            LoadCsvFile();
        }

        private void LoadCsvFile()
        {
            // Pfad zur Datei anpassen
            string filePath = @"C:\Pfad\zu\csv_090-303-LRW-STMM(3).csv";

            if (File.Exists(filePath))
            {
                // Inhalt als Text laden
                string content = File.ReadAllText(filePath);

                // Text in die TextBox setzen
                txtCsvContent.Text = content;
            }
            else
            {
                MessageBox.Show("Datei wurde nicht gefunden!");
            }
        }
    }
}
