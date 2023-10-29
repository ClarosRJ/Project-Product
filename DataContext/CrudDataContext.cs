using Crud_ASP.NET_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_ASP.NET_MVC.DataContext
{
    public class CrudDataContext: DbContext
    {
        public CrudDataContext(DbContextOptions<CrudDataContext> options):base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }

    }
}
