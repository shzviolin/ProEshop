namespace ProEshop.Entities.AuditableEntity;

public class AppShadowProperties
{
    public string UserAgent { get; set; }//information about browser
    public string UserIp { get; set; }
    public DateTime Now { get; set; }
    public long? UserId { get; set; }
}
