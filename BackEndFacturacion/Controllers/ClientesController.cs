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
    public class ClientesController : ApiController
    {
        // GET: api/Clientes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Clientes/5
        public string Get(int id)
        {
            return "value";
        }

        public IHttpActionResult getClientes()
        {
            string Mensaje;
            BaseFacturacion.DataSets.Clientes.DataSetClientes.ClientesDataTable data = new BaseFacturacion.DataSets.Clientes.DataSetClientes.ClientesDataTable();
            BaseFacturacion.DataSets.Clientes.DataSetClientesTableAdapters.ClientesTableAdapter get = new BaseFacturacion.DataSets.Clientes.DataSetClientesTableAdapters.ClientesTableAdapter();
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
      

        // POST: api/Clientes
        public void Post([FromBody]string value)
        {
        }

        public IHttpActionResult InsertClientes([FromBody] Models.Clientes value)
        {

            BaseFacturacion.DataSets.Clientes.DataSetClientes.ClientesDataTable Data = new BaseFacturacion.DataSets.Clientes.DataSetClientes.ClientesDataTable();
            BaseFacturacion.DataSets.Clientes.DataSetClientesTableAdapters.ClientesTableAdapter insert = new BaseFacturacion.DataSets.Clientes.DataSetClientesTableAdapters.ClientesTableAdapter();
            var IdCliente = Guid.NewGuid();
            Console.WriteLine(IdCliente);

            try
            {
                int Resultado = insert.InserClientes((IdCliente).ToString(), value.Nombres, value.Apellidos, value.Telefono, value.TipoIdentificacion, value.NroIdentificacion, value.FechaNacimiento, value.DireccionResidencia);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
                throw;
            }
        }


        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
