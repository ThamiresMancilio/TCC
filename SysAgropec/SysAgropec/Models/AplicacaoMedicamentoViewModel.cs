using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class AplicacaoMedicamentoViewModel
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

        public string nomeMedicamento { get; set; }

        public string animalDescri { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Medicamento Medicamento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
 
        public int AdicionaAplicacao(AplicacaoMedicamentoViewModel ap)
        {

            try
            {

                sysagropecEntities db = new sysagropecEntities();

                Aplicacao_Medicamento a = new Aplicacao_Medicamento();
                
                a.Animal_ID = ap.Animal_ID;
                a.Datacadastro = ap.Datacadastro;
                a.Datalteracao = ap.Datalteracao;
                a.Dataplicacao = ap.Dataplicacao;
                a.Medicamento_ID = ap.Medicamento_ID;
                a.Observacao = ap.Observacao;
                a.Quantidade = ap.Quantidade;
                a.Usuario_IDAlteracao = ap.Usuario_IDAlteracao;
                a.Usuario_IDCadastro = ap.Usuario_IDCadastro;

                db.Aplicacao_Medicamento.Add(a);
                db.SaveChanges();

                int lastID = a.ID;

                return lastID;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public List<AplicacaoMedicamentoViewModel> getAplicacosAnimal()
        {
            sysagropecEntities db = new sysagropecEntities();

            List<Aplicacao_Medicamento> aplicacoesA = db.Aplicacao_Medicamento.OrderBy(x => x.Animal_ID).ThenBy(x => x.Dataplicacao).ToList();

            List<AplicacaoMedicamentoViewModel> aplicacoes = aplicacoesA.Select(

                x => new AplicacaoMedicamentoViewModel
                {
                    ID = x.ID,
                    Animal_ID = x.Animal_ID,
                    nomeMedicamento = x.Medicamento.Nome,
                    Medicamento_ID = x.Medicamento_ID,
                    Dataplicacao = x.Dataplicacao,
                    Quantidade = x.Quantidade
                }

                ).ToList();

            return aplicacoes;

        } 
         


        public List<AplicacaoMedicamentoViewModel> CarregaAplicacoes(DateTime? datIni, DateTime? datFin)
        {

            sysagropecEntities db = new sysagropecEntities();

            List<Aplicacao_Medicamento> aplicacoes;


            if(datIni != null && datFin != null)
            {
                aplicacoes = db.Aplicacao_Medicamento.Where(x => x.Dataplicacao <= datIni && x.Dataplicacao >= datFin).ToList();
            }
            else
            {
                aplicacoes = db.Aplicacao_Medicamento.ToList();
            }

            AplicacaoMedicamentoViewModel m = new AplicacaoMedicamentoViewModel();

            List<AplicacaoMedicamentoViewModel> aplicacaoVMList = aplicacoes.Select(
                x => new AplicacaoMedicamentoViewModel
                {
                    ID = x.ID,
                    Animal_ID = x.Animal_ID,
                    animalDescri = x.Animal.Descricao,
                    Dataplicacao = x.Dataplicacao.Date,
                    Medicamento_ID = x.Medicamento_ID,
                    nomeMedicamento = x.Medicamento.Descricao
                    
                }

                ).ToList();


            return aplicacaoVMList;
        }

        public void ExcluiAplicacao(int idAplicacao)
        {

            if (idAplicacao > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Aplicacao_Medicamento ap = db.Aplicacao_Medicamento.SingleOrDefault(l => l.ID == idAplicacao);

                    if (ap != null)
                    {
                        db.Aplicacao_Medicamento.Remove(ap);

                        db.SaveChanges();
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }
        }
    }
}