using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class UsuarioViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public sbyte Admin { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Datalteracao { get; set; }
        public Nullable<System.DateTime> Dataultimoacesso { get; set; }
        public Nullable<sbyte> Excluido { get; set; }

        public Usuario ValidaUsuario(string login, string senha)
        {

            sysagropecEntities db = new sysagropecEntities();

            
            
            Usuario u = db.Usuario.SingleOrDefault(x => x.Login == login && x.Senha == senha);

            if (u != null)
            {
                ID = u.ID;
                Nome = u.Nome;
                Sobrenome = u.Sobrenome;
                Admin = u.Admin;
                Login = u.Login;
                Dataultimoacesso= u.Dataultimoacesso;
                

            }
            return u;

        }

        public int AdicionaUsuario(UsuarioViewModel usuario)
        {

            try
            {

                sysagropecEntities db = new sysagropecEntities();

                Usuario m = new Usuario();

                

                m.Datacadastro = usuario.Datacadastro;
                m.Datalteracao = usuario.Datalteracao;
                m.Dataultimoacesso = usuario.Dataultimoacesso;
                m.Login = usuario.Login;
                m.Senha = usuario.Senha;
                m.Sobrenome = usuario.Sobrenome;
                m.Excluido = m.Excluido;

                db.Usuario.Add(m);
                db.SaveChanges();

                int lastID = m.ID;

                return lastID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void AtualizaDataUltimoAcesso(int id, DateTime data)
        {

            if (id > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Usuario usuario = db.Usuario.SingleOrDefault(u => u.ID ==id);
                    
                    if (usuario != null)
                    {
                        usuario.Dataultimoacesso = data;

                        db.SaveChanges();

                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public void AtualizaUsuario(Usuario usuario)
        {

            if (usuario.ID > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Usuario usuarioOLD = db.Usuario.SingleOrDefault(u => u.ID == usuario.ID);

                    usuarioOLD.Datalteracao = usuario.Datalteracao;
                    usuarioOLD.Dataultimoacesso = usuario.Dataultimoacesso;
                    usuarioOLD.Admin = usuario.Admin;
                    usuarioOLD.Login = usuario.Login;
                    usuarioOLD.Nome = usuario.Nome;
                    usuarioOLD.Senha = usuario.Senha;
                    usuarioOLD.Sobrenome = usuario.Sobrenome;


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