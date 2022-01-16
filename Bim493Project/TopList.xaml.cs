using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bim493Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopList : ContentPage
    {
        ApiConnector apiConnector = new ApiConnector();
        public TopList()
        {
            InitializeComponent();
           
            //  this.BindingContext=ai
            this.BindingContext = apiConnector.getTrending(TMDbLib.Objects.Trending.TimeWindow.Week);


        }

      

        private void PickerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (PickerType.SelectedItem.ToString())
            {
                case "Week":
                    this.BindingContext = apiConnector.getTrending(TMDbLib.Objects.Trending.TimeWindow.Week);
                    break;
                case "Day":
                    this.BindingContext = apiConnector.getTrending(TMDbLib.Objects.Trending.TimeWindow.Day);
                    break;
                default:
                    this.BindingContext = apiConnector.allTimeHigh();
                    break;
            }
        }
    }
}