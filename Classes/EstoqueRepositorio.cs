using System;
using System.Collections.Generic;
using DIO.Series.Classes;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class EstoqueRepositorio : IRepositorio<Estoque>
    {
        private List<Estoque> listaSerie = new List<Estoque>();
		public void Atualiza(int id, Estoque objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Estoque objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Estoque> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Estoque RetornaPorId(int id)
		{
			return listaSerie[id];
		}
    }
}