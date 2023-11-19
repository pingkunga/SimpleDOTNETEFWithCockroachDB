using Microsoft.AspNetCore.Mvc;
using bojpawnapi.Service;
using bojpawnapi.DTO;

namespace bojpawnapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollateralsTxController : ControllerBase
    {
        private readonly ICollateralTxService _collateralTxService;

        public CollateralsTxController(ICollateralTxService collateralTxService)
        {
            _collateralTxService = collateralTxService;
        }

        // GET: api/Collaterals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollateralTxDTO>>> GetCollateralTxs()
        {
            var collateralList = await _collateralTxService.GetCollateralTxsAsync();
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
            var collateralTx = await _collateralTxService.GetCollateralTxByIdAsync(id);

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

            var result = await _collateralTxService.UpdateCollateralTxAsync(collateralTx);
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
            var result = await _collateralTxService.AddCollateralTxAsync(collateralTx);
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
            var result = await _collateralTxService.DeleteCollateralTxAsync(id);
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