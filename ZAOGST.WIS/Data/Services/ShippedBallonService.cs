namespace ZAOGST.WIS.Data.Services;

public class ShippedBallonService : IShippedBallonService
{
	private readonly DataContext _context;

	public ShippedBallonService(DataContext context) => _context = context;

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

	public async Task Update(ShippedBallon shippedBallon, int id)
	{
		var dbShippedBallon = await _context.ShippedBallons.FindAsync(id) ?? throw new BallonNotFoundException();

		dbShippedBallon.StrainGaugeNumber = shippedBallon.StrainGaugeNumber;
		dbShippedBallon.BallonNumber = shippedBallon.BallonNumber;

		await _context.SaveChangesAsync();
	}

	public async Task Delete(int id)
	{
		var dbShippedBallon = await _context.ShippedBallons.FindAsync(id) ?? throw new BallonNotFoundException();
		_context.ShippedBallons.Remove(dbShippedBallon);
		await _context.SaveChangesAsync();
	}

	public async Task<ShippedBallon> GetById(int id) => await _context.ShippedBallons.FindAsync(id) ?? throw new BallonNotFoundException();

	public async Task<ShippedBallon> GetByStrainGaugeNumber(int strainGaugeNumber) => await _context.ShippedBallons.FirstOrDefaultAsync(x => x.StrainGaugeNumber == strainGaugeNumber) ?? throw new BallonNotFoundException();

	public async Task<List<ShippedBallon>> GetList() => await _context.ShippedBallons.AsNoTracking().ToListAsync();
}
