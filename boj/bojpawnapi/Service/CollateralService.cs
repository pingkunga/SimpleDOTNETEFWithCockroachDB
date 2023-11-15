using System.Collections.Generic;
using bojpawnapi.DTO;
using bojpawnapi.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using bojpawnapi.Entities;

namespace bojpawnapi.Service
{
    public class CollateralService : ICollateralService
    {
        private readonly PawnDBContext _context;
        private readonly IMapper _mapper;
        public CollateralService(PawnDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CollateralTxDTO> GetCollateralTxByIdAsync(int id)
        {
            var collateralTx = await _context.CollateralTxs
                                             .Include(C => C.CollateralDetaills)
                                             .Include(C => C.Customer)
                                             .Include(C => C.Employee)
                                             .FirstOrDefaultAsync(C => C.CollateralId == id);
            if (collateralTx == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<CollateralTxDTO>(collateralTx);
            }
 
        }

        public async Task<IEnumerable<CollateralTxDTO>> GetCollateralTxsAsync()
        {
            var collateralTxList = await _context.CollateralTxs
                                                 .Include(C => C.CollateralDetaills)
                                                 .Include(C => C.Customer)
                                                 .Include(C => C.Employee)
                                                 .ToListAsync();
            if (collateralTxList == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<IEnumerable<CollateralTxDTO>>(collateralTxList);
            }
        }

        public async Task<CollateralTxDTO> AddCollateralTxAsync(CollateralTxDTO pCollateralPayload)
        {
            var CollateralTxEntities = _mapper.Map<CollateralTxEntities>(pCollateralPayload);

            _context.CollateralTxs.Add(CollateralTxEntities);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return _mapper.Map<CollateralTxDTO>(CollateralTxEntities);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateCollateralTxAsync(CollateralTxDTO pCollateralPayload)
        {
            var CollateralTxEntities = _mapper.Map<CollateralTxEntities>(pCollateralPayload);

            _context.Entry(CollateralTxEntities).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async  Task<bool> DeleteCollateralTxAsync(int id)
        {
            var collateralTx = await _context.CollateralTxs.FindAsync(id);
            if (collateralTx == null)
            {
                return false;
            }

            _context.CollateralTxs.Remove(collateralTx);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}