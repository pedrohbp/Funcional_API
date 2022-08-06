using System.ComponentModel.DataAnnotations.Schema;

namespace Funcional_API.Models
{
    [Table("conta", Schema = "contacorrente")]
    public partial class Conta: BaseEntity
    {
        public double saldo { get; set; }
    }
}
