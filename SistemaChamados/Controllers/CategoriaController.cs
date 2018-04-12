    using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaChamados.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaNeg objCategoriaNeg;
        
        public CategoriaController()
        {
            objCategoriaNeg = new CategoriaNeg();
        }
        // GET: Categoria
        public ActionResult Index()
        {
            Categoria objCategoria = new Categoria();
            List<Categoria> lista = objCategoriaNeg.findAll();
            mensagemErroServidor(objCategoria);
            return View(lista);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados e clique em Salvar";
        }

        [HttpGet]
        public ActionResult Create()
        {
            mensagemInicioRegistrar();
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Categoria objCategoria)
        {
            mensagemInicioRegistrar();
            objCategoriaNeg.create(objCategoria);
            MensagemErrorRegistrar(objCategoria);
            return View("Create");
            
        }

        public void MensagemErrorRegistrar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {
                case 1000:
                    ViewBag.MensagemErro = "Erro!!! Revise a instrução de inserir";
                    break;
                case 10://campo codigo vazio
                    ViewBag.MensagemErro = "Insira o Código da Categoria";
                    break;

                case 20://campo codigo vazio
                    ViewBag.MensagemErro = "Insira o nome da Categoria";
                    break;
                case 1://error campo codigo
                    ViewBag.MensagemErro = "O código não pode ter mais de 5 numeros";
                    break;
                
                case 2://erro de nome
                    ViewBag.MensagemErro = "Não insira mais de 30 caracteres no campo nome";
                    break;

                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Categoria [" + objCategoria.IdCategoria + "] já está Registrada no Sistema";
                    break;


                case 99://Categoria inserida com exito
                    ViewBag.MensagemExito = "Categoria [" + objCategoria.IdCategoria + "] foi inserida no sistema";
                    break;

            }

        }
            
        // POST: Categoria/Delete/5
        [HttpGet]
        public ActionResult Delete(long id)
        {
            mensagemInicialEliminar();
            Categoria objCategoria = new Categoria(id);
            objCategoriaNeg.find(objCategoria);
            return View(objCategoria);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            mensagemInicialEliminar();
            Categoria objCategoria = new Categoria(id);
            objCategoriaNeg.delete(objCategoria);
            mostrarMensagemEliminar(objCategoria);
            return Redirect("~/Categoria/Index");
        }



        public void mensagemErroServidor(Categoria objCategoria)
        {
            switch (objCategoria.Estado)
            {
                case 1000:
                    ViewBag.MensagemErro = "ERRO DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }

        //mensagem de erro
        public void MensagemErrorAtualizar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {

                case 1000://campo codigo vacio
                    ViewBag.MensagemErro = "Erro!!! Revise a instrução de inserir";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensagemErro = "Insira o Código da Categoria";
                    break;
                case 1://error campo codigo
                    ViewBag.MensagemErro = "O código não pode ter mais de 5 numeros";
                    break;
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o nome do cliente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "Não insira mais de 30 caracteres no campo nome";
                    break;

                case 30://campo descricao vazio
                    ViewBag.MensagemErro = "Insira descrição da categoria";
                    break;

                case 3://erro campo descricao 
                    ViewBag.MensagemErro = "Não é permitido mais que 30 caracteres";
                    break;



                case 99://atualizado com sucesso
                    ViewBag.MensagemExito = "Dados da Categoria [" + objCategoria.IdCategoria + "] Foram Modificados";
                    break;

            }

        }

        private void mostrarMensagemEliminar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {
                case 1000://campo codigo vazio
                    ViewBag.MensagemError = "Error!!! Revise a instrução de excluir";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Categoria [" + objCategoria.IdCategoria + "] Não está mais no sistema! ";
                    break;

                case 33://CATEGORIA NAO EXISTE
                    ViewBag.MensagemError = "Categoria: [" + objCategoria.Nome + "] já foi Eliminada";
                    break;

                case 99: //EXITO
                    ViewBag.MensagemExito = "Categoria [" + objCategoria.Nome + "] Foi Excluida!!!";
                    break;

                default:
                    ViewBag.MensagemError = "===Deu Erro ???===";
                    break;
            }
        }

        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulario de Eliminação";
        }

        public void mensagemInicioAtualizar()
        {
            ViewBag.MensajeInicio = "Insira os dados para alterar a categoria";
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            mensagemInicioAtualizar();
            Categoria objCategoria = new Categoria(id);
            objCategoriaNeg.find(objCategoria);
            return View(objCategoria);
        }
        [HttpPost]
        public ActionResult Update(Categoria objCategoria)
        {
            mensagemInicioAtualizar();
            objCategoriaNeg.update(objCategoria);
            MensagemErrorAtualizar(objCategoria);
            return View();
        }
    }
}
