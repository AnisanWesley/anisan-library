using System.Windows.Forms;

namespace Extensions
{
    public static class ComponentBoxExtension
    {
	    //For combobox
        public static void RemoveSelected(this ComboBox instance)
        {
            instance.Items.Remove(instance.SelectedItem);
        }
		//For listbox
        public static void RemoveSelected(this ListBox instance)
        {
            instance.Items.Remove(instance.SelectedItem);
        }
    }
}