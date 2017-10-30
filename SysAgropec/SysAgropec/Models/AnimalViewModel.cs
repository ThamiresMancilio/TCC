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

        public List<AnimalViewModel> animaisList;

        public List<AnimalViewModel> CarregaAnimal(string desc = "")
        {

            sysagropecConnection db = new sysagropecConnection();

            List<Animal> animais = db.Animal.ToList();

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
                    nomeraca = x.Raca.Descricao

                }

                ).ToList();


            return animalVMList;
        }

        public List<AnimalViewModel> CarregaMatrizes()
        {

            sysagropecConnection db = new sysagropecConnection();

            List<Animal> animais = db.Animal.ToList();

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

                    sysagropecConnection db = new sysagropecConnection();

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

            sysagropecConnection db = new sysagropecConnection();

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

                    sysagropecConnection db = new sysagropecConnection();

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