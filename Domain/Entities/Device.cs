namespace Domain.Entities
{
    public class Device
    {
        public int id { get; set; }
        public int entities_id { get; set; }
        public string name { get; set; }
        public string serial { get; set; }
        public string otherserial { get; set; }
        public string contact { get; set; }
        public string contact_num { get; set; }
        public int users_id_tech { get; set; }
        public int groups_id_tech { get; set; }
        public string comment { get; set; }
        public string date_mod { get; set; }
        public int autoupdatesystems_id { get; set; }
        public int locations_id { get; set; }
        public int networks_id { get; set; }
        public int computermodels_id { get; set; }
        public int computertypes_id { get; set; }
        public int is_template { get; set; }
        public object template_name { get; set; }
        public int manufacturers_id { get; set; }
        public int is_deleted { get; set; }
        public int is_dynamic { get; set; }
        public int users_id { get; set; }
        public int groups_id { get; set; }
        public int states_id { get; set; }
        public string ticket_tco { get; set; }
        public string uuid { get; set; }
        public string date_creation { get; set; }
        public int is_recursive { get; set; }
        public string last_inventory_update { get; set; }
        public string last_boot { get; set; }

    }

   
}
