using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("OperationClaims")]
    public class OperationClaim : IEntity
    {
        [Column("Id")]
        public int OperationClaimId { get; set; }
        public string Name { get; set; }
    }
}
