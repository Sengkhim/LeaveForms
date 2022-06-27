using System.ComponentModel.DataAnnotations;

namespace Application.BusinessObejct
{
    public class RecordStatusTypeCodes
    {
        [StringLength(3)] private const string Initial = "INI";
        [StringLength(3)] private const string Active = "ACT";
        [StringLength(3)] private const string Inactive = "INA";
        [StringLength(3)] private const string Deleted = "DEL";

        public string GetInitialCode() => Initial.ToString();
        public string GetActiveCode() => Active.ToString();
        public string GetInactiveCode() => Inactive.ToString();
        public string GetDeletedCode() => Deleted.ToString();   
    }
}
