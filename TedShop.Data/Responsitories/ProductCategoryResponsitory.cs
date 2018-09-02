using System.Collections.Generic;
using System.Linq;
using TedShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TedShop.Data.Responsitories
{
    public interface IProductCategoryResponsitory
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryResponsitory : RepositoryBase<ProductCategory>, IProductCategoryResponsitory
    {
        public ProductCategoryResponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}