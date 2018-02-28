using System;
using System.Collections.Generic;


namespace SwiftPass.Sdk.Utils
{
    /// <summary>
    ///  请求基本参数
    /// </summary>
    public abstract class TransactionBasicInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        protected TransactionBasicInfo()
        {
            Charset = "UTF-8";
            SignType = "MD5";
            Version = "2.0";
        }
        /// <summary>
        ///  可选值 UTF-8 ，默认为 UTF-8 
        /// </summary>
        private string Charset { get; set; }
        /// <summary>
        /// 签名类型，取值：MD5默认：MD5
        /// </summary>
        private string SignType { get; set; }
        /// <summary>
        /// 版本号，version默认值是2.0  Demo 是1.0
        /// </summary>
        private string Version { get;  set; }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> ToDictionary()
        {
            var dic = new Dictionary<string, string>
            {
                {"version", this.Version},
                {"charset", this.Charset},
                {"sign_type", this.SignType}
            };
            FillTo(dic);
            return dic;
        }

        /// <summary>
        /// 填充到字典
        /// </summary>
        /// <param name="data"></param>
        protected abstract void FillTo(IDictionary<string, string> data);

        /// <summary>
        /// 填充实体
        /// </summary>
        /// <param name="data">字符串</param>
        public void FillBy(string data)
        {
        }

        /// <summary>
        /// 填充实体
        /// </summary>
        /// <param name="data"></param>
        public virtual void FillBy(IDictionary<string, string> data)
        {
            this.Version = data.GetValueFromDic("version");
            this.Charset = data.GetValueFromDic("charset");
            this.SignType = data.GetValueFromDic("sign_type");
        }
    }
}