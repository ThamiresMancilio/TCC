using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SysAgropec.Class
{
    public class Animal
    {

        [Description("id")]
        private int id { get; set; }

        [Description("descricao")]
        private string descricao { get; set; }

        [Description("registro")]
        private string registro { get; set; }

        [Description("tatuagem")]
        private string tatuagem { get; set; }

        [Description("numerobrinco")]
        private int numerobrinco { get; set; }

        [Description("datanascimento")]
        private DateTime datanascimento { get; set; }

        [Description("morto")]
        private bool morto { get; set; }

        [Description("observacao")]
        private string observacao { get; set; }

        [Description("datacadastro")]
        private DateTime datacadastro { get; set; }

        [Description("datalteracao")]
        private DateTime datalteracao { get; set; }

        [Description("registropai")]
        private string registropai { get; set; }

        [Description("tatuagempai")]
        private string tatuagempai { get; set; }

        [Description("descricaopai")]
        private string descricaopai { get; set; }

        [Description("registromae")]
        private string registromae { get; set; }

        [Description("tatuagemae")]
        private string tatuagemae { get; set; }

        [Description("descricaomae")]
        private string descricaomae { get; set; }

        [Description("sexo")]
        private Enum.TipoSexo sexo { get; set; }

        [Description("livro_id")]
        private Livro livro_id { get; set; }

        [Description("raca_id")]
        private Raca raca_id { get; set; }

        [Description("propriedades_id")]
        private Propriedade propriedades_id { get; set; }

        [Description("usuario_idcadastro")]
        private Usuario usuario_idcadastro { get; set; }

        [Description("usuario_idalteracao")]
        private Usuario usuario_idalteracao { get; set; }
        [Description("Lactação")]
        private bool lactacao { get; set; }

        public Animal(int id, string descricao, string registro, string tatuagem, 
            int numerobrinco, DateTime datanascimento, bool morto, string observacao, DateTime datacadastro,
            string registropai, string tatuagempai, string descricaopai, string registromae, string tatuagemae,
            string descricaomae, Enum.TipoSexo sexo, Livro livro_id, Raca raca_id, Propriedade propriedades_id,
            Usuario usuario_idcadastro, bool lactacao, DateTime? datalteracao , Usuario usuario_idalteracao = null) {

        }
    }

    
}