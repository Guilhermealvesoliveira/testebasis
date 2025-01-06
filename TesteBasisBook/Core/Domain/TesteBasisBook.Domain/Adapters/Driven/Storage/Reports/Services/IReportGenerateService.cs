using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Reports.Services
{
    public interface IReportGenerateService
    {
        byte[] Execute();
    }
}
