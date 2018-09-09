/*
 * Fonte:
 * https://www.americanas.com.br/produto/124008864/umidificador-de-ar-digital-elgin-2-litros-bivolt?pfm_carac=umidificador%20de%20ar&pfm_index=0&pfm_page=search&pfm_pos=grid&pfm_type=search_page%20
 * e
 * https://produto.mercadolivre.com.br/MLB-1032079478-umidificador-de-ar-e-ionizador-ultrasonico-2l-bivolt-g-lif-_JM
 * 
 * */
 
 using System;

namespace PredioInteligente.Modelo
{
	public class UmidificadorAr
	{
		public string Id { get; set; }
		public string Estado { get; set; }
		public string Codigo { get; set; }
		public string Fabricante { get; set; }
		public string Marca { get; set; }
		public string Modelo { get; set; }
		public string EspecificacaoTecnica { get; set; }
		/*
		public string Autonomia { get; set; }
		public string CapacidadeAguaReservatorio { get; set; }
		public string Motor { get; set; }
		public bool Portatil { get; set; }
		public bool Silecioso { get; set; }
		public bool PossuiLubrificacao { get; set; }
		public bool DesligamentoAutomatico { get; set; }
		public bool Vaporizador { get; set; }
		public string Voltagem { get; set; }
		public string Potencia { get; set; }
		public string Cor { get; set; }
		public string Acessorios { get; set; }
		public string DimensoesComprimento { get; set; }
		public string DimensoesLargura { get; set; }
		public string DimensoesAltura { get; set; }
		public string PesoLiquido { get; set; }
		*/
		public Localizacao Localizacao { get; set; }
		public DateTime CarimboDataHora { get; set; }
	}
}
