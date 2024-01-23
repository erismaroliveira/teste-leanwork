using Flunt.Notifications;

namespace LeanWork.Atividade3.Shared.Models;

public class ResponseModel<T>
{
    public ResponseModel()
    {

    }
    public ResponseModel(T data, IEnumerable<Notification> notifications = null)
    {
        Data = data;
        Notifications = notifications ?? Enumerable.Empty<Notification>();
        Success = !Notifications.Any();
    }

    public bool Success { get; set; }
    public T Data { get; set; }
    public IEnumerable<Notification> Notifications { get; set; }
}

public class ResponseModel
{
    public ResponseModel(IEnumerable<Notification> notifications = null)
    {
        Notifications = notifications ?? Enumerable.Empty<Notification>();
        Success = !Notifications.Any();
    }

    public bool Success { get; set; }
    public IEnumerable<Notification> Notifications { get; set; }
}
