using Microsoft.AspNetCore.Mvc;
using StudentInformation.Models;

namespace StudentInformation.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> studentList = new List<Student>();
        [HttpGet]
        public IActionResult Index()
        {
            return View(studentList);
        }

        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterStudent(Student student)
        {
            if (student.FullName == "")
            {
                ModelState.AddModelError("Name", "Name cannot be empty.");
            }

            if (ModelState.IsValid)
            {
                student.StudentID = studentList.Count + 1;
                studentList.Add(student);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = studentList.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentID)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingStudent = studentList.FirstOrDefault(s => s.StudentID == id);
                if (existingStudent == null)
                    return NotFound();

                // Update student details
                existingStudent.FullName = student.FullName;
                existingStudent.DateOfBirth = student.DateOfBirth;
                existingStudent.Gender = student.Gender;
                existingStudent.Address = student.Address;
                existingStudent.ContactNumber = student.ContactNumber;

                return RedirectToAction("Index");
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var pet = studentList.FirstOrDefault(s => s.StudentID == id);
            if (pet == null)
                return NotFound();
            return View(pet);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = studentList.FirstOrDefault(s => s.StudentID == id);
            if
    (student != null)
            {
                studentList.Remove(student);

            }
            return RedirectToAction("Index");

        }
    }
}