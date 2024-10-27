using AutoMapper;
using Common.Model;
using Microsoft.EntityFrameworkCore;
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
    public class RequestService : IRequest<RequestDto>
    {
        private readonly IRequestR<Requeste> repository;
        private readonly IUserR<User> repositoryUser;
        private readonly IBookR<Book> repositoryBook;
        Queue<RequestDto> queueWaitinq = new Queue<RequestDto>();
        private readonly IMapper mapper;
        public RequestService(IRequestR<Requeste> repository, IUserR<User> repositoryUser, IBookR<Book> repositoryBook, IMapper mapper)
        {
            this.repository = repository;
            this.repositoryUser = repositoryUser;
            this.repositoryBook = repositoryBook;
            this.mapper = mapper;
        }

        public async Task<RequestDto> AddAsync(RequestDto item)
        {
            Task<Book> b1 = repositoryBook.GetByIdAsync(item.BookId);
            Task<List<Book>> books = repositoryBook.GetAllByName(b1.Result.BookName);
            Book b = books.Result.FirstOrDefault(x => x.Status == Repositories.Enums.StatusTypes.AVAILABLE);


            Task<User> userTask = repositoryUser.GetByIdAsync(item.UserId);
            User u = userTask.Result;

            if (u.countRequests < 3 && b != null)
            {
                u.countRequests++;
                b.Status = Repositories.Enums.StatusTypes.SAVED;
                return await mapper.Map<Task<RequestDto>>(repository.AddAsync(mapper.Map<Requeste>(item)));
            }
            //ספר תפוס או שמור
            if (u.countRequests < 3)
            {
                Requeste r = await repository.GetOldestRequestAsync(b1.Result.BookName);
                SendEmail(u.Email, u.UserName, "the book is not availbale please try again in " + r.Date.AddDays(3), $"request to book \"{b1.Result.BookName}\"");
            }
            else
            {
                SendEmail(u.Email, u.UserName, "you have more than 3 rrequest,please try later!", $"request to book \"{b1.Result.BookName}\"");
            }
            return new RequestDto() { Id=-1,BookId=-1,UserId=-1,Date=new DateTime()};
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
        public async Task DeleteAsync(int id)
        {
            Requeste r = await repository.GetByIdAsync(id);

            User u = await repositoryUser.GetByIdAsync(r.UserId);
            u.countRequests--;
            Book b=await repositoryBook.GetByIdAsync(r.BookId);
            b.Status = Repositories.Enums.StatusTypes.AVAILABLE;

            await repository.DeleteAsync(id);
        }

        public async Task RemoveRequestAfter3Days()
        {
            Task<List<Requeste>> req = repository.getAllAfter3Days();
            foreach (var item in req.Result)
            {
                await repository.DeleteAsync(item.Id);
            }
        }

    }
}
