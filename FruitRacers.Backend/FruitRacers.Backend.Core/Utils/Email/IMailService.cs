using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils.Email
{
    public interface IMailService
    {
        IMailBuilder NewMail();
    }
}
