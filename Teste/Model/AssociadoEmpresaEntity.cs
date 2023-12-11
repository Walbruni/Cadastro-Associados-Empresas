using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Model
{
    [Table("associados_empresas")]
    public class AssociadoEmpresaEntity
    {

        [Column("Id")]
        public int Id { get; set; }

        [Column("CD_empresa")]
        public int CdEmpresa { get; set; }

        [Column("CD_associado")]
        public int CdAssociado { get; set; }

    }
}
