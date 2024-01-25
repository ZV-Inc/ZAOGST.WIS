namespace ZAOGST.WIS.Data.Interfaces;

public interface IShippedControlBlockService
{
	List<ShippedControlBlock> ShippedControlBlocks { get; set; }
	Task Load();
	Task<ShippedControlBlock> GetById(int id);
	Task<ShippedControlBlock?> Create(ShippedControlBlock shippedControlBlock);
	Task Update(ShippedControlBlock shippedControlBlock);
	Task Delete(int id);
}
