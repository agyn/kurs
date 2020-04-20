using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurs.Shared.Data.Context
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public class User : BaseEntity
    {
        public string Login { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

    }
}