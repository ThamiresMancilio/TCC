using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class ProducaoViewModel
    {
        public int ID { get; set; }
        public System.DateTime Datarealizada { get; set; }
        public double Quantidade { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Datalteracao { get; set; }
        public Nullable<sbyte> Excluido { get; set; }
        public string Observacao { get; set; }
        public int Animail_ID { get; set; }
        public int Usuario_IDProducao { get; set; }
        public int Usuario_IDCadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }

        public string nomeAnimal { get; set; }

        public int AdicionaProducao(ProducaoViewModel producao)
        {

            try
            {

                sysagropecConnection db = new sysagropecConnection();

                Producao m = new Producao();

                m.Animail_ID = producao.Animail_ID;
                m.Datalteracao = producao.Datalteracao;
                m.Datacadastro = producao.Datacadastro;
                m.Datarealizada = producao.Datarealizada;
                m.Excluido = producao.Excluido;
                m.Observacao = producao.Observacao;
                m.Quantidade = producao.Quantidade;
                m.Usuario_IDAlteracao = producao.Usuario_IDAlteracao;
                m.Usuario_IDCadastro = producao.Usuario_IDCadastro;

                db.Producao.Add(m);
                db.SaveChanges();

                int lastID = m.ID;

                return lastID;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<ProducaoViewModel> CarregaProducoes(string desc = "")
        {

            sysagropecConnection db = new sysagropecConnection();



            List<Producao> producoes = db.Producao.ToList();

            MedicamentoViewModel m = new MedicamentoViewModel();

            List<ProducaoViewModel> producaoVMList = producoes.Select(
                x => new ProducaoViewModel
                {
                    ID = x.ID,
                    Animail_ID = x.Animail_ID,
                    Quantidade = x.Quantidade,
                    Datarealizada = x.Datarealizada.Date,
                    Observacao = x.Observacao,
                    nomeAnimal = x.Animal.Descricao
                    


                }

                ).ToList();


            return producaoVMList;
        }
    }
}