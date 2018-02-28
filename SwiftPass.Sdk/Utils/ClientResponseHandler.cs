using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace SwiftPass.Sdk.Utils
{
    /// <summary>
    /// 客户端消息返回头
    /// </summary>
    public class ClientResponseHandler
    {
        /// <summary>
        /// 密钥
        /// </summary>
        private string _key;

        /// <summary>
        /// 应答的参数
        /// </summary>
        protected IDictionary<string, string> Parameters;

        /// <summary>
        /// debug信息
        /// </summary>
        private string _debugInfo;

        /// <summary>
        /// 原始内容
        /// </summary>
        protected string _content;

        private string _charset = "UTF-8";

        /// <summary>
        /// 获取服务器通知数据方式，进行参数获取
        /// </summary>
        public ClientResponseHandler()
        {
            Parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// 获取返回内容
        /// </summary>
        /// <returns></returns>
        public string GetContent()
        {
            return this._content;
        }

        /// <summary>
        /// 设置返回内容
        /// </summary>
        /// <param name="content">XML内容</param>
        public virtual void SetContent(string content)
        {
            this._content = content;
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);
            var root = xmlDoc.FirstChild;
            if (root != null)
            {
                var xnl = root.ChildNodes;
                foreach (XmlNode xnf in xnl)
                {
                    this.SetParameter(xnf.Name, xnf.InnerText);
                }
            }
        }

        /// <summary>
        /// 获取密钥
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        { return _key; }

        /// <summary>
        /// 设置密钥
        /// </summary>
        /// <param name="key">密钥</param>
        public void SetKey(string key)
        { this._key = key; }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="parameter">参数名</param>
        /// <returns></returns>
        public string GetParameter(string parameter)
        {
            if (Parameters.ContainsKey(parameter))
                return Parameters[parameter];
            return "";
            var s = (string)Parameters[parameter];
            return s ?? "";
        }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="parameter">参数名</param>
        /// <param name="parameterValue">参数值</param>
        public void SetParameter(string parameter, string parameterValue)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                if (Parameters.ContainsKey(parameter))
                {
                    Parameters.Remove(parameter);
                }

                Parameters.Add(parameter, parameterValue);
            }
        }

        /// <summary>
        /// 是否支付平台签名,规则是:按参数名称a-z排序,遇到空值的参数不参加签名。
        /// </summary>
        /// <returns></returns>
        public virtual Boolean IsTenpaySign()
        {
            StringBuilder sb = new StringBuilder();
            
            List<string> akeys = Parameters.Keys.ToList();
            akeys.Sort();

            foreach (string k in akeys)
            {
                string v = (string)Parameters[k];
                if (null != v && String.Compare("", v, StringComparison.Ordinal) != 0
                    && String.Compare("sign", k, StringComparison.Ordinal) != 0 &&
                    String.Compare("key", k, StringComparison.Ordinal) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }

            sb.Append("key=" + this.GetKey());
            var sign = Md5Util.GetMd5(sb.ToString(), GetCharset()).ToLower();

            //debug信息
            this.SetDebugInfo(sb.ToString() + " => sign:" + sign);
            return GetParameter("sign").ToLower().Equals(sign);
        }

        /// <summary>
        /// 获取debug信息
        /// </summary>
        /// <returns></returns>
        public string GetDebugInfo()
        { return _debugInfo; }

        /// <summary>
        /// 设置debug信息
        /// </summary>
        /// <param name="debugInfo"></param>
        protected void SetDebugInfo(String debugInfo)
        { this._debugInfo = debugInfo; }

        /// <summary>
        /// 获取编码
        /// </summary>
        /// <returns></returns>
        protected virtual string GetCharset()
        {
            return this._charset;
        }

        /// <summary>
        /// 设置编码
        /// </summary>
        /// <param name="charset">编码</param>
        public void SetCharset(string charset)
        {
            this._charset = charset;
        }

        /// <summary>
        /// 是否支付平台签名,规则是:按参数名称a-z排序,遇到空值的参数不参加签名。
        /// </summary>
        /// <param name="akeys"></param>
        /// <returns></returns>
        public virtual Boolean _isTenpaySign(List<string> akeys)
        {
            StringBuilder sb = new StringBuilder();

            foreach (string k in akeys)
            {
                string v = (string)Parameters[k];
                if (null != v && String.Compare("", v, StringComparison.Ordinal) != 0
                    && String.Compare("sign", k, StringComparison.Ordinal) != 0 && 
                    String.Compare("key", k, StringComparison.Ordinal) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }

            sb.Append("key=" + this.GetKey());
            string sign = Md5Util.GetMd5(sb.ToString(), GetCharset()).ToLower();

            //debug信息
            this.SetDebugInfo(sb.ToString() + " => sign:" + sign);
            return GetParameter("sign").ToLower().Equals(sign);
        }

        /// <summary>
        /// 获取返回的所有参数
        /// </summary>
        /// <returns></returns>
        public IDictionary<string,string> GetAllParameters()
        {
            return this.Parameters;
        }
    }
}
