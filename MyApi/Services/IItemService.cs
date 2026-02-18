using System;

namespace MyApi.Services;

public interface IItemService
{
    List<string> GetAll();
    void Add(string item);
}
