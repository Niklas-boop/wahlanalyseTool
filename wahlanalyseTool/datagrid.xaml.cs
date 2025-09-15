using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaktionslogik für datagrid.xaml
    /// </summary>
    public partial class datagrid : Window
    {
        public datagrid()
        {
            InitializeComponent();
            LoadCsvFile();
        }
        private void LoadCsvFile()
        {
            string filePath = @"C:\Users\nmicr\Downloads\090-303-LRW-STMM(1).csv";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Datei wurde nicht gefunden!");
                return;
            }

            try
            {
                DataTable dataTable = ReadCsvToDataTable(filePath);
                csvDataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der CSV-Datei: " + ex.Message);
            }
        }

        private DataTable ReadCsvToDataTable(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var dataTable = new DataTable();

            // Automatisches Erkennen des Trennzeichens (Komma, Semikolon, Tab, etc.)
            char delimiter = DetectDelimiter(lines);

            // Erste Zeile = Spaltennamen
            string[] headers = lines[0].Split(delimiter);

            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }

            // Restliche Zeilen einfügen
            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(delimiter);

                // Falls Zeile weniger Spalten hat, auffüllen
                while (fields.Length < headers.Length)
                {
                    fields = fields.Concat(new string[] { "" }).ToArray();
                }

                // Falls Zeile mehr Spalten hat, abschneiden
                if (fields.Length > headers.Length)
                {
                    fields = fields.Take(headers.Length).ToArray();
                }

                dataTable.Rows.Add(fields);
            }

            return dataTable;
        }

        private char DetectDelimiter(string[] lines)
        {
            char[] possibleDelimiters = { ';', ',', '\t', '|' };

            // Nimm die erste Zeile und zähle die Trennzeichen
            string firstLine = lines[0];
            char bestDelimiter = ';';
            int maxCount = 0;

            foreach (var delimiter in possibleDelimiters)
            {
                int count = firstLine.Count(c => c == delimiter);
                if (count > maxCount)
                {
                    maxCount = count;
                    bestDelimiter = delimiter;
                }
            }

            return bestDelimiter;
        }
    
}
}
