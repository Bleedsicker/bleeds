using System.Collections.Concurrent;
using WebDevAPI.Dto;

namespace WebDevAPI.Infrastructure;

public static class CartStructure
{
    public static readonly ConcurrentDictionary<long, CartDto> Carts = new();
}
