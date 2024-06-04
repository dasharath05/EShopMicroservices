using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData: IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
        {
            return;
        }

        session.Store<Product>(GetPreConfiguredProducts());

        await session.SaveChangesAsync(cancellation);
    }

    private IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>()
    {
        new Product()
        {
            Id= new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "IPhone X",
            Description = "This phone is the company's biggest change to its product",
            ImageFile = "product-1.jpg",
            Price = 950,
            Category = ["Smart Phone"]
        }
    };
}
