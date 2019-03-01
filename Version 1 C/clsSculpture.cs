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

        public float Weight { get => _Weight; set => _Weight = value; }
        public string Material { get => _Material; set => _Material = value; }

        public override void EditDetails()
        {
            if (_ScluptureDialog == null)
                _ScluptureDialog = new frmSculpture();
            _ScluptureDialog.SetDetails(this);

            /*if (_ScluptureDialog == null)
            {
                _ScluptureDialog = new frmSculpture();
            }
            _ScluptureDialog.SetDetails(_Name, _Date, _Value, _Weight,_Material);
            if (_ScluptureDialog.ShowDialog() == DialogResult.OK)
            {
                _ScluptureDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Weight, ref _Material);
            }*/
        }

    }
    
}
