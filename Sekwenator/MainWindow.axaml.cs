using Avalonia.Controls; //daje dostep do elementow okna 
using Avalonia.Interactivity; 
using System.Collections.Generic; //daje dostep do obslugi klikniecia przycisku 
using System.Text;

namespace Sekwenator
{
    public partial class MainWindow : Window
    {
        public MainWindow() //MainWindows jest oknem aplikacji 
        {
            InitializeComponent(); 
        }

        private void CountButton_Click(object? sender, RoutedEventArgs e) //metoda klikniecia przycisku 
        {
            //pobranie kontrolek z okna: 
            TextBox inputTextBox = this.FindControl<TextBox>("InputTextBox"); 
            TextBlock resultTextBlock = this.FindControl<TextBlock>("ResultTextBlock");

            string dna = inputTextBox.Text; //pobranie sekwencji z wejœcia 
            dna = dna.ToUpper(); //zamiana na duze litery 
            //Slownik klucz-wartosc na zliczanie fragmentow 
            //kluczem jest tekst, a waroscia liczba calkowita zgodnie z <string,int> 
            Dictionary<string, int> counts = new Dictionary<string, int>();

            //petla for po sekwencji 
            for (int i = 0; i <= dna.Length - 4; i++)
            {
                string fragment = dna.Substring(i, 4); //wycinanie 4-nukleotydowego fragmentu z sekwencji, za pomoc¹ Substring 

                if (counts.ContainsKey(fragment)) //sprawdzenie czy fragment siê ju¿ pojawil? 
                {
                    counts[fragment] = counts[fragment] + 1; //zliczenie fragmentu, jesli pojawil siê wczesniej
                }
                else
                {
                    counts[fragment] = 1;
                }
            }

            StringBuilder result = new StringBuilder();

            foreach (var item in counts) //petla foreach po elementach slownika i wypisanie wyników 
            {
                result.AppendLine(item.Key + " : " + item.Value);
            }

            resultTextBlock.Text = result.ToString(); //zamiana na tekst 
        }
    }
}