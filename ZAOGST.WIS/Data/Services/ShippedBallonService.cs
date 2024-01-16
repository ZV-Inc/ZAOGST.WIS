namespace ZAOGST.WIS.Data.Services;

public class ShippedBallonService : IShippedBallonService
{
	private readonly DataContext _context;

	public ShippedBallonService(DataContext context)
	{
		_context = context;
	}

	public List<ShippedBallon> ShippedBallons { get; set; } = new();

	public async Task CreateShippedBallon(ShippedBallon shippedBallon)
	{
		ShippedBallon dbShippedBallon = new()
		{
			StrainGaugeNumber = shippedBallon.StrainGaugeNumber,
			BallonNumber = shippedBallon.BallonNumber,
			ShippedControlBlockId = shippedBallon.ShippedControlBlockId,
			ShippedControlBlock = shippedBallon.ShippedControlBlock
		};

		await _context.ShippedBallons.AddAsync(dbShippedBallon);

		await _context.SaveChangesAsync();
	}

	public async Task DeleteShippedBallon(int id)
	{
		var dbShippedBallon = await _context.ShippedBallons.FindAsync(id) ?? throw new Exception("Не удалось найти баллон.");
		_context.ShippedBallons.Remove(dbShippedBallon);
		await _context.SaveChangesAsync();
	}

	public int GetLastShippedBallonNumber() => _context.ShippedBallons.Count();

	public async Task<ShippedBallon> GetSingleShippedBallonById(int id)
	{
		var shippedBallon = await _context.ShippedBallons.FindAsync(id);

		//TODO: Сделать кастомные исключения
		return shippedBallon ?? throw new Exception("Не удалось найти баллон.");
	}

	public async Task<ShippedBallon> GetSingleShippedBallonByStrainGaugeNumber(int strainGaugeNumber)
	{
		var shippedBallon = await _context.ShippedBallons.FirstOrDefaultAsync(x => x.StrainGaugeNumber == strainGaugeNumber);
		return shippedBallon;
	}

	public async Task LoadShippedBallon() => ShippedBallons = await _context.ShippedBallons.AsNoTracking().ToListAsync();

	public async Task UpdateShippedBallon(ShippedBallon shippedBallon, int id)
	{
		var dbShippedBallon = await _context.ShippedBallons.FindAsync(id) ?? throw new Exception("Не удалось найти баллон.");

		dbShippedBallon.StrainGaugeNumber = shippedBallon.StrainGaugeNumber;
		dbShippedBallon.BallonNumber = shippedBallon.BallonNumber;

		await _context.SaveChangesAsync();
	}
}
