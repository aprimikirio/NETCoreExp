using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DINetCore.Services
{
    public interface IMessageSender
    {
        string Send();
    }
}
