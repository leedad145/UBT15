using System.Collections.Generic;

public interface IItemRepository
{
    IReadOnlyList<Item> All { get; }
}