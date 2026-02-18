using System;

namespace MyApi.Services;

public class ItemService : IItemService
{
    public List<string> GetAll()
    {
        return new List<string> { "Laptop", "Mouse" };
    }

    public void Add(string item) { }
}
