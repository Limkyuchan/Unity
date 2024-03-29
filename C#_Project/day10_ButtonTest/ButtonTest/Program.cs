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
        static Button m_button;     // 버튼

        // 버튼 클릭 시 이벤트 함수
        static void OnClick(object sender, EventArgs e)
        {
            MessageBox.Show("You Died!");
        }

        // 윈도우 생성 함수
        static void CreateWindow()
        {
            // 윈도우 세팅 (크기, 배경 색)
            m_form = new Form();
            m_form.Width = 600;
            m_form.Height = 600;
            m_form.BackColor = Color.WhiteSmoke;

            // 버튼 세팅 (크기, 문구, 색, 위치, 이벤트)
            m_button = new Button();
            m_button.Width = 200;
            m_button.Height = 50;
            m_button.Text = "절대 누르지마시오";
            m_button.BackColor = Color.Red;
            m_button.Location = new Point((m_form.Width - m_button.Width) / 2, (m_form.Height - m_button.Height) / 2);      // 버튼 화면 정중앙에 위치 
            m_button.Click += OnClick;      // Click은 대리자

            // 버튼을 사용할 때는 윈도우에 추가해야 사용이 가능하다.
            m_form.Controls.Add(m_button);

            // 윈도우 출력
            m_form.ShowDialog();
        }

        [STAThread]     // Thread: 작업을 수행하는 단위

        static void Main()
        {
            CreateWindow();
        }
    }
}
