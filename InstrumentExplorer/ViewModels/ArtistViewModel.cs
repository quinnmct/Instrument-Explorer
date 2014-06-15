using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrumentExplorer.ViewModels
{
    public class ArtistViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Link { get; set; }

        public ArtistViewModel()
        {
            Link = "http://www.wikipedia.org/wiki/"+Name;
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
