using System.Data.Entity;
using System.Threading.Tasks;
using MarketingNotifications.Web.Migrations;

namespace MarketingNotifications.Web.Models.Repository
{
    public interface ISubscribersRepository
    {
        Task<Subscriber> FindByPhoneNumberAsync(string phoneNumber);
        Task<int> CreateAsync(Subscriber subscriber);
        Task<int> UpdateAsync(Subscriber subscriber);
    }

    public class SubscribersRepository : ISubscribersRepository
    {
        private readonly MarketingNotificationsContext _context;

        public SubscribersRepository()
        {
            _context = new MarketingNotificationsContext();
        }

        public async Task<Subscriber> FindByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Subscribers.FirstAsync(s => s.PhoneNumber == phoneNumber);
        }

        public async Task<int> CreateAsync(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Subscriber subscriber)
        {
            _context.Entry(subscriber).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}