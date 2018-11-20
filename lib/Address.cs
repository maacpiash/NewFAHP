namespace NewFAHP.Lib
{
    public class Address
    {
        private string division;
        private string district;
        private string thana;
        private string union_Ward;

        public Address(string division, string district, string thana, string union_Ward)
        {
            this.division = division;
            this.district = district;
            this.thana = thana;
            this.union_Ward = union_Ward;
        }
    }
}