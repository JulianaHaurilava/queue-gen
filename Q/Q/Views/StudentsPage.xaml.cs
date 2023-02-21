using Q.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Q.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsPage : ContentPage
    {
        StudentsViewModel _viewModel;

        public StudentsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new StudentsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}