namespace ZAOGST.WIS.Data.Services;

public class BallonService : IBallonService
{
	private readonly DataContext _context;

	public BallonService(DataContext context) => _context = context;

	public async Task Create(Ballon ballon)
	{
		_context.Ballons.Add(ballon);
		await _context.SaveChangesAsync();
	}

	public async Task Update(Ballon ballon)
	{
		var dbBallon = await _context.Ballons.Where(b => b.Id == ballon.Id).SingleOrDefaultAsync() ?? throw new BallonNotFoundException();

		dbBallon.StrainGaugeNumber = ballon.StrainGaugeNumber;
		dbBallon.BallonNumber = ballon.BallonNumber;
		dbBallon.ControlBlockId = ballon.ControlBlockId;
		dbBallon.ControlBlock = ballon.ControlBlock;
		dbBallon.DateUpdated = ballon.DateUpdated;

		await _context.SaveChangesAsync();
	}

	public async Task Delete(int id)
	{
		var dbBallon = await _context.Ballons.FindAsync(id) ?? throw new BallonNotFoundException();
		_context.Ballons.Remove(dbBallon);
		await _context.SaveChangesAsync();
	}

	public async Task<Ballon> GetById(int id) => await _context.Ballons.FindAsync(id) ?? throw new BallonNotFoundException();

	public async Task<List<Ballon>> GetList() => await _context.Ballons.AsNoTracking().ToListAsync();
}
