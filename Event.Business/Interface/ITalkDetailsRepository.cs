using Event.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Interface
{
    public interface ITalkDetailsRepository
    {
        TalkDetails AddTalkDetails(TalkDetails item);

    }
}
