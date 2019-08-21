using CCLUtility;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisRepository
{
    public class Respository : IDisposable
    {
        protected static ConnectionMultiplexer redisClient;
        protected IDatabase db;

        public Respository(int dbName)
        {
            try
            {
                redisClient = ConnectionMultiplexer.Connect(RedisConst.constr);
                db = redisClient.GetDatabase(dbName);//指定连接的库
            }
            catch (Exception e)
            {
                Log.Err(e.StackTrace);
                throw e;
            }
        }

        public void Dispose()
        {
            try
            {
                redisClient.Close();
            }
            catch (Exception e)
            {
                Log.Err(e.StackTrace);
            }
        }
    }
}
