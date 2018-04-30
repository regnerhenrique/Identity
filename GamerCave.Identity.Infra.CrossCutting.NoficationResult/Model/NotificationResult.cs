using System.Collections.Generic;

namespace GamerCave.Identity.Infra.CrossCutting.NoficationResult.Model
{
    public class NotificationResult
    {
        public NotificationResult()
        {
            IsValid = true;
            Errors = new List<string>();
        }

        public bool IsValid { get; private set; }
        public object Data { get; set; }
        public List<string> Errors { get; }
        public string SuccessMessage { get; private set; }

        public void SetSuccessMessage(string successMessage)
        {
            if (IsValid)
                SuccessMessage = successMessage;
        }

        public void SetError(string error)
        {
            if (IsValid)
            {
                IsValid = false;
                SuccessMessage = "";
                Data = null;
            }

            Errors.Add(error);
        }

        public void SetData(object data, string successMessage)
        {
            if (IsValid)
                Data = data;

            SetSuccessMessage(successMessage);
        }
    }
}
