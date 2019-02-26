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
        private static frmSculpture scluptureDialog;

        public override void EditDetails()
        {

            if (scluptureDialog == null)
            {
                scluptureDialog = new frmSculpture();
            }
            scluptureDialog.SetDetails(_Name, _Date, _Value);
            if (scluptureDialog.ShowDialog() == DialogResult.OK)
            {
                scluptureDialog.GetDetails(ref _Name, ref _Date, ref _Value);
            }
        }
    
    }
    
}
