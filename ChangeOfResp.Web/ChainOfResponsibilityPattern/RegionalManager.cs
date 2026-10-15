using ChangeOfResp.Web.DataAccess;
using ChangeOfResp.Web.Entities;
using ChangeOfResp.Web.Models;

namespace ChangeOfResp.Web.ChainOfResponsibilityPattern
{
    public class RegionalManager(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 1000000)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Böge Müdürü - Korayhan Avcu",
                    Description = "Para çekme işlemi onaylandı. Müşteriye tutar ödendi."
                };
                _context.CustomerProcesss.Add(customerProcess);
                _context.SaveChanges();
            }
            else
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Bölge Müdürü - Korayhan Avcu",
                    Description = "Para çekme tutarı bölge müdürünün ödeyebileceği miktarı aştığı için işlem gerçekleştirilemedi.Günlük para çekme limitini aştığı için, müşterinin birden fazla gün gelmesi gereklidir."
                };
                _context.CustomerProcesss.Add(customerProcess);
                _context.SaveChanges();
                
            }
        }
    }
}
