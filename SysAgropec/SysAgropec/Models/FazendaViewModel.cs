using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SysAgropec.Models;

namespace SysAgropec.Models
{
    public class FazendaViewModel
    {
        public int ID { get; set; }
        public string Cnpj { get; set; }
        public string Razaosocial { get; set; }
        public string Nomefantasia { get; set; }
        public string Inscricaomunicipal { get; set; }
        public string Inscricaoestadual { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logo { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Dataalteracao { get; set; }
        public string email { get; set; }
        public string email2 { get; set; }
        public string telefone { get; set; }
        public string telefone2 { get; set; }

        public int Usuario_IDCadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }


        public List<Propriedade> CarregaFazenda()
        {

            sysagropecEntities db = new sysagropecEntities();



            List<Propriedade> fazendas = new List<Propriedade>();

            fazendas = db.Propriedade.ToList();
            
            return fazendas;
        }

        public Propriedade BuscaFazenda(int ID)
        {

            sysagropecEntities db = new sysagropecEntities();

           

            Propriedade p = db.Propriedade.SingleOrDefault(x => x.ID == ID);

            if (p.ID > 0)
            {
                return p;

            }
            return null;

        }

        public List<FazendaViewModel> CarregaFazendas()
        {

            sysagropecEntities db = new sysagropecEntities();

            List<Propriedade> fazendas = db.Propriedade.ToList();

            AnimalViewModel a = new AnimalViewModel();

            List<FazendaViewModel> f = fazendas.Select(
                x => new FazendaViewModel
                {
                    ID = x.ID,
                    Razaosocial = x.Razaosocial


                }

                ).ToList();


            return f;
        }

        public List<FazendaViewModel> CarregaFazendasUsuariosParticipantes(List<Usuario_Propriedade> userpro)
        {

            sysagropecEntities db = new sysagropecEntities();

            List<Propriedade> fazendas = db.Propriedade.ToList();

            AnimalViewModel a = new AnimalViewModel();

            List<FazendaViewModel> f = fazendas.Select(
                x => new FazendaViewModel
                {
                    ID = x.ID,
                    Razaosocial = x.Razaosocial


                }

                ).ToList();

            List<FazendaViewModel> lista = new List<FazendaViewModel>(); 

            for(int i = 0; i< userpro.Count; i++)
            {

                for(int j =0; j< f.Count; j++)
                {
                    if (userpro[i].Propriedade_ID == f[j].ID)
                    {
                        FazendaViewModel faz = new FazendaViewModel();

                        faz.ID = f[j].ID;
                        faz.Razaosocial = f[j].Razaosocial;

                        lista.Add(faz);
                    }
                }
                
            }


            return lista;
        }

        public int AdicionaFazenda(FazendaViewModel fazenda)
        {

            try
            {

                sysagropecEntities db = new sysagropecEntities();

                Propriedade f = new Propriedade();

                f.Bairro = fazenda.Bairro;
                f.Cep = fazenda.Cep;
                f.Cidade = fazenda.Cidade;
                f.Cnpj = fazenda.Cnpj;
                f.Complemento = fazenda.Complemento;
                f.Dataalteracao = fazenda.Dataalteracao;
                f.Datacadastro = fazenda.Datacadastro;
                f.Estado = fazenda.Estado;
                f.Inscricaoestadual = fazenda.Inscricaoestadual;
                f.Inscricaomunicipal = fazenda.Inscricaomunicipal;
                f.Logo = fazenda.Logo;
                f.Logradouro = fazenda.Logradouro;
                f.Nomefantasia = fazenda.Nomefantasia;
                f.Numero = fazenda.Numero;
                f.Razaosocial = fazenda.Razaosocial;
                f.Usuario_IDAlteracao = fazenda.Usuario_IDAlteracao;
                f.Usuario_IDCadastro = fazenda.Usuario_IDCadastro;
                f.Email = fazenda.email;
                f.Email2 = fazenda.email2;
                f.Telefone = fazenda.telefone;
                f.Telefone2 = fazenda.telefone2;
                
                db.Propriedade.Add(f);
                db.SaveChanges();

                int lastID = f.ID;

                return lastID;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void AtualizaFazenda(Propriedade fazenda)
        {

            if (fazenda.ID > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Propriedade f = db.Propriedade.SingleOrDefault(l => l.ID == fazenda.ID);


                    f.Bairro = fazenda.Bairro;
                    f.Cep = fazenda.Cep;
                    f.Cidade = fazenda.Cidade;
                    f.Cnpj = fazenda.Cnpj;
                    f.Complemento = fazenda.Complemento;
                    f.Dataalteracao = fazenda.Dataalteracao;
                    f.Estado = fazenda.Estado;
                    f.Inscricaoestadual = fazenda.Inscricaoestadual;
                    f.Inscricaomunicipal = fazenda.Inscricaomunicipal;
                    f.Logo = fazenda.Logo;
                    f.Logradouro = fazenda.Logradouro;
                    f.Nomefantasia = fazenda.Nomefantasia;
                    f.Numero = fazenda.Numero;
                    f.Razaosocial = fazenda.Razaosocial;
                    f.Usuario_IDAlteracao = fazenda.Usuario_IDAlteracao;
                    f.Email = fazenda.Email;
                    f.Email2 = fazenda.Email2;
                    f.Telefone = fazenda.Telefone;
                    f.Telefone2 = fazenda.Telefone2;

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