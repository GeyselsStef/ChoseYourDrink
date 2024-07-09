using ChooseYourDrink.Models;

namespace ChooseYourDrink.Services
{
    public interface IUserService
    {
        event Action OnChange;

        UserViewModel? CurrentUser { get; set; }

        Task<UserViewModel> GetUserAsync();
        Task SetUserAsync(UserViewModel user);
    }

    public class UserService : IUserService
    {
        public event Action? OnChange;

        private readonly IJSRunitmeServices _jSRunitmeServices;

        private UserViewModel? _currentUser;
        public UserViewModel? CurrentUser
        {
            get => _currentUser; set
            {
                _currentUser = value;
                OnChange?.Invoke();
            }
        }

        public UserService(IJSRunitmeServices jSRunitmeServices)
        {
            _jSRunitmeServices = jSRunitmeServices;

            //GetUserAsync().ContinueWith(task =>
            //{
            //    CurrentUser = task.Result;
            //    OnChange?.Invoke();
            //});
        }

        public async Task<UserViewModel> GetUserAsync()
        {
            UserViewModel user = await _jSRunitmeServices.GetItemAsync<UserViewModel>("user");
            CurrentUser = user;
            return user;
        }

        public async Task SetUserAsync(UserViewModel user)
        {
            await _jSRunitmeServices.SetItemAsync("user", user);
            CurrentUser = user;
        }
    }
}
