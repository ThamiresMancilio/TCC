using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class AnimalViewModel
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Registro { get; set; }
        public string Tatuagem { get; set; }
        public Nullable<int> Numerobrinco { get; set; }
        public Nullable<System.DateTime> Datanascimento { get; set; }
        public Nullable<sbyte> Morto { get; set; }
        public string Observacao { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Datalteracao { get; set; }
        public string Registropai { get; set; }
        public string Tatuagempai { get; set; }
        public string Descricaopai { get; set; }
        public string Registromae { get; set; }
        public string Tatuagemae { get; set; }
        public string Descricaomae { get; set; }
        public Nullable<int> Sexo { get; set; }
        public Nullable<sbyte> Lactacao { get; set; }
        public Nullable<int> Dias_lactacao { get; set; }
        public Nullable<System.DateTime> Datalactacao { get; set; }
        public int Livro_ID { get; set; }
        public int Raca_ID { get; set; }
        public int Propriedade_ID { get; set; }
        public int Usuario_IDCadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }


    }
}