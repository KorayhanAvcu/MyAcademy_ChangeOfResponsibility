using ChangeOfResp.Web.DataAccess;
using ChangeOfResp.Web.Entities;
using ChangeOfResp.Web.Models;

namespace ChangeOfResp.Web.ChainOfResponsibilityPattern
{
    public class Treasurer(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if(request.Amount<= 50000)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Veznedar - Barış Bingöl",
                    Description = "Para çekme işlemi onaylandı. Müşteriye tutar ödendi."
                };
                _context.CustomerProcesss.Add(customerProcess);
                _context.SaveChanges();
            }
            else if(NextApprover is not null)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Veznedar - Barış Bingöl",
                    Description = "Para çekme tutarı veznedarın ödeyebileceği miktarı aştığı için işlem müdür yardımcısına yönlendirildi."
                };
                _context.CustomerProcesss.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(request);
            }

        }
    }
}
