using System;

namespace DIO.Series.Classes
{
    public class Estoque : EntidadeBase
    {
        // Atributos
		private Roupas TipoRoupas { get; set; }
		private string Modelo { get; set; }
		private string Descricao { get; set; }
		private string Tamanho { get; set; }
		private string Cor { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Estoque(int id, Roupas roupa, string modelo, string descricao, string tamanho, string cor)
		{
			this.Id = id;
			this.TipoRoupas = roupa;
			this.Modelo = modelo;
			this.Descricao = descricao;
			this.Tamanho = tamanho;
			this.Cor = cor;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Roupa: " + this.TipoRoupas + Environment.NewLine;
            retorno += "Modelo: " + this.Modelo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Tamanho: " + this.Tamanho + Environment.NewLine;
			retorno += "Cor: " + this.Cor + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaModelo()
		{
			return this.Modelo;
		}

		public string retornaNome()
		{
			return this.Modelo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}