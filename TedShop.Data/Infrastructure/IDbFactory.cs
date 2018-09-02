using System;

namespace TedShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopDbContext Init();
    }
}