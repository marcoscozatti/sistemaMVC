using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.DAO;
using Sistema.Entidades;

namespace Sistema.Model
{
    public class UsuarioModel
    {
        public static int Inserir(UsuariosEnt objetoTabela)
        {
            return new UsuarioDAO().Inserir(objetoTabela);
        }

        public List<UsuariosEnt> Lista()
        {
           return new UsuarioDAO().Lista();

        }

        public UsuariosEnt Login(UsuariosEnt obj)
        {
            return new UsuarioDAO().Login(obj);

        }
    } 
}
