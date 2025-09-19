using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegDel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey reglm = Registry.CurrentUser;
                reglm.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                RegistryKey regName = reglm.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);
                regName.SetValue("DisableRegistryTools", "1", RegistryValueKind.DWord);
                reglm.Close();
                regName.Close();
                label1.Text = "註冊表禁用-成功";
                label4.Text = "(Disable Regedit Successful)";
            }
            catch
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] sValueNameColl;
            string sValueName = "DisableRegistryTools";
            RegistryKey reglm = Registry.CurrentUser;
            reglm.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            RegistryKey regName = reglm.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true);
            sValueNameColl = regName.GetValueNames(); //获取Policies下所有键值的名称
            foreach (string sName in sValueNameColl)
            {
                if (sName == sValueName)
                {
                    regName.DeleteValue(sValueName, true);
                    reglm.Close();
                    regName.Close();
                    label1.Text = "註冊表解禁-成功";
                    label4.Text = "(Enable Regedit Successful)";
                }
                else
                {
                    label1.Text = "註冊表解禁-完成";
                    label4.Text = "(Regedit Enabled)";
                }
            }
            reglm.Close();
            regName.Close();
        }
    }
}
