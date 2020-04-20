using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kurs.Shared.Data.Context
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int? ExchangerId { get; set; }
        [ForeignKey("ExchangerId")]
        public virtual Exchanger Exchanger { get; set; }
    }
}
