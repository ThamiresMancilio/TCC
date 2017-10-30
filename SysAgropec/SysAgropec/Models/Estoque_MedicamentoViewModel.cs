using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class Estoque_MedicamentoViewModel
    {
        public int ID { get; set; }
        public Nullable<int> Quantidademinima { get; set; }
        public Nullable<int> Quantidademaxima { get; set; }
        public Nullable<int> Quantidadeatual { get; set; }
        public int Medicamento_ID { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }

        public string nomeMedicamento { get; set; }
        public virtual Medicamento Medicamento { get; set; }
        public virtual Usuario Usuario { get; set; }

        public List<Estoque_MedicamentoViewModel> CarregaEstoque(string desc = "")
        {

            sysagropecConnection db = new sysagropecConnection();



            List<Estoque_Medicamento> listaEstoque = db.Estoque_Medicamento.ToList();

            Estoque_MedicamentoViewModel e = new Estoque_MedicamentoViewModel();

            List<Estoque_MedicamentoViewModel> estoqueVMList = listaEstoque.Select(
                x => new Estoque_MedicamentoViewModel
                {
                    ID = x.ID,
                    Quantidadeatual = x.Quantidadeatual,
                    Usuario = x.Usuario,
                    nomeMedicamento = x.Medicamento.Nome,
                    Quantidademaxima = x.Quantidademaxima,
                    Quantidademinima = x.Quantidademinima,
                    Medicamento_ID = x.Medicamento_ID
                    
                }

                ).ToList();


            return estoqueVMList;
        }


        public void AtualizaQuantidadeEstoque(int idMedicamento, int? quantidadeUtilizada = 0)
        {

            if (idMedicamento > 0)
            {

                try
                {

                    sysagropecConnection db = new sysagropecConnection();

                    Estoque_Medicamento e = db.Estoque_Medicamento.SingleOrDefault(es => es.Medicamento_ID == idMedicamento);

                    e.Quantidadeatual = e.Quantidadeatual - quantidadeUtilizada;
                    
                    db.SaveChanges();
                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }


    }
}