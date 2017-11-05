using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class RacaViewModel
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Datalteracao { get; set; }
        public int Usuario_IDCcadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }
        public Nullable<sbyte> Excluido { get; set; }

        public List<Raca> CarregaRaca(string desc = "")
        {

            sysagropecEntities db = new sysagropecEntities();



            List<Raca> racas = new List<Raca>();

            if (!desc.Equals(""))
            {
                racas = db.Raca.Where(l => l.Descricao == desc && l.Excluido == 0).ToList();
            }
            else
            {

                racas = db.Raca.Where(l => l.Excluido == 0).ToList();
            }



            return racas;
        }


        public int AdicionaRaca(RacaViewModel raca)
        {

            try
            {

                sysagropecEntities db = new sysagropecEntities();

                Raca r = new Raca();

                r.Datacadastro = raca.Datacadastro;
                r.Datalteracao = raca.Datalteracao;
                r.Descricao = raca.Descricao;
                r.Excluido = raca.Excluido;
                r.Usuario_IDCcadastro = raca.Usuario_IDCcadastro;
                r.Usuario_IDAlteracao = raca.Usuario_IDAlteracao;

                db.Raca.Add(r);
                db.SaveChanges();

                int lastID = r.ID;

                return lastID;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void AtualizaRaca(Raca raca)
        {

            if (raca.ID > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Raca racaOLD = db.Raca.SingleOrDefault(l => l.ID == raca.ID);

                    racaOLD.Datalteracao = raca.Datalteracao;
                    racaOLD.Descricao = raca.Descricao;
                    racaOLD.Usuario_IDAlteracao = raca.Usuario_IDAlteracao;


                    db.SaveChanges();


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }


        public Raca BuscaRaca(int ID)
        {

            sysagropecEntities db = new sysagropecEntities();

            Raca r = db.Raca.SingleOrDefault(x => x.ID == ID);

            if (r.ID > 0)
            {
                return r;

            }
            return null;

        }

        public void ExcluiRaca(int idRaca)
        {

            if (idRaca > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Raca raca = db.Raca.SingleOrDefault(l => l.ID == idRaca);

                    if (raca != null)
                    {
                        raca.Excluido = 1;
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