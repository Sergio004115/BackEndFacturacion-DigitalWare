using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackEndFacturacion.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductosController : ApiController
    {
        // GET: api/Productos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Productos/5
        public string Get(int id)
        {
            return "value";
        }

       public IHttpActionResult getProductos()
        {
            string Mensaje;
            BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable data = new BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable();
            BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter get = new BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter();
            try
            {
                data = get.GetData();

                return Ok(data);
               
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return Ok(Mensaje);
                throw;
            }
        }

        public IHttpActionResult getProductoById(int IdProducto)
        {
            string Mensaje;
            BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable data = new BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable();
            BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter get = new BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter();
            try
            {
                data = get.GetDataProdById(IdProducto);

                return Ok(data);

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return Ok(Mensaje);
                throw;
            }
        }

        public IHttpActionResult getMinimoPermitido(int MinimoPermitido)
        {
            string Mensaje;
            BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable data = new BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable();
            BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter get = new BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter();
            try
            {
                data = get.GetProductosMinPermitido(MinimoPermitido);

                return Ok(data);

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return Ok(Mensaje);
                throw;
            }
        }

        public IHttpActionResult getBusqueda(string Nombre)
        {
            string Mensaje;
            BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable data = new BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable();
            BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter get = new BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter();
            try
            {
                data = get.GetBusqueda(Nombre);

                return Ok(data);

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return Ok(Mensaje);
                throw;
            }
        }



        // POST: api/Productos
        public void Post([FromBody]string value)
        {
        }

        public IHttpActionResult InsertProductos([FromBody] Models.Productos value)
        {

            BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable Data = new BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable();
            BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter insert = new BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter();

            int IdProducto =  Convert.ToInt32(insert.MaxIdProductos());
            
            try
            {
                int Resultado = insert.InsertProductos(IdProducto, value.Nombre, Convert.ToInt32(value.Precio), Convert.ToInt32(value.Existencia));
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
                throw;
            }
        }

        // PUT: api/Productos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        public IHttpActionResult PutUpdateProducto(int IdProducto, [FromBody] Models.Productos value)
        {
            BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable Data = new BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable();
            BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter update = new BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter();
            try
            {
                int Resultado = update.UpdateProducto(value.Nombre, value.Precio, value.Existencia, IdProducto);
                return Ok(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Productos/5
        public void Delete(int id)
        {
        }

        public IHttpActionResult DeleteProducto(int IdProducto)
        {
            BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable Data = new BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable();
            BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter delete = new BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter();
            try
            {
                delete.DeleteProducto(IdProducto);
                return Ok(true);
            }
            catch (Exception)
            {
                return Ok(false);
                throw;
            }
        }
    }
}
