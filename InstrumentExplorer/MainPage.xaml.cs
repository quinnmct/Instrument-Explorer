using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using InstrumentExplorer.ViewModels;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using System.ComponentModel;

namespace InstrumentExplorer
{
    public partial class MainPage : PhoneApplicationPage
    {
        List<InstrumentViewModel> names;
        List<string> pickerItems;
        GenericGroupDescriptor<InstrumentViewModel, string> groupName;


        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = App.ViewModel;


			//Shows the rate reminder message, according to the settings of the RateReminder.
            (App.Current as App).rateReminder.Notify();

            names = new List<InstrumentViewModel>();
            foreach (InstrumentViewModel i in App.ViewModel.Instruments)
            {
                if (!names.Contains(i))
                {
                    names.Add(i);
                }
            }
            
            pickerItems = new List<string>();
            foreach (InstrumentViewModel c in App.ViewModel.Instruments)
            {
                if(!pickerItems.Contains(c.Name.Substring(0,1).ToUpper())){
                    pickerItems.Add(c.Name.Substring(0,1).ToUpper());
                }
            }
            groupName =  new GenericGroupDescriptor<InstrumentViewModel, string>(c => c.Name.Substring(0,1).ToUpper());

            pickerItems.Sort();
            this.jumpList.ItemsSource = names;//List<InstrumentViewModel>
            this.jumpList.GroupPickerItemsSource = pickerItems;//List<string>
            this.jumpList.GroupDescriptors.Add(groupName);//GenericGroupDescriptor<InstrumentViewModel,string>
            
        }



        //RadDataBoundListBox SelectionChanged
        public void SelectedEventChanged(object sender, SelectionChangedEventArgs e)
        {

            //if event is removed, this event-handler fires. this prevents null reference errors
            if ((sender as RadDataBoundListBox).SelectedItem != null)
            {
                var selectedEvent = ((sender as RadDataBoundListBox).SelectedItem as InstrumentViewModel);
                App.ViewModel.SelectedInstrument = selectedEvent as InstrumentViewModel;

                NavigationService.Navigate(new Uri("/MainPivotPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        //This event fires when the user selects the previously selected item
        private void SelectedEventSame(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var selectedEvent = ((sender as RadDataBoundListBox).SelectedItem as InstrumentViewModel);
            App.ViewModel.SelectedInstrument = selectedEvent as InstrumentViewModel;

            NavigationService.Navigate(new Uri("/MainPivotPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void jumpList_GroupPickerItemTap(object sender, GroupPickerItemTapEventArgs e)
        {
            foreach (DataGroup group in this.jumpList.Groups)
                {
                    if (object.Equals(e.DataItem, group.Key))
                    {
                        e.DataItemToNavigate = group;
                        return;
                    }
                }
        }

        private void jumpList_ItemTap(object sender, ListBoxItemTapEventArgs e)
        {
            if ((sender as RadJumpList).SelectedItem != null)
            {
               /* var selectedEvent = ((sender as RadJumpList).SelectedItem as InstrumentViewModel);
                App.ViewModel.SelectedInstrument = selectedEvent as InstrumentViewModel;*/

                var selected = e.Item.Content;
                App.ViewModel.SelectedInstrument = selected as InstrumentViewModel;

                NavigationService.Navigate(new Uri("/MainPivotPage.xaml", UriKind.RelativeOrAbsolute));
            }
           //MessageBox.Show(e.Item.Content.ToString());
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            //abc
            
            List<string> pickerItems = new List<string>();
            foreach (InstrumentViewModel c in App.ViewModel.Instruments)
            {
                if(!pickerItems.Contains(c.Name.Substring(0,1).ToUpper())){
                    pickerItems.Add(c.Name.Substring(0,1).ToUpper());
                }
            }
            GenericGroupDescriptor<InstrumentViewModel, string> groupName =  new
            GenericGroupDescriptor<InstrumentViewModel, string>(c => c.Name.Substring(0,1).ToUpper());


            this.jumpList.GroupPickerItemsSource = null;
            this.jumpList.GroupDescriptors.Clear();

            pickerItems.Sort();
            this.jumpList.GroupPickerItemsSource = pickerItems;//List<string>
            this.jumpList.GroupDescriptors.Add(groupName);//GenericGroupDescriptor<InstrumentViewModel,string>
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            //hornbell
            
            List<string> pickerItems = new List<string>();
            foreach (InstrumentViewModel c in App.ViewModel.Instruments)
            {
                if(!pickerItems.Contains(c.HbsCategory)){
                    pickerItems.Add(c.HbsCategory);
                }
            }
            groupName =  new GenericGroupDescriptor<InstrumentViewModel, string>(c => c.HbsCategory);
            
            this.jumpList.GroupPickerItemsSource = null;
            this.jumpList.GroupDescriptors.Clear();

            pickerItems.Sort();
            this.jumpList.GroupPickerItemsSource = pickerItems;//List<string>
            this.jumpList.GroupDescriptors.Add(groupName);//GenericGroupDescriptor<InstrumentViewModel,string>
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            //country
            
            List<string> pickerItems = new List<string>();
            foreach (InstrumentViewModel c in App.ViewModel.Instruments)
            {
                if(!pickerItems.Contains(c.CountryOfOrigin)){
                    pickerItems.Add(c.CountryOfOrigin);
                }
            }
            GenericGroupDescriptor<InstrumentViewModel, string> groupName =  new
            GenericGroupDescriptor<InstrumentViewModel, string>(c => c.CountryOfOrigin);
            
            this.jumpList.GroupPickerItemsSource = null;
            this.jumpList.GroupDescriptors.Clear();

            //this.jumpList.GroupPickerItemsPanel.

            pickerItems.Sort();
            this.jumpList.GroupPickerItemsSource = pickerItems;//List<string>
            this.jumpList.GroupDescriptors.Add(groupName);//GenericGroupDescriptor<InstrumentViewModel,string>


        }
    }
}
