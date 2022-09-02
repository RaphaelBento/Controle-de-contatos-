using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuario
    {
       
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel Adicionar(UsuarioModel usuarioModel)
        {
            usuarioModel.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuarioModel);
            _bancoContext.SaveChanges();
            return usuarioModel;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = BuscarPorId(id);
            if (usuarioDb == null) throw new Exception("Houve um erro na Exclusão do Usuário");
            _bancoContext.Usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {

            UsuarioModel usuarioDb = BuscarPorId(usuario.Id);
            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do Usuário");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuarioDb.DataAtualizacao = DateTime.Now;
            usuarioDb.Perfil = usuario.Perfil;

            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();
            return usuarioDb;
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }
    }
}
