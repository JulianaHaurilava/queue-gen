using Q.Models;
using Q.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Q.Views
{
    public partial class ConfirmLabPage : ContentPage
    {
        public Student Item { get; set; }
        public ConfirmLabPage()
        {
            InitializeComponent();
            BindingContext = new ConfirmLabViewModel();
        }
    }
}