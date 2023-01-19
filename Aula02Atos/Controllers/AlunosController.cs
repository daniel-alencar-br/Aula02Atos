using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aula02Atos.Models;

namespace Aula02Atos.Controllers
{
    public class AlunosController : Controller
    {
        public List<Models.Alunos> BD()
        {
            List<Models.Alunos> Lista = new List<Alunos>();

            Lista.Add(new Models.Alunos() 
                      { ID = 1, Nome = "Joao", CPF = "123" });
            Lista.Add(new Models.Alunos()
                      { ID = 2, Nome = "Maria", CPF = "456" });
            Lista.Add(new Models.Alunos()
                      { ID = 3, Nome = "Manoel", CPF = "789" });
            Lista.Add(new Models.Alunos()
                      { ID = 4, Nome = "Carla", CPF = "468" });

            return Lista;
        }

        public Models.Alunos PesquisaAlunos(int Codigo)
        {
            // Consulta de aluno via LINK
            var Item = from Aluno in BD()
                       where Aluno.ID == Codigo
                       select new { ID = Aluno.ID, Nome = Aluno.Nome,
                                    CPF = Aluno.CPF};

            Models.Alunos Resultado = new Alunos();
            foreach (var Ler in Item)
            {
                Resultado.ID = Ler.ID;
                Resultado.Nome = Ler.Nome;
                Resultado.CPF = Ler.CPF;
            }

            return Resultado;

        }

        public ActionResult TrazerAluno(int id)
        {
            return View(PesquisaAlunos(id));
        }

        [HttpGet]
        public ActionResult IncluirAluno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirAluno(FormCollection Form)
        {
            var Cod = Convert.ToInt32(Form["id"]);
            var Nome = Form["Nome"];

            Models.Alunos Novo = new Alunos();
            Novo.ID = Cod;
            Novo.Nome = Nome;

            return View("VerAluno", Novo);
        }

        [HttpGet]
        public ActionResult IncluirAlunoTipado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirAlunoTipado(Alunos aluno)
        {
            return View("VerAluno", aluno);
        }


        // GET: Alunos
        public ActionResult Index()
        {
            return View();
        }
    }
}