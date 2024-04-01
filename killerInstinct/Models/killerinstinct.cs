namespace killerInstinct.Models
{
    public class Personagem
    {
        public int Numero { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Idade { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public List<string> Ataques { get; set; }

        public string Tipo { get; set; }
        public string Imagem { get; set; }
    }
}