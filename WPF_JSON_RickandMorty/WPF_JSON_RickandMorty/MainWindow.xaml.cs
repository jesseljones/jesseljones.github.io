using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace WPF_JSON_RickandMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string url = "https://rickandmortyapi.com/api/character";


            while (url != null)

            {

                using (var client = new HttpClient())
                {
                    string jsonData = client.GetStringAsync(url).Result;

                    RickandMortyAPI api = JsonConvert.DeserializeObject<RickandMortyAPI>(jsonData);

                    foreach (var character in api.results)
                    {
                        lstCharacter.Items.Add(character);
                    }

                    url = api.info.next;
                }
            }
        }

        private void lstCharacter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCharacter = (Character)lstCharacter.SelectedItem;
            NewWindow imageWindow = new NewWindow();
            imageWindow.SelectedCharacter = selectedCharacter;
            imageWindow.GetImage(selectedCharacter);
            imageWindow.Show();

            
        
        }
    }
}
