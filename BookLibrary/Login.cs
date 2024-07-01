namespace BookLibrary
{
    public class Login
    {
        private string _name;
        private string _password;

        // _name və _password dəyərlərini əldə etmək üçün
        public string Name { get => _name; set => _name = value;}
        public string Password { get => _password; set => _password = value;}

        // Login obyekti yaradırıq və parametrlər veririk
        public Login(string userName, string userPassword)
        {
            _name = userName;
            _password = userPassword;
        }

        // Login obyektini mətnə çevirmək üçün
        public override string ToString()
        {
            return $"İstifadəçi adı:{Name}\n İstifadəçi şifrəsi: {Password}";
        }

    }
}
