using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI
{
    public class EntityVeiculosController : ApiController
    {
        private WebAPIContext db;// = new WebAPIContext();
        public EntityVeiculosController()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebAPIContext>();
            optionsBuilder.UseInMemoryDatabase("WebAPIInMemory"); // Nome do banco de dados InMemory
            db = new WebAPIContext(optionsBuilder.Options);
        }

        // GET: api/EntityVeiculos
        public IQueryable<Veiculo> GetVeiculoes()
        {
            return db.Veiculoes;
        }

        // GET: api/EntityVeiculos/5
        [ResponseType(typeof(Veiculo))]
        public async Task<IHttpActionResult> GetVeiculo(int id)
        {
            Veiculo veiculo = await db.Veiculoes.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        // PUT: api/EntityVeiculos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            db.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Ok(veiculo);
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EntityVeiculos
        [ResponseType(typeof(Veiculo))]
        public async Task<IHttpActionResult> PostVeiculo(Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Veiculoes.Add(veiculo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = veiculo.Id }, veiculo);
        }

        // DELETE: api/EntityVeiculos/5
        [ResponseType(typeof(Veiculo))]
        public async Task<IHttpActionResult> DeleteVeiculo(int id)
        {
            Veiculo veiculo = await db.Veiculoes.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            db.Veiculoes.Remove(veiculo);
            await db.SaveChangesAsync();

            return Ok(veiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VeiculoExists(int id)
        {
            return db.Veiculoes.Count(e => e.Id == id) > 0;
        }
    }
}