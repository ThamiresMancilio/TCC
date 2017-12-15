using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class AnimalViewModel
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Registro { get; set; }
        public string Tatuagem { get; set; }
        public Nullable<int> Numerobrinco { get; set; }
        public Nullable<System.DateTime> Datanascimento { get; set; }
        public Nullable<sbyte> Morto { get; set; }
        public string Observacao { get; set; }
        public System.DateTime Datacadastro { get; set; }
        public Nullable<System.DateTime> Datalteracao { get; set; }
        public string Registropai { get; set; }
        public string Tatuagempai { get; set; }
        public string Descricaopai { get; set; }
        public string Registromae { get; set; }
        public string Tatuagemae { get; set; }
        public string Descricaomae { get; set; }
        public Nullable<int> Sexo { get; set; }
        public Nullable<sbyte> Lactacao { get; set; }
        public Nullable<int> Dias_lactacao { get; set; }
        public Nullable<System.DateTime> Datalactacao { get; set; }
        public int Livro_ID { get; set; }
        public int Raca_ID { get; set; }
        public int Propriedade_ID { get; set; }
        public int Usuario_IDCadastro { get; set; }
        public Nullable<int> Usuario_IDAlteracao { get; set; }

        public string nomelivro { get; set; }
        public string nomeraca { get; set; }

        public string descriSexo { get; set; }

        public List<AnimalViewModel> animaisList;

        public List<AnimalViewModel> CarregaAnimal(int codFazenda, int sexoP,string regIP = "", string regFP = "", string tatuagemP = "")
        {

            sysagropecEntities db = new sysagropecEntities();

            List<Animal> animais;

            if(sexoP >= 0)
            {
                animais = db.Animal.Where(x => x.Sexo ==sexoP && x.Propriedade_ID ==codFazenda).ToList();
            }
            else
            {
                animais = db.Animal.Where(x=> x.Propriedade_ID == codFazenda).ToList();
            }

            
            if(!regIP.Equals("") || !regFP.Equals("") || !tatuagemP.Equals(""))
            {

                for (int i =0; i<animais.Count; i++)
                {
                    if (!regIP.Equals(""))
                    {
                        if(Convert.ToInt64(animais[i].Registro) < Convert.ToInt64(regIP))
                        {
                            animais.RemoveAt(i);
                        }
                    }

                    if (!regFP.Equals(""))
                    {
                        if (Convert.ToInt64(animais[i].Registro) > Convert.ToInt64(regFP))
                        {
                            animais.RemoveAt(i);
                        }
                    }

                    if (!tatuagemP.Equals(""))
                    {
                        if (animais[i].Tatuagem != tatuagemP)
                        {
                            animais.RemoveAt(i);
                        }
                    }


                }
                
            }
            
            AnimalViewModel a = new AnimalViewModel();

            List<AnimalViewModel> animalVMList = animais.Select(
                x => new AnimalViewModel
                {
                    ID = x.ID,
                    Descricao = x.Descricao,
                    Registro = x.Registro,
                    Datacadastro = x.Datacadastro,
                    Datalteracao = x.Datalteracao,
                    Datalactacao = x.Datalactacao,
                    Datanascimento = x.Datanascimento,
                    Descricaomae = x.Descricaomae,
                    Descricaopai = x.Descricaopai,
                    Dias_lactacao = x.Dias_lactacao,
                    Lactacao = x.Lactacao,
                    Morto = x.Morto,
                    Numerobrinco = x.Numerobrinco,
                    Observacao = x.Observacao,
                    Sexo = x.Sexo,
                    Tatuagem = x.Tatuagem,
                    Registromae = x.Registromae,
                    Registropai = x.Registropai,
                    Tatuagemae = x.Tatuagemae,
                    Tatuagempai = x.Tatuagempai,
                    Livro_ID = x.Livro_ID,
                    Raca_ID = x.Raca_ID,
                    Usuario_IDAlteracao = x.Usuario_IDAlteracao,
                    Usuario_IDCadastro = x.Usuario_IDCadastro,
                    nomelivro = x.Livro.Descricao,
                    nomeraca = x.Raca.Descricao,
                    descriSexo = x.Sexo == 1 ? "F" : "M"
                    
                }

                ).ToList();


            return animalVMList;
        }

       

        public List<AnimalViewModel> RelatorioAnimais(int codFazenda,DateTime dataCadI, DateTime dataCadF)
        {
            sysagropecEntities db = new sysagropecEntities();

            List<Animal> animaisrel = db.Animal.Where(x => x.Datacadastro >= dataCadI &&
            x.Datacadastro <= dataCadF && x.Propriedade_ID == codFazenda
            ).OrderBy(x => x.Sexo).ThenBy(x => x.Raca.Descricao).ToList();

            //List<Animal> animaisrel = db.Animal.OrderBy(x => x.Sexo).ThenBy(x => x.Raca_ID).ToList();



            AnimalViewModel a = new AnimalViewModel();

            List<AnimalViewModel> animalVMList = animaisrel.Select(
                x => new AnimalViewModel
                {
                    ID = x.ID,
                    Descricao = x.Descricao,
                    Registro = x.Registro,
                    nomelivro = x.Livro.Descricao,
                    nomeraca = x.Raca.Descricao,
                    Datanascimento = x.Datanascimento,
                    Tatuagem = x.Tatuagem, 
                    Numerobrinco = x.Numerobrinco,
                    Raca_ID = x.Raca_ID,
                    descriSexo = x.Sexo ==0 ? "M" : "F",
                    Datacadastro = x.Datacadastro
                    

                }

                ).ToList();


            return animalVMList;


        }

        //utilizado para a produção leiteira
        public List<AnimalViewModel> CarregaMatrizes(int codFazenda)
        {

            sysagropecEntities db = new sysagropecEntities();

            List<Animal> animais = db.Animal.Where(x => x.Sexo ==1 && (x.Morto ==0 || x.Morto ==null) &&  x.Propriedade_ID == codFazenda).ToList();

            AnimalViewModel a = new AnimalViewModel();

            List<AnimalViewModel> animalVMList = animais.Select(
                x => new AnimalViewModel
                {
                    ID = x.ID,
                    Descricao = x.Descricao,
                    Registro = x.Registro
                }

                ).ToList();


            return animalVMList;
        }

        //utilizado para a aplicação de medicamentos
        public List<AnimalViewModel> CarregaGado(int codFazenda)
        {

            sysagropecEntities db = new sysagropecEntities();

            List<Animal> animais = db.Animal.Where(x => (x.Morto == 0 || x.Morto ==null) && x.Propriedade_ID == codFazenda).ToList();

            AnimalViewModel a = new AnimalViewModel();

            List<AnimalViewModel> animalVMList = animais.Select(
                x => new AnimalViewModel
                {
                    ID = x.ID,
                    Descricao = x.Descricao,
                    Registro = x.Registro


                }

                ).ToList();


            return animalVMList;
        }
        public void AtualizaAnimal(Animal animal)
        {

            if (animal.ID > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Animal animalOLD = db.Animal.SingleOrDefault(l => l.ID == animal.ID);

                    animalOLD.Datalteracao = animal.Datalteracao;
                    animalOLD.Usuario_IDAlteracao = animal.Usuario_IDAlteracao;
                    animalOLD.Datanascimento = animal.Datanascimento;
                    animalOLD.Descricao = animal.Descricao;
                    animalOLD.Descricaomae = animal.Descricaomae;
                    animalOLD.Descricaopai = animal.Descricaopai;
                    animalOLD.Dias_lactacao = animal.Dias_lactacao;
                    animalOLD.Lactacao = animal.Lactacao;
                    animalOLD.Livro_ID = animal.Livro_ID;
                    animalOLD.Morto = animal.Morto;
                    animalOLD.Numerobrinco = animal.Numerobrinco;
                    animalOLD.Observacao = animal.Observacao;
                    animalOLD.Raca_ID = animal.Raca_ID;
                    animalOLD.Registro = animal.Registro;
                    animalOLD.Registromae = animal.Registromae;
                    animalOLD.Registropai = animal.Registropai;
                    animalOLD.Sexo = animal.Sexo;
                    animalOLD.Tatuagem = animal.Tatuagem;
                    animalOLD.Tatuagemae = animal.Tatuagemae;
                    animalOLD.Tatuagempai = animal.Tatuagempai;
                    animalOLD.Usuario_IDAlteracao = animal.Usuario_IDAlteracao;
                    
                    db.SaveChanges();


                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }


        public Animal BuscaAnimal(int ID)
        {

            sysagropecEntities db = new sysagropecEntities();

            Animal a = db.Animal.SingleOrDefault(x => x.ID == ID);

            if (a.ID > 0)
            {
                return a;

            }
            return null;

        }

        public void ExcluiAnimal(int idAnimal)
        {

            if (idAnimal > 0)
            {

                try
                {

                    sysagropecEntities db = new sysagropecEntities();

                    Animal animal = db.Animal.SingleOrDefault(l => l.ID == idAnimal);

                    if (animal != null)
                    {
                        db.Animal.Remove(animal);
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