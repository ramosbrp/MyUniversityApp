﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyUniversityAPI.Data;
using MyUniversityAPI.Models;
using System.Data.Entity;
using MyUniversityAPI.App_Start;

namespace MyUniversityAPI.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            //Inclui as Matriculas relacionadas com cada Disciplina
            var disciplinas = dbContext.Disciplinas.Include(a => a.Matriculas).ToList();

            // Retorna a lista como JSON
            return Json(disciplinas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Disciplina disciplina = dbContext.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }

            return View(disciplina);
        }

        [HttpPost]
        public Disciplina Create(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                dbContext.Disciplinas.Add(disciplina);
                dbContext.SaveChanges();
            }


            return disciplina;
        }


        // PUT api/student/5
        public void Put(int id, Aluno aluno)
        {
            // Aqui você vai atualizar um estudante pelo ID
        }

        // DELETE api/student/5
        public void Delete(int id)
        {
            // Aqui você vai deletar um estudante pelo ID
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}