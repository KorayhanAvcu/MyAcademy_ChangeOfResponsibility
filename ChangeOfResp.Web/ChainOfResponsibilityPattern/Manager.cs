using ChangeOfResp.Web.DataAccess;
using ChangeOfResp.Web.Entities;
using ChangeOfResp.Web.Models;

namespace ChangeOfResp.Web.ChainOfResponsibilityPattern
{
    public class Manager(AppDbContext _context) : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 500000)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Şube Müdürü - Nurgül Elmalı",
                    Description = "Para çekme işlemi onaylandı. Müşteriye tutar ödendi."
                };
                _context.CustomerProcesss.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover is not null)
            {
                var customerProcess = new CustomerProcess
                {
                    Amount = request.Amount,
                    FullName = request.FullName,
                    EmployeeName = "Şube Müdürü - Nurgül Elmalı",
                    Description = "Para çekme tutarı şube müdürünün ödeyebileceği miktarı aştığı için işlem bölge müdürüne yönlendirildi."
                };
                _context.CustomerProcesss.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
