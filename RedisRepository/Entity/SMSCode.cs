using CCLUtility;

namespace RedisRepository.Entity
{
    public class SMSCode
    {
        public string Phone { get; set; }
        public SMSTypeEnum Type { get; set; }
    }
}
