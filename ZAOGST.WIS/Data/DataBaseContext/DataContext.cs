namespace ZAOGST.WIS.Data.DataBaseContext;

public class DataContext : DbContext
{
	public virtual DbSet<ControlBlock> ControlBlocks { get; set; }
	public virtual DbSet<Ballon> Ballons { get; set; }
	public virtual DbSet<ShippedControlBlock> ShippedControlBlocks { get; set; }
	public virtual DbSet<ShippedBallon> ShippedBallons { get; set; }

	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=Data\DataBase\ZAOGST.WIS.DataBase.db");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<ControlBlock>()
			.HasMany(cb => cb.Ballons)
			.WithOne(b => b.ControlBlock);

		modelBuilder.Entity<ShippedControlBlock>()
			.HasMany(scb => scb.ShippedBallons)
			.WithOne(sb => sb.ShippedControlBlock);

		//modelBuilder.Entity<ControlBlock>(entity =>
		//{
		//	entity
		//	.HasMany(cb => cb.Ballons)
		//	.WithOne(b => b.ControlBlock);
		//	//.HasForeignKey(b => b.ControlBlockId)
		//	//.OnDelete(DeleteBehavior.Restrict);
		//	//.HasConstraintName("FK_Control_Block");
		//});

		//modelBuilder.Entity<ShippedControlBlock>(entity =>
		//{
		//	entity
		//	.HasMany(cb => cb.ShippedBallons)
		//	.WithOne(b => b.ShippedControlBlock);
		//	//.HasForeignKey(b => b.ControlBlockId)
		//	//.OnDelete(DeleteBehavior.Restrict);
		//	//.HasConstraintName("FK_Control_Block");
		//});
	}
}