namespace Furni.App.Models.BaseModels
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string IsDelete { get; set; }
    }
}
