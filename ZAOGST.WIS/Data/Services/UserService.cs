namespace ZAOGST.WIS.Data.Services;

public class UserService : IUserService
{
	private readonly DataContext _context;

	public UserService(DataContext context) => _context = context;

	public List<User> Users { get; set; }

	public async Task CreateUser(User user)
	{
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteUser(int id)
	{
		var dbUser = await _context.Users.FindAsync(id) ?? throw new Exception("Не удалось найти пользователя.");
		_context.Users.Remove(dbUser);
		await _context.SaveChangesAsync();
	}

	public async Task<User> GetSingleUserById(int id) => await _context.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Не удалось найти пользователя.");

	public async Task<User> GetSingleUserByUsername(string Username) => await _context.Users.FirstOrDefaultAsync(x => x.Username == Username) ?? throw new Exception("Не удалось найти пользователя.");

	public async Task LoadUsers() => Users = await _context.Users.AsNoTracking().ToListAsync();

	public async Task UpdateUser(User user)
	{
		var dbUser = await _context.Users.Where(u => u.Id == user.Id).SingleOrDefaultAsync() ?? throw new Exception("Не удалось найти пользователя.");

		dbUser.Username = user.Username;
		dbUser.Password = user.Password;
		dbUser.Token = user.Token;

		_context.Users.Update(dbUser);
		await _context.SaveChangesAsync();
	}
}
