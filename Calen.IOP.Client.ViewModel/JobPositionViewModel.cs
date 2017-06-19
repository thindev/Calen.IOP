namespace Calen.IOP.Client.ViewModel
{
    public class JobPositionViewModel
    {
        public string Description { get; internal set; }
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public DepartmentViewModel Department { get; internal set; }
    }
}