using System.Collections.Generic;

namespace SwiftPass.Sdk.Utils
{
    public abstract class ResponseBase : TransactionBasicInfo
    {
        /// <summary>
        /// 0表示成功，非0表示失败此字段是通信标识，非交易标识，交易是否成功需要查看 result_code 来判断
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 返回信息，如非空，为错误原因签名失败参数格式校验错误
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 业务结果0 是成功，非0失败
        /// </summary>
        public string ResultCode { get; set; }
        /// <summary>
        ///设备号终端设备号是必填：否 
        /// </summary>
        public string DeviceInfo { get; set; }

        /// <summary>
        ///随机字符串随机字符串，不长于 32 位是必填：是 
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        ///错误代码具体错误码请看文档最后错误码列表是必填：否 
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        ///错误代码描述结果信息描述是必填：否 
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        ///签名MD5签名结果，详见“安全规范”是必填：是 
        /// </summary>
        public string Sign { get; set; }


        public string MchId { get; set; }

        protected override void FillTo(IDictionary<string, string> data)
        {
           
        }

        public override void FillBy(IDictionary<string, string> data)
        {
            base.FillBy(data);

            this.Status = data.GetValueFromDic("status");
            this.Message = data.GetValueFromDic("message");

            this.ResultCode = data.GetValueFromDic("result_code");
            this.MchId = data.GetValueFromDic("mch_id");
            this.DeviceInfo = data.GetValueFromDic("device_info");
            this.NonceStr = data.GetValueFromDic("nonce_str");
            this.ErrCode = data.GetValueFromDic("err_code");
            this.ErrMsg = data.GetValueFromDic("err_msg");
            this.Sign = data.GetValueFromDic("sign");
        }
    }
}