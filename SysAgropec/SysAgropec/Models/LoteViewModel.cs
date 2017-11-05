using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class LoteViewModel
    {
        public int ID { get; set; }
        public string Numerolote { get; set; }
        public System.DateTime Datafabricacao { get; set; }
        public System.DateTime Datavalidade { get; set; }
        public string Observacao { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Dataalteracao { get; set; }
        public int Propriedade_ID { get; set; }
        public int Usuario_IDCadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }


        public List<Lote> CarregaLote(string desc = "")
        {

            sysagropecEntities db = new sysagropecEntities();
            
            List<Lote> lotes = new List<Lote>();

            if (!desc.Equals(""))
            {
                lotes = db.Lote.Where(l => l.Numerolote == desc).ToList();
            }
            else
            {

                lotes = db.Lote.ToList();
            }
            
            return lotes;
        }


        public int AdicionaLote(LoteViewModel lote)
        {

            try
            {

                sysagropecEntities db = new sysagropecEntities();

                Lote l = new Lote();

                l.Numerolote = lote.Numerolote;
                l.Observacao = lote.Observacao;
                l.Propriedade_ID = lote.Propriedade_ID;

                l.Dataalteracao = lote.Dataalteracao;
                l.Datacadastro = lote.Datacadastro;

                l.Datafabricacao = lote.Datafabricacao;
                l.Datavalidade = lote.Datavalidade;

                l.Usuario_IDAlteracao = lote.Usuario_IDAlteracao;
                l.Usuario_IDCadastro = lote.Usuario_IDCadastro;

                

                db.Lote.Add(l);
                db.SaveChanges();

                int lastID = l.ID;

                return lastID;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void AtualizaLote(Lote lote)
        {

            if (lote.ID > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Lote loteOLD = db.Lote.SingleOrDefault(l => l.ID == lote.ID);


                    loteOLD.Dataalteracao = lote.Dataalteracao;
                    loteOLD.Datafabricacao = lote.Datafabricacao;
                    loteOLD.Datavalidade = lote.Datavalidade;
                    loteOLD.Observacao = lote.Observacao;
                    loteOLD.Numerolote = lote.Numerolote;
                    loteOLD.Usuario_IDAlteracao = lote.Usuario_IDAlteracao;
                    

                    db.SaveChanges();


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }


        public Lote BuscaLote(int ID)
        {

            sysagropecEntities db = new sysagropecEntities();

            Lote l = db.Lote.SingleOrDefault(x => x.ID == ID);

            if (l.ID > 0)
            {
                
                return l;

            }
            return null;

        }

        public void ExcluiLote(int idLote)
        {

            if (idLote > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Lote lote = db.Lote.SingleOrDefault(l => l.ID == idLote);

                    if (lote != null)
                    {
                        db.Lote.Remove(lote);
                        
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