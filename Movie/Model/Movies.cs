using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Model
{
    class Movies : ObservableObject
    {
        private string title;
        public string Title { get => title; set => Set(ref title, value); }

        private string poster;
        public string Poster { get => poster; set => Set(ref poster, value); }

        private string year;
        public string Year { get => year; set => Set(ref year, value); }

        private string genre;
        public string Genre { get => genre; set => Set(ref genre, value); }

        private string plot;
        public string Plot { get => plot; set => Set(ref plot, value); }

        private string id;
        public string Id { get => id; set => Set(ref id, value); }
    }
}
