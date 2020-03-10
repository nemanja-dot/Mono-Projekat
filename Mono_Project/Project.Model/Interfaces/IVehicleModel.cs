namespace Project.Model.Interfaces
{
    interface IVehicleModel
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
