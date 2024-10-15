//LUIZMENDES 3012123

using System.ComponentModel;

namespace TP02.Models
{
    public class BL
    {
        public int Id { get; set; }        // Identificador único
        public string Consignee { get; set; }  // Nome do consignatário
        public string Navio { get; set; }      // Nome do navio
        public string Numero { get; set; }     // Número relacionado ao transporte

        public List<Cont> Conts { get; set; } = new List<Cont>();
    }
}
