using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kurs.Shared.Data.Context
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
    }
}
