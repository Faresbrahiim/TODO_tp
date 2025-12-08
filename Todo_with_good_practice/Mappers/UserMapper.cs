namespace Todo_with_good_practice.Mappers
{
    using Todo_with_good_practice.ViewModels;
    using Todo_with_good_practice.Models;

    public static class UserMapper
    {
        public static SessionUser MapLoginToUserSession(LoginVM vm)
        {
            return new SessionUser
            {
                Username = vm.UserName
            };
        }
        public static SessionUser MapRegisterToUserSession(RegisterVM vm)
        {
            return new SessionUser
            {
                Username = vm.UserName
            };
        }
    }
}
