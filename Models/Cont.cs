using System.ComponentModel.DataAnnotations;

namespace TP02.Models
{
    public class Cont
    {
        public int Id { get; set; }

        // Restrição de número com no máximo 11 caracteres
        [MaxLength(11, ErrorMessage = "O número deve ter no máximo 11 caracteres.")]
        public string Numero { get; set; }

        // Restringindo Tipo aos valores "Reefer" ou "Dry"
        private string _tipo;
        public string Tipo
        {
            get => _tipo;
            set
            {
                if (value != "Reefer" && value != "Dry")
                {
                    throw new ArgumentException("Tipo deve ser 'Reefer' ou 'Dry'.");
                }
                _tipo = value;
            }
        }

        // Restringindo Tamanho aos valores "20" ou "40"
        private int _tamanho;
        public int Tamanho
        {
            get => _tamanho;
            set
            {
                if (value != 20 && value != 40)
                {
                    throw new ArgumentException("Tamanho deve ser 20 ou 40.");
                }
                _tamanho = value;
            }
        }
        // Chave estrangeira para relacionar com o BL
        public int BLId { get; set; }

        // Referência ao BL associado
        public BL BL { get; set; } = null!;
    }
}
