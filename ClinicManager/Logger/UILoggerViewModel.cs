using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Logger
{
    public class UILoggerViewModel
    {
        public MessageSeverity Severity { get; set; }
        public string Message { get; set; }
        private Image SeverityImage;

        public void CreateMessage(string message, MessageSeverity severity)
        {
            Severity = severity;
            Message = message;
        }

        public UILoggerMessage CreateUIControl()
        {
            var control = new UILoggerMessage();
            switch(Severity)
            {
                case MessageSeverity.Information:
                    SeverityImage = Image.FromFile(@"../../Logger/SeverityIcons/message.png");
                    break;
                case MessageSeverity.Warning:
                    SeverityImage = Image.FromFile(@"../../Logger/SeverityIcons/warning.png");
                    break;
                case MessageSeverity.Error:
                    SeverityImage = Image.FromFile(@"../../Logger/SeverityIcons/error.png");
                    break;
                case MessageSeverity.Finish:
                    SeverityImage = Image.FromFile(@"../../Logger/SeverityIcons/success.png");
                    break;
            }

            control.MessageSeverity = SeverityImage;
            control.Message = Severity.ToString() + Message;
            return control;
        }
    }
}
