using Q.Models;
using Q.ViewModels;
using Xamarin.Forms;

namespace Q.Views
{
    public partial class NewStudentPage : ContentPage
    {
        public Student Item { get; set; }

        public NewStudentPage()
        {
            InitializeComponent();
            BindingContext = new NewStudentViewModel();
        }
    }
}