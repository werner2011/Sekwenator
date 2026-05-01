using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Text;

namespace Sekwenator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CountButton_Click(object? sender, RoutedEventArgs e)
        {
            TextBox inputTextBox = this.FindControl<TextBox>("InputTextBox");
            TextBlock resultTextBlock = this.FindControl<TextBlock>("ResultTextBlock");

            string dna = inputTextBox.Text;
            dna = dna.ToUpper();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            for (int i = 0; i <= dna.Length - 4; i++)
            {
                string fragment = dna.Substring(i, 4);

                if (counts.ContainsKey(fragment))
                {
                    counts[fragment] = counts[fragment] + 1;
                }
                else
                {
                    counts[fragment] = 1;
                }
            }

            StringBuilder result = new StringBuilder();

            foreach (var item in counts)
            {
                result.AppendLine(item.Key + " : " + item.Value);
            }

            resultTextBlock.Text = result.ToString();
        }
    }
}