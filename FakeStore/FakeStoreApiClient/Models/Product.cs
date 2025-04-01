using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStoreApiClient.Models;
public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{{\n\tId: {Id} \n\tTitle: {Title} \n\tDescription: {Description}\n\tCategory: {Category} \n\tImage: {Image} \n}}";
    }
}
