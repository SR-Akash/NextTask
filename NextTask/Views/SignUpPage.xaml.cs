using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using NextTask.ViewModels;

namespace NextTask.Views;

public sealed partial class SignUpPage : Page
{
    public SignUpViewModel ViewModel
    {
        get;
    }

    public SignUpPage(SignUpViewModel viewModel)
    {
        ViewModel = App.GetService<SignUpViewModel>();
        InitializeComponent();
    }

    private void btnBack_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (App.MainWindow.Content is Frame rootFrame)
        {
            // Navigate back to LoginPage
            rootFrame.Navigate(typeof(LogInPage));
        }
        else
        {
            // If somehow the content is not a Frame, create one and navigate
            var newFrame = new Frame();
            App.MainWindow.Content = newFrame;
            newFrame.Navigate(typeof(LogInPage));
        }
    }

    private void SignUp_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtPassword.Text))
        {
            ContentDialog dialog = new ContentDialog
            {
                Title="Warning",
                Content="All fields are required",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot

            };
            _ = dialog.ShowAsync();
        }
    }
    
}
