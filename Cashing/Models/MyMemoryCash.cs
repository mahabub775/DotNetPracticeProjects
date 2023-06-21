using Microsoft.Extensions.Caching.Memory;

namespace Cashing.Models
{
	public class MyMemoryCash
	{
		public MemoryCache Cashe { get; } = new MemoryCache(
			new MemoryCacheOptions()
			{
				SizeLimit= 1024
			
			});
	}
}
