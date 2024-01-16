namespace ZAOGST.WIS.Data.Interfaces;

public interface IShippedControlBlockService
{
	List<ShippedControlBlock> ShippedControlBlocks { get; set; }
	Task LoadShippedControlBlock();
	Task<ShippedControlBlock> GetSingleShippedControlBlock(int id);
	Task<ShippedControlBlock?> CreateShippedControlBlock(ShippedControlBlock shippedControlBlock);
	Task UpdateShippedControlBlock(ShippedControlBlock shippedControlBlock/*, int id*/);
	Task DeleteShippedControlBlock(int id);
	int GetLastShippedControlBlockNumber();
	Task<int> GetLastShippedControlBlockId();
}
