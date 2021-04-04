using PresentationLayer.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Data
{
    public class UnitOfWork : IDisposable
    {
        private SchoolContext _context;
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Course> courseRepository;
        private GenericRepository<Enrollment> enrollmentRepository;
        public UnitOfWork(SchoolContext context)
        {
            _context = context;
        }
        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(_context);
                }
                return studentRepository;
            }
        }
        public GenericRepository<Enrollment> EnrollmentRepository
        {
            get
            {

                if (this.enrollmentRepository == null)
                {
                    this.enrollmentRepository = new GenericRepository<Enrollment>(_context);
                }
                return enrollmentRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Course>(_context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
