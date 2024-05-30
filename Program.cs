namespace C_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            catalog.AddProduct(new Product { ID = 1, Name = "Product 1", Price = 10.5, Category = "Category 1" });
            catalog.AddProduct(new Product { ID = 2, Name = "Product 2", Price = 15.3, Category = "Category 2" });
            catalog.AddProduct(new Product { ID = 3, Name = "Product 3", Price = 23.6, Category = "Category 3" });

            catalog.SaveToJson("products.json");
            catalog.LoadFromJson("products.json");
            Console.WriteLine("Из json");
            foreach (var i in catalog.products)
            {
                Console.WriteLine($"ID: {i.ID}, Name: {i.Name}, Price: {i.Price}, Category: {i.Category}");
            }
            Console.WriteLine();

            catalog.SaveToXml("product.xml");
            catalog.LoadFromXml("product.xml");
            Console.WriteLine("Из Xml");
            foreach (var i in catalog.products)
            {
                Console.WriteLine($"ID: {i.ID}, Name: {i.Name}, Price: {i.Price}, Category: {i.Category}");
            }
            Console.WriteLine();
            Console.WriteLine("Из определенной категории");
            //фильтрация продуктов по категориям
            IEnumerable<Product> FilteredProducts = catalog.FilterProductsByCategory("Category 1");
            foreach(var i in FilteredProducts)
            {
                Console.WriteLine($"ID: {i.ID}, Name: {i.Name}, Price: {i.Price}, Category: {i.Category}");
            }
            Console.WriteLine();
            Console.WriteLine("по цене");
            //фильтр по цене
            IEnumerable<Product> sortedProduct = catalog.FilterProductsByPrice(10.3,20.5);
            foreach(var i in sortedProduct)
            {
                Console.WriteLine($"ID: {i.ID}, Name: {i.Name}, Price: {i.Price}, Category: {i.Category}");
            }
            Console.WriteLine();

        }
    }
}
