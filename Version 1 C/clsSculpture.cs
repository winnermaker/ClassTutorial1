using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsSculpture : clsWork
    {
        private float _Weight;
        private string _Material;
        

        [NonSerialized()]
        private static frmSculpture _ScluptureDialog;

        public override void EditDetails()
        {

            if (_ScluptureDialog == null)
            {
                _ScluptureDialog = new frmSculpture();
            }
            _ScluptureDialog.SetDetails(_Name, _Date, _Value);
            if (_ScluptureDialog.ShowDialog() == DialogResult.OK)
            {
                _ScluptureDialog.GetDetails(ref _Name, ref _Date, ref _Value);
            }
        }
    
    }
    
}
