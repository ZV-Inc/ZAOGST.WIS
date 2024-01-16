namespace ZAOGST.WIS.Data.Services;

public class ShippedControlBlockService : IShippedControlBlockService
{
	private readonly DataContext _context;

	public ShippedControlBlockService(DataContext context)
	{
		_context = context;
		_context.Database.EnsureCreated();
	}

	public List<ShippedControlBlock> ShippedControlBlocks { get; set; } = new();

	public async Task<ShippedControlBlock?> CreateShippedControlBlock(ShippedControlBlock shippedControlBlock)
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

		return await _context.ShippedControlBlocks.FirstOrDefaultAsync(x => x.Id == dbShippedControlBlock.Id);
		//_context.ShippedControlBlocks.Add(shipment);
		//await _context.SaveChangesAsync();
	}

	public async Task DeleteShippedControlBlock(int id)
	{
		var dbShippedControlBlock = await _context.ShippedControlBlocks.Include("ShippedBallons").FirstOrDefaultAsync(scb => scb.Id == id) ?? throw new Exception("Не удалось найти блок управления.");

		if (dbShippedControlBlock.ShippedBallons != null && dbShippedControlBlock.ShippedBallons.Count > 0)
			foreach (ShippedBallon shippedBallon in dbShippedControlBlock.ShippedBallons)
				_context.ShippedBallons.Remove(shippedBallon);

		_context.ShippedControlBlocks.Remove(dbShippedControlBlock);

		await _context.SaveChangesAsync();
	}

	public int GetLastShippedControlBlockNumber() => _context.ShippedControlBlocks.Count();

	public async Task<int> GetLastShippedControlBlockId()
	{
		ShippedControlBlock? shippedControlBlock = await _context.ShippedControlBlocks.OrderByDescending(x => x.Id).LastOrDefaultAsync();

		return shippedControlBlock == null ? throw new Exception("ShippedControlBlocks entries is empty") : shippedControlBlock.Id;
	}

	public async Task<ShippedControlBlock> GetSingleShippedControlBlock(int id)
	{
		var shipment = await _context.ShippedControlBlocks.Include("ShippedBallons").FirstOrDefaultAsync(scb => scb.Id == id);

		//TODO: Сделать кастомные исключения
		return shipment ?? throw new Exception("Не удалось найти блок управления.");
	}

	public async Task LoadShippedControlBlock()
	{
		ShippedControlBlocks = await _context.ShippedControlBlocks.AsNoTracking().Include("ShippedBallons").ToListAsync();
	}

	public async Task UpdateShippedControlBlock(ShippedControlBlock shipment/*, int id*/)
	{
		//var dbShipment = await _context.ShippedControlBlocks.Include("ShippedBallons").FirstOrDefaultAsync(scb => scb.Id == id) ?? throw new Exception("Не удалось найти блок управления.");
		var dbShipment = await _context.ShippedControlBlocks.Include("ShippedBallons").FirstOrDefaultAsync(scb => scb.Id == shipment.Id) ?? throw new Exception("Не удалось найти блок управления.");

		dbShipment.Number = shipment.Number;
		dbShipment.Type = shipment.Type;

		await _context.SaveChangesAsync();
	}
}
