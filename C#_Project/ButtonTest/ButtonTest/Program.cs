using System;
using System.Windows.Forms;
using System.Drawing;

namespace ButtonTest
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        /// 

        static Form m_form;         // Form: 윈도우

        [STAThread]   // Thread: 작업을 수행하는 단위

        static void Main()
        {
            m_form = new Form();

            // 윈도우 세팅 (크기, 배경 색)
            m_form.Width = 600;
            m_form.Height = 300;
            m_form.BackColor = Color.Aquamarine;

            // 윈도우 출력
            m_form.ShowDialog();

        }
    }
}