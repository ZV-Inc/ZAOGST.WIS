namespace ZAOGST.WIS.Data.Services;

public class BallonService : IBallonService
{
	private readonly DataContext _context;

	public BallonService(DataContext context)
	{
		_context = context;
	}

	public List<Ballon> Ballons { get; set; } = new();

	public async Task Load() => Ballons = await _context.Ballons.AsNoTracking().ToListAsync();

	public async Task<Ballon> GetById(int id)
	{
		var ballon = await _context.Ballons.FindAsync(id);

		return ballon ?? throw new BallonNotFoundException();
	}

	public async Task<Ballon> GetByStrainGaugeNumber(int strainGaugeNumber)
	{
		var ballon = await _context.Ballons.FirstOrDefaultAsync(x => x.StrainGaugeNumber == strainGaugeNumber) ?? throw new BallonNotFoundException();
		return ballon;
	}

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

		await _context.SaveChangesAsync();
	}

	public async Task Delete(int id)
	{
		var dbBallon = await _context.Ballons.FindAsync(id) ?? throw new BallonNotFoundException();
		_context.Ballons.Remove(dbBallon);
		await _context.SaveChangesAsync();
	}
}
