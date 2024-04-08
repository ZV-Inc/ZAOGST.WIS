namespace ZAOGST.WIS.Data.Services;

public class ShippedControlBlockService : IShippedControlBlockService
{
	private readonly DataContext _context;

	public ShippedControlBlockService(DataContext context) => _context = context;

	public async Task<ShippedControlBlock> Create(ShippedControlBlock shippedControlBlock)
	{
		ShippedControlBlock dbShippedControlBlock = new()
		{
			Number = shippedControlBlock.Number,
			Type = shippedControlBlock.Type,
			ShippedBallons = shippedControlBlock.ShippedBallons,
			ShippingDate = shippedControlBlock.ShippingDate,
		};

		await _context.ShippedControlBlocks.AddAsync(dbShippedControlBlock);

		await _context.SaveChangesAsync();

		return await _context.ShippedControlBlocks.FirstOrDefaultAsync(x => x.Id == dbShippedControlBlock.Id) ?? throw new ShippedControlBlockNotFoundException();
	}

	public async Task Update(ShippedControlBlock shippedControlBlock)
	{
		var dbShippedControlBlock = await _context.ShippedControlBlocks.Include("ShippedBallons").FirstOrDefaultAsync(scb => scb.Id == shippedControlBlock.Id) ?? throw new ShippedControlBlockNotFoundException();

		dbShippedControlBlock.Number = shippedControlBlock.Number;
		dbShippedControlBlock.Type = shippedControlBlock.Type;
		dbShippedControlBlock.IsSended = shippedControlBlock.IsSended;
		dbShippedControlBlock.DateUpdated = shippedControlBlock.DateUpdated;

		await _context.SaveChangesAsync();
	}

	public async Task Delete(ShippedControlBlock shippedControlBlock)
	{
		var dbShippedControlBlock = await _context.ShippedControlBlocks.Include("ShippedBallons").FirstOrDefaultAsync(scb => scb.Id == shippedControlBlock.Id) ?? throw new ShippedControlBlockNotFoundException();

		if (dbShippedControlBlock.ShippedBallons != null && dbShippedControlBlock.ShippedBallons.Count > 0)
			foreach (ShippedBallon shippedBallon in dbShippedControlBlock.ShippedBallons)
				_context.ShippedBallons.Remove(shippedBallon);

		_context.ShippedControlBlocks.Remove(dbShippedControlBlock);

		await _context.SaveChangesAsync();
	}

	public async Task<ShippedControlBlock> GetById(int id) => await _context.ShippedControlBlocks.Include("ShippedBallons").FirstOrDefaultAsync(scb => scb.Id == id) ?? throw new ShippedControlBlockNotFoundException();

	public async Task<List<ShippedControlBlock>> GetList() => await _context.ShippedControlBlocks.AsNoTracking().Include("ShippedBallons").ToListAsync();

	public async Task<List<ShippedControlBlock>> GetSended() => await _context.ShippedControlBlocks.Where(x => x.IsSended).ToListAsync();

	public async Task<List<ShippedControlBlock>> GetNotSended() => await _context.ShippedControlBlocks.Where(x => !x.IsSended).ToListAsync();
}
