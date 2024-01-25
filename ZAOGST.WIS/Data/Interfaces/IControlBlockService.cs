namespace ZAOGST.WIS.Data.Interfaces;

public interface IControlBlockService
{
	List<ControlBlock> ControlBlocks { get; set; }
	Task LoadControlBlock();
	Task<ControlBlock> GetSingleControlBlock(int id);
	Task<ControlBlock?> CreateControlBlock(ControlBlock controlBlock);
	//Task CreateControlBlock(ControlBlock controlBlock);
	Task UpdateControlBlock(ControlBlock controlBlock);
	Task DeleteControlBlock(int id);
	Task<int> GetLastControlBlockNumber();
	Task<List<Ballon>?> GetBallonsList(int id);
	Task<int> GetLastControlBlockCountNumber();
}
