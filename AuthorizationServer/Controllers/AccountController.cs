using System;
using System.Threading.Tasks;
using System.Web.Http;
using CodeFirstModelFromDB;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthorizationServer.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly ElearningDbContext _db;
        private readonly UserStore<User> _userStore;
        private readonly UserManager<User> _userManager;

        public AccountController()
        {
            _db = new ElearningDbContext();
            _userStore = new UserStore<User>(_db);
            _userManager = new UserManager<User>(_userStore);
        }

        [Route("")]
        public async Task<IHttpActionResult> Post(User user)
        {
            var identityResult = await _userManager.CreateAsync(user, user.PasswordHash);
            return Ok();
        }
    }
}
