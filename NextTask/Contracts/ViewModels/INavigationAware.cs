namespace NextTask.Contracts.ViewModels;

public interface INavigationAware
{
    void OnNavigatedTo(object parameter);

    void OnNavigatedFrom();
}
