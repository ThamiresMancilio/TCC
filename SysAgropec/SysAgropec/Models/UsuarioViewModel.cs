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

        public int AdicionaUsuario()
        {

            try
            {

                sysagropecEntities db = new sysagropecEntities();

                Usuario m = new Usuario();



                m.Datacadastro = Datacadastro;
                m.Datalteracao = Datalteracao;
                m.Dataultimoacesso = Dataultimoacesso;
                m.Login = Login;
                m.Senha = Senha;
                m.Sobrenome =Sobrenome;
                m.Excluido = Excluido;
                m.Admin = Admin;
                m.Nome = Nome;

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

        public List<Usuario> CarregaUsuario(int iduser)
        {

            sysagropecEntities db = new sysagropecEntities();
            
            List<Usuario> usuarios = new List<Usuario>();

            if(iduser > 0)
            {
                usuarios = db.Usuario.Where(l => l.Excluido == 0 && l.ID ==iduser).ToList();
            }
            else{
                usuarios = db.Usuario.Where(l => l.Excluido == 0).ToList();
            }

            
            
            return usuarios;
        }

        public void ExcluiUsuario(int idUsuario)
        {

            if (idUsuario > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Usuario usuario = db.Usuario.SingleOrDefault(l => l.ID == idUsuario);

                    if (usuario != null)
                    {
                        usuario.Excluido = 1;
                        db.SaveChanges();
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }
        }

        public void AtualizaUsuario()
        {

            if (ID > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Usuario usuarioOLD = db.Usuario.SingleOrDefault(u => u.ID == ID);

                    usuarioOLD.Datalteracao = Datalteracao;
                    usuarioOLD.Dataultimoacesso = Dataultimoacesso;
                    usuarioOLD.Admin = Admin;
                    usuarioOLD.Login = Login;
                    usuarioOLD.Nome = Nome;
                    usuarioOLD.Senha = Senha;
                    usuarioOLD.Sobrenome = Sobrenome;
                    
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