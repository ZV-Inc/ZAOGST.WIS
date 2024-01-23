namespace ZAOGST.WIS.Data.Services;

public class BallonService : IBallonService
{
	private readonly DataContext _context;

	public BallonService(DataContext context)
	{
		_context = context;
	}

	public List<Ballon> Ballons { get; set; } = new();

	public async Task CreateBallon(Ballon ballon)
	{
		_context.Ballons.Add(ballon);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteBallon(int id)
	{
		var dbBallon = await _context.Ballons.FindAsync(id) ?? throw new Exception("Не удалось найти баллон.");
		_context.Ballons.Remove(dbBallon);
		await _context.SaveChangesAsync();
	}

	public int GetLastBallonNumber() => _context.Ballons.Count();

	public async Task<Ballon> GetSingleBallonById(int id)
	{
		var ballon = await _context.Ballons.FindAsync(id);

		//TODO: Сделать кастомные исключения
		return ballon ?? throw new Exception("Не удалось найти баллон.");
	}

	public async Task<Ballon> GetSingleBallonByStrainGaugeNumber(int strainGaugeNumber)
	{
		var ballon = await _context.Ballons.FirstOrDefaultAsync(x => x.StrainGaugeNumber == strainGaugeNumber) ?? throw new Exception("Не удалось найти баллон.");
		return ballon;
	}

	public async Task LoadBallon() => Ballons = await _context.Ballons.AsNoTracking().ToListAsync();

	public async Task UpdateBallon(Ballon ballon)
	{
		var dbBallon = await _context.Ballons.Where(b => b.Id == ballon.Id).SingleOrDefaultAsync() ?? throw new Exception("Не удалось найти баллон.");

		dbBallon.StrainGaugeNumber = ballon.StrainGaugeNumber;
		dbBallon.BallonNumber = ballon.BallonNumber;
		dbBallon.ControlBlockId = ballon.ControlBlockId;
		dbBallon.ControlBlock = ballon.ControlBlock;

		//_context.ChangeTracker.Clear();
		await _context.SaveChangesAsync();

		//var dbBallon = await _context.Ballons.FindAsync(id) ?? throw new Exception("Не удалось найти баллон.");

		//dbBallon.StrainGaugeNumber = ballon.StrainGaugeNumber;
		//dbBallon.BallonNumber = ballon.BallonNumber;

		//await _context.SaveChangesAsync();
	}
}
