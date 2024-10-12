using ByteTechSchoolERP.DataAccess.Data;
using ByteTechSchoolERP.DataAccess.Filters;
using ByteTechSchoolERP.DataAccess.HRModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace ByteTechSchoolERP.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthenticationFilter]
    public class HRMController : Controller
    {

        private readonly ByteTechSchoolERPContext _context;
        private readonly RoleManager<IdentityRole> _role;
        public HRMController(ByteTechSchoolERPContext context, RoleManager<IdentityRole> role ) {

            _role = role;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Employeemanagement()
        {
            return View();
        }
        public async Task<IActionResult> AddEmployee()
        {
            ViewBag.department = await _context.Deparments.Select(o => o.Name).ToListAsync();
            return View();
        }
        public async Task<IActionResult> AddDepartment()
        {
            return View();
        }
        public async Task<IActionResult> ManageRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel model)
        {
            var employee = new Staff
            {
                Department = new Department
                {
                    Name = model.Department,
                    StaffId = Guid.Parse(model.EmployeeId),
                    Staffs = new List<Staff>() // Initialize the Staffs property
                },

                User = new ByteTechSchoolERPUser()

            };
            if (model.Photo != null && model.Photo.Length > 0)
            {
                // Define the path to save the image
                var fileName = Path.GetFileName(model.Photo.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(stream);
                }
                employee.ImageUrl = $"/images/{fileName}";

            }
            if (model.Resume != null && model.Resume.Length > 0)
            {
                // Define the path to save the image
                var fileName = Path.GetFileName(model.Resume.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Resume.CopyToAsync(stream);
                }
                employee.ResumeUrl = $"/images/{fileName}";

            }
            employee.User.UserName = model.Email;
            employee.User.PasswordHash = model.Password;    
            employee.User.Email = model.Email;
            employee.ContactNumber = model.ContactNo;
            employee.DateOfJoining = model.DateOfJoining;
            employee.FatherName = model.FatherName;
            employee.Email = model.Email;
            employee.Designation = model.Designation;
            employee.TemporaryAddress = model.Address;
            employee.PermanentAddress = model.PermanentAddress;
            employee.FirstName = model.Name;
            employee.LastName = model.Surname;
            employee.Designation = model.Designation;
            employee.EmergencyNumber = model.EmergencyNo;
            employee.MaritalStatus = model.MaritalStatus;
            employee.Note = model.Note;
            employee.Qualification
                = model.Qualification;
            employee.NumberOfExperience = model.WorkExperience;
          await _context.Staff.AddAsync(employee);
            await _context.SaveChangesAsync();

            // Generate the URL

            return View();
        }
        public async Task<IActionResult> EmployeeAttendence()
        {
            return View();
        }
        public async Task<IActionResult> LeaveRequest()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Deparments.ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRoles()
        {
            return await _role.Roles.ToListAsync();
        }

        // GET: api/department/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(Guid id)
        {
            var department = await _context.Deparments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // POST: api/department
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(string name)
        {
            Department dep = new Department
            {
                Name = name,
                Staffs = new List<Staff>() // Initialize the required Staffs property
            };

            dep.Id = Guid.NewGuid();
            _context.Deparments.Add(dep);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartment), new { id = dep.Id }, dep);
        }

        // POST: api/department
        [HttpPost]
        public async Task<ActionResult<Department>> PostRole(string name)
        {


            var role = new IdentityRole(name);
            await _role.CreateAsync(role);
            
            return CreatedAtAction(nameof(GetRoles), new { id = role.Id }, role);
        }

        // PUT: api/department/{id}
        [HttpPut]
        public async Task<IActionResult> PutDepartment(Guid id, string name)
        {
            var department = await _context.Deparments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            department.Name = name;
            // Ensure that the Staffs list is not null, initialize if necessary
            department.Staffs ??= new List<Staff>();

            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/department/{id}
        [HttpPut]
        public async Task<IActionResult> PutRole(Guid id, string name)
        {
            var Role = await _role.FindByIdAsync(id.ToString());
            if (Role == null)
            {
                return NotFound();
            }

            Role.Name = name;
            // Ensure that the Staffs list is not null, initialize if necessary

            await _role.UpdateAsync(Role);

            return NoContent();
        }

        // DELETE: api/department/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            var department = await _context.Deparments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Deparments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/department/{id}
        [HttpDelete]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            
            var role =await _role.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return NotFound();
            }
            await _role.DeleteAsync(role);
            
            return NoContent();
        }

        public async Task<IActionResult> Payroll()
        {
            return View();
        }
        public async Task<IActionResult> Loan()
        {
            return View();
        }
    }
}
