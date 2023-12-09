using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Model
{
    [Table("associados")]
    public class AssociadosEntity
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo {0}!")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo {0}!")]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Column("Data_Nascimento")]
        public DateTime? Data_Nascimento { get; set; }

        //[NotMapped]
        //public IList<EmpresasEntity> empresas;
        
    }
}
