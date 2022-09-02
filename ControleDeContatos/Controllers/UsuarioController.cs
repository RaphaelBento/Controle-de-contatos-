using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuarioRepositorio;

        public UsuarioController(IUsuario usuario)
        {
            _usuarioRepositorio = usuario;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View("CriarUser");
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {

            usuario = _usuarioRepositorio.Adicionar(usuario);
            return View("Index");

        }
    
    }
}
