namespace ZAOGST.WIS.Data.Services;

public class UserService : IUserService
{
	private readonly DataContext _context;

	public UserService(DataContext context) => _context = context;

	public async Task Create(User user)
	{
		await _context.Users.AddAsync(user);
		await _context.SaveChangesAsync();
	}

	public async Task Update(User user)
	{
		var dbUser = await _context.Users.Where(u => u.Id == user.Id).SingleOrDefaultAsync() ?? throw new UserNotFoundException();

		dbUser.Username = user.Username;
		dbUser.Password = user.Password;
		dbUser.Role = user.Role;
		dbUser.DateUpdated = user.DateUpdated;

		_context.Users.Update(dbUser);
		await _context.SaveChangesAsync();
	}

	public async Task Delete(int id)
	{
		var dbUser = await _context.Users.FindAsync(id) ?? throw new UserNotFoundException();
		_context.Users.Remove(dbUser);
		await _context.SaveChangesAsync();
	}

	public async Task<User> GetById(int id) => await _context.Users.FirstOrDefaultAsync(x => x.Id == id) ?? throw new UserNotFoundException();

	public async Task<User> GetByUsername(string Username) => await _context.Users.FirstOrDefaultAsync(x => x.Username == Username) ?? throw new UserNotFoundException();

	public async Task<List<User>> GetList() => await _context.Users.AsNoTracking().ToListAsync();
}
