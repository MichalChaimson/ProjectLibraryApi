using AutoMapper;
using Common.Model;
using MimeKit;
using Repositories.Entity;
using Repositories.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BorrowingService : IBorrowing<BorrowingDto>
    {
        private readonly IBorrowingR<Borrowing> repository;
        private readonly IUserR<User> repositoryUser;
        private readonly IBookR<Book> repositoryBook;
        private readonly IMapper mapper;
        public BorrowingService(IBorrowingR<Borrowing> repository,IBookR<Book> repositoryBook, IUserR<User> repositoryUser, IMapper mapper)
        {
            this.repository = repository;
            this.repositoryUser = repositoryUser;
            this.repositoryBook = repositoryBook;
            this.mapper = mapper;
        }
        public async Task<List<BorrowingDto>> GetAllAsync()
        {
            return await mapper.Map<Task<List<BorrowingDto>>>(repository.GetAllAsync());
        }

        //public async Task<BorrowingDto> GetByDateTakeAsync(DateTime date)
        //{
        //    return await mapper.Map<Task<BorrowingDto>>(repository.GetByDateTakeAsync(date));
        //}
        public async Task SendEmailAfterWeek()
        {

            List<Borrowing> bor = await repository.getAllAfterWeek();
            foreach (var item in bor)
            {
                Task<User> u = repositoryUser.GetByIdAsync(item.UserId);
                Task<Book> b = repositoryBook.GetByIdAsync(item.BookId);
                SendEmail(u.Result.Email, u.Result.UserName, "You have had the book at home for a week from the date:  " + item.DateTake, $"please, return the book \"{b.Result.BookName}\"");
            }
        }
        private void SendEmail(string to, string name, string htmlBody, string Subject)
        {
            var email = new MimeMessage();
            // הגדרת השולח
            email.From.Add(new MailboxAddress("ספריית ספרים", "librarybook2004@gmail.com"));
            // הגדרת הנמען
            email.To.Add(new MailboxAddress(name, to));

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = htmlBody; // הגדרת התוכן של המייל כ- HTML

            // הגדרת התוכן של המייל וכותרת המייל
            email.Body = bodyBuilder.ToMessageBody();
            email.Subject = Subject;

            using (var s = new MailKit.Net.Smtp.SmtpClient())
            {
                s.CheckCertificateRevocation = false;
                s.Connect("smtp.gmail.com", 587, false);
                s.Authenticate("librarybook2004@gmail.com", "sdjs igzg tjtu vkbb"); // התחברות לשרת הSMTP
                s.Send(email); // שליחת המייל
                s.Disconnect(true);
            }

        }

    }
}
