namespace BackEnd_SocialE.Learning.Domain.Models;

public class Event {
    /*
      "id": 1,
      "name": "The event 1",
      "description": "The best event have exist forever",
      "price": 29.36,
      "image": "https://www.bbva.com/wp-content/uploads/2020/05/festival2.jpg",
      "event_date": "12-12-2020",
      "start_time": "12:00",
      "end_time": "14:00",
      "manager_id": 2
     */
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public string EventDate { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    //RELACIONES
    //public int ManagerId { get; set; }
    //public User Manager { get; set; }
}