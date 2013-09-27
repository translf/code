using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SoukeyNetget
{
    class WMessage
    {
        #region ����windows dll

        [DllImport("User32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="hWnd">������Ϣ�Ĵ�����</param>
        /// <param name="Msg">��ϢID����"RegisterWindowMessage"��ȡ��</param>
        /// <param name="wParam">������Ϣ</param>
        /// <param name="lParam">������Ϣ</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        /// <summary>
        /// ע��/��ȡ�Զ�����Ϣ
        /// </summary>
        /// <param name="lpString"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "RegisterWindowMessage", CharSet = CharSet.Unicode, ThrowOnUnmappableChar = true)]
        private static extern uint RegisterWindowMessage(string lpString);
        #endregion

        #region ��Ϣ����
        /// <summary>
        /// ���ش��ڵ���Ϣ����
        /// </summary>
        public enum DF_wParam
        {
            /// <summary>
            /// ����ر�
            /// </summary>
            UM_CLOSE = 0x1001,
            /// <summary>
            /// ȡ�����رմ���
            /// </summary>
            UM_CLOSE_CANCEL = 0x1002,
            /// <summary>
            /// ��ɲ��رմ���
            /// </summary>
            UM_CLOSE_OK = 0x1003,
            /// <summary>
            /// ������������,��ʼ����
            /// </summary>
            UM_STARDOWNLOAD = 0x1004,
            /// <summary>
            /// �����������ڣ���������
            /// </summary>
            UM_CONTINUEDOWNLOAD = 0x1005
        }

        private static int msg_df = (int)RegisterWindowMessage("MSG_DOWNLOADFORM");
        /// <summary>
        /// ��ȡ�Զ��� ������Ϣ
        /// </summary>
        public static int MSG_MAINFORM
        {
            get { return WMessage.msg_df; }
        }
        #endregion


        /// <summary>
        /// ��ʼ����Ϣ������
        /// </summary>
        public WMessage()
        {
        }

        /// <summary>
        /// ��ָ�����巢����Ϣ
        /// </summary>
        /// <param name="wHander">������Ϣ�Ĵ�����</param>
        /// <param name="wParam">���ڵ���Ϣ����</param>
        /// <param name="lParam">������Ϣ</param>
        /// <returns></returns>
        public static int SendMessage(IntPtr wHander, DF_wParam wParam, IntPtr lParam)
        {
            return WMessage.SendMessage(wHander, WMessage.MSG_MAINFORM, (IntPtr)wParam, lParam);
        }


        #region �¼�ί��
        public delegate void MSGEventHander(ref Message m);
        private Dictionary<IntPtr, MSGEventHander> m_MSGEvent;
        /// <summary>
        /// ��ȡ �¼���
        /// </summary>
        protected Dictionary<IntPtr, MSGEventHander> MSGEvent
        {
            get
            {
                if (m_MSGEvent == null)
                {
                    m_MSGEvent = new Dictionary<IntPtr, MSGEventHander>();
                }
                return m_MSGEvent;
            }
        }
        #endregion

        #region �Զ�����Ϣ�������¼��ӿ�

        /// <summary>
        /// ���մ�����������Ϣ
        /// </summary>
        /// <param name="m"></param>
        public void mProc(ref Message m)
        {
            if (m.Msg == WMessage.MSG_MAINFORM)
            {
                if (MSGEvent.ContainsKey(m.WParam))
                {
                    MSGEventHander evt = MSGEvent[m.WParam];
                    evt(ref m);
                }
            }
        }

        /// <summary>
        /// ��ָ������Ϣ���¼�
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="evt"></param>
        public void BindEvent(DF_wParam wParam, MSGEventHander evt)
        {
            if (MSGEvent.ContainsKey((IntPtr)wParam))
            {
                MSGEventHander evt1 = MSGEvent[(IntPtr)wParam];
                evt1 += evt;
                MSGEvent[(IntPtr)wParam] = evt1;
            }
            else
            {
                m_MSGEvent[(IntPtr)wParam] = evt;
            }
        }
        /// <summary>
        /// �Ƴ���Ϣ���¼�
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="evt"></param>
        public void RemoveEvent(DF_wParam wParam, MSGEventHander evt)
        {
            if (MSGEvent.ContainsKey((IntPtr)wParam))
            {
                MSGEventHander evt1 = MSGEvent[(IntPtr)wParam];
                evt1 -= evt;
                MSGEvent[(IntPtr)wParam] = evt1;
            }
        }

        #endregion
    }
}
