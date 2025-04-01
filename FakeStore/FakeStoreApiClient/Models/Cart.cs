using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStoreApiClient.Models;
public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();

    public override string ToString()
    {
        return $"{{ \n\tId: {Id} \n\tUserId: {UserId} \n\tProducts: [{string.Join(", ", Products.Select(p => p.ToString()))}] \n}}";
    }
}
