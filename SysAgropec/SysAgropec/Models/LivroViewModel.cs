using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SysAgropec.Models;
using System.Runtime.Serialization.Json;

namespace SysAgropec.Models
{
    public class LivroViewModel

    {
        public int ID { get; set; }

        public string Descricao { get; set; }
        public DateTime Datacadastro { get; set; }
        public Nullable<DateTime> Datalteracao { get; set; }
        public Nullable<sbyte> Excluido { get; set; }
        public int Usuario_IDCadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }


        public List<Livro> CarregaLivro(string desc ="")
        {

            sysagropecEntities db = new sysagropecEntities();

            

            List<Livro> livros = new List<Livro>();

            if (!desc.Equals(""))
            {
                livros = db.Livro.Where(l => l.Descricao == desc && l.Excluido == 0).ToList();
            }
            else {

                livros = db.Livro.Where(l =>  l.Excluido == 0).ToList();
            }

            

            return livros;
        }


        public int AdicionaLivro(LivroViewModel livro)
        {

            try
            {

                sysagropecEntities db = new sysagropecEntities();

                Livro l = new Livro();

                l.Datacadastro = livro.Datacadastro;
                l.Datalteracao = livro.Datalteracao;
                l.Descricao = livro.Descricao;
                l.Excluido = livro.Excluido;
                l.Usuario_IDCadastro = livro.Usuario_IDCadastro;
                l.Usuario_IDAlteracao = livro.Usuario_IDAlteracao;

                db.Livro.Add(l);
                db.SaveChanges();

                int lastID = l.ID;

                return lastID;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void AtualizaLivro(Livro livro)
        {

            if (livro.ID > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Livro livroOLD = db.Livro.SingleOrDefault(l => l.ID == livro.ID);

                    livroOLD.Datalteracao = livro.Datalteracao;
                    livroOLD.Descricao = livro.Descricao;
                    livroOLD.Usuario_IDAlteracao = livro.Usuario_IDAlteracao;

                    
                    db.SaveChanges();
                    
                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }


        public Livro BuscaLivro(int ID)
        {

            sysagropecEntities db = new sysagropecEntities();

            //Livro l = db.Livro.SingleOrDefault(x => (ID > 0) ? x.ID == ID : x.Descricao == livro);

            Livro l = db.Livro.SingleOrDefault(x =>  x.ID == ID);

            if (l.ID > 0)
            {
                return l;

            }
            return null;

        }

        public void ExcluiLivro(int idLivro)
        {

            if (idLivro > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Livro livro = db.Livro.SingleOrDefault(l => l.ID == idLivro);

                    if (livro != null) {
                        livro.Excluido = 1;
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