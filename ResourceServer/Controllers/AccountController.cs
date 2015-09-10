using System.Threading.Tasks;
using System.Web.Http;
using CodeFirstModelFromDB;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ResourceServer.Controllers
{
    public class AccountController : ApiController
    {
        private readonly AngularDbContext _db;
        private readonly UserStore<User> _userStore;
        private readonly UserManager<User> _userManager;

        public AccountController()
        {
            _db = new AngularDbContext();
            _userStore = new UserStore<User>(_db);
            _userManager = new UserManager<User>(_userStore);
        }

        public async Task<IHttpActionResult> RegisterUser(User user)
        {
            var identityResult = await _userManager.CreateAsync(user, user.PasswordHash);
            return Ok();
        }
    }
}
