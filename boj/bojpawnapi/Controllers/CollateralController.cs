using Microsoft.AspNetCore.Mvc;
using bojpawnapi.Service;
using bojpawnapi.DTO;

namespace bojpawnapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollateralsController : ControllerBase
    {
        private readonly ICollateralService _collateralService;

        public CollateralsController(ICollateralService collateralService)
        {
            _collateralService = collateralService;
        }

        // GET: api/Collaterals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollateralTxDTO>>> GetCollateralTxs()
        {
            var collateralList = await _collateralService.GetCollateralTxsAsync();
            if (collateralList != null)
            {
                return Ok(collateralList);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/Collaterals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollateralTxDTO>> GetCollateralTx(int id)
        {
            var collateralTx = await _collateralService.GetCollateralTxByIdAsync(id);

            if (collateralTx == null)
            {
                return NotFound();
            }

            return Ok(collateralTx);
        }

        // PUT: api/Collaterals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollateralTx(int id, CollateralTxDTO collateralTx)
        {
            if (id != collateralTx.CollateralId)
            {
                return BadRequest();
            }

            var result = await _collateralService.UpdateCollateralTxAsync(collateralTx);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Collaterals
        [HttpPost]
        public async Task<ActionResult<CollateralTxDTO>> PostCollateralTx(CollateralTxDTO collateralTx)
        {
            var result = await _collateralService.AddCollateralTxAsync(collateralTx);
            if (result != null)
            {
                return CreatedAtAction("GetCollateralTx", new { id = result.CollateralId }, result);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Collaterals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCollateralTx(int id)
        {
            var result = await _collateralService.DeleteCollateralTxAsync(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}