using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{

    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemAprovacao"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro não foi possivel cadastrar o contato código do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemAprovacao"] = "Contato Alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar",contato);
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ocorreu um erro não foi possivel alterar o contato {erro.Message}";
                return View("Editar", contato);
            }
        }

        public IActionResult Apagar(int id)
        {
            
            try
            {
                bool Apagar = _contatoRepositorio.Apagar(id);

                if (Apagar)
                {
                    TempData["MensagemAprovacao"] = "Contato excluido com sucesso";
                }
                else 
                {
                    TempData["MensagemErro"] = "não foi possivel excluir o contato selecionado";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"não foi possivel excluir o contato selecionado código de erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
