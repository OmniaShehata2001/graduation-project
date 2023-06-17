using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graduation_project.Entities
{
    public class FeedBack
    {
        public int FeedbackId { get; set; }
        public string UserGuid { get; set; }
        public string Feedback { get; set; }


        public static FeedBack Create(string userGuid, string feedBack) 
        {
            return new FeedBack
            {
                UserGuid = userGuid,
                Feedback = feedBack
            };
        }
    }
}
