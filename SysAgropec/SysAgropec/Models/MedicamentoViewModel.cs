using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class MedicamentoViewModel
    {

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> Carencialeite { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Datalteracao { get; set; }
        public int Lote_ID { get; set; }
        public int Usuario_IDCadastro { get; set; }
        public int? Usuario_IDAlteracao { get; set; }
        public string Numerolote { get; set; }


        public List<MedicamentoViewModel> CarregaMedicamento(string desc = "")
        {

            sysagropecConnection db = new sysagropecConnection();



            List<Medicamento> medicamentos = db.Medicamento.ToList();

            MedicamentoViewModel m = new MedicamentoViewModel();

            List<MedicamentoViewModel> medicamentoVMList = medicamentos.Select(
                x => new MedicamentoViewModel
                {
                    ID = x.ID,
                    Nome = x.Nome,
                    Descricao = x.Descricao,
                    Carencialeite  = x.Carencialeite,
                    Lote_ID = x.Lote_ID,
                    Numerolote = x.Lote.Numerolote

                }

                ).ToList();

            
            return medicamentoVMList;
        }


        public int AdicionaMedicamentos(MedicamentoViewModel medicamento)
        {
            
            try
            {

                sysagropecConnection db = new sysagropecConnection();

                Medicamento m = new Medicamento();

                m.Datacadastro = medicamento.Datacadastro;
                m.Datalteracao = medicamento.Datalteracao;
                m.Descricao = medicamento.Descricao;
                m.Carencialeite = medicamento.Carencialeite;
                m.Nome = medicamento.Nome;
                m.Usuario_IDAlteracao = medicamento.Usuario_IDAlteracao;
                m.Usuario_IDCadastro = medicamento.Usuario_IDCadastro;
                
                db.Medicamento.Add(m);
                db.SaveChanges();

                int lastID = m.ID;

                return lastID;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void AtualizaMedicamento(Medicamento medicamento)
        {

            if (medicamento.ID > 0)
            {

                try
                {

                    sysagropecConnection db = new sysagropecConnection();

                    Medicamento medicamentoOLD = db.Medicamento.SingleOrDefault(l => l.ID == medicamento.ID);

                    medicamentoOLD.Datalteracao = medicamento.Datalteracao;
                    medicamentoOLD.Lote_ID = medicamento.Lote_ID;
                    medicamentoOLD.Nome = medicamento.Nome;
                    medicamentoOLD.Descricao = medicamento.Descricao;
                    medicamentoOLD.Carencialeite = medicamento.Carencialeite;
                    medicamentoOLD.Usuario_IDAlteracao = medicamento.Usuario_IDAlteracao;

                    db.SaveChanges();


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }


        public Medicamento BuscaMedicamento(int ID)
        {

            sysagropecConnection db = new sysagropecConnection();
            
            Medicamento m = db.Medicamento.SingleOrDefault(x => x.ID == ID);

            if (m.ID > 0)
            {
                return m;

            }
            return null;

        }

        public void ExcluiMedicamento(int idMedicamento)
        {

            if (idMedicamento > 0)
            {

                try
                {

                    sysagropecConnection db = new sysagropecConnection();

                    Medicamento medicamento = db.Medicamento.SingleOrDefault(l => l.ID == idMedicamento);

                    if (medicamento != null)
                    {
                        db.Medicamento.Remove(medicamento);
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