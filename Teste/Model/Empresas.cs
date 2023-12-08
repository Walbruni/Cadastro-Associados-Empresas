using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Model
{
    [Table("empresas")]
    public class Empresas
    {
        [Column("Id")]
        public int IdEmpresas { get; set; }

        [Column("Nome")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo {}!")]
        public string Nome { get; set; }

        [Column("CNPJ")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do campo {}!")]
        public string CNPJ { get; set; }
    }
}