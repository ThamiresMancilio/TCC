using MySql.Data.MySqlClient;
using SysAgropec.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SysAgropec.Models
{
    public class Usuario_Propriedade
    {

        public int Usuario_ID { get; set; }

        public int Propriedade_ID { get; set; }

        public List<Usuario_Propriedade> usuarios_propriedades { get; set; }

        public int[] idsPropriedades { get; set; }

        public List<Usuario_Propriedade> getUserPropriedadeByID(int iduser)
        {
            int contador = 0;
            usuarios_propriedades = new List<Usuario_Propriedade>();

            idsPropriedades = new int[10];

            string text = "Select * from Usuario_Propriedade where Usuario_ID = " + iduser;

            using (MySqlConnection connection = new MySqlConnection(Banco.getConexao()))

            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(text, connection))
                {

                    command.CommandType = CommandType.Text;
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Usuario_Propriedade userpropri = new Usuario_Propriedade();

                            userpropri.Usuario_ID = reader.GetInt16(0);
                            userpropri.Propriedade_ID = reader.GetInt16(1);

                            usuarios_propriedades.Add(userpropri);

                            idsPropriedades[contador] = userpropri.Propriedade_ID;
                            contador++;
                            
                        }
                        return usuarios_propriedades;
                    }
                }
            }

        }
    }
}