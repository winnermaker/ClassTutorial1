using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _Name;
        private string _Speciality;
        private string _Phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist _ArtistDialog = new frmArtist();      
        

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()        {
            _ArtistDialog.SetDetails(_Name, _Speciality, _Phone, _WorksList, _ArtistList);
            if (_ArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _ArtistDialog.GetDetails(ref _Name, ref _Speciality, ref _Phone);
                _TotalValue = _WorksList.GetTotalValue();
            }
        }

        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }

        public string GetKey()
        {
            return _Name;
        }

        public decimal GetWorksValue()
        {
            return _TotalValue;
        }
    }
}
