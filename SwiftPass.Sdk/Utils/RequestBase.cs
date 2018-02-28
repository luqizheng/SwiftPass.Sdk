using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftPass.Sdk.Utils
{
    public class RequestBase:TransactionBasicInfo
    {
        public RequestBase()
        {
        }

        public RequestBase(string service) 
        {
            if (String.IsNullOrEmpty(service))
                throw new ArgumentNullException(nameof(service));
            this.Service = service;
        }


        /// <summary>
        /// service 是 String(32) 接口类型：pay.weixin.native
        /// </summary>
        private string Service { get; set; }


        protected override void FillTo(IDictionary<string, string> data)
        {
            data["service"] = this.Service;
        }
    }
}
