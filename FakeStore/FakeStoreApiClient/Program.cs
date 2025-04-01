using FakeStoreApiClient;
using FakeStoreApiClient.Models;

Console.WriteLine("Hello, Programming Languages 1!");

var htttpClient = new HttpClient();

var productApi = new APIController<Product>("https://fakestoreapi.com/products");
var cartApi = new APIController<Cart>("https://fakestoreapi.com/carts");
var userApi = new APIController<User>("https://fakestoreapi.com/users");
Func<Login, Task<AccessToken>> login =  (Login login) => htttpClient.Post<AccessToken, Login>("https://fakestoreapi.com/auth/login", login);


var products = await productApi.GetAll();
products.ForEach(Console.WriteLine);

var carts = await cartApi.GetAll();
carts.ForEach(Console.WriteLine);

var users = await userApi.GetAll();
users.ForEach(Console.WriteLine);


Console.WriteLine(await login(new Login { Username = "jimmie_k", Password = "klein*#%*" }));

await productApi.Delete(1);


