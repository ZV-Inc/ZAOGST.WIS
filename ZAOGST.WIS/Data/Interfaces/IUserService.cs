namespace ZAOGST.WIS.Data.Interfaces;

public interface IUserService
{
	List<User> Users { get; set; }
	Task Load();
	Task<User> GetById(int id);
	Task<User> GetByUsername(string Username);
	Task Create(User user);
	Task Update(User user);
	Task Delete(int id);
}
