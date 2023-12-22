using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        


        public DashboardPage()
        {
            InitializeComponent();
        }

        private void goToPage_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AuthBut_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/Pages/ServerList.xaml", UriKind.Relative));
        }

        private void HyperlinkSignUp_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string urlSignUp = e.Uri.AbsoluteUri;
            System.Diagnostics.Process.Start("explorer.exe", urlSignUp);
            e.Handled = true;
        }


        private void HyperlinkForgotPass_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            string urlForgotPass = e.Uri.AbsoluteUri;
            Process.Start("explorer.exe", urlForgotPass);
            e.Handled = true;
        }

        private void youtubeRedirect_Click(object sender, RoutedEventArgs e)
        {

            string urlYoutube = "https://www.youtube.com/@BrotherhoodForces";
            Process.Start( "explorer.exe", urlYoutube);


        }

        private void discordRedirect_Click(object sender, RoutedEventArgs e)
        {
            string urlDiscord = "https://discord.com/channels/1079515306420097034/1079515481406439444";
            Process.Start("explorer.exe", urlDiscord);
        }

        private void vkRedirect_Click(object sender, RoutedEventArgs e)
        {
            string urlVk = "https://vk.com/brotherhoodforces";
            Process.Start("explorer.exe", urlVk);
        }
    }
}
