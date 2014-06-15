using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Linq;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using InstrumentExplorer.ViewModels;
using Telerik.Windows.Controls;
using Microsoft.Phone.Net.NetworkInformation;

namespace InstrumentExplorer
{
    public partial class MainPivotPage : PhoneApplicationPage
    {
        string instrumentName;

        public MainPivotPage()
        {
            InitializeComponent();

            DataContext = App.ViewModel.SelectedInstrument;

            imageImage.Source = App.ViewModel.SelectedInstrument.InstImage;
            classification.Text = App.ViewModel.SelectedInstrument.HbsCategory + " >\n " +
                              App.ViewModel.SelectedInstrument.HbsSubcategory + " > ";



            if (NetworkInterface.GetIsNetworkAvailable())
            {
                instrumentName = App.ViewModel.SelectedInstrument.Name;
                if (instrumentName == "Serpent") instrumentName = "Serpent instrument";
                //search youtube for videos of "instrument name"
                var wc = new WebClient();
                wc.DownloadStringCompleted += DownloadStringCompleted;
                var searchUri = string.Format(
                  "http://gdata.youtube.com/feeds/api/videos?q={0}&format=6", instrumentName);
                wc.DownloadStringAsync(new Uri(searchUri));
            }
            else
            {
                noInternetWarning.Visibility = Visibility.Visible;
            }
            
            
 

        }

        void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
            {
              var atomns = XNamespace.Get("http://www.w3.org/2005/Atom");
              var medians = XNamespace.Get("http://search.yahoo.com/mrss/");
              var xml = XElement.Parse(e.Result);
              var videos = (
                from entry in xml.Descendants(atomns.GetName("entry"))
                select new YouTubeVideo{
                  VideoId = entry.Element(atomns.GetName("id")).Value,
                  VideoImageUrl = (
                    from thumbnail in entry.Descendants(medians.GetName("thumbnail"))
                    where thumbnail.Attribute("height").Value == "90"
                    select thumbnail.Attribute("url").Value).FirstOrDefault(),
                  Title = entry.Element(atomns.GetName("title")).Value}).ToArray();
              ResultsList.ItemsSource = videos;
            }

        //loads video, opens video player
        public async void ResultsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            YouTubeVideo youtube = ResultsList.SelectedItem as YouTubeVideo;
            
            string[] delimiter = new string[]{"videos/"};
            string[] vidId = youtube.VideoId.Split(delimiter, StringSplitOptions.None);
            var videoUri = await MyToolkit.Multimedia.YouTube.GetVideoUriAsync(vidId[1], MyToolkit.Multimedia.YouTubeQuality.Quality480P);
            App.ViewModel.SelectedInstrument.YoutubeVideoUri = videoUri.Uri;

            NavigationService.Navigate(new Uri("/VideoPlayer.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}