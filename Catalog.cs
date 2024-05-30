using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace C_12
{
    public class Catalog
    {
        public List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void RemoveProduct(int id)
        {
            products.RemoveAll(p => p.ID == id);
        }
        public void UpdateProduct(Product prod)
        {
            var existing = products.FirstOrDefault(products => products.ID == prod.ID);
            if (existing != null)
            {
                existing.Name = prod.Name;
                existing.Price = prod.Price;
                existing.Category = prod.Category;
            }
        }
        public void SaveToJson(string path)
        {
            string json = JsonConvert.SerializeObject(products);
            File.WriteAllText(path, json);
        }
        public void LoadFromJson(string path)
        {
            string json = File.ReadAllText(path);
            products = JsonConvert.DeserializeObject<List<Product>>(json);
        }
        public void SaveToXml(string path)
        {
            XElement xml = new XElement("products",
                from product in products
                select new XElement("Product",
                new XAttribute("ID", product.ID),
                new XAttribute("Name", product.Name),
                new XAttribute("Price", product.Price),
                new XAttribute("Category", product.Category)
                ));
            xml.Save(path);
        }
        public void LoadFromXml(string path)
        {
            var culture = System.Globalization.CultureInfo.InvariantCulture;
            XDocument xml = XDocument.Load("product.xml");
            products = xml.Descendants("Product").Select(p => new Product
            {
                ID = int.Parse(p.Attribute("ID").Value),
                Name = p.Attribute("Name").Value,
                Price = double.Parse(p.Attribute("Price").Value, culture),
                Category = p.Attribute("Category").Value
            }).ToList();
        }
        public IEnumerable<Product> FilterProductsByCategory(string category)
        {
            return products.Where(p => p.Category.ToLower() == category.ToLower());
        }
        public IEnumerable<Product> FilterProductsByPrice(double min, double max)
        {
            return products.Where(p => p.Price >= min && p.Price <= max);
        }
        public IEnumerable<Product> SortProductsByPrice()
        {
            return products.OrderBy(p => p.Price);
        }
        public IEnumerable<Product> SortProductsByName()
        {
            return products.OrderBy(p => p.Name);
        }

    }
}
