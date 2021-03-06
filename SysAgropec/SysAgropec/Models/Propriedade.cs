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
    
    public partial class Propriedade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Propriedade()
        {
            this.Animal = new HashSet<Animal>();
            this.Lote = new HashSet<Lote>();
        }
    
        public int ID { get; set; }
        public string Cnpj { get; set; }
        public string Razaosocial { get; set; }
        public string Nomefantasia { get; set; }
        public string Inscricaomunicipal { get; set; }
        public string Inscricaoestadual { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logo { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Dataalteracao { get; set; }
        public int Usuario_IDCadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Animal> Animal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lote> Lote { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
