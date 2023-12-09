using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Model
{
    [Table("empresas")]
    public class EmpresasEntity
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo {0}!")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Column("CNPJ")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo {0}!")]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        //public ICollection<AssociadoEmpresaEntity> associadosEmpresas { get; set; }
    }
}