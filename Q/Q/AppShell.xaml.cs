using Q.ViewModels;
using Q.Views;
using System;
using Xamarin.Forms;

namespace Q
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(QueueDetailPage), typeof(QueueDetailPage));
            Routing.RegisterRoute(nameof(NewQueuePage), typeof(NewQueuePage));
            Routing.RegisterRoute(nameof(NewStudentPage), typeof(NewStudentPage));
            Routing.RegisterRoute(nameof(ChooseStudentPage), typeof(ChooseStudentPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
