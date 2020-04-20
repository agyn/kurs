using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurs.Shared.Data.Context
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [Column(Order =2)]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [Column(Order = 3)]
        public DateTime DateUpdate { get; set; } = DateTime.Now;
    }
}