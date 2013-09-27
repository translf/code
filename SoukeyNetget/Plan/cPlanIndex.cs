using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SoukeyNetget.Plan
{
    class cPlanIndex
    {
        cXmlIO xmlConfig;
        DataView Plans;

        #region ���������

        public cPlanIndex()
        {
            xmlConfig = new cXmlIO();
        }

        ~cPlanIndex()
        {
            xmlConfig =null;
        }

        #endregion

        #region �½�һ��index�ļ�,���ڴ��ļ����½�һ��������Ϣ

        //�ƻ���index�ļ��ǹ̶��ģ��û�����������޸�
        //Ĭ��λ��Ϊ��ϵͳ��·��\\tasks\\plan
       
        public void NewIndexFile()
        {

            string strXml = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                       "<PlanIndex>" +
                       "</PlanIndex>";
            xmlConfig.NewXmlFile(Program.getPrjPath () + "tasks\\plan\\index.xml", strXml);

        }

        //����һ���ƻ�����
        //����ƻ�����Ҫ�жϼƻ���״̬��ͨ������£��½��ƻ�������Ч�ġ�
        //��ǰ�ƻ�������Чʱ�䣬����ʱ�䵱ǰ�������ƻ�״̬���ж�
        public void InsertPlanIndex(string strXml, cGlobalParas.PlanState pState)
        {
            switch (pState)
            {
                case cGlobalParas.PlanState .Disabled :
                    xmlConfig.InsertElement("PlanIndex\\Disabled", "Plan", strXml);
                    break;
                case cGlobalParas.PlanState .Enabled :
                    xmlConfig.InsertElement("PlanIndex\\Enabled", "Plan", strXml);
                    break;
                case cGlobalParas.PlanState .Expired :
                    xmlConfig.InsertElement("PlanIndex\\Expired", "Plan", strXml);
                    break;
                default :
                    break ;
            }
            
            xmlConfig.Save();
        }

        //ɾ��һ���ƻ�����
        public void DelePlanIndex(string PlanID)
        {
            xmlConfig.DeleteChildNodes("PlanIndex", "ID", TaskName);
            xmlConfig.Save();
        }


        #endregion

        #region ���Ҽƻ���Ϣ

        //���ݼƻ���״̬��ȡ�ƻ�
        public void GetPlanByState(cGlobalParas.PlanState pState)
        {

            string PlanPath = Program.getPrjPath() + "tasks\\plan";

            xmlConfig = new cXmlIO(PlanPath + "\\index.xml");

            //��ȡTaskClass�ڵ�
            Plans = xmlConfig.GetData("TaskIndex");
        }

        //���㵱ǰ���ж��ٸ�TaskClass
        public int GetPlanCount()
        {
            int tCount;
            if (Plans == null)
            {
                tCount = 0;
            }
            else
            {
                tCount = Plans.Count;
            }
            return tCount;
        }

        public int GetPlanID(int index)
        {
            int tid = int.Parse(Plans[index].Row["id"].ToString());
            return tid;
        }

        public string GetPlanName(int index)
        {
            string TName = Plans[index].Row["Name"].ToString();
            return TName;
        }


        public string GetPlanState(int index)
        {
            string TType = Plans[index].Row["Type"].ToString();
            return TType;
        }

        public string GetPlanType(int index)
        {
            string TRunType = Plans[index].Row["Type"].ToString();
            return TRunType;
        }

        public string GetPlanRunType(int index)
        {
            string TRunType = Plans[index].Row["RunType"].ToString();
            return TRunType;
        }

        //��ȡ�˼ƻ���Ҫִ�����������
        public int GetTaskCount(int index)
        {
            int WebLinkCount;
            try
            {
                WebLinkCount = int.Parse(Plans[index].Row["WebLinkCount"].ToString());
            }
            catch
            {
                WebLinkCount = 0;
            }
            return WebLinkCount;
        }

        public bool GetIsDisabled(int index)
        {
            string TRunType = Plans[index].Row["IsDisabled"].ToString();
            return TRunType;
        }

        public bool GetIsOverRun(int index)
        {
            string TRunType = Plans[index].Row["IsOverRun"].ToString();
            return TRunType;
        }

        #endregion

    }
}
