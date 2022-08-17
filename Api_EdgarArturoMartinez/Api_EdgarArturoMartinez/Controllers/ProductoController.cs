using Api_EdgarArturoMartinez.Model;
using Api_EdgarArturoMartinez.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Api_EdgarArturoMartinez.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }
    }
}
