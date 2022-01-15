using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.Search;
using Xamarin.Forms;

namespace Bim493Project
{
    public partial class MainPage : ContentPage
    {
        ApiConnector apiConnector = new ApiConnector();
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = apiConnector.getActorswithMovies("Dicaprio")[0].KnownFor;

        }

        private void SearchButtonForActor_Clicked(object sender, EventArgs e)
        {
            List <SearchPerson> list = apiConnector.getActorswithMovies(entry_for_actor.Text.ToString()) ;
            if (list.Count < 1) {
                App.Current.MainPage.DisplayAlert("No Record Found", "Please check your actor name", "OK");
            }
            else
            {
                this.BindingContext =  list[0].KnownFor;
            }
          
        }
    }
}
