﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentCourseRegistrationMVC.Models;

namespace StudentCourseRegistrationMVC.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentContext db = new StudentContext();

        // GET: api/Students
        public IQueryable<Student> GetStudent()
        {
            return db.Student;
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.studentId)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student.Add(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.studentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student.studentId }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Student.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Student.Count(e => e.studentId == id) > 0;
        }
    }
}