using System.Windows.Forms;

namespace Extensions
{
    public enum MessageEnum
    {
        Error,
        Information,
        Warning,
        Question
    }

    public static class MessageBoxExtension
    {
        public static DialogResult ShowQuestion(string message)
        {
            return MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowInformation(string message)
        {
            return MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowError(string message)
        {
            return MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Show(string message, MessageEnum kind)
        {
            switch (kind)
            {
                case MessageEnum.Error:
                    MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case MessageEnum.Information:
                    MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case MessageEnum.Warning:
                    MessageBox.Show(message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case MessageEnum.Question:
                    return MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            return DialogResult.None;
        }
    }
}