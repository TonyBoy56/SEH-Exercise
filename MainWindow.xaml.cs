using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.IO;
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
using SEH_America;

namespace SEH_America
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



        public void btnSubmit_Click()
        {
            string searchQuery = Request["imageTitle"];
            string searchQuery2 = Request["imageText"];
            string cx = "f45637bb92df9b998";
            string apiKey = "AIzaSyAC7p2GdBwS-1Lj8SjSL5tmpPHc-RX93ak";
            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + searchQuery);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamGeometry dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader();
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);

            var results = new List<Result>();
            foreach (var item in jsonData.items)
            {
                results.Add(new Result
                    {
                        Title = item.title,
                        Link = item.link,
                        Snippet = item.snippet,
                });
            }

            return MainWindow();
        }
    }
}
