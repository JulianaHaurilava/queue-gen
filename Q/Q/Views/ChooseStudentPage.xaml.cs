using Q.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Q.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseStudentPage : ContentPage
    {
        ChooseStudentViewModel _viewModel;
        public ChooseStudentPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ChooseStudentViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}