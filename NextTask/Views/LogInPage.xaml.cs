using Microsoft.UI.Xaml.Controls;

using NextTask.ViewModels;

namespace NextTask.Views;

public sealed partial class LogInPage : Page
{
    public LogInViewModel ViewModel
    {
        get;
    }

    public LogInPage()
    {
        ViewModel = App.GetService<LogInViewModel>();
        InitializeComponent();
    }

    private async void Login_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUserName.Text))
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Warning",
                Content = "User name is required.",
                CloseButtonText = "OK",
                XamlRoot = this.Content.XamlRoot
            };

            await dialog.ShowAsync();
        }

        else if (string.IsNullOrEmpty(txtPassword.Text))
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Warning",
                Content = "Password is required.",
                CloseButtonText = "OK",
                XamlRoot = this.Content.XamlRoot
            };

            await dialog.ShowAsync();
        }

        if (!string.IsNullOrWhiteSpace(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
        {
            if (txtUserName.Text == "admin" && txtPassword.Text == "1234")
            {
                var shellViewModel = App.GetService<ShellViewModel>();
                App.MainWindow.Content = new ShellPage(shellViewModel);
            }
            else
            {
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Login Failed",
                    Content = "Invalid username or password.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                _ = dialog.ShowAsync();
            }
        }
        

    }

    private void btnSignUp_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        var signUpViewModel = App.GetService<SignUpViewModel>();
        App.MainWindow.Content = new SignUpPage(signUpViewModel);
    }
}
