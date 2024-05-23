using CourseTracker.UI.Models;
using Newtonsoft.Json;

namespace CourseTracker.UI.Services.State
{
    
    public class SessionState : IState
    {

        private ISession _session;
        private const string EntityIdKey = "ENTITY_IDS";

        public SessionState(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public EntityIds EntityIds
        {
            get
            {
                if (_session.Keys.Contains(EntityIdKey))
                { 
                    string str = _session.GetString(EntityIdKey);
                    return JsonConvert.DeserializeObject<EntityIds>(str);
                }
                else
                    return null;
            }
            set
            {
                if (value == null)
                    _session.Remove(EntityIdKey);
                else
                    _session.SetString(EntityIdKey, JsonConvert.SerializeObject(value));
            }
        }

    }

}
