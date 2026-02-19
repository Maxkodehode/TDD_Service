namespace MyApi.Services;

public class ItemService : IItemService
{
    private readonly List<string> _items;

    public ItemService()
    {
        _items = new List<string> { "Laptop", "Mouse" };
    }

    public List<string> GetAll()
    {
        return _items;
    }

    public void Add(string item)
    {
        _items.Add(item);
    }
}
