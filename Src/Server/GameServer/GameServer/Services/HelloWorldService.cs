using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Network;
using SkillBridge.Message;

namespace GameServer.Services
{
    class HelloWorldService:Singleton<HelloWorldService>
    {
        public void Init()
        {
            
        }
        public void Start()
        {
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<FirestTestRequest>(this.OnFirstTestRequest);
        }

        void OnFirstTestRequest(NetConnection<NetSession> sender,FirestTestRequest request)
        {
            Log.InfoFormat("OnFirstTestRequest:Helloworld:{0}", request.Helloworld);
        }

        public void Stop()
        {

        }
    }
}
