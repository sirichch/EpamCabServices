using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabServices
{
    public class Feedback
    {
        public int CabId {  get; set; }
        public int UserId {  get; set; }
        public string FeedbackText {  get; set; }

        public Feedback(int cabId, int userId, string feedbackText)
        {
            CabId = cabId;
            UserId = userId;
            FeedbackText = feedbackText;
        }
    }
}
