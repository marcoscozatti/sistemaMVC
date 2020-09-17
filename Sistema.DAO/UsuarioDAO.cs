using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.DAO;
using Sistema.Entidades;
using System.Data.SqlClient;
using System.Data;


namespace Sistema.DAO
{
    public class UsuarioDAO
    {
        public int Inserir(UsuariosEnt objetoTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                //soliita que inclua o Default
                //arquivo properties.settings.banco foi copiado de app.config
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cm = new SqlCommand();
                con.Open();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "INSERT INTO USUARIOS ([nome], [usuario], [senha]) values (@nome, @usuario, @senha)";

                cm.Parameters.Add("nome", SqlDbType.VarChar).Value = objetoTabela.Nome;
                cm.Parameters.Add("usuario", SqlDbType.VarChar).Value = objetoTabela.Usuario;
                cm.Parameters.Add("senha", SqlDbType.VarChar).Value = objetoTabela.Senha;

                cm.Connection = con;

                int qtd = cm.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }

        }

        public UsuariosEnt Login(UsuariosEnt obj)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cm = new SqlCommand();
                con.Open();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "SELECT  * FROM usuarios WHERE usuario = @usuario AND senha = @senha";

                cm.Connection = con;

                cm.Parameters.Add("usuario", SqlDbType.VarChar).Value = obj.Usuario;
                cm.Parameters.Add("senha", SqlDbType.VarChar).Value = obj.Senha;

                SqlDataReader dr;
                dr = cm.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuariosEnt dado = new UsuariosEnt();
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);

                    }
                }
                else
                {
                    obj.Usuario = null;
                    obj.Senha = null;
                }
                return obj;
            }
        }

        public List<UsuariosEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                //soliita que inclua o Default
                //arquivo properties.settings.banco foi copiado de app.config
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cm = new SqlCommand();
                con.Open();
                cm.CommandType = CommandType.Text;
                cm.CommandText = "SELECT  * FROM usuarios ORDER BY id DESC";

                cm.Connection = con;
                SqlDataReader dr;
                List<UsuariosEnt> lista = new List<UsuariosEnt>();
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuariosEnt dado = new UsuariosEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);

                        lista.Add(dado);

                    }
                }
                return lista;

            }
        }
    }
}
