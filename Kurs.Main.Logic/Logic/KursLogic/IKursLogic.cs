using Kurs.Shared.Data.Dtos;
using Kurs.Shared.Logic;
using System.Threading.Tasks;

namespace Kurs.Main.Logic.KursLogic
{
    public interface IKursLogic<TEntity> : IBaseCrudLogic<TEntity>
    {
        Task<object> GetList(KursSearchDto dto);
        Task<object> SearchAll(KursSearchDto dto);
    }
}
