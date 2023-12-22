using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestLauncher.Views.Pages
{
    /// <summary>
    /// Interaction logic for ServerList.xaml
    /// </summary>
    public partial class ServerList : Page
    {
        public ServerList()
        {
            InitializeComponent();
        }

        private void vkRedirectS_Click(object sender, RoutedEventArgs e)
        {
            string urlVk = "https://vk.com/brotherhoodforces";
            Process.Start("explorer.exe", urlVk);
        }

        private void discordRedirecS_Click(object sender, RoutedEventArgs e)
        {
            string urlDiscord = "https://discord.com/channels/1079515306420097034/1079515481406439444";
            Process.Start("explorer.exe", urlDiscord);
        }

        private void youtubeRedirectS_Click(object sender, RoutedEventArgs e)
        {
            string urlYoutube = "https://www.youtube.com/@BrotherhoodForces";
            Process.Start("explorer.exe", urlYoutube);

        }
    }
}
