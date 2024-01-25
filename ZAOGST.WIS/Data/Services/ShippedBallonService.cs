namespace ZAOGST.WIS.Data.Services;

public class ShippedBallonService : IShippedBallonService
{
	private readonly DataContext _context;

	public ShippedBallonService(DataContext context)
	{
		_context = context;
	}

	public List<ShippedBallon> ShippedBallons { get; set; } = new();

	public async Task Create(ShippedBallon shippedBallon)
	{
		ShippedBallon dbShippedBallon = new()
		{
			StrainGaugeNumber = shippedBallon.StrainGaugeNumber,
			BallonNumber = shippedBallon.BallonNumber,
			ShippedControlBlockId = shippedBallon.ShippedControlBlockId,
			ShippedControlBlock = shippedBallon.ShippedControlBlock,
			ShippingDate = shippedBallon.ShippingDate
		};

		await _context.ShippedBallons.AddAsync(dbShippedBallon);

		await _context.SaveChangesAsync();
	}

	public async Task Delete(int id)
	{
		var dbShippedBallon = await _context.ShippedBallons.FindAsync(id) ?? throw new Exception("Не удалось найти баллон.");
		_context.ShippedBallons.Remove(dbShippedBallon);
		await _context.SaveChangesAsync();
	}

	public async Task<ShippedBallon> GetById(int id)
	{
		var shippedBallon = await _context.ShippedBallons.FindAsync(id);

		//TODO: Сделать кастомные исключения
		return shippedBallon ?? throw new Exception("Не удалось найти баллон.");
	}

	public async Task<ShippedBallon> GetByStrainGaugeNumber(int strainGaugeNumber)
	{
		var shippedBallon = await _context.ShippedBallons.FirstOrDefaultAsync(x => x.StrainGaugeNumber == strainGaugeNumber);
		return shippedBallon;
	}

	public async Task Load() => ShippedBallons = await _context.ShippedBallons.AsNoTracking().ToListAsync();

	public async Task Update(ShippedBallon shippedBallon, int id)
	{
		var dbShippedBallon = await _context.ShippedBallons.FindAsync(id) ?? throw new Exception("Не удалось найти баллон.");

		dbShippedBallon.StrainGaugeNumber = shippedBallon.StrainGaugeNumber;
		dbShippedBallon.BallonNumber = shippedBallon.BallonNumber;

		await _context.SaveChangesAsync();
	}
}
