namespace MyNewWindowsService
{
    partial class MyWindowsService
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            //TODO: Change this name...
            this.ServiceName = "MyWindowsService";
        }
    }
}
