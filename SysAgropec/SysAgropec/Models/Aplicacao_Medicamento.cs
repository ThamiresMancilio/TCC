//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SysAgropec.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aplicacao_Medicamento
    {
        public int ID { get; set; }
        public System.DateTime Dataplicacao { get; set; }
        public Nullable<int> Quantidade { get; set; }
        public string Observacao { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Datalteracao { get; set; }
        public int Animal_ID { get; set; }
        public int Medicamento_ID { get; set; }
        public int Usuario_IDCadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual Medicamento Medicamento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
