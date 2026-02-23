using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MyApi.Data;

namespace MyApi.Services;

public class ItemService : IItemService
{
    private readonly ApiDbContext _context;

    public ItemService(ApiDbContext context)
    {
        _context = context;
    }

    public List<string> GetAll()
    {
        return _context.Items.Select(i => i.Name).ToList();
    }

    public void Add(string item)
    {
        if (String.IsNullOrEmpty(item))
        {
            throw new ArgumentException("Item cannot be null or empty.");
        }
        _context.Items.Add(new ItemEntity { Name = item });
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var item = _context.Items.Find(id);

        if (item != null)
        {
            // 2. Remove it from the table
            _context.Items.Remove(item);

            // 3. Save the deletion
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException($"Item with ID {id} not found.");
        }
    }

    public void Update(int id, string newItem)
    {
        var item = _context.Items.Find(id);

        if (item == null)
        {
            throw new KeyNotFoundException($"Item with ID {id} not found.");
        }
        item.Name = newItem;
        _context.SaveChanges();
    }
}
