namespace Duyan.Models.ViewModels
{
   
    public class AuthPageViewModel
    {
        public LoginViewModel Login { get; set; } = new LoginViewModel();
        public SignUpViewModel SignUp { get; set; } = new SignUpViewModel();

        
        public bool ShowSignUp { get; set; } = false;
    }
}
