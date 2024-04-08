namespace ZAOGST.WIS.Data.Interfaces;

public interface IShippedControlBlockService
{
	Task<ShippedControlBlock> Create(ShippedControlBlock shippedControlBlock);
	Task Update(ShippedControlBlock shippedControlBlock);
	Task Delete(ShippedControlBlock shippedControlBlock);
	Task<ShippedControlBlock> GetById(int id);
	Task<List<ShippedControlBlock>> GetList();
	Task<List<ShippedControlBlock>> GetSended();
	Task<List<ShippedControlBlock>> GetNotSended();
}
