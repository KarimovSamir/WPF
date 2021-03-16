using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Movie.Model;
using Movie.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Movie.ViewModel
{
    class AppViewModel : ViewModelBase
    {
        private string input = "Batman";
        public string Input { get => input; set => Set(ref input, value); }

        private Movies selected;
        public Movies Selected
        {
            get => selected;
            set
            {
                Set(ref selected, value);
                var movie = movieSearch.FullInfo(Selected.Id);
                Selected.Year = movie.Year;
                Selected.Genre = movie.Genre;
                Selected.Plot = movie.Plot;
                Selected.Poster = movie.Poster;
            }
        }

        private ObservableCollection<Movies> list = new ObservableCollection<Movies>();
        public ObservableCollection<Movies> List { get => list; set => Set(ref list, value); }

        private readonly IMovieSearch movieSearch;

        public AppViewModel(IMovieSearch movieSearch)
        {
            this.movieSearch = movieSearch;
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get => searchCommand ?? (searchCommand = new RelayCommand(
                () => List = new ObservableCollection<Movies>(movieSearch.Search(Input))
            ));
        }
    }
}
