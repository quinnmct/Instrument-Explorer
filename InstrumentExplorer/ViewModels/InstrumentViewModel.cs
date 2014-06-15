using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace InstrumentExplorer.ViewModels
{
    public class InstrumentViewModel : INotifyPropertyChanged
    {
        public InstrumentViewModel()
        {
            wikipediaLink ="http://www.wikipedia.org/wiki/" + name;
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }
        
        private BitmapImage instImage;
        public BitmapImage InstImage
        {
            get
            {
                return instImage;
            }
            set
            {
                if (value != instImage)
                {
                    instImage = value;
                    NotifyPropertyChanged("InstImage");
                }
            }
        }

        private ObservableCollection<ArtistViewModel> artists;
        public ObservableCollection<ArtistViewModel> Artists
        {
            get
            {
                return artists;
            }
            set
            {
                if (value != artists)
                {
                    artists = value;
                    NotifyPropertyChanged("Artists");
                }
            }
        }

        private string countryOfOrigin;
        public string CountryOfOrigin
        {
            get
            {
                return countryOfOrigin;
            }
            set
            {
                if (value != countryOfOrigin)
                {
                    countryOfOrigin = value;
                    NotifyPropertyChanged("CountryOfOrigin");
                }
            }
        }

        private string hbsCategory;
        public string HbsCategory
        {
            get
            {
                return hbsCategory;
            }
            set
            {
                if (value != hbsCategory)
                {
                    hbsCategory = value;
                    NotifyPropertyChanged("HbsCategory");
                }
            }
        }

        private string hbsSubcategory;
        public string HbsSubcategory
        {
            get
            {
                return hbsSubcategory;
            }
            set
            {
                if (value != hbsSubcategory)
                {
                    hbsSubcategory = value;
                    NotifyPropertyChanged("HbsSubcategory");
                }
            }
        }


        private string wikipediaLink;
        public string WikipediaLink
        {
            get
            {
                return wikipediaLink;
            }
            set
            {
                if (value != wikipediaLink)
                {
                    wikipediaLink = value;
                    NotifyPropertyChanged("WikipediaLink");
                }
            }
        }

        private Uri youtubeVideoUri;
        public Uri YoutubeVideoUri
        {
            get
            {
                return youtubeVideoUri;
            }
            set
            {
                if (value != youtubeVideoUri)
                {
                    youtubeVideoUri = value;
                    NotifyPropertyChanged("YoutubeVideoUri");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
