using Microsoft.UI.Xaml.Controls;

using NextTask.ViewModels;

namespace NextTask.Views;

public sealed partial class SignUpPage : Page
{
    public SignUpViewModel ViewModel
    {
        get;
    }

    public SignUpPage()
    {
        ViewModel = App.GetService<SignUpViewModel>();
        InitializeComponent();
    }
}
