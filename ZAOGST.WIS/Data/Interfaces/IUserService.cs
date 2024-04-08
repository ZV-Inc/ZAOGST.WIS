namespace ZAOGST.WIS.Data.Interfaces;

public interface IUserService
{
	Task Create(User user);
	Task Update(User user);
	Task Delete(int id);
	Task<User> GetById(int id);
	Task<User> GetByUsername(string Username);
	Task<List<User>> GetList();
}
