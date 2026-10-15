using ChangeOfResp.Web.Models;

namespace ChangeOfResp.Web.ChainOfResponsibilityPattern
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }
        public abstract void ProcessRequest(CustomerProcessViewModel request);
    }
}
