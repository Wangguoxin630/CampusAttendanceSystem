namespace CampusAttendanceSystem.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtStudentId.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            await Shell.Current.GoToAsync("//CheckPage");
        }
        else
        {
            await DisplayAlert("Notice", "Please fill all fields", "OK");
        }
    }
}