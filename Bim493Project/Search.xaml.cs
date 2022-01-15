using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.Search;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bim493Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        ApiConnector apiConnector = new ApiConnector();
        public Search()
        {
            InitializeComponent();
          
            //  this.BindingContext=ai
            this.BindingContext = apiConnector.getlist("Lord of the Rings","");
            //SearchType.ItemsSource = apiConnector.getGenres();
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            List < SearchMovie > movies = apiConnector.getlist(entry_for_search_movie.Text.ToString(), "");
            if (movies.Count < 1)
            {
                App.Current.MainPage.DisplayAlert("No Record Found", "Please check movie name", "OK");

            }
            else
            {
                this.BindingContext = movies;
            }
           
           
        }
    }
}