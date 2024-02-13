using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class VeiculosController : ApiController
    {
        Repositories.Veiculo _repositorioVeiculo;
        public VeiculosController() {
            _repositorioVeiculo = new Repositories.Veiculo(Configurations.Databases.getDatabase());
        }
        // GET api/veiculos
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await _repositorioVeiculo.GetAllVeiculos());
            } 
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        // GET api/veiculos/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Models.Veiculo veiculo = await _repositorioVeiculo.GetVeiculoById(id);
                if (veiculo.Id == 0) 
                    return NotFound();

                return Ok(veiculo);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        // POST api/veiculos
        public async Task<IHttpActionResult> Post([FromBody] Models.Veiculo veiculo)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                await _repositorioVeiculo.AddVeiculo(veiculo);

                if(veiculo.Id == 0)
                    return BadRequest();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        // PUT api/veiculos/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Veiculo veiculo)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                if(veiculo.Id != id)
                    return BadRequest("Objeto não relacionado, Ids diferentes");

                bool update = await _repositorioVeiculo.UpdateVeiculo(veiculo);

                if(!update)
                    return NotFound();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        // DELETE api/veiculos/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                bool excluir = await _repositorioVeiculo.DeleteVeiculo(id);
                if(!excluir)
                    return NotFound();
            
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}