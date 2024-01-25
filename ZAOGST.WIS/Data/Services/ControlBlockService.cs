﻿namespace ZAOGST.WIS.Data.Services;

public class ControlBlockService : IControlBlockService
{
	private readonly DataContext _context;

	public ControlBlockService(DataContext context)
	{
		_context = context;
		//_context.Database.EnsureCreated();
	}

	public List<ControlBlock> ControlBlocks { get; set; } = new();

	public async Task<ControlBlock?> Create(ControlBlock controlBlock)
	{
		ControlBlock dbControlBlock = new()
		{
			Number = controlBlock.Number,
			Type = controlBlock.Type,
			Ballons = controlBlock.Ballons,
			ShippingDate = controlBlock.ShippingDate,
		};

		await _context.ControlBlocks.AddAsync(dbControlBlock);

		await _context.SaveChangesAsync();

		return await _context.ControlBlocks.FirstOrDefaultAsync(x => x.Id == dbControlBlock.Id);
	}

	//public async Task CreateControlBlock(ControlBlock controlBlock)
	//{
	//	await _context.ControlBlocks.AddAsync(controlBlock);
	//	await _context.SaveChangesAsync();
	//}

	public async Task Delete(int id)
	{
		var dbControlBlock = await _context.ControlBlocks.FindAsync(id) ?? throw new Exception("Не удалось найти блок управления.");
		_context.ControlBlocks.Remove(dbControlBlock);
		await _context.SaveChangesAsync();
	}

	public async Task<int> GetLastNumber()
	{
		List<ControlBlock> controlBlocksList = await _context.ControlBlocks.ToListAsync();

		if(controlBlocksList == null || controlBlocksList.Count <= 0)
			return 1;

		ControlBlock? lastControlBlock = controlBlocksList.OrderBy(x => x.Number).LastOrDefault();

		if (lastControlBlock == null)
			return 1;

		return lastControlBlock.Number;
	}

	public async Task<ControlBlock> GetById(int id)
	{
		var controlBlock = await _context.ControlBlocks.Include("Ballons").FirstOrDefaultAsync(cb => cb.Id == id);

		//TODO: Сделать кастомные исключения
		return controlBlock ?? throw new Exception("Не удалось найти блок управления.");
	}

	public async Task Load() => ControlBlocks = await _context.ControlBlocks.AsNoTracking().ToListAsync();

	public async Task Update(ControlBlock controlBlock)
	{
		var dbControlBlock = await _context.ControlBlocks.Where(cb => cb.Id == controlBlock.Id).SingleOrDefaultAsync() ?? throw new Exception("Не удалось найти блок управления.");

		dbControlBlock.Number = controlBlock.Number;
		dbControlBlock.Type = controlBlock.Type;

		if (controlBlock.Ballons != null)
			dbControlBlock.Ballons = controlBlock.Ballons;

		//_context.ChangeTracker.Clear();
		await _context.SaveChangesAsync();
	}

	public async Task<List<Ballon>?> GetBallonsList(int id)
	{
		var controlBlock = await _context.ControlBlocks.FirstOrDefaultAsync(x => x.Id == id);

		if (controlBlock == null || controlBlock.Ballons == null)
			return null;

		return controlBlock.Ballons.ToList();
	}
}
