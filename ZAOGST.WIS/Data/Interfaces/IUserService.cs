namespace ZAOGST.WIS.Data.Interfaces;

public interface IUserService
{
	List<User> Users { get; set; }
	Task LoadUsers();
	Task<User> GetSingleUserById(int id);
	Task<User> GetSingleUserByUsername(string Username);
	Task CreateUser(User user);
	Task UpdateUser(User user);
	Task DeleteUser(int id);
}
