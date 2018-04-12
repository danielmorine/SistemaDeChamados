using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaChamados.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteNeg objClienteNeg;

        public ClienteController()
        {
            objClienteNeg = new ClienteNeg();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            Cliente objCliente = new Cliente();
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados e clique em salvar";
        }

        [HttpGet]
        public ActionResult Create()
        {
            mensagemInicioRegistrar();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente objCliente)
        {
            mensagemInicioRegistrar();
            objClienteNeg.create(objCliente);
            MensagemErrorRegistrar(objCliente);
           
                return View("Create");
        }

        public void MensagemErrorRegistrar(Cliente objCliente)
        {
            switch (objCliente.Estado)
            {
                case 1000:
                    ViewBag.MensagemErro = "Erro!!! Revise a instrução de inserir";
                    break;
                case 10://campo codigo vazio
                    ViewBag.MensagemErro = "Insira o Código do Cliente";
                    break;

                case 20://campo codigo vazio
                    ViewBag.MensagemErro = "Insira o nome do Cliente";
                    break;
                case 1://error campo codigo
                    ViewBag.MensagemErro = "O código não pode ter mais de 5 numeros";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "Não insira mais de 50 caracteres no campo nome";
                    break;

                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Cliente [" + objCliente.IdCliente + "] já está Registrada no Sistema";
                    break;


                case 99://Cliente inserido com exito
                    ViewBag.MensagemExito = "Cliente [" + objCliente.IdCliente + "] foi inserida no sistema";
                    break;
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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

        public void mensagemErroServidor(Cliente objCliente)
        {
            switch (objCliente.Estado)
            {
                case 1000:
                    ViewBag.MensagemErro = "ERRO DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }

        //mensagem de erro
        public void MensagemErrorAtualizar(Cliente objCliente)
        {

            switch (objCliente.Estado)
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
                    ViewBag.MensagemExito = "Dados da Categoria [" + objCliente.IdCliente + "] Foram Modificados";
                    break;

            }

        }
    }
}
