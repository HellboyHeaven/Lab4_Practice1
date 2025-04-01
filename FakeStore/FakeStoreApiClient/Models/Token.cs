using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStoreApiClient.Models;
public class AccessToken
{
    public string Token { get; set; } = string.Empty;


    public override string ToString()
    {
        return $"{Token}";
    }
}
