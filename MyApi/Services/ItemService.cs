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
    
    public void Delete(string item)
    {
        _items.Remove(item);
    }
    
    
    public void Update(string oldItem, string newItem)
    {
        
        int index = _items.IndexOf(oldItem);
        if (index != -1)
        {
            _items[index] = newItem;
        }
    }
}
