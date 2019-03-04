using System;
//using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPhotograph _PhotoDialog;

        public float Width { get => _Width; set => _Width = value; }
        public float Height { get => _Height; set => _Height = value; }
        public string Type { get => _Type; set => _Type = value; }
        public static frmPhotograph PhotoDialog { get => _PhotoDialog; set => _PhotoDialog = value; }

        public override void EditDetails()
        {
            if (_PhotoDialog == null)
                _PhotoDialog = new frmPhotograph();
            _PhotoDialog.SetDetails(this);

            /*if (_PhotoDialog == null)
            {
                _PhotoDialog = new frmPhotograph();
            }

            _PhotoDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
            if (_PhotoDialog.ShowDialog() == DialogResult.OK)
            {
                _PhotoDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
            }*/
        }
    }
}
