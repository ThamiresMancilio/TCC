using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SysAgropec.Class
{
    public class Raca
    {

        [Description("id")]

        private int id { get; set; }

        [Description("Descrição")]
        private string descricao { get; set; }
       
        [Description("datacadastro")]
        private DateTime datacadastro { get; set; }

        [Description("datalteracao")]
        private DateTime datalteracao { get; set; }

        [Description("usuario_idcadastro")]
        private int usuario_idcadastro { get; set; }

        [Description("usuario_idalteracao")]
        private int usuario_idalteracao { get; set; }

       
            
    }
}