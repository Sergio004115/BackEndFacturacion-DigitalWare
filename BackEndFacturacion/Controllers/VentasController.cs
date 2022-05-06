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
    public class VentasController : ApiController
    {
        // GET: api/Ventas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IHttpActionResult getTotalVentaPorProducto()
        {
           
            string Mensaje;
            BaseFacturacion.DataSets.Ventas.DataSetVentas.ProductosDataTable data = new BaseFacturacion.DataSets.Ventas.DataSetVentas.ProductosDataTable();
            BaseFacturacion.DataSets.Ventas.DataSetVentasTableAdapters.ProductosTableAdapter get = new BaseFacturacion.DataSets.Ventas.DataSetVentasTableAdapters.ProductosTableAdapter();
            try
            {
                int Year = 2000;
                data = get.GetDataTotalProductosAnio(Year);

                return Ok(data);

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return Ok(Mensaje);
                throw;
            }
        }

        public IHttpActionResult getClientesNoMayor()
        {
            DateTime FechaInicio = new DateTime(2000, 01, 01);
            DateTime FechaFin = new DateTime(2000, 05, 25);
            string Mensaje;
            BaseFacturacion.DataSets.Ventas.DataSetVentas.comprasNoMayoresDataTable data = new BaseFacturacion.DataSets.Ventas.DataSetVentas.comprasNoMayoresDataTable();
            BaseFacturacion.DataSets.Ventas.DataSetVentasTableAdapters.comprasNoMayoresTableAdapter get = new BaseFacturacion.DataSets.Ventas.DataSetVentasTableAdapters.comprasNoMayoresTableAdapter();
            try
            {
                data = get.GetDataClientesNoMayores(FechaInicio, FechaFin);

                return Ok(data);

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                return Ok(Mensaje);
                throw;
            }
        }

        public IHttpActionResult getEstimacionVentar()
        {

            BaseFacturacion.DataSets.Ventas.DataSetVentas.ClientesDataTable data = new BaseFacturacion.DataSets.Ventas.DataSetVentas.ClientesDataTable();
            BaseFacturacion.DataSets.Ventas.DataSetVentasTableAdapters.ClientesTableAdapter get = new BaseFacturacion.DataSets.Ventas.DataSetVentasTableAdapters.ClientesTableAdapter();
            try
            {
                data = get.GetDataEstimacionCompra();                

                return Ok(data);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: api/Ventas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ventas
        public void Post([FromBody]string value)
        {
        }

        public IHttpActionResult InsertNewVenta([FromBody] Models.Ventas value)
        {

            BaseFacturacion.DataSets.Ventas.DataSetVentas.VentasDataTable Data = new BaseFacturacion.DataSets.Ventas.DataSetVentas.VentasDataTable();
            BaseFacturacion.DataSets.Ventas.DataSetVentasTableAdapters.VentasTableAdapter insert = new BaseFacturacion.DataSets.Ventas.DataSetVentasTableAdapters.VentasTableAdapter();
            BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable dat = new BaseFacturacion.DataSets.Productos.DataSetProductos.ProductosDataTable();
            BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter get = new BaseFacturacion.DataSets.Productos.DataSetProductosTableAdapters.ProductosTableAdapter();

            DateTime FechaVenta = DateTime.Now;
            int IdVenta = Convert.ToInt32(insert.MaxId());

            try
            {
                int resulProd = Convert.ToInt32(get.GetExistenciasActualesProd(value.IdProducto));
                int existenciaActualizar = (resulProd - value.CantidadProducto);

                int actualizarProd = get.UpdateExistenciaProd(existenciaActualizar, value.IdProducto);
                
                int Resultado = insert.InsertNewVenta(IdVenta, value.IdProducto, value.Cliente, FechaVenta, value.CantidadProducto, value.TotalVenta);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
                throw;
            }
        }

        // PUT: api/Ventas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ventas/5
        public void Delete(int id)
        {
        }
    }
}
