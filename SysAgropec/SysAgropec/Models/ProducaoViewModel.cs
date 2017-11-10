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

        public double totalQuantidade { get; set; }

        public double[] producoes { get; set; }

        public int AdicionaProducao(ProducaoViewModel producao)
        {

            try
            {

                sysagropecEntities db = new sysagropecEntities();

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
        
        public List<ProducaoViewModel> RelatorioAnimais(DateTime dataProdI, DateTime dataProdF)
        {
            sysagropecEntities db = new sysagropecEntities();

            List<Producao> prod = db.Producao.Where(x => x.Datarealizada >= dataProdI &&
            x.Datarealizada <= dataProdF
            ).OrderBy(x => x.Animail_ID).ToList();

            //List<Producao> prod = db.Producao.OrderBy(x => x.Animail_ID).ThenBy(x => x.Datarealizada).ToList();

            List<ProducaoViewModel> animalVMList = prod.Select(
                x => new ProducaoViewModel
                {
                    ID = x.ID,
                    Datarealizada = x.Datarealizada,
                    nomeAnimal = x.Animal.Descricao,
                    Animail_ID = x.Animail_ID,
                    Usuario_IDProducao = x.Usuario_IDProducao,
                    Quantidade = x.Quantidade,
                    Observacao = x.Observacao
                    

                }

                ).ToList();


            return animalVMList;


        }

        public double[] DadosGrafico(int anoI, int anoF, int codFazenda) {

            sysagropecEntities db = new sysagropecEntities();

            producoes = new double[12];

            
            for (int i =0; i<12; i++)
            {
              producoes[i] = db.Producao.Where(x => x.Animal.Propriedade_ID == codFazenda
                && x.Datarealizada.Year == anoI && x.Datarealizada.Month == i+1
                    ).Sum(x => x.Quantidade);
                
            }
            
            return producoes;
        }



        public List<ProducaoViewModel> CarregaProducoes(DateTime? datIni, DateTime? datFin)
        {

            sysagropecEntities db = new sysagropecEntities();

            List<Producao> producoes;

            if (datFin != null && datIni != null)
            {

               producoes = db.Producao.Where(x => x.Datarealizada <= datIni && x.Datarealizada >= datFin).ToList();
            }
            else
            {

                producoes = db.Producao.ToList();
            }
            
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