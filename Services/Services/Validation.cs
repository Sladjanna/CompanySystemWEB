using System.Windows.Forms;

namespace Services
{
    public class Validation
    {
        public bool ErrorProvider(TextBox currentTextBox, ErrorProvider errorProvider)
        {
            if (string.IsNullOrEmpty(currentTextBox.Text))
            {
                currentTextBox.Focus();
                //   ToolTip tip = new ToolTip();
                errorProvider.SetError(currentTextBox, "Enter data");
                //   tip.Show("Enter data", currentTextBox);
                return false;
            }
            errorProvider.Clear();
            return true;
        }

        public bool ErrorProviderCombo(ComboBox currentBox, ErrorProvider errorProvider)
        {
            if (string.IsNullOrWhiteSpace(currentBox.Text))
            {
                currentBox.Focus();
                errorProvider.SetError(currentBox, "Enter data");
                return false;
            }
            errorProvider.Clear();
            return true;
        }

        public bool ErrorProviderDate(DateTimePicker date1, DateTimePicker date2, ErrorProvider errorProvider)
        {
            if (date1.Value > date2.Value)
            {
                date2.Focus();
                errorProvider.SetError(date2, "Error! Enter data again.");
                return false;
            }
            errorProvider.Clear();
            return true;
        }

        public bool ErrorProviderRadioButtons(RadioButton radio1, RadioButton radio2, ErrorProvider errorProvider)
        {
            if (radio1.Checked == false && radio2.Checked == false)
            {
                errorProvider.SetError(radio2, "Choose one button");
                return false;
            }
            errorProvider.Clear();
            return true;
        }
    }
}
