using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PrizeBondServices
    {
        public static bool CreateBond(PrizeBondDTO prizeBond)
        {
            if (prizeBond != null)
            {
                var mapper = MappingService<PrizeBondDTO,PrizeBond>.GetMapper();
                var bond = mapper.Map<PrizeBond>(prizeBond);
                var success = DataAccessFactory.BondDataAccess().Create(bond);
                if (success)
                {
                    return true;
                }
            }
            return false;
        }


        public static List<PrizeBondDTO> GetPrizeBondByUserId(int userId)
        {
            if (userId > 0)
            {
                var prize = (from b in DataAccessFactory.BondDataAccess().GetByID(userId)
                    where b.IsDeleted==false
                    select b).ToList();

                if (prize != null )
                {
                    //var config = new MapperConfiguration(cfg =>
                    //{
                    //    cfg.CreateMap<PrizeBond, PrizeBondDTO>();
                    //});

                    //var mapper = new Mapper(config);

                    var mapper = MappingService<PrizeBond,PrizeBondDTO>.GetMapper();
                    var success= mapper.Map<List<PrizeBondDTO>>(prize);
             
                    return success;
                }
            }

            return null;
        }

    }
}
