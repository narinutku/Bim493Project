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
        public TopList()
        {
            InitializeComponent();
            ApiConnector apiConnector = new ApiConnector();
            //  this.BindingContext=ai
            this.BindingContext = apiConnector.getTrending();

               //< pancakeView:PancakeView Margin = "30,5"
               // Padding = "10"
               // BackgroundColor = "Black"


               // CornerRadius = "10"
               // HeightRequest = "48" >

               // < Picker x: Name = "SearchType"  TextColor = "White"     BackgroundColor = "Black"
               //     FontSize = "Small"  TitleColor = "White" Title = "Type" HorizontalOptions = "FillAndExpand" >
      
               //           < Picker.Items >
      

               //           </ Picker.Items >
      
               //       </ Picker >
      
               //   </ pancakeView:PancakeView >
        }
    }
}