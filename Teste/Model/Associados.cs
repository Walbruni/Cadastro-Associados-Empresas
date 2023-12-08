using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Model
{
    [Table("associados")]
    public class Associados
    {
        [Column("Id")]
        public int IdAssociado { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo {}!")]
        public string Nome { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo {}!")]
        public string CPF { get; set; }

        [Column("Data_Nascimento")]
        public DateTime Data_Nascimento { get; set; }
    }
}
