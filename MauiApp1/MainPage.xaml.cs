using ZXing.Net.Maui;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            cameraBarcodeReaderView.Options = new BarcodeReaderOptions
            {
                Formats = BarcodeFormats.OneDimensional,
                AutoRotate = true,
                Multiple = true
            };

            cameraBarcodeReaderView.IsTorchOn = !cameraBarcodeReaderView.IsTorchOn;
            cameraBarcodeReaderView.CameraLocation =  CameraLocation.Rear;

        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            foreach (var barcode in e.Results)
                Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
        }
    }
}
