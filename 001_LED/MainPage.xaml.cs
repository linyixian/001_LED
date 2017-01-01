using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using Windows.Devices.Gpio;

// 空白ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 を参照してください

namespace _001_LED
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GpioPin pin = null;

        /// <summary>
        /// 
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            Led_On();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Led_On()
        {
            var gpio = GpioController.GetDefault();             //GPIOコントローラーの取得

            if (gpio != null)
            {
                pin = gpio.OpenPin(5);                          //GPIO5を使用
                pin.Write(GpioPinValue.High);                   //GPIO5をHigh（オンにする）
                pin.SetDriveMode(GpioPinDriveMode.Output);      //GPIO5を出力モードにする
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //終了処理
            pin.Dispose();
        }
    }
}
