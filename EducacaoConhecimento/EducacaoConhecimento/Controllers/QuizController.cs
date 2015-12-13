using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducacaoConhecimento.Models;
using EducacaoConhecimento.Helpers;
using Microsoft.AspNet.Identity;
namespace EducacaoConhecimento.Controllers
{
    public class QuizController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public string UserId { get { return User.Identity.GetUserId(); } }

        // GET: Quiz
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult VerificarAcerto(int PerguntaId, int RespostaId)
        {
            var retorno = new RetornoDTO();
            var resposta = db.Resposta.Where(x => x.PerguntaId == PerguntaId && x.RespostaId == RespostaId).FirstOrDefault();

            var profile = db.Profile.Where(x => x.CodUsuario == UserId).FirstOrDefault();
            if (profile != null)
            {
                var pontos = profile.NivelUsuario.Peso * Convert.ToInt32((Dificuldade)resposta.Pergunta.Dificuldade);

                if (resposta.Correta)
                {
                    profile.Pontuacao += pontos;
                }
                else
                {
                    profile.Pontuacao -= pontos;

                    if (profile.Pontuacao < 0)
                    {
                        profile.Pontuacao = 0;
                    }
                }
                profile.NivelUsuario = db.NivelUsuario.Where(n => profile.Pontuacao >= n.PontuacaoInicial && profile.Pontuacao <= n.PontuacaoFinal).FirstOrDefault();
                db.SaveChanges();
                retorno.Nivel = profile.NivelUsuario.Nome;
                retorno.Pontuacao = profile.Pontuacao;
            }
            else
            {
                retorno.Pontuacao = 0;
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ConsultaProfile()
        {
            var retorno = new RetornoDTO();
            try
            {

                var profile = db.Profile.Where(x => x.CodUsuario == UserId).FirstOrDefault();
                if (profile != null)
                {
                    retorno.Nivel = profile.NivelUsuario.Nome;
                    retorno.Pontuacao = profile.Pontuacao;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetPergunta()
        {
            var perguntaDTO = new PerguntaDTO();

            var obj = db.Pergunta.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (obj != null)
            {
                perguntaDTO.PerguntaId = obj.PerguntaId;
                perguntaDTO.Descricao = obj.Descricao;
                perguntaDTO.MateriaId = obj.MateriaId;
                perguntaDTO.MateriaDescricao = obj.Materia.Nome;
                perguntaDTO.Dificuldade = obj.Dificuldade.ToDescription();

                perguntaDTO.respostas = new List<RespostaDTO>();
                foreach (var item in db.Resposta.Where(x => x.PerguntaId == obj.PerguntaId).ToList())
                {
                    var resposta = new RespostaDTO()
                    {
                        RespostaId = item.RespostaId,
                        Descricao = item.Descricao,
                        Correta = item.Correta
                    };

                    perguntaDTO.respostas.Add(resposta);
                }

            }

            return Json(perguntaDTO, JsonRequestBehavior.AllowGet);

        }

    }
}