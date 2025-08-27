using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productColletion)
    {
        bool existProduct = productColletion.Find(p => true).Any();
        if (!existProduct)
        {
            productColletion.InsertManyAsync(GetMyProducts());
        }
    }

    private static IEnumerable<Product> GetMyProducts() {
        return new List<Product>()
        {
            new Product(){
                Id = "68ae5396b59f09166a086d31",
                Name = "Samsung A55",
                Description = "Dolore esse aute proident fugiat. Reprehenderit mollit veniam quis sint. Et cillum reprehenderit ex aliquip cillum. Velit exercitation ullamco in fugiat aute dolor aliqua reprehenderit deserunt proident. Sunt mollit aliqua amet deserunt.",
                Image = "product-1.png",
                Price = 1600.00M,
                Category = "Smartphone"
            },
            new Product(){
                Id = "68ae53a2b59f09166a086d32",
                Name = "IPhone XR",
                Description = "Dolore esse aute proident fugiat. Reprehenderit mollit veniam quis sint. Et cillum reprehenderit ex aliquip cillum. Velit exercitation ullamco in fugiat aute dolor aliqua reprehenderit deserunt proident. Sunt mollit aliqua amet deserunt.",
                Image = "product-1.png",
                Price = 2600.00M,
                Category = "Smartphone"
            },
            new Product(){
                Id = "68ae53a2b59f09166a086d32",
                Name = "TV LG 45 Pol. 4k",
                Description = "Dolore esse aute proident fugiat. Reprehenderit mollit veniam quis sint. Et cillum reprehenderit ex aliquip cillum. Velit exercitation ullamco in fugiat aute dolor aliqua reprehenderit deserunt proident. Sunt mollit aliqua amet deserunt.",
                Image = "product-1.png",
                Price = 3600.00M,
                Category = "Television"
            }
        };
    }
}