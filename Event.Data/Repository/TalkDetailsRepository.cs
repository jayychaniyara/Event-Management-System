using Event.Business.Interface;
using Event.Business.Models;
using Event.Data.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data.Repository
{
    public class TalkDetailsRepository : ITalkDetailsRepository
    {

        private readonly DBContext dbContext;
        public TalkDetailsRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public TalkDetails AddTalkDetails(TalkDetails item)
        {
            this.dbContext.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

    }
}
