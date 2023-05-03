using MessageApp.Database;
using MessageApp.Enums;
using MessageApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MessageApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateChat(string userId)
        {
            var chat = new Chat
            {
                Type = ChatType.Private
            };

            chat.ChatUsers.Add(new ChatUser
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            });

            chat.ChatUsers.Add(new ChatUser
            {
                UserId = userId
            });

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync(); ;

            return RedirectToAction("Chat", new { chat.Id });
        }

        [HttpGet]
        public IActionResult Chat(int id)
        {
            var chat =  _context.Chats
                .Include(c => c.Messages)
                .Include(c => c.ChatUsers)
                    .ThenInclude(c => c.User)
                .FirstOrDefault(c => c.Id == id);

            return View(chat);
        }

        public IActionResult Users()
        {
            var users = _context.Users
                .Where(u => u.Id != User.FindFirst(ClaimTypes.NameIdentifier).Value &&
                    !u.ChatUsers.Any(c => c.Chat.ChatUsers
                        .Any(c => c.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)))
                .ToList();

            return View(users);
        }

        public async Task<IActionResult> CreateMessage(int chatId, string text)
        {
            var message = new Message
            {
                ChatId = chatId,
                Text = text,
                SenderName = User.Identity.Name,
                TimeStamp = DateTime.Now
            };

            _context.Messages.Add(message);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
