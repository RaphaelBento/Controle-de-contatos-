using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public interface IUsuario
    {
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuarioModel);
        UsuarioModel Atualizar(UsuarioModel usuarioModel);
        bool Apagar(int id);


    }
}
