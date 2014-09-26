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
            return MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowInformation(string message)
        {
            return MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowError(string message)
        {
            return MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}