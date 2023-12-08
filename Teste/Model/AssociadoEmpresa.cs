using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Model
{
    [Table("associadoEmpresa")]
    public class AssociadoEmpresa
    {

        [Column("Id")]
        public int Id { get; set; }

        [Column("CD_empresa")]
        public int CD_empresa { get; set; }

        [Column("CD_associado")]
        public int CD_associado { get; set; }
    }
}
