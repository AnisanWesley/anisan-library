using System.Windows.Forms;

namespace Extensions
{
    public static class ComponentBoxExtension
    {
	    /// <summary>
	    /// Remove selected item
	    /// Remove o item selecionado
	    /// </summary>
	    /// <param name="instance"></param>
        public static void RemoveSelected(this ComboBox instance)
        {
            instance.Items.Remove(instance.SelectedItem);
        }
        /// <summary>
        /// Remove selected item
		/// Remove o item selecionado
		/// </summary>
		/// <param name="instance"></param>
        public static void RemoveSelected(this ListBox instance)
        {
            instance.Items.Remove(instance.SelectedItem);
        }
    }
}