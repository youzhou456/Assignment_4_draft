namespace Assignment_4_draft.Models
{
  public class Stations
  {
    public int total_result { get; set; }
    public record[] data { get; set; }
    public string station_locator_url { get; set; }
  }

  public class record
  {
    public string fuel_type_code { get; set; }
    public string station_name { get; set; }
    public string street_address { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zip { get; set; }
    public string country{ get; set; }
    public string cards_accepted { get; set; }
    public string access_days_time { get; set; }
    public bool e85_blender_pump { get; set; }
    public string lng_renewable_source { get; set; }
    public string id { get; set; }
 
  }
}
