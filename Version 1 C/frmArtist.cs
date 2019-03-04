using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        //private clsArtistList _ArtistList;  
        //private clsWorksList _WorksList;
        private byte _SortOrder; // 0 = Name, 1 = Date
        private clsArtist _Artist;
        

        private void updateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_SortOrder == 0)
            {
                _Artist.WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _Artist.WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _Artist.WorksList;
            lblTotal.Text = Convert.ToString(_Artist.WorksList.GetTotalValue());
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            updateDisplay();
            ShowDialog();
        }

       /* public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        {
            prName = txtName.Text;
            prSpeciality = txtSpeciality.Text;
            prPhone = txtPhone.Text;
            _SortOrder = _WorksList.SortOrder;
        }*/

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstWorks.SelectedIndex >= 0 && lstWorks.SelectedIndex < _Artist.WorksList.Count)
            {
                if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _Artist.WorksList.RemoveAt(lstWorks.SelectedIndex);
                }
            }
            updateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _Artist.WorksList.AddWork();
            updateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                try { 
                _Artist.WorksList.EditWork(lcIndex);
                updateDisplay();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sorry no work selected #" + Convert.ToString(lcIndex));
                }
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _SortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtPhone.Text = _Artist.Phone;
            txtSpeciality.Text = _Artist.Speciality;
            
        }
        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

    }
}