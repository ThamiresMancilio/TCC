using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SysAgropec.Class
{
    public class Livro
    {
        [Description("id")]
        
        private int id { get; set; }

        [Description("Descrição")]
        private string descricao { get; set; }
        [Description("Excluído")]
        private bool excluido { get; set; }
        [Description("datacadastro")]
        private DateTime datacadastro { get; set; }

        [Description("datalteracao")]
        private DateTime datalteracao { get; set; }

        [Description("usuario_idcadastro")]
        private Usuario usuario_idcadastro { get; set; }

        [Description("usuario_idalteracao")]
        private Usuario usuario_idalteracao { get; set; }

        public Livro(int id, string descricao, bool excluido, DateTime datacadastro, DateTime? datalteracao, Usuario usuario_idcadastro, Usuario usuario_idalteracao = null)
        {

        }

    }
}