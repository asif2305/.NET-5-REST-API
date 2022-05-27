using Grpc.Core;
using GrpcServicegWithEF.Data;
using GrpcServicegWithEF.Protos;

namespace GrpcServicegWithEF.Services
{
    public class StudentService : RemoteStudent.RemoteStudentBase
    {
        private readonly ILogger<StudentService> _logger;
        private readonly SchoolDbContext _context;

        public StudentService(ILogger<StudentService> logger, SchoolDbContext context)
        {
             _logger = logger;
             _context = context;

        }
        public override Task<StudentModel> GetStudentInfo(StudentLookupModel request, ServerCallContext context)
        {
           StudentModel output = new StudentModel();
           
            var student = _context.Students.Find(request.StudentId);
            _logger.LogInformation("Sending Student response");

            if(student != null)
            {
                output.StudentId = student.StudentId;
                output.FirstName = student.FirstName;
                output.LastName = student.LastName; 
                output.School = student.School;
            }
            return Task.FromResult(output);
        }
    }
}
