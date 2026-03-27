using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project2EmailNight.Context;
using Project2EmailNight.Entities;

namespace Project2EmailNight.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private void SetFolderCounts(string email)
        {
            ViewBag.InboxCount = _context.Messages.Count(x => x.ReceiverEmail == email && !x.IsTrash && !x.IsSpam && !x.IsDraft);
            ViewBag.StarredCount = _context.Messages.Count(x => x.ReceiverEmail == email && x.IsStarred && !x.IsTrash);
            ViewBag.SendBoxCount = _context.Messages.Count(x => x.SenderEmail == email && !x.IsTrash && !x.IsDraft);
            ViewBag.DraftsCount = _context.Messages.Count(x => x.SenderEmail == email && x.IsDraft && !x.IsTrash);
            ViewBag.SpamCount = _context.Messages.Count(x => x.ReceiverEmail == email && x.IsSpam && !x.IsTrash);
            ViewBag.TrashCount = _context.Messages.Count(x => (x.ReceiverEmail == email || x.SenderEmail == email) && x.IsTrash);

            ViewBag.IsCount = _context.Messages.Count(x => x.ReceiverEmail == email && x.Category == "İş" && !x.IsTrash);
            ViewBag.AileCount = _context.Messages.Count(x => x.ReceiverEmail == email && x.Category == "Aile" && !x.IsTrash);
            ViewBag.EgitimCount = _context.Messages.Count(x => x.ReceiverEmail == email && x.Category == "Eğitim" && !x.IsTrash);
            ViewBag.SosyalCount = _context.Messages.Count(x => x.ReceiverEmail == email && x.Category == "Sosyal" && !x.IsTrash);
        }

        private void SetPagination(int totalItems, int page)
        {
            int pageSize = 13; 
            ViewBag.TotalItems = totalItems;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }

        public async Task<IActionResult> Inbox(int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user; ViewBag.ActiveFolder = "Inbox";
            SetFolderCounts(user.Email);

            var query = _context.Messages.Where(x => x.ReceiverEmail == user.Email && !x.IsTrash && !x.IsSpam && !x.IsDraft).OrderByDescending(x => x.SendDate);
            SetPagination(query.Count(), page);

            var messageList = query.Skip((page - 1) * 13).Take(13).ToList();
            return View(messageList);
        }

        public async Task<IActionResult> SendBox(int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user; ViewBag.ActiveFolder = "SendBox";
            SetFolderCounts(user.Email);

            var query = _context.Messages.Where(x => x.SenderEmail == user.Email && !x.IsTrash && !x.IsDraft).OrderByDescending(x => x.SendDate);
            SetPagination(query.Count(), page);
            var messageList = query.Skip((page - 1) * 13).Take(13).ToList();
            return View("Inbox", messageList);
        }

        public async Task<IActionResult> Starred(int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user; ViewBag.ActiveFolder = "Starred";
            SetFolderCounts(user.Email);

            var query = _context.Messages.Where(x => x.ReceiverEmail == user.Email && x.IsStarred && !x.IsTrash).OrderByDescending(x => x.SendDate);
            SetPagination(query.Count(), page);
            var messageList = query.Skip((page - 1) * 13).Take(13).ToList();
            return View("Inbox", messageList);
        }

        public async Task<IActionResult> Trash(int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user; ViewBag.ActiveFolder = "Trash";
            SetFolderCounts(user.Email);

            var query = _context.Messages.Where(x => (x.ReceiverEmail == user.Email || x.SenderEmail == user.Email) && x.IsTrash).OrderByDescending(x => x.SendDate);
            SetPagination(query.Count(), page);
            var messageList = query.Skip((page - 1) * 13).Take(13).ToList();
            return View("Inbox", messageList);
        }

        public async Task<IActionResult> Drafts(int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user; ViewBag.ActiveFolder = "Drafts";
            SetFolderCounts(user.Email);

            var query = _context.Messages.Where(x => x.SenderEmail == user.Email && x.IsDraft && !x.IsTrash).OrderByDescending(x => x.SendDate);
            SetPagination(query.Count(), page);
            var messageList = query.Skip((page - 1) * 13).Take(13).ToList();
            return View("Inbox", messageList);
        }

        public async Task<IActionResult> Spam(int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user; ViewBag.ActiveFolder = "Spam";
            SetFolderCounts(user.Email);

            var query = _context.Messages.Where(x => x.ReceiverEmail == user.Email && x.IsSpam && !x.IsTrash).OrderByDescending(x => x.SendDate);
            SetPagination(query.Count(), page);
            var messageList = query.Skip((page - 1) * 13).Take(13).ToList();
            return View("Inbox", messageList);
        }

        public async Task<IActionResult> Category(string id, int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user; ViewBag.ActiveFolder = id;
            SetFolderCounts(user.Email);

            var query = _context.Messages.Where(x => x.ReceiverEmail == user.Email && x.Category == id && !x.IsTrash).OrderByDescending(x => x.SendDate);
            SetPagination(query.Count(), page);
            var messageList = query.Skip((page - 1) * 13).Take(13).ToList();
            return View("Inbox", messageList);
        }

        public async Task<IActionResult> Search(string query, int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user;
            ViewBag.ActiveFolder = "Search";
            SetFolderCounts(user.Email);

            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Inbox");
            }

            string aramaKelimesi = query.Trim();

            var allMessages = _context.Messages.Where(x =>
                (x.ReceiverEmail == user.Email || x.SenderEmail == user.Email) && !x.IsTrash
            ).ToList();

            var filteredMessages = allMessages.Where(x =>

                (x.Subject != null && x.Subject.IndexOf(aramaKelimesi, StringComparison.OrdinalIgnoreCase) >= 0) ||

                (x.SenderEmail != null && x.SenderEmail.IndexOf(aramaKelimesi, StringComparison.OrdinalIgnoreCase) >= 0) ||

                (x.MessageDetail != null && System.Text.RegularExpressions.Regex.Replace(x.MessageDetail, "<.*?>", string.Empty).IndexOf(aramaKelimesi, StringComparison.OrdinalIgnoreCase) >= 0)

            ).OrderByDescending(x => x.SendDate).ToList();

            SetPagination(filteredMessages.Count, page);
            var messageList = filteredMessages.Skip((page - 1) * 13).Take(13).ToList();

            return View("Inbox", messageList);
        }

        [HttpPost]
        public IActionResult CreateMessage(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsStatus = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("SendBox");
        }

        [HttpPost]
        public IActionResult SaveDraft(Message message)
        {
            message.SendDate = DateTime.Now;
            message.IsStatus = false;
            message.IsDraft = true;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Drafts");
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetail(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null) return NotFound();

            if (!message.IsStatus)
            {
                message.IsStatus = true;
                _context.Update(message);
                _context.SaveChanges();
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.CurrentUser = user;
            SetFolderCounts(user.Email);

            return View(message);
        }

        public IActionResult ToggleStar(int id)
        {
            var message = _context.Messages.Find(id);
            if (message != null) { message.IsStarred = !message.IsStarred; _context.SaveChanges(); }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult MoveToTrash(int id)
        {
            var message = _context.Messages.Find(id);
            if (message != null) { message.IsTrash = true; _context.SaveChanges(); }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}