using MessageApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MessageApp.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public SidebarViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var chats = _context.ChatUsers
                .Include(c => c.Chat)
                    .ThenInclude(c => c.ChatUsers)
                        .ThenInclude(c => c.User)
                .Where(c => c.UserId == userId)
                .Select(c => c.Chat)
                .ToList();

            return View(chats);
        }
    }
}
