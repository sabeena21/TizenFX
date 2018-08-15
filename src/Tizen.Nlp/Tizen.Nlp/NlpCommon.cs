/*
* Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the License);
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an AS IS BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using Tizen.Applications;
using Tizen.Nlp;

namespace Tizen.Nlp
{

    /// <summary>
    /// This class contains the methods and inner class related to the NLP processing.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class NltkClass
    {
        /// <summary>
        /// An EventHandler to expose to external to recieve data from remote Nlp service  .
        /// </summary>
        public event EventHandler OnMsgRecieved;
        private Message _msg;
        private readonly Message.NotifyCb _noti = new Message.NotifyCb();
        private string _tag;

        private void MakeRequest(string cmd, string info)
        {
            Bundle b = new Bundle();
            b.AddItem("command", cmd);
            b.AddItem("info", info);
            _msg.Send(b);
        }

        private void OnReceived(string sender, Bundle msg)
        {
            Log.Debug(_tag, "OnReceived ++");
            CustomEventArg e = new CustomEventArg();
            e.Msg = new Bundle();
            e.Msg = msg;
            OnMsgRecieved(sender, e);
            Log.Debug(_tag, "done");
        }

        /// <summary>
        /// An init session to connect remote tidl service with 2 input parameters.
        /// </summary>
        /// <param name="serviceId">remote nlp service id.</param>
        /// <param name="clientId">local nlp client app id.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void Init(string serviceId, string clientId)
        {
            _tag = clientId;
            Log.Debug(_tag, "msg construct started");
            _msg = new Message(serviceId);
            Log.Debug(_tag, "msg construct success");
            _noti.Received += OnReceived;
            Log.Debug(_tag, "notify callback be assigned");
            _msg.Connected += (sender, e) =>
            {
                Log.Debug(_tag, "start to register");
                _msg.CoRegister(clientId, _noti);
                Log.Debug(_tag, "connected callback be called");
            };
            Log.Debug(_tag, "start to connect");
            _msg.Connect();
            Log.Debug(_tag, "wait to callback of onConnected");
        }

        /// <summary>
        /// An release session to disconnect remote tidl service.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Release()
        {
            _noti.Received -= OnReceived;
            _msg.UnRegister();
            _msg.Dispose();
            _msg = null;

        }

        /// <summary>
        /// Send Pos of Tag request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void PosTag(string info)
        {
            MakeRequest("pos_tag", info);
        }

        /// <summary>
        /// Send Named Entity recognition request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void NeChunk(string info)
        {
            MakeRequest("ne_chunk", info);
        }

        /// <summary>
        /// Send language detect request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void LangDetect(string info)
        {
            MakeRequest("langdetect", info);
        }

        /// <summary>
        /// Send Lemmatize request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void Lemmatize(string info)
        {
            MakeRequest("lemmatize", info);
        }

        /// <summary>
        /// Send word tokenize request to remote tidl service with 1 input parameters.
        /// </summary>
        /// <param name="info">A sentence need to be processed.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        public void WordTokenize(string info)
        {
            MakeRequest("word_tokenize", info);
        }

    }

    /// <summary>
    /// This custom class extend from EventArgs to obtain Bundle object.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class CustomEventArg : EventArgs
    {
        /// <summary>
        /// An Bundle type to carry an array struct return from tidl service.
        /// To check which nlp command be return by  msg.GetItem("command")
        /// To get value by  msg.GetItem("return_tag") and cast the value to string []
        /// To get value by  msg.GetItem("return_token") and cast the value to string []
        /// </summary>
        internal Bundle _msg;
        /// <summary>
        /// Use get method  to avoid the _msg be modified directlly.
        /// </summary>
        public Bundle Msg
        {
            get => _msg;

            set => _msg = value;
        }
    }
}