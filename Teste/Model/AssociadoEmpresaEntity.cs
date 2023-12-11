using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Model
{
    [Table("associados_empresas")]
    public class AssociadoEmpresaEntity
    {

        [Column("Id")]
        public int Id { get; set; }

        [Column("CD_empresa")]
        public int CD_empresa { get; set; }

        [Column("CD_associado")]
        public int CD_associado { get; set; }

        //public List<AssociadosEntity> Associados { get; set; }

        //public List<EmpresasEntity> Empresas { get; set; }

        [ForeignKey("CD_empresa")]
        [DisplayName("Empresa")]
        public EmpresasEntity empresa { get; set; }

        [ForeignKey("CD_associado")]
        [DisplayName("Associado")]
        public AssociadosEntity associados { get; set; }
    }
}
